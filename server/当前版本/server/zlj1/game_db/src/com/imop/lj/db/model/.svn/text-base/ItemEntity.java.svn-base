package com.imop.lj.db.model;

import java.sql.Timestamp;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.orm.SoftDeleteEntity;

/**
 * 道具实例实体
 * 
 */
@Entity
@Table(name = "t_item_info")
@Comment(content="数据库实体类：道具实例实体")
public class ItemEntity implements SoftDeleteEntity<String>, CharSubEntity {
	private static final long serialVersionUID = 1L;
	/** 主键 */
	@Comment(content="主键")
	private String id;
	/** 所属角色ID */
	@Comment(content="所属角色ID")
	private long charId;
	/** 佩戴武将ID */
	@Comment(content="佩戴武将ID")
	private long wearerId;
	/** 物品所在背包编号 */
	@Comment(content="物品所在背包编号")
	private int bagId;
	/** 物品所在背包位置 */
	@Comment(content="物品所在背包位置")
	private int bagIndex;
	/** 物品类型编号 */
	@Comment(content="物品类型编号")
	private int templateId;
	/** 叠加数量 */
	@Comment(content="叠加数量")
	private int overlap;
	/** 是否已删除 */
	@Comment(content="是否已删除")
	private int deleted;
	/** 创建时间 */
	@Comment(content="创建时间 ")
	private Timestamp createTime;
	/** 删除时间 */
	@Comment(content="删除时间 ")
	private Timestamp deleteDate;
	/** 使用期限 */
	@Comment(content="使用期限 ")
	private Timestamp deadline;
	/**进入临时背包时间*/
	@Comment(content="进入临时背包时间 ")
	private Timestamp intoTempBagTime;
	/** 物品自身的属性 */
	@Comment(content="物品自身的属性  ")
	private String properties;
	@Comment(content="最后一次更新时间")
	private long lastUpdateTime;
	
	@Id
	@Override
	@Column(length = 36)
	public String getId() {
		return this.id;
	}

	@Override
	@Column
	public long getCharId() {
		return charId;
	}

	@Column
	public long getWearerId() {
		return wearerId;
	}

	@Column
	public int getBagId() {
		return bagId;
	}

	@Column
	public int getBagIndex() {
		return bagIndex;
	}

	@Column
	public int getTemplateId() {
		return templateId;
	}

	@Column
	public int getOverlap() {
		return overlap;
	}

	@Column
	public int getDeleted() {
		return deleted;
	}

	@Column
	public Timestamp getDeadline() {
		return deadline;
	}

	@Column
	public Timestamp getDeleteDate() {
		return deleteDate;
	}

	@Column
	public Timestamp getCreateTime() {
		return createTime;
	}
	
	@Column
	public Timestamp getIntoTempBagTime() {
		return intoTempBagTime;
	}

	@Column(columnDefinition = "TEXT")
	public String getProperties() {
		return properties;
	}

	public void setId(String id) {
		this.id = id;
	}

	public void setCharId(long charId) {
		this.charId = charId;
	}

	public void setWearerId(long wearerId) {
		this.wearerId = wearerId;
	}

	public void setBagId(int bagId) {
		this.bagId = bagId;
	}

	public void setBagIndex(int bagIndex) {
		this.bagIndex = bagIndex;
	}

	public void setTemplateId(int templateId) {
		this.templateId = templateId;
	}

	public void setOverlap(int overlap) {
		this.overlap = overlap;
	}

	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}

	public void setCreateTime(Timestamp createTime) {
		this.createTime = createTime;
	}

	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}

	public void setDeadline(Timestamp deadline) {
		this.deadline = deadline;
	}

	public void setProperties(String properties) {
		this.properties = properties;
	}
	
	public void setIntoTempBagTime(Timestamp intoTempBagTime) {
		this.intoTempBagTime = intoTempBagTime;
	}

	@Column(columnDefinition = " bigint(20) default 0", nullable = false)
	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}

	@Override
	public String toString() {
		return "ItemEntity [id=" + id + ", charId=" + charId + ", wearerId=" + wearerId + ", bagId=" + bagId + ", bagIndex=" + bagIndex
				+ ", templateId=" + templateId + ", overlap=" + overlap + ", deleted=" + deleted + ", createTime=" + createTime + ", deleteDate="
				+ deleteDate + ", deadline=" + deadline + ", properties=" + properties + "]";
	}
	
}
