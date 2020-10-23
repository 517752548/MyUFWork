package com.imop.lj.gameserver.relation.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.relation.handler.RelationHandlerFactory;

/**
 * 添加关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddRelationByName extends CGMessage{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家名称 */
	private String targetName;
	
	public CGAddRelationByName (){
	}
	
	public CGAddRelationByName (
			int relationType,
			String targetName ){
			this.relationType = relationType;
			this.targetName = targetName;
	}
	
	@Override
	protected boolean readImpl() {

	// 1好友，2黑名单
	int _relationType = readInteger();
	//end


	// 目标玩家名称
	String _targetName = readString();
	//end



			this.relationType = _relationType;
			this.targetName = _targetName;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1好友，2黑名单
	writeInteger(relationType);


	// 目标玩家名称
	writeString(targetName);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ADD_RELATION_BY_NAME;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ADD_RELATION_BY_NAME";
	}

	public int getRelationType(){
		return relationType;
	}
		
	public void setRelationType(int relationType){
		this.relationType = relationType;
	}

	public String getTargetName(){
		return targetName;
	}
		
	public void setTargetName(String targetName){
		this.targetName = targetName;
	}


	@Override
	public void execute() {
		RelationHandlerFactory.getHandler().handleAddRelationByName(this.getSession().getPlayer(), this);
	}
}