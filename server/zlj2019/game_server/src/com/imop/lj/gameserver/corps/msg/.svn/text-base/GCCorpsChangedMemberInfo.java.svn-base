package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回有更改的帮派成员信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsChangedMemberInfo extends GCMessage{
	
	/** 军团成员 */
	private com.imop.lj.common.model.corps.CorpsMemberInfo[] corpsMemInfoList;
	/** 更新类别 1修改,2添加,3删除 */
	private int changeType;

	public GCCorpsChangedMemberInfo (){
	}
	
	public GCCorpsChangedMemberInfo (
			com.imop.lj.common.model.corps.CorpsMemberInfo[] corpsMemInfoList,
			int changeType ){
			this.corpsMemInfoList = corpsMemInfoList;
			this.changeType = changeType;
	}

	@Override
	protected boolean readImpl() {

	// 军团成员
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


	// 更新类别 1修改,2添加,3删除
	int _changeType = readInteger();
	//end



		this.corpsMemInfoList = _corpsMemInfoList;
		this.changeType = _changeType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 军团成员
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


	// 更新类别 1修改,2添加,3删除
	writeInteger(changeType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CORPS_CHANGED_MEMBER_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CORPS_CHANGED_MEMBER_INFO";
	}

	public com.imop.lj.common.model.corps.CorpsMemberInfo[] getCorpsMemInfoList(){
		return corpsMemInfoList;
	}

	public void setCorpsMemInfoList(com.imop.lj.common.model.corps.CorpsMemberInfo[] corpsMemInfoList){
		this.corpsMemInfoList = corpsMemInfoList;
	}	

	public int getChangeType(){
		return changeType;
	}
		
	public void setChangeType(int changeType){
		this.changeType = changeType;
	}
}