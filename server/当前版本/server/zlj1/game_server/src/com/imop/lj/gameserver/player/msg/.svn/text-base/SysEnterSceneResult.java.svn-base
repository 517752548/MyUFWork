package com.imop.lj.gameserver.player.msg;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerExitReason;
import com.imop.lj.gameserver.player.PlayerState;
import com.imop.lj.gameserver.scene.PlayerEnterSceneCallback;

/**
 * 进入场景结果，场景线程发给主线程
 * 
 * 
 */
public class SysEnterSceneResult extends SysInternalMessage {
	private boolean isSuccess;
	
	private int playerId;
	
	private PlayerEnterSceneCallback callback;

	public SysEnterSceneResult(boolean isSuccess, int playerId,PlayerEnterSceneCallback callback) {
		this.isSuccess = isSuccess;
		this.playerId = playerId;
		this.callback = callback;
	}

	@Override
	public void execute() {
		Player player = Globals.getOnlinePlayerService().getPlayerByTempId(
				playerId);
		if (player == null) {
			Loggers.gameLogger.error(String.format(
					"SysEnterSceneResult.execute player == null. id=%d",
					playerId));
			return;
		}
		
		if(player.getHuman() == null){
			Loggers.gameLogger.error(String.format(
					"SysEnterSceneResult.execute player.getHuman() == null. id=%d",
					playerId));
			return;
		}
		if(player.getHuman().getScene() == null){
			Loggers.gameLogger.error(String.format(
					"SysEnterSceneResult.execute player.getHuman().getScene() == null. id=%d",
					playerId));
			return;
		}
		
		if (player.getState() == PlayerState.logouting) {
			Globals.getOnlinePlayerService().offlinePlayer(player, player.exitReason);
			return;
		}
		if (!isSuccess) {
			Loggers.gameLogger
					.error("Enter scene result is false , will kick player:"
							+ player.getRoleUUID());
			Globals.getOnlinePlayerService().offlinePlayer(player, PlayerExitReason.SERVER_ERROR);
			return;
		}
		player.setState(PlayerState.gaming);
		if (callback != null) {
			callback.afterEnterScene(player);
		}
	}

}
