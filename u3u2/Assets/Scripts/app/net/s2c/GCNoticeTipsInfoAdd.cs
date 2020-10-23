
using System;
namespace app.net
{
/**
 * 增加小信封信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNoticeTipsInfoAdd :BaseMessage
{
	/** 增加小信封信息 */
	private NoticeTipsInfoData noticeTipsInfo;

	public GCNoticeTipsInfoAdd ()
	{
	}

	protected override void ReadImpl()
	{
	// 增加小信封信息
	NoticeTipsInfoData _noticeTipsInfo = new NoticeTipsInfoData();
	// 窗口内容
	string _noticeTipsInfo_content = ReadString();	_noticeTipsInfo.content = _noticeTipsInfo_content;
	// 操作标识
	string _noticeTipsInfo_tag = ReadString();	_noticeTipsInfo.tag = _noticeTipsInfo_tag;
	// 小信封1无选择项2有选择框
	int _noticeTipsInfo_type = ReadInt();	_noticeTipsInfo.type = _noticeTipsInfo_type;
	// 小信封icon
	int _noticeTipsInfo_icon = ReadInt();	_noticeTipsInfo.icon = _noticeTipsInfo_icon;
	// 点完确定之后播放的动画类型，暂留
	int _noticeTipsInfo_showAnimation = ReadInt();	_noticeTipsInfo.showAnimation = _noticeTipsInfo_showAnimation;
	// 来源角色ID
	long _noticeTipsInfo_fromRoleId = ReadLong();	_noticeTipsInfo.fromRoleId = _noticeTipsInfo_fromRoleId;
	// 来源名称
	string _noticeTipsInfo_fromRoleName = ReadString();	_noticeTipsInfo.fromRoleName = _noticeTipsInfo_fromRoleName;
	// 等级
	int _noticeTipsInfo_fromRoleLevel = ReadInt();	_noticeTipsInfo.fromRoleLevel = _noticeTipsInfo_fromRoleLevel;
	// 角色职业
	int _noticeTipsInfo_fromRoleJobType = ReadInt();	_noticeTipsInfo.fromRoleJobType = _noticeTipsInfo_fromRoleJobType;
	// 角色模板Id
	int _noticeTipsInfo_fromRoleTplId = ReadInt();	_noticeTipsInfo.fromRoleTplId = _noticeTipsInfo_fromRoleTplId;
	// 聊天时间
	long _noticeTipsInfo_chatTime = ReadLong();	_noticeTipsInfo.chatTime = _noticeTipsInfo_chatTime;



		this.noticeTipsInfo = _noticeTipsInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_NOTICE_TIPS_INFO_ADD;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCNoticeTipsInfoAddEvent;
	}
	

	public NoticeTipsInfoData getNoticeTipsInfo(){
		return noticeTipsInfo;
	}
		

}
}