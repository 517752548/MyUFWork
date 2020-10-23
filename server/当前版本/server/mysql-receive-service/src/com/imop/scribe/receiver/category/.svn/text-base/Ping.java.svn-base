package com.imop.scribe.receiver.category;

import java.io.IOException;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Set;
import java.util.Map.Entry;
import org.codehaus.jackson.JsonNode;
import org.codehaus.jackson.JsonProcessingException;
import org.codehaus.jackson.node.ObjectNode;
import com.imop.scribe.receiver.Category;
import com.imop.scribe.receiver.SVCList;
import com.imop.scribe.util.Utils;

/**
 * @author wenping.jiang
 *	网络的ping处理
 */
public class Ping extends Category{
	/**
	 *策略名称
	 */
	final static String CATEGORY_NAME = "probe.ping";
	/**
	 * 表名称
	 */
	final static String TABLE_PREFIX = "ping";
	
	/**
	 * 存入数据库字段的平均分布名称
	 */
	final static String PING_DATABASE_AVER_PREF = "pingaver";
	
	/**
	 * 存入数据库字段的平均分布名称
	 */
	final static String PING_DATABASE_MAX_PREF = "pingmax";
	
	/**
	 * 总共时间
	 */
	final static String TOTAL_TIME = "t";
	
	/**
	 * 总共个数
	 */
	final static String COUNT = "c";
	
	/**
	 * 平均分布时间
	 */
	final static String AVER_TIME = "a";
	
	/**
	 * 最大的时间名称
	 */
	final static String MAX_TIME = "m";
	
	/**
	 * 平均分布时间
	 */
	final static String SQL_AVER_TIME = "avertime";
	
	/**
	 * 最大的时间名称
	 */
	final static String SQL_MAX_TIME = "maxtime";
	
	
	/**
	 * svcList的数据库名称
	 */
	final static String TABLE_NAME_SVCLIST = "svclist";
	
	/** ping时间统计区间 */
	static final int[] PING_INTERVAL = new int[] { 10, 50, 100, 500, 1000,
			5000, 10000, Integer.MAX_VALUE };
	/**
	 * 网络平均时间分布
	 */
	private HashMap<Integer, Integer>  ping_aver_time_interval = new HashMap<Integer, Integer>();
	
	/**
	 * 网络最大时间分布
	 */
	private HashMap<Integer, Integer>  ping_max_time_interval = new HashMap<Integer, Integer>();
	
	
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
		try {
			System.out.println(message);
			if(!Utils.canStoreMsgVersion(message)){
				return null;
			}
			ping_max_time_interval.clear();
			ping_aver_time_interval.clear();
			ObjectNode root = (ObjectNode) jacksonMapper.readTree(message);
			StringBuilder sb0 = new StringBuilder(" (");
			StringBuilder sb1 = new StringBuilder();
			String timePostfix = "";
			Iterator<Entry<String, JsonNode>> iter = root.getFields();
			int pos = 0;
			while (iter.hasNext()) {
				//使用字段进行存储，取消json字符串存储
				Entry<String, JsonNode> entry = iter.next();
				if (pos != 0) {
					sb0.append(",");
					sb1.append(",");
				}
				String key = entry.getKey();
				if (key.compareTo("detail_blob") == 0) {
					//插入表定义 16个 分布，1个总时间，1个总数量，1个最大数量
					for(int i = 0; i < PING_INTERVAL.length; i++ ){
						sb0.append(PING_DATABASE_AVER_PREF).append("_").append(i);
						sb0.append(",");
					}
					for(int i = 0; i < PING_INTERVAL.length; i++ ){
						sb0.append(PING_DATABASE_MAX_PREF).append("_").append(i);
						sb0.append(",");
					}
					sb0.append(SQL_AVER_TIME).append(",");
					sb0.append(SQL_MAX_TIME);
					
					ObjectNode pingTreeNode = (ObjectNode) entry.getValue();
					Iterator<Entry<String, JsonNode>> pingIterator = pingTreeNode.getFields();
					long totalTime = 0;
					long count = 0;
					float averTime = 0;
					float maxTime = 0;
					while (pingIterator.hasNext()) {
						Entry<String, JsonNode> pingEntry = pingIterator.next();
						ObjectNode pingNode = (ObjectNode) pingEntry.getValue();
						//获取平均时间
						int pingTotalTime = (pingNode.get(TOTAL_TIME)).getIntValue();
						int pingCount = (pingNode.get(COUNT)).getIntValue();
						int pingAverTime = 0;
						if(pingCount != 0){
							pingAverTime = pingTotalTime / pingCount;
						}else{
							pingAverTime = pingTotalTime;
						}
						
						addPingCount(ping_aver_time_interval, getPingKey(pingAverTime, PING_INTERVAL));
						//获取最大时间
						int pingMaxTime =(pingNode.get(MAX_TIME)).getIntValue();
						//插入新的组合json对象
						addPingCount(ping_max_time_interval, getPingKey(pingMaxTime, PING_INTERVAL));
						totalTime += pingTotalTime;
						count += pingCount;
						if(maxTime < pingMaxTime){
							maxTime = pingMaxTime;
						}
					}
					
					if(count != 0){
						averTime = totalTime / count;
					}else{
						averTime = totalTime;
					}
					
					//插入16个时序字段  1个平均时间字段。1个最大时间字段(全部才用int存储)
					for(int i = 0; i < PING_INTERVAL.length; i++ ){
						if(ping_aver_time_interval.containsKey(i)){
							sb1.append(ping_aver_time_interval.get(i));
						}else{
							sb1.append(0);
						}
						sb1.append(",");
					}
					for(int i = 0; i < PING_INTERVAL.length; i++ ){
						if(ping_max_time_interval.containsKey(i)){
							sb1.append(ping_max_time_interval.get(i));
						}else{
							sb1.append(0);
						}
						sb1.append(",");
					}
					
					sb1.append(averTime);
					sb1.append(",");
					sb1.append(maxTime);
				} else {
					sb0.append(key);
					sb1.append(entry.getValue().toString());
				}
				
				if (key.compareTo("ts_end") == 0) {
					timePostfix = getYearAndMonth(entry.getValue().getTextValue());
				}
				pos += 1;
			}

			sb0.append(") VALUES (").append(sb1).append(")");
			String sqlString = addInsertIntoTable(sb0, TABLE_PREFIX, timePostfix).toString();
			return sqlString;

		} catch (JsonProcessingException ex) {
			ex.printStackTrace();
			return null;
		} catch (IOException ex) {
			return null;
		} catch(Exception ex){
			ex.printStackTrace();
			return null;
		}
	}

	@Override
	public String message2svclistSql(String category, String message) {
		try {
			if(!Utils.canStoreMsgVersion(message)){
				return null;
			}
			ObjectNode root = (ObjectNode) jacksonMapper.readTree(message);
			StringBuilder sb0 = new StringBuilder("INSERT INTO ").append(
					TABLE_NAME_SVCLIST).append(" (");
			StringBuilder sb1 = new StringBuilder();
			String[][] svc = new String[4][2];
			Set<String> set = SVCList.getInstance().getSvcSet();
			Iterator<Entry<String, JsonNode>> iter = root.getFields();
			int pos = 0;
			int pos1 = 0;
			while (iter.hasNext()) {
				Entry<String, JsonNode> entry = iter.next();
				String key = entry.getKey();
				String value = entry.getValue().toString().replace("\"", "");
				if(key.trim().equalsIgnoreCase("gameid")){
					svc[0][0] = key;
					svc[0][1] = value;
				} else if(key.trim().equalsIgnoreCase("svrid")){
					svc[1][0] = key;
					svc[1][1] = value;
				} else if(key.trim().equalsIgnoreCase("svcid")){
					svc[2][0] = key;
					svc[2][1] = value;
				} else if(key.trim().equalsIgnoreCase("svc_type")){
					svc[3][0] = key;
					svc[3][1] = value;
				}
			}
			StringBuilder setkey = new StringBuilder();
			for (int i = 0; i < svc.length; i++) {
				if(svc[i][0] == null || svc[i][1] == null){
					return null;
				} else {
					if(pos1 != 0){
						setkey.append(",");
					}
					setkey.append(svc[i][1]);
				}
				pos1++;
			}
			if(!set.contains(setkey.toString())){
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
				set.add(setkey.toString());
				return sb0.toString();
			} else {
				return null;
			}
		} catch (JsonProcessingException ex) {
			ex.printStackTrace();
			return null;
		} catch (IOException ex) {
			ex.printStackTrace();
			return null;
		}
	}
	
	/**
	 * @param averValue
	 * @return
	 * 获取分布的索引key
	 */
	public int getPingKey(int averValue, int[] interval){
		int key = 0;
		for(int i = 0; i < interval.length; i++){
			if(averValue <= interval[i]){
				key = i;
				break;
			}
		}
		return key;
	}
	
	/**
	 * @param map
	 * @param key
	 * 增加该key值的分布
	 * @throws Exception 
	 */
	public void addPingCount(HashMap<Integer, Integer> map, int key) throws Exception{
		if(map.containsKey(key)){
			map.put(key, map.get(key) + 1);
		}else{
			map.put(key, 1);
		}
	}
}
