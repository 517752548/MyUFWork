
using System;
namespace app.net
{
/**
 * 精彩活动更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGoodActivityUpdate :BaseMessage
{
	/** 功能id */
	private int funcId;
	/** 精彩活动信息 */
	private GoodActivityInfo goodActivityInfo;

	public GCGoodActivityUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 功能id
	int _funcId = ReadInt();
	// 精彩活动信息
	GoodActivityInfo _goodActivityInfo = new GoodActivityInfo();
	// 活动唯一Id
	long _goodActivityInfo_activityId = ReadLong();	_goodActivityInfo.activityId = _goodActivityInfo_activityId;
	// 活动类型Id
	int _goodActivityInfo_typeId = ReadInt();	_goodActivityInfo.typeId = _goodActivityInfo_typeId;
	// 活动图标
	int _goodActivityInfo_icon = ReadInt();	_goodActivityInfo.icon = _goodActivityInfo_icon;
	// 名称图标
	int _goodActivityInfo_nameIcon = ReadInt();	_goodActivityInfo.nameIcon = _goodActivityInfo_nameIcon;
	// 标题图标
	int _goodActivityInfo_titleIcon = ReadInt();	_goodActivityInfo.titleIcon = _goodActivityInfo_titleIcon;
	// 名称
	string _goodActivityInfo_name = ReadString();	_goodActivityInfo.name = _goodActivityInfo_name;
	// 描述 
	string _goodActivityInfo_desc = ReadString();	_goodActivityInfo.desc = _goodActivityInfo_desc;
	// 是否新活动，1新，0否
	int _goodActivityInfo_isNew = ReadInt();	_goodActivityInfo.isNew = _goodActivityInfo_isNew;
	// 活动开始时间
	long _goodActivityInfo_startTime = ReadLong();	_goodActivityInfo.startTime = _goodActivityInfo_startTime;
	// 活动结束时间
	long _goodActivityInfo_endTime = ReadLong();	_goodActivityInfo.endTime = _goodActivityInfo_endTime;
	// 是否有未领取的奖励，1是，0否
	int _goodActivityInfo_hasUnGotBonus = ReadInt();	_goodActivityInfo.hasUnGotBonus = _goodActivityInfo_hasUnGotBonus;
	// 倒计时描述
	string _goodActivityInfo_countDownTimeDesc = ReadString();	_goodActivityInfo.countDownTimeDesc = _goodActivityInfo_countDownTimeDesc;
	// 倒计时时间
	long _goodActivityInfo_countDownTime = ReadLong();	_goodActivityInfo.countDownTime = _goodActivityInfo_countDownTime;
	// 自身相关信息
	string _goodActivityInfo_selfInfo = ReadString();	_goodActivityInfo.selfInfo = _goodActivityInfo_selfInfo;
	// 活动目标json串
	string _goodActivityInfo_targetInfo = ReadString();	_goodActivityInfo.targetInfo = _goodActivityInfo_targetInfo;
	// 目标类型，前端显示用
	int _goodActivityInfo_showTargetType = ReadInt();	_goodActivityInfo.showTargetType = _goodActivityInfo_showTargetType;
	// 最近开启的
	int _goodActivityInfo_isRecentOpen = ReadInt();	_goodActivityInfo.isRecentOpen = _goodActivityInfo_isRecentOpen;
	// 最近结束的
	int _goodActivityInfo_isRecentClose = ReadInt();	_goodActivityInfo.isRecentClose = _goodActivityInfo_isRecentClose;
	// 日志列表 
	int goodActivityInfo_logListSize = ReadShort();
	string[] _goodActivityInfo_logList = new string[goodActivityInfo_logListSize];
	int goodActivityInfo_logListIndex = 0;
	for(goodActivityInfo_logListIndex=0; goodActivityInfo_logListIndex<goodActivityInfo_logListSize; goodActivityInfo_logListIndex++){
		_goodActivityInfo_logList[goodActivityInfo_logListIndex] = ReadString();
	}//end
		_goodActivityInfo.logList = _goodActivityInfo_logList;
	// 是否需要隐藏，0否，1是
	int _goodActivityInfo_needHide = ReadInt();	_goodActivityInfo.needHide = _goodActivityInfo_needHide;



		this.funcId = _funcId;
		this.goodActivityInfo = _goodActivityInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_GOOD_ACTIVITY_UPDATE;
	}
	
	public override string getEventType()
	{
		return GoodactivityGCHandler.GCGoodActivityUpdateEvent;
	}
	

	public int getFuncId(){
		return funcId;
	}
		

	public GoodActivityInfo getGoodActivityInfo(){
		return goodActivityInfo;
	}
		

}
}