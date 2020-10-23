package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.scene.PlayerEnterSceneCallback;
import com.imop.lj.gameserver.scene.handler.SceneHandlerFactory;

public class SysEnterScene extends SysInternalMessage{
	
	private int playerId;
	
	private int sceneId;
	
	private PlayerEnterSceneCallback callback;

	public SysEnterScene(int playerId, int sceneId,PlayerEnterSceneCallback callback) {
		this.playerId = playerId;
		this.sceneId = sceneId;
		this.callback = callback;
	}

	public int getPlayerId() {
		return playerId;
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
		return "SysEnterSceneMsg";
	}

	@Override
	public void execute() {
		boolean result = SceneHandlerFactory.getHandler().handleEnterScene(playerId, sceneId);
		SysEnterSceneResult resultMsg = new SysEnterSceneResult(result, playerId,callback);
		Globals.getMessageProcessor().put(resultMsg);
	}

}
