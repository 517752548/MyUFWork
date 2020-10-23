
using System;
namespace app.net
{
/**
 * 申请列表信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamApplyList :BaseMessage
{
	/** 队员信息列表 */
	private TeamMemberInfo[] teamMemberInfos;

	public GCTeamApplyList ()
	{
	}

	protected override void ReadImpl()
	{

	// 队员信息列表
	int teamMemberInfosSize = ReadShort();
	TeamMemberInfo[] _teamMemberInfos = new TeamMemberInfo[teamMemberInfosSize];
	int teamMemberInfosIndex = 0;
	TeamMemberInfo _teamMemberInfosTmp = null;
	for(teamMemberInfosIndex=0; teamMemberInfosIndex<teamMemberInfosSize; teamMemberInfosIndex++){
		_teamMemberInfosTmp = new TeamMemberInfo();
		_teamMemberInfos[teamMemberInfosIndex] = _teamMemberInfosTmp;
	// 队员唯一Id
	long _teamMemberInfos_uuid = ReadLong();	_teamMemberInfosTmp.uuid = _teamMemberInfos_uuid;
		// 是否队长
	int _teamMemberInfos_isLeader = ReadInt();	_teamMemberInfosTmp.isLeader = _teamMemberInfos_isLeader;
		// 模板Id
	int _teamMemberInfos_tplId = ReadInt();	_teamMemberInfosTmp.tplId = _teamMemberInfos_tplId;
		// 是否伙伴，0否，1是
	int _teamMemberInfos_isFriend = ReadInt();	_teamMemberInfosTmp.isFriend = _teamMemberInfos_isFriend;
		// 名字 
	string _teamMemberInfos_name = ReadString();	_teamMemberInfosTmp.name = _teamMemberInfos_name;
		// 职业Id
	int _teamMemberInfos_jobTypeId = ReadInt();	_teamMemberInfosTmp.jobTypeId = _teamMemberInfos_jobTypeId;
		// 等级
	int _teamMemberInfos_level = ReadInt();	_teamMemberInfosTmp.level = _teamMemberInfos_level;
		// 位置Id，从1开始计数
	int _teamMemberInfos_position = ReadInt();	_teamMemberInfosTmp.position = _teamMemberInfos_position;
		// 状态，1队伍中，2暂离
	int _teamMemberInfos_status = ReadInt();	_teamMemberInfosTmp.status = _teamMemberInfos_status;
		// 主将武器模板Id
	int _teamMemberInfos_equipWeaponId = ReadInt();	_teamMemberInfosTmp.equipWeaponId = _teamMemberInfos_equipWeaponId;
		}
	//end



		this.teamMemberInfos = _teamMemberInfos;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TEAM_APPLY_LIST;
	}
	
	public override string getEventType()
	{
		return TeamGCHandler.GCTeamApplyListEvent;
	}
	

	public TeamMemberInfo[] getTeamMemberInfos(){
		return teamMemberInfos;
	}


	public override bool isCompress() {
		return true;
	}
}
}