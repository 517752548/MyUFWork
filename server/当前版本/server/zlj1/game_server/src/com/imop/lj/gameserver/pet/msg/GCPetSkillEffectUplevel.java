package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 主将技能仙符升级结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetSkillEffectUplevel extends GCMessage{
	
	/** 技能Id */
	private int skillId;
	/** 要升级的位置，从1开始计数 */
	private int posId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCPetSkillEffectUplevel (){
	}
	
	public GCPetSkillEffectUplevel (
			int skillId,
			int posId,
			int result ){
			this.skillId = skillId;
			this.posId = posId;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 技能Id
	int _skillId = readInteger();
	//end


	// 要升级的位置，从1开始计数
	int _posId = readInteger();
	//end


	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end



		this.skillId = _skillId;
		this.posId = _posId;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能Id
	writeInteger(skillId);


	// 要升级的位置，从1开始计数
	writeInteger(posId);


	// 操作结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_SKILL_EFFECT_UPLEVEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_SKILL_EFFECT_UPLEVEL";
	}

	public int getSkillId(){
		return skillId;
	}
		
	public void setSkillId(int skillId){
		this.skillId = skillId;
	}

	public int getPosId(){
		return posId;
	}
		
	public void setPosId(int posId){
		this.posId = posId;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}