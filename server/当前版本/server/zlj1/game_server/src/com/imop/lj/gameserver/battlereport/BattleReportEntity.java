package com.imop.lj.gameserver.battlereport;

import java.sql.Timestamp;

import com.imop.lj.core.orm.BaseEntity;

/**
 * 战报的数据实体
 * @author yue.yan
 *
 */
public class BattleReportEntity implements BaseEntity<Long>  {

	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	/** 存储战报的数据表名称 */
	private String tableName;
	/** 战报id */
	private long id;
	/** 战报数据 */
	private String data;
	/** 创建时间 */
	private Timestamp createTime;
	
	
	public String getTableName() {
		return tableName;
	}
	
	public void setTableName(String tableName) {
		this.tableName = tableName;
	}
	
	public Long getId() {
		return id;
	}
	public void setId(long id) {
		this.id = id;
	}
	
	@Override
	public void setId(Long id) {
		this.id = id;
	}
	
	public String getData() {
		return data;
	}
	
	public void setData(String data) {
		this.data = data;
	}
	
	public Timestamp getCreateTime() {
		return createTime;
	}
	
	public void setCreateTime(Timestamp createTime) {
		this.createTime = createTime;
	}
}
