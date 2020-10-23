package com.imop.lj.gameserver.wizardraid.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.wizardraid.handler.WizardraidHandlerFactory;

/**
 * 请求进入单人副本
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWizardraidEnterSingle extends CGMessage{
	
	/** 副本id */
	private int raidId;
	
	public CGWizardraidEnterSingle (){
	}
	
	public CGWizardraidEnterSingle (
			int raidId ){
			this.raidId = raidId;
	}
	
	@Override
	protected boolean readImpl() {

	// 副本id
	int _raidId = readInteger();
	//end



			this.raidId = _raidId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 副本id
	writeInteger(raidId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_WIZARDRAID_ENTER_SINGLE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_WIZARDRAID_ENTER_SINGLE";
	}

	public int getRaidId(){
		return raidId;
	}
		
	public void setRaidId(int raidId){
		this.raidId = raidId;
	}


	@Override
	public void execute() {
		WizardraidHandlerFactory.getHandler().handleWizardraidEnterSingle(this.getSession().getPlayer(), this);
	}
}