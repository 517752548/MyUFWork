package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.battle.handler.BattleHandlerFactory;

/**
 * 更新自动战斗
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleUpdateAutoAction extends CGMessage{
	
	/** 武将类型，1主将，2宠物 */
	private int petTypeId;
	/** 技能Id */
	private int selSkillId;
	
	public CGBattleUpdateAutoAction (){
	}
	
	public CGBattleUpdateAutoAction (
			int petTypeId,
			int selSkillId ){
			this.petTypeId = petTypeId;
			this.selSkillId = selSkillId;
	}
	
	@Override
	protected boolean readImpl() {

	// 武将类型，1主将，2宠物
	int _petTypeId = readInteger();
	//end


	// 技能Id
	int _selSkillId = readInteger();
	//end



			this.petTypeId = _petTypeId;
			this.selSkillId = _selSkillId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将类型，1主将，2宠物
	writeInteger(petTypeId);


	// 技能Id
	writeInteger(selSkillId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_BATTLE_UPDATE_AUTO_ACTION;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BATTLE_UPDATE_AUTO_ACTION";
	}

	public int getPetTypeId(){
		return petTypeId;
	}
		
	public void setPetTypeId(int petTypeId){
		this.petTypeId = petTypeId;
	}

	public int getSelSkillId(){
		return selSkillId;
	}
		
	public void setSelSkillId(int selSkillId){
		this.selSkillId = selSkillId;
	}


	@Override
	public void execute() {
		BattleHandlerFactory.getHandler().handleBattleUpdateAutoAction(this.getSession().getPlayer(), this);
	}
}