package com.imop.lj.tools.excel;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileOutputStream;
import java.io.OutputStreamWriter;
import java.lang.reflect.Constructor;
import java.lang.reflect.Field;
import java.lang.reflect.Method;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;

import com.imop.lj.core.annotation.NotClient;
import com.imop.lj.core.config.ConfigUtil;
import com.imop.lj.core.template.TemplateConfig;
import com.imop.lj.core.template.TemplateFileParser;
import com.imop.lj.core.template.TemplateObject;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.core.util.FileUtil;

/**
 * 读配置表，产生templateService，之后根据所有的模板来生成sqlite的表和数据
 * 
 * 里面很多都是写死的，如获取模板对应的父类，即VO类，然后取里面所有的属性对应值；
 * 如果是自定义parser的，比如item.xls，则获取自定义的parser后，然后取里面的classes，
 * 这里也是写死的，即classes的第一个对象是基类，然后取所有后边的类，如EquipItemTemplate.class，
 * 再然后取EquipItemTemplate.class的父类即VO类，然后取里面所有的属性对应值，
 * 再再然后，取EquipItemTemplate.class的父类的父类的父类，即ItemTemplateVO.class，再取里面所有属性对应的值
 * 
 * @author Black
 *
 */
public class SqliteSqlGenerator {
	private static final String clientCSRootPath = "../game_tools/target/cs_target/sql/";

	private static final String DB_NAME = "uuu.db";
	private static final String SQL_NAME = "db.sql";

	private static final String CONFIG_DIR = "excel/";
	private static final String scriptPath = "../resources/scripts/";
	public static final String TablePrefix = "t_";

	private ArrayList<String> sqlList = new ArrayList<String>();

	// Map<表名，List<表的列描述对象>>
	private static Map<String, List<SqlColumnInfo>> tableDefMap = new HashMap<String, List<SqlColumnInfo>>();
	// Map<表名，<行数据<列数据>>>
	private static Map<String, List<List<String>>> tableDataMap = new HashMap<String, List<List<String>>>();

	public static void main(String[] args) throws Exception {
		TemplateService templateService = new TemplateService(scriptPath, false);
		templateService.loadForGenSqliteSql(ConfigUtil
				.getConfigURL("templates.xml"));

		genMap(templateService);
		String tableDefSql = genTableDefSql();
		String tableDataSql = genTableDataSql();

		FileUtil.delete(new File(clientCSRootPath));
		FileUtil.createDir(new File(clientCSRootPath));
		String sqlFileName = clientCSRootPath + SQL_NAME;
		inputFile(sqlFileName, tableDefSql, tableDataSql);

//		toDB(tableDefSql, tableDataSql);
	}

	private static void genMap(TemplateService templateService)
			throws Exception {
		String tableName = "";

		// templates.xml 中的excel列表
		List<TemplateConfig> cfgList = templateService.getTemplateCfgs();
		for (TemplateConfig cfg : cfgList) {
			// 每一个excel

			// 该excel不是客户端的，跳过
			if (cfg.isNotclient()) {
				continue;
			}

			// 普通类型，直接从classes中获取
			Class<?>[] clzArr = null;
			// 自定义parser类型，从parser中获取
			boolean isSelfParser = cfg.getParserClassName() != null
					&& cfg.getParserClassName().length() > 0;
			if (isSelfParser) {
				Class<?> clazz = Class.forName(cfg.getParserClassName());
				Constructor<?> constructor = clazz.getConstructor();
				TemplateFileParser parser = (TemplateFileParser) constructor
						.newInstance();
				Class<?>[] cArr = parser.getLimitClazzes();
				clzArr = new Class<?>[cArr.length - 1];
				// 跳过第一个，第一个是基类
				for (int ca = 0; ca < cArr.length - 1; ca++) {
					clzArr[ca] = cArr[ca + 1];
				}
			} else {
				clzArr = cfg.getClasses();
			}

			for (int i = 0; i < clzArr.length; i++) {
				// 每一个模板，对应excel的一个sheet

				// 该sheet不是客户端的，跳过
				if (cfg.getNotclientClasses() != null
						&& cfg.getNotclientClasses().length > 0
						&& cfg.getNotclientClasses()[i]) {
					continue;
				}

				Class<?> tplClz = clzArr[i];
				Class<?> tplVOClz = clzArr[i].getSuperclass();
				// 父类VO的属性，针对EquipItemTemplate这种
				Field[] superFArr = getSuperVOFiled(tplVOClz);

				// 表名
				tableName = tplClz.getSimpleName();

				// 表的行数据
				List<List<String>> tableRowData = new ArrayList<List<String>>();
				tableDataMap.put(tableName, tableRowData);

				Set<Entry<Integer, TemplateObject>> tplSet = null;
				if (!isSelfParser) {
					tplSet = templateService.getAllClassTemplateMaps()
							.get(tplClz).entrySet();
				} else {
					// 自定义parser的key是父类class，但是这样就取到的是该表的所有sheet的数据，所以下面需要过滤
					tplSet = templateService.getAllClassTemplateMaps()
							.get(tplVOClz.getSuperclass()).entrySet();
				}

				for (Entry<Integer, TemplateObject> entry : tplSet) {
					// 一个sheet中的每行数据

					// 如果是自定义parser的
					if (isSelfParser) {
						// 不是自己类型的数据，不做处理
						if (entry.getValue().getClass().getSuperclass() != tplVOClz) {
							continue;
						}
					}

					List<Field> fArrList = new ArrayList<Field>();
					int tplId = entry.getKey();
					TemplateObject tpl = entry.getValue();
					Field[] tfArr = tplVOClz.getDeclaredFields();
					if (superFArr != null && superFArr.length > 0) {
						for (int t1 = 0; t1 < superFArr.length; t1++) {
							fArrList.add(superFArr[t1]);
						}
					}
					for (int t2 = 0; t2 < tfArr.length; t2++) {
						fArrList.add(tfArr[t2]);
					}
					Field[] fArr = fArrList.toArray(new Field[0]);

					List<SqlColumnInfo> columnList = new ArrayList<SqlColumnInfo>();
					// id字段
					columnList.add(genColumnInfo("id", entry.getKey()
							.getClass()));

					// 表的一行数据，即所有列的数据
					List<String> tableColData = new ArrayList<String>();
					tableRowData.add(tableColData);
					// 加入id
					tableColData.add(tplId + "");

					for (int j = 0; j < fArr.length; j++) {
						// 模板对象的每个属性

						// System.out.println("attr type=" +
						// fArr[j].getType().getSimpleName());

						// 如果是notclient 则跳过
						if (fArr[j].isAnnotationPresent(NotClient.class)) {
							System.out
									.println("field is not clinet,jump...fieldName="
											+ fArr[j].getName());
							continue;
						}
						//过滤掉静态变量
						String modiStr = java.lang.reflect.Modifier.toString(fArr[j].getModifiers());
						if (modiStr.contains("static")) {
							System.out.println("fArr filt static filed!" + fArr[j].getName());
							continue;
						}

						Object value = getAttrValue(tplVOClz, fArr[j], tpl);
						if (null == value) {
							throw new Exception("ERROR!attr value is null!");
						}

						String columnNameBase = fArr[j].getName();
						if (isList(fArr[j])) {
							List<Object> vList = (List<Object>) value;
							int attrIndex = 0;
							for (Object subObj : vList) {
								attrIndex++;
								// System.out.println("list o=" +
								// subObj.getClass().getName());
								// 属性是自定义类
								if (isUserDefClass(subObj.getClass())) {
									Field[] subFArr = subObj.getClass()
											.getDeclaredFields();
									for (int k = 0; k < subFArr.length; k++) {
										//过滤掉静态变量
										String modiStrSub = java.lang.reflect.Modifier.toString(subFArr[k].getModifiers());
										if (modiStrSub.contains("static")) {
											System.out.println("subFArr filt static filed!" + subFArr[k].getName());
											continue;
										}
										
										// 字段名=columnNameBase_attrIndex_subName
										columnList.add(genColumnInfo(
												columnNameBase + "_"
														+ attrIndex + "_"
														+ subFArr[k].getName(),
												subFArr[k].getType()));

										Object subValue = getAttrValue(
												subObj.getClass(), subFArr[k],
												subObj);
										
//										//XXX 特殊字段过滤，否则会报错
//										if (subObj instanceof RewardTemplate) {
//											if (subFArr[k].getType() == RewardDef.RewardType.class) {
//												continue;
//											}
//										}
										
										if (null == value) {
											throw new Exception(
													"ERROR!sub attr value is null!");
										}
										// System.out.println("sub attr value="
										// + subValue);

										// 加入列数据
										tableColData.add(subValue.toString());
									}
								} else if (isNormalType(subObj.getClass())) {
									// 普通类型
									// 普通类型对应的 字段名=columnNameBase_attrIndex
									columnList.add(genColumnInfo(columnNameBase
											+ "_" + attrIndex,
											subObj.getClass()));
									// 加入列数据
									tableColData.add(subObj.toString());
								} else {
									throw new Exception(
											"ERROR!unrecgonized sub filed type!");
								}
							}
						} else if (isUserDefClass(fArr[j].getType())) {
							// 自定义类型，非List
							// 自定义的需要每个字段都放入，字段名作为前缀，如columnNameBase_subName
							Field[] subFArr = fArr[j].getType()
									.getDeclaredFields();
							for (int k = 0; k < subFArr.length; k++) {
								//过滤掉静态变量
								String modiStrS = java.lang.reflect.Modifier.toString(subFArr[k].getModifiers());
								if (modiStrS.contains("static")) {
									System.out.println("subFArr filt static filed!" + subFArr[k].getName());
									continue;
								}
								
								String subName = subFArr[k].getName();
								columnList.add(genColumnInfo(columnNameBase
										+ "_" + subName, subFArr[k].getType()));

								Object subValue = getAttrValue(
										fArr[j].getType(), subFArr[k], value);
								if (null == subValue) {
									throw new Exception(
											"ERROR!sub attr value is null!");
								}
								// System.out.println("sub attr value=" +
								// subValue);
								// 加入列数据
								tableColData.add(subValue.toString());
							}
						} else if (isNormalType(fArr[j].getType())) {
							// 普通类型
							// 普通类型对应的字段直接放入
							columnList.add(genColumnInfo(columnNameBase,
									fArr[j].getType()));
							// 加入列数据
							tableColData.add(value.toString());
						} else {
							throw new Exception(
									"ERROR!unrecgonized filed type!");
						}
					}
					if (!tableDefMap.containsKey(tableName)) {
						tableDefMap.put(tableName, columnList);
					}
				}
			}
		}
	}

	private static Field[] getSuperVOFiled(Class<?> clz) {
		if (clz.getSuperclass() != null) {
			if (!clz.getSuperclass().getSimpleName()
					.equalsIgnoreCase("TemplateObject")) {
				if (clz.getSuperclass().getSuperclass().getSuperclass()
						.getSimpleName().equalsIgnoreCase("TemplateObject")) {
					return clz.getSuperclass().getSuperclass()
							.getDeclaredFields();
				}
			}
		}
		return null;
	}

	private static String genTableDefSql() {
		StringBuffer sb = new StringBuffer();
		sb.append("");
		for (Entry<String, List<SqlColumnInfo>> entry : tableDefMap.entrySet()) {
			String tname = "\"main\".\"" + TablePrefix + entry.getKey() + "\"";
			String tkname = "\"main\".\"" + TablePrefix + entry.getKey()
					+ "_id\"";// id 为唯一索引
			sb.append("----------------\r\n--Table structure for " + tname
					+ " \r\n----------------\r\n");
			sb.append("DROP TABLE IF EXISTS " + tname + ";\r\n");
			sb.append("CREATE TABLE " + tname + "(\r\n");

			int i = 0;
			int size = entry.getValue().size();
			for (SqlColumnInfo col : entry.getValue()) {
				i++;
				sb.append("'" + col.name + "' " + col.getDbType());
				// last no ","
				if (i != size) {
					sb.append(",");
				}
				sb.append("\r\n");
			}
			sb.append(");\r\n");

			// 建id的唯一索引
			sb.append("CREATE UNIQUE INDEX " + tkname + " ON \"" + TablePrefix
					+ entry.getKey() + "\" (\"id\" ASC);");

			sb.append("\r\n\r\n");
		}

		return sb.toString();
	}

	private static String genTableDataSql() throws Exception {
		// TODO
		// -- ----------------------------
		// -- Records of item
		// -- ----------------------------
		// INSERT INTO "main"."item" VALUES (1010,
		// 'UI_Icon_Inventory,UI_Icon_AP_lv1', '普通体力丹', 1, 4, 10.0, 4, 120.0, 1,
		// '使用：体力+10\n\n酷酷人士闯关必需品', 500, 9999, 0, 0, 0);

		StringBuffer sb = new StringBuffer();
		for (Entry<String, List<List<String>>> entry : tableDataMap.entrySet()) {
			String tname = "\"main\".\"" + TablePrefix + entry.getKey() + "\"";
			sb.append("----------------\r\n--Records of " + tname
					+ " \r\n----------------\r\n");

			List<List<String>> ll = entry.getValue();
			for (List<String> ls : ll) {
				sb.append("INSERT INTO " + tname + " VALUES (");

				int size = ls.size();
				int i = 0;
				for (String data : ls) {
					i++;
					// 将单引号替换为双引号，否则sql会执行失败
					data = data.replaceAll("\'", "\"");
					// 将true false变为1 0
					data = data.replaceAll("true", "1")
							.replaceAll("false", "0");

					sb.append("'" + data + "'");
					if (i != size) {
						sb.append(", ");
					}
				}
				sb.append(");\r\n");
			}
			sb.append("\r\n");
		}
		return sb.toString();
	}

	public static SqlColumnInfo genColumnInfo(String columnName,
			Class<?> typeClz) {
		SqlColumnInfo columnInfo = new SqlColumnInfo();
		columnInfo.name = columnName;
		columnInfo.type = typeClz.getSimpleName().toLowerCase();
		columnInfo.typeClz = typeClz;
		return columnInfo;
	}

	public static boolean isNormalType(Class<?> clz) {
		if (clz.isPrimitive()) {
			return true;
		}
		String typeName = clz.getSimpleName();
		if (typeName.equalsIgnoreCase("Integer")
				|| typeName.equalsIgnoreCase("String")
				|| typeName.equalsIgnoreCase("Boolean")
				|| typeName.equalsIgnoreCase("Long")
				|| typeName.equalsIgnoreCase("Short")
				|| typeName.equalsIgnoreCase("Byte")) {
			return true;
		}
		return false;
	}

	public static boolean isList(Field field) {
		return field.getType().getSimpleName().equalsIgnoreCase("List");
	}

	public static boolean isUserDefClass(Class<?> clz) {
		if (isNormalType(clz)) {
			return false;
		}
		if (clz.getName().contains("java")) {
			return false;
		}
		return true;
	}

	public static Object getAttrValue(Class<?> tplVOClz, Field field, Object tpl) {
		Object value = null;
		String prefix = "get";
		if (field.getType().getSimpleName().equalsIgnoreCase("boolean")) {
			prefix = "is";
		}

		String firstLetter = field.getName().substring(0, 1).toUpperCase();
		String getter = prefix + firstLetter + field.getName().substring(1);
		try {
			Method method = tplVOClz.getMethod(getter, new Class[] {});
			value = method.invoke(tpl, new Object[] {});
		} catch (Exception e) {
			e.printStackTrace();
		}
		return value;
	}

	private static void inputFile(String fileName, String tableDefSql,
			String tableDataSql) throws Exception {
		BufferedWriter writer = null;
		try {
			File sqlFile = new File(fileName);

			writer = new BufferedWriter(new OutputStreamWriter(
					new FileOutputStream(sqlFile, true), "UTF-8"));

			writer.write(tableDefSql);
			writer.newLine();
			writer.write(tableDataSql);
			writer.flush();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			if (writer != null) {
				writer.close();
			}
		}
	}

	private static void toDB(String tableDefSql, String tableDataSql) {
		try {
			// 连接SQLite的JDBC
			Class.forName("org.sqlite.JDBC");

			// 建立一个数据库名zieckey.db的连接，如果不存在就在当前目录下创建之
			Connection conn = DriverManager.getConnection("jdbc:sqlite:"
					+ clientCSRootPath + DB_NAME);

			Statement stat = conn.createStatement();
			// stat.execute(".read " + clientCSRootPath + SQL_NAME);

			addBatchSql(stat, tableDefSql);
			addBatchSql(stat, tableDataSql);
			
			// stat.execute(tableDefSql);

			// stat.execute(tableDataSql);

			// ResultSet rs = stat.executeQuery("select 1;");

			conn.close(); // 结束数据库的连接

		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	private static void addBatchSql(Statement stat, String allSql) {
		try {
			String defArr[] = allSql.split(";");
			for (int i = 0; i < defArr.length; i++) {
				if (defArr[i].trim().isEmpty()) {
					continue;
				}
				
				String sql = defArr[i] + ";";
				System.out.println(sql);
//				stat.execute(sql);
				stat.addBatch(sql);
			}
			stat.executeBatch();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

}
