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
	
	/** 技能ID */
	private int skillId;
	/** 是否为批量升级，1是，2否 */
	private int isBatch;
	
	public CGHsSubSkillUpgrade (){
	}
	
	public CGHsSubSkillUpgrade (
			int skillId,
			int isBatch ){
			this.skillId = skillId;
			this.isBatch = isBatch;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能ID
	int _skillId = readInteger();
	//end


	// 是否为批量升级，1是，2否
	int _isBatch = readInteger();
	//end



			this.skillId = _skillId;
			this.isBatch = _isBatch;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能ID
	writeInteger(skillId);


	// 是否为批量升级，1是，2否
	writeInteger(isBatch);


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
		HumanskillHandlerFactory.getHandler().handleHsSubSkillUpgrade(this.getSession().getPlayer(), this);
	}
}