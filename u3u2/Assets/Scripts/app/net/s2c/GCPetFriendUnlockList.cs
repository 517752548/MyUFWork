
using System;
namespace app.net
{
/**
 * 伙伴解锁情况列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetFriendUnlockList :BaseMessage
{
	/** 伙伴解锁情况列表 */
	private PetFriendUnlockInfo[] petFriendUnlockInfoList;

	public GCPetFriendUnlockList ()
	{
	}

	protected override void ReadImpl()
	{

	// 伙伴解锁情况列表
	int petFriendUnlockInfoListSize = ReadShort();
	PetFriendUnlockInfo[] _petFriendUnlockInfoList = new PetFriendUnlockInfo[petFriendUnlockInfoListSize];
	int petFriendUnlockInfoListIndex = 0;
	PetFriendUnlockInfo _petFriendUnlockInfoListTmp = null;
	for(petFriendUnlockInfoListIndex=0; petFriendUnlockInfoListIndex<petFriendUnlockInfoListSize; petFriendUnlockInfoListIndex++){
		_petFriendUnlockInfoListTmp = new PetFriendUnlockInfo();
		_petFriendUnlockInfoList[petFriendUnlockInfoListIndex] = _petFriendUnlockInfoListTmp;
	// 伙伴模板Id
	int _petFriendUnlockInfoList_tplId = ReadInt();	_petFriendUnlockInfoListTmp.tplId = _petFriendUnlockInfoList_tplId;
		// 剩余的有效时间， -1表示永久有效，0已过期
	long _petFriendUnlockInfoList_leftTime = ReadLong();	_petFriendUnlockInfoListTmp.leftTime = _petFriendUnlockInfoList_leftTime;
		}
	//end



		this.petFriendUnlockInfoList = _petFriendUnlockInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_FRIEND_UNLOCK_LIST;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetFriendUnlockListEvent;
	}
	

	public PetFriendUnlockInfo[] getPetFriendUnlockInfoList(){
		return petFriendUnlockInfoList;
	}


}
}