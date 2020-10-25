package com.imop.lj.gameserver.relation.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.relation.handler.RelationHandlerFactory;

/**
 * 添加关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddRelationById extends CGMessage{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家Id */
	private long targetCharId;
	
	public CGAddRelationById (){
	}
	
	public CGAddRelationById (
			int relationType,
			long targetCharId ){
			this.relationType = relationType;
			this.targetCharId = targetCharId;
	}
	
	@Override
	protected boolean readImpl() {

	// 1好友，2黑名单
	int _relationType = readInteger();
	//end


	// 目标玩家Id
	long _targetCharId = readLong();
	//end



			this.relationType = _relationType;
			this.targetCharId = _targetCharId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1好友，2黑名单
	writeInteger(relationType);


	// 目标玩家Id
	writeLong(targetCharId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ADD_RELATION_BY_ID;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ADD_RELATION_BY_ID";
	}

	public int getRelationType(){
		return relationType;
	}
		
	public void setRelationType(int relationType){
		this.relationType = relationType;
	}

	public long getTargetCharId(){
		return targetCharId;
	}
		
	public void setTargetCharId(long targetCharId){
		this.targetCharId = targetCharId;
	}


	@Override
	public void execute() {
		RelationHandlerFactory.getHandler().handleAddRelationById(this.getSession().getPlayer(), this);
	}
}