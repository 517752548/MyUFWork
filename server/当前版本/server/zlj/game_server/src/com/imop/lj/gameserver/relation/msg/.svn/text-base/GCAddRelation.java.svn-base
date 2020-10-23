package com.imop.lj.gameserver.relation.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 添加关系成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCAddRelation extends GCMessage{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家Id */
	private long targetCharId;
	/** 玩家信息 */
	private com.imop.lj.common.model.RelationInfo relationInfoData;

	public GCAddRelation (){
	}
	
	public GCAddRelation (
			int relationType,
			long targetCharId,
			com.imop.lj.common.model.RelationInfo relationInfoData ){
			this.relationType = relationType;
			this.targetCharId = targetCharId;
			this.relationInfoData = relationInfoData;
	}

	@Override
	protected boolean readImpl() {

	// 1好友，2黑名单
	int _relationType = readInteger();
	//end


	// 目标玩家Id
	long _targetCharId = readLong();
	//end

	// 玩家信息
	com.imop.lj.common.model.RelationInfo _relationInfoData = new com.imop.lj.common.model.RelationInfo();

	// 角色ID
	long _relationInfoData_uuid = readLong();
	//end
	_relationInfoData.setUuid (_relationInfoData_uuid);

	// 角色名称
	String _relationInfoData_name = readString();
	//end
	_relationInfoData.setName (_relationInfoData_name);

	// 国家
	int _relationInfoData_country = readInteger();
	//end
	_relationInfoData.setCountry (_relationInfoData_country);

	// 等级
	int _relationInfoData_level = readInteger();
	//end
	_relationInfoData.setLevel (_relationInfoData_level);

	// 头像
	int _relationInfoData_pic = readInteger();
	//end
	_relationInfoData.setPic (_relationInfoData_pic);
	// 玩家qq信息vip等数据
	com.imop.lj.common.model.human.QQInfo _relationInfoData_qqInfo = new com.imop.lj.common.model.human.QQInfo();

	// 是否黄钻用户，0否，1是
	int _relationInfoData_qqInfo_isYellowVip = readInteger();
	//end
	_relationInfoData_qqInfo.setIsYellowVip (_relationInfoData_qqInfo_isYellowVip);

	// 黄钻等级
	int _relationInfoData_qqInfo_yellowVipLevel = readInteger();
	//end
	_relationInfoData_qqInfo.setYellowVipLevel (_relationInfoData_qqInfo_yellowVipLevel);

	// 是否黄钻年费用户，0否，1是
	int _relationInfoData_qqInfo_isYellowYearVip = readInteger();
	//end
	_relationInfoData_qqInfo.setIsYellowYearVip (_relationInfoData_qqInfo_isYellowYearVip);

	// 是否豪华版黄钻用户，0否，1是
	int _relationInfoData_qqInfo_isYellowHighVip = readInteger();
	//end
	_relationInfoData_qqInfo.setIsYellowHighVip (_relationInfoData_qqInfo_isYellowHighVip);
	_relationInfoData.setQqInfo (_relationInfoData_qqInfo);



		this.relationType = _relationType;
		this.targetCharId = _targetCharId;
		this.relationInfoData = _relationInfoData;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1好友，2黑名单
	writeInteger(relationType);


	// 目标玩家Id
	writeLong(targetCharId);


	long relationInfoData_uuid = relationInfoData.getUuid ();

	// 角色ID
	writeLong(relationInfoData_uuid);

	String relationInfoData_name = relationInfoData.getName ();

	// 角色名称
	writeString(relationInfoData_name);

	int relationInfoData_country = relationInfoData.getCountry ();

	// 国家
	writeInteger(relationInfoData_country);

	int relationInfoData_level = relationInfoData.getLevel ();

	// 等级
	writeInteger(relationInfoData_level);

	int relationInfoData_pic = relationInfoData.getPic ();

	// 头像
	writeInteger(relationInfoData_pic);

	com.imop.lj.common.model.human.QQInfo relationInfoData_qqInfo = relationInfoData.getQqInfo ();

	int relationInfoData_qqInfo_isYellowVip = relationInfoData_qqInfo.getIsYellowVip ();

	// 是否黄钻用户，0否，1是
	writeInteger(relationInfoData_qqInfo_isYellowVip);

	int relationInfoData_qqInfo_yellowVipLevel = relationInfoData_qqInfo.getYellowVipLevel ();

	// 黄钻等级
	writeInteger(relationInfoData_qqInfo_yellowVipLevel);

	int relationInfoData_qqInfo_isYellowYearVip = relationInfoData_qqInfo.getIsYellowYearVip ();

	// 是否黄钻年费用户，0否，1是
	writeInteger(relationInfoData_qqInfo_isYellowYearVip);

	int relationInfoData_qqInfo_isYellowHighVip = relationInfoData_qqInfo.getIsYellowHighVip ();

	// 是否豪华版黄钻用户，0否，1是
	writeInteger(relationInfoData_qqInfo_isYellowHighVip);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ADD_RELATION;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ADD_RELATION";
	}

	public int getRelationType(){
		return relationType;
	}
		
	public void setRelationType(int relationType){
		this.relationType = relationType;
	}

	public long getTargetCharId(){
		return targetCharId;
	}
		
	public void setTargetCharId(long targetCharId){
		this.targetCharId = targetCharId;
	}

	public com.imop.lj.common.model.RelationInfo getRelationInfoData(){
		return relationInfoData;
	}
		
	public void setRelationInfoData(com.imop.lj.common.model.RelationInfo relationInfoData){
		this.relationInfoData = relationInfoData;
	}
}