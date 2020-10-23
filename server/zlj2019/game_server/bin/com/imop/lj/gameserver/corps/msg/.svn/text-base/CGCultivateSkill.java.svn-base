package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求修炼技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCultivateSkill extends CGMessage{
	
	/** 技能Id */
	private int skillId;
	/** 修炼方式是否批量,0-否,1-是 */
	private int isBatch;
	
	public CGCultivateSkill (){
	}
	
	public CGCultivateSkill (
			int skillId,
			int isBatch ){
			this.skillId = skillId;
			this.isBatch = isBatch;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能Id
	int _skillId = readInteger();
	//end


	// 修炼方式是否批量,0-否,1-是
	int _isBatch = readInteger();
	//end



			this.skillId = _skillId;
			this.isBatch = _isBatch;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能Id
	writeInteger(skillId);


	// 修炼方式是否批量,0-否,1-是
	writeInteger(isBatch);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CULTIVATE_SKILL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CULTIVATE_SKILL";
	}

	public int getSkillId(){
		return skillId;
	}
		
	public void setSkillId(int skillId){
		this.skillId = skillId;
	}

	public int getIsBatch(){
		return isBatch;
	}
		
	public void setIsBatch(int isBatch){
		this.isBatch = isBatch;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleCultivateSkill(this.getSession().getPlayer(), this);
	}
}