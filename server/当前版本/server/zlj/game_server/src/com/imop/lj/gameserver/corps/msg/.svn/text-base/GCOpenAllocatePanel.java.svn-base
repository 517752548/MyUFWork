package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回请求打开活动奖励分配面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenAllocatePanel extends GCMessage{
	
	/** 待被分配到的奖励内容 */
	private com.imop.lj.common.model.allocate.AllocateItemInfo[] beforeAllocateItemInfos;
	/** 被分配奖励的玩家信息 */
	private com.imop.lj.common.model.allocate.AllocateMemberInfo[] allocateMemberInfoList;

	public GCOpenAllocatePanel (){
	}
	
	public GCOpenAllocatePanel (
			com.imop.lj.common.model.allocate.AllocateItemInfo[] beforeAllocateItemInfos,
			com.imop.lj.common.model.allocate.AllocateMemberInfo[] allocateMemberInfoList ){
			this.beforeAllocateItemInfos = beforeAllocateItemInfos;
			this.allocateMemberInfoList = allocateMemberInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 待被分配到的奖励内容
	int beforeAllocateItemInfosSize = readUnsignedShort();
	com.imop.lj.common.model.allocate.AllocateItemInfo[] _beforeAllocateItemInfos = new com.imop.lj.common.model.allocate.AllocateItemInfo[beforeAllocateItemInfosSize];
	int beforeAllocateItemInfosIndex = 0;
	for(beforeAllocateItemInfosIndex=0; beforeAllocateItemInfosIndex<beforeAllocateItemInfosSize; beforeAllocateItemInfosIndex++){
		_beforeAllocateItemInfos[beforeAllocateItemInfosIndex] = new com.imop.lj.common.model.allocate.AllocateItemInfo();
	// 已被分配到的奖励道具Id
	int _beforeAllocateItemInfos_itemId = readInteger();
	//end
	_beforeAllocateItemInfos[beforeAllocateItemInfosIndex].setItemId (_beforeAllocateItemInfos_itemId);

	// 已被分配到的奖励道具数量
	int _beforeAllocateItemInfos_num = readInteger();
	//end
	_beforeAllocateItemInfos[beforeAllocateItemInfosIndex].setNum (_beforeAllocateItemInfos_num);
	}
	//end


	// 被分配奖励的玩家信息
	int allocateMemberInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.allocate.AllocateMemberInfo[] _allocateMemberInfoList = new com.imop.lj.common.model.allocate.AllocateMemberInfo[allocateMemberInfoListSize];
	int allocateMemberInfoListIndex = 0;
	for(allocateMemberInfoListIndex=0; allocateMemberInfoListIndex<allocateMemberInfoListSize; allocateMemberInfoListIndex++){
		_allocateMemberInfoList[allocateMemberInfoListIndex] = new com.imop.lj.common.model.allocate.AllocateMemberInfo();
	// 玩家id
	long _allocateMemberInfoList_roleId = readLong();
	//end
	_allocateMemberInfoList[allocateMemberInfoListIndex].setRoleId (_allocateMemberInfoList_roleId);

	// 玩家姓名
	String _allocateMemberInfoList_playerName = readString();
	//end
	_allocateMemberInfoList[allocateMemberInfoListIndex].setPlayerName (_allocateMemberInfoList_playerName);

	// 玩家军团id
	long _allocateMemberInfoList_corpsId = readLong();
	//end
	_allocateMemberInfoList[allocateMemberInfoListIndex].setCorpsId (_allocateMemberInfoList_corpsId);

	// 玩家积分
	int _allocateMemberInfoList_score = readInteger();
	//end
	_allocateMemberInfoList[allocateMemberInfoListIndex].setScore (_allocateMemberInfoList_score);

	// 玩家等级
	int _allocateMemberInfoList_playerLevel = readInteger();
	//end
	_allocateMemberInfoList[allocateMemberInfoListIndex].setPlayerLevel (_allocateMemberInfoList_playerLevel);

	// 玩家战力
	int _allocateMemberInfoList_playerPower = readInteger();
	//end
	_allocateMemberInfoList[allocateMemberInfoListIndex].setPlayerPower (_allocateMemberInfoList_playerPower);

	// 玩家帮派职务
	int _allocateMemberInfoList_corpsJob = readInteger();
	//end
	_allocateMemberInfoList[allocateMemberInfoListIndex].setCorpsJob (_allocateMemberInfoList_corpsJob);

	// 已被分配到的奖励内容
	int allocateMemberInfoList_afterAllocateItemInfosSize = readUnsignedShort();
	com.imop.lj.common.model.allocate.AllocateItemInfo[] _allocateMemberInfoList_afterAllocateItemInfos = new com.imop.lj.common.model.allocate.AllocateItemInfo[allocateMemberInfoList_afterAllocateItemInfosSize];
	int allocateMemberInfoList_afterAllocateItemInfosIndex = 0;
	for(allocateMemberInfoList_afterAllocateItemInfosIndex=0; allocateMemberInfoList_afterAllocateItemInfosIndex<allocateMemberInfoList_afterAllocateItemInfosSize; allocateMemberInfoList_afterAllocateItemInfosIndex++){
		_allocateMemberInfoList_afterAllocateItemInfos[allocateMemberInfoList_afterAllocateItemInfosIndex] = new com.imop.lj.common.model.allocate.AllocateItemInfo();
	// 已被分配到的奖励道具Id
	int _allocateMemberInfoList_afterAllocateItemInfos_itemId = readInteger();
	//end
	_allocateMemberInfoList_afterAllocateItemInfos[allocateMemberInfoList_afterAllocateItemInfosIndex].setItemId (_allocateMemberInfoList_afterAllocateItemInfos_itemId);

	// 已被分配到的奖励道具数量
	int _allocateMemberInfoList_afterAllocateItemInfos_num = readInteger();
	//end
	_allocateMemberInfoList_afterAllocateItemInfos[allocateMemberInfoList_afterAllocateItemInfosIndex].setNum (_allocateMemberInfoList_afterAllocateItemInfos_num);
	}
	//end
	_allocateMemberInfoList[allocateMemberInfoListIndex].setAfterAllocateItemInfos (_allocateMemberInfoList_afterAllocateItemInfos);
	}
	//end



		this.beforeAllocateItemInfos = _beforeAllocateItemInfos;
		this.allocateMemberInfoList = _allocateMemberInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 待被分配到的奖励内容
	writeShort(beforeAllocateItemInfos.length);
	int beforeAllocateItemInfosIndex = 0;
	int beforeAllocateItemInfosSize = beforeAllocateItemInfos.length;
	for(beforeAllocateItemInfosIndex=0; beforeAllocateItemInfosIndex<beforeAllocateItemInfosSize; beforeAllocateItemInfosIndex++){

	int beforeAllocateItemInfos_itemId = beforeAllocateItemInfos[beforeAllocateItemInfosIndex].getItemId();

	// 已被分配到的奖励道具Id
	writeInteger(beforeAllocateItemInfos_itemId);

	int beforeAllocateItemInfos_num = beforeAllocateItemInfos[beforeAllocateItemInfosIndex].getNum();

	// 已被分配到的奖励道具数量
	writeInteger(beforeAllocateItemInfos_num);
	}
	//end


	// 被分配奖励的玩家信息
	writeShort(allocateMemberInfoList.length);
	int allocateMemberInfoListIndex = 0;
	int allocateMemberInfoListSize = allocateMemberInfoList.length;
	for(allocateMemberInfoListIndex=0; allocateMemberInfoListIndex<allocateMemberInfoListSize; allocateMemberInfoListIndex++){

	long allocateMemberInfoList_roleId = allocateMemberInfoList[allocateMemberInfoListIndex].getRoleId();

	// 玩家id
	writeLong(allocateMemberInfoList_roleId);

	String allocateMemberInfoList_playerName = allocateMemberInfoList[allocateMemberInfoListIndex].getPlayerName();

	// 玩家姓名
	writeString(allocateMemberInfoList_playerName);

	long allocateMemberInfoList_corpsId = allocateMemberInfoList[allocateMemberInfoListIndex].getCorpsId();

	// 玩家军团id
	writeLong(allocateMemberInfoList_corpsId);

	int allocateMemberInfoList_score = allocateMemberInfoList[allocateMemberInfoListIndex].getScore();

	// 玩家积分
	writeInteger(allocateMemberInfoList_score);

	int allocateMemberInfoList_playerLevel = allocateMemberInfoList[allocateMemberInfoListIndex].getPlayerLevel();

	// 玩家等级
	writeInteger(allocateMemberInfoList_playerLevel);

	int allocateMemberInfoList_playerPower = allocateMemberInfoList[allocateMemberInfoListIndex].getPlayerPower();

	// 玩家战力
	writeInteger(allocateMemberInfoList_playerPower);

	int allocateMemberInfoList_corpsJob = allocateMemberInfoList[allocateMemberInfoListIndex].getCorpsJob();

	// 玩家帮派职务
	writeInteger(allocateMemberInfoList_corpsJob);

	com.imop.lj.common.model.allocate.AllocateItemInfo[] allocateMemberInfoList_afterAllocateItemInfos = allocateMemberInfoList[allocateMemberInfoListIndex].getAfterAllocateItemInfos();

	// 已被分配到的奖励内容
	writeShort(allocateMemberInfoList_afterAllocateItemInfos.length);
	int allocateMemberInfoList_afterAllocateItemInfosIndex = 0;
	int allocateMemberInfoList_afterAllocateItemInfosSize = allocateMemberInfoList_afterAllocateItemInfos.length;
	for(allocateMemberInfoList_afterAllocateItemInfosIndex=0; allocateMemberInfoList_afterAllocateItemInfosIndex<allocateMemberInfoList_afterAllocateItemInfosSize; allocateMemberInfoList_afterAllocateItemInfosIndex++){

	int allocateMemberInfoList_afterAllocateItemInfos_itemId = allocateMemberInfoList_afterAllocateItemInfos[allocateMemberInfoList_afterAllocateItemInfosIndex].getItemId();

	// 已被分配到的奖励道具Id
	writeInteger(allocateMemberInfoList_afterAllocateItemInfos_itemId);

	int allocateMemberInfoList_afterAllocateItemInfos_num = allocateMemberInfoList_afterAllocateItemInfos[allocateMemberInfoList_afterAllocateItemInfosIndex].getNum();

	// 已被分配到的奖励道具数量
	writeInteger(allocateMemberInfoList_afterAllocateItemInfos_num);
	}
	//end
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OPEN_ALLOCATE_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_ALLOCATE_PANEL";
	}

	public com.imop.lj.common.model.allocate.AllocateItemInfo[] getBeforeAllocateItemInfos(){
		return beforeAllocateItemInfos;
	}

	public void setBeforeAllocateItemInfos(com.imop.lj.common.model.allocate.AllocateItemInfo[] beforeAllocateItemInfos){
		this.beforeAllocateItemInfos = beforeAllocateItemInfos;
	}	

	public com.imop.lj.common.model.allocate.AllocateMemberInfo[] getAllocateMemberInfoList(){
		return allocateMemberInfoList;
	}

	public void setAllocateMemberInfoList(com.imop.lj.common.model.allocate.AllocateMemberInfo[] allocateMemberInfoList){
		this.allocateMemberInfoList = allocateMemberInfoList;
	}	
}