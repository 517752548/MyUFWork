
using System;
namespace app.net
{
/**
 * 功能按钮更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFuncUpdate :BaseMessage
{
	/** 功能按钮 */
	private FuncShowInfo funcInfo;

	public GCFuncUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 功能按钮
	FuncShowInfo _funcInfo = new FuncShowInfo();
	// 功能按钮类型
	int _funcInfo_funcType = ReadInt();	_funcInfo.funcType = _funcInfo_funcType;
	// 1开启，0关闭
	int _funcInfo_isOpened = ReadInt();	_funcInfo.isOpened = _funcInfo_isOpened;
	// 所属功能
	int _funcInfo_ownerFuncType = ReadInt();	_funcInfo.ownerFuncType = _funcInfo_ownerFuncType;
	// 特效
	int _funcInfo_effect = ReadInt();	_funcInfo.effect = _funcInfo_effect;
	// 名称
	string _funcInfo_name = ReadString();	_funcInfo.name = _funcInfo_name;
	// 描述
	string _funcInfo_desc = ReadString();	_funcInfo.desc = _funcInfo_desc;
	// 数字角标，没有则为0
	int _funcInfo_showNum = ReadInt();	_funcInfo.showNum = _funcInfo_showNum;
	// 倒计时，没有则为0
	long _funcInfo_countDownTime = ReadLong();	_funcInfo.countDownTime = _funcInfo_countDownTime;
	// 按钮位置
	int _funcInfo_position = ReadInt();	_funcInfo.position = _funcInfo_position;
	// 顺序
	int _funcInfo_order = ReadInt();	_funcInfo.order = _funcInfo_order;
	// 是否首次开启，0否，1是
	int _funcInfo_isFirstOpen = ReadInt();	_funcInfo.isFirstOpen = _funcInfo_isFirstOpen;
	// 总CD时间
	long _funcInfo_totalCountDownTime = ReadLong();	_funcInfo.totalCountDownTime = _funcInfo_totalCountDownTime;
	// 图片ID
	string _funcInfo_icon = ReadString();	_funcInfo.icon = _funcInfo_icon;
	// 按钮描述
	string _funcInfo_menuDesc = ReadString();	_funcInfo.menuDesc = _funcInfo_menuDesc;
	// 组ID
	int _funcInfo_groupID = ReadInt();	_funcInfo.groupID = _funcInfo_groupID;



		this.funcInfo = _funcInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_FUNC_UPDATE;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCFuncUpdateEvent;
	}
	

	public FuncShowInfo getFuncInfo(){
		return funcInfo;
	}
		

}
}