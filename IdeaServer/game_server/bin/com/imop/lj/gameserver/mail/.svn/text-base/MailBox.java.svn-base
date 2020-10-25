package com.imop.lj.gameserver.mail;

import java.util.Iterator;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.HeartBeatListener;
import com.imop.lj.common.LogReasons.MailLogReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.orm.DataAccessException;
import com.imop.lj.core.util.Assert;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.db.model.MailEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.RoleDataHolder;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutor;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutorImpl;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;

public class MailBox implements RoleDataHolder, HeartBeatListener {
	/** 邮件所属的玩家 */
	private final Human owner;

	/** 所有邮件 */
	private Map<String, MailInstance> allMails;

	/** 收件箱[全部] */
	private List<MailInstance> inBox;

	/** 发件箱 */
	private List<MailInstance> sendedBox;

	/** 保存箱 */
	private List<MailInstance> saveBox;

	/** 心跳任务处理器 */
	private HeartbeatTaskExecutor hbTaskExecutor;

	public MailBox(Human owner) {
		this.owner = owner;
		this.allMails = Maps.newLinkedHashMap();
		this.inBox = Lists.newLinkedList();
		this.saveBox = Lists.newLinkedList();
		this.sendedBox = Lists.newLinkedList();
		hbTaskExecutor = new HeartbeatTaskExecutorImpl();
		// 增加邮件过期检查
		hbTaskExecutor.submit(new MailExpiredProcessor(owner));
	}

	public void load() {
		// 从数据库加载邮件
		loadAllMailsFromDB(this);
	}

	/**
	 * 从数据库中加载玩家的所有物品
	 * 
	 * @param taskInfo
	 */
	protected void loadAllMailsFromDB(MailBox mailbox) {
		Assert.notNull(mailbox);
		long uuid = mailbox.getOwner().getUUID();
		try {
			List<MailEntity> mails = Globals.getDaoService().getMailDao().getMailsByCharId(uuid);
			for (MailEntity entity : mails) {
				MailInstance mail = MailInstance.buildFromItemEntity(entity, mailbox.getOwner());
				mail.setInDb(true);
				// 激活
				mail.active();
				// 加入相应的分组中
				putMail(mail);
			}
		} catch (DataAccessException e) {
			if (Loggers.mailLogger.isErrorEnabled()) {
				Loggers.mailLogger.error(LogUtils.buildLogInfoStr(mailbox.getOwner().getUUID() + "", "从数据库中加载邮件信息出错"), e);
			}
			return;
		}
	}
	
	/**
	 * 检查邮件是否过期，过期则删除
	 */
	public void checkMail() {
		// 检查邮件是否过期
		// 检查收件箱
		checkInBox();
		// 检查发件箱
		checkSendedBox();
	}
	
	/**
	 * 检查收件箱
	 * 1、检查是否过期，如果是则删除
	 * 2、检查是否黑名单中的玩家发的，如果是则删除
	 */
	protected void checkInBox() {
		Iterator<MailInstance> inBoxIt = getInbox().iterator();
		for (;inBoxIt.hasNext();) {
			MailInstance instance = inBoxIt.next();
			// 如果邮件已过期，或邮件是黑名单中的玩家发的，则删除
			boolean isExpired = isExpired(instance);
			boolean isBlackSend = Globals.getRelationService().isTargetInBlackList(getOwner(), instance.getSendId());
			if (isExpired || isBlackSend) {
				inBoxIt.remove();
				removeMail(instance);
				// 记录日志
				Globals.getLogService().sendMailLog(owner, MailLogReason.INBOX_EXPIRED_DELETE, 
						"isExpired=" + isExpired + ";isBlackSend" + isBlackSend, instance.getMailUUID(), 
						instance.getSendId() + "", instance.getSendName(), instance.getRecId() + "", instance.getRecName(), 
						instance.getTitle(), instance.getMailStatus().getIndex(), instance.getCreateTime().getTime());
			}
		}
	}
	
	/**
	 * 检查发件箱，如果已过期则删除
	 */
	protected void checkSendedBox() {
		Iterator<MailInstance> sendedBoxIt = getSendedBox().iterator();
		for (;sendedBoxIt.hasNext();) {
			MailInstance instance = sendedBoxIt.next();
			// 如果已过期，则删除
			if (isExpired(instance)) {
				sendedBoxIt.remove();
				removeMail(instance);
				// 记录日志
				Globals.getLogService().sendMailLog(owner, MailLogReason.SENDEDBOX_EXPIRED_DELETE, "", instance.getMailUUID(), 
						instance.getSendId() + "", instance.getSendName(), instance.getRecId() + "", instance.getRecName(), 
						instance.getTitle(), instance.getMailStatus().getIndex(), instance.getCreateTime().getTime());
			}
		}
	}
	
	/**
	 * 邮件是否过期，不针对保存箱中的邮件
	 * @param instance
	 * @return
	 */
	public boolean isExpired(MailInstance instance) {
		// 已保存邮件没有过期时间，按照数量限制
		if (!instance.isSaved()) {
			long validityExpireTime = instance.getExpiredTime();
			long now = Globals.getTimeService().now();
			if (now >= validityExpireTime) {
				return true;
			} 
		}
		return false;
	}

	/**
	 * 是否有新邮件
	 * 
	 * @return
	 */
	public boolean hasNewMail() {
		for (MailInstance mail : this.getInbox()) {
			if (mail.isUnread()) {
				return true;
			}
		}
		return false;
	}
	
	/**
	 * 获取未读邮件的数量
	 * @return
	 */
	public int getUnReadMailNum() {
		int num = 0;
		for (MailInstance mail : this.getInbox()) {
			if (mail.isUnread()) {
				num++;
			}
		}
		return num;
	}

	/**
	 * 
	 * 邮件接受，并通知客户端
	 * 
	 * @param mail
	 */
	public void receiveMail(MailInstance mailInst) {
		if (mailInst == null) {
			return;
		}
		if (putMail(mailInst)) {
			// 按钮变化
			Globals.getFuncService().onFuncChanged(getOwner(), FuncTypeEnum.MAIL);
		}
	}
	
//	public void noticeMailUpdate(MailInstance mailInst) {
//		GCMailUpdate gcMailUpdate = new GCMailUpdate();
//		gcMailUpdate.setMail(MailMsgBuilder.createMailInfo(mailInst));
//		this.getOwner().sendMessage(gcMailUpdate);
//	}

	/**
	 * 往对应的数据结构中放入邮件
	 * @param mail
	 * @return
	 */
	protected boolean putMail(MailInstance mail) {
		// 如果已经有了这个邮件，就不再处理了
		if (hasMail(mail)) {
			return false;
		}
		
		boolean flag = false;
		// 加入相应的分组
		if (!mail.isSended()) {
			if (mail.isSaved()) {
				flag = addToSavebox(mail);
			} else {
				flag = addToInBox(mail);
			}
		}else{
			flag = addToSendedBox(mail);
		}
		if (flag) {
			// 加入所有邮件map
			addToAllMails(mail);
		}
		return flag;
	}

	@Override
	public void onHeartBeat() {
		hbTaskExecutor.onHeartBeat();
	}

	public Human getOwner() {
		return owner;
	}
	
	protected void removeMailFromSendedBox(MailInstance mailInstance) {
		sendedBox.remove(mailInstance);
	}
	
	protected void removeMailFromSavebox(MailInstance mailInstance) {
		saveBox.remove(mailInstance);
	}

	public void removeMailFromInbox(MailInstance mailInstance) {
		inBox.remove(mailInstance);
	}
	
	protected void addMailToInBox(MailInstance mailInstance) {
		inBox.add(0, mailInstance);
	}
	
	protected MailInstance removeOldestFromInBox() {
		return inBox.remove(getInbox().size() - 1);
	}
	
	public MailInstance getMailByUUID(String uuid) {
		return allMails.get(uuid);
	}
	
	public boolean hasMail(MailInstance mail) {
		return allMails.containsKey(mail.getMailUUID());
	}
	
	protected void removeMailFromAllMailBox(String uuid) {
		allMails.remove(uuid);
	}
	
	protected void addToAllMails(MailInstance mail) {
		allMails.put(mail.getMailUUID(), mail);
	}
	
	protected void removeMail(MailInstance instance) {
		removeMailFromAllMailBox(instance.getMailUUID());
		instance.onDelete();
	}

	protected boolean addToInBox(MailInstance mailInstance) {
		if (!isInBoxReachMaxNum()) {
			// 收件箱未满，直接加进去
			addMailToInBox(mailInstance);
			return true;
		}
		
		MailInstance delInstance = null;
		// 当收件箱已满，则删除最早的没有附件的邮件
		List<MailInstance> inBoxMails = getInbox();
		for (int i = inBoxMails.size() - 1; i >= 0; i--) {
			MailInstance instance = inBoxMails.get(i);
			if (!instance.hasAttachment()) {
				delInstance = instance;
				break;
			}
		}
		if (delInstance != null) {
			removeMailFromInbox(delInstance);
			removeMail(delInstance);
			addMailToInBox(mailInstance);
			// 记录日志
			Globals.getLogService().sendMailLog(owner, MailLogReason.INBOX_DELETE_ON_FULL, 
					"recvMailInstanceUUID=" + mailInstance.getMailUUID(), delInstance.getMailUUID(), 
					delInstance.getSendId() + "", delInstance.getSendName(), delInstance.getRecId() + "", delInstance.getRecName(), 
					delInstance.getTitle(), delInstance.getMailStatus().getIndex(), delInstance.getCreateTime().getTime());
			return true;
		}
		
		// 如果全都有附件，则看本封邮件是否有附件，如果没有则不收了
		if (!mailInstance.hasAttachment()) {
			// 记录日志
			Globals.getLogService().sendMailLog(owner, MailLogReason.INBOX_DELETE_ON_FULL_ALL_HAS_ATTACHMENT, "", mailInstance.getMailUUID(), 
					mailInstance.getSendId() + "", mailInstance.getSendName(), mailInstance.getRecId() + "", mailInstance.getRecName(), 
					mailInstance.getTitle(), mailInstance.getMailStatus().getIndex(), mailInstance.getCreateTime().getTime());
			return false;
		}
		
		// 如果全都有附件，则删除最早的一封
		delInstance = removeOldestFromInBox();
		if (delInstance != null) {
			removeMail(delInstance);
			addMailToInBox(mailInstance);
			// 记录日志
			Globals.getLogService().sendMailLog(owner, MailLogReason.INBOX_DELETE_BY_TIME_ON_FULL, 
					"recvMailInstanceUUID=" + mailInstance.getMailUUID(), delInstance.getMailUUID(), 
					delInstance.getSendId() + "", delInstance.getSendName(), delInstance.getRecId() + "", delInstance.getRecName(), 
					delInstance.getTitle(), delInstance.getMailStatus().getIndex(), delInstance.getCreateTime().getTime());
			return true;
		}
		return false;
	}
	
	protected boolean addToSendedBox(MailInstance mailInstance) {
		// 如果超过上限，则删除最早的数据
		if (isSendedBoxReachMaxNum()) {
			int delIndex = getSendedBox().size() - 1;
			MailInstance delInstance = sendedBox.get(delIndex);
			removeMailFromSendedBox(delInstance);
			removeMail(delInstance);
			// 记录日志
			Globals.getLogService().sendMailLog(owner, MailLogReason.SENDEDBOX_DELETE_BY_TIME_ON_FULL, 
					"recvMailInstanceUUID=" + mailInstance.getMailUUID(), delInstance.getMailUUID(), 
					delInstance.getSendId() + "", delInstance.getSendName(), delInstance.getRecId() + "", delInstance.getRecName(), 
					delInstance.getTitle(), delInstance.getMailStatus().getIndex(), delInstance.getCreateTime().getTime());
			
		}
		sendedBox.add(0, mailInstance);
		return true;
	}

	public boolean addToSavebox(MailInstance mailInstance) {
		// 如果超过上限，则删除最早的数据
		if (isSaveBoxReachMaxNum()) {
			MailInstance delInstance = saveBox.get(0);
			removeMailFromSavebox(delInstance);
			removeMail(delInstance);
			// 记录日志
			Globals.getLogService().sendMailLog(owner, MailLogReason.SAVEBOX_DELETE_BY_TIME_ON_FULL, 
					"recvMailInstanceUUID=" + mailInstance.getMailUUID(), delInstance.getMailUUID(), 
					delInstance.getSendId() + "", delInstance.getSendName(), delInstance.getRecId() + "", delInstance.getRecName(), 
					delInstance.getTitle(), delInstance.getMailStatus().getIndex(), delInstance.getCreateTime().getTime());
			
		}
		return saveBox.add(mailInstance);
	}
	
	public void onMailSended(MailInstance mail) {
		addToAllMails(mail);
		addToSendedBox(mail);
	}
	
	public void removeOneMail(MailInstance mailInstance) {
		// 从分组中删除邮件
		removeMailFromInbox(mailInstance);
		removeMailFromSavebox(mailInstance);
		removeMailFromSendedBox(mailInstance);
		// 删除邮件
		removeMail(mailInstance);
	}

	public boolean isInBoxReachMaxNum() {
		int curNum = getInbox().size();
		if (curNum >= Globals.getGameConstants().getMailInBoxMaxCount()) {
			return true;
		}
		return false;
	}
	
	public boolean isSendedBoxReachMaxNum() {
		int curNum = getSendedBox().size();
		if (curNum >= Globals.getGameConstants().getMailSendedBoxMaxCount()) {
			return true;
		}
		return false;
	}

	public boolean isSaveBoxReachMaxNum() {
		int curNum = getSavebox().size();
		if (curNum >= Globals.getGameConstants().getMailSaveBoxMaxCount()) {
			return true;
		}
		return false;
	}
	
	public int getSaveBoxLeftNum() {
		int leftNum = Globals.getGameConstants().getMailSaveBoxMaxCount() - getSavebox().size();
		if (leftNum < 0) {
			leftNum = 0;
		}
		return leftNum;
	}
	
	public List<MailInstance> getInbox() {
		return inBox;
	}

	public List<MailInstance> getSavebox() {
		return saveBox;
	}

	public List<MailInstance> getSendedBox() {
		return sendedBox;
	}
	
	@Override
	public void checkAfterRoleLoad() {
		
	}

	@Override
	public void checkBeforeRoleEnter() {

	}
}
