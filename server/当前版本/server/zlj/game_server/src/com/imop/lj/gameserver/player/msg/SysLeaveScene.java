package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.scene.PlayerLeaveSceneCallback;
import com.imop.lj.gameserver.scene.handler.SceneHandlerFactory;

/**
 * 离开场景请求，主线程发给场景线程
 * 
 * @author zhangwh
 * @since 2010-6-8
 */
public class SysLeaveScene extends SysInternalMessage {

	private int playerId;
	private int sceneId;
	
	private PlayerLeaveSceneCallback callback;

	public int getPlayerId() {
		return playerId;
	}

	public SysLeaveScene(int playerId, int sceneId,PlayerLeaveSceneCallback callback) {
		super();
		this.playerId = playerId;
		this.sceneId = sceneId;
		this.callback = callback;
	}


	public void setPlayerId(int playerId) {
		this.playerId = playerId;
	}

	public int getSceneId() {
		return sceneId;
	}

	public void setSceneId(int sceneId) {
		this.sceneId = sceneId;
	}

	@Override
	public String getTypeName() {
		return "SysLeaveSceneMsg";
	}

	@Override
	public void execute() {
		Player player = Globals.getOnlinePlayerService().getPlayerByTempId(playerId);
		if (player == null) {//maybe the player has exit
			return;
		}
		SceneHandlerFactory.getHandler().handleLeaveScene(playerId, sceneId);
		SysLeaveSceneResult resultMsg = new SysLeaveSceneResult(playerId,callback);
		Globals.getMessageProcessor().put(resultMsg);
	}

}
