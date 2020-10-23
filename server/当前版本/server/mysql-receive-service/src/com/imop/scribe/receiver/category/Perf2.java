package com.imop.scribe.receiver.category;

import java.io.File;
import java.io.IOException;
import java.util.Iterator;
import java.util.Map.Entry;
import java.util.Set;

import org.codehaus.jackson.JsonNode;
import org.codehaus.jackson.JsonProcessingException;
import org.codehaus.jackson.map.ObjectMapper;
import org.codehaus.jackson.node.ObjectNode;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.scribe.receiver.Category;
import com.imop.scribe.receiver.SVCList;
import com.imop.scribe.util.CalendarUtil;
import com.imop.scribe.util.FileUtil;
import com.imop.scribe.util.Utils;

/**
 * @author wenping.jiang
 *	messge的处理相应
 */
public class Perf2 extends Category {
	private static final Logger logger = LoggerFactory.getLogger("Perf2");
	final static String CATEGORY_NAME = "probe.perf2";
	final static String TABLE_PREFIX = "perf";
	final static String TABLE_NAME_SVCLIST = "svclist";
	
	final static String MSG_FILE_PREFIX = "msg_";
	/**
	 * 生成的文件地址
	 */
	public static String filePath;
	
	/**
	 * 分析生成的目标文件地址
	 */
	public static String anaysisFilePath;
	
	public Perf2(){
	}
	public String getCategoryName() {
		return CATEGORY_NAME;
	}

	@Override
	public String getTablePrefix() {
		return TABLE_PREFIX;
	}

	@Override
	public String messageToInsertSQL(String category, String message) {
		System.out.println(message);
		if(!Utils.canStoreMsgVersion(message)){
			return null;
		}
		
		String tempGMTDayString = CalendarUtil.getGMTDDay();
		File file = new File(filePath);
		if(!file.exists()){
			file.mkdirs();
		}
		//生成根目录
		String fileName = getMsgFileName(message, jacksonMapper,tempGMTDayString);
		if(fileName != null){
			file = new File(filePath,fileName);
			if(file != null){
				FileUtil.writeLogLineMessage(file, message);
			}
		}else{
			logger.info("recive message cannot getmsgfilename: " + message);
		}
		return null;
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
	 * @param message
	 * @param jacksonMapper
	 * @return从message里面获取需要写入的文件名称
	 */
	public String getMsgFileName(String message, ObjectMapper jacksonMapper, String dayString){
		ObjectNode root;
		try {
			root = (ObjectNode) jacksonMapper.readTree(message);
			/*String[][] svc = new String[4][2];
			Iterator<Entry<String, JsonNode>> iter = root.getFields();
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
			int pos = 0;
			StringBuilder setkey = new StringBuilder();
			for (int i = 0; i < svc.length; i++) {
				if(svc[i][0] == null || svc[i][1] == null){
					return null;
				} else {
					if(pos != 0){
						setkey.append("_");
					}
					setkey.append(svc[i][1]);
				}
				pos++;
			}*/
			StringBuilder setkey = new StringBuilder();
			setkey.append(MSG_FILE_PREFIX);
			//默认加上系统当前gmt时间
			setkey.append(dayString);
			setkey.append(".log");
			return setkey.toString();
		} catch (JsonProcessingException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return null;
	}
	
//	public static void main(String[] args) {
//		String message = "{\"logversion\":1,\"gameid\":\"ss\",\"svrid\":\"s1.l.webzt.com\",\"svcid\":\"5\",\"svc_type\":\"gameserver\",\"hostid\":\"tianshu-test0\",\"ts_begin\":\"2011-01-01 22:07:35\",\"ts_end\":\"2011-01-01 22:12:35\",\"cpu_avg\":0.66,\"mem_usage\":917,\"users\":0,\"login_users\":0,\"logout_users\":0,\"fmt\":\"j\",\"detail_blob\":{\"scene_num\":\"17\",\"scene_human\":\"n40001=0,n40305=0,n40221=0,n40001=0,n40001=0,n40201=0,n40211=0,n40202=0,n40303=0,n40203=0,n40304=0,n40222=0,n40213=0,n20301=0,n40223=0,n40001=0,n40212=0\",\"sceneMonster\":\"n40001=0,n40305=105,n40221=0,n40001=0,n40001=0,n40201=0,n40211=0,n40202=0,n40303=105,n40203=0,n40304=105,n40222=0,n40213=0,n20301=210,n40223=0,n40001=0,n40212=0\"}}";
//		System.out.println(new Perf2().message2svclistSql("", message));
//	}
}
