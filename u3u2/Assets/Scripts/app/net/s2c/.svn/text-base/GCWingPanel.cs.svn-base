
using System;
namespace app.net
{
/**
 * 返回翅膀列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWingPanel :BaseMessage
{
	/** 翅膀信息页面 */
	private WingInfo[] wingList;

	public GCWingPanel ()
	{
	}

	protected override void ReadImpl()
	{

	// 翅膀信息页面
	int wingListSize = ReadShort();
	WingInfo[] _wingList = new WingInfo[wingListSize];
	int wingListIndex = 0;
	WingInfo _wingListTmp = null;
	for(wingListIndex=0; wingListIndex<wingListSize; wingListIndex++){
		_wingListTmp = new WingInfo();
		_wingList[wingListIndex] = _wingListTmp;
	// 翅膀类型id
	int _wingList_templateId = ReadInt();	_wingListTmp.templateId = _wingList_templateId;
		// 是否已装备
	int _wingList_isEquip = ReadInt();	_wingListTmp.isEquip = _wingList_isEquip;
		// 翅膀阶数
	int _wingList_wingLevel = ReadInt();	_wingListTmp.wingLevel = _wingList_wingLevel;
		// 翅膀祝福值
	int _wingList_wingBless = ReadInt();	_wingListTmp.wingBless = _wingList_wingBless;
		// 翅膀战斗力
	int _wingList_wingPower = ReadInt();	_wingListTmp.wingPower = _wingList_wingPower;
		}
	//end



		this.wingList = _wingList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_WING_PANEL;
	}
	
	public override string getEventType()
	{
		return WingGCHandler.GCWingPanelEvent;
	}
	

	public WingInfo[] getWingList(){
		return wingList;
	}


}
}