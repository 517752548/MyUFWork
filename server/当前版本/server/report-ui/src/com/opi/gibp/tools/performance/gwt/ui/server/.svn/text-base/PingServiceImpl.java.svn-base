package com.opi.gibp.tools.performance.gwt.ui.server;

import java.sql.Timestamp;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.codehaus.jackson.map.ObjectMapper;

import com.google.gwt.user.server.rpc.RemoteServiceServlet;
import com.opi.gibp.tools.performance.constants.ServerConstants;
import com.opi.gibp.tools.performance.gwt.ui.client.Constans;
import com.opi.gibp.tools.performance.gwt.ui.client.model.PingPerformance;
import com.opi.gibp.tools.performance.gwt.ui.client.service.PingService;
import com.opi.gibp.tools.performance.gwt.ui.server.model.SSOUser;
import com.opi.gibp.tools.performance.utils.CalendarUtil;
import com.opi.gibp.tools.performance.utils.db.DbHelper;

/**
 * @author wenping.jiang
 *	网络服务应用
 */
public class PingServiceImpl extends RemoteServiceServlet implements
		PingService {

	protected final static ObjectMapper jacksonMapper = new ObjectMapper();
	
	/**
	 * 数据库的平均时间
	 */
	final static String AVERTIME = "avergeTime";
	
	/**
	 * 最大时间
	 */
	final static String MAXTIME = "maxTime";
	
	/**
	 * ip
	 */
	final static String IP = "type";
	@Override
	public List<PingPerformance> getLineChartDatas(Map<String, Object> queryData) {	
		Timestamp begin = new Timestamp(CalendarUtil.getGMTTime()- 1000 * 60 * 60 * 24);
		Timestamp end = new Timestamp(CalendarUtil.getGMTTime());
		SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		List<String> monthList = CalendarUtil.fromMonths(begin.toString(), end.toString(), formatter) ;
		
		StringBuilder sqlBuilder = new StringBuilder();
		for(int i = 0 ; i < monthList.size() ; i++){
			String fromTables = "ping_" +  monthList.get(i);
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
		
		List<PingPerformance> perfList = null;
		List<PingPerformance> resultList = new ArrayList<PingPerformance>();
		try {
			perfList = (List<PingPerformance>)DbHelper.Select(sql, "com.opi.gibp.tools.performance.gwt.ui.client.model.PingPerformance");
			
			if(perfList != null && perfList.size()>0){
				long preTime = 0;
				long nowTime = 0;
				
				for(int i = 0 ; i < perfList.size()-1 ; i++){
					PingPerformance ping = perfList.get(i);
					
					if(i==0){
						preTime = ping.getTs_end().getTime();
					}
					nowTime = ping.getTs_end().getTime();
					
					if(preTime - nowTime >= 1000 * 60 * 5 * 2){//如果两点之间的时间大于了平均汇报时间5分钟的2倍，说明有点未记录,则将期间的点补充完整
						
						for(long j = nowTime , t = 1; j <= preTime ; j +=(1000 * 60 * 5), t++ ){
							PingPerformance nullPerf = new PingPerformance();
							nullPerf.setDefault();
							nullPerf.setTs_end(new Timestamp(preTime - 1000 * 60 * 5 * t));
							resultList.add(nullPerf);
						}
						
					}else{
						resultList.add(ping);
					}
					
					preTime = ping.getTs_end().getTime();
				}
			}
			
		} catch (Exception e) {
			e.printStackTrace();
		}
		
		return resultList;
	}

	@Override
	public List<PingPerformance> getStatMaxLineChartDatas(
			Map<String, Object> queryData) {
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
			String fromTables = "ping_" + monthList.get(i);
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
		List<PingPerformance> rawDataList = null;
		try {
			rawDataList = DbHelper.Select(sql, "com.opi.gibp.tools.performance.gwt.ui.client.model.PingPerformance");
		} catch (Exception e) {
			e.printStackTrace();
		}
		if(rawDataList == null || rawDataList.size() == 0 ){
			return rawDataList;
		}
//		System.out.println("数据库选择" + rawDataList.size());
//		for(int i = 0; i < rawDataList.size(); i++){
//			PingPerformance  ping = (PingPerformance) rawDataList.get(i);
//			System.out.println(i+"数据库选择" + ping.getTs_end() + "svrId:" + ping.getSvrid());
//		}
		List<PingPerformance> resultList = new ArrayList<PingPerformance>();
		long preTime = 0;
		long nowTime = 0;
		
		for(int i = 0 ; i < rawDataList.size()-1 ; i++){
			PingPerformance ping = rawDataList.get(i);
			
			if(i==0){
				preTime = ping.getTs_end().getTime();
			}
			nowTime = ping.getTs_end().getTime();
			
			if(preTime - nowTime >= 1000 * 60 * 5 * 2){//如果两点之间的时间大于了平均汇报时间5分钟的2倍，说明有点未记录,则将期间的点补充完整
				
				for(long j = nowTime , t = 1; j <= preTime ; j +=(1000 * 60 * 5), t++ ){
					PingPerformance nullPerf = new PingPerformance();
					nullPerf.setDefault();
					nullPerf.setTs_end(new Timestamp(preTime - 1000 * 60 * 5 * t));
					resultList.add(nullPerf);
				}
				
			}else{
				resultList.add(ping);
			}
			
			preTime = ping.getTs_end().getTime();
		}
			
//		System.out.println("填充选择" + resultList.size());
//		for(int i = 0; i < resultList.size(); i++){
//			PingPerformance  ping = (PingPerformance) resultList.get(i);
//			System.out.println(i+"填充选择" + ping.getTs_end() + "svrId:" + ping.getSvrid());
//		}
		
		/**
		 * 1.获取选择出的数据的size，判断与288关系，如果rawDataSize/288<1,则直接返回rawData
		 * 										如果rawDataSize/288>1,则分成rawDataSize/288个区间，对区间内的点，取max
		 * 
		 * **/
		int stepCount = 288;
		int result = resultList.size();
		float step = ((float)result)/stepCount;
		if(step < 1){
			step = 1;
		}
		List maxList = getMaxList(step,stepCount,resultList);
//		System.out.println("数据选择" + maxList.size());
//		for(int i = 0; i < maxList.size(); i++){
//			PingPerformance  ping = (PingPerformance) maxList.get(i);
//			System.out.println(i+"数据选择" + ping.getTs_end() + "svrId:" + ping.getSvrid());
//		}
		return maxList;
	}

	/**
	 * @param queryData
	 * @return
	 * 生成限制条件
	 */
	private String buildCondition(Map<String, Object> queryData) {
//		SSOUser user = (SSOUser) getThreadLocalRequest().getSession()
//									.getAttribute(ServerConstants.SSO_LOGINUSER);
		SSOUser user = SSOUser.getTestUser();
		
		String result = "";
		
		Iterator<String> keyIt = queryData.keySet().iterator();
		while(keyIt.hasNext()){
			String key = keyIt.next();
			if(key.contains("###")){
				
				result = buildTimeCond(queryData, result, key);
				
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
		result += " order by id desc ";
		return result;
	}
	
	/**
	 * @param queryData
	 * @param result
	 * @param key
	 * @return
	 * 生成日期条件
	 */
	private String buildTimeCond(Map<String, Object> queryData, String result,
			String key) {
		//###时间处理 value ###beginDate###endDate

		try{
			String realKey = key.replace("###", "");
			String[] dateRange = ((String)queryData.get(key)).split("###");
			System.out.println(((String)queryData.get(key)));
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
	
	/**
	 * 按照baseStep~baseStep+step区间，从rawDataList中取出该区间中的最大值，并按照先后顺序依次存入List
	 * 
	 * @param step 每个区间段最大值最小值的差
	 * @param stepCount 需要划分成多少个区间段
	 * @param rawDataList 
	 * @return
	 */
	private List getMaxList(float step, int stepCount,
			List<PingPerformance> rawDataList) {
		
		List<PingPerformance> maxList = new ArrayList<PingPerformance>();
		
		for(int i = 0 ; i < stepCount && i < rawDataList.size(); i++){
			
			int base = (int) (step * i);
			int top = (int) (step * (i + 1) - 1 );
			
			PingPerformance max = new PingPerformance();
			max.setTs_end(new Timestamp(0));
			for(int j = base ; j <= top && j < rawDataList.size(); j++ ){
				PingPerformance perf = rawDataList.get(j);
				buildMax(perf,max);
			}
			
			maxList.add(max);
			
		}
		
		return maxList;
	}
	/**
	 * 比对perf和max，将max中的所有字段，换成perf和max中该字段的最大值
	 * @param perf
	 * @param max
	 */
	private void buildMax(PingPerformance perf, PingPerformance max) {
		max.setId(perf.getId());
		max.setLogversion(perf.getLogversion());
		max.setGameid(perf.getGameid());
		max.setSvrid(perf.getSvrid());
		max.setSvcid(perf.getSvcid());
		max.setSvc_type(perf.getSvc_type());
		if(perf.getTs_end().after(max.getTs_end())){
			max.setTs_end(perf.getTs_end());
		}
		
		if(perf.getPingaver_0() > max.getPingaver_0()){
			max.setPingaver_0(perf.getPingaver_0());
		}
		if(perf.getPingaver_1() > max.getPingaver_1()){
			max.setPingaver_1(perf.getPingaver_1());
		}
		if(perf.getPingaver_2() > max.getPingaver_2()){
			max.setPingaver_2(perf.getPingaver_2());
		}
		if(perf.getPingaver_3() > max.getPingaver_3()){
			max.setPingaver_3(perf.getPingaver_3());
		}
		if(perf.getPingaver_4() > max.getPingaver_4()){
			max.setPingaver_4(perf.getPingaver_4());
		}
		if(perf.getPingaver_5() > max.getPingaver_5()){
			max.setPingaver_5(perf.getPingaver_5());
		}
		if(perf.getPingaver_6() > max.getPingaver_6()){
			max.setPingaver_6(perf.getPingaver_6());
		}
		if(perf.getPingaver_7() > max.getPingaver_7()){
			max.setPingaver_7(perf.getPingaver_7());
		}
		
		if(perf.getPingmax_0() > max.getPingmax_0()){
			max.setPingmax_0(perf.getPingmax_0());
		}
		if(perf.getPingmax_1() > max.getPingmax_1()){
			max.setPingmax_1(perf.getPingmax_1());
		}
		if(perf.getPingmax_2() > max.getPingmax_2()){
			max.setPingmax_2(perf.getPingmax_2());
		}
		if(perf.getPingmax_3() > max.getPingmax_3()){
			max.setPingmax_3(perf.getPingmax_3());
		}
		if(perf.getPingmax_4() > max.getPingmax_4()){
			max.setPingmax_4(perf.getPingmax_4());
		}
		if(perf.getPingmax_5() > max.getPingmax_5()){
			max.setPingmax_5(perf.getPingmax_5());
		}
		if(perf.getPingmax_6() > max.getPingmax_6()){
			max.setPingmax_6(perf.getPingmax_6());
		}
		if(perf.getPingmax_7() > max.getPingmax_7()){
			max.setPingmax_7(perf.getPingmax_7());
		}
		
		if(perf.getAvertime() > max.getAvertime()){
			max.setAvertime(perf.getAvertime());
		}
		if(perf.getMaxtime() > max.getMaxtime()){
			max.setMaxtime(perf.getMaxtime());
		}
	}
}
