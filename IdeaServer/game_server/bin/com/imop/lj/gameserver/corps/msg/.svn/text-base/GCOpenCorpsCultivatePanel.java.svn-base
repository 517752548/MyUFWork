package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回帮派修炼技能面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsCultivatePanel extends GCMessage{
	
	/** 帮派修炼技能信息 */
	private com.imop.lj.common.model.corps.CorpsSkillInfo[] corpsSkillInfoList;

	public GCOpenCorpsCultivatePanel (){
	}
	
	public GCOpenCorpsCultivatePanel (
			com.imop.lj.common.model.corps.CorpsSkillInfo[] corpsSkillInfoList ){
			this.corpsSkillInfoList = corpsSkillInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 帮派修炼技能信息
	int corpsSkillInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsSkillInfo[] _corpsSkillInfoList = new com.imop.lj.common.model.corps.CorpsSkillInfo[corpsSkillInfoListSize];
	int corpsSkillInfoListIndex = 0;
	for(corpsSkillInfoListIndex=0; corpsSkillInfoListIndex<corpsSkillInfoListSize; corpsSkillInfoListIndex++){
		_corpsSkillInfoList[corpsSkillInfoListIndex] = new com.imop.lj.common.model.corps.CorpsSkillInfo();
	// 技能Id
	int _corpsSkillInfoList_skillId = readInteger();
	//end
	_corpsSkillInfoList[corpsSkillInfoListIndex].setSkillId (_corpsSkillInfoList_skillId);

	// 技能等级
	int _corpsSkillInfoList_level = readInteger();
	//end
	_corpsSkillInfoList[corpsSkillInfoListIndex].setLevel (_corpsSkillInfoList_level);

	// 如果技能升级需要经验,就设置该值
	long _corpsSkillInfoList_exp = readLong();
	//end
	_corpsSkillInfoList[corpsSkillInfoListIndex].setExp (_corpsSkillInfoList_exp);
	}
	//end



		this.corpsSkillInfoList = _corpsSkillInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 帮派修炼技能信息
	writeShort(corpsSkillInfoList.length);
	int corpsSkillInfoListIndex = 0;
	int corpsSkillInfoListSize = corpsSkillInfoList.length;
	for(corpsSkillInfoListIndex=0; corpsSkillInfoListIndex<corpsSkillInfoListSize; corpsSkillInfoListIndex++){

	int corpsSkillInfoList_skillId = corpsSkillInfoList[corpsSkillInfoListIndex].getSkillId();

	// 技能Id
	writeInteger(corpsSkillInfoList_skillId);

	int corpsSkillInfoList_level = corpsSkillInfoList[corpsSkillInfoListIndex].getLevel();

	// 技能等级
	writeInteger(corpsSkillInfoList_level);

	long corpsSkillInfoList_exp = corpsSkillInfoList[corpsSkillInfoListIndex].getExp();

	// 如果技能升级需要经验,就设置该值
	writeLong(corpsSkillInfoList_exp);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OPEN_CORPS_CULTIVATE_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_CORPS_CULTIVATE_PANEL";
	}

	public com.imop.lj.common.model.corps.CorpsSkillInfo[] getCorpsSkillInfoList(){
		return corpsSkillInfoList;
	}

	public void setCorpsSkillInfoList(com.imop.lj.common.model.corps.CorpsSkillInfo[] corpsSkillInfoList){
		this.corpsSkillInfoList = corpsSkillInfoList;
	}	
}