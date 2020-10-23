package com.imop.scribe.receiver.category;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Set;
import java.util.StringTokenizer;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.ThreadPoolExecutor;
import java.util.concurrent.TimeUnit;

import org.apache.commons.lang.ArrayUtils;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.scribe.receiver.Alarm;
import com.imop.scribe.receiver.Category;
import com.imop.scribe.receiver.SVCList;
import com.imop.scribe.util.CalendarUtil;

public class Perf extends Category {
	private static final Logger logger = LoggerFactory.getLogger("Perf");
	final static String CATEGORY_NAME = "probe.perf";
	final static String TABLE_PREFIX = "perf";
	final static String TABLE_NAME_SVCLIST = "svclist";
	final static String[] PERF_COLUMNS = new String[]{"logversion",
					"gameid","svrid","svcid","svc_type","hostid",
					"ts_begin","ts_end",
					"cpu_avg","cpu_max",
					"mem_total","mem_usage",
					"thr_cur","ygc_time","ygc_count","fgc_time","fgc_count",
					"bytes_in","bytes_out",
					"req_reach","req_ok","req_flop",
					"msg_profile","msg_0","msg_1","msg_2","msg_3","msg_4","msg_5","msg_6","msg_7",
					"msg_flop","msg_avg","msg_max",
					"db_profile","db_0","db_1","db_2","db_3","db_4","db_5","db_6","db_7",
					"db_flop","db_avg","db_max",
					"rpc_profile","rpc_0","rpc_1","rpc_2","rpc_3","rpc_4","rpc_5","rpc_6","rpc_7",
					"rpc_flop","rpc_avg","rpc_max",
					"users"
				};
	final static String[] SVC_COLUMNS = new String[]{"gameid","svrid","svcid","svc_type"};

	final static String[] stringFields = { "gameid", "svrid", "svcid",
		"svc_type", "ts_begin", "ts_end", "hostid" };

	/**
	 * 一个小时的秒数
	 */
	public static int mailwarnningintervaltime = 60 * 60 * 1000;
	
	/**
	 * 这里面的设定的属于后门。
	 */
	public static HashSet<String> backdoorSet = new HashSet();
	
	/**
	 * 是否发送邮件的后门
	 */
	public static boolean sendMailFlag = false;
	
	/**
	 * 存储上次每个服务器对应的fullGC数量
	 */
	protected HashMap<String, Long> fullGCMap = new HashMap<String, Long>();
	
	protected HashSet<String> perfStringFieldNames;

	/**
	 * 发邮件的线程池
	 */
	protected ThreadPoolExecutor warnMailThreadPool;
	
	/**
	 * 用于记录已经发过的
	 * 里面的key值为 服务器标示_邮件类型，value为发送的时间
	 */
	protected HashMap<String, Long> mailDetailMap = new HashMap<String, Long>(); 
	
	public Perf() {
		perfStringFieldNames = new HashSet<String>();
		for (String s : stringFields) {
			perfStringFieldNames.add(s);
		}
		warnMailThreadPool = new ThreadPoolExecutor(5, 10, 5 * 60, TimeUnit.SECONDS, new ArrayBlockingQueue<Runnable>(3),
				new ThreadPoolExecutor.DiscardOldestPolicy());
	}

	@Override
	public String getCategoryName() {
		return CATEGORY_NAME;
	}

	@Override
	public String getTablePrefix() {
		return TABLE_PREFIX;
	}

	@Override
	public String messageToInsertSQL(String category, String message) {
		
		StringTokenizer st = new StringTokenizer(message, ",");

		String timePostfix = null;
		StringBuilder sb0 = new StringBuilder(" (");
		// StringBuilder sb0 = new StringBuilder("INSERT INTO ").append(
		// TABLE_PREFIX).append(" (");
		StringBuilder sb1 = new StringBuilder();

		int pos = 0;
		

		//临时变量
		String cpu_avg = null;
		String fullGC_Count = null;
		while (st.hasMoreTokens()) {
			String token = st.nextToken();
			int off = token.indexOf('=');
			String varname = null;
			String value = null;
			try {
				varname = token.substring(0, off);
				value = token.substring(off + 1);
			} catch (Exception e) {
				if (logger.isDebugEnabled()) {
					logger.debug("message format error|errorPlace:" + token + "|error category:" + category + "|error message:" + message);
				}
				continue;
			}

			//如果varname非已定义的数据库字段，则直接忽略该字段的值入库
			if(!ArrayUtils.contains(PERF_COLUMNS, varname)){
				continue;
			}
			
			// append name
			if (pos != 0)
				sb0.append(",");
			sb0.append(varname);

			// append value
			if (pos != 0)
				sb1.append(",");

			if (perfStringFieldNames.contains(varname))
				sb1.append("'").append(value).append("'");
			else
				sb1.append(value);

			if (varname.compareTo("ts_end") == 0)
				timePostfix = getYearAndMonth(value);
			++pos;
			
			if(varname.equals("cpu_avg")){//cpu负载
				cpu_avg = value;
			}else if(varname.equals("fgc_count")){//fullgc次数
				fullGC_Count = value;
			}
		}
		
		String[][] serverInfo = getServerInfo(message);
		
		//性能检测 当cpu达到400或者fullgc5次的时候 发邮件报警
		if(!backdoorSet.contains(getServerKey(serverInfo)) && sendMailFlag){
			checkPerformanceCPUWarnning(cpu_avg, serverInfo);
			checkPerformanceMemoryWarnning(fullGC_Count, serverInfo);
		}
		sb0.append(") VALUES (").append(sb1).append(")");
		return addInsertIntoTable(sb0, TABLE_PREFIX, timePostfix).toString();
	}
	
	/**
	 * @param varname
	 * @param value
	 * 检测CPU性能，发邮件
	 */
	public void checkPerformanceCPUWarnning(String value, String[][] info){
		try {
			String serverKey = getServerKey(info);
			float cpu_avg = Float.parseFloat(value);
			if(cpu_avg >= Alarm.cpu_aver){
				logger.info(serverKey + " cpu warnning");
				if(mailDetailMap.containsKey(serverKey + "_" + Alarm.CPU)){
					if(CalendarUtil.getGMTTime() - mailDetailMap.get(serverKey + "_" + Alarm.CPU) <= mailwarnningintervaltime){
						logger.info(serverKey + " fullGC warnning send too fast time:" + CalendarUtil.getGMTDefaultDay());
						return;
					}
				}
				warnMailThreadPool.execute(new Alarm(Alarm.CPU,getServerKey(info) + " cpu warnning", 
						"cpu_avg = " + cpu_avg) {
				});
				mailDetailMap.put(serverKey + "_" + Alarm.CPU, CalendarUtil.getGMTTime());
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	/**
	 * @param varname
	 * @param value
	 * 检测内存性能，发邮件
	 */
	public void checkPerformanceMemoryWarnning(String value, String[][] info){
		try {
			String serverKey = getServerKey(info);
			long fullGC_Count = Long.parseLong(value);
			//第一次上传不报警
			if(fullGCMap.containsKey(serverKey)){
				if(fullGC_Count - fullGCMap.get(serverKey) >= Alarm.fullgc_count){
					if(mailDetailMap.containsKey(serverKey + "_" + Alarm.FULL_GC)){
						if(CalendarUtil.getGMTTime() - mailDetailMap.get(serverKey + "_" + Alarm.FULL_GC) <= mailwarnningintervaltime){
							logger.info(serverKey + " fullGC warnning send too fast time:" + CalendarUtil.getGMTDefaultDay());
							return;
						}
					}
					logger.info(serverKey + " fullGC warnning " + (fullGC_Count - fullGCMap.get(serverKey)));
					warnMailThreadPool.execute(new Alarm(Alarm.CPU,getServerKey(info) + " fullGC warnning", 
							"fullGC = " + (fullGC_Count - fullGCMap.get(serverKey))) {
					});
					mailDetailMap.put(serverKey + "_" + Alarm.FULL_GC, CalendarUtil.getGMTTime());
				}
			}
			fullGCMap.put(getServerKey(info), fullGC_Count);
		} catch (Exception e) {
			e.printStackTrace();
		}
	} 
	
	public String[][] getServerInfo(String message){
		StringTokenizer st = new StringTokenizer(message, ",");
		String[][] svc = new String[4][2];
		while (st.hasMoreTokens()) {
			String token = st.nextToken();
			int off = token.indexOf('=');

			String varname = null;
			String value = null;
			try {
				varname = token.substring(0, off);
				value = token.substring(off + 1);
			} catch (Exception e) {
				if (ArrayUtils.contains(SVC_COLUMNS, varname)) {
					logger.info("svclist format error|errorPlace:" + token + "|error columns:" + varname + "|error message:" + message);
				}
				continue;
			}
			if(varname.trim().equalsIgnoreCase("gameid")){
				svc[0][0] = varname;
				svc[0][1] = value;
			} else if(varname.trim().equalsIgnoreCase("svrid")){
				svc[1][0] = varname;
				svc[1][1] = value;
			} else if(varname.trim().equalsIgnoreCase("svcid")){
				svc[2][0] = varname;
				svc[2][1] = value;
			} else if(varname.trim().equalsIgnoreCase("svc_type")){
				svc[3][0] = varname;
				svc[3][1] = value;
			}
		}
		return svc;
	}
	
	/**
	 * @param message
	 * @return
	 * 获取服务器key值 gameid_svrid_svcid_svc_type
	 */
	public String getServerKey(String message){
		String[][] info = getServerInfo(message);
		return getServerKey(info);
	}
	
	/**
	 * @param info
	 * @return
	 * 获取服务器key值
	 */
	public String getServerKey(String[][] info){
		StringBuffer buffer = new StringBuffer();
		buffer.append(info[0][1] );
		buffer.append("_");
		buffer.append(info[1][1]);
		buffer.append("_");
		buffer.append(info[2][1]);
		buffer.append("_");
		buffer.append(info[3][1]);
		String key = buffer.toString();
		return key;
	}
	@Override
	public String message2svclistSql(String category, String message) {
		StringTokenizer st = new StringTokenizer(message, ",");
		StringBuilder sb0 = new StringBuilder("INSERT INTO ").append(
				TABLE_NAME_SVCLIST).append(" (");
		StringBuilder sb1 = new StringBuilder();
		String[][] svc = new String[4][2];
		Set<String> set = SVCList.getInstance().getSvcSet();
		while (st.hasMoreTokens()) {
			String token = st.nextToken();
			int off = token.indexOf('=');
			String varname = null;
			String value = null;
			try {
				varname = token.substring(0, off);
				value = token.substring(off + 1);
			} catch (Exception e) {
				if (ArrayUtils.contains(SVC_COLUMNS, varname)) {
					logger.info("svclist format error|errorPlace:" + token + "|error columns:" + varname + "|error message:" + message);
				}
				continue;
			}
			if(varname.trim().equalsIgnoreCase("gameid")){
				svc[0][0] = varname;
				svc[0][1] = value;
			} else if(varname.trim().equalsIgnoreCase("svrid")){
				svc[1][0] = varname;
				svc[1][1] = value;
			} else if(varname.trim().equalsIgnoreCase("svcid")){
				svc[2][0] = varname;
				svc[2][1] = value;
			} else if(varname.trim().equalsIgnoreCase("svc_type")){
				svc[3][0] = varname;
				svc[3][1] = value;
			}
		}
		int pos = 0;
		int pos2 = 0;
		StringBuilder key = new StringBuilder();
		for (int i = 0; i < svc.length; i++) {
			if(svc[i][0] == null || svc[i][1] == null){
				return null;
			} else {
				if(pos2 != 0){
					key.append(",");
				}
				key.append(svc[i][1]);
			}
			pos2++;
		}
		if (logger.isDebugEnabled()) {
			logger.info("receiving svclist key :" + key.toString());
		}
		if(!set.contains(key.toString())){
			for (int i = 0; i < svc.length; i++) {
				if(pos != 0){
					sb0.append(",");
					sb1.append(",");
				}
				sb0.append(svc[i][0]);
				sb1.append("'" + svc[i][1] + "'");
				pos++;
			}
			sb0.append(") VALUES (").append(sb1).append(")");
			set.add(key.toString());
			if (logger.isDebugEnabled()) {
				logger.info("receiving svclist key :" + sb0.toString());
			}
			return sb0.toString();
		} else {
			if (logger.isDebugEnabled()) {
				logger.info("svclist returning null:" );
			}
			return null;
		}
	}
	
	/**
	 * @param svcId
	 * 排除警报后门
	 */
	public static void addBackDoor(String[] svcIds){
		for(int i = 0; i < svcIds.length; i++){
			backdoorSet.add(svcIds[i]);
		}
	}
	
	public static void main(String[] args) {
//		String report = "logversion=1,gameid=ss,svrid=103,svcid=2,svc_type=game,ts_begin=2010-11-22 19:19:00,ts_end=2010-11-22 19:19:01,cpu_avg=0.0,cpu_max=0.0,mem_total=247,mem_usage=3,thr_cur=16,ygc_time=5,ygc_count=2,fgc_time=0,fgc_count=0,bytes_in=5277098637,bytes_out=5319677495,req_reach=10014,req_ok=5023,req_flop=4991,msg_profile=1,msg_0=1,msg_1=2,msg_2=7,msg_3=43,msg_4=46,msg_5=382,msg_6=482,msg_7=9054,msg_flop=10017,msg_avg=4966,msg_max=9999,db_profile=1,db_0=17,db_1=38,db_2=40,db_3=391,db_4=502,db_5=4005,db_6=5025,db_7=0,db_flop=10018,db_avg=4989,db_max=9999,rpc_profile=1,rpc_0=9,rpc_1=32,rpc_2=60,rpc_3=457,rpc_4=507,rpc_5=3994,rpc_6=4957,rpc_7=0,rpc_flop=10017,rpc_avg=4999,rpc_max=9999";
		String report = "logversion=1,gameid=sx,svrid=sx01.o8game.com,svcid=1000,svc_type=log,hostid=L-D,ts_begin=2012-01-30 16:28:16,ts_end=2012-01-30 16:33:16,cpu_avg=43.75,cpu_max=468.75,mem_total=20,mem_usage=20,thr_cur=18,ygc_time=0,ygc_count=0,fgc_time=0,fgc_count=0,bytes_in=20991,bytes_out=0,req_reach=0,req_ok=0,req_flop=0,msg_profile=1,msg_0=0,msg_1=0,msg_2=0,msg_3=0,msg_4=0,msg_5=0,msg_6=0,msg_7=0,msg_flop=0,msg_avg=0,msg_max=0,db_profile=1,db_0=0,db_1=0,db_2=0,db_3=0,db_4=0,db_5=0,db_6=0,db_7=0,db_flop=0,db_avg=0,db_max=0,rpc_profile=1,rpc_0=0,rpc_1=0,rpc_2=0,rpc_3=0,rpc_4=0,rpc_5=0,rpc_6=0,rpc_7=0,rpc_flop=0,rpc_avg=0,rpc_max=,users=0,newusers=0";
//		System.out.println(new Perf().message2svclistSql("", report));
		System.out.println(new Perf().messageToInsertSQL("", report));
		
	}
}
