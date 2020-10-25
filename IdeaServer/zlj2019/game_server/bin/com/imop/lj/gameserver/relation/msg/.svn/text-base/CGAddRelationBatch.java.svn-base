package com.imop.lj.gameserver.relation.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.relation.handler.RelationHandlerFactory;

/**
 * 批量添加关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddRelationBatch extends CGMessage{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家Id列表 */
	private long[] targetCharIdArr;
	
	public CGAddRelationBatch (){
	}
	
	public CGAddRelationBatch (
			int relationType,
			long[] targetCharIdArr ){
			this.relationType = relationType;
			this.targetCharIdArr = targetCharIdArr;
	}
	
	@Override
	protected boolean readImpl() {

	// 1好友，2黑名单
	int _relationType = readInteger();
	//end


	// 目标玩家Id列表
	int targetCharIdArrSize = readUnsignedShort();
	long[] _targetCharIdArr = new long[targetCharIdArrSize];
	int targetCharIdArrIndex = 0;
	for(targetCharIdArrIndex=0; targetCharIdArrIndex<targetCharIdArrSize; targetCharIdArrIndex++){
		_targetCharIdArr[targetCharIdArrIndex] = readLong();
	}//end



			this.relationType = _relationType;
			this.targetCharIdArr = _targetCharIdArr;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1好友，2黑名单
	writeInteger(relationType);


	// 目标玩家Id列表
	writeShort(targetCharIdArr.length);
	int targetCharIdArrSize = targetCharIdArr.length;
	int targetCharIdArrIndex = 0;
	for(targetCharIdArrIndex=0; targetCharIdArrIndex<targetCharIdArrSize; targetCharIdArrIndex++){
		writeLong(targetCharIdArr [ targetCharIdArrIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ADD_RELATION_BATCH;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ADD_RELATION_BATCH";
	}

	public int getRelationType(){
		return relationType;
	}
		
	public void setRelationType(int relationType){
		this.relationType = relationType;
	}

	public long[] getTargetCharIdArr(){
		return targetCharIdArr;
	}

	public void setTargetCharIdArr(long[] targetCharIdArr){
		this.targetCharIdArr = targetCharIdArr;
	}	


	@Override
	public void execute() {
		RelationHandlerFactory.getHandler().handleAddRelationBatch(this.getSession().getPlayer(), this);
	}
}