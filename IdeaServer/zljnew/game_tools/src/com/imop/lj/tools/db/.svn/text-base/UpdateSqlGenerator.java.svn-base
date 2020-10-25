package com.imop.lj.tools.db;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import org.apache.log4j.Logger;
import org.apache.velocity.VelocityContext;
import org.apache.velocity.texen.util.FileUtil;
import org.jdom.Document;
import org.jdom.Element;
import org.jdom.Namespace;
import org.jdom.input.SAXBuilder;

import com.imop.lj.tools.log.LogReasonListSqlGenerator;
import com.imop.lj.tools.util.GeneratorHelper;

/**
 * updateSql、initSql生成器
 *
 */
public class UpdateSqlGenerator {
	private static final Logger logger = Logger.getLogger(UpdateSqlGenerator.class);

	public static final String MERGE_CONFIG_FILE = "db/update_sql.xml";

	public static final Namespace NAME_SPACE = Namespace.getNamespace("http://com.imop.lj.merge");

	public static final String mergeSqlFile = "..\\game_tools\\target\\game_server_target\\db\\db_update.sql";

	public static final String TEMPLATE_DIC = "db/";

	private static final String mergeSqlTemplates = "update_sql.vm";

	// 以此库为准导出init sql
	public static final String localDbName = "lj_release";
	public static final String localDbIp = "192.168.1.132";
	
	private static final String initSqlTemplates = "init_sql.vm";
	public static final String initSqlFile = "..\\game_db\\sql\\initsql\\db_init.sql";//"..\\game_tools\\target\\game_server_target\\db\\db_init.sql";
	public static final String localUpdateFileName = "..\\game_tools\\target\\game_server_target\\db\\local_update.sql";
	public static final String localDbInitFileName = "..\\game_tools\\target\\game_server_target\\db\\local_db_init.sql";

	private static String VERSION = "";
	
	// 目前支持的 增加字段 的定义
	private static final Map<String, UpdateSqlColumnInfo> ColumnTypeMap = new HashMap<>();
	{
		ColumnTypeMap.put("int", new UpdateSqlColumnInfo("int", 11, true, "0"));
		ColumnTypeMap.put("bigint", new UpdateSqlColumnInfo("bigint", 20, true, "0"));
		ColumnTypeMap.put("varchar", new UpdateSqlColumnInfo("varchar", 255, false, "NULL"));
		ColumnTypeMap.put("text", new UpdateSqlColumnInfo("text", 0, false, ""));
		ColumnTypeMap.put("longtext", new UpdateSqlColumnInfo("longtext", 0, false, ""));
	}
	
	public UpdateSqlGenerator() {

	}
	
	@SuppressWarnings({ "rawtypes" })
	public void genUpdateSql() throws Exception{
		try {
			String configFilePath = GeneratorHelper.getBuildPath(MERGE_CONFIG_FILE);
			SAXBuilder builder = new SAXBuilder();
			Document doc = builder.build(configFilePath);
			Element root = doc.getRootElement();
			
			// 版本号
			List vl = root.getChildren("version", NAME_SPACE);
			for (Iterator i = vl.iterator(); i.hasNext();) {
				Element versionE = (Element) i.next();
				String version = versionE.getAttributeValue("name");
				// 版本号写死 必须4位 XXX
				if (version.split("\\.").length != 4) {
					throw new Exception("Version is invalid!version=" + version);
				}
				VERSION = version;
				break;
			}
			
			// 特殊语句，取text直接全取过来
			List<UpdateSqlSpecialInfo> specList = new ArrayList<UpdateSqlSpecialInfo>();
			List specCList = root.getChildren("special", NAME_SPACE);
			for (Iterator i = specCList.iterator(); i.hasNext();) {
				Element configElement = (Element) i.next();
				String desc = configElement.getText();
				if (desc != null) {
					// 换行符替换，默认生成的只有\n，可能会有问题，所以替换为\r\n
					desc = desc.replaceAll("\n", "\r\n");
					UpdateSqlSpecialInfo specInfo = new UpdateSqlSpecialInfo();
					specInfo.setDesc(desc);
					specList.add(specInfo);
				}
			}
			
			// 增加字段
			List<UpdateSqlAddColumnInfo> configList = new ArrayList<UpdateSqlAddColumnInfo>();
			List configs = root.getChildren("addColumn", NAME_SPACE);
			for (Iterator i = configs.iterator(); i.hasNext();) {
				Element configElement = (Element) i.next();
				UpdateSqlAddColumnInfo addColumnInfo = new UpdateSqlAddColumnInfo();
				
				String tableName = configElement.getAttributeValue("tableName");
				String columnName = configElement.getAttributeValue("columnName");
				addColumnInfo.setTableName(tableName);
				addColumnInfo.setColumnName(columnName);
				
				// 字段类型及默认值设置
				String columnType = configElement.getAttributeValue("columnType");
				if (!ColumnTypeMap.containsKey(columnType)) {
					throw new Exception("columnType is invalid!columnType=" + columnType);
				}
				addColumnInfo.setColumnType(columnType);
				addColumnInfo.setColumnLen(ColumnTypeMap.get(columnType).getLen());
				addColumnInfo.setColumnDefault(ColumnTypeMap.get(columnType).getDefV());
				addColumnInfo.setNotNull(ColumnTypeMap.get(columnType).isNotNull());
				
				// 如果另外设置了非空，则重置
				String notNull = configElement.getAttributeValue("notNull");
				if (null != notNull) {
					addColumnInfo.setNotNull(Boolean.parseBoolean(notNull));
				}
				// 如果另外设置了长度，则重置
				String columnLen = configElement.getAttributeValue("columnLen");
				if (null != columnLen) {
					addColumnInfo.setColumnLen(Integer.parseInt(columnLen));
				}
				// 如果另外设置了默认值，则重置
				String columnDefault = configElement.getAttributeValue("columnDefault"); 
				if (null != columnDefault) {
					addColumnInfo.setColumnDefault(columnDefault);
				}

				configList.add(addColumnInfo);
			}
			
			VelocityContext context = new VelocityContext();
			context.put("version", VERSION);
			context.put("hasAddColumn", configList.size() > 0);
			context.put("modules", configList);
			context.put("specList", specList);
			GeneratorHelper.generate(context, UpdateSqlGenerator.mergeSqlTemplates, UpdateSqlGenerator.mergeSqlFile,UpdateSqlGenerator.TEMPLATE_DIC);
			logger.info("generate " + UpdateSqlGenerator.mergeSqlFile + " is finished");
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	private static void inputFile(File file, String updateSql, String reasonListSql)
			throws Exception {
		BufferedWriter writer = null;
		try {

			writer = new BufferedWriter(new OutputStreamWriter(
					new FileOutputStream(file, true), "UTF-8"));

			writer.write(updateSql);
			writer.newLine();
			writer.newLine();
			writer.write(reasonListSql);
			writer.flush();
		} finally {
			writer.close();
		}
	}
	
	private static void readFile(String fileName, StringBuilder sb) {
		try {
			FileInputStream file = new FileInputStream(fileName);
			BufferedReader br = new BufferedReader(new InputStreamReader(file, "UTF-8"));
			int ch = 0;
			while ((ch = br.read()) != -1) {
				sb.append((char)ch);
			}
			br.close();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	public static int runCmd(String cmd) {
		int exitVal = -1;
		try {
			Process process = Runtime.getRuntime().exec(cmd);
			System.out.println("cmd run end!cmd=" + cmd);
			
			StreamGobbler er = new StreamGobbler(process.getErrorStream(), "ERROR");
			StreamGobbler ot = new StreamGobbler(process.getInputStream(), "OUTPUT");
			er.start();
			ot.start();
			
			exitVal = process.waitFor();
			System.out.println("Exitvalue: " + exitVal + ";cmd=" + cmd);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return exitVal;
	}
	
	public void genInitSql(String updateSqlStr, String reasonListSqlStr) throws Exception{
		// 创建本地update sql
		String localUpdateSql = updateSqlStr.replaceAll("tr_[$][{]server_id[}]", localDbName);
//		System.out.println(localUpdateSql);
		
		File localOutput = new File(localUpdateFileName);
		if (localOutput.exists()) {
			localOutput.delete();
		}
		inputFile(localOutput, localUpdateSql, "");
		
		// 运行local update sql。倒出一个临时文件，然后再执行。直接执行-e的话，存储过程好像有问题，没执行
		String cmdUpdateSql = "cmd.exe /c mysql -h" + localDbIp + " -uroot < " + localUpdateFileName;
		int updateExitValue = UpdateSqlGenerator.runCmd(cmdUpdateSql);
		if (updateExitValue != 0) {
			throw new Exception("update sql has ERROR!");
		}
		
		// local update sql运行成功后，导出本地的库，结构和数据都包括
		String cmdInitSql = "cmd.exe /c mysqldump --extended-insert=false --add-drop-table --default-character-set=utf8 -h" + localDbIp + " -uroot  " + localDbName + " > " + localDbInitFileName;
		int initExitValue = UpdateSqlGenerator.runCmd(cmdInitSql);
		if (initExitValue != 0) {
			throw new Exception("init sql has ERROR!");
		}
		
		// 读取原始的local init sql
		StringBuilder initSqlSb = new StringBuilder();
		readFile(localDbInitFileName, initSqlSb);
		String initSqlRaw = initSqlSb.toString();
		// 做一些处理，去掉注释等，去掉没用的空行
		String initSql = initSqlRaw.replaceAll("--.*|[/][*].*|[^CHAR]SET.*|UNLOCK.*|LOCK.*", "").replaceAll("(?m)\\s+$", "\r\n");
		// 生成 local init sql file
		File localInitSqlFile = new File(localDbInitFileName);
		if (localInitSqlFile.exists()) {
			localInitSqlFile.delete();
		}
		inputFile(localInitSqlFile, initSql, "");
		
		// 生成版本更新用的 db_init.sql
		VelocityContext context = new VelocityContext();
		context.put("initSql", initSql);
		context.put("reasonListSql", reasonListSqlStr);
		GeneratorHelper.generate(context, UpdateSqlGenerator.initSqlTemplates, UpdateSqlGenerator.initSqlFile,UpdateSqlGenerator.TEMPLATE_DIC);
		logger.info("generate " + UpdateSqlGenerator.initSqlFile + " is finished");
	}
	
	public static void main(String[] args) throws Exception {
		// update sql
		UpdateSqlGenerator usg = new UpdateSqlGenerator();
		usg.genUpdateSql();
		
		// reasonList sql
		LogReasonListSqlGenerator.genReasonListSql();
		
		StringBuilder updateSqlSb = new StringBuilder();
		readFile(UpdateSqlGenerator.mergeSqlFile, updateSqlSb);
		
		StringBuilder reasonListSqlSb = new StringBuilder();
		readFile(LogReasonListSqlGenerator.OutFile, reasonListSqlSb);
		
		// 将两个sql读出来后合并到一个文件中，放到game_db的对应版本的目录中
		String fileName = "..\\game_db\\sql\\zh_CN\\" + UpdateSqlGenerator.VERSION + "\\db_update.sql";
		FileUtil.mkdir(new File(fileName).getParent());
		File output = new File(fileName);
		if (output.exists()) {
			output.delete();
		}
		inputFile(output, updateSqlSb.toString(), reasonListSqlSb.toString());
		
		// 生成init sql
		usg.genInitSql(updateSqlSb.toString(), reasonListSqlSb.toString());
	}
	
}

class StreamGobbler extends Thread {
	InputStream is;
	String type;
	
	public StreamGobbler(InputStream is, String type) {
		this.is = is;
		this.type = type;
	}
	
	public void run() {
		try {
			InputStreamReader isr = new InputStreamReader(is);
			BufferedReader br = new BufferedReader(isr);
			String line = null;
			while((line = br.readLine()) != null) {
				System.out.println(type + "> " + line);
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
