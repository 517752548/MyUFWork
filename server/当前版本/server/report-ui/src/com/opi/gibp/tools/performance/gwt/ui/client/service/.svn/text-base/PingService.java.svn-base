package com.opi.gibp.tools.performance.gwt.ui.client.service;

import java.util.List;
import java.util.Map;

import com.google.gwt.user.client.rpc.RemoteService;
import com.google.gwt.user.client.rpc.RemoteServiceRelativePath;
import com.opi.gibp.tools.performance.gwt.ui.client.model.PingPerformance;

/**
 * @author wenping.jiang
 *	
 */
@RemoteServiceRelativePath("ping")
public interface PingService extends RemoteService{
	
	public List<PingPerformance> getLineChartDatas(Map<String,Object> queryData);
	
	/**
	 * 利用传入的查询条件所选择出的数据，进行区间划分，并获取各个区间段内的最大值作为该区间段的代表值进行展示
	 * 
	 * @param queryData
	 * @return
	 */
	public List<PingPerformance> getStatMaxLineChartDatas(Map<String,Object> queryData);
}
