
using System;
namespace app.net
{
/**
 * 小信封功能信息列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNoticeTipsInfoList :BaseMessage
{
	/** 小信封功能信息列表 */
	private NoticeTipsInfoData[] noticeTipsInfoList;

	public GCNoticeTipsInfoList ()
	{
	}

	protected override void ReadImpl()
	{

	// 小信封功能信息列表
	int noticeTipsInfoListSize = ReadShort();
	NoticeTipsInfoData[] _noticeTipsInfoList = new NoticeTipsInfoData[noticeTipsInfoListSize];
	int noticeTipsInfoListIndex = 0;
	NoticeTipsInfoData _noticeTipsInfoListTmp = null;
	for(noticeTipsInfoListIndex=0; noticeTipsInfoListIndex<noticeTipsInfoListSize; noticeTipsInfoListIndex++){
		_noticeTipsInfoListTmp = new NoticeTipsInfoData();
		_noticeTipsInfoList[noticeTipsInfoListIndex] = _noticeTipsInfoListTmp;
	// 窗口内容
	string _noticeTipsInfoList_content = ReadString();	_noticeTipsInfoListTmp.content = _noticeTipsInfoList_content;
		// 操作标识
	string _noticeTipsInfoList_tag = ReadString();	_noticeTipsInfoListTmp.tag = _noticeTipsInfoList_tag;
		// 小信封1无选择项2有选择框
	int _noticeTipsInfoList_type = ReadInt();	_noticeTipsInfoListTmp.type = _noticeTipsInfoList_type;
		// 小信封icon
	int _noticeTipsInfoList_icon = ReadInt();	_noticeTipsInfoListTmp.icon = _noticeTipsInfoList_icon;
		// 点完确定之后播放的动画类型，暂留
	int _noticeTipsInfoList_showAnimation = ReadInt();	_noticeTipsInfoListTmp.showAnimation = _noticeTipsInfoList_showAnimation;
		// 来源角色ID
	long _noticeTipsInfoList_fromRoleId = ReadLong();	_noticeTipsInfoListTmp.fromRoleId = _noticeTipsInfoList_fromRoleId;
		// 来源名称
	string _noticeTipsInfoList_fromRoleName = ReadString();	_noticeTipsInfoListTmp.fromRoleName = _noticeTipsInfoList_fromRoleName;
		// 等级
	int _noticeTipsInfoList_fromRoleLevel = ReadInt();	_noticeTipsInfoListTmp.fromRoleLevel = _noticeTipsInfoList_fromRoleLevel;
		// 角色职业
	int _noticeTipsInfoList_fromRoleJobType = ReadInt();	_noticeTipsInfoListTmp.fromRoleJobType = _noticeTipsInfoList_fromRoleJobType;
		// 角色模板Id
	int _noticeTipsInfoList_fromRoleTplId = ReadInt();	_noticeTipsInfoListTmp.fromRoleTplId = _noticeTipsInfoList_fromRoleTplId;
		// 聊天时间
	long _noticeTipsInfoList_chatTime = ReadLong();	_noticeTipsInfoListTmp.chatTime = _noticeTipsInfoList_chatTime;
		}
	//end



		this.noticeTipsInfoList = _noticeTipsInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_NOTICE_TIPS_INFO_LIST;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCNoticeTipsInfoListEvent;
	}
	

	public NoticeTipsInfoData[] getNoticeTipsInfoList(){
		return noticeTipsInfoList;
	}


}
}