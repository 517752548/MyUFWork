package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求学习辅助技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLearnAssistSkill extends CGMessage{
	
	/** 技能Id */
	private int skillId;
	
	public CGLearnAssistSkill (){
	}
	
	public CGLearnAssistSkill (
			int skillId ){
			this.skillId = skillId;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能Id
	int _skillId = readInteger();
	//end



			this.skillId = _skillId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能Id
	writeInteger(skillId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_LEARN_ASSIST_SKILL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_LEARN_ASSIST_SKILL";
	}

	public int getSkillId(){
		return skillId;
	}
		
	public void setSkillId(int skillId){
		this.skillId = skillId;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleLearnAssistSkill(this.getSession().getPlayer(), this);
	}
}