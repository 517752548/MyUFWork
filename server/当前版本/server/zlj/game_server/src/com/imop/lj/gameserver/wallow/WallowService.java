package com.imop.lj.gameserver.wallow;

import java.util.ArrayList;
import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.DisconnectReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.WallowConstants;
import com.imop.lj.common.constants.WallowConstants.WallowStatus;
import com.imop.lj.core.schedule.ScheduleService;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.i18n.LangService;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerExitReason;
import com.imop.lj.gameserver.player.msg.GCNotifyException;
import com.imop.lj.gameserver.wallow.async.FetchOnlineTimeOperation;
import com.imop.lj.gameserver.wallow.msg.GCWallowOpenPanel;
import com.imop.lj.gameserver.wallow.msg.ScheduleSyncWallowOnlineTime;
import com.imop.lj.gameserver.wallow.msg.SysWallowTickerServiceStart;
import com.imop.lj.gameserver.wallow.msg.WallowOnlineTimeMsg;

/**
 * 防沉迷服务
 * 
 * 
 */
public class WallowService {
	private final static Logger logger = Loggers.wallowLogger;
	private WallowLogicalProcessor wallowProcessor;
	private LangService langService;
	private OnlinePlayerService onlinePlayerSerice;

	/** 定时任务服务 */
	private ScheduleService schService;

	public WallowService(ScheduleService schService, WallowLogicalProcessor wallowProcessor, LangService langService,
			OnlinePlayerService onlinePlayerSerice) {
		this.schService = schService;
		this.wallowProcessor = wallowProcessor;
		this.langService = langService;
		this.onlinePlayerSerice = onlinePlayerSerice;
	}
	
	public void checkOnLogin(Player player) {
		if (player == null) {
			Loggers.wallowLogger.error("#WallowService#checkOnLogin#player is null!");
			return;
		}
		
		if (Globals.getServerConfig().isWallowControlled() 
				// TODO 任全登陆类型都要进行防沉迷 
				// &&  player.getCurrTerminalType() == TerminalTypeEnum.WEB 
//				&& !player.isQuickLoginAccount() // 快客先注掉 TODO
				) {
			// 发送防沉迷信息
			if (player.getWallowFlag() == WallowConstants.WALLOW_FLAG_ON) {
				player.setAccOnlineTime(0);
				onPlayerEnter(player);

				if (Globals.getServerConfig().isWallowControlled()) {
					// 给出提示框，完善资料
					sendWallowAddInfo(player);
				}
			} else {
				onPlayerExit(player.getPassportId());
			}
		} else {
			onPlayerExit(player.getPassportId());
		}
	}

	public void onPlayerEnter(Player _player) {
		if (_player == null) {
			if (logger.isWarnEnabled()) {
				logger.warn(ErrorsUtil.error("", "#WS.WallowLogicalProcessor.onPlayerEnter", ""));
			}
			return;
		}
		
		if (!Globals.getServerConfig().isWallowControlled()) {
			return;
		}
		
		// 加入反沉迷列表吧
		wallowProcessor.addWallowUser(_player.getPassportId());

		// 立即获取玩家的反沉迷状态
		List<String> _players = new ArrayList<String>(1);
		_players.add(_player.getPassportId());
		Globals.getAsyncService().createOperationAndExecuteAtOnce(new FetchOnlineTimeOperation(_players));
	}

	/**
	 * 玩家退出请离防沉迷列表
	 * 
	 * @param wallowExitMsg
	 */
	public void onPlayerExit(String passportId) {
		wallowProcessor.removeWallowUser(passportId);
	}

	/**
	 * 当从接口成功取得玩家的累计时长时，调用本方法处理防沉迷状态
	 * 
	 * @param player
	 * @param second
	 */
	public void onPlayerOnlineTimeSynced(WallowOnlineTimeMsg timeMsg) {
		List<String> _players = timeMsg.getPlayers();
		List<Long> _seconds = timeMsg.getSeconds();
		if (_players.size() != _seconds.size()) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error("", "#WS.WallowLogicalProcessor.onPlayerOnlineTimeSynced", ""));
			}
			return;
		}

		for (int i = 0; i < _players.size(); i++) {
			String _passportId = _players.get(i);
			long _second = _seconds.get(i);
			Player _player = onlinePlayerSerice.getPlayerByPassportId(_passportId);
			if (_player == null) {
				// 玩家已经下线了
				continue;
			}
			if (_second == -1) {
				// 调用累计时长接口时发生错误
				continue;
			}
			if (_second == 0) {
				continue;
			}
			// 以此处理吧
			processPlayerOnlineTime(_player, _second);
		}
	}

	/**
	 * 异步地同步反沉迷玩家的在线累计时长
	 */
	public void syncWallowPlayerOnlineTime() {
		if (!Globals.getServerConfig().isWallowControlled()) {
			// 开关没有打开
			return;
		}

		if (wallowProcessor.isAllWaitersSync()) {
			wallowProcessor.clearWaiters();
			wallowProcessor.pumpWaiters();
		}
		List<String> _syncList = wallowProcessor.getNextWaiters();
		if (_syncList.size() > 0) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(new FetchOnlineTimeOperation(_syncList));
			wallowProcessor.incCounter();
		}
	}

	/**
	 * 防沉迷控制关闭相关处理
	 */
	public void onWallowClosed() {
		for (String _pid : wallowProcessor.getAllWallowUsers()) {
			Player _player = onlinePlayerSerice.getPlayerByPassportId(_pid);
			if (_player != null) {
				int _oldUnit = _player.getAccOnlineTime() / WallowConstants.TIME_EXTEND_UNIT;
				// 已经处理非正常收益状态的玩家，发送消息通知其恢复正常收益
				if (_oldUnit >= WallowConstants.NORMAL_UP_INDEX) {
					if (_player.getWallowState() != WallowStatus.NORMAL) {
						_player.setWallowState(WallowStatus.NORMAL);
						_player.sendSystemMessage(LangConstants.WALLOW_CLOSE_NORMAL);
					}
				}
			}
		}
	}

	/**
	 * 防沉迷控制开启相关处理
	 */
	public void onWallowOpened() {
		for (String _pid : wallowProcessor.getAllWallowUsers()) {
			Player _player = onlinePlayerSerice.getPlayerByPassportId(_pid);
			if (_player != null) {
				int _oldUnit = _player.getAccOnlineTime() / WallowConstants.TIME_EXTEND_UNIT;
				// 已经处于非正常收益状态的玩家，发送消息通知GS
				if (_oldUnit >= WallowConstants.NORMAL_UP_INDEX) {
					WallowStatus state = getWallowState(_oldUnit);
					if (_player.getWallowState() != state) {
						_player.setWallowState(state);

						// 提示
						if (state == WallowStatus.WARN) {
							sendWallowAddInfo(_player);
							_player.sendBoxMessage(LangConstants.WALLOW_OPEN_WARN);
						} else if (state == WallowStatus.DANGER) {
							sendWallowAddInfo(_player);
							_player.sendBoxMessage(LangConstants.WALLOW_OPEN_DANGER);
						}
					}
				}
			}
		}
	}

	/**
	 * 处理单个玩家的在线累计时长
	 * 
	 * @param player
	 * @param second
	 */
	private void processPlayerOnlineTime(Player player, long second) {

		int _oldsec = player.getAccOnlineTime();

		int _oldUnit = _oldsec / WallowConstants.TIME_EXTEND_UNIT;
		int _newUnit = (int) (second / WallowConstants.TIME_EXTEND_UNIT);

		int _oldExtend = wallowProcessor.getTimeExtend(_oldUnit);
		int _newExtend = wallowProcessor.getTimeExtend(_newUnit);

		player.setAccOnlineTime((int) second);
		if (_newUnit >= WallowConstants.NORMAL_UP_INDEX) {
			player.sendMessage(new GCNotifyException(DisconnectReason.WALLOW_KICK.code, langService
					.readSysLang(LangConstants.WALLOW_CANNOT_LOGIN_STATUS)));
			player.exitReason = PlayerExitReason.WALLOW_KICK;
			player.disconnect();
		}

		// _oldsec大于0保证首次登录，有防沉迷提醒到GS,初始化防沉迷系数
		if (_oldsec > 0 && _oldExtend == _newExtend) {
			// 时间区间没有发生变化
			return;
		}
		// 通知gs玩家时间区间发生改变
		wallowRemind(player, second, _newUnit, _newExtend);

	}

	/**
	 * 向玩家所在的GS发送提示
	 * 
	 * @param player
	 * @param second
	 *            累计在线时间
	 * @param _newUnit
	 *            多少个以15分钟为单位的单元
	 * @param _newExtend
	 *            第几个小时区间
	 */
	public void wallowRemind(Player player, long second, int _newUnit, int _newExtend) {

		WallowStatus _state = getWallowState(_newUnit);

		if (_state == null) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error("防沉迷状态错误定义", "#GS.WallowService.wallowRemind", String.valueOf(_newUnit)));
			}
			return;
		}

		int _minute = (int) (second / 60);

		// 防沉迷状态发生，修正系数相关
		if (player.getWallowState() != _state) {
			// TODO:修正防沉迷系数
			player.setWallowState(_state);
		}

		// 根据策划需求对防沉迷做一些修改
		if (_minute > 12 * WallowConstants.TIME_EXTEND_MIN_UNIT && _minute <= 24 * WallowConstants.TIME_EXTEND_MIN_UNIT) {
			player.sendSystemMessage(LangConstants.WALLOW_SAFE_STATUS, _minute / 60, _minute % 60);
			player.sendBoxMessage(LangConstants.WALLOW_SAFE_STATUS, _minute / 60, _minute % 60);
		} else if (_minute > 24 * WallowConstants.TIME_EXTEND_MIN_UNIT && _minute <= 35 * WallowConstants.TIME_EXTEND_MIN_UNIT) // 2:30
		{
			player.sendSystemMessage(LangConstants.WALLOW_SAFE_STATUS, _minute / 60, _minute % 60);
			player.sendBoxMessage(LangConstants.WALLOW_SAFE_STATUS, _minute / 60, _minute % 60);
		}
		// else if(_minute > 30 * WallowConstants.TIME_EXTEND_MIN_UNIT &&
		// _minute <= 33 * WallowConstants.TIME_EXTEND_MIN_UNIT) // 2:45
		// {
		// player.sendSystemMessage(LangConstants.WALLOW_ENTERING_WARN_STATUS,
		// 36 * WallowConstants.TIME_EXTEND_MIN_UNIT - _minute);
		// }
		// else if(_minute > 33 * WallowConstants.TIME_EXTEND_MIN_UNIT &&
		// _minute <= 34 * WallowConstants.TIME_EXTEND_MIN_UNIT) // 2:50
		// {
		// player.sendSystemMessage(LangConstants.WALLOW_ENTERING_WARN_STATUS,
		// 36 * WallowConstants.TIME_EXTEND_MIN_UNIT - _minute);
		// }
		// else if(_minute > 34 * WallowConstants.TIME_EXTEND_MIN_UNIT &&
		// _minute <= 35 * WallowConstants.TIME_EXTEND_MIN_UNIT) // 2:55
		// {
		// player.sendSystemMessage(LangConstants.WALLOW_ENTERING_WARN_STATUS,
		// 36 * WallowConstants.TIME_EXTEND_MIN_UNIT - _minute);
		// }
		else if (_minute > 35 * WallowConstants.TIME_EXTEND_MIN_UNIT && _minute <= 36 * WallowConstants.TIME_EXTEND_MIN_UNIT) // 2:55
																																// ~
																																// 3:00
		{
			player.sendSystemMessage(LangConstants.WALLOW_BEING_KICK_OFF_STATUS);
			player.sendBoxMessage(LangConstants.WALLOW_BEING_KICK_OFF_STATUS);
		}
	}

	public void sendWallowAddInfo(Player player) {
		player.sendMessage(new GCWallowOpenPanel());
	}

	/**
	 * 获取防沉迷状态
	 * 
	 * @param unit
	 * @return
	 */
	public WallowStatus getWallowState(int unit) {
		if (unit < WallowConstants.NORMAL_UP_INDEX) {
			return WallowStatus.NORMAL;
		} else if (unit < WallowConstants.WARN_UP_INDEX) {
			return WallowStatus.WARN;
		}
		return WallowStatus.DANGER;
	}

	/**
	 * 开始方法
	 * <p>
	 * 该方法会通过内部消息的方式来启动service，这样做是为了让主消息线程来调用{@link #startService()}
	 */
	public void start() {
		Globals.getMessageProcessor().put(new SysWallowTickerServiceStart());
	}

	/**
	 * 开始服务
	 */
	public void startService() {
		// 周期性的同步防沉迷列表的在线时长
		this.schService.scheduleWithFixedDelay(new ScheduleSyncWallowOnlineTime(Globals.getTimeService().now()), Globals.getServerConfig()
				.getWallowPeriod() * 1000, Globals.getServerConfig().getWallowPeriod() * 1000);
	}
	
	//-------------------------------在线时长计算-------------------------------------
	/**
	 * 获取玩家在线时长，并且更新数据
	 * 
	 * 
	 * @param player
	 * @return
	 */
	public long getTodayOnlineTimeAndUpdate(Player player){
		if(player == null){
			return -1;
		}
		
		long now = Globals.getTimeService().now();	
//		if(TimeUtils.isSameDay(player.getTodayOnlineUpdateTime().getTime(), now)){
//			return (int)(player.getTodayOnlineTime() + (now - player.getTodayOnlineUpdateTime().getTime()) / 1000);
//		}else{
//			// 如果不在一天，则更新今日在线时长
//			player.setTodayOnlineUpdateTime(new Timestamp(now));
//			player.setTodayOnlineTime((int) ((now - TimeUtils.getTodayBegin(Globals.getTimeService())) / 1000));
//			return player.getTodayOnlineTime();
//		}
		
		//TODO 以上规则已做修改，当前在线时间=累积在线时间+（现在时间 - 最后一次登陆时间），单位秒	
		return (int)(player.getTodayOnlineTime() + (now - player.getLastLoginTime().getTime()) / 1000);
	}
}
