
using System;
namespace app.net
{
/**
 * 功能按钮列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCFuncList :BaseMessage
{
	/** 功能按钮列表 */
	private FuncShowInfo[] funcInfoList;

	public GCFuncList ()
	{
	}

	protected override void ReadImpl()
	{

	// 功能按钮列表
	int funcInfoListSize = ReadShort();
	FuncShowInfo[] _funcInfoList = new FuncShowInfo[funcInfoListSize];
	int funcInfoListIndex = 0;
	FuncShowInfo _funcInfoListTmp = null;
	for(funcInfoListIndex=0; funcInfoListIndex<funcInfoListSize; funcInfoListIndex++){
		_funcInfoListTmp = new FuncShowInfo();
		_funcInfoList[funcInfoListIndex] = _funcInfoListTmp;
	// 功能按钮类型
	int _funcInfoList_funcType = ReadInt();	_funcInfoListTmp.funcType = _funcInfoList_funcType;
		// 1开启，0关闭
	int _funcInfoList_isOpened = ReadInt();	_funcInfoListTmp.isOpened = _funcInfoList_isOpened;
		// 所属功能
	int _funcInfoList_ownerFuncType = ReadInt();	_funcInfoListTmp.ownerFuncType = _funcInfoList_ownerFuncType;
		// 特效
	int _funcInfoList_effect = ReadInt();	_funcInfoListTmp.effect = _funcInfoList_effect;
		// 名称
	string _funcInfoList_name = ReadString();	_funcInfoListTmp.name = _funcInfoList_name;
		// 描述
	string _funcInfoList_desc = ReadString();	_funcInfoListTmp.desc = _funcInfoList_desc;
		// 数字角标，没有则为0
	int _funcInfoList_showNum = ReadInt();	_funcInfoListTmp.showNum = _funcInfoList_showNum;
		// 倒计时，没有则为0
	long _funcInfoList_countDownTime = ReadLong();	_funcInfoListTmp.countDownTime = _funcInfoList_countDownTime;
		// 按钮位置
	int _funcInfoList_position = ReadInt();	_funcInfoListTmp.position = _funcInfoList_position;
		// 顺序
	int _funcInfoList_order = ReadInt();	_funcInfoListTmp.order = _funcInfoList_order;
		// 是否首次开启，0否，1是
	int _funcInfoList_isFirstOpen = ReadInt();	_funcInfoListTmp.isFirstOpen = _funcInfoList_isFirstOpen;
		// 总CD时间
	long _funcInfoList_totalCountDownTime = ReadLong();	_funcInfoListTmp.totalCountDownTime = _funcInfoList_totalCountDownTime;
		// 图片ID
	string _funcInfoList_icon = ReadString();	_funcInfoListTmp.icon = _funcInfoList_icon;
		// 按钮描述
	string _funcInfoList_menuDesc = ReadString();	_funcInfoListTmp.menuDesc = _funcInfoList_menuDesc;
		// 组ID
	int _funcInfoList_groupID = ReadInt();	_funcInfoListTmp.groupID = _funcInfoList_groupID;
		}
	//end



		this.funcInfoList = _funcInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_FUNC_LIST;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCFuncListEvent;
	}
	

	public FuncShowInfo[] getFuncInfoList(){
		return funcInfoList;
	}


	public override bool isCompress() {
		return true;
	}
}
}