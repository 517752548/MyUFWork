package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回军团面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsPanel extends GCMessage{
	
	/** 军详细团信息 */
	private com.imop.lj.common.model.corps.DetailCorpsInfo detailCorpsInfo;
	/** 军团成员申请信息 */
	private com.imop.lj.common.model.corps.MemberApplyInfo[] memberApplyInfoList;
	/** 军团日志列表 */
	private com.imop.lj.common.model.corps.CorpsEventInfo[] corpsEventInfoList;
	/** 军团面板功能列表 */
	private com.imop.lj.common.model.corps.CorpsFuncInfo[] corpsPanelFuncInfoList;

	public GCOpenCorpsPanel (){
	}
	
	public GCOpenCorpsPanel (
			com.imop.lj.common.model.corps.DetailCorpsInfo detailCorpsInfo,
			com.imop.lj.common.model.corps.MemberApplyInfo[] memberApplyInfoList,
			com.imop.lj.common.model.corps.CorpsEventInfo[] corpsEventInfoList,
			com.imop.lj.common.model.corps.CorpsFuncInfo[] corpsPanelFuncInfoList ){
			this.detailCorpsInfo = detailCorpsInfo;
			this.memberApplyInfoList = memberApplyInfoList;
			this.corpsEventInfoList = corpsEventInfoList;
			this.corpsPanelFuncInfoList = corpsPanelFuncInfoList;
	}

	@Override
	protected boolean readImpl() {
	// 军详细团信息
	com.imop.lj.common.model.corps.DetailCorpsInfo _detailCorpsInfo = new com.imop.lj.common.model.corps.DetailCorpsInfo();

	// 军团ID
	long _detailCorpsInfo_corpsId = readLong();
	//end
	_detailCorpsInfo.setCorpsId (_detailCorpsInfo_corpsId);

	// 军团名称
	String _detailCorpsInfo_name = readString();
	//end
	_detailCorpsInfo.setName (_detailCorpsInfo_name);

	// 军团级别
	int _detailCorpsInfo_level = readInteger();
	//end
	_detailCorpsInfo.setLevel (_detailCorpsInfo_level);

	// 是否有下一级，1：有；0：没有
	int _detailCorpsInfo_hasNextLevel = readInteger();
	//end
	_detailCorpsInfo.setHasNextLevel (_detailCorpsInfo_hasNextLevel);

	// 当前成员数量
	int _detailCorpsInfo_currMemNum = readInteger();
	//end
	_detailCorpsInfo.setCurrMemNum (_detailCorpsInfo_currMemNum);

	// 当前帮派经验
	long _detailCorpsInfo_currExp = readLong();
	//end
	_detailCorpsInfo.setCurrExp (_detailCorpsInfo_currExp);

	// 当前帮派资金
	long _detailCorpsInfo_currFund = readLong();
	//end
	_detailCorpsInfo.setCurrFund (_detailCorpsInfo_currFund);

	// 团长名称
	String _detailCorpsInfo_presidentName = readString();
	//end
	_detailCorpsInfo.setPresidentName (_detailCorpsInfo_presidentName);

	// 公告
	String _detailCorpsInfo_notice = readString();
	//end
	_detailCorpsInfo.setNotice (_detailCorpsInfo_notice);

	// 军团排名
	int _detailCorpsInfo_rank = readInteger();
	//end
	_detailCorpsInfo.setRank (_detailCorpsInfo_rank);

	// 帮会解散确认时间
	long _detailCorpsInfo_disbandConfirmDate = readLong();
	//end
	_detailCorpsInfo.setDisbandConfirmDate (_detailCorpsInfo_disbandConfirmDate);


	// 军团成员申请信息
	int memberApplyInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.MemberApplyInfo[] _memberApplyInfoList = new com.imop.lj.common.model.corps.MemberApplyInfo[memberApplyInfoListSize];
	int memberApplyInfoListIndex = 0;
	for(memberApplyInfoListIndex=0; memberApplyInfoListIndex<memberApplyInfoListSize; memberApplyInfoListIndex++){
		_memberApplyInfoList[memberApplyInfoListIndex] = new com.imop.lj.common.model.corps.MemberApplyInfo();
	// 申请玩家ID
	long _memberApplyInfoList_memId = readLong();
	//end
	_memberApplyInfoList[memberApplyInfoListIndex].setMemId (_memberApplyInfoList_memId);

	// 玩家姓名
	String _memberApplyInfoList_name = readString();
	//end
	_memberApplyInfoList[memberApplyInfoListIndex].setName (_memberApplyInfoList_name);

	// 玩家级别
	int _memberApplyInfoList_level = readInteger();
	//end
	_memberApplyInfoList[memberApplyInfoListIndex].setLevel (_memberApplyInfoList_level);

	// 玩家性别
	int _memberApplyInfoList_sex = readInteger();
	//end
	_memberApplyInfoList[memberApplyInfoListIndex].setSex (_memberApplyInfoList_sex);

	// 玩家职业
	int _memberApplyInfoList_petJob = readInteger();
	//end
	_memberApplyInfoList[memberApplyInfoListIndex].setPetJob (_memberApplyInfoList_petJob);

	// 申请功能列表
	int memberApplyInfoList_applyFuncInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsMemberFuncInfo[] _memberApplyInfoList_applyFuncInfoList = new com.imop.lj.common.model.corps.CorpsMemberFuncInfo[memberApplyInfoList_applyFuncInfoListSize];
	int memberApplyInfoList_applyFuncInfoListIndex = 0;
	for(memberApplyInfoList_applyFuncInfoListIndex=0; memberApplyInfoList_applyFuncInfoListIndex<memberApplyInfoList_applyFuncInfoListSize; memberApplyInfoList_applyFuncInfoListIndex++){
		_memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex] = new com.imop.lj.common.model.corps.CorpsMemberFuncInfo();
	// 功能标题
	String _memberApplyInfoList_applyFuncInfoList_title = readString();
	//end
	_memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex].setTitle (_memberApplyInfoList_applyFuncInfoList_title);

	// 附加描述
	String _memberApplyInfoList_applyFuncInfoList_desc = readString();
	//end
	_memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex].setDesc (_memberApplyInfoList_applyFuncInfoList_desc);

	// 功能类型ID
	int _memberApplyInfoList_applyFuncInfoList_funcId = readInteger();
	//end
	_memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex].setFuncId (_memberApplyInfoList_applyFuncInfoList_funcId);

	// 军团ID
	long _memberApplyInfoList_applyFuncInfoList_memUUID = readLong();
	//end
	_memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex].setMemUUID (_memberApplyInfoList_applyFuncInfoList_memUUID);

	// 功能是否可用 1:可用，0：不可用
	int _memberApplyInfoList_applyFuncInfoList_available = readInteger();
	//end
	_memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex].setAvailable (_memberApplyInfoList_applyFuncInfoList_available);
	}
	//end
	_memberApplyInfoList[memberApplyInfoListIndex].setApplyFuncInfoList (_memberApplyInfoList_applyFuncInfoList);
	}
	//end


	// 军团日志列表
	int corpsEventInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsEventInfo[] _corpsEventInfoList = new com.imop.lj.common.model.corps.CorpsEventInfo[corpsEventInfoListSize];
	int corpsEventInfoListIndex = 0;
	for(corpsEventInfoListIndex=0; corpsEventInfoListIndex<corpsEventInfoListSize; corpsEventInfoListIndex++){
		_corpsEventInfoList[corpsEventInfoListIndex] = new com.imop.lj.common.model.corps.CorpsEventInfo();
	// 军团日志信息
	String _corpsEventInfoList_corpsLog = readString();
	//end
	_corpsEventInfoList[corpsEventInfoListIndex].setCorpsLog (_corpsEventInfoList_corpsLog);

	// 在线状态描述
	String _corpsEventInfoList_onlineDesc = readString();
	//end
	_corpsEventInfoList[corpsEventInfoListIndex].setOnlineDesc (_corpsEventInfoList_onlineDesc);
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



		this.detailCorpsInfo = _detailCorpsInfo;
		this.memberApplyInfoList = _memberApplyInfoList;
		this.corpsEventInfoList = _corpsEventInfoList;
		this.corpsPanelFuncInfoList = _corpsPanelFuncInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	long detailCorpsInfo_corpsId = detailCorpsInfo.getCorpsId ();

	// 军团ID
	writeLong(detailCorpsInfo_corpsId);

	String detailCorpsInfo_name = detailCorpsInfo.getName ();

	// 军团名称
	writeString(detailCorpsInfo_name);

	int detailCorpsInfo_level = detailCorpsInfo.getLevel ();

	// 军团级别
	writeInteger(detailCorpsInfo_level);

	int detailCorpsInfo_hasNextLevel = detailCorpsInfo.getHasNextLevel ();

	// 是否有下一级，1：有；0：没有
	writeInteger(detailCorpsInfo_hasNextLevel);

	int detailCorpsInfo_currMemNum = detailCorpsInfo.getCurrMemNum ();

	// 当前成员数量
	writeInteger(detailCorpsInfo_currMemNum);

	long detailCorpsInfo_currExp = detailCorpsInfo.getCurrExp ();

	// 当前帮派经验
	writeLong(detailCorpsInfo_currExp);

	long detailCorpsInfo_currFund = detailCorpsInfo.getCurrFund ();

	// 当前帮派资金
	writeLong(detailCorpsInfo_currFund);

	String detailCorpsInfo_presidentName = detailCorpsInfo.getPresidentName ();

	// 团长名称
	writeString(detailCorpsInfo_presidentName);

	String detailCorpsInfo_notice = detailCorpsInfo.getNotice ();

	// 公告
	writeString(detailCorpsInfo_notice);

	int detailCorpsInfo_rank = detailCorpsInfo.getRank ();

	// 军团排名
	writeInteger(detailCorpsInfo_rank);

	long detailCorpsInfo_disbandConfirmDate = detailCorpsInfo.getDisbandConfirmDate ();

	// 帮会解散确认时间
	writeLong(detailCorpsInfo_disbandConfirmDate);


	// 军团成员申请信息
	writeShort(memberApplyInfoList.length);
	int memberApplyInfoListIndex = 0;
	int memberApplyInfoListSize = memberApplyInfoList.length;
	for(memberApplyInfoListIndex=0; memberApplyInfoListIndex<memberApplyInfoListSize; memberApplyInfoListIndex++){

	long memberApplyInfoList_memId = memberApplyInfoList[memberApplyInfoListIndex].getMemId();

	// 申请玩家ID
	writeLong(memberApplyInfoList_memId);

	String memberApplyInfoList_name = memberApplyInfoList[memberApplyInfoListIndex].getName();

	// 玩家姓名
	writeString(memberApplyInfoList_name);

	int memberApplyInfoList_level = memberApplyInfoList[memberApplyInfoListIndex].getLevel();

	// 玩家级别
	writeInteger(memberApplyInfoList_level);

	int memberApplyInfoList_sex = memberApplyInfoList[memberApplyInfoListIndex].getSex();

	// 玩家性别
	writeInteger(memberApplyInfoList_sex);

	int memberApplyInfoList_petJob = memberApplyInfoList[memberApplyInfoListIndex].getPetJob();

	// 玩家职业
	writeInteger(memberApplyInfoList_petJob);

	com.imop.lj.common.model.corps.CorpsMemberFuncInfo[] memberApplyInfoList_applyFuncInfoList = memberApplyInfoList[memberApplyInfoListIndex].getApplyFuncInfoList();

	// 申请功能列表
	writeShort(memberApplyInfoList_applyFuncInfoList.length);
	int memberApplyInfoList_applyFuncInfoListIndex = 0;
	int memberApplyInfoList_applyFuncInfoListSize = memberApplyInfoList_applyFuncInfoList.length;
	for(memberApplyInfoList_applyFuncInfoListIndex=0; memberApplyInfoList_applyFuncInfoListIndex<memberApplyInfoList_applyFuncInfoListSize; memberApplyInfoList_applyFuncInfoListIndex++){

	String memberApplyInfoList_applyFuncInfoList_title = memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex].getTitle();

	// 功能标题
	writeString(memberApplyInfoList_applyFuncInfoList_title);

	String memberApplyInfoList_applyFuncInfoList_desc = memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex].getDesc();

	// 附加描述
	writeString(memberApplyInfoList_applyFuncInfoList_desc);

	int memberApplyInfoList_applyFuncInfoList_funcId = memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex].getFuncId();

	// 功能类型ID
	writeInteger(memberApplyInfoList_applyFuncInfoList_funcId);

	long memberApplyInfoList_applyFuncInfoList_memUUID = memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex].getMemUUID();

	// 军团ID
	writeLong(memberApplyInfoList_applyFuncInfoList_memUUID);

	int memberApplyInfoList_applyFuncInfoList_available = memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex].getAvailable();

	// 功能是否可用 1:可用，0：不可用
	writeInteger(memberApplyInfoList_applyFuncInfoList_available);
	}
	//end
	}
	//end


	// 军团日志列表
	writeShort(corpsEventInfoList.length);
	int corpsEventInfoListIndex = 0;
	int corpsEventInfoListSize = corpsEventInfoList.length;
	for(corpsEventInfoListIndex=0; corpsEventInfoListIndex<corpsEventInfoListSize; corpsEventInfoListIndex++){

	String corpsEventInfoList_corpsLog = corpsEventInfoList[corpsEventInfoListIndex].getCorpsLog();

	// 军团日志信息
	writeString(corpsEventInfoList_corpsLog);

	String corpsEventInfoList_onlineDesc = corpsEventInfoList[corpsEventInfoListIndex].getOnlineDesc();

	// 在线状态描述
	writeString(corpsEventInfoList_onlineDesc);
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
		return MessageType.GC_OPEN_CORPS_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_CORPS_PANEL";
	}

	public com.imop.lj.common.model.corps.DetailCorpsInfo getDetailCorpsInfo(){
		return detailCorpsInfo;
	}
		
	public void setDetailCorpsInfo(com.imop.lj.common.model.corps.DetailCorpsInfo detailCorpsInfo){
		this.detailCorpsInfo = detailCorpsInfo;
	}

	public com.imop.lj.common.model.corps.MemberApplyInfo[] getMemberApplyInfoList(){
		return memberApplyInfoList;
	}

	public void setMemberApplyInfoList(com.imop.lj.common.model.corps.MemberApplyInfo[] memberApplyInfoList){
		this.memberApplyInfoList = memberApplyInfoList;
	}	

	public com.imop.lj.common.model.corps.CorpsEventInfo[] getCorpsEventInfoList(){
		return corpsEventInfoList;
	}

	public void setCorpsEventInfoList(com.imop.lj.common.model.corps.CorpsEventInfo[] corpsEventInfoList){
		this.corpsEventInfoList = corpsEventInfoList;
	}	

	public com.imop.lj.common.model.corps.CorpsFuncInfo[] getCorpsPanelFuncInfoList(){
		return corpsPanelFuncInfoList;
	}

	public void setCorpsPanelFuncInfoList(com.imop.lj.common.model.corps.CorpsFuncInfo[] corpsPanelFuncInfoList){
		this.corpsPanelFuncInfoList = corpsPanelFuncInfoList;
	}	
}