using System;
using System.IO;
namespace app.net
{

/**
 * 升星装备位
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpUpstar :BaseMessage
{
	
	/** 装备位 */
	private int equipPosition;
	/** 是否使用物品提升概率，1使用，2不使用 */
	private int useExtraItem;
	
	public CGEqpUpstar ()
	{
	}
	
	public CGEqpUpstar (
			int equipPosition,
			int useExtraItem )
	{
			this.equipPosition = equipPosition;
			this.useExtraItem = useExtraItem;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 装备位
	WriteInt(equipPosition);
	// 是否使用物品提升概率，1使用，2不使用
	WriteInt(useExtraItem);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_EQP_UPSTAR;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}