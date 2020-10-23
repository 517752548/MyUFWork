package com.imop.lj.gameserver.player.async;


import java.sql.Timestamp;

import net.sf.json.JSONObject;

import org.slf4j.Logger;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.DisconnectReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.common.constants.WallowConstants;
import com.imop.lj.core.enums.AccountState;
import com.imop.lj.core.i18n.SysLangService;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.db.model.UserInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.LocalBindUUIDIoOperation;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerExitReason;
import com.imop.lj.gameserver.player.PlayerState;
import com.imop.lj.gameserver.player.auth.AuthResult;
import com.imop.lj.gameserver.player.auth.UserAuth;
import com.imop.lj.gameserver.player.msg.GCNotifyException;

/**
 * 加载角色所有数据的异步操作
 *
 *
 */
public class PlayerTokenLoginOperation implements LocalBindUUIDIoOperation {

	private Logger logoutLogger = Loggers.logoutLogger;

	private final Player player;

	private UserAuth userAuth;

	private SysLangService langService;

	private UserInfo userInfo;

	/** 是否数据库操作成功 */
	private boolean authResult = false;

	private Logger logger = Loggers.loginLogger;
	
	private String token;
	private String pid;
	private long rid;

	/**
	 *
	 * @param player
	 *            玩家对象
	 * @param roleUUID
	 *            玩家角色
	 */
	public PlayerTokenLoginOperation(Player player, String token, String pid, long rid,
			UserAuth userAuth, SysLangService langService) {
		this.player = player;
		this.userAuth = userAuth;
		this.langService = langService;
		
		this.token = token;
		this.pid = pid;
		this.rid = rid;
	}

	@Override
	public int doIo() {
		long timeStart = System.currentTimeMillis();
		authResult = authUser();
		String userId = userInfo == null ? "" : userInfo.getId();
		Loggers.loginLogger.info("PlayerTokenLoginOperation.doIo() passportId=" + userId + 
				" token="+token+" timeStart="+timeStart+" timeBlank="+(System.currentTimeMillis()-timeStart));
		return STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		long timeStart = System.currentTimeMillis();
		if (!authResult) {
			player.disconnect();
		}else{
			player.setState(PlayerState.auth);
			//设置Player的passwordId
			player.setPassportId(userInfo.getId());
			Loggers.loginLogger.info("GS#LoadPlayerRoleOperation.doIo 2:"
					+ "passportId:" + userInfo.getId() + ";"
					+ "userName:"+ userInfo.getName() + ";"
					);
			player.setWallowFlag(userInfo.getWallowFlag());

			//XXX 快速登录处理
//			player.setQuickLoginAccount(userInfo.isQuickLoginAccount());
//			player.setReadyBandQuickLogin(userInfo.isReadyBandQuickLogin());
//			player.setQuickLogin(userInfo.isQuickLogin());
//			player.setBandPassportId(userInfo.getBandPassportId());
			player.setCookieValue(userInfo.getCookieValue());
			Loggers.loginLogger.info("GS#LoadPlayerRoleOperation.doStop 1:"
					+ "passportId:" + userInfo.getId() + ";"
					+ "userName:"+ userInfo.getName() + ";"
//					+ "isQuickLoginAccount:"+ userInfo.isQuickLoginAccount() + ";"
//					+ "isReadyBandQuickLogin:"+ userInfo.isReadyBandQuickLogin() + ";"
//					+ "isQuickLogin:"+ userInfo.isQuickLogin() + ";"
					);

			Globals.getLoginLogicalProcessor().loadCharacters(player, false, 0);
		}
		String userId = userInfo == null ? "" : userInfo.getId();
		Loggers.loginLogger.info("PlayerCookieLoginOperation.doStop() passportId="+
				userId+" token="+token+" timeStart="+timeStart+" timeBlank="+(System.currentTimeMillis()-timeStart));
		return STAGE_STOP_DONE;
	}

	/**
	 * @param player
	 * @param cookieValue
	 * @return
	 */
	private boolean authUser() {
		if (!checkSession(player)) {
			return false;
		}
		
		AuthResult result = this.userAuth.auth(player, token, pid, rid);
		return handleAuthResult(player, result);
	}

	private boolean handleAuthResult(Player player, final AuthResult result) {
		if (result == null) {
			// 登录失败
			player.sendErrorMessage(langService.read(LangConstants.LOGIN_VALIDATE_ERROR));
			return false;
		}
		if (!result.success) {
			// 登录失败
			//player.sendErrorMessage(result.message);
			player.sendMessage(new GCNotifyException(DisconnectReason.TOKEN_VALID_FAIL.code,result.message));
			player.exitReason = PlayerExitReason.LOGOUT;
			logger.info("PlayerCookieLoginOperation.handleAuthResult " + "NotifyException" + DisconnectReason.TOKEN_VALID_FAIL.code + " " + result.message) ;
			return false;
		}

		this.userInfo = result.userInfo;

		// final long localAccOnlineTime = result.localAccOnlineTime;
        
		// TODO 测试使用， 在线时长赋值
		if (WallowConstants.debug) {
			Loggers.loginLogger.warn("normal login : passportId = "	+ userInfo.getId());
			Loggers.loginLogger.warn("normal login : lastLogoutTime = "	+ userInfo.getLastLogoutTime());
			Loggers.loginLogger.warn("normal login : todayOnlineTime = " + userInfo.getTodayOnlineTime());
			Loggers.loginLogger.warn("normal login : todayOnlineUpdateTime = " + userInfo.getTodayOnlineUpdateTime());
		}
		player.setLastLoginTime(new Timestamp(Globals.getTimeService().now()));
		player.setLastLogoutTime(result.userInfo.getLastLogoutTime());
		player.setTodayOnlineTime(result.userInfo.getTodayOnlineTime());
		player.setTodayOnlineUpdateTime(result.userInfo.getTodayOnlineUpdateTime());
		player.setActivity(result.userInfo.getActivity() == 1);

		// 登陆墙不允许普通玩家登陆
		if (userInfo.getRole() == 0
				&& Globals.getServerConfig().isLoginWallEnabled()) {
			player.sendErrorMessage(langService
					.read(LangConstants.LOGIN_ERROR_WALL_CLOSED));
			return false;
		}

		if (Globals.getServerConfig().isWallowControlled() && player.getCurrTerminalType() == TerminalTypeEnum.WEB 
//				&& !this.userInfo.isQuickLoginAccount()
				) {

			if (userInfo.getWallowFlag() == WallowConstants.WALLOW_FLAG_ON) {
				//如果当前登陆时间-上次登出时间>=指定时间，则将在线时间清除
				if(player.getLastLogoutTime() == null || player.getLastLoginTime().getTime() - player.getLastLogoutTime().getTime() >= WallowConstants.WALLOW_CLEAR_TIME){
					if(Loggers.loginLogger.isWarnEnabled()){
						Loggers.loginLogger.warn("PlayerLoginOperation.checkOnLogin lastLoginTime = " + player.getLastLoginTime() + ", lastLogoutTime = " + player.getLastLogoutTime() + " , offline time gt 5 hour, clear online time");
					}
					player.setTodayOnlineTime(0);
				}
				
				// 登陆
				if(player.getTodayOnlineTime() >= 36 * WallowConstants.TIME_EXTEND_UNIT)
				{
					player.sendMessage(new GCNotifyException(DisconnectReason.WALLOW_KICK.code,langService.read(LangConstants.WALLOW_CANNOT_LOGIN_STATUS)));
					player.exitReason = PlayerExitReason.WALLOW_KICK;
					logger.info("PlayerCookieLoginOperation.handleAuthResult userInfo passportID:" + userInfo.getId() + "NotifyException" + DisconnectReason.WALLOW_KICK.code);
					return false;
				}
			}
		}

		// 检查是否处于锁定等非法状态
		if (!checkState(player, userInfo)) {
			return false;
		}

		//TODO 获得禁言时间 从userInfo里
		/***
		 * 1、player对象加禁言时间属性
		 * 2、读取userInfo里获得放进player里
		 */
		player.setForibedTime(userInfo.getForibedTalkTime());

		Player existPlayer = Globals.getOnlinePlayerService().getPlayerByPassportId(userInfo.getId());
//		System.out.println("+++++++" + userInfo.getId() + "+++++++++++++++");
//		System.out.println("+++++++++exitPlayer:" + (existPlayer == null) + "++++++++++++++++");
//		System.out.println("+++++++++state" + existPlayer.getState() + "++++++++++++++++");
//		 玩家已在线
		if (existPlayer != null) {
//			System.out.println("+++++++++state" + existPlayer.getState() + "++++++++++++++++");
			// 踢掉当前在线玩家，通知当前登录玩家稍后重试
			if (existPlayer.getState() != PlayerState.logouting) {
				if(existPlayer.getHuman() != null){
					long now = Globals.getTimeService().now();
					Globals.getLogService().sendPlayerLoginLog(existPlayer.getHuman(), LogReasons.PlayerLoginLogReason.PLAYER_LOGOUT_EXIST_KICK, existPlayer.getClientIpOnLoginLog(), existPlayer.getCurrTerminalType().getSource(), now, existPlayer.getSource());
				}
				
				existPlayer.sendMessage(new GCNotifyException(DisconnectReason.LOGIN_ON_ANOTHER_CLIENT.code, langService.read(LangConstants.LOGIN_ONLINE_ERROR)));
				existPlayer.exitReason = PlayerExitReason.MULTI_LOGIN;
				existPlayer.disconnect();

				player.sendMessage(new GCNotifyException(DisconnectReason.LOGIN_ON_ANOTHER_CLIENT.code,langService.read(LangConstants.LOGIN_ONLINE_ERROR)));
				player.exitReason =  PlayerExitReason.MULTI_LOGIN;
				player.disconnect();

				logoutLogger.info("GS#PlayerCookieLoginOperation.handleAuthResult player passportID:" + existPlayer.getPassportId() + "NotifyException" + DisconnectReason.LOGIN_ON_ANOTHER_CLIENT.code);
				return false;
			}else{
				player.sendMessage(new GCNotifyException(DisconnectReason.LOGIN_ON_ANOTHER_CLIENT.code,langService.read(LangConstants.LOGIN_ONLINE_ERROR)));
				player.exitReason =  PlayerExitReason.MULTI_LOGIN;
				player.disconnect();
				logoutLogger.info("------------------existPlayer " + existPlayer.getState());
			}
		}

		return true;
	}

	private boolean checkSession(Player player) {
		player.setState(PlayerState.connected);
		// 判断session : 验证过程中可能掉线
		if (player.getSession() == null) {
			return false;
		}
		return true;
	}

	/**
	 * 检查玩家状态
	 *
	 * @return
	 */
	private boolean checkState(final Player player, final UserInfo userInfo) {
		AccountState _state = AccountState.indexOf(userInfo.getLockStatus());
		if (_state == AccountState.NORMAL) {
			return true;
		} else if (_state == AccountState.LOCKED) {
			// 获取锁定原因
			String _reason = null;
			if (userInfo.getProps() != null) {
				JSONObject _json = JSONObject.fromObject(userInfo.getProps());
				JSONObject _lockJson = JsonUtils.getJSONObject(_json, "lock");
				if (_lockJson != null) {
					_reason = JsonUtils.getString(_lockJson, "reason");
				}
			}
			player.sendErrorMessage(langService.read(
					LangConstants.LOGIN_ERROR_ACCOUNT_LOCKED,
					_reason == null ? " " : _reason));
		} else {
			player.sendErrorMessage(langService
					.read(LangConstants.LOGIN_ERROR_ACCOUNT_STATE));
		}
		return false;
	}

	@Override
	public long getBindUUID() {
		return this.player.getRoleUUID();
	}
}
