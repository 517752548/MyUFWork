package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回军团成员列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsMemberList extends GCMessage{
	
	/** 军团成员列表 */
	private com.imop.lj.common.model.corps.CorpsMemberInfo[] corpsMemInfoList;
	/** 军团面板功能列表 */
	private com.imop.lj.common.model.corps.CorpsFuncInfo[] corpsPanelFuncInfoList;

	public GCOpenCorpsMemberList (){
	}
	
	public GCOpenCorpsMemberList (
			com.imop.lj.common.model.corps.CorpsMemberInfo[] corpsMemInfoList,
			com.imop.lj.common.model.corps.CorpsFuncInfo[] corpsPanelFuncInfoList ){
			this.corpsMemInfoList = corpsMemInfoList;
			this.corpsPanelFuncInfoList = corpsPanelFuncInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 军团成员列表
	int corpsMemInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsMemberInfo[] _corpsMemInfoList = new com.imop.lj.common.model.corps.CorpsMemberInfo[corpsMemInfoListSize];
	int corpsMemInfoListIndex = 0;
	for(corpsMemInfoListIndex=0; corpsMemInfoListIndex<corpsMemInfoListSize; corpsMemInfoListIndex++){
		_corpsMemInfoList[corpsMemInfoListIndex] = new com.imop.lj.common.model.corps.CorpsMemberInfo();
	// 成员ID
	long _corpsMemInfoList_memId = readLong();
	//end
	_corpsMemInfoList[corpsMemInfoListIndex].setMemId (_corpsMemInfoList_memId);

	// 名称
	String _corpsMemInfoList_name = readString();
	//end
	_corpsMemInfoList[corpsMemInfoListIndex].setName (_corpsMemInfoList_name);

	// 模板Id
	int _corpsMemInfoList_tplId = readInteger();
	//end
	_corpsMemInfoList[corpsMemInfoListIndex].setTplId (_corpsMemInfoList_tplId);

	// 级别
	int _corpsMemInfoList_level = readInteger();
	//end
	_corpsMemInfoList[corpsMemInfoListIndex].setLevel (_corpsMemInfoList_level);

	// 职位
	int _corpsMemInfoList_memJob = readInteger();
	//end
	_corpsMemInfoList[corpsMemInfoListIndex].setMemJob (_corpsMemInfoList_memJob);

	// 职业
	int _corpsMemInfoList_petJob = readInteger();
	//end
	_corpsMemInfoList[corpsMemInfoListIndex].setPetJob (_corpsMemInfoList_petJob);

	// 本周贡献
	long _corpsMemInfoList_weekContribution = readLong();
	//end
	_corpsMemInfoList[corpsMemInfoListIndex].setWeekContribution (_corpsMemInfoList_weekContribution);

	// 总贡献
	long _corpsMemInfoList_totalContribution = readLong();
	//end
	_corpsMemInfoList[corpsMemInfoListIndex].setTotalContribution (_corpsMemInfoList_totalContribution);

	// 在线描述
	String _corpsMemInfoList_onlineDesc = readString();
	//end
	_corpsMemInfoList[corpsMemInfoListIndex].setOnlineDesc (_corpsMemInfoList_onlineDesc);

	// 最后一次离线时间
	long _corpsMemInfoList_lastOfflineTime = readLong();
	//end
	_corpsMemInfoList[corpsMemInfoListIndex].setLastOfflineTime (_corpsMemInfoList_lastOfflineTime);

	// 军团成员功能列表
	int corpsMemInfoList_corpsMemberFuncInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsMemberFuncInfo[] _corpsMemInfoList_corpsMemberFuncInfoList = new com.imop.lj.common.model.corps.CorpsMemberFuncInfo[corpsMemInfoList_corpsMemberFuncInfoListSize];
	int corpsMemInfoList_corpsMemberFuncInfoListIndex = 0;
	for(corpsMemInfoList_corpsMemberFuncInfoListIndex=0; corpsMemInfoList_corpsMemberFuncInfoListIndex<corpsMemInfoList_corpsMemberFuncInfoListSize; corpsMemInfoList_corpsMemberFuncInfoListIndex++){
		_corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex] = new com.imop.lj.common.model.corps.CorpsMemberFuncInfo();
	// 功能标题
	String _corpsMemInfoList_corpsMemberFuncInfoList_title = readString();
	//end
	_corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex].setTitle (_corpsMemInfoList_corpsMemberFuncInfoList_title);

	// 附加描述
	String _corpsMemInfoList_corpsMemberFuncInfoList_desc = readString();
	//end
	_corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex].setDesc (_corpsMemInfoList_corpsMemberFuncInfoList_desc);

	// 功能类型ID
	int _corpsMemInfoList_corpsMemberFuncInfoList_funcId = readInteger();
	//end
	_corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex].setFuncId (_corpsMemInfoList_corpsMemberFuncInfoList_funcId);

	// 军团ID
	long _corpsMemInfoList_corpsMemberFuncInfoList_memUUID = readLong();
	//end
	_corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex].setMemUUID (_corpsMemInfoList_corpsMemberFuncInfoList_memUUID);

	// 功能是否可用 1:可用，0：不可用
	int _corpsMemInfoList_corpsMemberFuncInfoList_available = readInteger();
	//end
	_corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex].setAvailable (_corpsMemInfoList_corpsMemberFuncInfoList_available);
	}
	//end
	_corpsMemInfoList[corpsMemInfoListIndex].setCorpsMemberFuncInfoList (_corpsMemInfoList_corpsMemberFuncInfoList);
	}
	//end


	// 军团面板功能列表
	int corpsPanelFuncInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsFuncInfo[] _corpsPanelFuncInfoList = new com.imop.lj.common.model.corps.CorpsFuncInfo[corpsPanelFuncInfoListSize];
	int corpsPanelFuncInfoListIndex = 0;
	for(corpsPanelFuncInfoListIndex=0; corpsPanelFuncInfoListIndex<corpsPanelFuncInfoListSize; corpsPanelFuncInfoListIndex++){
		_corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex] = new com.imop.lj.common.model.corps.CorpsFuncInfo();
	// 功能标题
	String _corpsPanelFuncInfoList_title = readString();
	//end
	_corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex].setTitle (_corpsPanelFuncInfoList_title);

	// 附加描述
	String _corpsPanelFuncInfoList_desc = readString();
	//end
	_corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex].setDesc (_corpsPanelFuncInfoList_desc);

	// 功能类型ID
	int _corpsPanelFuncInfoList_funcId = readInteger();
	//end
	_corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex].setFuncId (_corpsPanelFuncInfoList_funcId);

	// 军团ID
	long _corpsPanelFuncInfoList_corpsUUID = readLong();
	//end
	_corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex].setCorpsUUID (_corpsPanelFuncInfoList_corpsUUID);

	// 功能是否可用 1:可用，0：不可用
	int _corpsPanelFuncInfoList_available = readInteger();
	//end
	_corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex].setAvailable (_corpsPanelFuncInfoList_available);
	}
	//end



		this.corpsMemInfoList = _corpsMemInfoList;
		this.corpsPanelFuncInfoList = _corpsPanelFuncInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 军团成员列表
	writeShort(corpsMemInfoList.length);
	int corpsMemInfoListIndex = 0;
	int corpsMemInfoListSize = corpsMemInfoList.length;
	for(corpsMemInfoListIndex=0; corpsMemInfoListIndex<corpsMemInfoListSize; corpsMemInfoListIndex++){

	long corpsMemInfoList_memId = corpsMemInfoList[corpsMemInfoListIndex].getMemId();

	// 成员ID
	writeLong(corpsMemInfoList_memId);

	String corpsMemInfoList_name = corpsMemInfoList[corpsMemInfoListIndex].getName();

	// 名称
	writeString(corpsMemInfoList_name);

	int corpsMemInfoList_tplId = corpsMemInfoList[corpsMemInfoListIndex].getTplId();

	// 模板Id
	writeInteger(corpsMemInfoList_tplId);

	int corpsMemInfoList_level = corpsMemInfoList[corpsMemInfoListIndex].getLevel();

	// 级别
	writeInteger(corpsMemInfoList_level);

	int corpsMemInfoList_memJob = corpsMemInfoList[corpsMemInfoListIndex].getMemJob();

	// 职位
	writeInteger(corpsMemInfoList_memJob);

	int corpsMemInfoList_petJob = corpsMemInfoList[corpsMemInfoListIndex].getPetJob();

	// 职业
	writeInteger(corpsMemInfoList_petJob);

	long corpsMemInfoList_weekContribution = corpsMemInfoList[corpsMemInfoListIndex].getWeekContribution();

	// 本周贡献
	writeLong(corpsMemInfoList_weekContribution);

	long corpsMemInfoList_totalContribution = corpsMemInfoList[corpsMemInfoListIndex].getTotalContribution();

	// 总贡献
	writeLong(corpsMemInfoList_totalContribution);

	String corpsMemInfoList_onlineDesc = corpsMemInfoList[corpsMemInfoListIndex].getOnlineDesc();

	// 在线描述
	writeString(corpsMemInfoList_onlineDesc);

	long corpsMemInfoList_lastOfflineTime = corpsMemInfoList[corpsMemInfoListIndex].getLastOfflineTime();

	// 最后一次离线时间
	writeLong(corpsMemInfoList_lastOfflineTime);

	com.imop.lj.common.model.corps.CorpsMemberFuncInfo[] corpsMemInfoList_corpsMemberFuncInfoList = corpsMemInfoList[corpsMemInfoListIndex].getCorpsMemberFuncInfoList();

	// 军团成员功能列表
	writeShort(corpsMemInfoList_corpsMemberFuncInfoList.length);
	int corpsMemInfoList_corpsMemberFuncInfoListIndex = 0;
	int corpsMemInfoList_corpsMemberFuncInfoListSize = corpsMemInfoList_corpsMemberFuncInfoList.length;
	for(corpsMemInfoList_corpsMemberFuncInfoListIndex=0; corpsMemInfoList_corpsMemberFuncInfoListIndex<corpsMemInfoList_corpsMemberFuncInfoListSize; corpsMemInfoList_corpsMemberFuncInfoListIndex++){

	String corpsMemInfoList_corpsMemberFuncInfoList_title = corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex].getTitle();

	// 功能标题
	writeString(corpsMemInfoList_corpsMemberFuncInfoList_title);

	String corpsMemInfoList_corpsMemberFuncInfoList_desc = corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex].getDesc();

	// 附加描述
	writeString(corpsMemInfoList_corpsMemberFuncInfoList_desc);

	int corpsMemInfoList_corpsMemberFuncInfoList_funcId = corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex].getFuncId();

	// 功能类型ID
	writeInteger(corpsMemInfoList_corpsMemberFuncInfoList_funcId);

	long corpsMemInfoList_corpsMemberFuncInfoList_memUUID = corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex].getMemUUID();

	// 军团ID
	writeLong(corpsMemInfoList_corpsMemberFuncInfoList_memUUID);

	int corpsMemInfoList_corpsMemberFuncInfoList_available = corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex].getAvailable();

	// 功能是否可用 1:可用，0：不可用
	writeInteger(corpsMemInfoList_corpsMemberFuncInfoList_available);
	}
	//end
	}
	//end


	// 军团面板功能列表
	writeShort(corpsPanelFuncInfoList.length);
	int corpsPanelFuncInfoListIndex = 0;
	int corpsPanelFuncInfoListSize = corpsPanelFuncInfoList.length;
	for(corpsPanelFuncInfoListIndex=0; corpsPanelFuncInfoListIndex<corpsPanelFuncInfoListSize; corpsPanelFuncInfoListIndex++){

	String corpsPanelFuncInfoList_title = corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex].getTitle();

	// 功能标题
	writeString(corpsPanelFuncInfoList_title);

	String corpsPanelFuncInfoList_desc = corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex].getDesc();

	// 附加描述
	writeString(corpsPanelFuncInfoList_desc);

	int corpsPanelFuncInfoList_funcId = corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex].getFuncId();

	// 功能类型ID
	writeInteger(corpsPanelFuncInfoList_funcId);

	long corpsPanelFuncInfoList_corpsUUID = corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex].getCorpsUUID();

	// 军团ID
	writeLong(corpsPanelFuncInfoList_corpsUUID);

	int corpsPanelFuncInfoList_available = corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex].getAvailable();

	// 功能是否可用 1:可用，0：不可用
	writeInteger(corpsPanelFuncInfoList_available);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OPEN_CORPS_MEMBER_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_CORPS_MEMBER_LIST";
	}

	public com.imop.lj.common.model.corps.CorpsMemberInfo[] getCorpsMemInfoList(){
		return corpsMemInfoList;
	}

	public void setCorpsMemInfoList(com.imop.lj.common.model.corps.CorpsMemberInfo[] corpsMemInfoList){
		this.corpsMemInfoList = corpsMemInfoList;
	}	

	public com.imop.lj.common.model.corps.CorpsFuncInfo[] getCorpsPanelFuncInfoList(){
		return corpsPanelFuncInfoList;
	}

	public void setCorpsPanelFuncInfoList(com.imop.lj.common.model.corps.CorpsFuncInfo[] corpsPanelFuncInfoList){
		this.corpsPanelFuncInfoList = corpsPanelFuncInfoList;
	}	
}