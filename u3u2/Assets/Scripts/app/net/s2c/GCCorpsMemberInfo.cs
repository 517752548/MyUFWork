
using System;
namespace app.net
{
/**
 * 返回个人帮派成员信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsMemberInfo :BaseMessage
{
	/** 军团成员 */
	private CorpsMemberInfo corpsMemInfo;
	/** 军团名称 */
	private string corpsName;

	public GCCorpsMemberInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 军团成员
	CorpsMemberInfo _corpsMemInfo = new CorpsMemberInfo();
	// 成员ID
	long _corpsMemInfo_memId = ReadLong();	_corpsMemInfo.memId = _corpsMemInfo_memId;
	// 名称
	string _corpsMemInfo_name = ReadString();	_corpsMemInfo.name = _corpsMemInfo_name;
	// 模板Id
	int _corpsMemInfo_tplId = ReadInt();	_corpsMemInfo.tplId = _corpsMemInfo_tplId;
	// 级别
	int _corpsMemInfo_level = ReadInt();	_corpsMemInfo.level = _corpsMemInfo_level;
	// 职位
	int _corpsMemInfo_memJob = ReadInt();	_corpsMemInfo.memJob = _corpsMemInfo_memJob;
	// 职业
	int _corpsMemInfo_petJob = ReadInt();	_corpsMemInfo.petJob = _corpsMemInfo_petJob;
	// 本周贡献
	long _corpsMemInfo_weekContribution = ReadLong();	_corpsMemInfo.weekContribution = _corpsMemInfo_weekContribution;
	// 总贡献
	long _corpsMemInfo_totalContribution = ReadLong();	_corpsMemInfo.totalContribution = _corpsMemInfo_totalContribution;
	// 在线描述
	string _corpsMemInfo_onlineDesc = ReadString();	_corpsMemInfo.onlineDesc = _corpsMemInfo_onlineDesc;
	// 最后一次离线时间
	long _corpsMemInfo_lastOfflineTime = ReadLong();	_corpsMemInfo.lastOfflineTime = _corpsMemInfo_lastOfflineTime;

	// 军团成员功能列表
	int corpsMemInfo_corpsMemberFuncInfoListSize = ReadShort();
	CorpsMemberFuncInfo[] _corpsMemInfo_corpsMemberFuncInfoList = new CorpsMemberFuncInfo[corpsMemInfo_corpsMemberFuncInfoListSize];
	int corpsMemInfo_corpsMemberFuncInfoListIndex = 0;
	CorpsMemberFuncInfo _corpsMemInfo_corpsMemberFuncInfoListTmp = null;
	for(corpsMemInfo_corpsMemberFuncInfoListIndex=0; corpsMemInfo_corpsMemberFuncInfoListIndex<corpsMemInfo_corpsMemberFuncInfoListSize; corpsMemInfo_corpsMemberFuncInfoListIndex++){
		_corpsMemInfo_corpsMemberFuncInfoListTmp = new CorpsMemberFuncInfo();
		_corpsMemInfo_corpsMemberFuncInfoList[corpsMemInfo_corpsMemberFuncInfoListIndex] = _corpsMemInfo_corpsMemberFuncInfoListTmp;
	// 功能标题
	string _corpsMemInfo_corpsMemberFuncInfoList_title = ReadString();	_corpsMemInfo_corpsMemberFuncInfoListTmp.title = _corpsMemInfo_corpsMemberFuncInfoList_title;
		// 附加描述
	string _corpsMemInfo_corpsMemberFuncInfoList_desc = ReadString();	_corpsMemInfo_corpsMemberFuncInfoListTmp.desc = _corpsMemInfo_corpsMemberFuncInfoList_desc;
		// 功能类型ID
	int _corpsMemInfo_corpsMemberFuncInfoList_funcId = ReadInt();	_corpsMemInfo_corpsMemberFuncInfoListTmp.funcId = _corpsMemInfo_corpsMemberFuncInfoList_funcId;
		// 军团ID
	long _corpsMemInfo_corpsMemberFuncInfoList_memUUID = ReadLong();	_corpsMemInfo_corpsMemberFuncInfoListTmp.memUUID = _corpsMemInfo_corpsMemberFuncInfoList_memUUID;
		// 功能是否可用 1:可用，0：不可用
	int _corpsMemInfo_corpsMemberFuncInfoList_available = ReadInt();	_corpsMemInfo_corpsMemberFuncInfoListTmp.available = _corpsMemInfo_corpsMemberFuncInfoList_available;
		}
	//end
	_corpsMemInfo.corpsMemberFuncInfoList = _corpsMemInfo_corpsMemberFuncInfoList;

	// 军团名称
	string _corpsName = ReadString();


		this.corpsMemInfo = _corpsMemInfo;
		this.corpsName = _corpsName;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CORPS_MEMBER_INFO;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCCorpsMemberInfoEvent;
	}
	

	public CorpsMemberInfo getCorpsMemInfo(){
		return corpsMemInfo;
	}
		

	public string getCorpsName(){
		return corpsName;
	}
		

}
}