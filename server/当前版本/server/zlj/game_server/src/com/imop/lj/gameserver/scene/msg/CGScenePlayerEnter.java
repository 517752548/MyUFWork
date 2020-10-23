package com.imop.lj.gameserver.scene.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.scene.handler.SceneHandlerFactory;

/**
 * 玩家进入场景
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGScenePlayerEnter extends CGMessage{
	
	/** 场景id */
	private int sceneId;
	
	public CGScenePlayerEnter (){
	}
	
	public CGScenePlayerEnter (
			int sceneId ){
			this.sceneId = sceneId;
	}
	
	@Override
	protected boolean readImpl() {

	// 场景id
	int _sceneId = readInteger();
	//end



			this.sceneId = _sceneId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 场景id
	writeInteger(sceneId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SCENE_PLAYER_ENTER;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SCENE_PLAYER_ENTER";
	}

	public int getSceneId(){
		return sceneId;
	}
		
	public void setSceneId(int sceneId){
		this.sceneId = sceneId;
	}


	@Override
	public void execute() {
		SceneHandlerFactory.getHandler().handleScenePlayerEnter(this.getSession().getPlayer(), this);
	}
}