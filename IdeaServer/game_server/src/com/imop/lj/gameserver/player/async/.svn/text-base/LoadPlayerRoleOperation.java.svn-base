package com.imop.lj.gameserver.player.async;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.LoginLogReason;
import com.imop.lj.common.constants.DisconnectReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.db.dao.HumanDao;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerExitReason;
import com.imop.lj.gameserver.player.PlayerState;
import com.imop.lj.gameserver.player.msg.GCNotifyException;

import java.util.List;

/**
 * 加载角色所有数据的异步操作
 *
 *
 */
public class LoadPlayerRoleOperation implements BindUUIDIoOperation {

	private final Player player;
	private long roleUUID;

	/** 是否数据库操作成功 */
	private boolean isOperateSucc = false;
	
	private Human humanCache = null;

	/**
	 *
	 * @param player
	 *            玩家对象
	 * @param roleUUID
	 *            玩家角色
	 */
	public LoadPlayerRoleOperation(Player player, long roleUUID) {
		this.player = player;
		this.roleUUID = roleUUID;
	}

	@Override
	public int doIo() {
		// 玩家已断线，则不再做任何处理
		if (!player.isOnline()) {
			Loggers.loginLogger.error("GS#LoadPlayerRoleOperation.doIo 1:player is not online.passportId=" + player.getPassportId() + ";" + player.getClientIp());
			return STAGE_STOP_DONE;
		}
		do {
			try {
				// 加载帐户信息 ：
				this.loadAccountInfo();

				HumanDao _roleInfoDao = Globals.getDaoService().getHumanDao();
				HumanEntity entity = _roleInfoDao.get(this.roleUUID);

				Human human = new Human();
				human.fromEntity(entity);
				human.initInventory();
				String passportId = entity.getPassportId();
				if(!passportId.equalsIgnoreCase(player.getPassportId())){
						//账号不匹配
					player.sendMessage(new GCNotifyException(DisconnectReason.ENTER_SCENE_FAIL.code, Globals.getLangService().readSysLang(LangConstants.POSSPORTID_NOT_EQUAL_FAIL)));
					player.exitReason = PlayerExitReason.MULTI_LOGIN;
					player.disconnect();

					Loggers.loginLogger.info("GS#LoadPlayerRoleOperation.doIo 999:"
							+ "passportId:" + passportId + ";"
							+ "player.getPassportId():" + player.getPassportId() + ";"
							+ "UserName:"+ human.getName() + ";"
							+ "PlayerName:"+ player.getPassportName() + ";"
							+ "roleUUID:"+ roleUUID + ";"
							);
					return STAGE_STOP_DONE;
				}
				Loggers.loginLogger.info("GS#LoadPlayerRoleOperation.doIo 3:"
						+ "passportId:" + passportId + ";"
						+ "player.getPassportId():" + player.getPassportId() + ";"
						+ "UserName:"+ human.getName() + ";"
						+ "PlayerName:"+ player.getPassportName() + ";"
						+ "roleUUID:"+ roleUUID + ";"
						);
//				player.setPassportId(passportId);

				// 首先设置player,因为在之后的执行中可能会用到player
				player.setHuman(human);
				human.setPlayer(player);
				
				//TODO human.getVipManager().load();
				
				human.getPetManager().load();
				
//				human.getHorseManager().load();

				// 加载任务
				human.getCommonTaskManager().load();
				
				//加载酒馆任务
				human.getPubTaskManager().load();
				
				// 初始化宠物装备包裹
				human.getInventory().initPetBags();
				
//				// 初始化宠物宝石包裹
//				human.getInventory().initGemBags();
				
				
				// 加载物品
				human.getInventory().load();

				// 加载邮件
				human.getMailbox().load();
				
				// 加载离线奖励
				human.getOfflineRewardManager().load();
				
				// 加载关系
				human.getRelationManager().load();
				
				//加载除暴安良任务
				human.getTheSweeneyTaskManager().load();
				
				//加载藏宝图任务
				human.getTreasureMapManager().load();

				//加载护送粮草任务
				human.getForageTaskManager().load();
				
				//加载翅膀系统
				human.getWingManager().load();
				
				//加载帮派任务
				human.getCorpsTaskManager().load();
				
				//加载跑环任务
				human.getRingTaskManager().load();
				
				//围剿魔族任务
				human.getSiegeDemonNormalTaskManager().load();
				human.getSiegeDemonHardTaskManager().load();
				
				//加载七日目标任务
				human.getDay7TaskManager().load();
				
				// 因为涉及的到数据量可能较大,在加载完成后执行进入游戏的预处理,将相关的对象设置为Live
				human.checkAfterRoleLoad();
				// 设置成活动

				// 数据加载完成之后初始化
				human.onInit(Globals.getTemplateCacheService(), Globals.getLangService());
				human.getOnlineGiftManager().load();
				human.getSpecOnlineGiftManager().load();


//				// XXX 收藏功能检查
//				human.getGameFuncManager().checkBookMarkFunc();
//
//				// 检查vip通讯录功能
//				human.getGameFuncManager().checkAddressBookFunc();
//
//
//				//首冲功能检查
//				human.getGameFuncManager().checkFirstRecharge();
//
//				//加急领取功能检查
//				human.getGameFuncManager().checkExpeditedReceiveFunc();

				isOperateSucc = true;
			} catch (Exception e) {
				e.printStackTrace();
				isOperateSucc = false;
				Loggers.playerLogger.error(LogUtils.buildLogInfoStr(player
						.getRoleUUID() + "", "#GS.CharacterLoad.doIo"), e);
			}
		} while (false);
		return STAGE_IO_DONE;
	}

	/**
	 * 加载帐户信息
	 */
	private void loadAccountInfo() {
		// 获取并设置权限
		List<?> _roles = Globals.getDaoService().getDBService()
				.findByNamedQueryAndNamedParam("queryPlayerRole",
						new String[] { "id" },
						new Object[] { player.getPassportId() });
		if (_roles != null && _roles.size() > 0) {
			Object[] _userInfo = (Object[]) _roles.get(0);
			if (_userInfo != null && _userInfo.length > 1) {
				player.setPassportName((String) _userInfo[0]);
				player.setPermission((Integer) _userInfo[1]);
				// 在线时间在帐号登陆时设置，不直接通过数据库赋值 player.setTodayOnlineTime((Integer) _userInfo[2]);
				// 登出时间在帐号登录时已设置过，player.setLastLogoutTime((Timestamp) _userInfo[3]);				
			}
		}
	}

	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		// 玩家已断线，则不再做任何处理
		if (!player.isOnline()) {
			Loggers.loginLogger.error("GS#LoadPlayerRoleOperation.doStop 2:player is not online.passportId=" + player.getPassportId() + ";" + player.getClientIp());
			return STAGE_STOP_DONE;
		}
		
		try {
			Human human = null;
			//如果没有缓存数据，则再取一次，可能会取到
			if (humanCache == null) {
				humanCache = Globals.getHumanCacheService().getHuman(roleUUID);
				if (humanCache != null) {
					Loggers.loginLogger.warn("GS#LoadPlayerRoleOperation.doStop 119humanCache:start no human cache but after doIO add human cache!pid=" 
							+ player.getPassportId() + ";ip=" + player.getClientIp() + ";state=" + player.getState());
				}
			}
			
			if (humanCache != null) {
				human = humanCache;
				player.setHuman(human);
				human.setPlayer(player);
				isOperateSucc = true;
			} else {
				human = player.getHuman();
			}
			
			if (player.getState() == PlayerState.logouting || !isOperateSucc || human == null) {
				player.sendMessage(new GCNotifyException(
						DisconnectReason.FINISH_LOAD_HUMAN_EXCEPTION.code, Globals.getLangService().readSysLang(LangConstants.LOAD_PLAYER_SELECTED_ROLE)));
				player.exitReason = PlayerExitReason.SERVER_ERROR;
				player.disconnect();
				//XXX load 出现错误时 onlinePlayersMap 里对应player 对象里human为空 导致remove对象失败
				if(!isOperateSucc){
					Loggers.logoutLogger.info(player.getClientIp() + " 20、Player logout LoadPlayerRoleOperation.doStop " +
							" player passportId:" + player.getPassportId() +
							" player state:" + player.getState().name() +
							" human uuid:" + this.roleUUID);
					Globals.getOnlinePlayerService().forceKickOutPlayer(this.roleUUID);
				}
			} else {
				human.getInitManager().humanLogin();
				Globals.getLogService().sendPlayerLoginLog(human, LogReasons.PlayerLoginLogReason.PLAYER_LOGIN, "", player.getCurrTerminalType().getSource(), player.getLastLoginTime().getTime(), player.getSource());
				
				Globals.getLocalScribeService().sendScribeGameLoginOrOutReport(human, LoginLogReason.LOGIN, LoginLogReason.LOGIN.reasonText);
				
				//热云汇报
				Globals.getReyunService().reportLogin(player);
			}
		} catch (Exception e) {
			Loggers.playerLogger.error(LogUtils.buildLogInfoStr(
					player.getRoleUUID() + "", "#GS.CharacterLoad.doIo"), e);
			player.sendMessage(new GCNotifyException(
					DisconnectReason.FINISH_LOAD_HUMAN_EXCEPTION.code, Globals.getLangService().readSysLang(LangConstants.LOAD_PLAYER_SELECTED_ROLE)));
			player.exitReason = PlayerExitReason.SERVER_ERROR;
			player.disconnect();

		}
		return STAGE_STOP_DONE;
	}
	
	public void setHumanCache(Human humanCache) {
		this.humanCache = humanCache;
	}

	@Override
	public long getBindUUID() {
		return this.roleUUID;
	}
}
