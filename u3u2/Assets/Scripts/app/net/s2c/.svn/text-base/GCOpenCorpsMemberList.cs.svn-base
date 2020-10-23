
using System;
namespace app.net
{
/**
 * 返回军团成员列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsMemberList :BaseMessage
{
	/** 军团成员列表 */
	private CorpsMemberInfo[] corpsMemInfoList;
	/** 军团面板功能列表 */
	private CorpsFuncInfo[] corpsPanelFuncInfoList;

	public GCOpenCorpsMemberList ()
	{
	}

	protected override void ReadImpl()
	{

	// 军团成员列表
	int corpsMemInfoListSize = ReadShort();
	CorpsMemberInfo[] _corpsMemInfoList = new CorpsMemberInfo[corpsMemInfoListSize];
	int corpsMemInfoListIndex = 0;
	CorpsMemberInfo _corpsMemInfoListTmp = null;
	for(corpsMemInfoListIndex=0; corpsMemInfoListIndex<corpsMemInfoListSize; corpsMemInfoListIndex++){
		_corpsMemInfoListTmp = new CorpsMemberInfo();
		_corpsMemInfoList[corpsMemInfoListIndex] = _corpsMemInfoListTmp;
	// 成员ID
	long _corpsMemInfoList_memId = ReadLong();	_corpsMemInfoListTmp.memId = _corpsMemInfoList_memId;
		// 名称
	string _corpsMemInfoList_name = ReadString();	_corpsMemInfoListTmp.name = _corpsMemInfoList_name;
		// 模板Id
	int _corpsMemInfoList_tplId = ReadInt();	_corpsMemInfoListTmp.tplId = _corpsMemInfoList_tplId;
		// 级别
	int _corpsMemInfoList_level = ReadInt();	_corpsMemInfoListTmp.level = _corpsMemInfoList_level;
		// 职位
	int _corpsMemInfoList_memJob = ReadInt();	_corpsMemInfoListTmp.memJob = _corpsMemInfoList_memJob;
		// 职业
	int _corpsMemInfoList_petJob = ReadInt();	_corpsMemInfoListTmp.petJob = _corpsMemInfoList_petJob;
		// 本周贡献
	long _corpsMemInfoList_weekContribution = ReadLong();	_corpsMemInfoListTmp.weekContribution = _corpsMemInfoList_weekContribution;
		// 总贡献
	long _corpsMemInfoList_totalContribution = ReadLong();	_corpsMemInfoListTmp.totalContribution = _corpsMemInfoList_totalContribution;
		// 在线描述
	string _corpsMemInfoList_onlineDesc = ReadString();	_corpsMemInfoListTmp.onlineDesc = _corpsMemInfoList_onlineDesc;
		// 最后一次离线时间
	long _corpsMemInfoList_lastOfflineTime = ReadLong();	_corpsMemInfoListTmp.lastOfflineTime = _corpsMemInfoList_lastOfflineTime;
	
	// 军团成员功能列表
	int corpsMemInfoList_corpsMemberFuncInfoListSize = ReadShort();
	CorpsMemberFuncInfo[] _corpsMemInfoList_corpsMemberFuncInfoList = new CorpsMemberFuncInfo[corpsMemInfoList_corpsMemberFuncInfoListSize];
	int corpsMemInfoList_corpsMemberFuncInfoListIndex = 0;
	CorpsMemberFuncInfo _corpsMemInfoList_corpsMemberFuncInfoListTmp = null;
	for(corpsMemInfoList_corpsMemberFuncInfoListIndex=0; corpsMemInfoList_corpsMemberFuncInfoListIndex<corpsMemInfoList_corpsMemberFuncInfoListSize; corpsMemInfoList_corpsMemberFuncInfoListIndex++){
		_corpsMemInfoList_corpsMemberFuncInfoListTmp = new CorpsMemberFuncInfo();
		_corpsMemInfoList_corpsMemberFuncInfoList[corpsMemInfoList_corpsMemberFuncInfoListIndex] = _corpsMemInfoList_corpsMemberFuncInfoListTmp;
	// 功能标题
	string _corpsMemInfoList_corpsMemberFuncInfoList_title = ReadString();	_corpsMemInfoList_corpsMemberFuncInfoListTmp.title = _corpsMemInfoList_corpsMemberFuncInfoList_title;
		// 附加描述
	string _corpsMemInfoList_corpsMemberFuncInfoList_desc = ReadString();	_corpsMemInfoList_corpsMemberFuncInfoListTmp.desc = _corpsMemInfoList_corpsMemberFuncInfoList_desc;
		// 功能类型ID
	int _corpsMemInfoList_corpsMemberFuncInfoList_funcId = ReadInt();	_corpsMemInfoList_corpsMemberFuncInfoListTmp.funcId = _corpsMemInfoList_corpsMemberFuncInfoList_funcId;
		// 军团ID
	long _corpsMemInfoList_corpsMemberFuncInfoList_memUUID = ReadLong();	_corpsMemInfoList_corpsMemberFuncInfoListTmp.memUUID = _corpsMemInfoList_corpsMemberFuncInfoList_memUUID;
		// 功能是否可用 1:可用，0：不可用
	int _corpsMemInfoList_corpsMemberFuncInfoList_available = ReadInt();	_corpsMemInfoList_corpsMemberFuncInfoListTmp.available = _corpsMemInfoList_corpsMemberFuncInfoList_available;
		}
	//end
	_corpsMemInfoListTmp.corpsMemberFuncInfoList = _corpsMemInfoList_corpsMemberFuncInfoList;
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



		this.corpsMemInfoList = _corpsMemInfoList;
		this.corpsPanelFuncInfoList = _corpsPanelFuncInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_CORPS_MEMBER_LIST;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCOpenCorpsMemberListEvent;
	}
	

	public CorpsMemberInfo[] getCorpsMemInfoList(){
		return corpsMemInfoList;
	}


	public CorpsFuncInfo[] getCorpsPanelFuncInfoList(){
		return corpsPanelFuncInfoList;
	}


}
}