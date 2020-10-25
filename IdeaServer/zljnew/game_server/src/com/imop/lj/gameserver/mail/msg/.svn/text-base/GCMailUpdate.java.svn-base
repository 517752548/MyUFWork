package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 单个邮件更新
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMailUpdate extends GCMessage{
	
	/** 邮件 */
	private com.imop.lj.common.model.mail.MailInfo mail;

	public GCMailUpdate (){
	}
	
	public GCMailUpdate (
			com.imop.lj.common.model.mail.MailInfo mail ){
			this.mail = mail;
	}

	@Override
	protected boolean readImpl() {
	// 邮件
	com.imop.lj.common.model.mail.MailInfo _mail = new com.imop.lj.common.model.mail.MailInfo();

	// 邮件的唯一标识
	String _mail_uuid = readString();
	//end
	_mail.setUuid (_mail_uuid);

	// 邮件的标题
	String _mail_title = readString();
	//end
	_mail.setTitle (_mail_title);

	// 发送玩家名称
	String _mail_senderName = readString();
	//end
	_mail.setSenderName (_mail_senderName);

	// 接收玩家名称
	String _mail_recName = readString();
	//end
	_mail.setRecName (_mail_recName);

	// 邮件的内容
	String _mail_content = readString();
	//end
	_mail.setContent (_mail_content);

	// 邮件类型
	int _mail_mailType = readInteger();
	//end
	_mail.setMailType (_mail_mailType);

	// 邮件状态
	int _mail_mailStatus = readInteger();
	//end
	_mail.setMailStatus (_mail_mailStatus);

	// 是否有附件，0没有，1有
	int _mail_attachmented = readInteger();
	//end
	_mail.setAttachmented (_mail_attachmented);

	// 发送时间
	String _mail_createTime = readString();
	//end
	_mail.setCreateTime (_mail_createTime);

	// 删除时间
	String _mail_deleteTime = readString();
	//end
	_mail.setDeleteTime (_mail_deleteTime);

	// 最后更新时间
	long _mail_updateTime = readLong();
	//end
	_mail.setUpdateTime (_mail_updateTime);
	// 附件奖励信息
	com.imop.lj.common.model.reward.RewardInfo _mail_rewardInfo = new com.imop.lj.common.model.reward.RewardInfo();

	// 奖励信息
	String _mail_rewardInfo_rewardStr = readString();
	//end
	_mail_rewardInfo.setRewardStr (_mail_rewardInfo_rewardStr);
	_mail.setRewardInfo (_mail_rewardInfo);



		this.mail = _mail;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	String mail_uuid = mail.getUuid ();

	// 邮件的唯一标识
	writeString(mail_uuid);

	String mail_title = mail.getTitle ();

	// 邮件的标题
	writeString(mail_title);

	String mail_senderName = mail.getSenderName ();

	// 发送玩家名称
	writeString(mail_senderName);

	String mail_recName = mail.getRecName ();

	// 接收玩家名称
	writeString(mail_recName);

	String mail_content = mail.getContent ();

	// 邮件的内容
	writeString(mail_content);

	int mail_mailType = mail.getMailType ();

	// 邮件类型
	writeInteger(mail_mailType);

	int mail_mailStatus = mail.getMailStatus ();

	// 邮件状态
	writeInteger(mail_mailStatus);

	int mail_attachmented = mail.getAttachmented ();

	// 是否有附件，0没有，1有
	writeInteger(mail_attachmented);

	String mail_createTime = mail.getCreateTime ();

	// 发送时间
	writeString(mail_createTime);

	String mail_deleteTime = mail.getDeleteTime ();

	// 删除时间
	writeString(mail_deleteTime);

	long mail_updateTime = mail.getUpdateTime ();

	// 最后更新时间
	writeLong(mail_updateTime);

	com.imop.lj.common.model.reward.RewardInfo mail_rewardInfo = mail.getRewardInfo ();

	String mail_rewardInfo_rewardStr = mail_rewardInfo.getRewardStr ();

	// 奖励信息
	writeString(mail_rewardInfo_rewardStr);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MAIL_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MAIL_UPDATE";
	}

	public com.imop.lj.common.model.mail.MailInfo getMail(){
		return mail;
	}
		
	public void setMail(com.imop.lj.common.model.mail.MailInfo mail){
		this.mail = mail;
	}
}