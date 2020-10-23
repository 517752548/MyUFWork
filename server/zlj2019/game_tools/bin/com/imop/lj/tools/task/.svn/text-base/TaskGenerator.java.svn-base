package com.imop.lj.tools.task;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.List;

import org.apache.commons.io.FileUtils;
import org.apache.log4j.Logger;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.poifs.filesystem.POIFSFileSystem;
import org.apache.velocity.VelocityContext;

import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.tools.i18n.PoiUtils;
import com.imop.lj.tools.util.GeneratorHelper;


public class TaskGenerator {

//	1.创建对应的*Dao.java和*Entity.java文件，和在game_server_hibernate.cfg.xml文件，game_server_hibernate_query.xml文件中定义sql语句
//	2.PlayerDataUpdater或者CommonDataUpdater中注册
//	3.若要创建UUID,
//	UUIDTYPE.java
//	Globals.java文件中定义
//	则要在game_server_hibernate_query.xml文件中添加queryUUID_CORPSBOSS_RANK
//
//	要严格定义
//		@Column(columnDefinition = " int default 0", nullable = false)
//
//	GameDaoService.java中加入初始化
	
	
	//生成步骤 : 创建*Entity.java -- > 注册文件game_server_hibernate.cfg.xml
	//		    创建*Dao.java 	 -- > 注册文件game_server_hibernate_query.xml
	//		 需要有个变量判读是否只和human相关,如果是human相关 -- >PlayerDataUpdater, 和全服玩家相关 -- > CommonDataUpdater
	//		*DbManager.java
	//		 需要有个变量判读是否只和human相关,如果是human相关 -- >, 和全服玩家相关 -- > UUIDTYPE.java,同时注册文件game_server_hibernate_query.xml
	//		注册 GameDaoService.java
	
	/** 日志 */
	@SuppressWarnings("unused")
	private static final Logger logger = Logger
			.getLogger(TaskGenerator.class);
	
	private static String modelName = "TestTask";
	private static final String entity_path = "../game_db/src/com/imop/lj/db/model/";
	private static final String hibber_cfg = "../game_server/config/game_server_hibernate.cfg.xml";
	private static final String dao_path = "../game_db/src/com/imop/lj/db/dao/";
	private static final String hibber_query = "../game_server/config/game_server_hibernate_query.xml";
	private static final String player_data_updater = "../game_server/src/com/imop/lj/gameserver/player/persistance/PlayerDataUpdater.java";
//	private static final String Common_data_updater = "../game_server/src/com/imop/lj/gameserver/scene/CommonDataUpdater.java";
	private static final String model_path = "../game_server/src/com/imop/lj/gameserver/"+ modelName.toLowerCase() +"/";
	private static final String updater_path = "../game_server/src/com/imop/lj/gameserver/"+ modelName.toLowerCase() +"/persistance/";
	private static final String db_manager_path = "../game_server/src/com/imop/lj/gameserver/"+ modelName.toLowerCase() +"/persistance/";
	private static final String game_dao_service = "../game_server/src/com/imop/lj/gameserver/common/db/GameDaoService.java";
	private static final String msg_path = "../game_tools/config/msg/model/";
	private static final String msg_generator_js = "../game_tools/config/msg/message_generator.js";
	private static final String msg_config_xls = "../game_tools/config/msg/messageTypeConfig.xls";
	private static final String msg_recognizer = "../game_server/src/com/imop/lj/gameserver/startup/ClientMessageRecognizer.java";
	private static final String template_xls = "../game_server/config/templates.xml";
	private static final String Globals = "../game_server/src/com/imop/lj/gameserver/common/Globals.java";
	private static final String humanInitManager = "../game_server/src/com/imop/lj/gameserver/human/manager/HumanInitManager.java";
	private static final String load_player_role = "../game_server/src/com/imop/lj/gameserver/player/async/LoadPlayerRoleOperation.java";
	private static final String human = "../game_server/src/com/imop/lj/gameserver/human/Human.java";
	private static final String taskListener = "../game_server/src/com/imop/lj/gameserver/task/TaskListener.java";
	private static final String taskdef = "../game_server/src/com/imop/lj/gameserver/task/TaskDef.java";
	private static final String funcdef = "../game_server/src/com/imop/lj/gameserver/func/FuncDef.java";
	private static final String funcFactory = "../game_server/src/com/imop/lj/gameserver/func/FuncFactory.java";
	private static final String func_path = "../game_server/src/com/imop/lj/gameserver/func/allfunc/";
	private static final String func_xls = "../resources/scripts/func.xls";
	
	@SuppressWarnings({"unused" })
	public static void main(String[] args) throws Exception {
		String comment =  "测试任务";
		String tableName = "t_"+modelName.substring(0, modelName.length() - 4).toLowerCase()+
				"_"+modelName.substring(modelName.length() - 4, modelName.length()).toLowerCase();
		String entityName = modelName + "Entity";
		String daoName = modelName + "Dao";
		String queryName = "query"+ modelName +"ByCharId";
		String updaterName = modelName + "Updater";
		String dbManagerName = modelName + "DbManager";
		boolean onlyHuman = true;
		
		/**DB相关**/
//		genEntity(comment, tableName, entityName);
//		insertHiberCfg(entityName);
//		genDao(comment, daoName, queryName, entityName);
//		insertHiberQuery(entityName, queryName);
		
		/**model相关**/
//		genModel(entityName, comment);
//		if(onlyHuman){
//			insertPlayerDataUpdater(updaterName);	
//		}else{
//			CommonDataUpdater();
//		}
//		insertDaoService(daoName, comment);
//		genDbManager(dbManagerName, daoName, entityName);
//		genUpdater(updaterName, dbManagerName);
		
		/**消息相关**/
//		genTaskMsg(comment);
//		insertJs();
//		insertMsgXls(comment);
//		insertRecognizer();
		
		/**模板相关**/
//		insertTemplate();
		
		/**service相关**/
//		genService();
//		genManager(entityName, comment);
//		insertGlobals(comment);
//		insertHumanInitManager(comment);		
		
//		insertHuman(comment);
//		insertLoadIo(comment);
//		insertListner();
//		insertTaskDef(comment);
		
		/** func相关**/
//		genTaskFunc(comment);
//		insertFuncFactory();
//		insertFuncDef(comment);
//		insertFuncXls(comment);
		
	}

	@SuppressWarnings({ "unused"})
	private static void genTaskFunc(String comment) throws Exception {
		String templateDir = "task/service/";
		String templateFileName = "Func.template";
		VelocityContext context = new VelocityContext();
		context.put("modelName", modelName);
		context.put("comment", comment);
		String generateToString = GeneratorHelper.generateToString(context, templateFileName, templateDir);
		String temName = (String) context.get("modelName") + "Func.java";
		System.out.println("创建 " + temName);
		FileUtils.writeStringToFile(new File(func_path +  temName), generateToString);
	}


	@SuppressWarnings({ "unused", "unchecked" })
	private static void insertFuncDef(String comment) throws IOException {
		int length = FuncTypeEnum.values().length + 2;
		File cfgFile = new File(funcdef);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("private FuncTypeEnum(int index, IFuncFactory funcFactory)")) {
				System.out.println("注册文件  FuncDef.java");
				lines.add(i - 2, "		"+ modelName.toUpperCase() +"("+ length +", FuncFactory."+modelName+"Factory),");
				lines.add(i - 2, "		/** "+comment +"*/");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
		
	}
	
	@SuppressWarnings({ "unused", "unchecked" })
	private static void insertFuncFactory() throws IOException {
		File cfgFile = new File(funcFactory);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("public class FuncFactory")) {
				System.out.println("注册文件  FuncFactory.java");
				lines.add(i + 1, "	};");
				lines.add(i + 1, "		}");
				lines.add(i + 1, "			return new "+modelName+"Func(owner, FuncTypeEnum."+modelName.toUpperCase()+");");
				lines.add(i + 1, "		public AbstractFunc createNewFunc(Human owner) {");
				lines.add(i + 1, "		@Override");
				lines.add(i + 1, "");
				lines.add(i + 1, "	public static IFuncFactory "+modelName+"Factory = new IFuncFactory() {");
				lines.add(i + 1, "");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
		
	}

	@SuppressWarnings("unused")
	private static void insertFuncXls(String comment) throws Exception {
		FileInputStream fs=new FileInputStream(func_xls);
        POIFSFileSystem ps=new POIFSFileSystem(fs);
        HSSFWorkbook wb=new HSSFWorkbook(ps); 
        
        //第一个sheet
        HSSFSheet sheet1=wb.getSheetAt(0);
        HSSFRow srcRow1=sheet1.getRow(sheet1.getLastRowNum());
          
        FileOutputStream out=new FileOutputStream(func_xls);
        HSSFRow row1=sheet1.createRow((short)(sheet1.getLastRowNum()+1));
        for (int i = 0; i < 13; i++) {
        	if(i == 0){
        		row1.createCell(i).setCellValue(PoiUtils.getIntValue(srcRow1.getCell(i)) + 1);
        	}else if(i == 4 || i == 9 || i == 12){
        		row1.createCell(i).setCellValue(comment);
        	}else{
        		row1.createCell(i).setCellValue(PoiUtils.getIntValue(srcRow1.getCell(i)));
        	}
		}
        
        //第二个sheet
        HSSFSheet sheet2=wb.getSheetAt(1);
        HSSFRow srcRow2=sheet2.getRow(sheet2.getLastRowNum());
        
        HSSFRow row2=sheet2.createRow((short)(sheet2.getLastRowNum()+1));
        for (int i = 0; i < 8; i++) {
        	if(i == 0){
        		row2.createCell(i).setCellValue(PoiUtils.getIntValue(srcRow2.getCell(i)) + 1);
        	}else if(i == 7){
        		row2.createCell(i).setCellValue(comment);
        	}else{
        		row2.createCell(i).setCellValue(PoiUtils.getIntValue(srcRow2.getCell(i)));
        	}
        }

        
        out.flush();  
        wb.write(out);    
        out.close();    
        
        System.out.println("注册 func.xls");
	}

	@SuppressWarnings({ "unused", "unchecked" })
	private static void insertTaskDef(String comment) throws IOException {
		int length = QuestType.values().length + 1;
		File cfgFile = new File(taskdef);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("private QuestType(int index)")) {
				System.out.println("注册文件  TaskDef.java");
				lines.add(i - 4, "		"+ modelName.toUpperCase() +"("+ length +"),");
				lines.add(i - 4, "		/** "+comment +"*/");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}

	@SuppressWarnings({ "unused", "unchecked" })
	private static void insertListner() throws IOException {
		File cfgFile = new File(taskListener);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("新增的任务管理器从来这里加进去即可")) {
				System.out.println("注册文件  TaskListener.java");
				lines.add(i + 2, "			addTaskManager(((Human)owner).get"+modelName+"Manager());");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}

	@SuppressWarnings({ "unused", "unchecked" })
	private static void insertLoadIo(String comment) throws IOException {
		File cfgFile = new File(load_player_role);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("加载跑环任务")) {
				System.out.println("注册文件  LoadPlayerRoleOperation.java");
				lines.add(i, "");
				lines.add(i, "				human.get"+modelName+"Manager().load();");
				lines.add(i, "				//加载"+comment);
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}

	@SuppressWarnings({ "unused", "unchecked" })
	private static void insertHumanInitManager(String comment) throws IOException {
		File cfgFile = new File(humanInitManager);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("是否有车轮战的排名奖励需要领")) {
				System.out.println("注册文件  HumanInitManager.java");
				lines.add(i - 3, "        Globals.get"+modelName+"Service().sendCur"+modelName+"Msg(human);");
				lines.add(i - 3, "        //"+comment);
				lines.add(i - 3, "");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}

	@SuppressWarnings({ "unused"})
	private static void genService() throws Exception {
		String templateDir = "task/service/";
		String templateFileName = "TaskService.template";
		VelocityContext context = new VelocityContext();
		context.put("modelName", modelName);
		context.put("lowModelName", modelName.toLowerCase());
		context.put("bigModelName",  modelName.substring(0, 1)
				+ modelName.substring(1).toLowerCase());
		context.put("behavior", modelName.substring(0, modelName.length() - 4).toUpperCase() + "_"
				+ modelName.substring(modelName.length() - 4, modelName.length()).toUpperCase()+"_NUM");
		context.put("upperModelName", modelName.toUpperCase());
		String generateToString = GeneratorHelper.generateToString(context, templateFileName, templateDir);
		String temName = (String) context.get("modelName") + "Service.java";
		System.out.println("创建" + temName);
		FileUtils.writeStringToFile(new File(model_path +  temName), generateToString);
	}



	@SuppressWarnings({ "unused"})
	private static void genManager(String entityName, String comment) throws Exception {
		String templateDir = "task/service/";
		String templateFileName = "TaskManager.template";
		VelocityContext context = new VelocityContext();
		context.put("lowModelName", modelName.toLowerCase());
		context.put("entityName",  entityName);
		context.put("modelName",  modelName);
		context.put("comment",  comment);
		String generateToString = GeneratorHelper.generateToString(context, templateFileName, templateDir);
		String temName = (String) context.get("modelName") + "Manager.java";
		System.out.println("创建" + temName);
		FileUtils.writeStringToFile(new File(model_path +  temName), generateToString);
	}



	@SuppressWarnings({ "unused", "unchecked" })
	private static void insertHuman(String comment) throws IOException {
		File cfgFile = new File(human);
		List<String> lines = FileUtils.readLines(cfgFile);
		System.out.println("注册文件 human.java");
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("import net.sf.json.JSONObject;")) {
				lines.add(i - 1, "import com.imop.lj.gameserver."+modelName.toLowerCase()+"."+modelName+"Manager;");
				break;
			}
			
		}
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("获取当前终端类型")) {
				lines.add(i - 1, "	private "+modelName+"Manager "+modelName.substring(0, 1).toLowerCase() 
						+ modelName.substring(1)+"Manager;");
				lines.add(i - 1, "	/** "+comment+"管理器*/");
				
				break;
			}
			
		}
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("获取战斗力")) {
				lines.add(i - 1, "");
				lines.add(i - 1, "	}");
				lines.add(i - 1, "		return "+modelName.substring(0, 1).toLowerCase() 
						+ modelName.substring(1)+"Manager;");
				lines.add(i - 1, "	public "+modelName+"Manager get"+modelName+"Manager() {");
				break;
			}
			
		}
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("这个前面放任务管理器")) {
				lines.add(i, "        this."+modelName.substring(0, 1).toLowerCase() 
						+ modelName.substring(1)+"Manager = new "+modelName+"Manager(this);");
				break;
			}
			
		}
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("public void checkAfterRoleLoad() {")) {
				lines.add(i + 1, "		this."+modelName.substring(0, 1).toLowerCase() 
						+ modelName.substring(1)+"Manager.checkAfterRoleLoad();");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}



	@SuppressWarnings({ "unused", "unchecked" })
	private static void insertGlobals(String comment) throws IOException {
		File cfgFile = new File(Globals);
		List<String> lines = FileUtils.readLines(cfgFile);
		System.out.println("注册文件  Globals.java");
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("import net.sf.json.JSONArray;")) {
				lines.add(i - 1, "import com.imop.lj.gameserver."+modelName.toLowerCase()+"."+modelName+"Service;");
				break;
			}
			
		}
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("服务器启动时调用，初始化所有管理器实例")) {
				lines.add(i - 1, "");
				lines.add(i - 1, "	private static "+ modelName+"Service "+modelName.substring(0, 1).toLowerCase()
						+ modelName.substring(1)+"Service;");
				lines.add(i - 1, "	/** "+comment+" */");
				break;
			}
			
		}
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("***********在此之前初始化************")) {
				lines.add(i - 1, " 		"+modelName.substring(0, 1).toLowerCase()
						+ modelName.substring(1)+"Service.init();");
				lines.add(i - 1, " 		"+modelName.substring(0, 1).toLowerCase()
						+ modelName.substring(1)+"Service = new "+modelName+"Service();");
				lines.add(i - 1, " 		//"+comment);
				lines.add(i - 1, "");
				break;
			}
			
		}
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("static MapService getMapService")) {
				lines.add(i - 1, "    }");
				lines.add(i - 1, "        return "+ modelName.substring(0, 1).toLowerCase()
						+ modelName.substring(1)+"Service;");
				lines.add(i - 1, "    public static "+modelName+"Service get"+modelName+"Service() {");
				lines.add(i - 1, "");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}




	@SuppressWarnings({ "unchecked", "unused" })
	private static void insertTemplate() throws IOException {
		File cfgFile = new File(template_xls);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("<file name=\"quest.xls\">")) {
				System.out.println("注册文件  template.xls");
				lines.add(i + 1, "		<sheet class=\"com.imop.lj.gameserver.task.template.QuestTemplate\" />");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}



	@SuppressWarnings({ "unchecked", "unused" })
	private static void insertJs() throws IOException {
		File cfgFile = new File(msg_generator_js);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("/*ｔｒｕｅ-重新生成文件，ｆａｌｓｅ-跳过*/")) {
				System.out.println("注册文件 message_generator.js");
				lines.add(i + 1, "engine.createMessageFiles(\""+modelName.toLowerCase()+"_message.xml\",true);");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}




	@SuppressWarnings("unused")
	private static void insertMsgXls(String comment) throws Exception {
		FileInputStream fs=new FileInputStream(msg_config_xls);
        POIFSFileSystem ps=new POIFSFileSystem(fs);
        HSSFWorkbook wb=new HSSFWorkbook(ps);    
        HSSFSheet sheet=wb.getSheetAt(0);
        HSSFRow srcRow=sheet.getRow(sheet.getLastRowNum());
          
        FileOutputStream out=new FileOutputStream(msg_config_xls);
        HSSFRow row=sheet.createRow((short)(sheet.getLastRowNum()+1));
        row.createCell(0).setCellValue(modelName.toLowerCase());
        row.createCell(1).setCellValue(PoiUtils.getIntValue(srcRow.getCell(1)) + 100);
        row.createCell(2).setCellValue(PoiUtils.getIntValue(srcRow.getCell(2)) + 100);
        row.createCell(3).setCellValue(modelName.toLowerCase() + "_message.xml");
        row.createCell(4).setCellValue(comment);
        
        out.flush();  
        wb.write(out);    
        out.close();    
        
        System.out.println("注册 messageTypeConfig.xls");
	}




	@SuppressWarnings({ "unchecked", "unused" })
	private static void insertRecognizer() throws IOException {
		File cfgFile = new File(msg_recognizer);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("注册消息号和消息类的映射")) {
				System.out.println("注册文件ClientMessageRecognizer.java");
				lines.add(i - 3, "		registerMsgMapping(new "+  modelName.substring(0, 1).toUpperCase()
						+ modelName.substring(1).toLowerCase() +"MsgMappingProvider());");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}




	@SuppressWarnings({"unused" })
	private static void genTaskMsg(String comment) throws Exception {
		String templateDir = "msg/";
		String templateFileName = "TaskMsg.template";
		VelocityContext context = new VelocityContext();
		context.put("lowModelName", modelName.toLowerCase());
		context.put("bigModelName",  modelName.toUpperCase());
		context.put("comment", comment);
		String generateToString = GeneratorHelper.generateToString(context, templateFileName, templateDir);
		String temName = (String) context.get("lowModelName") + "_message.xml";
		System.out.println("创建" + temName);
		FileUtils.writeStringToFile(new File(msg_path +  temName), generateToString);
	}


	@SuppressWarnings({ "unchecked", "unused" })
	private static void insertDaoService(String daoName, String comment) throws IOException {
		File cfgFile = new File(game_dao_service);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("import com.imop.lj.gameserver.common.config.GameServerConfig;")) {
				lines.add(i - 1, "import com.imop.lj.db.dao."+daoName+";");
				break;
			}
		}
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("DBMultiTransactionHelper getQueryHelper()")) {
				lines.add(i + 3, "");
				lines.add(i + 4, "	public "+daoName+" get"+daoName+"(){");
				lines.add(i + 5, "		return daoHelper."+daoName.substring(0, 1).toLowerCase()
						+ daoName.substring(1)+";");
				lines.add(i + 6, "	}");
				break;
			}
		}
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("DaoHelper(GameServerConfig config)")) {
				lines.add(i - 1, "        private final "+ daoName +" "+  daoName.substring(0, 1).toLowerCase()
						+ daoName.substring(1) +";");
				lines.add(i - 1, "        /** "+ comment +"数据Dao */");
				break;
			}
		}
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("/* dao管理类初始化 */")) {
				lines.add(i + 1, "			"+daoName.substring(0, 1).toLowerCase()
						+ daoName.substring(1)+" = new "+daoName+"(dbService);");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
		System.out.println("注册文件 GameDaoService.java");
	}



	@SuppressWarnings({"unused" })
	private static void genModel(String entityName, String comment) throws Exception {
		String templateDir = "data/";
		String templateFileName = "TaskModel.template";
		VelocityContext context = new VelocityContext();
		context.put("modelName", modelName);
		context.put("lowModelName", modelName.toLowerCase());
		context.put("entityName", entityName);
		context.put("bigModelName",  modelName.substring(0, 1).toUpperCase()
				+ modelName.substring(1).toLowerCase());
		context.put("comment", comment);
		String generateToString = GeneratorHelper.generateToString(context, templateFileName, templateDir);
		String temName = (String) context.get("modelName") + ".java";
		System.out.println("创建" + temName);
		FileUtils.writeStringToFile(new File(model_path +  temName), generateToString);
	}

	@SuppressWarnings({"unused" })
	private static void genUpdater(String updaterName, String dbManagerName) throws Exception {
		String templateDir = "db/";
		String templateFileName = "TaskUpdater.template";
		VelocityContext context = new VelocityContext();
		context.put("modelName", modelName);
		context.put("lowModelName", modelName.toLowerCase());
		context.put("updaterName", updaterName);
		context.put("dbManagerName", dbManagerName);
		String generateToString = GeneratorHelper.generateToString(context, templateFileName, templateDir);
		String temName = (String) context.get("updaterName") + ".java";
		System.out.println("创建" + temName);
		FileUtils.writeStringToFile(new File(updater_path +  temName), generateToString);
	}
	
	@SuppressWarnings({ "unused" })
	private static void genDbManager(String dbManagerName, String daoName, String entityName) throws Exception {
		String templateDir = "db/";
		String templateFileName = "TaskDbManager.template";
		VelocityContext context = new VelocityContext();
		context.put("modelName", modelName);
		context.put("lowModelName", modelName.toLowerCase());
		context.put("daoName", daoName);
		context.put("dbManagerName", dbManagerName);
		context.put("lowDbManagerName", dbManagerName.substring(0, 1).toLowerCase()
				+ dbManagerName.substring(1));
		context.put("entityName", entityName);
		String generateToString = GeneratorHelper.generateToString(context, templateFileName, templateDir);
		String temName = (String) context.get("dbManagerName") + ".java";
		System.out.println("创建" + temName);
		FileUtils.writeStringToFile(new File(db_manager_path +  temName), generateToString);
	}


	@SuppressWarnings({ "unchecked", "unused" })
	private static void insertPlayerDataUpdater(String updaterName) throws IOException{
		File cfgFile = new File(player_data_updater);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("PlayerDataUpdater()")) {
				System.out.println("注册文件PlayerDataUpdater.java");
				lines.add(i - 4, "        operationDbMap.put("+modelName+".class, new "+updaterName+"());");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}

	@SuppressWarnings({"unused" })
	private static void CommonDataUpdater() {
		
	}

	@SuppressWarnings({ "unchecked", "unused" })
	private static void insertHiberQuery(String entityName, String queryName) throws IOException {
		File cfgFile = new File(hibber_query);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("</hibernate-mapping>")) {
				System.out.println("注册文件game_server_hibernate_query.xml");
				lines.add(i - 1, "	</query>");
				lines.add(i - 1, "		from "+ entityName +" where charId = :charId order by startTime desc limit 1");
				lines.add(i - 1, "	<query name=\"" + queryName +"\">");
				lines.add(i - 1, "	<!-- 查询跑环的任务 -->");
				lines.add(i - 1, "");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}

	@SuppressWarnings({"unused" })
	private static void genDao(String comment, String daoName, String queryName, String entityName)  throws Exception{
		String templateDir = "db/";
		String templateFileName = "TaskDao.template";
		VelocityContext context = new VelocityContext();
		context.put("comment", comment);
		context.put("daoName", daoName);
		context.put("queryName", queryName);
		context.put("entityName", entityName);
		String generateToString = GeneratorHelper.generateToString(context, templateFileName, templateDir);
		String temName = (String) context.get("daoName") + ".java";
		System.out.println("创建" + temName);
		FileUtils.writeStringToFile(new File(dao_path +  temName), generateToString);
	}

	@SuppressWarnings({"unused" })
	private static void genEntity(String comment, String tableName, String entityName) throws Exception{
		String templateDir = "entity/task/";
		String templateFileName = "TaskEntityTemplate.template";
		VelocityContext context = new VelocityContext();
		context.put("comment", comment);
		context.put("tableName", tableName);
		context.put("entityName", entityName);
		String generateToString = GeneratorHelper.generateToString(context, templateFileName, templateDir);
		String temName = (String) context.get("entityName") + ".java";
		System.out.println("创建" + temName);
		FileUtils.writeStringToFile(new File(entity_path +  temName), generateToString);
	}
	@SuppressWarnings({ "unchecked", "unused" })
	private static void insertHiberCfg(String entityName) throws IOException{
		File cfgFile = new File(hibber_cfg);
		List<String> lines = FileUtils.readLines(cfgFile);
		for (int i = 0; i < lines.size(); i++) {
			if (lines.get(i).contains("</session-factory>")) {
				System.out.println("注册文件game_server_hibernate.cfg.xml");
				lines.add(i - 1, "		<mapping class=\"com.imop.lj.db.model."+entityName+"\" />");
				break;
			}
			
		}
		FileUtils.writeLines(cfgFile, lines);
	}
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
}
