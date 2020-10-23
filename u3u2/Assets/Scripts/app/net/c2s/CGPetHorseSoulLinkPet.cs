using System;
using System.IO;
namespace app.net
{

/**
 * 骑宠灵魂链接宠物
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetHorseSoulLinkPet :BaseMessage
{
	
	/** 骑宠Id */
	private long petHorseId;
	/** 宠物Id */
	private long[] petId;
	/** 1增加,0取消 */
	private int[] flag;
	
	public CGPetHorseSoulLinkPet ()
	{
	}
	
	public CGPetHorseSoulLinkPet (
			long petHorseId,
			long[] petId,
			int[] flag )
	{
			this.petHorseId = petHorseId;
			this.petId = petId;
			this.flag = flag;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 骑宠Id
	WriteLong(petHorseId);
	// 宠物Id
	WriteShort((short)petId.Length);
	int petIdSize = petId.Length;
	int petIdIndex = 0;
	for(petIdIndex=0; petIdIndex<petIdSize; petIdIndex++){
		WriteLong(petId [ petIdIndex ]);
	}//end
	
	// 1增加,0取消
	WriteShort((short)flag.Length);
	int flagSize = flag.Length;
	int flagIndex = 0;
	for(flagIndex=0; flagIndex<flagSize; flagIndex++){
		WriteInt(flag [ flagIndex ]);
	}//end
	

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PET_HORSE_SOUL_LINK_PET;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public long[] getPetId()
	{
		return petId;
	}

	public void setPetId(long[] petId)
	{
		this.petId = petId;
	}

	public int[] getFlag()
	{
		return flag;
	}

	public void setFlag(int[] flag)
	{
		this.flag = flag;
	}
	}
}