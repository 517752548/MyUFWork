package com.imop.scribe.job;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.util.HashMap;
import java.util.Iterator;
import java.util.Map;
import java.util.TreeMap;
import java.util.Map.Entry;

import org.codehaus.jackson.JsonNode;
import org.codehaus.jackson.JsonProcessingException;
import org.codehaus.jackson.map.ObjectMapper;
import org.codehaus.jackson.node.ObjectNode;
import org.quartz.Job;
import org.quartz.JobExecutionContext;
import org.quartz.JobExecutionException;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.csvreader.CsvWriter;
import com.imop.scribe.receiver.category.Perf2;
import com.imop.scribe.util.CalendarUtil;
import com.imop.scribe.util.FileUtil;

/**
 * @author wenping.jiang
 *	执行报表计划
 */
public class MsgJob implements Job {
	private static final Logger logger = LoggerFactory.getLogger("MsgJob");
	/**
	 * 最大时间
	 */
	public static final String MAX_TIME = "m";
	
	/**
	 * 总计时间
	 */
	public static final String TOTAL_TIME = "t";
	
	/**
	 * 个数
	 */
	public static final String COUNT = "c";
	
	/**
	 * 类型
	 */
	public static final String TYPE = "p";
	
	/**
	 * msg文件名的前缀
	 */
	final static String MSG_FILE_PREFIX = "msg_";
	
	
	/**
	 * json解析映射
	 */
	protected final static ObjectMapper jacksonMapper = new ObjectMapper();
	
	/**
	 * msg的存储器
	 */
	protected final TreeMap<String, MsgAnaysis> msgTreeMap = new TreeMap<String, MsgAnaysis>();
	
	/**
	 * 文件写的存储
	 */
	protected final HashMap<String, CsvWriter> writerMap = new HashMap<String, CsvWriter>();
	
	@Override
	public void execute(JobExecutionContext arg0) throws JobExecutionException {
		logger.info("msg anaysis start");
		//获取需要分析目录的文件
		String tempGMTDay = CalendarUtil.getLastGMTDay();
		File files = new File(Perf2.filePath);
		File srcFile = null;
		if(files.exists()){
			for(File temp: files.listFiles()){
				if(temp.getName().equals(MSG_FILE_PREFIX + tempGMTDay + ".log")){
					srcFile = temp;
					break;
				}
			}
		}else{
			logger.info("the msg directory " +  tempGMTDay + " miss");
		}
		
		if(srcFile!= null){
			//读取里面内容每行。进行熟悉数据存储
			//生成分析目标目录.
			File destFile = new File(Perf2.anaysisFilePath, tempGMTDay + "_anaysis");
			if(!destFile.exists()){
				destFile.mkdirs();
			}
			
			FileReader fr;
			try {
				fr = new FileReader(srcFile);
				BufferedReader reader = new BufferedReader(fr);
				String message;
				try {
					clearAnaysis();
					while((message = reader.readLine()) != null){
						try{
							//开始分析里面的程序
							ObjectNode root = (ObjectNode) jacksonMapper.readTree(message);
							//里面存有srcId, srvId,gametype,svc_type 这几个应该都是一样的放在可以里面， msg_detail
							parseMsgJSON(root);
						} catch (Exception e) {
							e.printStackTrace();
						}
					}
					
					//末尾写入文件
					msgTreeMap.comparator();
					for(Map.Entry<String, MsgAnaysis> entry: msgTreeMap.entrySet()){
						MsgAnaysis msgAnaysis = entry.getValue();
						String messagetype = entry.getKey();
						String key= messagetype.substring(0, messagetype.lastIndexOf("$"));
						String[] info = key.split("_");
						//开始生成目标文件
						//寻找该文件的写入缓存，如果没有则创建
						if(checkValid(info)){
							if(!writerMap.containsKey(key)){//有文件缓存
								File anaysisFile = new File(getDestDirect(destFile.getAbsolutePath(), info));
								if(!anaysisFile.exists()){
									anaysisFile.mkdirs();
								}
								String fileName = getDestFileName(info, tempGMTDay);
								anaysisFile = new File(anaysisFile.getAbsolutePath(), fileName+ ".csv");
								CsvWriter writer = FileUtil.getCsvWriterMessgage(anaysisFile, createComment());
								if(writer != null){
									writerMap.put(key, writer);
								}
							}
						}else{
							logger.info("no valid mssage:" + message);
						}
						if(writerMap.containsKey(key)){
							CsvWriter writer = writerMap.get(key);
							writer.write(msgAnaysis.getCsvString());
							writer.endRecord();
						}else{
							logger.info("file info unfind msgAnaysisString:" + msgAnaysis.toString());
						}
						
					}
				} catch (JsonProcessingException e) {
					e.printStackTrace();
				} catch (IOException e) {
					e.printStackTrace();
				}
			} catch (FileNotFoundException e) {
				e.printStackTrace();
			} catch (Exception e) {
				e.printStackTrace();
			}
			finally{
				//结束所有写入
				for(Map.Entry<String, CsvWriter> temp: writerMap.entrySet()){
					CsvWriter writer = temp.getValue();
					writer.close();
				}
			}
		}else{
			logger.info("the msg log " +  tempGMTDay + " not find");
		}
	}
	
	/**
	 * @param info
	 * @return
	 * 分离出来的字符串是否合法
	 */
	public boolean checkValid(String[] info){
		boolean flag = true;
		if(info == null || info.length != 4){
			flag = false;
		}else{
			for(int i = 0; i < info.length; i++){
				if(info[1] == null && info[i].length() == 0){
					flag = false;
					break;
				}
			}
		}
		return flag;
	}
	/**
	 * @param info
	 * @param date
	 * @return生成文件名称 gamid 0, svcId 2
	 */
	public String getDestFileName(String[] info, String date){
		StringBuffer buffer = new StringBuffer();
		buffer.append(info[0]);
		buffer.append("_");
		buffer.append(info[2]);
		buffer.append("_");
		buffer.append(date);
		return buffer.toString();
	}
	/**
	 * @param path
	 * @param info
	 * @return
	 * 生成总目录 svrid 1, svctype 3
	 */
	public String getDestDirect(String path, String[] info){
		File file = new File(path, info[1]);
		file = new File(file.getAbsolutePath(), info[3]);
		if(!file.exists()){
			file.mkdirs();
		}
		return file.getAbsolutePath();
		
	}
	/**
	 * 清理分析
	 */
	public void clearAnaysis(){
		msgTreeMap.clear();
	}
	
	/**
	 * @param msg
	 * 解析msg创建文件名称
	 */
	public void parseMsgJSON(ObjectNode msg){
		try{
			String gameId = msg.get("gameid").getTextValue();
			String svrId = msg.get("svrid").getTextValue();
			String svcId = msg.get("svcid").getTextValue();
			String svc_type = msg.get("svc_type").getTextValue();
			JsonNode node = msg.get("msg_detail");
			if(node != null){
				//获取里面的每个消息类型，并进行统计
				ObjectNode detailNode = (ObjectNode) node;
				Iterator<Entry<String, JsonNode>> pingIterator = detailNode.getFields();
				long i = 0;
				while (pingIterator.hasNext()) {
					logger.info("gameid:" + gameId + " svrid:" + svrId + " svcid:" + svcId
							+ "svc_type:" + svcId + "order" + i);
					Entry<String, JsonNode> msgEntry = pingIterator.next();
					ObjectNode msgNode = (ObjectNode) msgEntry.getValue();
					//获取平均时间
					String msgType = (msgNode.get(TYPE)).getTextValue();
					int pingTotalTime = (msgNode.get(TOTAL_TIME)).getIntValue();
					int pingCount = (msgNode.get(COUNT)).getIntValue();
					int maxTime = (msgNode.get(MAX_TIME)).getIntValue();
					
					//生成存储的key值
					StringBuffer buffer = new StringBuffer();
					buffer.append(gameId);
					buffer.append("_");
					buffer.append(svrId);
					buffer.append("_");
					buffer.append(svcId);
					buffer.append("_");
					buffer.append(svc_type);
					buffer.append("$");
					buffer.append(getShortMsgType(msgType));
					String key = buffer.toString();
					
					//加入总用时，最大数,平均时间
					if(msgTreeMap.containsKey(key)){
						MsgAnaysis msgAnaysis = msgTreeMap.get(key);
						addMsgAnaysis(msgAnaysis, pingTotalTime, pingCount, maxTime);
					}else{
						MsgAnaysis msgAnaysis = new MsgAnaysis(getShortMsgType(msgType));
						addMsgAnaysis(msgAnaysis, pingTotalTime, pingCount, maxTime);
						msgTreeMap.put(key, msgAnaysis);
					}
					i++;
				}
			}
		}catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	/**
	 * @param msgAnaysis
	 * @param pingTotalTime
	 * @param pingCount
	 * @param maxTime
	 * 进行msg分析统计
	 */
	public void addMsgAnaysis(MsgAnaysis msgAnaysis, int pingTotalTime, int pingCount , int maxTime){
		msgAnaysis.addTotalTime(pingTotalTime);
		msgAnaysis.addCount(pingCount);
		msgAnaysis.compareMaxTime(maxTime);
	}
	/**
	 * @param msgType
	 * @return
	 *  暂时作废：删除掉msg的包名(采用方案是 按照删除空格后的所有字符串) 
	 */
	public String getShortMsgType(String msgType){
//		if(!msgType.contains(" ")){
//			return msgType;
//		}
//		return msgType.substring(0, msgType.indexOf(" "));
		return msgType;
	}
	
	/**
	 * @return'
	 * 生成注释
	 */
	public String createComment(){
		StringBuffer buffer = new StringBuffer();
		buffer.append("msgtype,");
		buffer.append("totaltime,");
		buffer.append("count,");
		buffer.append("avertime,");
		buffer.append("maxTime");
		return buffer.toString();
	}
}
