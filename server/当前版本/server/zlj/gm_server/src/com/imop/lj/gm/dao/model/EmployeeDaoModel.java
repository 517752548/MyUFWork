package com.imop.lj.gm.dao.model;

import java.sql.Timestamp;

public class EmployeeDaoModel {
	/** 主键 UUID */
	private long id;
	/** 所属角色 */
	private long charId;
	/** 模板ID */
	private int templateId;
	/** 所属公司  */
	private long companyId;
	/** 创建日期 */
	private Timestamp createDate;
	/** 记录上一次增加熟练度日期 */
	private Timestamp lastRefreshSkillDate;
	/** 解雇日期 */
	private Timestamp deleteDate;
	/** 是否已招募 */
	private int deleted;
	/** 员工名称 */
	private String name;
	/** 级别 */
	private int level;
	/** 熟练度 */
	private int exp;
//	//删除时间
//	private int deleteTime;
	public long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}
	public long getCharId() {
		return charId;
	}
	public void setCharId(long charId) {
		this.charId = charId;
	}
	public int getTemplateId() {
		return templateId;
	}
	public void setTemplateId(int templateId) {
		this.templateId = templateId;
	}
	public long getCompanyId() {
		return companyId;
	}
	public void setCompanyId(long companyId) {
		this.companyId = companyId;
	}
	public Timestamp getCreateDate() {
		return createDate;
	}
	public void setCreateDate(Timestamp createDate) {
		this.createDate = createDate;
	}
	public Timestamp getLastRefreshSkillDate() {
		return lastRefreshSkillDate;
	}
	public void setLastRefreshSkillDate(Timestamp lastRefreshSkillDate) {
		this.lastRefreshSkillDate = lastRefreshSkillDate;
	}
	public Timestamp getDeleteDate() {
		return deleteDate;
	}
	public void setDeleteDate(Timestamp deleteDate) {
		this.deleteDate = deleteDate;
	}
	public int getDeleted() {
		return deleted;
	}
	public void setDeleted(int deleted) {
		this.deleted = deleted;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public int getLevel() {
		return level;
	}
	public void setLevel(int level) {
		this.level = level;
	}
	public int getExp() {
		return exp;
	}
	public void setExp(int exp) {
		this.exp = exp;
	}
//	public int getDeleteTime() {
//		return deleteTime;
//	}
//	public void setDeleteTime(int deleteTime) {
//		this.deleteTime = deleteTime;
//	}
}
