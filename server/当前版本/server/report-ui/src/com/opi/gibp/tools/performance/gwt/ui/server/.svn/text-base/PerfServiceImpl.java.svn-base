/**
 * 
 */
package com.opi.gibp.tools.performance.gwt.ui.server;

import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import com.google.gwt.user.server.rpc.RemoteServiceServlet;
import com.opi.gibp.tools.performance.constants.ServerConstants;
import com.opi.gibp.tools.performance.gwt.ui.client.Constans;
import com.opi.gibp.tools.performance.gwt.ui.client.model.Performance;
import com.opi.gibp.tools.performance.gwt.ui.client.service.PerfService;
import com.opi.gibp.tools.performance.gwt.ui.server.model.SSOUser;
import com.opi.gibp.tools.performance.utils.CalendarUtil;
import com.opi.gibp.tools.performance.utils.PerfUtil;
import com.opi.gibp.tools.performance.utils.db.DbHelper;

/**
 * @author Administrator
 *
 */
@SuppressWarnings("serial")
public class PerfServiceImpl extends RemoteServiceServlet implements
		PerfService {
	/* (non-Javadoc)
	 * @see com.gogole.gwt.ui.test.client.PerfService#getLineChartDatas(java.util.Map)
	 */
	@SuppressWarnings({ "unchecked"})
	@Override
	public List<Performance> getLineChartDatas(Map<String, Object> queryData) {	
		Timestamp begin = new Timestamp(CalendarUtil.getGMTTime()- 1000 * 60 * 60 * 24);
		Timestamp end = new Timestamp(CalendarUtil.getGMTTime());
		SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		List<String> monthList = CalendarUtil.fromMonths(begin.toString(), end.toString(), formatter) ;
		
		StringBuilder sqlBuilder = new StringBuilder();
		for(int i = 0 ; i < monthList.size() ; i++){
			String fromTables = "perf_" +  monthList.get(i);
			String select = "select * from ";
			String whereTrue = " where 1=1 ";
			String timeRange = " and ts_end between '" + begin + "' and '" + end + "' ";
	
			sqlBuilder.append("(")
						.append( select ).append( fromTables ).append( whereTrue ).append(timeRange)
						.append(")");
			sqlBuilder.append(" union ");
		}
		String sql = sqlBuilder.toString();
		if(sql.endsWith(" union ")){
			sql = sql.substring(0,sql.length()- 7);
			//末尾加上排序
			sql += " order by ts_end desc ";
		}
		if(monthList.size()==1){//如果是单表，则删除前后因union 所需要的小括号
			sql = sql.substring(1,sql.lastIndexOf(")"));
		}
		
		String andCondition = buildCondition(queryData);
		
		sql += andCondition;
		System.out.println(sql);
		
		List<Performance> perfList = null;
		List<Performance> resultList = new ArrayList<Performance>();
		try {
			perfList = (List<Performance>)DbHelper.Select(sql, "com.opi.gibp.tools.performance.gwt.ui.client.model.Performance");
			
			if(perfList != null && perfList.size()>0){
				long preTime = 0;
				long nowTime = 0;
				
				for(int i = 0 ; i < perfList.size()-1 ; i++){
					Performance perf = perfList.get(i);
					
					if(i==0){
						preTime = perf.getTs_end().getTime();
					}
					nowTime = perf.getTs_end().getTime();
					
					if(preTime - nowTime >= 1000 * 60 * 5 * 2){//如果两点之间的时间大于了平均汇报时间5分钟的2倍，说明有点未记录,则将期间的点补充完整
						
						for(long j = nowTime , t = 1; j <= preTime ; j +=(1000 * 60 * 5), t++ ){
							Performance nullPerf = new Performance();
							nullPerf.setDefault();
							nullPerf.setTs_end(new Timestamp(preTime - 1000 * 60 * 5 * t));
							resultList.add(nullPerf);
						}
						
					}else{
						resultList.add(perf);
					}
					
					preTime = perf.getTs_end().getTime();
				}
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultList;
	}

	private String buildCondition(Map<String, Object> queryData) {
//		SSOUser user = (SSOUser) getThreadLocalRequest().getSession()
//									.getAttribute(ServerConstants.SSO_LOGINUSER);
		SSOUser user = SSOUser.getTestUser();
		
		String result = "";
		
		Iterator<String> keyIt = queryData.keySet().iterator();
		while(keyIt.hasNext()){
			String key = keyIt.next();
			if(key.contains("###")){
				
				List<String> timeCondList = CalendarUtil.getTimeCond(queryData.get(key).toString());
				if(timeCondList!=null && timeCondList.size()>=2){
					result += " and " + key.replace("###", "") + " between '" + timeCondList.get(0) + "' and '" + timeCondList.get(1) + "' ";
				}
				
			}else if(key.contains("???")){
				//???扩展用
				
			}else if(key.contains("!!!")){
				
				
			}else if(key.contains("$$$")){
				//$$$数字字段的解读
				result += " and " + key + "=" + (String)queryData.get(key) + " ";
				
			}else{//字符字段的解读  id='searchValue' 
				result += " and " + key + "='" + (String)queryData.get(key) + "' ";
			}
			
		}

		//添加游戏权限划分
		result += " and gameid in('" + user.getGameids().replace(",", "','") + "')";
		
		result += " order by ts_end desc ";
		return result;
	}
	
	@SuppressWarnings("unused")
	private String buildTimeCond(Map<String, Object> queryData, String result,
			String key) {
		//###时间处理 value ###beginDate###endDate

		try{
			String realKey = key.replace("###", "");
			String[] dateRange = ((String)queryData.get(key)).split("###");
			if(dateRange != null && dateRange.length > 0){
				// 获得第一个时间，作为时间戳的开始
				String begin = dateRange[0];
				//获得list中的最后一个时间，作为时间戳的结束
				String end = dateRange[dateRange.length - 1];
				
				//添加过滤条件
				result += " and " + realKey + " between '" + begin + "' and '" + end + "' ";
			}
			
		}catch (Exception e) {
			
			e.printStackTrace();
			
		}
		return result;
	}

	/* (non-Javadoc)
	 * @see com.opi.gibp.tools.performance.gwt.ui.client.PerfService#getStatLineChartDatas(java.util.Map)
	 * 
	 * 按照72 个区间段进行数据的展示
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	@Override
	public List<Performance> getStatMaxLineChartDatas(Map<String, Object> queryData) {
		List<String> monthList = null;
		String begin = null;
		String end = null;
		if(queryData.containsKey(Constans.QUERY_DATE_KEY)){
			String timeRange = queryData.get(Constans.QUERY_DATE_KEY).toString();
			List<String> timeRangeList = CalendarUtil.getTimeCond(timeRange);
			
			if(timeRangeList != null && timeRangeList.size() >=2){
				begin = timeRangeList.get(0);
				end = timeRangeList.get(1);
				SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
				monthList = CalendarUtil.fromMonths(begin, end, formatter) ;
			}
		}
		
		StringBuilder sqlBuilder = new StringBuilder();
		for(int i = 0 ; i < monthList.size() ; i++){
			String fromTables = "perf_" + monthList.get(i);
			String select = "select * from ";
			String whereTrue = " where 1=1 ";
			String timeRange = " and ts_end between '" + begin + "' and '" + end + "' ";
			String andCondition = buildCondition(queryData);
	
			sqlBuilder.append("(")
						.append( select ).append( fromTables ).append( whereTrue ).append( timeRange ).append(andCondition)
					.append(")");
			sqlBuilder.append(" union ");
		}
		
		String sql = sqlBuilder.toString();
		if(sql.endsWith(" union ")){
			sql = sql.substring(0,sql.length()- 7);
			//末尾加上排序
			sql += " order by ts_end desc ";
		}
			
		if(monthList.size()==1){//如果是单表，则删除前后因union 所需要的小括号
			sql = sql.substring(1,sql.lastIndexOf(")"));
		}
		
		System.out.println(sql);	
		List<Performance> rawDataList = null;
		try {
			rawDataList = DbHelper.Select(sql, "com.opi.gibp.tools.performance.gwt.ui.client.model.Performance");
		} catch (Exception e) {
			e.printStackTrace();
		}
		if(rawDataList == null || rawDataList.size() == 0 ){
			return rawDataList;
		}
		
//		System.out.println("填充前结果" + rawDataList.size());
//		for(int i = 0; i < rawDataList.size();  i++){
//			Performance perf = rawDataList.get(i);
//			System.out.println(i + "填充前值" + perf.getTs_end());
//		}
		/**
		 * 1.获取选择出的数据的size，判断与288关系，如果rawDataSize/288<1,则直接返回rawData
		 * 										如果rawDataSize/288>1,则分成rawDataSize/288个区间，对区间内的点，取max
		 * 
		 * **/
		int stepCount = 288;
		int rawDataSize = rawDataList.size();
		List<Performance> resultList = new ArrayList<Performance>();
		if(rawDataList != null && rawDataList.size()>0){
			long preTime = 0;
			long nowTime = 0;
			
			for(int i = 0 ; i < rawDataList.size()-1 ; i++){
				Performance perf = rawDataList.get(i);
				
				if(i==0){
					preTime = perf.getTs_end().getTime();
				}
				nowTime = perf.getTs_end().getTime();
				
				if(preTime - nowTime >= 1000 * 60 * 5 * 2){//如果两点之间的时间大于了平均汇报时间5分钟的2倍，说明有点未记录,则将期间的点补充完整
					
					for(long j = nowTime , t = 1; j <= preTime ; j +=(1000 * 60 * 5), t++ ){
						Performance nullPerf = new Performance();
						nullPerf.setDefault();
						nullPerf.setTs_end(new Timestamp(preTime - 1000 * 60 * 5 * t));
						resultList.add(nullPerf);
					}
					
				}else{
					resultList.add(perf);
				}
				
				preTime = perf.getTs_end().getTime();
			}
		}
//		System.out.println("填充结果" + resultList.size());
//		for(int i = 0; i < resultList.size();  i++){
//			Performance perf = resultList.get(i);
//			System.out.println(i + "填充值" + perf.getTs_end());
//		}
		float step = ((float)resultList.size())/stepCount;
		if(step < 1){
			step = 1;
		}
		List maxList = getMaxList(step,stepCount,resultList);
//		System.out.println("填充2结果" + maxList.size());
//		for(int i = 0; i < maxList.size();  i++){
//			Performance perf = (Performance) maxList.get(i);
//			System.out.println(i + "填充2值" + perf.getTs_end());
//		}
		return maxList;
	}

	@SuppressWarnings("unused")
	private List<Performance> fixList(List<Performance> maxList) {
		
		long maxTime = maxList.get(maxList.size()-1).getTs_end().getTime();
		long minTime = maxList.get(0).getTs_end().getTime();
		
		long timeStep = ( maxTime - minTime ) / maxList.size();
		
		System.out.println(timeStep);
		
		return null;
	}

	/**
	 * 按照baseStep~baseStep+step区间，从rawDataList中取出该区间中的最大值，并按照先后顺序依次存入List
	 * 
	 * @param step 每个区间段最大值最小值的差
	 * @param stepCount 需要划分成多少个区间段
	 * @param rawDataList 
	 * @return
	 */
	@SuppressWarnings("rawtypes")
	private List getMaxList(float step, int stepCount,
			List<Performance> rawDataList) {
		
		List<Performance> maxList = new ArrayList<Performance>();
		for(int i = 0 ; i < stepCount && i < rawDataList.size(); i++){
			
			int base = (int) (step * i);
			int top = (int) (step * (i + 1) - 1 );
			
			Performance max = new Performance();
			max.setTs_end(new Timestamp(0));
			
			for(int j = base ; j <= top && j < rawDataList.size(); j++ ){
				Performance perf = rawDataList.get(j);
				PerfUtil.buildMax(perf,max);
			}
			
			
			maxList.add(max);
			
		}
		
		return maxList;
	}

}
