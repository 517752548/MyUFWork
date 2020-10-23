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
	/** 修炼页签红点，0没有，1有 */
	private int cultivateFlag;
	/** 辅助页签红点，0没有，1有 */
	private int assistFlag;

	public GCHsOpenPanel (){
	}
	
	public GCHsOpenPanel (
			int mindFlag,
			int skillFlag,
			int cultivateFlag,
			int assistFlag ){
			this.mindFlag = mindFlag;
			this.skillFlag = skillFlag;
			this.cultivateFlag = cultivateFlag;
			this.assistFlag = assistFlag;
	}

	@Override
	protected boolean readImpl() {

	// 心法页签红点，0没有，1有
	int _mindFlag = readInteger();
	//end


	// 技能页签红点，0没有，1有
	int _skillFlag = readInteger();
	//end


	// 修炼页签红点，0没有，1有
	int _cultivateFlag = readInteger();
	//end


	// 辅助页签红点，0没有，1有
	int _assistFlag = readInteger();
	//end



		this.mindFlag = _mindFlag;
		this.skillFlag = _skillFlag;
		this.cultivateFlag = _cultivateFlag;
		this.assistFlag = _assistFlag;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 心法页签红点，0没有，1有
	writeInteger(mindFlag);


	// 技能页签红点，0没有，1有
	writeInteger(skillFlag);


	// 修炼页签红点，0没有，1有
	writeInteger(cultivateFlag);


	// 辅助页签红点，0没有，1有
	writeInteger(assistFlag);


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
}