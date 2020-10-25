package com.imop.lj.gameserver.humanskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 心法信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCHsMainSkillInfo extends GCMessage{
	
	/** 心法信息列表 */
	private com.imop.lj.common.model.humanskill.MainSkillInfo[] mainSkillInfos;

	public GCHsMainSkillInfo (){
	}
	
	public GCHsMainSkillInfo (
			com.imop.lj.common.model.humanskill.MainSkillInfo[] mainSkillInfos ){
			this.mainSkillInfos = mainSkillInfos;
	}

	@Override
	protected boolean readImpl() {

	// 心法信息列表
	int mainSkillInfosSize = readUnsignedShort();
	com.imop.lj.common.model.humanskill.MainSkillInfo[] _mainSkillInfos = new com.imop.lj.common.model.humanskill.MainSkillInfo[mainSkillInfosSize];
	int mainSkillInfosIndex = 0;
	for(mainSkillInfosIndex=0; mainSkillInfosIndex<mainSkillInfosSize; mainSkillInfosIndex++){
		_mainSkillInfos[mainSkillInfosIndex] = new com.imop.lj.common.model.humanskill.MainSkillInfo();
	// 心法Id
	int _mainSkillInfos_mindId = readInteger();
	//end
	_mainSkillInfos[mainSkillInfosIndex].setMindId (_mainSkillInfos_mindId);

	// 心法等级
	int _mainSkillInfos_mindLevel = readInteger();
	//end
	_mainSkillInfos[mainSkillInfosIndex].setMindLevel (_mainSkillInfos_mindLevel);
	}
	//end



		this.mainSkillInfos = _mainSkillInfos;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 心法信息列表
	writeShort(mainSkillInfos.length);
	int mainSkillInfosIndex = 0;
	int mainSkillInfosSize = mainSkillInfos.length;
	for(mainSkillInfosIndex=0; mainSkillInfosIndex<mainSkillInfosSize; mainSkillInfosIndex++){

	int mainSkillInfos_mindId = mainSkillInfos[mainSkillInfosIndex].getMindId();

	// 心法Id
	writeInteger(mainSkillInfos_mindId);

	int mainSkillInfos_mindLevel = mainSkillInfos[mainSkillInfosIndex].getMindLevel();

	// 心法等级
	writeInteger(mainSkillInfos_mindLevel);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_HS_MAIN_SKILL_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_HS_MAIN_SKILL_INFO";
	}

	public com.imop.lj.common.model.humanskill.MainSkillInfo[] getMainSkillInfos(){
		return mainSkillInfos;
	}

	public void setMainSkillInfos(com.imop.lj.common.model.humanskill.MainSkillInfo[] mainSkillInfos){
		this.mainSkillInfos = mainSkillInfos;
	}	
}