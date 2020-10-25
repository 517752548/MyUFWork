package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.core.orm.SoftDeleteEntity;

@Entity
@Table(name = "t_mail_info")
@Comment(content="数据库实体类：邮件 ")
public class MailEntity implements BaseEntity<String>, CharSubEntity,SoftDeleteEntity<String> {
	private static final long serialVersionUID = 1L;

	/** 主键 */
	@Comment(content="主键 ")
	private String id;

	/** 所属角色ID */
	@Comment(content="所属角色ID ")
	private long charId;

	/** 发送角色ID */
	@Comment(content="发送角色ID ")
	private Long sendId;

	/** 发送角色名称 */
	@Comment(content="发送角色名称 ")
	private String sendName;

	/** 接收角色ID */
	@Comment(content="接收角色ID ")
	private Long recId;

	/** 接收角色名称 */
	@Comment(content="接收角色名称 ")
	private String recName;

	/** 邮件标题 */
	@Comment(content="邮件标题 ")
	private String title;

	/** 邮件内容 */
	@Comment(content="邮件内容 ")
	private String content;

	/** 邮件类别 */
	@Comment(content="邮件类别 ")
	private int mailType;

	/** 邮件状态 */
	@Comment(content="邮件状态 ")
	private int mailStatus;

//	/** 创建时间[游戏内] */
//	private String createTimeInGame;

	/** 创建时间 */
	@Comment(content="创建时间 ")
	private Timestamp createTime;

	/** 最后更新时间 */
	@Comment(content="最后更新时间  ")
	private Timestamp updateTime;

	/** 是否已删除 */
	@Comment(content="是否已删除  ")
	private int deleted;

	/** 删除时间 */
	@Comment(content="删除时间  ")
	private Timestamp deleteDate;

	/** 附件内容(JSON字符串) */
	@Comment(content="附件内容(JSON字符串)  ")
	private String attachmentProps;

	@Id
	@Override
	@Column(length = 36)
	public String getId() {
		return id;
	}

	@Override
	@Column(columnDefinition = "bigint(20) default 0")
	public long getCharId() {
		return charId;
	}

	@Column(columnDefinition = "bigint(20) default 0")
	public Long getSendId() {
		return sendId;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getSendName() {
		return sendName;
	}

	@Column(columnDefinition = "bigint(20) default 0")
	public Long getRecId() {
		return recId;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getRecName() {
		return recName;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getTitle() {
		return title;
	}

	@Column(columnDefinition = "TEXT")
	public String getContent() {
		return content;
	}

	@Column(columnDefinition = "int(11) default 0")
	public int getMailType() {
		return mailType;
	}

	@Column(columnDefinition = "int(11) default 0")
	public int getMailStatus() {
		return mailStatus;
	}

	@Column
	public Timestamp getCreateTime() {
		return createTime;
	}

	@Column
	public Timestamp getUpdateTime() {
		return updateTime;
	}

	@Column
	@Override
	public int getDeleted() {
		return deleted;
	}

	@Column
	@Override
	public Timestamp getDeleteDate() {
		return deleteDate;
	}

	@Column(columnDefinition = "LONGTEXT")
	public String getAttachmentProps() {
		return attachmentProps;
	}

	@Override
	public void setId(String id) {
		this.id = id;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	public void setSendId(Long sendId) {
		this.sendId = sendId;
	}

	public void setSendName(String sendName) {
		this.sendName = sendName;
	}

	public void setRecId(Long recId) {
		this.recId = recId;
	}

	public void setRecName(String recName) {
		this.recName = recName;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public void setMailType(int mailType) {
		this.mailType = mailType;
	}

	public void setMailStatus(int mailStatus) {
		this.mailStatus = mailStatus;
	}

	public void setCreateTime(Timestamp createTime) {
		this.createTime = createTime;
	}

	public void setUpdateTime(Timestamp updateTime) {
		this.updateTime = updateTime;
	}

	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}

	public void setAttachmentProps(String attachmentProps) {
		this.attachmentProps = attachmentProps;
	}

}
