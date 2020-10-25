package com.imop.lj.logserver.createtable;

import java.util.Collection;
import java.util.Map;

import com.imop.lj.logserver.LogServerConfig;

/**
 * 日志表创建接口
 * 
 * 
 * 
 */
public interface ITableCreator {
	/**
	 * 创建日志表
	 */
	public void buildTable();

	/**
	 * 删除日志表
	 */
	public void dropTable();

	/**
	 * 取得基本表名列表
	 * 
	 * @return
	 */
	public Collection<String> getBaseTableNames();

	/**
	 * 设置基本表名列表
	 * 
	 * @param baseTableNames
	 */
	public void setBaseTableNames(Collection<String> baseTableNames);
	
	/**
	 * 设置特殊日志存活时间Map
	 * 
	 * @param specLogLiveTimeMap
	 */
	public void setSpecLogLiveTimeMap(Map<String, Integer> specLogLiveTimeMap);

	/**
	 * 设置LogServer配置
	 * 
	 * @param logServerConfig
	 */
	public void setLogServerConfig(LogServerConfig logServerConfig);
}
