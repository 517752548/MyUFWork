
using System;
namespace app.net
{
/**
 * 返回平台玩家奖励列表和gm补偿列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPrizeList :BaseMessage
{
	/** 奖励列表 */
	private UserPrizeInfo[] userPrizes;

	public GCPrizeList ()
	{
	}

	protected override void ReadImpl()
	{

	// 奖励列表
	int userPrizesSize = ReadShort();
	UserPrizeInfo[] _userPrizes = new UserPrizeInfo[userPrizesSize];
	int userPrizesIndex = 0;
	UserPrizeInfo _userPrizesTmp = null;
	for(userPrizesIndex=0; userPrizesIndex<userPrizesSize; userPrizesIndex++){
		_userPrizesTmp = new UserPrizeInfo();
		_userPrizes[userPrizesIndex] = _userPrizesTmp;
	// 平台奖励唯一编号
	int _userPrizes_uniqueId = ReadInt();	_userPrizesTmp.uniqueId = _userPrizes_uniqueId;
		// 奖励ID
	string _userPrizes_prizeId = ReadString();	_userPrizesTmp.prizeId = _userPrizes_prizeId;
		// 奖励类型  1 平台奖励还是 2 gm奖励 
	int _userPrizes_prizeType = ReadInt();	_userPrizesTmp.prizeType = _userPrizes_prizeType;
		// 奖励名称
	string _userPrizes_prizeName = ReadString();	_userPrizesTmp.prizeName = _userPrizes_prizeName;
		// 失效时间
	long _userPrizes_expireTime = ReadLong();	_userPrizesTmp.expireTime = _userPrizes_expireTime;
		}
	//end



		this.userPrizes = _userPrizes;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PRIZE_LIST;
	}
	
	public override string getEventType()
	{
		return PrizeGCHandler.GCPrizeListEvent;
	}
	

	public UserPrizeInfo[] getUserPrizes(){
		return userPrizes;
	}


}
}