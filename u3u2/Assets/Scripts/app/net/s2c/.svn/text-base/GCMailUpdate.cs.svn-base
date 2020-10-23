
using System;
namespace app.net
{
/**
 * 单个邮件更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMailUpdate :BaseMessage
{
	/** 邮件 */
	private MailInfoData mail;

	public GCMailUpdate ()
	{
	}

	protected override void ReadImpl()
	{
	// 邮件
	MailInfoData _mail = new MailInfoData();
	// 邮件的唯一标识
	string _mail_uuid = ReadString();	_mail.uuid = _mail_uuid;
	// 邮件的标题
	string _mail_title = ReadString();	_mail.title = _mail_title;
	// 发送玩家名称
	string _mail_senderName = ReadString();	_mail.senderName = _mail_senderName;
	// 接收玩家名称
	string _mail_recName = ReadString();	_mail.recName = _mail_recName;
	// 邮件的内容
	string _mail_content = ReadString();	_mail.content = _mail_content;
	// 邮件类型
	int _mail_mailType = ReadInt();	_mail.mailType = _mail_mailType;
	// 邮件状态
	int _mail_mailStatus = ReadInt();	_mail.mailStatus = _mail_mailStatus;
	// 是否有附件，0没有，1有
	int _mail_attachmented = ReadInt();	_mail.attachmented = _mail_attachmented;
	// 发送时间
	string _mail_createTime = ReadString();	_mail.createTime = _mail_createTime;
	// 删除时间
	string _mail_deleteTime = ReadString();	_mail.deleteTime = _mail_deleteTime;
	// 最后更新时间
	long _mail_updateTime = ReadLong();	_mail.updateTime = _mail_updateTime;
	// 附件奖励信息
	RewardInfoData _mail_rewardInfo = new RewardInfoData();
	// 奖励信息
	string _mail_rewardInfo_rewardStr = ReadString();	_mail_rewardInfo.rewardStr = _mail_rewardInfo_rewardStr;
	_mail.rewardInfo = _mail_rewardInfo;



		this.mail = _mail;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MAIL_UPDATE;
	}
	
	public override string getEventType()
	{
		return MailGCHandler.GCMailUpdateEvent;
	}
	

	public MailInfoData getMail(){
		return mail;
	}
		

}
}