package com.imop.lj.gameserver.player.async;

import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.BindUUIDIoOperation;
import com.imop.lj.gameserver.player.Player;

/**
 * 加载t_user_info数据的异步操作
 *
 */
public class LoadPlayerAccountOperation implements BindUUIDIoOperation {

	private final Player player;
	private long roleUUID;
	private boolean loadFlag;
	private LoadPlayerRoleOperation loadTask;

	public LoadPlayerAccountOperation(Player player, long roleUUID, LoadPlayerRoleOperation loadTask) {
		this.player = player;
		this.roleUUID = roleUUID;
		this.loadTask = loadTask;
	}

	@Override
	public int doIo() {
		try {
			// 加载帐户信息 ：
			this.loadAccountInfo();
			loadFlag = true;
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.playerLogger.error(LogUtils.buildLogInfoStr(player
					.getRoleUUID() + "", "#GS.CharacterLoad.doIo"), e);
		}
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
		if (loadFlag && loadTask != null) {
			Loggers.loginLogger.info("#LoadPlayerAccountOperation#doStop#will call LoadPlayerRoleOperation.doStop.humanId=" + 
					roleUUID + ";pid=" + player.getPassportId());
			//保证doStop在主线程做，不阻塞场景线程，human.getInitManager().humanLogin()执行起来较慢
			loadTask.doStop();
		}
		return STAGE_STOP_DONE;
	}
	
	@Override
	public long getBindUUID() {
		return this.roleUUID;
	}
}
