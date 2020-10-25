package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求分配活动得到的物品
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAllocateActivityItem extends CGMessage{
	
	/** 活动类型,1-帮派竞赛 */
	private int activityType;
	/** 接受者 */
	private long targetId;
	/** 分配中的奖励内容 */
	private com.imop.lj.common.model.allocate.AllocateItemInfo[] allocatingItemInfos;
	
	public CGAllocateActivityItem (){
	}
	
	public CGAllocateActivityItem (
			int activityType,
			long targetId,
			com.imop.lj.common.model.allocate.AllocateItemInfo[] allocatingItemInfos ){
			this.activityType = activityType;
			this.targetId = targetId;
			this.allocatingItemInfos = allocatingItemInfos;
	}
	
	@Override
	protected boolean readImpl() {

	// 活动类型,1-帮派竞赛
	int _activityType = readInteger();
	//end


	// 接受者
	long _targetId = readLong();
	//end


	// 分配中的奖励内容
	int allocatingItemInfosSize = readUnsignedShort();
	com.imop.lj.common.model.allocate.AllocateItemInfo[] _allocatingItemInfos = new com.imop.lj.common.model.allocate.AllocateItemInfo[allocatingItemInfosSize];
	int allocatingItemInfosIndex = 0;
	for(allocatingItemInfosIndex=0; allocatingItemInfosIndex<allocatingItemInfosSize; allocatingItemInfosIndex++){
		_allocatingItemInfos[allocatingItemInfosIndex] = new com.imop.lj.common.model.allocate.AllocateItemInfo();
	// 已被分配到的奖励道具Id
	int _allocatingItemInfos_itemId = readInteger();
	//end
	_allocatingItemInfos[allocatingItemInfosIndex].setItemId (_allocatingItemInfos_itemId);

	// 已被分配到的奖励道具数量
	int _allocatingItemInfos_num = readInteger();
	//end
	_allocatingItemInfos[allocatingItemInfosIndex].setNum (_allocatingItemInfos_num);
	}
	//end



			this.activityType = _activityType;
			this.targetId = _targetId;
			this.allocatingItemInfos = _allocatingItemInfos;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 活动类型,1-帮派竞赛
	writeInteger(activityType);


	// 接受者
	writeLong(targetId);


	// 分配中的奖励内容
	writeShort(allocatingItemInfos.length);
	int allocatingItemInfosIndex = 0;
	int allocatingItemInfosSize = allocatingItemInfos.length;
	for(allocatingItemInfosIndex=0; allocatingItemInfosIndex<allocatingItemInfosSize; allocatingItemInfosIndex++){

	int allocatingItemInfos_itemId = allocatingItemInfos[allocatingItemInfosIndex].getItemId();

	// 已被分配到的奖励道具Id
	writeInteger(allocatingItemInfos_itemId);

	int allocatingItemInfos_num = allocatingItemInfos[allocatingItemInfosIndex].getNum();

	// 已被分配到的奖励道具数量
	writeInteger(allocatingItemInfos_num);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ALLOCATE_ACTIVITY_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ALLOCATE_ACTIVITY_ITEM";
	}

	public int getActivityType(){
		return activityType;
	}
		
	public void setActivityType(int activityType){
		this.activityType = activityType;
	}

	public long getTargetId(){
		return targetId;
	}
		
	public void setTargetId(long targetId){
		this.targetId = targetId;
	}

	public com.imop.lj.common.model.allocate.AllocateItemInfo[] getAllocatingItemInfos(){
		return allocatingItemInfos;
	}

	public void setAllocatingItemInfos(com.imop.lj.common.model.allocate.AllocateItemInfo[] allocatingItemInfos){
		this.allocatingItemInfos = allocatingItemInfos;
	}	


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleAllocateActivityItem(this.getSession().getPlayer(), this);
	}
}