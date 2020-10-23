
using System;
namespace app.net
{
/**
 * 返回军团面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsPanel :BaseMessage
{
	/** 军详细团信息 */
	private DetailCorpsInfo detailCorpsInfo;
	/** 军团成员申请信息 */
	private MemberApplyInfo[] memberApplyInfoList;
	/** 军团日志列表 */
	private CorpsEventInfo[] corpsEventInfoList;
	/** 军团面板功能列表 */
	private CorpsFuncInfo[] corpsPanelFuncInfoList;

	public GCOpenCorpsPanel ()
	{
	}

	protected override void ReadImpl()
	{
	// 军详细团信息
	DetailCorpsInfo _detailCorpsInfo = new DetailCorpsInfo();
	// 军团ID
	long _detailCorpsInfo_corpsId = ReadLong();	_detailCorpsInfo.corpsId = _detailCorpsInfo_corpsId;
	// 军团名称
	string _detailCorpsInfo_name = ReadString();	_detailCorpsInfo.name = _detailCorpsInfo_name;
	// 军团级别
	int _detailCorpsInfo_level = ReadInt();	_detailCorpsInfo.level = _detailCorpsInfo_level;
	// 是否有下一级，1：有；0：没有
	int _detailCorpsInfo_hasNextLevel = ReadInt();	_detailCorpsInfo.hasNextLevel = _detailCorpsInfo_hasNextLevel;
	// 当前成员数量
	int _detailCorpsInfo_currMemNum = ReadInt();	_detailCorpsInfo.currMemNum = _detailCorpsInfo_currMemNum;
	// 当前帮派经验
	long _detailCorpsInfo_currExp = ReadLong();	_detailCorpsInfo.currExp = _detailCorpsInfo_currExp;
	// 当前帮派资金
	long _detailCorpsInfo_currFund = ReadLong();	_detailCorpsInfo.currFund = _detailCorpsInfo_currFund;
	// 团长名称
	string _detailCorpsInfo_presidentName = ReadString();	_detailCorpsInfo.presidentName = _detailCorpsInfo_presidentName;
	// 公告
	string _detailCorpsInfo_notice = ReadString();	_detailCorpsInfo.notice = _detailCorpsInfo_notice;
	// 军团排名
	int _detailCorpsInfo_rank = ReadInt();	_detailCorpsInfo.rank = _detailCorpsInfo_rank;
	// 帮会解散确认时间
	long _detailCorpsInfo_disbandConfirmDate = ReadLong();	_detailCorpsInfo.disbandConfirmDate = _detailCorpsInfo_disbandConfirmDate;


	// 军团成员申请信息
	int memberApplyInfoListSize = ReadShort();
	MemberApplyInfo[] _memberApplyInfoList = new MemberApplyInfo[memberApplyInfoListSize];
	int memberApplyInfoListIndex = 0;
	MemberApplyInfo _memberApplyInfoListTmp = null;
	for(memberApplyInfoListIndex=0; memberApplyInfoListIndex<memberApplyInfoListSize; memberApplyInfoListIndex++){
		_memberApplyInfoListTmp = new MemberApplyInfo();
		_memberApplyInfoList[memberApplyInfoListIndex] = _memberApplyInfoListTmp;
	// 申请玩家ID
	long _memberApplyInfoList_memId = ReadLong();	_memberApplyInfoListTmp.memId = _memberApplyInfoList_memId;
		// 玩家姓名
	string _memberApplyInfoList_name = ReadString();	_memberApplyInfoListTmp.name = _memberApplyInfoList_name;
		// 玩家级别
	int _memberApplyInfoList_level = ReadInt();	_memberApplyInfoListTmp.level = _memberApplyInfoList_level;
		// 玩家性别
	int _memberApplyInfoList_sex = ReadInt();	_memberApplyInfoListTmp.sex = _memberApplyInfoList_sex;
		// 玩家职业
	int _memberApplyInfoList_petJob = ReadInt();	_memberApplyInfoListTmp.petJob = _memberApplyInfoList_petJob;
	
	// 申请功能列表
	int memberApplyInfoList_applyFuncInfoListSize = ReadShort();
	CorpsMemberFuncInfo[] _memberApplyInfoList_applyFuncInfoList = new CorpsMemberFuncInfo[memberApplyInfoList_applyFuncInfoListSize];
	int memberApplyInfoList_applyFuncInfoListIndex = 0;
	CorpsMemberFuncInfo _memberApplyInfoList_applyFuncInfoListTmp = null;
	for(memberApplyInfoList_applyFuncInfoListIndex=0; memberApplyInfoList_applyFuncInfoListIndex<memberApplyInfoList_applyFuncInfoListSize; memberApplyInfoList_applyFuncInfoListIndex++){
		_memberApplyInfoList_applyFuncInfoListTmp = new CorpsMemberFuncInfo();
		_memberApplyInfoList_applyFuncInfoList[memberApplyInfoList_applyFuncInfoListIndex] = _memberApplyInfoList_applyFuncInfoListTmp;
	// 功能标题
	string _memberApplyInfoList_applyFuncInfoList_title = ReadString();	_memberApplyInfoList_applyFuncInfoListTmp.title = _memberApplyInfoList_applyFuncInfoList_title;
		// 附加描述
	string _memberApplyInfoList_applyFuncInfoList_desc = ReadString();	_memberApplyInfoList_applyFuncInfoListTmp.desc = _memberApplyInfoList_applyFuncInfoList_desc;
		// 功能类型ID
	int _memberApplyInfoList_applyFuncInfoList_funcId = ReadInt();	_memberApplyInfoList_applyFuncInfoListTmp.funcId = _memberApplyInfoList_applyFuncInfoList_funcId;
		// 军团ID
	long _memberApplyInfoList_applyFuncInfoList_memUUID = ReadLong();	_memberApplyInfoList_applyFuncInfoListTmp.memUUID = _memberApplyInfoList_applyFuncInfoList_memUUID;
		// 功能是否可用 1:可用，0：不可用
	int _memberApplyInfoList_applyFuncInfoList_available = ReadInt();	_memberApplyInfoList_applyFuncInfoListTmp.available = _memberApplyInfoList_applyFuncInfoList_available;
		}
	//end
	_memberApplyInfoListTmp.applyFuncInfoList = _memberApplyInfoList_applyFuncInfoList;
		}
	//end


	// 军团日志列表
	int corpsEventInfoListSize = ReadShort();
	CorpsEventInfo[] _corpsEventInfoList = new CorpsEventInfo[corpsEventInfoListSize];
	int corpsEventInfoListIndex = 0;
	CorpsEventInfo _corpsEventInfoListTmp = null;
	for(corpsEventInfoListIndex=0; corpsEventInfoListIndex<corpsEventInfoListSize; corpsEventInfoListIndex++){
		_corpsEventInfoListTmp = new CorpsEventInfo();
		_corpsEventInfoList[corpsEventInfoListIndex] = _corpsEventInfoListTmp;
	// 军团日志信息
	string _corpsEventInfoList_corpsLog = ReadString();	_corpsEventInfoListTmp.corpsLog = _corpsEventInfoList_corpsLog;
		// 在线状态描述
	string _corpsEventInfoList_onlineDesc = ReadString();	_corpsEventInfoListTmp.onlineDesc = _corpsEventInfoList_onlineDesc;
		}
	//end


	// 军团面板功能列表
	int corpsPanelFuncInfoListSize = ReadShort();
	CorpsFuncInfo[] _corpsPanelFuncInfoList = new CorpsFuncInfo[corpsPanelFuncInfoListSize];
	int corpsPanelFuncInfoListIndex = 0;
	CorpsFuncInfo _corpsPanelFuncInfoListTmp = null;
	for(corpsPanelFuncInfoListIndex=0; corpsPanelFuncInfoListIndex<corpsPanelFuncInfoListSize; corpsPanelFuncInfoListIndex++){
		_corpsPanelFuncInfoListTmp = new CorpsFuncInfo();
		_corpsPanelFuncInfoList[corpsPanelFuncInfoListIndex] = _corpsPanelFuncInfoListTmp;
	// 功能标题
	string _corpsPanelFuncInfoList_title = ReadString();	_corpsPanelFuncInfoListTmp.title = _corpsPanelFuncInfoList_title;
		// 附加描述
	string _corpsPanelFuncInfoList_desc = ReadString();	_corpsPanelFuncInfoListTmp.desc = _corpsPanelFuncInfoList_desc;
		// 功能类型ID
	int _corpsPanelFuncInfoList_funcId = ReadInt();	_corpsPanelFuncInfoListTmp.funcId = _corpsPanelFuncInfoList_funcId;
		// 军团ID
	long _corpsPanelFuncInfoList_corpsUUID = ReadLong();	_corpsPanelFuncInfoListTmp.corpsUUID = _corpsPanelFuncInfoList_corpsUUID;
		// 功能是否可用 1:可用，0：不可用
	int _corpsPanelFuncInfoList_available = ReadInt();	_corpsPanelFuncInfoListTmp.available = _corpsPanelFuncInfoList_available;
		}
	//end



		this.detailCorpsInfo = _detailCorpsInfo;
		this.memberApplyInfoList = _memberApplyInfoList;
		this.corpsEventInfoList = _corpsEventInfoList;
		this.corpsPanelFuncInfoList = _corpsPanelFuncInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_CORPS_PANEL;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCOpenCorpsPanelEvent;
	}
	

	public DetailCorpsInfo getDetailCorpsInfo(){
		return detailCorpsInfo;
	}
		

	public MemberApplyInfo[] getMemberApplyInfoList(){
		return memberApplyInfoList;
	}


	public CorpsEventInfo[] getCorpsEventInfoList(){
		return corpsEventInfoList;
	}


	public CorpsFuncInfo[] getCorpsPanelFuncInfoList(){
		return corpsPanelFuncInfoList;
	}


}
}