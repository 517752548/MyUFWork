
using System;
namespace app.net
{
/**
 * 添加关系成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCAddRelation :BaseMessage
{
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家Id */
	private long targetCharId;
	/** 玩家信息 */
	private RelationInfo relationInfoData;

	public GCAddRelation ()
	{
	}

	protected override void ReadImpl()
	{
	// 1好友，2黑名单
	int _relationType = ReadInt();
	// 目标玩家Id
	long _targetCharId = ReadLong();
	// 玩家信息
	RelationInfo _relationInfoData = new RelationInfo();
	// 角色ID
	long _relationInfoData_uuid = ReadLong();	_relationInfoData.uuid = _relationInfoData_uuid;
	// 角色名称
	string _relationInfoData_name = ReadString();	_relationInfoData.name = _relationInfoData_name;
	// 国家
	int _relationInfoData_country = ReadInt();	_relationInfoData.country = _relationInfoData_country;
	// 等级
	int _relationInfoData_level = ReadInt();	_relationInfoData.level = _relationInfoData_level;
	// 头像
	int _relationInfoData_pic = ReadInt();	_relationInfoData.pic = _relationInfoData_pic;
	// 玩家qq信息vip等数据
	QQInfoData _relationInfoData_qqInfo = new QQInfoData();
	// 是否黄钻用户，0否，1是
	int _relationInfoData_qqInfo_isYellowVip = ReadInt();	_relationInfoData_qqInfo.isYellowVip = _relationInfoData_qqInfo_isYellowVip;
	// 黄钻等级
	int _relationInfoData_qqInfo_yellowVipLevel = ReadInt();	_relationInfoData_qqInfo.yellowVipLevel = _relationInfoData_qqInfo_yellowVipLevel;
	// 是否黄钻年费用户，0否，1是
	int _relationInfoData_qqInfo_isYellowYearVip = ReadInt();	_relationInfoData_qqInfo.isYellowYearVip = _relationInfoData_qqInfo_isYellowYearVip;
	// 是否豪华版黄钻用户，0否，1是
	int _relationInfoData_qqInfo_isYellowHighVip = ReadInt();	_relationInfoData_qqInfo.isYellowHighVip = _relationInfoData_qqInfo_isYellowHighVip;
	_relationInfoData.qqInfo = _relationInfoData_qqInfo;



		this.relationType = _relationType;
		this.targetCharId = _targetCharId;
		this.relationInfoData = _relationInfoData;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ADD_RELATION;
	}
	
	public override string getEventType()
	{
		return RelationGCHandler.GCAddRelationEvent;
	}
	

	public int getRelationType(){
		return relationType;
	}
		

	public long getTargetCharId(){
		return targetCharId;
	}
		

	public RelationInfo getRelationInfoData(){
		return relationInfoData;
	}
		

}
}