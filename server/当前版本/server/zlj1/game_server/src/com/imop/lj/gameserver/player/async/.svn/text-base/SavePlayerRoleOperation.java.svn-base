package com.imop.lj.gameserver.player.async;

import java.sql.Timestamp;

import org.slf4j.Logger;

import com.imop.lj.common.LogReasons.LoginLogReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BindUUIDIoOperation;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerConstants;
import com.imop.lj.gameserver.player.PlayerState;

/**
 * 异步保存角色信息
 *
 * @author Fancy
 * @version 2009-8-4 下午02:38:40
 */
public class SavePlayerRoleOperation implements BindUUIDIoOperation {

	private Logger logoutLogger = Loggers.logoutLogger;

	/** 玩家 */
	private Player player;
	/** 保存信息 Mask */
	private int mask;
	/** */
	private boolean isLogoutSaving;
	/** */
	private Human human;
	/** 角色基础信息 */
	private HumanEntity humanEntity = null;
	/** 角色战斗快照信息 */
//	private BattleSnapEntity battleSnapEntity = null;
	
	private boolean isShutDownServer = false;


	public SavePlayerRoleOperation(Player player, int mask,
			boolean isLogoutSaving) {
		this.player = player;
		this.mask = mask;
		this.isLogoutSaving = isLogoutSaving;
	}

	@Override
	public int doStart() {
		this.human = player.getHuman();
		if (human == null) {
			// 如果玩家没有角色绑定,则忽略保存,直接返回STATE_IO_DONE,进入下一个阶段
			return STAGE_IO_DONE;
		}
		try {
			if (isLogoutSaving) {
				human.logLogout();//Must be invoked before human.toEntity()
			}
			if ((mask & PlayerConstants.CHARACTER_INFO_MASK_BASE) != 0) {
				this.humanEntity = human.toEntity();
			}
//			if ((mask & PlayerConstants.CHARACTER_INFO_MASK_BATTLE_SNAP) != 0) {
//				this.battleSnapEntity = human.getBattleManager().buildBattleSnapEntity();
//
//				// 让鲜花场景处理，防止多线程    更新缓存
//				if (this.battleSnapEntity != null) {
//					IMessage msg = new ModfyHumanInfoMessage(this.battleSnapEntity);
//					Globals.getSceneService().getFlowersScene().putMessage(msg);
//				}
//			}
		} catch (Exception e) {
			Loggers.playerLogger.error(LogUtils.buildLogInfoStr(human
				.getUUID() + "", String.format(
					"Conventer error. pid=%s,cid=%s", humanEntity != null ? humanEntity
							.getPassportId() : "", humanEntity != null ? humanEntity.getId() : 0)), e);
		}
		return STAGE_START_DONE;
	}

	@Override
	public int doIo() {
		do {
			// 保存玩家的基本数据到数据库
			try {
				if (this.humanEntity != null) {
					Globals.getDaoService().getHumanDao().update(humanEntity);
//					Globals.getHumanService().syncCacheEntity(humanEntity);
					if (isLogoutSaving) {
						//记录日志
						Loggers.playerLogger.info("#SavePlayerRoleOperation#doIo#direct save humanEntity.roleId=" + 
								humanEntity.getId() + ";pid=" + humanEntity.getPassportId() + ";isLogoutSaving=" + isLogoutSaving);

					}
				}

//				if (this.battleSnapEntity != null) {
//					Globals.getDaoService().getBattleSnapDao().saveOrUpdate(battleSnapEntity);
//				}

				if (isLogoutSaving) {
					Timestamp lastLoginTime = human.getLastLoginTime();

					if(lastLoginTime != null)
					{
						// 如果跨天，对管理开始时间清零，当日历史累计在线时长清零，重新计算提醒时间
//						long now = Globals.getTimeService().now();
//						if (!TimeUtils.isSameDay(human.getLastLoginTime().getTime(), now)) {
//							int time = (int) (now - TimeUtils.getTodayBegin(Globals.getTimeService())) / 1000 / 60;
//							human.getPlayer().setTodayOnlineTime(time);
//							human.getPlayer().setTodayOnlineUpdateTime(new Timestamp(now));
//						} else {
//							human.getPlayer().setTodayOnlineTime((int) (now - human.getLastLoginTime().getTime()) / 1000 / 60);
//						}
//						
						long todayOnlineTime = Globals.getWallowService().getTodayOnlineTimeAndUpdate(player);
						player.setTodayOnlineTime((int)todayOnlineTime);
						
//						// qq数据保存
//						String qqData = player.getQqDataManager().toJsonProp();
//						
//						// 更新UserInfo的当日累计在线时间
//						Globals.getDaoService().getHumanDao().updatePlayerOnlineTime(
//										human.getPlayer().getPassportId(),
//										human.getPlayer().getLastLoginTime(),
//										human.getPlayer().getTodayOnlineUpdateTime(),
//										human.getPlayer().getTodayOnlineTime(),
//										qqData);
					}
					
					Globals.getLocalScribeService().sendScribeGameLoginOrOutReport(human, LoginLogReason.LOGOUT, LoginLogReason.LOGOUT.reasonText);
				}
			} catch (Exception e) {
				Loggers.playerLogger.error(LogUtils.buildLogInfoStr(human.getUUID() + "", "Save character base info error."), e);
			}

		} while (false);
		return STAGE_IO_DONE;
	}

	@Override
	public int doStop() {
		if (isLogoutSaving && !isShutDownServer) {
			logoutLogger.info(player.getClientIp() + " 15、Player logout SavePlayerRoleOperation.doStop " +
					" player passportId" + player.getPassportId() +
					" player state" + player.getState().name());
			player.setState(PlayerState.logouting);
			Globals.getOnlinePlayerService().removeSession(player.getSession());
			Globals.getOnlinePlayerService().removePlayer(player);
		}
		return STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return this.player.getHuman().getUUID();
	}
	
	/**
	 * 设置是否是关闭服务器调用
	 * 
	 * 此变量控制是否要保留OnlinePlayerService中缓存信息
	 * 关服时要使用OnlinePlayerService中缓存信息将用户信息同步更新一下
	 * 
	 * @param isShutDownServer
	 */
	public void setShutDownServer(boolean isShutDownServer) {
		this.isShutDownServer = isShutDownServer;
	}
}
