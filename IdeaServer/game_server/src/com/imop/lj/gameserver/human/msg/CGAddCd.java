package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 增加 Cd 队列
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddCd extends CGMessage{
	
	/** Cd 类型 */
	private short cdType;
	/** Cd 索引 */
	private short cdIndex;
	
	public CGAddCd (){
	}
	
	public CGAddCd (
			short cdType,
			short cdIndex ){
			this.cdType = cdType;
			this.cdIndex = cdIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// Cd 类型
	short _cdType = readShort();
	//end


	// Cd 索引
	short _cdIndex = readShort();
	//end



			this.cdType = _cdType;
			this.cdIndex = _cdIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// Cd 类型
	writeShort(cdType);


	// Cd 索引
	writeShort(cdIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ADD_CD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ADD_CD";
	}

	public short getCdType(){
		return cdType;
	}
		
	public void setCdType(short cdType){
		this.cdType = cdType;
	}

	public short getCdIndex(){
		return cdIndex;
	}
		
	public void setCdIndex(short cdIndex){
		this.cdIndex = cdIndex;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleAddCd(this.getSession().getPlayer(), this);
	}
}