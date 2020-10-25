package com.imop.lj.gameserver.humanskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.humanskill.handler.HumanskillHandlerFactory;

/**
 * 人物技能增加熟练度
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGHsSubSkillAddProficiency extends CGMessage{
	
	/** 技能ID */
	private int skillId;
	
	public CGHsSubSkillAddProficiency (){
	}
	
	public CGHsSubSkillAddProficiency (
			int skillId ){
			this.skillId = skillId;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能ID
	int _skillId = readInteger();
	//end



			this.skillId = _skillId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能ID
	writeInteger(skillId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_HS_SUB_SKILL_ADD_PROFICIENCY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_HS_SUB_SKILL_ADD_PROFICIENCY";
	}

	public int getSkillId(){
		return skillId;
	}
		
	public void setSkillId(int skillId){
		this.skillId = skillId;
	}


	@Override
	public void execute() {
		HumanskillHandlerFactory.getHandler().handleHsSubSkillAddProficiency(this.getSession().getPlayer(), this);
	}
}