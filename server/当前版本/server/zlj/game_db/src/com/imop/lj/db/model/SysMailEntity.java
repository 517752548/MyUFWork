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
@Table(name = "t_sys_mail")
@Comment(content="数据库实体类：系统邮件 ")
public class SysMailEntity implements BaseEntity<Long>, SoftDeleteEntity<Long>  {
	private static final long serialVersionUID = 1L;

	/** 主键 */
	@Comment(content="主键 ")
	private Long id;

	/** 邮件标题 */
	@Comment(content="邮件标题 ")
	private String title;

	/** 邮件内容 */
	@Comment(content="邮件内容 ")
	private String content;

	/** 创建时间 */
	@Comment(content="创建时间")
	private long createTime;
	
	/** 过期时间 */
	@Comment(content="过期时间")
	private long expiredTime;

	/** 附件内容(JSON字符串) */
	@Comment(content="附件内容(JSON字符串)")
	private String attachmentProps;
	
	/** 已发送的玩家id集合 */
	@Comment(content="已发送的玩家id集合")
	private String sendUsers;
	
	/** 删除时间 */
	@Comment(content="删除时间")
	private Timestamp deleteDate;
	
	/** 是否已删除 */
	@Comment(content="是否已删除")
	private int deleted;

	@Id
	@Override
	public Long getId() {
		return id;
	}

	@Column(columnDefinition = "VARCHAR(255)")
	public String getTitle() {
		return title;
	}

	@Column(columnDefinition = "TEXT")
	public String getContent() {
		return content;
	}

	@Column(columnDefinition = "bigint(20) default 0")
	public long getCreateTime() {
		return createTime;
	}
	
	@Column(columnDefinition = "bigint(20) default 0")
	public long getExpiredTime() {
		return expiredTime;
	}
	
	@Column(columnDefinition = "TEXT")
	public String getAttachmentProps() {
		return attachmentProps;
	}
	
	@Column(columnDefinition = "LONGTEXT")
	public String getSendUsers() {
		return sendUsers;
	}

	@Override
	public void setId(Long id) {
		this.id = id;
	}

	public void setTitle(String title) {
		this.title = title;
	}

	public void setContent(String content) {
		this.content = content;
	}

	public void setCreateTime(long createTime) {
		this.createTime = createTime;
	}

	public void setExpiredTime(long expiredTime) {
		this.expiredTime = expiredTime;
	}

	public void setAttachmentProps(String attachmentProps) {
		this.attachmentProps = attachmentProps;
	}

	public void setSendUsers(String sendUsers) {
		this.sendUsers = sendUsers;
	}
	
	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}
	
	@Column
	public int getDeleted() {
		return deleted;
	}

	@Column
	public Timestamp getDeleteDate() {
		return deleteDate;
	}

}
