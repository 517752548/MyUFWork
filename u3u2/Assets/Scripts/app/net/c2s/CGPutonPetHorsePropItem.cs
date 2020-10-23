using System;
using System.IO;
namespace app.net
{

/**
 * 设置骑宠资质丹
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPutonPetHorsePropItem :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	/** 6强壮,7敏捷,8智力,9信仰,10耐力 */
	private int targetIndex;
	/** 资质丹索引 */
	private int propItemIndex;
	
	public CGPutonPetHorsePropItem ()
	{
	}
	
	public CGPutonPetHorsePropItem (
			long petId,
			int targetIndex,
			int propItemIndex )
	{
			this.petId = petId;
			this.targetIndex = targetIndex;
			this.propItemIndex = propItemIndex;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 武将唯一Id
	WriteLong(petId);
	// 6强壮,7敏捷,8智力,9信仰,10耐力
	WriteInt(targetIndex);
	// 资质丹索引
	WriteInt(propItemIndex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PUTON_PET_HORSE_PROP_ITEM;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}