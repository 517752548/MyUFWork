
using System;
namespace app.net
{
/**
 * 军团列表面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsListPanel :BaseMessage
{
	/** 当前页数 */
	private int currPage;
	/** 总数页数 */
	private int maxPageNum;
	/** 军团信息列表 */
	private SimpleCorpsInfo[] simpleCorpsInfos;
	/** 军团列表功能列表 */
	private CorpsFuncInfo[] corpsListPanelFuncInfoList;

	public GCCorpsListPanel ()
	{
	}

	protected override void ReadImpl()
	{
	// 当前页数
	int _currPage = ReadInt();
	// 总数页数
	int _maxPageNum = ReadInt();

	// 军团信息列表
	int simpleCorpsInfosSize = ReadShort();
	SimpleCorpsInfo[] _simpleCorpsInfos = new SimpleCorpsInfo[simpleCorpsInfosSize];
	int simpleCorpsInfosIndex = 0;
	SimpleCorpsInfo _simpleCorpsInfosTmp = null;
	for(simpleCorpsInfosIndex=0; simpleCorpsInfosIndex<simpleCorpsInfosSize; simpleCorpsInfosIndex++){
		_simpleCorpsInfosTmp = new SimpleCorpsInfo();
		_simpleCorpsInfos[simpleCorpsInfosIndex] = _simpleCorpsInfosTmp;
	// 军团ID
	long _simpleCorpsInfos_corpsId = ReadLong();	_simpleCorpsInfosTmp.corpsId = _simpleCorpsInfos_corpsId;
		// 军团名称
	string _simpleCorpsInfos_name = ReadString();	_simpleCorpsInfosTmp.name = _simpleCorpsInfos_name;
		// 军团级别
	int _simpleCorpsInfos_level = ReadInt();	_simpleCorpsInfosTmp.level = _simpleCorpsInfos_level;
		// 团长名称
	string _simpleCorpsInfos_presidentName = ReadString();	_simpleCorpsInfosTmp.presidentName = _simpleCorpsInfos_presidentName;
		// 团长ID
	long _simpleCorpsInfos_presidentId = ReadLong();	_simpleCorpsInfosTmp.presidentId = _simpleCorpsInfos_presidentId;
		// 团长模板Id
	int _simpleCorpsInfos_presidentTplId = ReadInt();	_simpleCorpsInfosTmp.presidentTplId = _simpleCorpsInfos_presidentTplId;
		// 团长等级
	int _simpleCorpsInfos_presidentLevel = ReadInt();	_simpleCorpsInfosTmp.presidentLevel = _simpleCorpsInfos_presidentLevel;
		// 当前成员数量
	int _simpleCorpsInfos_currMemNum = ReadInt();	_simpleCorpsInfosTmp.currMemNum = _simpleCorpsInfos_currMemNum;
		// 最大成员数量
	int _simpleCorpsInfos_maxMemNum = ReadInt();	_simpleCorpsInfosTmp.maxMemNum = _simpleCorpsInfos_maxMemNum;
		// 所属国家
	int _simpleCorpsInfos_country = ReadInt();	_simpleCorpsInfosTmp.country = _simpleCorpsInfos_country;
		// 军团QQ
	string _simpleCorpsInfos_qq = ReadString();	_simpleCorpsInfosTmp.qq = _simpleCorpsInfos_qq;
		// 公告
	string _simpleCorpsInfos_notice = ReadString();	_simpleCorpsInfosTmp.notice = _simpleCorpsInfos_notice;
		// 军团排名
	int _simpleCorpsInfos_rank = ReadInt();	_simpleCorpsInfosTmp.rank = _simpleCorpsInfos_rank;
		// 是否已经申请 1是 0否
	int _simpleCorpsInfos_isApplied = ReadInt();	_simpleCorpsInfosTmp.isApplied = _simpleCorpsInfos_isApplied;
	
	// 军团功能列表
	int simpleCorpsInfos_corpsFuncInfoListSize = ReadShort();
	CorpsFuncInfo[] _simpleCorpsInfos_corpsFuncInfoList = new CorpsFuncInfo[simpleCorpsInfos_corpsFuncInfoListSize];
	int simpleCorpsInfos_corpsFuncInfoListIndex = 0;
	CorpsFuncInfo _simpleCorpsInfos_corpsFuncInfoListTmp = null;
	for(simpleCorpsInfos_corpsFuncInfoListIndex=0; simpleCorpsInfos_corpsFuncInfoListIndex<simpleCorpsInfos_corpsFuncInfoListSize; simpleCorpsInfos_corpsFuncInfoListIndex++){
		_simpleCorpsInfos_corpsFuncInfoListTmp = new CorpsFuncInfo();
		_simpleCorpsInfos_corpsFuncInfoList[simpleCorpsInfos_corpsFuncInfoListIndex] = _simpleCorpsInfos_corpsFuncInfoListTmp;
	// 功能标题
	string _simpleCorpsInfos_corpsFuncInfoList_title = ReadString();	_simpleCorpsInfos_corpsFuncInfoListTmp.title = _simpleCorpsInfos_corpsFuncInfoList_title;
		// 附加描述
	string _simpleCorpsInfos_corpsFuncInfoList_desc = ReadString();	_simpleCorpsInfos_corpsFuncInfoListTmp.desc = _simpleCorpsInfos_corpsFuncInfoList_desc;
		// 功能类型ID
	int _simpleCorpsInfos_corpsFuncInfoList_funcId = ReadInt();	_simpleCorpsInfos_corpsFuncInfoListTmp.funcId = _simpleCorpsInfos_corpsFuncInfoList_funcId;
		// 军团ID
	long _simpleCorpsInfos_corpsFuncInfoList_corpsUUID = ReadLong();	_simpleCorpsInfos_corpsFuncInfoListTmp.corpsUUID = _simpleCorpsInfos_corpsFuncInfoList_corpsUUID;
		// 功能是否可用 1:可用，0：不可用
	int _simpleCorpsInfos_corpsFuncInfoList_available = ReadInt();	_simpleCorpsInfos_corpsFuncInfoListTmp.available = _simpleCorpsInfos_corpsFuncInfoList_available;
		}
	//end
	_simpleCorpsInfosTmp.corpsFuncInfoList = _simpleCorpsInfos_corpsFuncInfoList;
		}
	//end


	// 军团列表功能列表
	int corpsListPanelFuncInfoListSize = ReadShort();
	CorpsFuncInfo[] _corpsListPanelFuncInfoList = new CorpsFuncInfo[corpsListPanelFuncInfoListSize];
	int corpsListPanelFuncInfoListIndex = 0;
	CorpsFuncInfo _corpsListPanelFuncInfoListTmp = null;
	for(corpsListPanelFuncInfoListIndex=0; corpsListPanelFuncInfoListIndex<corpsListPanelFuncInfoListSize; corpsListPanelFuncInfoListIndex++){
		_corpsListPanelFuncInfoListTmp = new CorpsFuncInfo();
		_corpsListPanelFuncInfoList[corpsListPanelFuncInfoListIndex] = _corpsListPanelFuncInfoListTmp;
	// 功能标题
	string _corpsListPanelFuncInfoList_title = ReadString();	_corpsListPanelFuncInfoListTmp.title = _corpsListPanelFuncInfoList_title;
		// 附加描述
	string _corpsListPanelFuncInfoList_desc = ReadString();	_corpsListPanelFuncInfoListTmp.desc = _corpsListPanelFuncInfoList_desc;
		// 功能类型ID
	int _corpsListPanelFuncInfoList_funcId = ReadInt();	_corpsListPanelFuncInfoListTmp.funcId = _corpsListPanelFuncInfoList_funcId;
		// 军团ID
	long _corpsListPanelFuncInfoList_corpsUUID = ReadLong();	_corpsListPanelFuncInfoListTmp.corpsUUID = _corpsListPanelFuncInfoList_corpsUUID;
		// 功能是否可用 1:可用，0：不可用
	int _corpsListPanelFuncInfoList_available = ReadInt();	_corpsListPanelFuncInfoListTmp.available = _corpsListPanelFuncInfoList_available;
		}
	//end



		this.currPage = _currPage;
		this.maxPageNum = _maxPageNum;
		this.simpleCorpsInfos = _simpleCorpsInfos;
		this.corpsListPanelFuncInfoList = _corpsListPanelFuncInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CORPS_LIST_PANEL;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCCorpsListPanelEvent;
	}
	

	public int getCurrPage(){
		return currPage;
	}
		

	public int getMaxPageNum(){
		return maxPageNum;
	}
		

	public SimpleCorpsInfo[] getSimpleCorpsInfos(){
		return simpleCorpsInfos;
	}


	public CorpsFuncInfo[] getCorpsListPanelFuncInfoList(){
		return corpsListPanelFuncInfoList;
	}


}
}