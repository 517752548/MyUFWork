
using System;
namespace app.net
{
/**
 * 伙伴阵容列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetFriendArrayList :BaseMessage
{
	/** 当前使用的阵容索引，从0开始计数 */
	private int curArrayIndex;
	/** 伙伴阵容列表 */
	private PetFriendArrayInfo[] petFriendArrayInfoList;

	public GCPetFriendArrayList ()
	{
	}

	protected override void ReadImpl()
	{
	// 当前使用的阵容索引，从0开始计数
	int _curArrayIndex = ReadInt();

	// 伙伴阵容列表
	int petFriendArrayInfoListSize = ReadShort();
	PetFriendArrayInfo[] _petFriendArrayInfoList = new PetFriendArrayInfo[petFriendArrayInfoListSize];
	int petFriendArrayInfoListIndex = 0;
	PetFriendArrayInfo _petFriendArrayInfoListTmp = null;
	for(petFriendArrayInfoListIndex=0; petFriendArrayInfoListIndex<petFriendArrayInfoListSize; petFriendArrayInfoListIndex++){
		_petFriendArrayInfoListTmp = new PetFriendArrayInfo();
		_petFriendArrayInfoList[petFriendArrayInfoListIndex] = _petFriendArrayInfoListTmp;
	// 伙伴模板Id列表
	int petFriendArrayInfoList_tplIdListSize = ReadShort();
	int[] _petFriendArrayInfoList_tplIdList = new int[petFriendArrayInfoList_tplIdListSize];
	int petFriendArrayInfoList_tplIdListIndex = 0;
	for(petFriendArrayInfoList_tplIdListIndex=0; petFriendArrayInfoList_tplIdListIndex<petFriendArrayInfoList_tplIdListSize; petFriendArrayInfoList_tplIdListIndex++){
		_petFriendArrayInfoList_tplIdList[petFriendArrayInfoList_tplIdListIndex] = ReadInt();
	}//end
		_petFriendArrayInfoListTmp.tplIdList = _petFriendArrayInfoList_tplIdList;
		// 阵法等级
	int _petFriendArrayInfoList_arrLevel = ReadInt();	_petFriendArrayInfoListTmp.arrLevel = _petFriendArrayInfoList_arrLevel;
		// 阵法id
	int _petFriendArrayInfoList_arrId = ReadInt();	_petFriendArrayInfoListTmp.arrId = _petFriendArrayInfoList_arrId;
		}
	//end



		this.curArrayIndex = _curArrayIndex;
		this.petFriendArrayInfoList = _petFriendArrayInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_FRIEND_ARRAY_LIST;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetFriendArrayListEvent;
	}
	

	public int getCurArrayIndex(){
		return curArrayIndex;
	}
		

	public PetFriendArrayInfo[] getPetFriendArrayInfoList(){
		return petFriendArrayInfoList;
	}


}
}