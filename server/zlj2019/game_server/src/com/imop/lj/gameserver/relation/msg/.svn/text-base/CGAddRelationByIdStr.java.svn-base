package com.imop.lj.gameserver.relation.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.relation.handler.RelationHandlerFactory;

/**
 * 添加关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddRelationByIdStr extends CGMessage{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家Id */
	private String targetCharIdStr;
	
	public CGAddRelationByIdStr (){
	}
	
	public CGAddRelationByIdStr (
			int relationType,
			String targetCharIdStr ){
			this.relationType = relationType;
			this.targetCharIdStr = targetCharIdStr;
	}
	
	@Override
	protected boolean readImpl() {

	// 1好友，2黑名单
	int _relationType = readInteger();
	//end


	// 目标玩家Id
	String _targetCharIdStr = readString();
	//end



			this.relationType = _relationType;
			this.targetCharIdStr = _targetCharIdStr;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1好友，2黑名单
	writeInteger(relationType);


	// 目标玩家Id
	writeString(targetCharIdStr);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ADD_RELATION_BY_ID_STR;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ADD_RELATION_BY_ID_STR";
	}

	public int getRelationType(){
		return relationType;
	}
		
	public void setRelationType(int relationType){
		this.relationType = relationType;
	}

	public String getTargetCharIdStr(){
		return targetCharIdStr;
	}
		
	public void setTargetCharIdStr(String targetCharIdStr){
		this.targetCharIdStr = targetCharIdStr;
	}


	@Override
	public void execute() {
		RelationHandlerFactory.getHandler().handleAddRelationByIdStr(this.getSession().getPlayer(), this);
	}
}