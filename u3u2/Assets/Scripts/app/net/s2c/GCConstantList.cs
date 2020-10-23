
using System;
namespace app.net
{
/**
 * 常量列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCConstantList :BaseMessage
{
	/** 常量信息 */
	private ConstantInfo[] constantInfoList;

	public GCConstantList ()
	{
	}

	protected override void ReadImpl()
	{

	// 常量信息
	int constantInfoListSize = ReadShort();
	ConstantInfo[] _constantInfoList = new ConstantInfo[constantInfoListSize];
	int constantInfoListIndex = 0;
	ConstantInfo _constantInfoListTmp = null;
	for(constantInfoListIndex=0; constantInfoListIndex<constantInfoListSize; constantInfoListIndex++){
		_constantInfoListTmp = new ConstantInfo();
		_constantInfoList[constantInfoListIndex] = _constantInfoListTmp;
	// 常量的键
	string _constantInfoList_key = ReadString();	_constantInfoListTmp.key = _constantInfoList_key;
		// 常量的值
	string _constantInfoList_value = ReadString();	_constantInfoListTmp.value = _constantInfoList_value;
		}
	//end



		this.constantInfoList = _constantInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_CONSTANT_LIST;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCConstantListEvent;
	}
	

	public ConstantInfo[] getConstantInfoList(){
		return constantInfoList;
	}


}
}