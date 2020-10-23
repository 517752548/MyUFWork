package com.imop.lj.gameserver.relation.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 显示好友推荐面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCShowRecommendFriendList extends GCMessage{
	
	/** 玩家列表 */
	private com.imop.lj.common.model.RelationInfo[] relationInfoList;

	public GCShowRecommendFriendList (){
	}
	
	public GCShowRecommendFriendList (
			com.imop.lj.common.model.RelationInfo[] relationInfoList ){
			this.relationInfoList = relationInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 玩家列表
	int relationInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.RelationInfo[] _relationInfoList = new com.imop.lj.common.model.RelationInfo[relationInfoListSize];
	int relationInfoListIndex = 0;
	for(relationInfoListIndex=0; relationInfoListIndex<relationInfoListSize; relationInfoListIndex++){
		_relationInfoList[relationInfoListIndex] = new com.imop.lj.common.model.RelationInfo();
	// 角色ID
	long _relationInfoList_uuid = readLong();
	//end
	_relationInfoList[relationInfoListIndex].setUuid (_relationInfoList_uuid);

	// 角色名称
	String _relationInfoList_name = readString();
	//end
	_relationInfoList[relationInfoListIndex].setName (_relationInfoList_name);

	// 国家
	int _relationInfoList_country = readInteger();
	//end
	_relationInfoList[relationInfoListIndex].setCountry (_relationInfoList_country);

	// 等级
	int _relationInfoList_level = readInteger();
	//end
	_relationInfoList[relationInfoListIndex].setLevel (_relationInfoList_level);

	// 头像
	int _relationInfoList_pic = readInteger();
	//end
	_relationInfoList[relationInfoListIndex].setPic (_relationInfoList_pic);
	// 玩家qq信息vip等数据
	com.imop.lj.common.model.human.QQInfo _relationInfoList_qqInfo = new com.imop.lj.common.model.human.QQInfo();

	// 是否黄钻用户，0否，1是
	int _relationInfoList_qqInfo_isYellowVip = readInteger();
	//end
	_relationInfoList_qqInfo.setIsYellowVip (_relationInfoList_qqInfo_isYellowVip);

	// 黄钻等级
	int _relationInfoList_qqInfo_yellowVipLevel = readInteger();
	//end
	_relationInfoList_qqInfo.setYellowVipLevel (_relationInfoList_qqInfo_yellowVipLevel);

	// 是否黄钻年费用户，0否，1是
	int _relationInfoList_qqInfo_isYellowYearVip = readInteger();
	//end
	_relationInfoList_qqInfo.setIsYellowYearVip (_relationInfoList_qqInfo_isYellowYearVip);

	// 是否豪华版黄钻用户，0否，1是
	int _relationInfoList_qqInfo_isYellowHighVip = readInteger();
	//end
	_relationInfoList_qqInfo.setIsYellowHighVip (_relationInfoList_qqInfo_isYellowHighVip);
	_relationInfoList[relationInfoListIndex].setQqInfo (_relationInfoList_qqInfo);
	}
	//end



		this.relationInfoList = _relationInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 玩家列表
	writeShort(relationInfoList.length);
	int relationInfoListIndex = 0;
	int relationInfoListSize = relationInfoList.length;
	for(relationInfoListIndex=0; relationInfoListIndex<relationInfoListSize; relationInfoListIndex++){

	long relationInfoList_uuid = relationInfoList[relationInfoListIndex].getUuid();

	// 角色ID
	writeLong(relationInfoList_uuid);

	String relationInfoList_name = relationInfoList[relationInfoListIndex].getName();

	// 角色名称
	writeString(relationInfoList_name);

	int relationInfoList_country = relationInfoList[relationInfoListIndex].getCountry();

	// 国家
	writeInteger(relationInfoList_country);

	int relationInfoList_level = relationInfoList[relationInfoListIndex].getLevel();

	// 等级
	writeInteger(relationInfoList_level);

	int relationInfoList_pic = relationInfoList[relationInfoListIndex].getPic();

	// 头像
	writeInteger(relationInfoList_pic);

	com.imop.lj.common.model.human.QQInfo relationInfoList_qqInfo = relationInfoList[relationInfoListIndex].getQqInfo();

	int relationInfoList_qqInfo_isYellowVip = relationInfoList_qqInfo.getIsYellowVip ();

	// 是否黄钻用户，0否，1是
	writeInteger(relationInfoList_qqInfo_isYellowVip);

	int relationInfoList_qqInfo_yellowVipLevel = relationInfoList_qqInfo.getYellowVipLevel ();

	// 黄钻等级
	writeInteger(relationInfoList_qqInfo_yellowVipLevel);

	int relationInfoList_qqInfo_isYellowYearVip = relationInfoList_qqInfo.getIsYellowYearVip ();

	// 是否黄钻年费用户，0否，1是
	writeInteger(relationInfoList_qqInfo_isYellowYearVip);

	int relationInfoList_qqInfo_isYellowHighVip = relationInfoList_qqInfo.getIsYellowHighVip ();

	// 是否豪华版黄钻用户，0否，1是
	writeInteger(relationInfoList_qqInfo_isYellowHighVip);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SHOW_RECOMMEND_FRIEND_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SHOW_RECOMMEND_FRIEND_LIST";
	}

	public com.imop.lj.common.model.RelationInfo[] getRelationInfoList(){
		return relationInfoList;
	}

	public void setRelationInfoList(com.imop.lj.common.model.RelationInfo[] relationInfoList){
		this.relationInfoList = relationInfoList;
	}	
}