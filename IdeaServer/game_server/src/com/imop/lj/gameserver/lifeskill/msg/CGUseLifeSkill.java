package com.imop.lj.gameserver.lifeskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.lifeskill.handler.LifeskillHandlerFactory;

/**
 * 使用生活技能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGUseLifeSkill extends CGMessage{
	
	/** 技能Id */
	private int skillId;
	/** 资源点Id */
	private int resourceId;
	
	public CGUseLifeSkill (){
	}
	
	public CGUseLifeSkill (
			int skillId,
			int resourceId ){
			this.skillId = skillId;
			this.resourceId = resourceId;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能Id
	int _skillId = readInteger();
	//end


	// 资源点Id
	int _resourceId = readInteger();
	//end



			this.skillId = _skillId;
			this.resourceId = _resourceId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能Id
	writeInteger(skillId);


	// 资源点Id
	writeInteger(resourceId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_USE_LIFE_SKILL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_USE_LIFE_SKILL";
	}

	public int getSkillId(){
		return skillId;
	}
		
	public void setSkillId(int skillId){
		this.skillId = skillId;
	}

	public int getResourceId(){
		return resourceId;
	}
		
	public void setResourceId(int resourceId){
		this.resourceId = resourceId;
	}


	@Override
	public void execute() {
		LifeskillHandlerFactory.getHandler().handleUseLifeSkill(this.getSession().getPlayer(), this);
	}
}