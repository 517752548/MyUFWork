package com.imop.lj.tools.excel;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.io.StringWriter;
import java.io.UnsupportedEncodingException;
import java.io.Writer;
import java.lang.reflect.Constructor;
import java.net.URL;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Properties;
import java.util.Set;
import java.util.TreeSet;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import org.apache.velocity.VelocityContext;
import org.apache.velocity.app.Velocity;

import com.imop.lj.common.exception.ConfigException;
import com.imop.lj.core.config.ConfigUtil;
import com.imop.lj.core.template.TemplateConfig;
import com.imop.lj.core.template.TemplateFileParser;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.core.util.FileUtil;
import com.imop.lj.tools.util.GeneratorHelper;

/**
 * Excel模板生成器
 *
 *
 */
public class ExcelTemplateGenerator {

	private static final String path_gs = "../game_server/src/";
//	private static final String path_gs = "..\\game_tools\\target\\server\\";
	private static final String path_core = "../core/src/";
//	private static final String path_core = "..\\game_tools\\target\\core\\";

	private static final String XML_CONFIG_DIR = "../game_server/config/";
	private static final String CONFIG_DIR = "excel/";
	private static final String MODEL_DIR = "excel/model/";

	private static final Pattern TEMPLATE_FIELD = Pattern
			.compile("([^\\s]+)\\s+([^\\s]+)\\s*;\\s*(\\[([^\\s]*)\\])?\\s*(//\\s*?(.*))?");
	private static final Pattern TEMPLATE_CONFIG = Pattern
			.compile("([^\\s]+)\\s+([^\\s]+)\\s+([^\\s]+)\\s+([a-zA-Z0-9]*)\\s*(//([^\\s]*))?");
	private static final Pattern ANOTATION_COLLECTION = Pattern
			.compile("^collection\\((\\d+),(\\d+)\\)$");
	private static final Pattern ANOTATION_ROWBINDING = Pattern
			.compile("^object\\((\\d+)\\)$");
	private static final Pattern ANOTATION_CELLBINDING = Pattern
			.compile("cell");
	private static final Pattern ANOTATION_NOTTRANSLATE = Pattern
			.compile("nottranslate");
	private static final Pattern ANOTATION_NOTCLIENT = Pattern
			.compile("notclient");
	

	private static int lineNumber = 1;
	private static Set<String> types;
	
	//c#
	private static final String clientCSRootPath = "../game_tools/target/cs_target/";
	public static final String TEMPLATE_DIC = "excel/template/";
	//c#
	private static final Pattern pObject = Pattern.compile(".*object\\((\\d+)\\).*");
	private static final Pattern pCollection = Pattern.compile(".*collection\\((\\d+),(\\d+)\\).*");
	private static final String scriptPath = "../resources/scripts/";
	//c#
	private static Map<TemplateGenConfig, List<ExcelFieldObject>> fieldMap = new HashMap<TemplateGenConfig, List<ExcelFieldObject>>();
	private static Set<TemplateGenConfig> superSet = new HashSet<TemplateGenConfig>();

	public static void main(String[] args) throws Exception {
		Properties _vp = new Properties();
		_vp.put("file.resource.loader.path", "config/excel/template");
		try {
			Velocity.init(_vp);
		} catch (Exception e) {
			throw new RuntimeException(e);
		}
		
		List<TemplateGenConfig> _configs = loadTemplateGenConfig(CONFIG_DIR,
				"model_template_gen.config");
		for (TemplateGenConfig _conf : _configs) {
			types = new TreeSet<String>();
			lineNumber = 1;
			List<ExcelFieldObject> fields = loadDetailTemplateConfig(_conf);
			fieldMap.put(_conf, fields);

			String _fileName = "";
			String _pkgName = "";
			if (_conf.getClassName().contains(".")) {
				_fileName = _conf.getClassName().substring(
						_conf.getClassName().lastIndexOf(".") + 1);
				_pkgName = _conf.getClassName().substring(0,
						_conf.getClassName().lastIndexOf("."));
			} else {
				_fileName = _conf.getClassName();
			}

			if (_conf.getFather().equals("TemplateObject")) {
				types.add("com.imop.lj.core.template.TemplateObject");
			}

			VelocityContext _context = new VelocityContext();
			_context.put("fields", fields);
			_context.put("packageName", _pkgName);
			_context.put("className", _fileName);
			_context.put("types", types);
			_context.put("comment", _conf.getComment());
			_context.put("father", _conf.getFather());

			generateTemplate(_context, _fileName, _pkgName, _conf.getPath());
		}
		
		genCS(_configs);
	}
	
	private static void genCS(List<TemplateGenConfig> _configs) throws Exception {
		//c#
		Set<String> clientCSFileNameSet = genClientCSFileNameSet();
		FileUtil.delete(new File(clientCSRootPath + "/db/"));
		FileUtil.createDir(new File(clientCSRootPath + "/db/"));
		
		for (TemplateGenConfig _conf : _configs) {
			List<ExcelFieldObject> fields = fieldMap.get(_conf);

			String _fileName = "";
			String _pkgName = "";
			if (_conf.getClassName().contains(".")) {
				_fileName = _conf.getClassName().substring(
						_conf.getClassName().lastIndexOf(".") + 1);
				_pkgName = _conf.getClassName().substring(0,
						_conf.getClassName().lastIndexOf("."));
			} else {
				_fileName = _conf.getClassName();
			}

			VelocityContext _context = new VelocityContext();
			_context.put("fields", fields);
			_context.put("fieldsRaw", fields);
			_context.put("packageName", _pkgName);
			_context.put("className", _fileName);
			_context.put("types", types);
			_context.put("comment", _conf.getComment());
			_context.put("father", _conf.getFather());

			if (!clientCSFileNameSet.contains(_fileName)) {
				continue;
			}
			
			// 如果是有父类的，需要将父类的字段也放进去
			if (!_conf.getFather().equalsIgnoreCase("TemplateObject")) {
				List<ExcelFieldObject> superFields = getSuperFieldList(_conf.getFather(), _configs);
				if (superFields != null && superFields.size() > 0) {
					superFields.addAll(fields);
					_context.put("fields", superFields);
				}
			}
			
			generateCSTemplate(_context, _fileName);
			generateCSDBTemplate(_context, _fileName);
		}
		
		// 生成父类VO
		for (TemplateGenConfig _conf : superSet) {
			List<ExcelFieldObject> fields = fieldMap.get(_conf);

			String _fileName = "";
			String _pkgName = "";
			if (_conf.getClassName().contains(".")) {
				_fileName = _conf.getClassName().substring(
						_conf.getClassName().lastIndexOf(".") + 1);
				_pkgName = _conf.getClassName().substring(0,
						_conf.getClassName().lastIndexOf("."));
			} else {
				_fileName = _conf.getClassName();
			}

			VelocityContext _context = new VelocityContext();
			_context.put("fields", fields);
			_context.put("fieldsRaw", fields);
			_context.put("packageName", _pkgName);
			_context.put("className", _fileName);
			_context.put("types", types);
			_context.put("comment", _conf.getComment());
			_context.put("father", _conf.getFather());

			generateCSTemplate(_context, _fileName);
		}
	}
	
	private static List<ExcelFieldObject> getSuperFieldList(String father, List<TemplateGenConfig> _configs) throws Exception {
		List<ExcelFieldObject> fields = new ArrayList<ExcelFieldObject>();
		for (TemplateGenConfig tc : _configs) {
			String[] arr = tc.getClassName().split("\\.");
			String sname = arr[arr.length - 1];
			//去掉VO
			sname = sname.substring(0, sname.length() - 2);
			if (sname.equalsIgnoreCase(father)) {
				fields.addAll(fieldMap.get(tc));
				
				superSet.add(tc);
				break;
			}
		}
		return fields;
	}
	
	//c#
	private static Set<String> genClientCSFileNameSet() throws Exception {
		Set<String> nameSet = new HashSet<String>();
		TemplateService templateService = new TemplateService(
				scriptPath, false); 
		// XXX 修改
		List<TemplateConfig> csFileList = templateService.loadForGenCSDBFile(ConfigUtil.getConfigURL("templates.xml"));
		for (TemplateConfig tc : csFileList) {
			// 判断如果是notclient则跳过，整体跳过
			if (tc.isNotclient()) {
				continue;
			}
			
			Class<?>[] clzArr = null;
			boolean isSelfParser = tc.getParserClassName() != null && tc.getParserClassName().length() > 0;
			if (isSelfParser) {
				Class<?> clazz = Class.forName(tc.getParserClassName());
				Constructor<?> constructor = clazz.getConstructor();
				TemplateFileParser parser = (TemplateFileParser) constructor.newInstance();
				Class<?>[] cArr = parser.getLimitClazzes();
				clzArr = new Class<?>[cArr.length - 1];
				// 跳过第一个，第一个是基类
				for (int ca = 0; ca < cArr.length - 1; ca++) {
					clzArr[ca] = cArr[ca + 1];
				}
			} else {
				clzArr = tc.getClasses();
			}
			
			int size = clzArr.length;
			for (int i = 0; i < size; i++) {
				// 单个类跳过
				if (tc.getNotclientClasses() != null && 
						tc.getNotclientClasses().length > 0 &&
						tc.getNotclientClasses()[i]) {
					continue;
				}
				nameSet.add(clzArr[i].getSimpleName()+"VO");
			}
		}
		return nameSet;
	}

	/**
	 * 读取要生成的模板的配置文件
	 *
	 * @param sourceDir
	 * @param fileName
	 * @return
	 * @throws IOException
	 */
	private static List<TemplateGenConfig> loadTemplateGenConfig(
			String sourceDir, String fileName) throws IOException {
		List<TemplateGenConfig> _configs = new ArrayList<TemplateGenConfig>();

		String _genConfig = getFilePath(sourceDir, fileName);
		BufferedReader _reader = new BufferedReader(new InputStreamReader(
				new FileInputStream(_genConfig)));
		String _line = null;

		while ((_line = _reader.readLine()) != null) {
			_line = _line.trim();
			if (_line.length() == 0) {
				continue;
			}

			Matcher _matcher = TEMPLATE_CONFIG.matcher(_line);
			if (_matcher.matches()) {
				if (_line.startsWith("#")) {
					continue;
				}
				TemplateGenConfig _conf = new TemplateGenConfig(_matcher
						.group(1), _matcher.group(2), _matcher.group(3),
						_matcher.group(4), _matcher.group(6));
				_configs.add(_conf);
			}
		}

		return _configs;
	}

	/**
	 * 加载某一具体模板的详细信息
	 *
	 * @param config
	 * @return
	 * @throws IOException
	 */
	private static List<ExcelFieldObject> loadDetailTemplateConfig(
			TemplateGenConfig config) throws IOException {
		List<ExcelFieldObject> _fields = new ArrayList<ExcelFieldObject>();

		String _fileName = config.getFileName();
		System.out.println(_fileName);
		String _tmpConfig = getFilePath(MODEL_DIR, _fileName);

		BufferedReader _reader = new BufferedReader(new InputStreamReader(
				new FileInputStream(_tmpConfig)));
		String _line = null;

		while ((_line = _reader.readLine()) != null) {
			_line = _line.trim();
			if (_line.length() == 0) {
				continue;
			}

			Matcher _matcher = TEMPLATE_FIELD.matcher(_line);
			if (!_matcher.matches()) {
				lineNumber++;
				continue;
			}

			ExcelFieldObject _f = buildFieldObject(_matcher.group(1), _matcher
					.group(2), _matcher.group(4), _matcher.group(6),
					lineNumber + 1);
			_fields.add(_f);
		}
		return _fields;
	}

	/**
	 * 生成模板类
	 *
	 * @param config
	 * @throws IOException
	 * @throws UnsupportedEncodingException
	 */
	private static void generateTemplate(VelocityContext context,
			String fileName, String pkgName, String path)
			throws UnsupportedEncodingException, IOException {
		StringWriter _readWriter = new StringWriter();
		try {
			Velocity.mergeTemplate("TemplateClass.template", "UTF-8", context,
					_readWriter);
		} catch (Exception e) {
			throw new RuntimeException(e);
		}

		if (!pkgName.equals("")) {
			path = getPath(path);
			File _srcDist = new File(path + pkgName.replaceAll("\\.", "/"));
			if (!_srcDist.exists()) {
				if (!_srcDist.mkdirs()) {
					throw new RuntimeException("Can't create dir " + _srcDist);
				}
			}
			Writer _fileWriter = new OutputStreamWriter(new FileOutputStream(
					new File(_srcDist, fileName + ".java")), "UTF-8");
			_fileWriter.write(_readWriter.toString());
			_fileWriter.close();
		} else {
			Writer _fileWriter = new OutputStreamWriter(new FileOutputStream(
					new File(fileName + ".java")), "UTF-8");
			_fileWriter.write(_readWriter.toString());
			_fileWriter.close();
		}
	}
	
	//c#
	private static void generateCSTemplate(VelocityContext context, String fileName)
			throws UnsupportedEncodingException, IOException {
		String outputCSFilePath = clientCSRootPath + "/db/" + fileName + ".cs";
		String clientModelCSTemplate = "TemplateClassCS.template";
		try {
			
			GeneratorHelper.generate(context, clientModelCSTemplate, outputCSFilePath, TEMPLATE_DIC);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	//c#
	private static void generateCSDBTemplate(VelocityContext context, String fileName)
			throws UnsupportedEncodingException, IOException {
		// clientName 去掉VO的name，fileName VO变为DBBase的name
		String clientName = fileName;
		if (fileName.endsWith("VO")) {
			fileName = fileName.substring(0, fileName.length() - 2);
			clientName = fileName;
			fileName += "DB";
		}
		
		context.put("fileName", fileName);
		context.put("clientName", clientName);
		context.put("TablePrefix", SqliteSqlGenerator.TablePrefix);
		
		String outputCSFilePath = clientCSRootPath + "/db/" + fileName + "Base.cs";
		String clientModelCSTemplate = "TemplateDBCS.template";
		try {
			GeneratorHelper.generate(context, clientModelCSTemplate, outputCSFilePath, TEMPLATE_DIC);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	//c# sql
	private static void genSqlCS(VelocityContext context, String fileName)
			throws UnsupportedEncodingException, IOException {
		
		String outputCSFilePath = clientCSRootPath + "/sql/db.sql";
		String clientModelCSTemplate = "SqlCS.template";
		try {
			FileUtil.delete(new File(clientCSRootPath + "/sql"));
			GeneratorHelper.generate(context, clientModelCSTemplate, outputCSFilePath, TEMPLATE_DIC);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	

	/**
	 * 获取文件路径
	 *
	 * @param dir
	 * @param fileName
	 * @return
	 */
	private static String getFilePath(String dir, String fileName) {
		ClassLoader classLoader = Thread.currentThread()
				.getContextClassLoader();
		URL url = classLoader.getResource(dir + fileName);
		if (url == null) {
			throw new ConfigException("file:" + fileName + " does not exists");
		}
		return url.getPath();
	}

	/**
	 * 解析生成字段的anotation
	 *
	 * @param str
	 * @return
	 */
	private static List<String> buildAnotation(String str, String type) {
		List<String> _anotations = new ArrayList<String>();

		if (str == null || str.equals("")) {
			str = "cell";
		}

		if (str.contains("nottranslate")) {
			str = str + ";cell";
		}

		String[] _arr = str.split(";");
		int _len = _arr.length;

		for (int i = 0; i < _len; i++) {
			String tmp = _arr[i].toLowerCase();
			Matcher _matcher = ANOTATION_COLLECTION.matcher(tmp);

			if (_matcher.matches()) {
				types
						.add("com.imop.lj.core.template.ExcelCollectionMapping");
				int _g = Integer.parseInt(_matcher.group(1));
				int _p = Integer.parseInt(_matcher.group(2));
				StringBuilder sb = new StringBuilder(
						"@ExcelCollectionMapping(clazz = ");
				sb.append(type);
				sb.append(".class, collectionNumber = \"");
				for (int j = 0; j < _g; j++) {
					for (int k = 0; k < _p; k++) {
						sb.append(lineNumber);
						if (k != _p - 1) {
							sb.append(",");
						}
						lineNumber++;
					}
					if (j != _g - 1) {
						sb.append(";");
					}
				}
				sb.append("\")");
				_anotations.add(sb.toString());
				continue;
			}

			_matcher = ANOTATION_CELLBINDING.matcher(tmp);
			if (_matcher.matches()) {
				StringBuilder sb = new StringBuilder(
						"@ExcelCellBinding(offset = ");
				sb.append(lineNumber);
				sb.append(")");
				_anotations.add(sb.toString());
				lineNumber++;
				types.add("com.imop.lj.core.annotation.ExcelCellBinding");
				continue;
			}

			_matcher = ANOTATION_ROWBINDING.matcher(tmp);
			if (_matcher.matches()) {
				int _line = Integer.parseInt(_matcher.group(1));
				_anotations.add("@ExcelRowBinding");
				lineNumber = lineNumber + _line;
				continue;
			}

			_matcher = ANOTATION_NOTTRANSLATE.matcher(tmp);
			if (_matcher.matches()) {
				types.add("com.imop.lj.core.annotation.NotTranslate");
				_anotations.add("@NotTranslate");
				continue;
			}
		}
		return _anotations;
	}

	/**
	 * 解析字段类型
	 *
	 * @param type
	 * @return
	 */
	private static String parseFieldType(String type) {
		Pattern _map = Pattern.compile("Map<[a-zA-Z0-9]+,([^\\s]+)>");
		Pattern _list = Pattern.compile("List<([^\\s]+)>");
		Pattern _set = Pattern.compile("Set<([^\\s]+)>");
		Pattern _array = Pattern.compile("([a-zA-Z]+)\\[\\]");

		// Map类型的
		Matcher _matcher = _map.matcher(type);
		if (_matcher.matches()) {
			types.add("java.util.Map");
			return _matcher.group(1);
		}

		// LIST
		_matcher = _list.matcher(type);
		if (_matcher.matches()) {
			types.add("java.util.List");
			return _matcher.group(1);
		}

		// SET
		_matcher = _set.matcher(type);
		if (_matcher.matches()) {
			types.add("java.util.Set");
			return _matcher.group(1);
		}

		// ARRAY
		_matcher = _array.matcher(type);
		if (_matcher.matches()) {
			return _matcher.group(1);
		}

		return type;
	}
	
	private static String genClientType(String type) {
		//"List<com.imop.lj.gameserver.activity.template.ActivityFunctionTemplate>"
		// 变为 List<ActivityFunctionTemplate>
		String clientType = type.replaceAll("[a-zA-Z0-9]+\\.", "");
		return clientType;
	}
	
	private static String getLastDotStr(String str) {
		if (str.contains(".")) {
			String[] tArr = str.split("\\.");
			str = tArr[tArr.length - 1];
		}
		return str;
	}
	
	private static int genUnitFieldNum(String content) {
		int num = 0;
		content = content.toLowerCase();
		if (content.contains("object")) {
			//com.imop.lj.gameserver.activity.template.ActivityFunctionTemplate activityFunctionTemplate;[Object(6)] //活动执行函数";
//			Pattern pObject = Pattern.compile(".*object\\((\\d+)\\).*");
			Matcher matcher = pObject.matcher(content);
			if (matcher.matches()) {
				num = Integer.parseInt(matcher.group(1));
			}
		} else if (content.contains("collection")) {
			//List<com.imop.lj.gameserver.activity.template.ActivityMessageTemplate> activityMessageTemplateList;[collection(4,6)] //活动个阶段函数
//			Pattern pCollection = Pattern.compile(".*collection\\((\\d+),(\\d+)\\).*");
			Matcher matcherCol = pCollection.matcher(content);
			if (matcherCol.matches()) {
				num = Integer.parseInt(matcherCol.group(2));
			}
		}
		return num;
	}
	
	private static int genUnitNum(String content) {
		int num = 0;
		//List<com.imop.lj.gameserver.activity.template.ActivityMessageTemplate> activityMessageTemplateList;[collection(4,6)] //活动个阶段函数
		content = content.toLowerCase();
//		Pattern pCollection = Pattern.compile(".*collection\\((\\d+),(\\d+)\\).*");
		Matcher matcher = pCollection.matcher(content);
		if (matcher.matches()) {
			num = Integer.parseInt(matcher.group(1));
		}
		return num;
	}

	private static final ExcelFieldObject buildFieldObject(String type,
			String name, String condition, String comment, int startLine) {
		ExcelFieldObject _f = null;

		Pattern _minValue = Pattern.compile("minvalue=(\\d+)");
		Pattern _maxValue = Pattern.compile("maxvalue=(\\d+)");
		Pattern _x = Pattern.compile("x=([^\\s]+)");
		Pattern _y = Pattern.compile("y=([^\\s]+)");
		Pattern _anot = Pattern
				.compile("(collection[^\\s]+)|(object[^\\s]+)|(nottranslate)|(cell)");
		Pattern _notNull = Pattern.compile("notnull=([^\\s]+)");
		Pattern _maxLen = Pattern.compile("maxlen=(\\d+)");
		Pattern _minLen = Pattern.compile("minlen=(\\d+)");
		
		Pattern _notClient = ANOTATION_NOTCLIENT;

		StringBuilder anot = new StringBuilder();
		boolean x = false;
		boolean y = false;
		int maxValue = -1;
		int minValue = -1;
		boolean notNull = true;
		int minLen = -1;
		int maxLen = -1;
		
		boolean notClient = false;
		int unitFieldNum = 0;
		int unitNum = 0;

		if (condition == null) {
			condition = "";
		}

		String[] _conds = condition.split(";");

		for (String _c : _conds) {
			_c = _c.toLowerCase();
			Matcher _matcher = _anot.matcher(_c);

			if (_matcher.matches()) {
				if (!anot.toString().equals("")) {
					anot.append(";");
				}
				anot.append(_c);
				continue;
			}

			_matcher = _minValue.matcher(_c);
			if (_matcher.matches()) {
				minValue = Integer.parseInt(_matcher.group(1));
				continue;
			}

			_matcher = _maxValue.matcher(_c);
			if (_matcher.matches()) {
				maxValue = Integer.parseInt(_matcher.group(1));
				continue;
			}

			_matcher = _x.matcher(_c);
			if (_matcher.matches()) {
				x = Boolean.parseBoolean(_matcher.group(1));
				if (x) {
					types.add("com.imop.lj.common.exception.TemplateConfigException");
				}
				continue;
			}

			_matcher = _y.matcher(_c);
			if (_matcher.matches()) {
				y = Boolean.parseBoolean(_matcher.group(1));
				if (y) {
					types.add("com.imop.lj.common.exception.TemplateConfigException");
				}
				continue;
			}

			_matcher = _notNull.matcher(_c);
			if (_matcher.matches()) {
				notNull = Boolean.parseBoolean(_matcher.group(1));
				continue;
			}

			_matcher = _maxLen.matcher(_c);
			if (_matcher.matches()) {
				maxLen = Integer.parseInt(_matcher.group(1));
				continue;
			}

			_matcher = _minLen.matcher(_c);
			if (_matcher.matches()) {
				minLen = Integer.parseInt(_matcher.group(1));
				continue;
			}
			
			_matcher = _notClient.matcher(_c);
			if (_matcher.matches()) {
				notClient = true;
				continue;
			}
		}

		if (notNull) {
			types.add("com.imop.lj.common.exception.TemplateConfigException");
		}

		if (notNull && type.equals("String")) {
			types.add("com.imop.lj.core.util.StringUtils");
		}

		if (!notNull && ( // 如果是非对象类型数据, 且 notNull=false
			type.equals("int") ||
			type.equals("float") ||
			type.equals("long") ||
			type.equals("short"))) {
			types.add("com.imop.lj.common.exception.TemplateConfigException");
		}

		String _fieldType = parseFieldType(type);
		List<String> _anotations = buildAnotation(anot.toString(), _fieldType);
		
		//c#
		if (notClient) {
			types.add("com.imop.lj.core.annotation.NotClient");
			_anotations.add("@NotClient");
		}
		String clientType = genClientType(type);
		unitFieldNum = genUnitFieldNum(condition);
		unitNum = genUnitNum(condition);
		
		_f = new ExcelFieldObject(type, name, _anotations, comment, x, y,
				maxValue, minValue, notNull, startLine, maxLen, minLen, 
				notClient, clientType, unitFieldNum, unitNum);

		return _f;
	}

	private static String getPath(String pkgName) {
		if (pkgName.contains("gs")) {
			return path_gs;
		}

		if (pkgName.contains("core")) {
			return path_core;
		}

		throw new ConfigException("您在model_template_gen.config中配置了错误的包名："
				+ pkgName);
	}

}
