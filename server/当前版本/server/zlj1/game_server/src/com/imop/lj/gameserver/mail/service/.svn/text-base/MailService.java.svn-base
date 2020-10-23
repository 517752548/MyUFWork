package com.imop.lj.gameserver.mail.service;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.PageUtil;
import com.imop.lj.gameserver.common.PageUtil.PageResult;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corps.model.CorpsMember;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.ItemParam;
import com.imop.lj.gameserver.mail.MailBox;
import com.imop.lj.gameserver.mail.MailDef;
import com.imop.lj.gameserver.mail.MailDef.BoxType;
import com.imop.lj.gameserver.mail.MailDef.MailStatus;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.mail.MailInstance;
import com.imop.lj.gameserver.mail.async.SaveMailOperation;
import com.imop.lj.gameserver.mail.confirmhandler.DelMailStaticHandler;
import com.imop.lj.gameserver.mail.msg.MailMsgBuilder;
import com.imop.lj.gameserver.mail.msg.SysReceiveMailFinish;
import com.imop.lj.gameserver.player.IStaticHandler;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.List;
import java.util.Map.Entry;

public class MailService implements InitializeRequired {

	public MailService() {
		
	}

	@Override
	public void init() {
		
	}

	/**
	 * 发送系统邮件,一般为系统触发,只有系统有附件
	 * 
	 * @param recId
	 * @param mailType
	 * @param title
	 * @param content
	 */
	public void sendSysMail(long recId, MailType mailType, String title, String content,Reward reward) {
		if (mailType != MailType.SYSTEM) {
			return;
		}

		MailInstance mailInstance = createMail(recId, MailDef.SYSTEM_MAIL_SEND_ID, getSystemSenderName(), "", mailType, title, content,reward);

		// 如果玩家在线，则用playerDataUpdater存库，否则创建operation存库
		if (!onlineSaveMail(mailInstance, false)) {
			SaveMailOperation saveTask = new SaveMailOperation(mailInstance);
			Globals.getAsyncService().createOperationAndExecuteAtOnce(saveTask);
		}
	}

	/**
	 * 发送军团邮件
	 * 
	 * @param sender
	 * @param content
	 */
	public void sendCorpsMail(Human sender, Corps corps, String title, String content) {
		if (corps == null) {
			return;
		}
		// 保存到自己的发件箱 *这里修改,现在玩家没有自己的发件箱,加入但是前端不显示
		MailInstance selfSended = createMailSended(sender, 0, "", getGuildSenderName(), content);
		sender.getMailbox().onMailSended(selfSended);
		
		title = title == null || title.isEmpty() ? getGuildSenderName() : title;
		for (CorpsMember member : corps.getCorpsMemberManager().getCorpsMemberList()) {
			MailInstance mailInstance = createMail(member.getRoleId(),	sender.getUUID(), 
					sender.getName(), member.getName(), MailType.GROUP, title, content, null);
			// 如果玩家在线，则用playerDataUpdater存库，否则创建operation存库
			if (!onlineSaveMail(mailInstance, false)) {
				SaveMailOperation saveTask = new SaveMailOperation(mailInstance);
				Globals.getAsyncService().createOperationAndExecuteAtOnce(saveTask);
			}
		}
	}
	
	/**
	 * 发送单封军团邮件
	 * 
	 * @param recId
	 * @param title
	 * @param content
	 */
	public void sendSingleCorpsMail(long recId, String recName, String title, String content, Reward reward) {
		MailInstance mailInstance = createMail(recId, MailDef.GUILD_MAIL_SEND_ID, 
				getSystemSenderName(), recName, MailType.GROUP, getGuildSenderName(), content, reward);
		// 如果玩家在线，则用playerDataUpdater存库，否则创建operation存库
		if (!onlineSaveMail(mailInstance, false)) {
			SaveMailOperation saveTask = new SaveMailOperation(mailInstance);
			Globals.getAsyncService().createOperationAndExecuteAtOnce(saveTask);
		}
	}

	/**
	 * 发送普通邮件，一对一
	 * 
	 * @param sender
	 * @param recId
	 * @param recName
	 * @param title
	 * @param content
	 */
	public void sendMail(Human sender, long recId, String recName, String title, String content) {
		// 保存到自己的发件箱
		MailInstance selfSended = createMailSended(sender, recId, recName, title, content);
		sender.getMailbox().onMailSended(selfSended);
		
		// 如果接收玩家在线，则用playerDataUpdater存库，否则创建operation存库
		MailInstance mailInstance = createMail(recId, sender.getUUID(), sender.getName(), recName, MailType.NORMAL, title, content, null);
		if (!onlineSaveMail(mailInstance, false)) {
			SaveMailOperation saveTask = new SaveMailOperation(mailInstance);
			Globals.getAsyncService().createOperationAndExecuteAtOnce(saveTask);
		}
	}
	
	/**
	 * 如果玩家在线，则用playerDataUpdater存库，并更新内存数据
	 * @param mailInstance
	 * @return
	 */
	public boolean onlineSaveMail(MailInstance mailInstance, boolean hasSaved) {
		long ownerId = mailInstance.getOwnerId();
		Player player = Globals.getOnlinePlayerService().getPlayer(ownerId);
		if (player != null && player.getHuman() != null && player.getHuman().getMailbox() != null) {
			// 如果还未存库，玩家必须在场景中，才能保证能存储成功
			if (hasSaved || (!hasSaved && player.isInScene())) {
				mailInstance.setOwner(player.getHuman());
				SysReceiveMailFinish mailreceivedmsg = new SysReceiveMailFinish(mailInstance);
				player.putMessage(mailreceivedmsg);
				return true;
			}
		}
		return false;
	}
	
	/**
	 * 添加一个mail数据的方法，仅在{@link SysReceiveMailFinish}消息中调用的
	 * @param mailInstance
	 */
	public void addSaveMail(MailInstance mailInstance) {
		if (mailInstance == null || mailInstance.getOwner() == null) {
			// 应该不会走到这里
			Loggers.mailLogger.error("#MailService#addSaveMail#mailInstance is null!mailInstance=" + mailInstance);
			return;
		}
		if (mailInstance.getOwner().getMailbox() == null) {
			Loggers.mailLogger.error("#MailService#addSaveMail#owner mailBox is null!mailInstance=" + mailInstance);
			return;
		}
		
		// 发件人在收件人的黑名单中，则不添加该邮件
		if (Globals.getRelationService().isTargetInBlackList(mailInstance.getOwner(), mailInstance.getSendId())) {
			// 记录警告日志
			Loggers.mailLogger.warn("#MailService#addSaveMail#sender is in receiver blacklist!mailInstance=" + mailInstance);
			return;
		}
		if (!mailInstance.getOwner().getPlayer().isInScene()) {
			// 如果玩家当前没在场景中，则可能该条数据没存库
			Loggers.mailLogger.error("#MailService#addSaveMail#player is not in scene!humanId=" + 
					mailInstance.getOwner().getCharId()+";mailUUID=" + mailInstance.getMailUUID());
		}
		
		Human owner = mailInstance.getOwner();
		// 激活
		mailInstance.getLifeCycle().activate();
		// 存库
		mailInstance.setModified();
		// 加入内存中
		MailBox mailbox = owner.getMailbox();
		mailbox.receiveMail(mailInstance);
	}

	/**
	 * 创建一封发件箱的邮件
	 * @param human
	 * @param recId
	 * @param recName
	 * @param title
	 * @param content
	 * @return
	 */
	protected MailInstance createMailSended(Human human, long recId, String recName, String title, String content) {
		MailInstance mailInstance = MailInstance.newActivatedInstance(human);
		mailInstance.setInDb(false);
		mailInstance.setSendId(human.getUUID());
		mailInstance.setSendName(human.getName());
		mailInstance.setRecId(recId);
		mailInstance.setRecName(recName);
		mailInstance.setMailType(MailType.NORMAL);
		mailInstance.setTitle(title);
		mailInstance.setContent(content);
		mailInstance.setMailStatus(MailStatus.SENDED);
		mailInstance.setUpdateTime(new Timestamp(Globals.getTimeService().now()));
		mailInstance.setAttachmentReward(null);
		return mailInstance;
	}
	
	/**
	 * 创建一封邮件
	 * 
	 * @param recId
	 * @param sendId
	 * @param sendName
	 * @param recName
	 * @param mailType
	 * @param title
	 * @param content
	 * @return
	 */
	protected MailInstance createMail(long recId, long sendId, String sendName, String recName, MailType mailType, String title, String content,Reward attachmentReward) {
		MailInstance mailInstance = MailInstance.newDeactivedInstanceWithoutOwner();
		mailInstance.setInDb(false);
		mailInstance.setOwnerId(recId);
		mailInstance.setSendId(sendId);
		mailInstance.setSendName(sendName);
		mailInstance.setRecId(recId);
		mailInstance.setRecName(recName);
		mailInstance.setMailType(mailType);
		mailInstance.setTitle(title);
		mailInstance.setContent(content);
		mailInstance.setMailStatus(MailStatus.UNREAD);
		mailInstance.setUpdateTime(new Timestamp(Globals.getTimeService().now()));
		mailInstance.setAttachmentReward(attachmentReward);
		return mailInstance;
	}
	
	public String getSystemSenderName() {
		return Globals.getLangService().readSysLang(LangConstants.SYSTEM_MAIL_SENDER_NAME);
	}

	public String getGuildSenderName() {
		return Globals.getLangService().readSysLang(LangConstants.GUILD_MAIL_SENDER_NAME);
	}
	
	///////消息相关/////////
	
	/**
	 * 显示邮件列表
	 */
	public void showMailList(Human human, int page, int boxType) {
		if (human == null) {
			return;
		}

		MailBox mailbox = human.getMailbox();
		if (mailbox == null) {
			return;
		}

		BoxType mailBoxType = BoxType.valueOf(boxType);
		if (mailBoxType == null) {
			return;
		}

		List<MailInstance> mails = null;
		switch (mailBoxType) {
		case INBOX: {
			mails = mailbox.getInbox();
			break;
		}
		case SENDED: {
			mails = mailbox.getSendedBox();
			break;
		}
		case SAVE: {
			mails = mailbox.getSavebox();
			break;
		}
		}
		if (mails == null) {
			return;
		}
		
		// 分页
		PageResult<MailInstance> pageResult = PageUtil.getPageResult(mails, page, getPageNum(human));
		// 给玩家发消息
		human.sendMessage(MailMsgBuilder.buildGCMailList(boxType, page, pageResult.getMaxPage(), pageResult.getResultList()));
	}
	
	public int getPageNum(Human human) {
		int pageNum = Globals.getGameConstants().getMailNumPerPage();
		// 移动端每页数量不一样
		if (human.getPlayer().getCurrTerminalType() != TerminalTypeEnum.WEB) {
			pageNum = Globals.getGameConstants().getMailNumPerPageMobile();
		}
		return pageNum;
	}
	
	/**
	 * 读邮件
	 * @param human
	 * @param mailUUId
	 */
	public void readMail(Human human, String mailUUId) {
		if (human == null || human.getMailbox() == null) {
			return;
		}
		MailBox mailBox = human.getMailbox();
		MailInstance mailInstance = mailBox.getMailByUUID(mailUUId);
		if (mailInstance == null) {
			return;
		}
		
		if (mailInstance.isReaded()) {
			return;
		}
		// 如果是未读邮件，则设为已读
		if (mailInstance.isUnread()) {
			// 设为已读
			mailInstance.setMailStatus(MailStatus.READED);
			// 邮件按钮角标变化
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MAIL);
			// 发消息给玩家
			human.sendMessage(MailMsgBuilder.buildGCMailUpdate(mailInstance));
		}
	}
	
	/**
	 * 保存邮件
	 * @param human
	 * @param uuids
	 */
	public void saveMailBatch(Human human, String[] uuids) {
		if (human == null || human.getMailbox() == null) {
			return;
		}
		
		MailBox mailBox = human.getMailbox();
		// 检查是否可以存下这么多邮件
		if (mailBox.getSaveBoxLeftNum() < uuids.length) {
			human.sendErrorMessage(LangConstants.SAVE_MAIL_BOX_IS_FULL);
			return;
		}
		
		List<MailInstance> valideList = new ArrayList<MailInstance>();
		for (String mailUUID : uuids) {
			MailInstance mailInstance = mailBox.getMailByUUID(mailUUID);
			if (mailInstance == null) {
				continue;
			}
			// 邮件如果是发件箱,不能保存
			if (mailInstance.isSended()) {
				continue;
			}
			// 如果已经保存，不保存
			if (mailInstance.isSaved()) {
				continue;
			}
			// 邮件保存箱已满
			if (mailBox.isSaveBoxReachMaxNum()) {
				human.sendErrorMessage(LangConstants.SAVE_MAIL_BOX_IS_FULL);
				return;
			}
			// 有未领取的附件，不能保存
			if (mailInstance.hasAttachment()) {
				human.sendErrorMessage(LangConstants.MAIL_SAVE_FAILED_HAS_ATTACHMENT);
				return;
			}
			// 合法邮件列表
			valideList.add(mailInstance);
		}
		
		if (valideList.isEmpty()) {
			human.sendErrorMessage(LangConstants.MAIL_SAVE_FAIL_NO_VALIDE);
			return;
		}
		
		// 是否未读邮件
		boolean unRead = false;
		for (MailInstance mailInstance : valideList) {
			// 是否未读邮件
			if (mailInstance.isUnread()) {
				unRead = true;
			}
			// 保存邮件
			mailInstance.setMailStatus(MailStatus.SAVED);
			// 从收件箱删除
			mailBox.removeMailFromInbox(mailInstance);
			// 放入保存箱
			mailBox.addToSavebox(mailInstance);
		}
		
		// 未读邮件变为已保存，角标变化
		if (unRead) {
			// 邮件按钮角标变化
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MAIL);
		}
		human.sendErrorMessage(LangConstants.MAIL_SAVE_OK);
	}
	
	/**
	 * 批量删除邮件
	 * @param human
	 * @param uuids
	 */
	public void delMailBatch(Human human, String[] uuids) {
		if (human == null || human.getMailbox() == null || uuids == null || uuids.length == 0) {
			return;
		}
		
		MailBox mailBox = human.getMailbox();
		// 先检查删除的邮件中是否有带附件的
		boolean hasAttachment = false;
		for (String mailUUID : uuids) {
			MailInstance mailInstance = mailBox.getMailByUUID(mailUUID);
			if (mailInstance == null) {
				continue;
			}
			if (mailInstance.hasAttachment()) {
				hasAttachment = true;
				break;
			}
		}
		
		// 如果有附件，需要二次确认框
		if (hasAttachment) {
			IStaticHandler handler = new DelMailStaticHandler(uuids);
			human.getStaticHandlelHolder().setHandler(handler);
			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), false, 
					LangConstants.MAIL_DEL_HAS_ATTACHMENT_CONFIRM);
			return;
		}
		
		// 删除邮件
		delMailConfirm(human, uuids);
	}
	
	/**
	 * 确认删除邮件
	 * @param human
	 * @param uuids
	 */
	public void delMailConfirm(Human human, String[] uuids) {
		if (human == null || human.getMailbox() == null || uuids == null || uuids.length == 0) {
			return;
		}
		boolean unRead = false;
		MailBox mailBox = human.getMailbox();
		for (String mailUUID : uuids) {
			MailInstance mailInstance = mailBox.getMailByUUID(mailUUID);
			if (mailInstance == null) {
				continue;
			}
			if (mailInstance.isUnread()) {
				unRead = true;
			}
			// 删除邮件
			mailBox.removeOneMail(mailInstance);
		}
		
		if (unRead) {
			// 邮件按钮角标变化
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MAIL);
		}
		// 发消息，删除成功
		human.sendMessage(MailMsgBuilder.buildGCDelMail());
	}
	
	/**
	 * 领取邮件的附件
	 * @param human
	 * @param mailUUId
	 */
	public void getMailAttachment(Human human, String mailUUId) {
		if (human == null || human.getMailbox() == null) {
			return;
		}
		
		MailBox mailBox = human.getMailbox();
		MailInstance mailInstance = mailBox.getMailByUUID(mailUUId);
		if (mailInstance == null) {
			return;
		}
		
		boolean unRead = mailInstance.isUnread();
		if (unRead) {
			mailInstance.setMailStatus(MailStatus.READED);
		}
		Reward reward = mailInstance.getAttachmentReward();
		if(reward != null && !reward.isNull()) {
			//如果有道具奖励，则调用背包的checkSpace，看是否能够都放下，如果放不下，就不让玩家领取了
			if (reward.hasItem()) {
				List<ItemParam> list = new ArrayList<ItemParam>();
				for (Entry<Integer, Integer> entry : reward.getItemMap().entrySet()) {
					list.add(new ItemParam(entry.getKey(), entry.getValue()));
				}
				//背包空间不够全部领取，报错返回
				if (!human.getInventory().checkSpace(list, false)) {
					human.sendErrorMessage(LangConstants.GET_MAIL_ATTACHMENT_FAIL_FULL_BAG);
					return;
				}
			}
			
			//清空附件
			mailInstance.setAttachmentReward(null);
			//给奖励
			boolean flag = Globals.getRewardService().giveReward(human, reward, true);
			if (!flag) {
				// 记录错误日志
				Loggers.mailLogger.warn("#MailService#getMailAttachment#giveReward return false!humanId=" 
						+ human.getUUID() + ";mailInstance=" + mailInstance + ";reward=" + reward);
			}
			// 给玩家发邮件更新的消息
			human.sendMessage(MailMsgBuilder.buildGCMailUpdate(mailInstance));
			// 提示玩家领取附件成功
			human.sendErrorMessage(LangConstants.GET_MAIL_ATTACHMENT_SUCCESS);
			
//			// XXX 参加军团战任务的特殊处理，由于vip5可以离线自动参战，所以做到了领取奖励里面
//			if (reward.getReasonType() == RewardReasonType.CORPSWAR_USER_JOIN || 
//					reward.getReasonType() == RewardReasonType.CORPSWAR_USER_FIGHT) {
//				// 任务监听
//				human.getQuestDiary().getListener().onNumRecordDest(human, NumRecordType.JOIN_CORPS_WAR, 0, 1);
//			}
		} else {
			// 发错误消息，该邮件没有附件
			human.sendErrorMessage(LangConstants.GET_MAIL_ATTACHMENT_ERROR);
		}
		
		if (unRead) {
			// 邮件按钮角标变化
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MAIL);
		}
	}
}
