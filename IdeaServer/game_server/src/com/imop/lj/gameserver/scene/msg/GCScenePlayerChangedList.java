package com.imop.lj.gameserver.scene.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 场景变化的玩家信息列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCScenePlayerChangedList extends GCMessage{
	
	/** 场景id */
	private int sceneId;
	/** 场景玩家信息 */
	private com.imop.lj.common.model.ScenePlayerInfoData[] scenePlayerInfoDataList;

	public GCScenePlayerChangedList (){
	}
	
	public GCScenePlayerChangedList (
			int sceneId,
			com.imop.lj.common.model.ScenePlayerInfoData[] scenePlayerInfoDataList ){
			this.sceneId = sceneId;
			this.scenePlayerInfoDataList = scenePlayerInfoDataList;
	}

	@Override
	protected boolean readImpl() {

	// 场景id
	int _sceneId = readInteger();
	//end


	// 场景玩家信息
	int scenePlayerInfoDataListSize = readUnsignedShort();
	com.imop.lj.common.model.ScenePlayerInfoData[] _scenePlayerInfoDataList = new com.imop.lj.common.model.ScenePlayerInfoData[scenePlayerInfoDataListSize];
	int scenePlayerInfoDataListIndex = 0;
	for(scenePlayerInfoDataListIndex=0; scenePlayerInfoDataListIndex<scenePlayerInfoDataListSize; scenePlayerInfoDataListIndex++){
		_scenePlayerInfoDataList[scenePlayerInfoDataListIndex] = new com.imop.lj.common.model.ScenePlayerInfoData();
	// 角色id
	long _scenePlayerInfoDataList_uuid = readLong();
	//end
	_scenePlayerInfoDataList[scenePlayerInfoDataListIndex].setUuid (_scenePlayerInfoDataList_uuid);

	// 玩家信息json串
	String _scenePlayerInfoDataList_playerDataJson = readString();
	//end
	_scenePlayerInfoDataList[scenePlayerInfoDataListIndex].setPlayerDataJson (_scenePlayerInfoDataList_playerDataJson);
	}
	//end



		this.sceneId = _sceneId;
		this.scenePlayerInfoDataList = _scenePlayerInfoDataList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 场景id
	writeInteger(sceneId);


	// 场景玩家信息
	writeShort(scenePlayerInfoDataList.length);
	int scenePlayerInfoDataListIndex = 0;
	int scenePlayerInfoDataListSize = scenePlayerInfoDataList.length;
	for(scenePlayerInfoDataListIndex=0; scenePlayerInfoDataListIndex<scenePlayerInfoDataListSize; scenePlayerInfoDataListIndex++){

	long scenePlayerInfoDataList_uuid = scenePlayerInfoDataList[scenePlayerInfoDataListIndex].getUuid();

	// 角色id
	writeLong(scenePlayerInfoDataList_uuid);

	String scenePlayerInfoDataList_playerDataJson = scenePlayerInfoDataList[scenePlayerInfoDataListIndex].getPlayerDataJson();

	// 玩家信息json串
	writeString(scenePlayerInfoDataList_playerDataJson);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SCENE_PLAYER_CHANGED_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SCENE_PLAYER_CHANGED_LIST";
	}

	public int getSceneId(){
		return sceneId;
	}
		
	public void setSceneId(int sceneId){
		this.sceneId = sceneId;
	}

	public com.imop.lj.common.model.ScenePlayerInfoData[] getScenePlayerInfoDataList(){
		return scenePlayerInfoDataList;
	}

	public void setScenePlayerInfoDataList(com.imop.lj.common.model.ScenePlayerInfoData[] scenePlayerInfoDataList){
		this.scenePlayerInfoDataList = scenePlayerInfoDataList;
	}	
	public boolean isCompress() {
		return true;
	}
}