using System;
using System.IO;
namespace app.net
{

/**
 * 骑宠改名
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseChangeName :BaseMessage
{
	
	/** 骑宠唯一Id */
	private long petId;
	/** 名字 */
	private string newName;
	
	public CGPetHorseChangeName ()
	{
	}
	
	public CGPetHorseChangeName (
			long petId,
			string newName )
	{
			this.petId = petId;
			this.newName = newName;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 骑宠唯一Id
	WriteLong(petId);
	// 名字
	WriteString(newName);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_HORSE_CHANGE_NAME;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}