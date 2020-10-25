package com.imop.lj.gameserver.lifeskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.lifeskill.handler.LifeskillHandlerFactory;

/**
 * 生活技能升级
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLifeSkillUpgrade extends CGMessage{
	
	/** 技能书道具Id */
	private int itemId;
	
	public CGLifeSkillUpgrade (){
	}
	
	public CGLifeSkillUpgrade (
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
		return MessageType.CG_LIFE_SKILL_UPGRADE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_LIFE_SKILL_UPGRADE";
	}

	public int getItemId(){
		return itemId;
	}
		
	public void setItemId(int itemId){
		this.itemId = itemId;
	}


	@Override
	public void execute() {
		LifeskillHandlerFactory.getHandler().handleLifeSkillUpgrade(this.getSession().getPlayer(), this);
	}
}