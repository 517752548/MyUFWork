
using System;
namespace app.net
{
/**
 * 骑宠灵魂链接宠物
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorseSoulLinkPet :BaseMessage
{
	/** 宠物灵魂链接信息 */
	private PetSoulLinkInfo[] petSoulLinkInfoList;

	public GCPetHorseSoulLinkPet ()
	{
	}

	protected override void ReadImpl()
	{

	// 宠物灵魂链接信息
	int petSoulLinkInfoListSize = ReadShort();
	PetSoulLinkInfo[] _petSoulLinkInfoList = new PetSoulLinkInfo[petSoulLinkInfoListSize];
	int petSoulLinkInfoListIndex = 0;
	PetSoulLinkInfo _petSoulLinkInfoListTmp = null;
	for(petSoulLinkInfoListIndex=0; petSoulLinkInfoListIndex<petSoulLinkInfoListSize; petSoulLinkInfoListIndex++){
		_petSoulLinkInfoListTmp = new PetSoulLinkInfo();
		_petSoulLinkInfoList[petSoulLinkInfoListIndex] = _petSoulLinkInfoListTmp;
	// petId
	long _petSoulLinkInfoList_petId = ReadLong();	_petSoulLinkInfoListTmp.petId = _petSoulLinkInfoList_petId;
		// 灵魂链接骑宠ID, 0-无灵魂链接
	long _petSoulLinkInfoList_soulLinkPetHorseId = ReadLong();	_petSoulLinkInfoListTmp.soulLinkPetHorseId = _petSoulLinkInfoList_soulLinkPetHorseId;
		}
	//end



		this.petSoulLinkInfoList = _petSoulLinkInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_HORSE_SOUL_LINK_PET;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetHorseSoulLinkPetEvent;
	}
	

	public PetSoulLinkInfo[] getPetSoulLinkInfoList(){
		return petSoulLinkInfoList;
	}


}
}