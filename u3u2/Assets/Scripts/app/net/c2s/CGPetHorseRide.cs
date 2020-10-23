using System;
using System.IO;
namespace app.net
{

/**
 * 骑宠出战or休息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseRide :BaseMessage
{
	
	/** 武将唯一Id */
	private long petId;
	/** 出战状态，0休息，1出战 */
	private int state;
	
	public CGPetHorseRide ()
	{
	}
	
	public CGPetHorseRide (
			long petId,
			int state )
	{
			this.petId = petId;
			this.state = state;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 武将唯一Id
	WriteLong(petId);
	// 出战状态，0休息，1出战
	WriteInt(state);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_HORSE_RIDE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}