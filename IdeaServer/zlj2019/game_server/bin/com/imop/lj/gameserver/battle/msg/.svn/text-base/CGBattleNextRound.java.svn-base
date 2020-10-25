package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.battle.handler.BattleHandlerFactory;

/**
 * 请求下一轮战斗
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGBattleNextRound extends CGMessage{
	
	/** 是否自动战斗，0否，1是 */
	private int isAuto;
	/** 玩家选择的技能Id */
	private int selSkillId;
	/** 玩家选择的技能目标 */
	private int selTarget;
	/** 玩家选择的道具Id */
	private int selItemId;
	/** 宠物选择的技能Id */
	private int petSelSkillId;
	/** 宠物选择的技能目标 */
	private int petSelTarget;
	/** 宠物选择的道具Id */
	private int petSelItemId;
	/** 召唤宠物Id */
	private long summonPetId;
	
	public CGBattleNextRound (){
	}
	
	public CGBattleNextRound (
			int isAuto,
			int selSkillId,
			int selTarget,
			int selItemId,
			int petSelSkillId,
			int petSelTarget,
			int petSelItemId,
			long summonPetId ){
			this.isAuto = isAuto;
			this.selSkillId = selSkillId;
			this.selTarget = selTarget;
			this.selItemId = selItemId;
			this.petSelSkillId = petSelSkillId;
			this.petSelTarget = petSelTarget;
			this.petSelItemId = petSelItemId;
			this.summonPetId = summonPetId;
	}
	
	@Override
	protected boolean readImpl() {

	// 是否自动战斗，0否，1是
	int _isAuto = readInteger();
	//end


	// 玩家选择的技能Id
	int _selSkillId = readInteger();
	//end


	// 玩家选择的技能目标
	int _selTarget = readInteger();
	//end


	// 玩家选择的道具Id
	int _selItemId = readInteger();
	//end


	// 宠物选择的技能Id
	int _petSelSkillId = readInteger();
	//end


	// 宠物选择的技能目标
	int _petSelTarget = readInteger();
	//end


	// 宠物选择的道具Id
	int _petSelItemId = readInteger();
	//end


	// 召唤宠物Id
	long _summonPetId = readLong();
	//end



			this.isAuto = _isAuto;
			this.selSkillId = _selSkillId;
			this.selTarget = _selTarget;
			this.selItemId = _selItemId;
			this.petSelSkillId = _petSelSkillId;
			this.petSelTarget = _petSelTarget;
			this.petSelItemId = _petSelItemId;
			this.summonPetId = _summonPetId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否自动战斗，0否，1是
	writeInteger(isAuto);


	// 玩家选择的技能Id
	writeInteger(selSkillId);


	// 玩家选择的技能目标
	writeInteger(selTarget);


	// 玩家选择的道具Id
	writeInteger(selItemId);


	// 宠物选择的技能Id
	writeInteger(petSelSkillId);


	// 宠物选择的技能目标
	writeInteger(petSelTarget);


	// 宠物选择的道具Id
	writeInteger(petSelItemId);


	// 召唤宠物Id
	writeLong(summonPetId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_BATTLE_NEXT_ROUND;
	}
	
	@Override
	public String getTypeName() {
		return "CG_BATTLE_NEXT_ROUND";
	}

	public int getIsAuto(){
		return isAuto;
	}
		
	public void setIsAuto(int isAuto){
		this.isAuto = isAuto;
	}

	public int getSelSkillId(){
		return selSkillId;
	}
		
	public void setSelSkillId(int selSkillId){
		this.selSkillId = selSkillId;
	}

	public int getSelTarget(){
		return selTarget;
	}
		
	public void setSelTarget(int selTarget){
		this.selTarget = selTarget;
	}

	public int getSelItemId(){
		return selItemId;
	}
		
	public void setSelItemId(int selItemId){
		this.selItemId = selItemId;
	}

	public int getPetSelSkillId(){
		return petSelSkillId;
	}
		
	public void setPetSelSkillId(int petSelSkillId){
		this.petSelSkillId = petSelSkillId;
	}

	public int getPetSelTarget(){
		return petSelTarget;
	}
		
	public void setPetSelTarget(int petSelTarget){
		this.petSelTarget = petSelTarget;
	}

	public int getPetSelItemId(){
		return petSelItemId;
	}
		
	public void setPetSelItemId(int petSelItemId){
		this.petSelItemId = petSelItemId;
	}

	public long getSummonPetId(){
		return summonPetId;
	}
		
	public void setSummonPetId(long summonPetId){
		this.summonPetId = summonPetId;
	}


	@Override
	public void execute() {
		BattleHandlerFactory.getHandler().handleBattleNextRound(this.getSession().getPlayer(), this);
	}
}