package com.imop.lj.gameserver.player.msg;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerState;
import com.imop.lj.gameserver.scene.PlayerLeaveSceneCallback;

/**
 * 离开场景结果，场景线程发给主线程
 * 
 */
public class SysLeaveSceneResult extends SysInternalMessage {
	private int playerId;
	
	private PlayerLeaveSceneCallback callback;


	public SysLeaveSceneResult(int playerId,PlayerLeaveSceneCallback callback) {
		this.playerId = playerId;
		this.callback = callback;
	}

	@Override
	public void execute() {
		Player player = Globals.getOnlinePlayerService().getPlayerByTempId(
				playerId);
		if (player == null) {
			return;
		}
		
		if(player.getHuman() == null){
			return;
		}
		
		if(player.getHuman().getScene() == null){
			Loggers.gameLogger.warn("player.human.scene is null!playerId=" + player.getPassportId() + 
					";humanId=" + player.getCharId() + ";curSceneId=" + player.getSceneId());
			return;
		}
		
		player.getHuman().setScene(null);
		
		if (player.getState() == PlayerState.logouting) {
			Globals.getOnlinePlayerService().offlinePlayer(player,player.exitReason);
			return;
		}
		if (player.getState() != PlayerState.leaving) {
			Loggers.gameLogger.warn("玩家离开场景回到主线程之后的场景不是leaving状态" + player.getPassportId() + 
					";humanId=" + player.getCharId());
		}
		if (callback != null) {
			callback.afterLeaveScene(player);
		}
	}

}
