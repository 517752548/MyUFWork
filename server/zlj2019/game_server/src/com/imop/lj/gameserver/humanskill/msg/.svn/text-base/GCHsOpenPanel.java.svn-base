package com.imop.lj.gameserver.humanskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 打开心法技能面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCHsOpenPanel extends GCMessage{
	
	/** 心法页签红点，0没有，1有 */
	private int mindFlag;
	/** 技能页签红点，0没有，1有 */
	private int skillFlag;
	/** 心法技能提升列表 */
	private com.imop.lj.common.model.humanskill.MainSkillTipsInfo mainSkillTipsInfo;
	/** 修炼页签红点，0没有，1有 */
	private int cultivateFlag;
	/** 辅助页签红点，0没有，1有 */
	private int assistFlag;
	/** 生活技能页签红点，0没有，1有 */
	private int lifeSkillFlag;

	public GCHsOpenPanel (){
	}
	
	public GCHsOpenPanel (
			int mindFlag,
			int skillFlag,
			com.imop.lj.common.model.humanskill.MainSkillTipsInfo mainSkillTipsInfo,
			int cultivateFlag,
			int assistFlag,
			int lifeSkillFlag ){
			this.mindFlag = mindFlag;
			this.skillFlag = skillFlag;
			this.mainSkillTipsInfo = mainSkillTipsInfo;
			this.cultivateFlag = cultivateFlag;
			this.assistFlag = assistFlag;
			this.lifeSkillFlag = lifeSkillFlag;
	}

	@Override
	protected boolean readImpl() {

	// 心法页签红点，0没有，1有
	int _mindFlag = readInteger();
	//end


	// 技能页签红点，0没有，1有
	int _skillFlag = readInteger();
	//end

	// 心法技能提升列表
	com.imop.lj.common.model.humanskill.MainSkillTipsInfo _mainSkillTipsInfo = new com.imop.lj.common.model.humanskill.MainSkillTipsInfo();

	// 心法Id
	int _mainSkillTipsInfo_mindId = readInteger();
	//end
	_mainSkillTipsInfo.setMindId (_mainSkillTipsInfo_mindId);

	// 技能Id
	int _mainSkillTipsInfo_skillId = readInteger();
	//end
	_mainSkillTipsInfo.setSkillId (_mainSkillTipsInfo_skillId);


	// 修炼页签红点，0没有，1有
	int _cultivateFlag = readInteger();
	//end


	// 辅助页签红点，0没有，1有
	int _assistFlag = readInteger();
	//end


	// 生活技能页签红点，0没有，1有
	int _lifeSkillFlag = readInteger();
	//end



		this.mindFlag = _mindFlag;
		this.skillFlag = _skillFlag;
		this.mainSkillTipsInfo = _mainSkillTipsInfo;
		this.cultivateFlag = _cultivateFlag;
		this.assistFlag = _assistFlag;
		this.lifeSkillFlag = _lifeSkillFlag;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 心法页签红点，0没有，1有
	writeInteger(mindFlag);


	// 技能页签红点，0没有，1有
	writeInteger(skillFlag);


	int mainSkillTipsInfo_mindId = mainSkillTipsInfo.getMindId ();

	// 心法Id
	writeInteger(mainSkillTipsInfo_mindId);

	int mainSkillTipsInfo_skillId = mainSkillTipsInfo.getSkillId ();

	// 技能Id
	writeInteger(mainSkillTipsInfo_skillId);


	// 修炼页签红点，0没有，1有
	writeInteger(cultivateFlag);


	// 辅助页签红点，0没有，1有
	writeInteger(assistFlag);


	// 生活技能页签红点，0没有，1有
	writeInteger(lifeSkillFlag);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_HS_OPEN_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_HS_OPEN_PANEL";
	}

	public int getMindFlag(){
		return mindFlag;
	}
		
	public void setMindFlag(int mindFlag){
		this.mindFlag = mindFlag;
	}

	public int getSkillFlag(){
		return skillFlag;
	}
		
	public void setSkillFlag(int skillFlag){
		this.skillFlag = skillFlag;
	}

	public com.imop.lj.common.model.humanskill.MainSkillTipsInfo getMainSkillTipsInfo(){
		return mainSkillTipsInfo;
	}
		
	public void setMainSkillTipsInfo(com.imop.lj.common.model.humanskill.MainSkillTipsInfo mainSkillTipsInfo){
		this.mainSkillTipsInfo = mainSkillTipsInfo;
	}

	public int getCultivateFlag(){
		return cultivateFlag;
	}
		
	public void setCultivateFlag(int cultivateFlag){
		this.cultivateFlag = cultivateFlag;
	}

	public int getAssistFlag(){
		return assistFlag;
	}
		
	public void setAssistFlag(int assistFlag){
		this.assistFlag = assistFlag;
	}

	public int getLifeSkillFlag(){
		return lifeSkillFlag;
	}
		
	public void setLifeSkillFlag(int lifeSkillFlag){
		this.lifeSkillFlag = lifeSkillFlag;
	}
}