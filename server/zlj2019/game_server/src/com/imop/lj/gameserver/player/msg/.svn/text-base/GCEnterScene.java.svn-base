package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 玩家已经进入场景
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEnterScene extends GCMessage{
	
	/** 场景Id */
	private int sceneId;
	/** 场景名称 */
	private String sceneName;

	public GCEnterScene (){
	}
	
	public GCEnterScene (
			int sceneId,
			String sceneName ){
			this.sceneId = sceneId;
			this.sceneName = sceneName;
	}

	@Override
	protected boolean readImpl() {

	// 场景Id
	int _sceneId = readInteger();
	//end


	// 场景名称
	String _sceneName = readString();
	//end



		this.sceneId = _sceneId;
		this.sceneName = _sceneName;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 场景Id
	writeInteger(sceneId);


	// 场景名称
	writeString(sceneName);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ENTER_SCENE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ENTER_SCENE";
	}

	public int getSceneId(){
		return sceneId;
	}
		
	public void setSceneId(int sceneId){
		this.sceneId = sceneId;
	}

	public String getSceneName(){
		return sceneName;
	}
		
	public void setSceneName(String sceneName){
		this.sceneName = sceneName;
	}
}