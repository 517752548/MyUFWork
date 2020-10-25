package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 邮件列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMailList extends GCMessage{
	
	/** 邮箱类型1-inbox,2-sended,3-savebox */
	private int boxType;
	/** 查询的页面索引 */
	private int queryIndex;
	/** 总数 */
	private int totalNums;
	/** 邮件列表 */
	private com.imop.lj.common.model.mail.MailInfo[] mailInfos;

	public GCMailList (){
	}
	
	public GCMailList (
			int boxType,
			int queryIndex,
			int totalNums,
			com.imop.lj.common.model.mail.MailInfo[] mailInfos ){
			this.boxType = boxType;
			this.queryIndex = queryIndex;
			this.totalNums = totalNums;
			this.mailInfos = mailInfos;
	}

	@Override
	protected boolean readImpl() {

	// 邮箱类型1-inbox,2-sended,3-savebox
	int _boxType = readInteger();
	//end


	// 查询的页面索引
	int _queryIndex = readInteger();
	//end


	// 总数
	int _totalNums = readInteger();
	//end


	// 邮件列表
	int mailInfosSize = readUnsignedShort();
	com.imop.lj.common.model.mail.MailInfo[] _mailInfos = new com.imop.lj.common.model.mail.MailInfo[mailInfosSize];
	int mailInfosIndex = 0;
	for(mailInfosIndex=0; mailInfosIndex<mailInfosSize; mailInfosIndex++){
		_mailInfos[mailInfosIndex] = new com.imop.lj.common.model.mail.MailInfo();
	// 邮件的唯一标识
	String _mailInfos_uuid = readString();
	//end
	_mailInfos[mailInfosIndex].setUuid (_mailInfos_uuid);

	// 邮件的标题
	String _mailInfos_title = readString();
	//end
	_mailInfos[mailInfosIndex].setTitle (_mailInfos_title);

	// 发送玩家名称
	String _mailInfos_senderName = readString();
	//end
	_mailInfos[mailInfosIndex].setSenderName (_mailInfos_senderName);

	// 接收玩家名称
	String _mailInfos_recName = readString();
	//end
	_mailInfos[mailInfosIndex].setRecName (_mailInfos_recName);

	// 邮件的内容
	String _mailInfos_content = readString();
	//end
	_mailInfos[mailInfosIndex].setContent (_mailInfos_content);

	// 邮件类型
	int _mailInfos_mailType = readInteger();
	//end
	_mailInfos[mailInfosIndex].setMailType (_mailInfos_mailType);

	// 邮件状态
	int _mailInfos_mailStatus = readInteger();
	//end
	_mailInfos[mailInfosIndex].setMailStatus (_mailInfos_mailStatus);

	// 是否有附件，0没有，1有
	int _mailInfos_attachmented = readInteger();
	//end
	_mailInfos[mailInfosIndex].setAttachmented (_mailInfos_attachmented);

	// 发送时间
	String _mailInfos_createTime = readString();
	//end
	_mailInfos[mailInfosIndex].setCreateTime (_mailInfos_createTime);

	// 删除时间
	String _mailInfos_deleteTime = readString();
	//end
	_mailInfos[mailInfosIndex].setDeleteTime (_mailInfos_deleteTime);

	// 最后更新时间
	long _mailInfos_updateTime = readLong();
	//end
	_mailInfos[mailInfosIndex].setUpdateTime (_mailInfos_updateTime);
	// 附件奖励信息
	com.imop.lj.common.model.reward.RewardInfo _mailInfos_rewardInfo = new com.imop.lj.common.model.reward.RewardInfo();

	// 奖励信息
	String _mailInfos_rewardInfo_rewardStr = readString();
	//end
	_mailInfos_rewardInfo.setRewardStr (_mailInfos_rewardInfo_rewardStr);
	_mailInfos[mailInfosIndex].setRewardInfo (_mailInfos_rewardInfo);
	}
	//end



		this.boxType = _boxType;
		this.queryIndex = _queryIndex;
		this.totalNums = _totalNums;
		this.mailInfos = _mailInfos;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 邮箱类型1-inbox,2-sended,3-savebox
	writeInteger(boxType);


	// 查询的页面索引
	writeInteger(queryIndex);


	// 总数
	writeInteger(totalNums);


	// 邮件列表
	writeShort(mailInfos.length);
	int mailInfosIndex = 0;
	int mailInfosSize = mailInfos.length;
	for(mailInfosIndex=0; mailInfosIndex<mailInfosSize; mailInfosIndex++){

	String mailInfos_uuid = mailInfos[mailInfosIndex].getUuid();

	// 邮件的唯一标识
	writeString(mailInfos_uuid);

	String mailInfos_title = mailInfos[mailInfosIndex].getTitle();

	// 邮件的标题
	writeString(mailInfos_title);

	String mailInfos_senderName = mailInfos[mailInfosIndex].getSenderName();

	// 发送玩家名称
	writeString(mailInfos_senderName);

	String mailInfos_recName = mailInfos[mailInfosIndex].getRecName();

	// 接收玩家名称
	writeString(mailInfos_recName);

	String mailInfos_content = mailInfos[mailInfosIndex].getContent();

	// 邮件的内容
	writeString(mailInfos_content);

	int mailInfos_mailType = mailInfos[mailInfosIndex].getMailType();

	// 邮件类型
	writeInteger(mailInfos_mailType);

	int mailInfos_mailStatus = mailInfos[mailInfosIndex].getMailStatus();

	// 邮件状态
	writeInteger(mailInfos_mailStatus);

	int mailInfos_attachmented = mailInfos[mailInfosIndex].getAttachmented();

	// 是否有附件，0没有，1有
	writeInteger(mailInfos_attachmented);

	String mailInfos_createTime = mailInfos[mailInfosIndex].getCreateTime();

	// 发送时间
	writeString(mailInfos_createTime);

	String mailInfos_deleteTime = mailInfos[mailInfosIndex].getDeleteTime();

	// 删除时间
	writeString(mailInfos_deleteTime);

	long mailInfos_updateTime = mailInfos[mailInfosIndex].getUpdateTime();

	// 最后更新时间
	writeLong(mailInfos_updateTime);

	com.imop.lj.common.model.reward.RewardInfo mailInfos_rewardInfo = mailInfos[mailInfosIndex].getRewardInfo();

	String mailInfos_rewardInfo_rewardStr = mailInfos_rewardInfo.getRewardStr ();

	// 奖励信息
	writeString(mailInfos_rewardInfo_rewardStr);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MAIL_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MAIL_LIST";
	}

	public int getBoxType(){
		return boxType;
	}
		
	public void setBoxType(int boxType){
		this.boxType = boxType;
	}

	public int getQueryIndex(){
		return queryIndex;
	}
		
	public void setQueryIndex(int queryIndex){
		this.queryIndex = queryIndex;
	}

	public int getTotalNums(){
		return totalNums;
	}
		
	public void setTotalNums(int totalNums){
		this.totalNums = totalNums;
	}

	public com.imop.lj.common.model.mail.MailInfo[] getMailInfos(){
		return mailInfos;
	}

	public void setMailInfos(com.imop.lj.common.model.mail.MailInfo[] mailInfos){
		this.mailInfos = mailInfos;
	}	
}