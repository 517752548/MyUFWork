package com.imop.lj.gameserver.scene.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 玩家被强制踢回主城
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCScenePlayerForceToCityScene extends GCMessage{
	
	/** 从哪个场景被踢的 */
	private int fromSceneId;

	public GCScenePlayerForceToCityScene (){
	}
	
	public GCScenePlayerForceToCityScene (
			int fromSceneId ){
			this.fromSceneId = fromSceneId;
	}

	@Override
	protected boolean readImpl() {

	// 从哪个场景被踢的
	int _fromSceneId = readInteger();
	//end



		this.fromSceneId = _fromSceneId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 从哪个场景被踢的
	writeInteger(fromSceneId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SCENE_PLAYER_FORCE_TO_CITY_SCENE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SCENE_PLAYER_FORCE_TO_CITY_SCENE";
	}

	public int getFromSceneId(){
		return fromSceneId;
	}
		
	public void setFromSceneId(int fromSceneId){
		this.fromSceneId = fromSceneId;
	}
}