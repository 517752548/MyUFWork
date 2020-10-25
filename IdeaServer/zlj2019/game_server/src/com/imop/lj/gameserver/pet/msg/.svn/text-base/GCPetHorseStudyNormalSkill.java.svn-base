package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 骑宠学习普通技能
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorseStudyNormalSkill extends GCMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 技能书道具Id */
	private int itemTplId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetHorseStudyNormalSkill (){
	}
	
	public GCPetHorseStudyNormalSkill (
			long petId,
			int itemTplId,
			int result ){
			this.petId = petId;
			this.itemTplId = itemTplId;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 技能书道具Id
	int _itemTplId = readInteger();
	//end


	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end



		this.petId = _petId;
		this.itemTplId = _itemTplId;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 技能书道具Id
	writeInteger(itemTplId);


	// 操作结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_HORSE_STUDY_NORMAL_SKILL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_HORSE_STUDY_NORMAL_SKILL";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getItemTplId(){
		return itemTplId;
	}
		
	public void setItemTplId(int itemTplId){
		this.itemTplId = itemTplId;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}