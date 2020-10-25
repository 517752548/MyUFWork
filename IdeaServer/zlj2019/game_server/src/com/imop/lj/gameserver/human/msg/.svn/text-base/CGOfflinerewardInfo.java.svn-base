package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 离线奖励信息，一个奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOfflinerewardInfo extends CGMessage{
	
	/** 奖励功能按钮类型Id */
	private int funcTypeId;
	
	public CGOfflinerewardInfo (){
	}
	
	public CGOfflinerewardInfo (
			int funcTypeId ){
			this.funcTypeId = funcTypeId;
	}
	
	@Override
	protected boolean readImpl() {

	// 奖励功能按钮类型Id
	int _funcTypeId = readInteger();
	//end



			this.funcTypeId = _funcTypeId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 奖励功能按钮类型Id
	writeInteger(funcTypeId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_OFFLINEREWARD_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_OFFLINEREWARD_INFO";
	}

	public int getFuncTypeId(){
		return funcTypeId;
	}
		
	public void setFuncTypeId(int funcTypeId){
		this.funcTypeId = funcTypeId;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleOfflinerewardInfo(this.getSession().getPlayer(), this);
	}
}