package com.imop.lj.gameserver.lifeskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 生活技能列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLifeSkillInfo extends GCMessage{
	
	/** 生活技能列表 */
	private com.imop.lj.common.model.human.LifeSkillInfo[] lifeSkillInfos;

	public GCLifeSkillInfo (){
	}
	
	public GCLifeSkillInfo (
			com.imop.lj.common.model.human.LifeSkillInfo[] lifeSkillInfos ){
			this.lifeSkillInfos = lifeSkillInfos;
	}

	@Override
	protected boolean readImpl() {

	// 生活技能列表
	int lifeSkillInfosSize = readUnsignedShort();
	com.imop.lj.common.model.human.LifeSkillInfo[] _lifeSkillInfos = new com.imop.lj.common.model.human.LifeSkillInfo[lifeSkillInfosSize];
	int lifeSkillInfosIndex = 0;
	for(lifeSkillInfosIndex=0; lifeSkillInfosIndex<lifeSkillInfosSize; lifeSkillInfosIndex++){
		_lifeSkillInfos[lifeSkillInfosIndex] = new com.imop.lj.common.model.human.LifeSkillInfo();
	// 技能Id
	int _lifeSkillInfos_skillId = readInteger();
	//end
	_lifeSkillInfos[lifeSkillInfosIndex].setSkillId (_lifeSkillInfos_skillId);

	// 技能等级
	int _lifeSkillInfos_level = readInteger();
	//end
	_lifeSkillInfos[lifeSkillInfosIndex].setLevel (_lifeSkillInfos_level);

	// 层数
	int _lifeSkillInfos_layer = readInteger();
	//end
	_lifeSkillInfos[lifeSkillInfosIndex].setLayer (_lifeSkillInfos_layer);

	// 熟练度
	long _lifeSkillInfos_proficiency = readLong();
	//end
	_lifeSkillInfos[lifeSkillInfosIndex].setProficiency (_lifeSkillInfos_proficiency);
	}
	//end



		this.lifeSkillInfos = _lifeSkillInfos;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 生活技能列表
	writeShort(lifeSkillInfos.length);
	int lifeSkillInfosIndex = 0;
	int lifeSkillInfosSize = lifeSkillInfos.length;
	for(lifeSkillInfosIndex=0; lifeSkillInfosIndex<lifeSkillInfosSize; lifeSkillInfosIndex++){

	int lifeSkillInfos_skillId = lifeSkillInfos[lifeSkillInfosIndex].getSkillId();

	// 技能Id
	writeInteger(lifeSkillInfos_skillId);

	int lifeSkillInfos_level = lifeSkillInfos[lifeSkillInfosIndex].getLevel();

	// 技能等级
	writeInteger(lifeSkillInfos_level);

	int lifeSkillInfos_layer = lifeSkillInfos[lifeSkillInfosIndex].getLayer();

	// 层数
	writeInteger(lifeSkillInfos_layer);

	long lifeSkillInfos_proficiency = lifeSkillInfos[lifeSkillInfosIndex].getProficiency();

	// 熟练度
	writeLong(lifeSkillInfos_proficiency);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_LIFE_SKILL_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_LIFE_SKILL_INFO";
	}

	public com.imop.lj.common.model.human.LifeSkillInfo[] getLifeSkillInfos(){
		return lifeSkillInfos;
	}

	public void setLifeSkillInfos(com.imop.lj.common.model.human.LifeSkillInfo[] lifeSkillInfos){
		this.lifeSkillInfos = lifeSkillInfos;
	}	
}