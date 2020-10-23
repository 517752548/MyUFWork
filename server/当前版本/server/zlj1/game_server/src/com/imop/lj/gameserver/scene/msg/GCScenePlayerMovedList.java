package com.imop.lj.gameserver.scene.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 场景移动的玩家
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCScenePlayerMovedList extends GCMessage{
	
	/** 场景id */
	private int sceneId;
	/** 场景玩家信息 */
	private com.imop.lj.common.model.ScenePlayerMoveInfo[] scenePlayerMoveList;

	public GCScenePlayerMovedList (){
	}
	
	public GCScenePlayerMovedList (
			int sceneId,
			com.imop.lj.common.model.ScenePlayerMoveInfo[] scenePlayerMoveList ){
			this.sceneId = sceneId;
			this.scenePlayerMoveList = scenePlayerMoveList;
	}

	@Override
	protected boolean readImpl() {

	// 场景id
	int _sceneId = readInteger();
	//end


	// 场景玩家信息
	int scenePlayerMoveListSize = readUnsignedShort();
	com.imop.lj.common.model.ScenePlayerMoveInfo[] _scenePlayerMoveList = new com.imop.lj.common.model.ScenePlayerMoveInfo[scenePlayerMoveListSize];
	int scenePlayerMoveListIndex = 0;
	for(scenePlayerMoveListIndex=0; scenePlayerMoveListIndex<scenePlayerMoveListSize; scenePlayerMoveListIndex++){
		_scenePlayerMoveList[scenePlayerMoveListIndex] = new com.imop.lj.common.model.ScenePlayerMoveInfo();
	// 角色id
	long _scenePlayerMoveList_uuid = readLong();
	//end
	_scenePlayerMoveList[scenePlayerMoveListIndex].setUuid (_scenePlayerMoveList_uuid);

	// x坐标
	int _scenePlayerMoveList_x = readInteger();
	//end
	_scenePlayerMoveList[scenePlayerMoveListIndex].setX (_scenePlayerMoveList_x);

	// y坐标
	int _scenePlayerMoveList_y = readInteger();
	//end
	_scenePlayerMoveList[scenePlayerMoveListIndex].setY (_scenePlayerMoveList_y);

	// 是否瞬移，0否，1是
	int _scenePlayerMoveList_instantFlag = readInteger();
	//end
	_scenePlayerMoveList[scenePlayerMoveListIndex].setInstantFlag (_scenePlayerMoveList_instantFlag);
	}
	//end



		this.sceneId = _sceneId;
		this.scenePlayerMoveList = _scenePlayerMoveList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 场景id
	writeInteger(sceneId);


	// 场景玩家信息
	writeShort(scenePlayerMoveList.length);
	int scenePlayerMoveListIndex = 0;
	int scenePlayerMoveListSize = scenePlayerMoveList.length;
	for(scenePlayerMoveListIndex=0; scenePlayerMoveListIndex<scenePlayerMoveListSize; scenePlayerMoveListIndex++){

	long scenePlayerMoveList_uuid = scenePlayerMoveList[scenePlayerMoveListIndex].getUuid();

	// 角色id
	writeLong(scenePlayerMoveList_uuid);

	int scenePlayerMoveList_x = scenePlayerMoveList[scenePlayerMoveListIndex].getX();

	// x坐标
	writeInteger(scenePlayerMoveList_x);

	int scenePlayerMoveList_y = scenePlayerMoveList[scenePlayerMoveListIndex].getY();

	// y坐标
	writeInteger(scenePlayerMoveList_y);

	int scenePlayerMoveList_instantFlag = scenePlayerMoveList[scenePlayerMoveListIndex].getInstantFlag();

	// 是否瞬移，0否，1是
	writeInteger(scenePlayerMoveList_instantFlag);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SCENE_PLAYER_MOVED_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SCENE_PLAYER_MOVED_LIST";
	}

	public int getSceneId(){
		return sceneId;
	}
		
	public void setSceneId(int sceneId){
		this.sceneId = sceneId;
	}

	public com.imop.lj.common.model.ScenePlayerMoveInfo[] getScenePlayerMoveList(){
		return scenePlayerMoveList;
	}

	public void setScenePlayerMoveList(com.imop.lj.common.model.ScenePlayerMoveInfo[] scenePlayerMoveList){
		this.scenePlayerMoveList = scenePlayerMoveList;
	}	
	public boolean isCompress() {
		return true;
	}
}