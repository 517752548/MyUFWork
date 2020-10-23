package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 充值测试消息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGChargeGmTest extends CGMessage{
	
	/** 充值模板Id */
	private int tplId;
	
	public CGChargeGmTest (){
	}
	
	public CGChargeGmTest (
			int tplId ){
			this.tplId = tplId;
	}
	
	@Override
	protected boolean readImpl() {

	// 充值模板Id
	int _tplId = readInteger();
	//end



			this.tplId = _tplId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 充值模板Id
	writeInteger(tplId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CHARGE_GM_TEST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CHARGE_GM_TEST";
	}

	public int getTplId(){
		return tplId;
	}
		
	public void setTplId(int tplId){
		this.tplId = tplId;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleChargeGmTest(this.getSession().getPlayer(), this);
	}
}