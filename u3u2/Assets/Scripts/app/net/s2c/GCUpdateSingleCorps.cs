
using System;
namespace app.net
{
/**
 * 更新单条军团信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUpdateSingleCorps :BaseMessage
{
	/** 军团信息 */
	private SimpleCorpsInfo simpleCorpsInfo;

	public GCUpdateSingleCorps ()
	{
	}

	protected override void ReadImpl()
	{
	// 军团信息
	SimpleCorpsInfo _simpleCorpsInfo = new SimpleCorpsInfo();
	// 军团ID
	long _simpleCorpsInfo_corpsId = ReadLong();	_simpleCorpsInfo.corpsId = _simpleCorpsInfo_corpsId;
	// 军团名称
	string _simpleCorpsInfo_name = ReadString();	_simpleCorpsInfo.name = _simpleCorpsInfo_name;
	// 军团级别
	int _simpleCorpsInfo_level = ReadInt();	_simpleCorpsInfo.level = _simpleCorpsInfo_level;
	// 团长名称
	string _simpleCorpsInfo_presidentName = ReadString();	_simpleCorpsInfo.presidentName = _simpleCorpsInfo_presidentName;
	// 团长ID
	long _simpleCorpsInfo_presidentId = ReadLong();	_simpleCorpsInfo.presidentId = _simpleCorpsInfo_presidentId;
	// 团长模板Id
	int _simpleCorpsInfo_presidentTplId = ReadInt();	_simpleCorpsInfo.presidentTplId = _simpleCorpsInfo_presidentTplId;
	// 团长等级
	int _simpleCorpsInfo_presidentLevel = ReadInt();	_simpleCorpsInfo.presidentLevel = _simpleCorpsInfo_presidentLevel;
	// 当前成员数量
	int _simpleCorpsInfo_currMemNum = ReadInt();	_simpleCorpsInfo.currMemNum = _simpleCorpsInfo_currMemNum;
	// 最大成员数量
	int _simpleCorpsInfo_maxMemNum = ReadInt();	_simpleCorpsInfo.maxMemNum = _simpleCorpsInfo_maxMemNum;
	// 所属国家
	int _simpleCorpsInfo_country = ReadInt();	_simpleCorpsInfo.country = _simpleCorpsInfo_country;
	// 军团QQ
	string _simpleCorpsInfo_qq = ReadString();	_simpleCorpsInfo.qq = _simpleCorpsInfo_qq;
	// 公告
	string _simpleCorpsInfo_notice = ReadString();	_simpleCorpsInfo.notice = _simpleCorpsInfo_notice;
	// 军团排名
	int _simpleCorpsInfo_rank = ReadInt();	_simpleCorpsInfo.rank = _simpleCorpsInfo_rank;
	// 是否已经申请 1是 0否
	int _simpleCorpsInfo_isApplied = ReadInt();	_simpleCorpsInfo.isApplied = _simpleCorpsInfo_isApplied;

	// 军团功能列表
	int simpleCorpsInfo_corpsFuncInfoListSize = ReadShort();
	CorpsFuncInfo[] _simpleCorpsInfo_corpsFuncInfoList = new CorpsFuncInfo[simpleCorpsInfo_corpsFuncInfoListSize];
	int simpleCorpsInfo_corpsFuncInfoListIndex = 0;
	CorpsFuncInfo _simpleCorpsInfo_corpsFuncInfoListTmp = null;
	for(simpleCorpsInfo_corpsFuncInfoListIndex=0; simpleCorpsInfo_corpsFuncInfoListIndex<simpleCorpsInfo_corpsFuncInfoListSize; simpleCorpsInfo_corpsFuncInfoListIndex++){
		_simpleCorpsInfo_corpsFuncInfoListTmp = new CorpsFuncInfo();
		_simpleCorpsInfo_corpsFuncInfoList[simpleCorpsInfo_corpsFuncInfoListIndex] = _simpleCorpsInfo_corpsFuncInfoListTmp;
	// 功能标题
	string _simpleCorpsInfo_corpsFuncInfoList_title = ReadString();	_simpleCorpsInfo_corpsFuncInfoListTmp.title = _simpleCorpsInfo_corpsFuncInfoList_title;
		// 附加描述
	string _simpleCorpsInfo_corpsFuncInfoList_desc = ReadString();	_simpleCorpsInfo_corpsFuncInfoListTmp.desc = _simpleCorpsInfo_corpsFuncInfoList_desc;
		// 功能类型ID
	int _simpleCorpsInfo_corpsFuncInfoList_funcId = ReadInt();	_simpleCorpsInfo_corpsFuncInfoListTmp.funcId = _simpleCorpsInfo_corpsFuncInfoList_funcId;
		// 军团ID
	long _simpleCorpsInfo_corpsFuncInfoList_corpsUUID = ReadLong();	_simpleCorpsInfo_corpsFuncInfoListTmp.corpsUUID = _simpleCorpsInfo_corpsFuncInfoList_corpsUUID;
		// 功能是否可用 1:可用，0：不可用
	int _simpleCorpsInfo_corpsFuncInfoList_available = ReadInt();	_simpleCorpsInfo_corpsFuncInfoListTmp.available = _simpleCorpsInfo_corpsFuncInfoList_available;
		}
	//end
	_simpleCorpsInfo.corpsFuncInfoList = _simpleCorpsInfo_corpsFuncInfoList;



		this.simpleCorpsInfo = _simpleCorpsInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_UPDATE_SINGLE_CORPS;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCUpdateSingleCorpsEvent;
	}
	

	public SimpleCorpsInfo getSimpleCorpsInfo(){
		return simpleCorpsInfo;
	}
		

}
}