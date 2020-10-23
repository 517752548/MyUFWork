package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求制作物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMakeItem extends CGMessage{
	
	/** 技能Id */
	private int skillId;
	/** 生成对应等级的物品,默认为0代表该生成物品为随机方式 */
	private int targetLevel;
	
	public CGMakeItem (){
	}
	
	public CGMakeItem (
			int skillId,
			int targetLevel ){
			this.skillId = skillId;
			this.targetLevel = targetLevel;
	}
	
	@Override
	protected boolean readImpl() {

	// 技能Id
	int _skillId = readInteger();
	//end


	// 生成对应等级的物品,默认为0代表该生成物品为随机方式
	int _targetLevel = readInteger();
	//end



			this.skillId = _skillId;
			this.targetLevel = _targetLevel;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 技能Id
	writeInteger(skillId);


	// 生成对应等级的物品,默认为0代表该生成物品为随机方式
	writeInteger(targetLevel);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_MAKE_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_MAKE_ITEM";
	}

	public int getSkillId(){
		return skillId;
	}
		
	public void setSkillId(int skillId){
		this.skillId = skillId;
	}

	public int getTargetLevel(){
		return targetLevel;
	}
		
	public void setTargetLevel(int targetLevel){
		this.targetLevel = targetLevel;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleMakeItem(this.getSession().getPlayer(), this);
	}
}