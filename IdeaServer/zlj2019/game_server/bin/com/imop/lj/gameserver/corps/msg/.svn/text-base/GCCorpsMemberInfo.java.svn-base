package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回个人帮派成员信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsMemberInfo extends GCMessage{
	
	/** 军团成员 */
	private com.imop.lj.common.model.corps.CorpsMemberInfo corpsMemInfo;
	/** 军团名称 */
	private String corpsName;

	public GCCorpsMemberInfo (){
	}
	
	public GCCorpsMemberInfo (
			com.imop.lj.common.model.corps.CorpsMemberInfo corpsMemInfo,
			String corpsName ){
			this.corpsMemInfo = corpsMemInfo;
			this.corpsName = corpsName;
	}

	@Override
	protected boolean readImpl() {
	// 军团成员
	com.imop.lj.common.model.corps.CorpsMemberInfo _corpsMemInfo = new com.imop.lj.common.model.corps.CorpsMemberInfo();

	// 成员ID
	long _corpsMemInfo_memId = readLong();
	//end
	_corpsMemInfo.setMemId (_corpsMemInfo_memId);

	// 名称
	String _corpsMemInfo_name = readString();
	//end
	_corpsMemInfo.setName (_corpsMemInfo_name);

	// 模板Id
	int _corpsMemInfo_tplId = readInteger();
	//end
	_corpsMemInfo.setTplId (_corpsMemInfo_tplId);

	// 级别
	int _corpsMemInfo_level = readInteger();
	//end
	_corpsMemInfo.setLevel (_corpsMemInfo_level);

	// 职位
	int _corpsMemInfo_memJob = readInteger();
	//end
	_corpsMemInfo.setMemJob (_corpsMemInfo_memJob);

	// 职业
	int _corpsMemInfo_petJob = readInteger();
	//end
	_corpsMemInfo.setPetJob (_corpsMemInfo_petJob);

	// 本周贡献
	long _corpsMemInfo_weekContribution = readLong();
	//end
	_corpsMemInfo.setWeekContribution (_corpsMemInfo_weekContribution);

	// 总贡献
	long _corpsMemInfo_totalContribution = readLong();
	//end
	_corpsMemInfo.setTotalContribution (_corpsMemInfo_totalContribution);

	// 在线描述
	String _corpsMemInfo_onlineDesc = readString();
	//end
	_corpsMemInfo.setOnlineDesc (_corpsMemInfo_onlineDesc);

	// 最后一次离线时间
	long _corpsMemInfo_lastOfflineTime = readLong();
	//end
	_corpsMemInfo.setLastOfflineTime (_corpsMemInfo_lastOfflineTime);

	// 军团成员功能列表
	int corpsMemInfo_corpsMemberFuncInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsMemberFuncInfo[] _corpsMemInfo_corpsMemberFuncInfoList = new com.imop.lj.common.model.corps.CorpsMemberFuncInfo[corpsMemInfo_corpsMemberFuncInfoListSize];
	int corpsMemInfo_corpsMemberFuncInfoListIndex = 0;
	for(corpsMemInfo_corpsMemberFuncInfoListIndex=0; corpsMemInfo_corpsMemberFuncInfoListIndex<corpsMemInfo_corpsMemberFuncInfoListSize; corpsMemInfo_corpsMemberFuncInfoListIndex++){
		_corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex] = new com.imop.lj.common.model.corps.CorpsMemberFuncInfo();
	// 功能标题
	String _corpsMemInfo_corpsMemberFuncInfoList_title = readString();
	//end
	_corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex].setTitle (_corpsMemInfo_corpsMemberFuncInfoList_title);

	// 附加描述
	String _corpsMemInfo_corpsMemberFuncInfoList_desc = readString();
	//end
	_corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex].setDesc (_corpsMemInfo_corpsMemberFuncInfoList_desc);

	// 功能类型ID
	int _corpsMemInfo_corpsMemberFuncInfoList_funcId = readInteger();
	//end
	_corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex].setFuncId (_corpsMemInfo_corpsMemberFuncInfoList_funcId);

	// 军团ID
	long _corpsMemInfo_corpsMemberFuncInfoList_memUUID = readLong();
	//end
	_corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex].setMemUUID (_corpsMemInfo_corpsMemberFuncInfoList_memUUID);

	// 功能是否可用 1:可用，0：不可用
	int _corpsMemInfo_corpsMemberFuncInfoList_available = readInteger();
	//end
	_corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex].setAvailable (_corpsMemInfo_corpsMemberFuncInfoList_available);
	}
	//end
	_corpsMemInfo.setCorpsMemberFuncInfoList (_corpsMemInfo_corpsMemberFuncInfoList);


	// 军团名称
	String _corpsName = readString();
	//end



		this.corpsMemInfo = _corpsMemInfo;
		this.corpsName = _corpsName;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	long corpsMemInfo_memId = corpsMemInfo.getMemId ();

	// 成员ID
	writeLong(corpsMemInfo_memId);

	String corpsMemInfo_name = corpsMemInfo.getName ();

	// 名称
	writeString(corpsMemInfo_name);

	int corpsMemInfo_tplId = corpsMemInfo.getTplId ();

	// 模板Id
	writeInteger(corpsMemInfo_tplId);

	int corpsMemInfo_level = corpsMemInfo.getLevel ();

	// 级别
	writeInteger(corpsMemInfo_level);

	int corpsMemInfo_memJob = corpsMemInfo.getMemJob ();

	// 职位
	writeInteger(corpsMemInfo_memJob);

	int corpsMemInfo_petJob = corpsMemInfo.getPetJob ();

	// 职业
	writeInteger(corpsMemInfo_petJob);

	long corpsMemInfo_weekContribution = corpsMemInfo.getWeekContribution ();

	// 本周贡献
	writeLong(corpsMemInfo_weekContribution);

	long corpsMemInfo_totalContribution = corpsMemInfo.getTotalContribution ();

	// 总贡献
	writeLong(corpsMemInfo_totalContribution);

	String corpsMemInfo_onlineDesc = corpsMemInfo.getOnlineDesc ();

	// 在线描述
	writeString(corpsMemInfo_onlineDesc);

	long corpsMemInfo_lastOfflineTime = corpsMemInfo.getLastOfflineTime ();

	// 最后一次离线时间
	writeLong(corpsMemInfo_lastOfflineTime);

	com.imop.lj.common.model.corps.CorpsMemberFuncInfo[] corpsMemInfo_corpsMemberFuncInfoList = corpsMemInfo.getCorpsMemberFuncInfoList ();

	// 军团成员功能列表
	writeShort(corpsMemInfo_corpsMemberFuncInfoList.length);
	int corpsMemInfo_corpsMemberFuncInfoListIndex = 0;
	int corpsMemInfo_corpsMemberFuncInfoListSize = corpsMemInfo_corpsMemberFuncInfoList.length;
	for(corpsMemInfo_corpsMemberFuncInfoListIndex=0; corpsMemInfo_corpsMemberFuncInfoListIndex<corpsMemInfo_corpsMemberFuncInfoListSize; corpsMemInfo_corpsMemberFuncInfoListIndex++){

	String corpsMemInfo_corpsMemberFuncInfoList_title = corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex].getTitle();

	// 功能标题
	writeString(corpsMemInfo_corpsMemberFuncInfoList_title);

	String corpsMemInfo_corpsMemberFuncInfoList_desc = corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex].getDesc();

	// 附加描述
	writeString(corpsMemInfo_corpsMemberFuncInfoList_desc);

	int corpsMemInfo_corpsMemberFuncInfoList_funcId = corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex].getFuncId();

	// 功能类型ID
	writeInteger(corpsMemInfo_corpsMemberFuncInfoList_funcId);

	long corpsMemInfo_corpsMemberFuncInfoList_memUUID = corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex].getMemUUID();

	// 军团ID
	writeLong(corpsMemInfo_corpsMemberFuncInfoList_memUUID);

	int corpsMemInfo_corpsMemberFuncInfoList_available = corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex].getAvailable();

	// 功能是否可用 1:可用，0：不可用
	writeInteger(corpsMemInfo_corpsMemberFuncInfoList_available);
	}
	//end


	// 军团名称
	writeString(corpsName);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CORPS_MEMBER_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CORPS_MEMBER_INFO";
	}

	public com.imop.lj.common.model.corps.CorpsMemberInfo getCorpsMemInfo(){
		return corpsMemInfo;
	}
		
	public void setCorpsMemInfo(com.imop.lj.common.model.corps.CorpsMemberInfo corpsMemInfo){
		this.corpsMemInfo = corpsMemInfo;
	}

	public String getCorpsName(){
		return corpsName;
	}
		
	public void setCorpsName(String corpsName){
		this.corpsName = corpsName;
	}
}