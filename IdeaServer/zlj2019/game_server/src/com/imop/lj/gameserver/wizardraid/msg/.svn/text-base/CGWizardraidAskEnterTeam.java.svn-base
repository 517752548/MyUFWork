package com.imop.lj.gameserver.wizardraid.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.wizardraid.handler.WizardraidHandlerFactory;

/**
 * 队长请求进入组队副本
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWizardraidAskEnterTeam extends CGMessage{
	
	/** 副本id */
	private int raidId;
	
	public CGWizardraidAskEnterTeam (){
	}
	
	public CGWizardraidAskEnterTeam (
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
		return MessageType.CG_WIZARDRAID_ASK_ENTER_TEAM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_WIZARDRAID_ASK_ENTER_TEAM";
	}

	public int getRaidId(){
		return raidId;
	}
		
	public void setRaidId(int raidId){
		this.raidId = raidId;
	}


	@Override
	public void execute() {
		WizardraidHandlerFactory.getHandler().handleWizardraidAskEnterTeam(this.getSession().getPlayer(), this);
	}
}