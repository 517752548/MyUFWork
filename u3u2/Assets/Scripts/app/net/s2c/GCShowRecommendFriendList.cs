
using System;
namespace app.net
{
/**
 * 显示好友推荐面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCShowRecommendFriendList :BaseMessage
{
	/** 玩家列表 */
	private RelationInfo[] relationInfoList;

	public GCShowRecommendFriendList ()
	{
	}

	protected override void ReadImpl()
	{

	// 玩家列表
	int relationInfoListSize = ReadShort();
	RelationInfo[] _relationInfoList = new RelationInfo[relationInfoListSize];
	int relationInfoListIndex = 0;
	RelationInfo _relationInfoListTmp = null;
	for(relationInfoListIndex=0; relationInfoListIndex<relationInfoListSize; relationInfoListIndex++){
		_relationInfoListTmp = new RelationInfo();
		_relationInfoList[relationInfoListIndex] = _relationInfoListTmp;
	// 角色ID
	long _relationInfoList_uuid = ReadLong();	_relationInfoListTmp.uuid = _relationInfoList_uuid;
		// 角色名称
	string _relationInfoList_name = ReadString();	_relationInfoListTmp.name = _relationInfoList_name;
		// 国家
	int _relationInfoList_country = ReadInt();	_relationInfoListTmp.country = _relationInfoList_country;
		// 等级
	int _relationInfoList_level = ReadInt();	_relationInfoListTmp.level = _relationInfoList_level;
		// 头像
	int _relationInfoList_pic = ReadInt();	_relationInfoListTmp.pic = _relationInfoList_pic;
		// 玩家qq信息vip等数据
	QQInfoData _relationInfoList_qqInfo = new QQInfoData();
	// 是否黄钻用户，0否，1是
	int _relationInfoList_qqInfo_isYellowVip = ReadInt();	_relationInfoList_qqInfo.isYellowVip = _relationInfoList_qqInfo_isYellowVip;
	// 黄钻等级
	int _relationInfoList_qqInfo_yellowVipLevel = ReadInt();	_relationInfoList_qqInfo.yellowVipLevel = _relationInfoList_qqInfo_yellowVipLevel;
	// 是否黄钻年费用户，0否，1是
	int _relationInfoList_qqInfo_isYellowYearVip = ReadInt();	_relationInfoList_qqInfo.isYellowYearVip = _relationInfoList_qqInfo_isYellowYearVip;
	// 是否豪华版黄钻用户，0否，1是
	int _relationInfoList_qqInfo_isYellowHighVip = ReadInt();	_relationInfoList_qqInfo.isYellowHighVip = _relationInfoList_qqInfo_isYellowHighVip;
	_relationInfoListTmp.qqInfo = _relationInfoList_qqInfo;
		}
	//end



		this.relationInfoList = _relationInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SHOW_RECOMMEND_FRIEND_LIST;
	}
	
	public override string getEventType()
	{
		return RelationGCHandler.GCShowRecommendFriendListEvent;
	}
	

	public RelationInfo[] getRelationInfoList(){
		return relationInfoList;
	}


}
}