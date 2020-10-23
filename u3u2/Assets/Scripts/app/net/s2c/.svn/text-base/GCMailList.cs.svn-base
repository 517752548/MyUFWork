
using System;
namespace app.net
{
/**
 * 邮件列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMailList :BaseMessage
{
	/** 邮箱类型1-inbox,2-sended,3-savebox */
	private int boxType;
	/** 查询的页面索引 */
	private int queryIndex;
	/** 总数 */
	private int totalNums;
	/** 邮件列表 */
	private MailInfoData[] mailInfos;

	public GCMailList ()
	{
	}

	protected override void ReadImpl()
	{
	// 邮箱类型1-inbox,2-sended,3-savebox
	int _boxType = ReadInt();
	// 查询的页面索引
	int _queryIndex = ReadInt();
	// 总数
	int _totalNums = ReadInt();

	// 邮件列表
	int mailInfosSize = ReadShort();
	MailInfoData[] _mailInfos = new MailInfoData[mailInfosSize];
	int mailInfosIndex = 0;
	MailInfoData _mailInfosTmp = null;
	for(mailInfosIndex=0; mailInfosIndex<mailInfosSize; mailInfosIndex++){
		_mailInfosTmp = new MailInfoData();
		_mailInfos[mailInfosIndex] = _mailInfosTmp;
	// 邮件的唯一标识
	string _mailInfos_uuid = ReadString();	_mailInfosTmp.uuid = _mailInfos_uuid;
		// 邮件的标题
	string _mailInfos_title = ReadString();	_mailInfosTmp.title = _mailInfos_title;
		// 发送玩家名称
	string _mailInfos_senderName = ReadString();	_mailInfosTmp.senderName = _mailInfos_senderName;
		// 接收玩家名称
	string _mailInfos_recName = ReadString();	_mailInfosTmp.recName = _mailInfos_recName;
		// 邮件的内容
	string _mailInfos_content = ReadString();	_mailInfosTmp.content = _mailInfos_content;
		// 邮件类型
	int _mailInfos_mailType = ReadInt();	_mailInfosTmp.mailType = _mailInfos_mailType;
		// 邮件状态
	int _mailInfos_mailStatus = ReadInt();	_mailInfosTmp.mailStatus = _mailInfos_mailStatus;
		// 是否有附件，0没有，1有
	int _mailInfos_attachmented = ReadInt();	_mailInfosTmp.attachmented = _mailInfos_attachmented;
		// 发送时间
	string _mailInfos_createTime = ReadString();	_mailInfosTmp.createTime = _mailInfos_createTime;
		// 删除时间
	string _mailInfos_deleteTime = ReadString();	_mailInfosTmp.deleteTime = _mailInfos_deleteTime;
		// 最后更新时间
	long _mailInfos_updateTime = ReadLong();	_mailInfosTmp.updateTime = _mailInfos_updateTime;
		// 附件奖励信息
	RewardInfoData _mailInfos_rewardInfo = new RewardInfoData();
	// 奖励信息
	string _mailInfos_rewardInfo_rewardStr = ReadString();	_mailInfos_rewardInfo.rewardStr = _mailInfos_rewardInfo_rewardStr;
	_mailInfosTmp.rewardInfo = _mailInfos_rewardInfo;
		}
	//end



		this.boxType = _boxType;
		this.queryIndex = _queryIndex;
		this.totalNums = _totalNums;
		this.mailInfos = _mailInfos;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MAIL_LIST;
	}
	
	public override string getEventType()
	{
		return MailGCHandler.GCMailListEvent;
	}
	

	public int getBoxType(){
		return boxType;
	}
		

	public int getQueryIndex(){
		return queryIndex;
	}
		

	public int getTotalNums(){
		return totalNums;
	}
		

	public MailInfoData[] getMailInfos(){
		return mailInfos;
	}


}
}