package com.imop.lj.gm.autolog;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.parsers.ParserConfigurationException;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.w3c.dom.DOMException;
import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;
import org.xml.sax.SAXException;

import com.imop.lj.gm.constants.GMLangConstants;
import com.imop.lj.gm.service.db.PrivilegeService;
import com.imop.lj.gm.service.xls.ExcelLangManagerService;
import com.imop.lj.gm.utils.LangUtils;

/**
 * 日志对应class 管理类
 * 
 * @author sky
 * 
 */
public class GMAutoLogConstants {

	/** 该类所在的根路径 */
	private static String path = LangUtils.getRootPath() + "/i18n/";
	
	/** SysUserService LOG */
	private static final Logger logger = LoggerFactory
			.getLogger(PrivilegeService.class);
	
	/** 所有日志及对应class的MAP文件 */
	private static Map<String, Class<?>> LOGTYPE;
	/**所以日志对应的Index*/
	private static Map<String, Integer> LOGINDEX;
	/** 所有日志及对应字段List的MAP文件 */
	private static Map<String, List<String>> LOGVALUE;
	/** 所有日志及对应字段List的MAP文件 KEY:logTable名称 VALUE:log的注释*/
	private static Map<String, String> LOGCOMMENT;
	/** 多语言管理 */
	private static final ExcelLangManagerService lang = new ExcelLangManagerService();
	/** BaseLog多语言 */
	private final static String[] basicLogValue = new String[] {
			lang.readGm(GMLangConstants.LOG) + lang.readGm(GMLangConstants.ID),
			lang.readGm(GMLangConstants.LOG)
					+ lang.readGm(GMLangConstants.CARDTYPE),
			lang.readGm(GMLangConstants.TIME),
			lang.readGm(GMLangConstants.REGION_ID),
			lang.readGm(GMLangConstants.SERVER_ID),
			lang.readGm(GMLangConstants.USER_ID),
			lang.readGm(GMLangConstants.USER_NAME),
			lang.readGm(GMLangConstants.ROLE_ID),
			lang.readGm(GMLangConstants.ROLE_NAME),
			lang.readGm(GMLangConstants.LEVEL),
			lang.readGm(GMLangConstants.ROLE_ALLIANCE_TYPE),
			lang.readGm(GMLangConstants.VIP_LEVEL),
			lang.readGm(GMLangConstants.TOTAL_CHARGE),
			lang.readGm(GMLangConstants.REASON)};
	/** 地图多语言 */
	private final static String[] mapLogValue = new String[] {
			lang.readGm(GMLangConstants.MAP),
			lang.readGm(GMLangConstants.MAP_X),
			lang.readGm(GMLangConstants.MAP_Y), };
	private final static String param = lang.readGm(GMLangConstants.PARAM);

	/** 是否初始化 */
	private static boolean isInit = false;

	/** Init */
	private static void init() {

		List<LogType> logTypeList = new ArrayList<LogType>();
		
		Document root = getLogTypesDoc();
		NodeList types = root.getElementsByTagName("type");
		for (int i = 0; i < types.getLength(); i++) {
			Element m = (Element) types.item(i);
			LogType logType = new LogType();
			logType.setId(Integer.parseInt(m.getAttribute("id")));
			logType.setName(m.getAttribute("name"));
			logType.setClassName(m.getAttribute("class"));
			logType.setComment(m.getAttribute("comment"));
			logTypeList.add(logType);
		}
		
		// logType init
		LOGTYPE = new HashMap<String, Class<?>>();
		//LOGINDEX init
		LOGINDEX = new HashMap<String, Integer>();
		
		LOGCOMMENT = new HashMap<String, String>();
		
		for (LogType logType : logTypeList) {
			Class logClass = null;
			try {
				logClass = Class.forName(logType.getClassName());
			} catch (ClassNotFoundException e) {
				e.printStackTrace();
			}
			if(logClass != null) {
				LOGTYPE.put(logType.getName(), logClass);
				LOGCOMMENT.put(logType.getName(), logType.getComment());
			}
			LOGINDEX.put(logType.getName(), logType.getId());
		}
		
		/** -some basic log values init- */
		List<String> basic = Arrays.asList(basicLogValue);
		@SuppressWarnings("unused")
		List<String> map = Arrays.asList(mapLogValue);
		LOGVALUE = new HashMap<String, List<String>>();
		
		Document langRoot = getLanguageDoc();
		NodeList langList = langRoot.getElementsByTagName("titles");
		for (int i = 0; i < langList.getLength(); i++) {
			Element e = (Element) langList.item(i);
			String name = e.getAttribute("name");
			NodeList titleList = e.getElementsByTagName("title");
			List<String> langTitles = new ArrayList<String>();
			
			langTitles.addAll(basic);
			for (int j = 0; j < titleList.getLength(); j++) {
				Element titleElement = (Element) titleList.item(j);
				langTitles.add(titleElement.getAttribute("name"));
			}
			langTitles.add(param);
			LOGVALUE.put(name, langTitles);
		}
		
		// set isInit true
		isInit = true;
	}

	/**
	 * 根据log类型获取Class
	 * 
	 * @param logName
	 * @return
	 */
	public static Class<?> getClassByLogName(String logName) {
		if (!isInit) {
			init();
		}
		return LOGTYPE.get(logName);
	}

	/**
	 * 根据log类型获取字段多语言
	 * 
	 * @param logName
	 * @return
	 */
	public static List<String> getHeaderByLogname(String logName) {
		if (!isInit) {
			init();
		}
		return LOGVALUE.get(logName);
	}
	
	/**
	 * 根据log类型查询logINDEX
	 * @param logName
	 * @return
	 */
	public static int getIndexByLogName(String logName) {
		if (!isInit) {
			init();
		}
		System.out.println(logName);
		return LOGINDEX.get(logName);
	}
	
	public static Document getLogTypesDoc() {
		File inFile = new File(path + LangUtils.getLanguage() + "/logtypes.xml");
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db = null;
		Document doc = null;
		try {
			db = dbf.newDocumentBuilder();
			doc = (Document) db.parse(inFile);
		} catch (ParserConfigurationException pce) {
			logger.error("ParserConfigurationException:", pce);
		}catch (SAXException e) {
			logger.error("ParserConfigurationException:", e);
		} catch (DOMException dom) {
			logger.error("DOMException:", dom.getMessage());
		} catch (IOException ioe) {
			logger.error("IOException:", ioe);
		}
		return doc;
	}
	
	private static Document getLanguageDoc() {
		File inFile = new File(path + LangUtils.getLanguage() + "/language.xml");
		DocumentBuilderFactory dbf = DocumentBuilderFactory.newInstance();
		DocumentBuilder db = null;
		Document doc = null;
		try {
			db = dbf.newDocumentBuilder();
			doc = (Document) db.parse(inFile);
		} catch (ParserConfigurationException pce) {
			logger.error("ParserConfigurationException:", pce);
		}catch (SAXException e) {
			logger.error("ParserConfigurationException:", e);
		} catch (DOMException dom) {
			logger.error("DOMException:", dom.getMessage());
		} catch (IOException ioe) {
			logger.error("IOException:", ioe);
		}
		return doc;
	}
	
	public static String getLogDesc(String logName) {
		if (!isInit) {
			init();
		}
		System.out.println(logName);
		return LOGCOMMENT.get(logName);
	}
}
