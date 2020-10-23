
using System;
namespace app.net
{
/**
 * 打开精彩活动列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGoodActivityList :BaseMessage
{
	/** 功能id */
	private int funcId;
	/** 精彩活动信息列表 */
	private GoodActivityInfo[] goodActivityList;

	public GCGoodActivityList ()
	{
	}

	protected override void ReadImpl()
	{
	// 功能id
	int _funcId = ReadInt();

	// 精彩活动信息列表
	int goodActivityListSize = ReadShort();
	GoodActivityInfo[] _goodActivityList = new GoodActivityInfo[goodActivityListSize];
	int goodActivityListIndex = 0;
	GoodActivityInfo _goodActivityListTmp = null;
	for(goodActivityListIndex=0; goodActivityListIndex<goodActivityListSize; goodActivityListIndex++){
		_goodActivityListTmp = new GoodActivityInfo();
		_goodActivityList[goodActivityListIndex] = _goodActivityListTmp;
	// 活动唯一Id
	long _goodActivityList_activityId = ReadLong();	_goodActivityListTmp.activityId = _goodActivityList_activityId;
		// 活动类型Id
	int _goodActivityList_typeId = ReadInt();	_goodActivityListTmp.typeId = _goodActivityList_typeId;
		// 活动图标
	int _goodActivityList_icon = ReadInt();	_goodActivityListTmp.icon = _goodActivityList_icon;
		// 名称图标
	int _goodActivityList_nameIcon = ReadInt();	_goodActivityListTmp.nameIcon = _goodActivityList_nameIcon;
		// 标题图标
	int _goodActivityList_titleIcon = ReadInt();	_goodActivityListTmp.titleIcon = _goodActivityList_titleIcon;
		// 名称
	string _goodActivityList_name = ReadString();	_goodActivityListTmp.name = _goodActivityList_name;
		// 描述 
	string _goodActivityList_desc = ReadString();	_goodActivityListTmp.desc = _goodActivityList_desc;
		// 是否新活动，1新，0否
	int _goodActivityList_isNew = ReadInt();	_goodActivityListTmp.isNew = _goodActivityList_isNew;
		// 活动开始时间
	long _goodActivityList_startTime = ReadLong();	_goodActivityListTmp.startTime = _goodActivityList_startTime;
		// 活动结束时间
	long _goodActivityList_endTime = ReadLong();	_goodActivityListTmp.endTime = _goodActivityList_endTime;
		// 是否有未领取的奖励，1是，0否
	int _goodActivityList_hasUnGotBonus = ReadInt();	_goodActivityListTmp.hasUnGotBonus = _goodActivityList_hasUnGotBonus;
		// 倒计时描述
	string _goodActivityList_countDownTimeDesc = ReadString();	_goodActivityListTmp.countDownTimeDesc = _goodActivityList_countDownTimeDesc;
		// 倒计时时间
	long _goodActivityList_countDownTime = ReadLong();	_goodActivityListTmp.countDownTime = _goodActivityList_countDownTime;
		// 自身相关信息
	string _goodActivityList_selfInfo = ReadString();	_goodActivityListTmp.selfInfo = _goodActivityList_selfInfo;
		// 活动目标json串
	string _goodActivityList_targetInfo = ReadString();	_goodActivityListTmp.targetInfo = _goodActivityList_targetInfo;
		// 目标类型，前端显示用
	int _goodActivityList_showTargetType = ReadInt();	_goodActivityListTmp.showTargetType = _goodActivityList_showTargetType;
		// 最近开启的
	int _goodActivityList_isRecentOpen = ReadInt();	_goodActivityListTmp.isRecentOpen = _goodActivityList_isRecentOpen;
		// 最近结束的
	int _goodActivityList_isRecentClose = ReadInt();	_goodActivityListTmp.isRecentClose = _goodActivityList_isRecentClose;
		// 日志列表 
	int goodActivityList_logListSize = ReadShort();
	string[] _goodActivityList_logList = new string[goodActivityList_logListSize];
	int goodActivityList_logListIndex = 0;
	for(goodActivityList_logListIndex=0; goodActivityList_logListIndex<goodActivityList_logListSize; goodActivityList_logListIndex++){
		_goodActivityList_logList[goodActivityList_logListIndex] = ReadString();
	}//end
		_goodActivityListTmp.logList = _goodActivityList_logList;
		// 是否需要隐藏，0否，1是
	int _goodActivityList_needHide = ReadInt();	_goodActivityListTmp.needHide = _goodActivityList_needHide;
		}
	//end



		this.funcId = _funcId;
		this.goodActivityList = _goodActivityList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_GOOD_ACTIVITY_LIST;
	}
	
	public override string getEventType()
	{
		return GoodactivityGCHandler.GCGoodActivityListEvent;
	}
	

	public int getFuncId(){
		return funcId;
	}
		

	public GoodActivityInfo[] getGoodActivityList(){
		return goodActivityList;
	}


}
}