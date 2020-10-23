package com.opi.gibp.tools.performance.gwt.ui.server;

import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import com.opi.gibp.tools.performance.gwt.ui.client.model.Performance;

public class PerfUtil {

	/**
	 * 比对perf和max，将max中的所有字段，换成perf和max中该字段的最大值
	 * @param perf
	 * @param max
	 */
	public static void buildMax(Performance perf, Performance max) {
		max.setId(perf.getId());
		max.setLogversion(perf.getLogversion());
		max.setGameid(perf.getGameid());
		max.setSvrid(perf.getSvrid());
		max.setSvcid(perf.getSvcid());
		max.setSvc_type(perf.getSvc_type());
		if(perf.getTs_end().after(max.getTs_end())){
			max.setTs_end(perf.getTs_end());
		}
		if(perf.getUsers()>max.getUsers()){
			max.setUsers(perf.getUsers());
		}
		if(perf.getMem_total()>max.getMem_total()){
			max.setMem_total(perf.getMem_total());
		}
		if(perf.getMem_usage()>max.getMem_usage()){
			max.setMem_usage(perf.getMem_usage());
		}
		if(perf.getCpu_avg()>max.getCpu_avg()){
			max.setCpu_avg(perf.getCpu_avg());
		}
		if(perf.getCpu_max()>max.getCpu_max()){
			max.setCpu_max(perf.getCpu_max());
		}
		if(perf.getReq_reach()>max.getReq_reach()){
			max.setReq_reach(perf.getReq_reach());
		}
		if(perf.getReq_flop()>max.getReq_flop()){
			max.setReq_flop(perf.getReq_flop());
		}
		if(perf.getReq_ok()>max.getReq_ok()){
			max.setReq_ok(perf.getReq_ok());
		}
		if(perf.getBytes_in()>max.getBytes_in()){
			max.setBytes_in(perf.getBytes_in());
		}
		if(perf.getBytes_out()>max.getBytes_out()){
			max.setBytes_out(perf.getBytes_out());
		}
		if(perf.getThr_cur()>max.getThr_cur()){
			max.setThr_cur(perf.getThr_cur());
		}
		if(perf.getYgc_count()>max.getYgc_count()){
			max.setYgc_count(perf.getYgc_count());
		}
		if(perf.getFgc_count()>max.getFgc_count()){
			max.setFgc_count(perf.getFgc_count());
		}
		if(perf.getMsg_profile()>max.getMsg_profile()){
			max.setMsg_profile(perf.getMsg_profile());
		}
		if(perf.getMsg_0()>max.getMsg_0()){
			max.setMsg_0(perf.getMsg_0());
		}
		if(perf.getMsg_1()>max.getMsg_1()){
			max.setMsg_1(perf.getMsg_1());
		}
		if(perf.getMsg_2()>max.getMsg_2()){
			max.setMsg_2(perf.getMsg_2());
		}
		if(perf.getMsg_3()>max.getMsg_3()){
			max.setMsg_3(perf.getMsg_3());
		}
		if(perf.getMsg_4()>max.getMsg_4()){
			max.setMsg_4(perf.getMsg_4());
		}
		if(perf.getMsg_5()>max.getMsg_5()){
			max.setMsg_5(perf.getMsg_5());
		}
		if(perf.getMsg_6()>max.getMsg_6()){
			max.setMsg_6(perf.getMsg_6());
		}
		if(perf.getMsg_7()>max.getMsg_7()){
			max.setMsg_7(perf.getMsg_7());
		}
		if(perf.getMsg_8()>max.getMsg_8()){
			max.setMsg_8(perf.getMsg_8());
		}
		if(perf.getMsg_flop()>max.getMsg_flop()){
			max.setMsg_flop(perf.getMsg_flop());
		}
		if(perf.getMsg_avg()>max.getMsg_avg()){
			max.setMsg_avg(perf.getMsg_avg());
		}
		if(perf.getMsg_max()>max.getMsg_max()){
			max.setMsg_max(perf.getMsg_max());
		}
		if(perf.getDb_profile()>max.getDb_profile()){
			max.setDb_profile(perf.getDb_profile());
		}
		if(perf.getDb_0()>max.getDb_0()){
			max.setDb_0(perf.getDb_0());
		}
		if(perf.getDb_1()>max.getDb_1()){
			max.setDb_1(perf.getDb_1());
		}
		if(perf.getDb_2()>max.getDb_2()){
			max.setDb_2(perf.getDb_2());
		}
		if(perf.getDb_3()>max.getDb_3()){
			max.setDb_3(perf.getDb_3());
		}
		if(perf.getDb_4()>max.getDb_4()){
			max.setDb_4(perf.getDb_4());
		}
		if(perf.getDb_5()>max.getDb_5()){
			max.setDb_5(perf.getDb_5());
		}
		if(perf.getDb_6()>max.getDb_6()){
			max.setDb_6(perf.getDb_6());
		}
		if(perf.getDb_7()>max.getDb_7()){
			max.setDb_7(perf.getDb_7());
		}
		if(perf.getDb_8()>max.getDb_8()){
			max.setDb_8(perf.getDb_8());
		}
		if(perf.getDb_flop()>max.getDb_flop()){
			max.setDb_flop(perf.getDb_flop());
		}
		if(perf.getDb_avg()>max.getDb_avg()){
			max.setDb_avg(perf.getDb_avg());
		}
		if(perf.getDb_max()>max.getDb_max()){
			max.setDb_max(perf.getDb_max());
		}
		if(perf.getRpc_profile()>max.getRpc_profile()){
			max.setRpc_profile(perf.getRpc_profile());
		}
		if(perf.getRpc_0()>max.getRpc_0()){
			max.setRpc_0(perf.getRpc_0());
		}
		if(perf.getRpc_1()>max.getRpc_1()){
			max.setRpc_1(perf.getRpc_1());
		}
		if(perf.getRpc_2()>max.getRpc_2()){
			max.setRpc_2(perf.getRpc_2());
		}
		if(perf.getRpc_3()>max.getRpc_3()){
			max.setRpc_3(perf.getRpc_3());
		}
		if(perf.getRpc_4()>max.getRpc_4()){
			max.setRpc_4(perf.getRpc_4());
		}
		if(perf.getRpc_5()>max.getRpc_5()){
			max.setRpc_5(perf.getRpc_5());
		}
		if(perf.getRpc_6()>max.getRpc_6()){
			max.setRpc_6(perf.getRpc_6());
		}
		if(perf.getRpc_7()>max.getRpc_7()){
			max.setRpc_7(perf.getRpc_7());
		}
		if(perf.getRpc_8()>max.getRpc_8()){
			max.setRpc_8(perf.getRpc_8());
		}
		if(perf.getRpc_flop()>max.getRpc_flop()){
			max.setRpc_flop(perf.getRpc_flop());
		}
		if(perf.getRpc_avg()>max.getRpc_avg()){
			max.setRpc_avg(perf.getRpc_avg());
		}
		if(perf.getRpc_max()>max.getRpc_max()){
			max.setRpc_max(perf.getRpc_max());
		}
		
	}

	/**
	 * 通过传入的b_yyyyMMdd,e_yyyyMMdd时间值,以及formatter 来获取这两个时间值之间的月份List
	 * @param begin
	 * @param end
	 * @return
	 */
	public static List<String> fromMonths(String b_yyyyMMdd , String e_yyyyMMdd,SimpleDateFormat formatter){
		SimpleDateFormat yearMonthFormatter = new SimpleDateFormat("yyyyMM");
		List<String> monthList = new ArrayList<String>();
		Calendar beginCal = Calendar.getInstance();
		Calendar endCal = Calendar.getInstance();
		
		try {
			beginCal.setTime(formatter.parse(b_yyyyMMdd));
			endCal.setTime(formatter.parse(e_yyyyMMdd));
		} catch (ParseException e) {
			System.err.println("the formatter or the String parameters are not properly! " +
					"[b_yyyyMMdd:" + b_yyyyMMdd + "][e_yyyyMMdd:" + e_yyyyMMdd + "][formatter:"+ formatter );
			e.printStackTrace();
			return null;
		}
		
		while(beginCal.before(endCal)){
			Date duringDate = beginCal.getTime();
			String month = yearMonthFormatter.format(duringDate);
			
			monthList.add(month);

			// add a month
			beginCal.set(Calendar.MONTH, beginCal.get(Calendar.MONTH) + 1);
		}
		
		Date date = endCal.getTime();
		String month = yearMonthFormatter.format(date);
		if(!monthList.contains(month)){
			monthList.add(month);
		}
		
		return monthList;
	}
	
	/**
	 * @param tablePre
	 * @param monthList
	 * @return
	 */
	public static String fromTables(String tablePre , List<String> monthList){
		if(monthList ==  null || monthList.size()==0){
			return null;
		}
		
		StringBuilder sb = new StringBuilder();
		
		for(int i = 0 ; i < monthList.size() ; i ++){
			String month = monthList.get(i);
			sb.append( tablePre ).append( month ).append(",");
		}
		
		String tables = sb.toString();
		
		return tables.substring(0,tables.length()-1);
	}
	
	
	public static void main(String[] args) {
		
		SimpleDateFormat a = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
		Timestamp begin = new Timestamp(System.currentTimeMillis() - 1000 * 60 * 60 * 24);
		System.out.println(a.format(begin));
		Timestamp end = new Timestamp(System.currentTimeMillis());
		SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
		List<String> monthList = PerfUtil.fromMonths("2010-08-03", "2011-01-02", formatter) ;
		String fromTables = PerfUtil.fromTables("perf_", monthList);
		
		String sql = "select * from ";
		String whereTrue = " where 1=1 ";
		String range = " and ts_end between '" + begin + "' and '" + end + "' ";

		sql = sql + fromTables + whereTrue +  range;
		System.out.println(sql);
		
	}
}
