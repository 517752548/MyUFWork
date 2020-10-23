using System;
using System.IO;
namespace app.net
{

/**
 * 设置消费确认提示
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSetConsumeConfirm :BaseMessage
{
	
	/** 消费信息 */
	private ConsumeConfirmData[] consumeConfirmInfoList;
	
	public CGSetConsumeConfirm ()
	{
	}
	
	public CGSetConsumeConfirm (
			ConsumeConfirmData[] consumeConfirmInfoList )
	{
			this.consumeConfirmInfoList = consumeConfirmInfoList;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{

	// 消费信息
	WriteShort((short)consumeConfirmInfoList.Length);
	int consumeConfirmInfoListIndex = 0;
	int consumeConfirmInfoListSize = consumeConfirmInfoList.Length;
	for(consumeConfirmInfoListIndex=0; consumeConfirmInfoListIndex<consumeConfirmInfoListSize; consumeConfirmInfoListIndex++){

	int consumeConfirmInfoList_confirmType = consumeConfirmInfoList[consumeConfirmInfoListIndex].confirmType;
	// 提示类型
	WriteInt(consumeConfirmInfoList_confirmType);
	int consumeConfirmInfoList_isSelected = consumeConfirmInfoList[consumeConfirmInfoListIndex].isSelected;
	// 是否选中不提示框0 不选择 1选择
	WriteInt(consumeConfirmInfoList_isSelected);	}
	//end


	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SET_CONSUME_CONFIRM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public ConsumeConfirmData[] getConsumeConfirmInfoList()
	{
		return consumeConfirmInfoList;
	}

	public void setConsumeConfirmInfoList(ConsumeConfirmData[] consumeConfirmInfoList)
	{
		this.consumeConfirmInfoList = consumeConfirmInfoList;
	}
	}
}