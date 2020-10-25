package com.imop.lj.gameserver.relation.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.relation.handler.RelationHandlerFactory;

/**
 * 删除关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGDelRelation extends CGMessage{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家名称 */
	private String targetName;
	
	public CGDelRelation (){
	}
	
	public CGDelRelation (
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
		return MessageType.CG_DEL_RELATION;
	}
	
	@Override
	public String getTypeName() {
		return "CG_DEL_RELATION";
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
		RelationHandlerFactory.getHandler().handleDelRelation(this.getSession().getPlayer(), this);
	}
}