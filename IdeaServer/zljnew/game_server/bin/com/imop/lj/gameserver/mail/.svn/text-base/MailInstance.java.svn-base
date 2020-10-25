package com.imop.lj.gameserver.mail;

import java.sql.Timestamp;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.util.Assert;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.MailEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mail.MailDef.MailStatus;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.reward.Reward;

public class MailInstance implements PersistanceObject<String, MailEntity>, Comparable<MailInstance> {

	/** 邮件的实例UUID */
	private String mailUUID;

	/** 所有者 */
	private Human owner;

	/** 此实例是否在db中 */
	private boolean isInDb;

	/** 邮件的生命期的状态 */
	private final LifeCycle lifeCycle;

	private long ownerId = 0l;

	/** 发送者uuid */
	private long sendId;

	/** 发送者名称 */
	private String sendName;

	/** 接收者uuid */
	private long recId;

	/** 接收者名称 */
	private String recName;

	/** 名称 */
	private String title;

	/** 内容 */
	private String content;

	/** 邮件类型 */
	private MailType mailType;

	/** 邮件状态值{@see MailStatus} */
	private MailStatus mailStatus;

	/** 创建时间 */
	private Timestamp createTime;

	/** 更新时间 */
	private Timestamp updateTime;

	private Reward attachmentReward;

	private MailInstance(Human owner) {
		lifeCycle = new LifeCycleImpl(this);
		this.owner = owner;
	}

	/**
	 * 创建一个激活的邮件对象,例如从库中读取
	 * 
	 * 
	 * @param owner
	 * @return
	 */
	public static MailInstance newActivatedInstance(Human owner) {
		Assert.notNull(owner);
		MailInstance mail = new MailInstance(owner);
		mail.setOwnerId(owner.getCharId());
		mail.setMailUUID(KeyUtil.UUIDKey());
		mail.setCreateTime(new Timestamp(Globals.getTimeService().now()));
		mail.lifeCycle.activate();
		return mail;
	}

	/**
	 * 创建不绑定所有者的邮件，创建时默认是未激活状态，即不会出现在游戏世界中，也不会对应数据库中的记录
	 * 
	 * @param human
	 * @return
	 */
	public static MailInstance newDeactivedInstanceWithoutOwner() {
		MailInstance mail = new MailInstance(null);
		mail.lifeCycle.deactivate();
		mail.setMailUUID(KeyUtil.UUIDKey());
		mail.setCreateTime(new Timestamp(Globals.getTimeService().now()));
		return mail;
	}

	/**
	 * 从ItemEntity生成一个item实例
	 * 
	 * @param entity
	 * @return
	 */
	public static MailInstance buildFromItemEntity(MailEntity entity, Human owner) {
		MailInstance mail = new MailInstance(owner);
		mail.fromEntity(entity);
		return mail;
	}

//	/**
//	 * 邮件数据加载完成后进行数据的校验,只有校验通过的邮件才会加载,过期邮件删除
//	 * 
//	 * @return true,数据正常,校验通过;false,数据异常,校验未通过
//	 */
//	public boolean validateOnLoaded(MailEntity mailInfo) {
//		if (this.getOwnerId() == 0l || this.getMailType() == null || this.getCreateTime() == null || this.getMailStatus() == null) {
//			onDelete();
//			if (Loggers.mailLogger.isWarnEnabled()) {
//				Loggers.mailLogger.error(LogUtils.buildLogInfoStr(getCharId() + "",
//						String.format("[Found inValid mail from db mail=%s", this.toString())));
//			}
//
//			return false;
//		}
//
//		if (isExpired(Globals.getTimeService().now())) {
//			onDelete();
//			if (Loggers.mailLogger.isWarnEnabled()) {
//				Loggers.mailLogger.error(LogUtils.buildLogInfoStr(getCharId() + "",
//						String.format("[Found inValid mail from db mail=%s", this.toString())));
//			}
//			return false;
//		}
//		return true;
//	}

	@Override
	public void fromEntity(MailEntity entity) {
		this.setDbId(entity.getId());
		if (this.getOwner() != null) {
			this.setOwnerId(this.getOwner().getUUID());
		}
		this.setSendId(entity.getSendId());
		this.setSendName(entity.getSendName());
		this.setRecId(entity.getRecId());
		this.setRecName(entity.getRecName());
		this.setTitle(entity.getTitle());
		this.setContent(entity.getContent());
		this.setMailType(MailType.valueOf(entity.getMailType()));
		this.setMailStatus(MailStatus.valueOf(entity.getMailStatus()));
		this.setCreateTime(entity.getCreateTime());
		this.setUpdateTime(entity.getUpdateTime());
		String attachmentProps = entity.getAttachmentProps();
		if (attachmentProps != null && !attachmentProps.equalsIgnoreCase("")) {
			attachmentReward = Reward.fromJsonStr(attachmentProps);
		}
	}

	public boolean hasAttachment() {
		if (attachmentReward == null || attachmentReward.isNull()) {
			return false;
		}
		return true;
	}

	@Override
	public MailEntity toEntity() {
		MailEntity mailEntity = new MailEntity();
		mailEntity.setId(this.getMailUUID());
		mailEntity.setCharId(this.getCharId());
		mailEntity.setSendId(this.getSendId());
		mailEntity.setSendName(this.getSendName());
		mailEntity.setRecId(this.getRecId());
		mailEntity.setRecName(this.getRecName());
		mailEntity.setTitle(this.getTitle());
		mailEntity.setContent(this.getContent());
		mailEntity.setMailType(this.getMailType().getIndex());
		mailEntity.setMailStatus(this.getMailStatus().getIndex());
		mailEntity.setCreateTime(this.getCreateTime());
		mailEntity.setUpdateTime(this.getUpdateTime());
		if (attachmentReward == null || attachmentReward.isNull()) {
			mailEntity.setAttachmentProps("");
		} else {
			mailEntity.setAttachmentProps(attachmentReward.toJsonObj().toString());
		}
		return mailEntity;
	}

	@Override
	public long getCharId() {
		return ownerId;
	}

	@Override
	public String getGUID() {
		return this.mailUUID;
	}

	@Override
	public String getDbId() {
		return this.mailUUID;
	}

	@Override
	public void setDbId(String id) {
		this.mailUUID = id;
	}

	@Override
	public LifeCycle getLifeCycle() {
		return lifeCycle;
	}

	@Override
	public boolean isInDb() {
		return isInDb;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.isInDb = inDb;
	}

	@Override
	public void setModified() {
		if (owner != null) {
			this.lifeCycle.checkModifiable();
			if (this.lifeCycle.isActive()) {
				// 邮件的生命期处于活动状态,则执行通知更新机制进行
				this.onUpdate();
			}
		}
	}

	public String getMailUUID() {
		return mailUUID;
	}

	public void setMailUUID(String mailUUID) {
		this.mailUUID = mailUUID;
	}

	public Human getOwner() {
		return owner;
	}

	public void setOwner(Human owner) {
		this.owner = owner;
		setModified();
	}

	public long getOwnerId() {
		return ownerId;
	}

	public void setOwnerId(long ownerId) {
		this.ownerId = ownerId;
		setModified();
	}

	public long getSendId() {
		return sendId;
	}

	public void setSendId(long sendId) {
		this.sendId = sendId;
		setModified();
	}

	public String getSendName() {
		return sendName;
	}

	public void setSendName(String sendName) {
		this.sendName = sendName;
		setModified();
	}

	public long getRecId() {
		return recId;
	}

	public void setRecId(long recId) {
		this.recId = recId;
		setModified();
	}

	public String getRecName() {
		return recName;
	}

	public void setRecName(String recName) {
		this.recName = recName;
		setModified();
	}

	public String getTitle() {
		return title;
	}

	public void setTitle(String title) {
		this.title = title;
		setModified();
	}

	public String getContent() {
		return content;
	}

	public void setContent(String content) {
		this.content = content;
		setModified();
	}

	public MailType getMailType() {
		return mailType;
	}

	public void setMailType(MailType mailType) {
		this.mailType = mailType;
		setModified();
	}

	public MailStatus getMailStatus() {
		return mailStatus;
	}

	public void setMailStatus(MailStatus mailStatus) {
		this.mailStatus = mailStatus;
		setModified();
	}

	public Timestamp getCreateTime() {
		return createTime;
	}

	public void setCreateTime(Timestamp createTime) {
		this.createTime = createTime;
		setModified();
	}

	public Timestamp getUpdateTime() {
		return updateTime;
	}

	public void setUpdateTime(Timestamp updateTime) {
		this.updateTime = updateTime;
		setModified();
	}
	
	/**
	 * 获取邮件过期时间
	 * @return
	 */
	public long getExpiredTime() {
		long validityExpireTime = TimeUtils.getDeadLine(getCreateTime(), 
				Globals.getGameConstants().getMailInInboxExpiredTime(), TimeUtils.HOUR);
		return validityExpireTime;
	}

	public boolean isHasAttachment() {
		if (attachmentReward == null || attachmentReward.isNull()) {
			return false;
		} 
		return true;
	}

	public boolean isUnread() {
		return this.getMailStatus() == MailStatus.UNREAD;
	}

	public boolean isReaded() {
		return this.getMailStatus() == MailStatus.READED;
	}

	public boolean isSaved() {
		return this.getMailStatus() == MailStatus.SAVED;
	}

	public boolean isSended() {
		return this.getMailStatus() == MailStatus.SENDED;
	}
	
	public Reward getAttachmentReward() {
		return attachmentReward;
	}

	public void setAttachmentReward(Reward attachmentReward) {
		this.attachmentReward = attachmentReward;
		this.setModified();
	}

	/**
	 * 邮件实例被修改(新增加或者属性更新)时调用,触发更新机制
	 */
	private void onUpdate() {
		if (Loggers.mailLogger.isDebugEnabled()) {
			Loggers.mailLogger.debug(String.format("update mail=%s ", this.toString()));
		}
		this.getOwner().getPlayer().getDataUpdater().addUpdate(this.getLifeCycle());
	}

	/**
	 * 邮件被删除时调用,恢复默认值,并触发删除机制
	 * 
	 */
	public void onDelete() {
		this.lifeCycle.destroy();
		if (Loggers.mailLogger.isDebugEnabled()) {
			Loggers.mailLogger.debug(String.format("delete item=%s ", this.toString()));
		}
		this.getOwner().getPlayer().getDataUpdater().addDelete(this.getLifeCycle());
	}
	
	public void active() {
		this.lifeCycle.activate();
	}

	@Override
	public int hashCode() {
		return mailUUID.hashCode();
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		MailInstance other = (MailInstance) obj;
		if (!mailUUID.equals(other.mailUUID))
			return false;
		return true;
	}

	@Override
	public String toString() {
		return "MailInstance [UUID=" + mailUUID + ", owner=" + owner + ", isInDb=" + isInDb + ", lifeCycle=" + lifeCycle + ", ownerId=" + ownerId
				+ ", sendId=" + sendId + ", sendName=" + sendName + ", recId=" + recId + ", recName=" + recName + ", title=" + title + ", content="
				+ content + ", mailType=" + mailType.getIndex() + ", mailStatus=" + mailStatus + ", createTime=" + createTime + ", updateTime="
				+ updateTime + "]";
	}

	/**
	 * 被传入邮件的创建时间更早,返回负数,在treeSet中更靠后
	 */
	@Override
	public int compareTo(MailInstance other) {
		Timestamp currTime = this.getCreateTime();
		Timestamp otherTime = other.getCreateTime();
		return otherTime.compareTo(currTime);
	}

}
