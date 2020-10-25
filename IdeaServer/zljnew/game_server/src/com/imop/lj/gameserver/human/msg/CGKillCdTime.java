package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 清除 Cd 等待时间
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGKillCdTime extends CGMessage{
	
	/** Cd 类型 */
	private int cdType;
	/** Cd 索引位置 */
	private int cdIndex;
	
	public CGKillCdTime (){
	}
	
	public CGKillCdTime (
			int cdType,
			int cdIndex ){
			this.cdType = cdType;
			this.cdIndex = cdIndex;
	}
	
	@Override
	protected boolean readImpl() {

	// Cd 类型
	int _cdType = readInteger();
	//end


	// Cd 索引位置
	int _cdIndex = readInteger();
	//end



			this.cdType = _cdType;
			this.cdIndex = _cdIndex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// Cd 类型
	writeInteger(cdType);


	// Cd 索引位置
	writeInteger(cdIndex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_KILL_CD_TIME;
	}
	
	@Override
	public String getTypeName() {
		return "CG_KILL_CD_TIME";
	}

	public int getCdType(){
		return cdType;
	}
		
	public void setCdType(int cdType){
		this.cdType = cdType;
	}

	public int getCdIndex(){
		return cdIndex;
	}
		
	public void setCdIndex(int cdIndex){
		this.cdIndex = cdIndex;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleKillCdTime(this.getSession().getPlayer(), this);
	}
}