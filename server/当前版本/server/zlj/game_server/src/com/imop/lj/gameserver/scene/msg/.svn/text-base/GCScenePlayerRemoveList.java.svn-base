package com.imop.lj.gameserver.scene.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 场景移除的玩家
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCScenePlayerRemoveList extends GCMessage{
	
	/** 场景id */
	private int sceneId;
	/** 角色id */
	private long[] uuid;

	public GCScenePlayerRemoveList (){
	}
	
	public GCScenePlayerRemoveList (
			int sceneId,
			long[] uuid ){
			this.sceneId = sceneId;
			this.uuid = uuid;
	}

	@Override
	protected boolean readImpl() {

	// 场景id
	int _sceneId = readInteger();
	//end


	// 角色id
	int uuidSize = readUnsignedShort();
	long[] _uuid = new long[uuidSize];
	int uuidIndex = 0;
	for(uuidIndex=0; uuidIndex<uuidSize; uuidIndex++){
		_uuid[uuidIndex] = readLong();
	}//end



		this.sceneId = _sceneId;
		this.uuid = _uuid;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 场景id
	writeInteger(sceneId);


	// 角色id
	writeShort(uuid.length);
	int uuidSize = uuid.length;
	int uuidIndex = 0;
	for(uuidIndex=0; uuidIndex<uuidSize; uuidIndex++){
		writeLong(uuid [ uuidIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SCENE_PLAYER_REMOVE_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SCENE_PLAYER_REMOVE_LIST";
	}

	public int getSceneId(){
		return sceneId;
	}
		
	public void setSceneId(int sceneId){
		this.sceneId = sceneId;
	}

	public long[] getUuid(){
		return uuid;
	}

	public void setUuid(long[] uuid){
		this.uuid = uuid;
	}	
}