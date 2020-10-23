package com.imop.lj.gameserver.prize.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回平台玩家奖励列表和gm补偿列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPrizeList extends GCMessage{
	
	/** 奖励列表 */
	private com.imop.lj.gameserver.prize.UserPrizeInfo[] userPrizes;

	public GCPrizeList (){
	}
	
	public GCPrizeList (
			com.imop.lj.gameserver.prize.UserPrizeInfo[] userPrizes ){
			this.userPrizes = userPrizes;
	}

	@Override
	protected boolean readImpl() {

	// 奖励列表
	int userPrizesSize = readUnsignedShort();
	com.imop.lj.gameserver.prize.UserPrizeInfo[] _userPrizes = new com.imop.lj.gameserver.prize.UserPrizeInfo[userPrizesSize];
	int userPrizesIndex = 0;
	for(userPrizesIndex=0; userPrizesIndex<userPrizesSize; userPrizesIndex++){
		_userPrizes[userPrizesIndex] = new com.imop.lj.gameserver.prize.UserPrizeInfo();
	// 平台奖励唯一编号
	int _userPrizes_uniqueId = readInteger();
	//end
	_userPrizes[userPrizesIndex].setUniqueId (_userPrizes_uniqueId);

	// 奖励ID
	String _userPrizes_prizeId = readString();
	//end
	_userPrizes[userPrizesIndex].setPrizeId (_userPrizes_prizeId);

	// 奖励类型  1 平台奖励还是 2 gm奖励 
	int _userPrizes_prizeType = readInteger();
	//end
	_userPrizes[userPrizesIndex].setPrizeType (_userPrizes_prizeType);

	// 奖励名称
	String _userPrizes_prizeName = readString();
	//end
	_userPrizes[userPrizesIndex].setPrizeName (_userPrizes_prizeName);

	// 失效时间
	long _userPrizes_expireTime = readLong();
	//end
	_userPrizes[userPrizesIndex].setExpireTime (_userPrizes_expireTime);
	}
	//end



		this.userPrizes = _userPrizes;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 奖励列表
	writeShort(userPrizes.length);
	int userPrizesIndex = 0;
	int userPrizesSize = userPrizes.length;
	for(userPrizesIndex=0; userPrizesIndex<userPrizesSize; userPrizesIndex++){

	int userPrizes_uniqueId = userPrizes[userPrizesIndex].getUniqueId();

	// 平台奖励唯一编号
	writeInteger(userPrizes_uniqueId);

	String userPrizes_prizeId = userPrizes[userPrizesIndex].getPrizeId();

	// 奖励ID
	writeString(userPrizes_prizeId);

	int userPrizes_prizeType = userPrizes[userPrizesIndex].getPrizeType();

	// 奖励类型  1 平台奖励还是 2 gm奖励 
	writeInteger(userPrizes_prizeType);

	String userPrizes_prizeName = userPrizes[userPrizesIndex].getPrizeName();

	// 奖励名称
	writeString(userPrizes_prizeName);

	long userPrizes_expireTime = userPrizes[userPrizesIndex].getExpireTime();

	// 失效时间
	writeLong(userPrizes_expireTime);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PRIZE_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PRIZE_LIST";
	}

	public com.imop.lj.gameserver.prize.UserPrizeInfo[] getUserPrizes(){
		return userPrizes;
	}

	public void setUserPrizes(com.imop.lj.gameserver.prize.UserPrizeInfo[] userPrizes){
		this.userPrizes = userPrizes;
	}	
}