package com.imop.lj.gameserver.humanskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.humanskill.handler.HumanskillHandlerFactory;

/**
 * 人物技能升级
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGHsSubSkillUpgrade extends CGMessage{
	
	/** 技能书道具Id */
	private int itemId;
	
	public CGHsSubSkillUpgrade (){
	}
	
	public CGHsSubSkillUpgrade (
			int itemId ){
			this.itemId = itemId;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能书道具Id
	int _itemId = readInteger();
	//end



			this.itemId = _itemId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能书道具Id
	writeInteger(itemId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_HS_SUB_SKILL_UPGRADE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_HS_SUB_SKILL_UPGRADE";
	}

	public int getItemId(){
		return itemId;
	}
		
	public void setItemId(int itemId){
		this.itemId = itemId;
	}


	@Override
	public void execute() {
		HumanskillHandlerFactory.getHandler().handleHsSubSkillUpgrade(this.getSession().getPlayer(), this);
	}
}