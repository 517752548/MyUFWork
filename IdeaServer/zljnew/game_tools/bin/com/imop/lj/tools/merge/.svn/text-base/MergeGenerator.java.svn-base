package com.imop.lj.tools.merge;

import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

import javax.persistence.Table;

import org.apache.log4j.Logger;
import org.apache.velocity.VelocityContext;
import org.jdom.Document;
import org.jdom.Element;
import org.jdom.Namespace;
import org.jdom.input.SAXBuilder;

import com.imop.lj.tools.util.GeneratorHelper;

/**
 *
 * 合服代码生成器
 *
 */
public class MergeGenerator {
	private static final Logger logger = Logger.getLogger(MergeGenerator.class);

	public static final String MERGE_CONFIG_FILE = "merge/merge_config.xml";

	public static final Namespace NAME_SPACE = Namespace.getNamespace("http://com.imop.lj.merge");

	public static final String mergeStrategyGenertorPath = "..\\MergeDb\\src\\com\\imop\\lj\\mergedb\\strategy\\";

	public static final String mergeStrategyImplGenertorPath = "..\\game_tools\\target\\game_server_target\\merge\\strategy\\impl\\";

	public static final String mergeDaoFile = "..\\MergeDb\\src\\com\\imop\\lj\\mergedb\\db\\dao\\MergeDao.java";

	public static final String mergeSqlFile = "..\\MergeDb\\config\\mergedb_sql.xml";

	public static final String TEMPLATE_DIC = "merge/template/";

	private static final String mergeStrategyTemplates = "strategy_merge.vm";

	private static final String mergeStrategyImplTemplates = "strategy_impl_merge.vm";

	private static final String mergeDaoTemplates = "strategy_merge_dao.vm";

	private static final String mergeSqlTemplates = "strategy_merge_sql.vm";

	private List<MergeEntityConfigInfo> configList = new ArrayList<MergeEntityConfigInfo>();

	public MergeGenerator() {

	}

	@SuppressWarnings({ "rawtypes", "unchecked" })
	public void init() {
		try {
			String configFilePath = GeneratorHelper.getBuildPath(MERGE_CONFIG_FILE);
			SAXBuilder builder = new SAXBuilder();
			Document doc = builder.build(configFilePath);
			Element root = doc.getRootElement();
			List configs = root.getChildren("mergeEntityConfig", NAME_SPACE);

			for (Iterator i = configs.iterator(); i.hasNext();) {
				Element configElement = (Element) i.next();
				MergeEntityConfigInfo configInfo = new MergeEntityConfigInfo();

				String fullClassName = configElement.getAttributeValue("className");

				String className = fullClassName.substring(fullClassName.lastIndexOf(".") + 1);

				String mergeModelName = configElement.getAttributeValue("mergeModelName");

				Class entityClass = Class.forName(fullClassName);
				Table tableAnnotation = (Table) entityClass.getAnnotation(Table.class);
				Method method = entityClass.getMethod("getId", null);
				String idClassName = method.getReturnType().getName();


				if (configElement.getAttributeValue("empty") != null) {
					configInfo.setEmpty(configElement.getAttributeValue("empty").equals("true") ? true : false);
				}

				if (configElement.getAttributeValue("globals") != null) {
					configInfo.setGlobals(configElement.getAttributeValue("globals").equals("true") ? true : false);
				}

				if (configElement.getAttributeValue("deleted") != null) {
					configInfo.setDeleted(configElement.getAttributeValue("deleted").equals("true") ? true : false);
				}
				
				if (configElement.getAttributeValue("bindCharId") != null) {
					configInfo.setBindCharId(configElement.getAttributeValue("bindCharId").equals("true") ? true : false);
				}
				
				if (configElement.getAttributeValue("bindCharName") != null) {
					configInfo.setBindCharName(configElement.getAttributeValue("bindCharName").equals("true") ? true : false);
				}
				
				configInfo.setFullClassName(fullClassName);
				configInfo.setClassName(className);
				configInfo.setMergeModelName(mergeModelName);
				configInfo.setIdClassName(idClassName);
				configInfo.setTableName(tableAnnotation.name());

				this.configList.add(configInfo);
				System.out.println(configInfo);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void generateStrategy() throws Exception{
		for (MergeEntityConfigInfo configInfo : configList) {
			VelocityContext context = new VelocityContext();
			context.put("module", configInfo);
			String outputFilePath = MergeGenerator.mergeStrategyGenertorPath + configInfo.getClassName() + "Strategy.java";
			GeneratorHelper.generate(context, MergeGenerator.mergeStrategyTemplates, outputFilePath,MergeGenerator.TEMPLATE_DIC);
			logger.info("generate " + outputFilePath + " is finished");
		}
	}

	public void generateStrategyImpl() throws Exception{
		for (MergeEntityConfigInfo configInfo : configList) {
			VelocityContext context = new VelocityContext();
			context.put("module", configInfo);
			String outputFilePath = MergeGenerator.mergeStrategyImplGenertorPath + configInfo.getClassName() + "StrategyImpl.java";
			GeneratorHelper.generate(context, MergeGenerator.mergeStrategyImplTemplates, outputFilePath,MergeGenerator.TEMPLATE_DIC);
			logger.info("generate " + outputFilePath + " is finished");
		}
	}

	public void generateStrategySql() throws Exception{
		VelocityContext context = new VelocityContext();
		context.put("modules", configList);
		GeneratorHelper.generate(context, MergeGenerator.mergeSqlTemplates, MergeGenerator.mergeSqlFile,MergeGenerator.TEMPLATE_DIC);
		logger.info("generate " + MergeGenerator.mergeSqlFile + " is finished");
	}

	public void generateStrategyDao() throws Exception{
		VelocityContext context = new VelocityContext();
		context.put("modules", configList);
		GeneratorHelper.generate(context, MergeGenerator.mergeDaoTemplates, MergeGenerator.mergeDaoFile,MergeGenerator.TEMPLATE_DIC);
		logger.info("generate " + MergeGenerator.mergeDaoTemplates + " is finished");
	}

	public static void main(String[] args) throws Exception {
		MergeGenerator gen = new MergeGenerator();
		gen.init();
		gen.generateStrategySql();
		gen.generateStrategyDao();
		gen.generateStrategy();
		gen.generateStrategyImpl();
//		MergeGenerator.createMergeStrategyFiles();
	}
}
