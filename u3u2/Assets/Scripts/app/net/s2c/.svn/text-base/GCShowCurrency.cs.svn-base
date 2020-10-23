
using System;
namespace app.net
{
/**
 * 货币显示配置
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCShowCurrency :BaseMessage
{
	/** 显示货币信息 */
	private ShowCurrencyInfo[] showCurrencyInfoList;

	public GCShowCurrency ()
	{
	}

	protected override void ReadImpl()
	{

	// 显示货币信息
	int showCurrencyInfoListSize = ReadShort();
	ShowCurrencyInfo[] _showCurrencyInfoList = new ShowCurrencyInfo[showCurrencyInfoListSize];
	int showCurrencyInfoListIndex = 0;
	ShowCurrencyInfo _showCurrencyInfoListTmp = null;
	for(showCurrencyInfoListIndex=0; showCurrencyInfoListIndex<showCurrencyInfoListSize; showCurrencyInfoListIndex++){
		_showCurrencyInfoListTmp = new ShowCurrencyInfo();
		_showCurrencyInfoList[showCurrencyInfoListIndex] = _showCurrencyInfoListTmp;
	// 类型
	int _showCurrencyInfoList_showType = ReadInt();	_showCurrencyInfoListTmp.showType = _showCurrencyInfoList_showType;
		// 类别名称
	string _showCurrencyInfoList_typeName = ReadString();	_showCurrencyInfoListTmp.typeName = _showCurrencyInfoList_typeName;
		// 名称
	string _showCurrencyInfoList_name = ReadString();	_showCurrencyInfoListTmp.name = _showCurrencyInfoList_name;
		// 描述
	string _showCurrencyInfoList_desc = ReadString();	_showCurrencyInfoListTmp.desc = _showCurrencyInfoList_desc;
		// 图标
	int _showCurrencyInfoList_icon = ReadInt();	_showCurrencyInfoListTmp.icon = _showCurrencyInfoList_icon;
		// 最小值
	long _showCurrencyInfoList_min = ReadLong();	_showCurrencyInfoListTmp.min = _showCurrencyInfoList_min;
		// 最大值
	long _showCurrencyInfoList_max = ReadLong();	_showCurrencyInfoListTmp.max = _showCurrencyInfoList_max;
		}
	//end



		this.showCurrencyInfoList = _showCurrencyInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SHOW_CURRENCY;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCShowCurrencyEvent;
	}
	

	public ShowCurrencyInfo[] getShowCurrencyInfoList(){
		return showCurrencyInfoList;
	}


}
}