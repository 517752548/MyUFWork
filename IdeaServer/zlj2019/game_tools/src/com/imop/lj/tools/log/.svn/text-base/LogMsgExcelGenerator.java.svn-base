package com.imop.lj.tools.log;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.UnsupportedEncodingException;
import java.net.URL;
import java.text.MessageFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import jxl.Workbook;
import jxl.format.Alignment;
import jxl.format.Colour;
import jxl.format.UnderlineStyle;
import jxl.write.Label;
import jxl.write.WritableCellFormat;
import jxl.write.WritableFont;
import jxl.write.WritableSheet;
import jxl.write.WritableWorkbook;
import jxl.write.WriteException;
import jxl.write.biff.RowsExceededException;

import com.google.common.collect.Maps;
import com.imop.lj.common.LogReasons.LogDesc;
import com.imop.lj.core.config.ConfigUtil;
import com.imop.lj.tools.log.LogMsgGenerator.Field;
import com.imop.lj.tools.log.LogMsgGenerator.LogConfig;

public class LogMsgExcelGenerator {
	
	/** 日志文件信息 */
	private static final Pattern LOG_FILE_INFO = Pattern.compile("([^\\s]+)\\s+([^\\s]+)\\s+([^\\s]+)");
	
	/** 日志文件信息 */
	private static final Pattern LOG_FILE_SIZE_INFO = Pattern.compile("([^\\s]+)\\s+([^\\s]+)\\s+([^\\s]+)\\s+([^\\s]+)\\s+([^\\s]+)\\s+([^\\s]+)\\s+([^\\s]+)\\s+([^\\s]+)");
	
	/** 消息格式 message className( */
	private static final Pattern MESSAGE_HEADER = Pattern.compile("message\\s+(.+)\\s*\\(");

	/** 字段格式 type fieldName constraint */
	private static final Pattern MESSAGE_FIELD = Pattern.compile("([^\\s]+)\\s+([^\\s]+)\\s*(.*);\\s*[//]*(.*)");
	
	/**LogInfo的Sheet索引*/
	private static final int  LOG_INFO_SHEET_INDEX = 0;
	
	/**LogInfo的Sheet索引*/
	private static final String  LOG_INFO_SHEET_NAME = "Info";
	
	/**LogTable的Sheet索引*/
	private static final int  LOG_TABLE_INFO_SHEET_INDEX = 1;
	/**LogTable的Sheet名称*/
	private static final String  LOG_TABLE_INFO_SHEET_NAME = "logTables";

	/**存储Log文件的大小 KEY:文件名称 value：文件大小*/
	private static final Map<String,String> logCapMap = Maps.newHashMap();
	
	private static WritableWorkbook wwbook;
	
	public static void main(String[] args) throws IOException {
		start();
	}
	
	public static void start() throws IOException {
		
		LogMsgGenConfig _config = buildLogMsgGenConfig();
		String _packageName = _config.getPackageName();//导出model文件对应logserver的包名
		String _logServerDir = _config.getLogServerDir();//导出MessageType.java对应logserver的包名
		String _logServiceDir = _config.getLogServiceDir(); //导出文件对应gameserver的包名
		String _logSrcGenDir = _config.getLogSrcGenDir();//导出logs文件的根目录
		String _logResGenDir = _config.getLogResGenDir();//导出logs ibatis配置文件片段的根目录
		String _gsGenDir = _config.getGsGenDir();//导出gameserver文件根目录
		String _logConfig = _config.getLogConfig(); //自动导出消息文件的配置文件
		String _msgDir = _config.getMsgDir();//消息模板目录
		System.out.println("_packageName="+_packageName);
		System.out.println("_logServerDir="+_logServerDir);
		System.out.println("_logServiceDir="+_logServiceDir);
		System.out.println("_logSrcGenDir="+_logSrcGenDir);
		System.out.println("_logResGenDir="+_logResGenDir);
		System.out.println("_gsGenDir="+_gsGenDir);
		System.out.println("_logConfig="+_logConfig);
		System.out.println("_msgDir="+_msgDir);
		
		BufferedReader _reader = new BufferedReader(new InputStreamReader(new FileInputStream(_logConfig)));
		String _line = null;

		/* 解析日志配置文件列表 */
		List<LogConfig> _logConfigs = new ArrayList<LogConfig>();
		while ((_line = _reader.readLine()) != null) {
			_line = _line.trim();
			if (_line.length() == 0) {
				continue;
			}
			Matcher _matcher = LOG_FILE_INFO.matcher(_line);
			if (_matcher.matches()) {
				LogConfig _log = new LogConfig(_matcher.group(1), _matcher.group(2), _matcher.group(3));
				_logConfigs.add(_log);
			}
		}
		_reader.close();
		Map<String, Map<String, Field>> allLogMap = new HashMap<String, Map<String,Field>>();
		/* 导出日志xml配置文件和日志消息.java */
		for(LogConfig _logType : _logConfigs) {
			 Map<String, Field> logMap = generateMessageConfig(_msgDir + _logType.getLogFile(), _packageName, _logSrcGenDir, _logType);
			 allLogMap.put(_logType.getLogFileName(), logMap);
		}
		
		String logExcelPath = "doc/";
		//加载log文件
		loadLogFiles(logExcelPath,"log_size.txt");
		
		//生成excel文件
		generateExcelFile(logExcelPath,"游戏审计日志表.xls",allLogMap);
	}
	
	/***
	 * 加载log文件
	 * @param path
	 * @param fileName
	 * @throws IOException
	 */
	private static void loadLogFiles(String path,String fileName) throws IOException {
		
		File file= new File(path+fileName);
		if(!file.exists()) {
			System.out.println(fileName+" not exist!");
			return;
		}
		
		BufferedReader _reader = new BufferedReader(new InputStreamReader(new FileInputStream(path+fileName)));
		String _line = null;
		String _msgName = null;
		// 解析消息定义的字段
//		Map<String, Field> _fieldMap = new LinkedHashMap<String, Field>();
		//_fieldMap.putAll(sharedFieldMap);
		
		while ((_line = _reader.readLine()) != null) {
			_line = _line.trim();
			if (_line.length() == 0) {
				continue;
			}
			Matcher _matcher = LOG_FILE_SIZE_INFO.matcher(_line);
			if (_matcher.matches()) {
//				System.out.println(_matcher.group(1));
//				System.out.println(_matcher.group(2));
//				System.out.println(_matcher.group(3));
//				System.out.println(_matcher.group(4));
//				System.out.println(_matcher.group(5));
//				System.out.println(_matcher.group(6));
//				System.out.println(_matcher.group(7));
//				System.out.println(_matcher.group(8));
				System.out.println("||||||||||||||||||||||");
				String name = _matcher.group(8);
				String fileSize = _matcher.group(5);
				if(name.endsWith(".MYD")) {
					System.out.println(name+":"+fileSize);
					logCapMap.put(name, fileSize);
				}
			}
		}
		_reader.close();	
	}
	
	private static LogMsgGenConfig buildLogMsgGenConfig() {
		ClassLoader _classLoader = Thread.currentThread().getContextClassLoader();
		URL _url = _classLoader.getResource("log/log_msg_gen.cfg.js");
		return ConfigUtil.buildConfig(LogMsgGenConfig.class, _url);
	}
	
	
	private static void generateExcelFile(String dir,String fileName,Map<String, Map<String, Field>> allLogData) {
		System.out.println("filePath="+dir);
		
		try {
			File dirFile = new File(dir);
			if(!dirFile.exists()) {
				dirFile.mkdir();
			}
			File xlsFile = new File(dir+fileName);
			if (!xlsFile.exists()) {
				xlsFile.createNewFile();
			}
			
			wwbook = Workbook.createWorkbook(xlsFile);
			
			//创建首页表
			createInfoFrontTableSheet(dir, fileName, allLogData);
			//创建LogTable表
			createLogInfoTableSheet(dir, fileName, allLogData);
			//创建每个Log的详情表
			createLogDetailSheet(dir, fileName, allLogData);
			
			wwbook.write();
			wwbook.close();
			
		} catch (RowsExceededException e) {
			e.printStackTrace();
		} catch (WriteException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	
	/****
	 * 获得LogReason
	 * @param logName
	 * @return
	 */
	public static String getLogReason(String logName) {
		
		String logReason = "com.imop.lj.common.LogReasons${0}Reason";
		String logReasonClassName = MessageFormat.format(logReason, logName);
		
		try {

			Class reason = Class.forName(logReasonClassName);
			LogDesc _reasonDesc = (LogDesc) reason.getAnnotation(LogDesc.class);
			System.out.println(_reasonDesc.desc());
			return _reasonDesc.desc();
		} catch (ClassNotFoundException e) {
			System.out.println("logReasonClassName="+logReasonClassName+" not found");
			return "";
		}
	}
	
	public static void createInfoFrontTableSheet(String dir,String fileName,Map<String, Map<String, Field>> allLogData) throws IOException, RowsExceededException, WriteException {
		
		WritableSheet tableSheet = wwbook.createSheet(LOG_INFO_SHEET_NAME, LOG_INFO_SHEET_INDEX);
		
		WritableFont font = new WritableFont(WritableFont.createFont("微软雅黑"),14,WritableFont.NO_BOLD,false,UnderlineStyle.NO_UNDERLINE);
		WritableCellFormat format = new WritableCellFormat();
		format.setFont(font);
		
		WritableFont vFont = new WritableFont(WritableFont.createFont("微软雅黑"),14,WritableFont.NO_BOLD,false,UnderlineStyle.NO_UNDERLINE);
		WritableCellFormat vFormat = new WritableCellFormat();
		vFont.setColour(Colour.BLUE_GREY);
		vFormat.setFont(vFont);
		int sheetWidth = 30;
		tableSheet.setColumnView(0, sheetWidth);
		tableSheet.setColumnView(1, sheetWidth);
		
		//列索引
		int TABLE_SHUOMING = 0;
		int TABLE_DATE = 1;
		int TABLE_GAME_ID = 2;
		int TABLE_GAME_NAME = 3;
		int TABLE_DATABASE_NAME = 4;
		int TABLE_LOG_DATABASE_NAME = 5;
		
		Date date = new Date();
		SimpleDateFormat dateFormat = new SimpleDateFormat("yyyy-MM-dd");
		
		Label shuoMingLable = new Label(0, TABLE_SHUOMING, "表格说明",format);
		Label shuoMingValueLable = new Label(1, TABLE_SHUOMING, "",vFormat);
		
		Label dateLabel = new Label(0, TABLE_DATE, "更新日期",format);
		Label dateValueLabel = new Label(1, TABLE_DATE, dateFormat.format(date),vFormat);
		
		Label gameIdLabel = new Label(0, TABLE_GAME_ID, "游戏ID",format);
		Label gameIdValueLabel = new Label(1, TABLE_GAME_ID, "ceo",vFormat);
		
		Label gameNameLabel = new Label(0, TABLE_GAME_NAME, "游戏名称",format);
		Label gameNameValueLabel = new Label(1, TABLE_GAME_NAME, "战龙诀",vFormat);
		
		Label gameDataNameLabel = new Label(0, TABLE_DATABASE_NAME, "数据库名",format);
		Label gameDataNameValueLabel = new Label(1, TABLE_DATABASE_NAME, "tr",vFormat);
		
		Label gameLogDataNameLabel = new Label(0, TABLE_LOG_DATABASE_NAME, "日志数据库名",format);
		Label gameLogDataNameValueLabel = new Label(1, TABLE_LOG_DATABASE_NAME, "tr_log",vFormat);
		
		tableSheet.addCell(shuoMingLable);
		tableSheet.addCell(shuoMingValueLable);
		tableSheet.addCell(dateLabel);
		tableSheet.addCell(dateValueLabel);
		tableSheet.addCell(gameIdLabel);
		tableSheet.addCell(gameIdValueLabel);
		tableSheet.addCell(gameNameLabel);
		tableSheet.addCell(gameNameValueLabel);
		tableSheet.addCell(gameDataNameLabel);
		tableSheet.addCell(gameDataNameValueLabel);
		tableSheet.addCell(gameLogDataNameLabel);
		tableSheet.addCell(gameLogDataNameValueLabel);
	}
	
	/***
	 * 创建Log表单Sheet
	 * @param dir
	 * @param fileName
	 * @param allLogData
	 * @throws IOException 
	 * @throws WriteException 
	 * @throws RowsExceededException 
	 */
	public static void createLogInfoTableSheet(String dir,String fileName,Map<String, Map<String, Field>> allLogData) throws IOException, RowsExceededException, WriteException {
		
		WritableCellFormat format = new WritableCellFormat();
		format.setAlignment(Alignment.RIGHT);
		WritableSheet tableSheet = wwbook.createSheet(LOG_TABLE_INFO_SHEET_NAME, LOG_TABLE_INFO_SHEET_INDEX);
		int sheetWidth = 30;
		
		//列索引
		int logNameIndex = 0;
		int logKeepIndex = 1;
		int logReasonIndex = 2;
		int logDataCapIndex = 3;
		int logRelationTableIndex = 4;
		
		int sheetRowIndex = 0;
		Label nameLable = new Label(logNameIndex, sheetRowIndex, "表名前缀");
		Label keepLable = new Label(logKeepIndex, sheetRowIndex, "是否保留");
		Label reasonLable = new Label(logReasonIndex, sheetRowIndex, "内容说明");
		Label logDataCapLable = new Label(logDataCapIndex, sheetRowIndex, "数据量估计");
		Label logRelationLable = new Label(logRelationTableIndex, sheetRowIndex, "相关数据表");
		
		tableSheet.addCell(nameLable);
		tableSheet.setColumnView(logNameIndex, sheetWidth);
		tableSheet.addCell(keepLable);
		tableSheet.setColumnView(logKeepIndex, sheetWidth);
		tableSheet.addCell(reasonLable);
		tableSheet.setColumnView(logReasonIndex, sheetWidth);
		tableSheet.addCell(logDataCapLable);
		tableSheet.setColumnView(logDataCapIndex, sheetWidth);
		tableSheet.addCell(logRelationLable);
		tableSheet.setColumnView(logRelationTableIndex, sheetWidth);
		for (String key : allLogData.keySet()) {
			sheetRowIndex++;
			String _logName = key.substring(key.lastIndexOf(".") + 1);
			_logName = _logName.substring(0,1).toLowerCase()+_logName.substring(1);
			_logName = _logName.replaceAll("([A-Z]{1})","_$1").toLowerCase();
			//添加Log名称
			Label namelab = new Label(logNameIndex, sheetRowIndex, _logName,format);
			tableSheet.addCell(namelab);
			//添加log注释
			String logReason = getLogReason(key);
			Label reasonlab = new Label(logReasonIndex, sheetRowIndex, logReason);
			tableSheet.addCell(reasonlab);
			
			String capacity = null;
			for (String logName:logCapMap.keySet()) {
				if(logName.startsWith(_logName)) {
					capacity = logCapMap.get(logName);
					System.out.println("excel="+logName+":"+capacity);
					break;
				}
			}
			
			if(capacity == null) {
				capacity = "";
			}
			
			Label capLabel = new Label(logDataCapIndex, sheetRowIndex, capacity);
			tableSheet.addCell(capLabel);
		}
	}
	
	/***
	 * 创建Log详情Sheet
	 * @param dir
	 * @param fileName
	 * @param allLogData
	 * @throws IOException
	 * @throws RowsExceededException
	 * @throws WriteException
	 */
	public static void createLogDetailSheet(String dir,String fileName,Map<String, Map<String, Field>> allLogData) throws IOException, RowsExceededException, WriteException {

			WritableCellFormat format = new WritableCellFormat();
			int sheetWidth = 30;
			int logIndex = LOG_TABLE_INFO_SHEET_INDEX+1;
			
			for (String key : allLogData.keySet()) {
				System.out.println("key="+key);
				String _logName = key.substring(key.lastIndexOf(".") + 1);
				_logName = _logName.substring(0,1).toLowerCase()+_logName.substring(1);
				_logName = _logName.replaceAll("([A-Z]{1})","_$1").toLowerCase();
				WritableSheet workSheet = wwbook.createSheet(_logName, logIndex);
				Map<String, Field> logMap = allLogData.get(key);
				
				//列索引
				int nameIndex = 0;
				int infoIndex = 1;
				
				int fieldIndex = 0;
				Label nameLabel = new Label(nameIndex, fieldIndex, "字段名称",format);
				Label infoLabel = new Label(infoIndex, fieldIndex, "内容说明",format);
				fieldIndex++;
				workSheet.addCell(nameLabel);
				workSheet.setColumnView(nameIndex, sheetWidth);
				workSheet.addCell(infoLabel);
				workSheet.setColumnView(infoIndex, sheetWidth);
				for (Field field : logMap.values()) {
					Label nameCell = new Label(nameIndex, fieldIndex, field.getName(),format);
					Label infoCell = new Label(infoIndex, fieldIndex, field.getFieldInfo(),format);
					workSheet.addCell(nameCell);
					workSheet.addCell(infoCell);
					fieldIndex++;
				}
				logIndex++;
			}

	}
	
	/**
	 * 解析每一个Log文件
	 * 
	 * @param msgConfig
	 * @param packageName
	 * @param sourceDir
	 * @throws FileNotFoundException
	 * @throws IOException
	 * @throws UnsupportedEncodingException
	 */
	private static Map<String, Field> generateMessageConfig(String msgFile, String packageName, String sourceDir, LogConfig logConfig) throws FileNotFoundException, IOException, UnsupportedEncodingException {
		BufferedReader _reader = new BufferedReader(new InputStreamReader(new FileInputStream(msgFile)));
		String _line = null;
		String _msgName = null;

		// 解析消息定义的名称和类型
		while ((_line = _reader.readLine()) != null) {
			_line = _line.trim();
			if (_line.length() == 0) {
				continue;
			}
			do {
				Matcher _matcher = MESSAGE_HEADER.matcher(_line);
				if (_matcher.matches()) {
					_msgName = _matcher.group(1);
					break;
				}
			} while (false);
			if (_msgName != null) {
				break;
			}
		}
		if (_msgName == null || _msgName.length() == 0) {
			throw new IllegalArgumentException("Bad message format,no Entity Class name:" + _line);
		}

		// 解析消息定义的字段
		Map<String, Field> _fieldMap = new LinkedHashMap<String, Field>();
		//_fieldMap.putAll(sharedFieldMap);
		
		while ((_line = _reader.readLine()) != null) {
			_line = _line.trim();
			if (_line.length() == 0) {
				continue;
			}
			Matcher _matcher = MESSAGE_FIELD.matcher(_line);
			if (_matcher.matches()) {
				Field _f = new Field(_matcher.group(2), _matcher.group(1), _matcher.group(3), _matcher.group(4));
				if(_fieldMap.containsKey(_matcher.group(2))) {
					throw new IllegalArgumentException("Duplicate variable name '" + _matcher.group(2) + "' in " + msgFile + " !");
				}
				_fieldMap.put(_matcher.group(2), _f);
			}
		}
		_reader.close();	
		return _fieldMap;
	}
	
}
