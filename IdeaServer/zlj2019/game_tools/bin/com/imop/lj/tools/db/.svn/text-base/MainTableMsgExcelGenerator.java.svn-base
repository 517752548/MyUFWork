package com.imop.lj.tools.db;

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
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import javax.persistence.Table;

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

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.LogReasons.LogDesc;
import com.imop.lj.core.annotation.Comment;
import com.imop.lj.core.config.ConfigUtil;
import com.imop.lj.tools.log.LogMsgGenerator.Field;
import com.imop.lj.tools.log.LogMsgGenerator.LogConfig;

public class MainTableMsgExcelGenerator {
	
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
	
	/**主表列表描述*/
	private static final List<EntityDesc> entityDescList = Lists.newArrayList();
	
	/**数据库表字段详情*/
	private static final Map<String,List<EntityFieldDesc>> allFieldsMap = Maps.newHashMap();
	
	public static void main(String[] args) throws IOException {
		start();
	}
	
	public static void start() {
		MainTableMsgGenConfig _config = buildMainTableMsgGenConfig();
		String mainEntitiesDir = _config.getMainEntitisDir();//加载*Entity.java文件对应的game_db的目录
		String entityPackageName = _config.getEntityPackageName();//数据库实例包名
		/**初始化列表信息*/
		initEntityDesc(mainEntitiesDir,entityPackageName);
	
		/**初始化所有的字段数据*/
		initAllFieldsMap(entityPackageName);
		
		String mainTableExcelPath = "doc/";
		
		//生成excel文件
		generateExcelFile(mainTableExcelPath,"游戏审计数据表.xls");
	}
	
	public static void initAllFieldsMap(String packageName) {
		
		for (EntityDesc entityDesc : entityDescList) {
			String className = packageName +"."+entityDesc.getClassName();
			String tableName = entityDesc.getTableName();
			List<EntityFieldDesc> fieldList = getFieldDescList(className);
			allFieldsMap.put(tableName, fieldList);
		}
		
	}
	
	public static List<EntityFieldDesc> getFieldDescList(String className) {
		List<EntityFieldDesc> fieldList = new ArrayList<EntityFieldDesc>();
		Class entityClass = null;
		try {
			entityClass = Class.forName(className);
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
			return fieldList;
		}
		
		java.lang.reflect.Field[] fields = entityClass.getDeclaredFields();
		
		for (java.lang.reflect.Field field : fields) {
			Comment comment = (Comment)field.getAnnotation(Comment.class);
			if(comment == null) {
				continue;
			}
			
			EntityFieldDesc fieldDesc = new EntityFieldDesc();
			fieldDesc.setDesc(comment.content());
			fieldDesc.setFieldName(field.getName());
			fieldList.add(fieldDesc);
		}
		
		return fieldList;
	}
	
	public static void initEntityDesc(String mainDir,String packageName) {
		File file = new File(mainDir);
		String[] files = file.list();
		for (String fileName : files) {
			String className = getClassName(fileName);
			if(className == null) {
				continue;
			}
			
			String classFullName = packageName+"."+className;
			EntityDesc entityDesc = getRegisterEntityClassDesc(classFullName);
			if(entityDesc == null) {
				continue;
			}
			entityDescList.add(entityDesc);
			System.out.println("className="+className);
		}
	}
	
	public static boolean isJavaFile(String fileName) {
		if(!fileName.endsWith(".java")) {
			return false;
		}
		return true;
	}
	
	public static String getClassName(String fileName) {
		if(!isJavaFile(fileName)) {
			return null;
		}
		int index = fileName.indexOf(".");
		if(index < 0) {
			return null;
		}
		String className = fileName.substring(0, index);
		
		return className;
	}
	

	/***
	 * 获得entity类的详细数据
	 * @param className
	 * @return
	 */
	public static EntityDesc getRegisterEntityClassDesc(String className) {
		Class entityClass = null;
		try {
			entityClass = Class.forName(className);
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
			return null;
		}
		if(entityClass == null) {
			return null;
		}
		
		Table table = (Table) entityClass.getAnnotation(Table.class);
		if(table == null || table.name() == null || table.name().isEmpty()) {
			return null;
		}
		
		Comment comment = (Comment) entityClass.getAnnotation(Comment.class);
		if(comment == null || comment.content() == null || comment.content().isEmpty()) {
			return null;
		}
		
		EntityDesc desc = new EntityDesc();
		desc.setClassName(entityClass.getSimpleName());
		desc.setTableName(table.name());
		desc.setDesc(comment.content());
		return desc;
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
	
	private static MainTableMsgGenConfig buildMainTableMsgGenConfig() {
		ClassLoader _classLoader = Thread.currentThread().getContextClassLoader();
		URL _url = _classLoader.getResource("log/main_table_msg_gen.cfg.js");
		return ConfigUtil.buildConfig(MainTableMsgGenConfig.class, _url);
	}
	
	
	private static void generateExcelFile(String dir,String fileName) {
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
			createInfoFrontTableSheet(dir, fileName);
			//创建LogTable表
			createLogInfoTableSheet(dir, fileName);
			//创建每个Log的详情表
			createLogDetailSheet(dir, fileName);
			
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
		
		String logReason = "com.imop.ceo.common.LogReasons${0}Reason";
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
	
	public static void createInfoFrontTableSheet(String dir,String fileName) throws IOException, RowsExceededException, WriteException {
		
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
	public static void createLogInfoTableSheet(String dir,String fileName) throws IOException, RowsExceededException, WriteException {
		
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
		for (EntityDesc entityDesc : entityDescList) {
			sheetRowIndex++;
			String _logName = entityDesc.getTableName();
//			_logName = _logName.substring(0,1).toLowerCase()+_logName.substring(1);
//			_logName = _logName.replaceAll("([A-Z]{1})","_$1").toLowerCase();
			//添加Log名称
			Label namelab = new Label(logNameIndex, sheetRowIndex, _logName,format);
			tableSheet.addCell(namelab);
			//添加log注释
			String logReason = entityDesc.getDesc();
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
	public static void createLogDetailSheet(String dir,String fileName) throws IOException, RowsExceededException, WriteException {

			WritableCellFormat format = new WritableCellFormat();
			int sheetWidth = 30;
			int logIndex = LOG_TABLE_INFO_SHEET_INDEX+1;
			
			for (String key : allFieldsMap.keySet()) {
				System.out.println("key="+key);
				String _logName = key;//key.substring(key.lastIndexOf(".") + 1);
//				_logName = _logName.substring(0,1).toLowerCase()+_logName.substring(1);
//				_logName = _logName.replaceAll("([A-Z]{1})","_$1").toLowerCase();
				WritableSheet workSheet = wwbook.createSheet(_logName, logIndex);
				List<EntityFieldDesc> fieldList = allFieldsMap.get(key);
				
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
				for (EntityFieldDesc fieldDesc : fieldList) {
					Label nameCell = new Label(nameIndex, fieldIndex, fieldDesc.getFieldName(),format);
					Label infoCell = new Label(infoIndex, fieldIndex, fieldDesc.getDesc(),format);
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
