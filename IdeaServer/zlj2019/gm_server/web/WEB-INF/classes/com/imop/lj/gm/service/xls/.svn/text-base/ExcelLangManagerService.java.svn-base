package com.imop.lj.gm.service.xls;

import java.io.FileInputStream;
import java.io.InputStream;
import java.text.MessageFormat;
import java.util.HashMap;
import java.util.Map;

import org.apache.log4j.Logger;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.poifs.filesystem.POIFSFileSystem;

import com.imop.lj.gm.constants.SystemConstants;
import com.imop.lj.gm.utils.PoiUtils;

/**
 * 处理Excel的多语言类
 *
 *
 */
public class ExcelLangManagerService {

	/** ExcelLangManagerService Log */
	private static final Logger logger = Logger
			.getLogger(ExcelLangManagerService.class);

	/** 多语言语言集合 **/
	private static Map<String, String> gmMap = new HashMap<String, String>();

	/** 是否初始化数据 */
	private static boolean isInit = false;

	public ExcelLangManagerService() {
		if(!isInit){
			initData();
		}
	}

	public void setGmMap(String priv) {
		gmMap = loadExcel(priv + "/gm_lang.xls");
	}

	/** 读gm_lang.xls里面的内容 */
	public String readGm(Integer val) {
		if(val == null){
			return "";
		}
		return read("lang_" + val.toString(), gmMap);
	}

	/**
	 * 初始话所有数据
	 */
	private void initData() {
		gmMap = loadExcel(SystemConstants.PRIV_ZH_CN + "/gm_lang.xls");

	}

	/** 读gm_lang.xls里面的内容 */
	public static String readGmLang(Integer val) {
		return read("lang_" + val.toString(), gmMap);
	}


	/**
	 * 读取多语言数据,如果params不为空,则用其格式化结果
	 * @param val
	 * @param params
	 * @return
	 */
	public String formatStr(Integer val,Object... params){
		String _msg = readGmLang(val);
		if (params != null) {
			return MessageFormat.format(_msg, params);
		} else {
			return _msg;
		}
	}

	/**
	 * 根据KEY,读取多语言MAP的实际value
	 *
	 * @param val
	 *            KEY
	 * @param map
	 *            多语言MAP
	 * @return
	 */
	private static String read(String val, Map<String, String> map) {
		if (val != null) {
			val = val.trim();
		}
		if (map.get(val) != null) {
			return map.get(val);
		} else {
			return val;
		}
	}

	/**
	 * 根据excel文件名，取得对应的多语言集合
	 *
	 * @param filename
	 * @return
	 */
	private Map<String, String> loadExcel(String filename) {

		Map<String, String> tmp_map = new HashMap<String, String>();
		HSSFWorkbook workbook = null;
		InputStream inp;
		try {
			inp = new FileInputStream(this.getClass().getClassLoader()
					.getResource("i18n/" + filename).getFile());
			workbook = new HSSFWorkbook(new POIFSFileSystem(inp));
		} catch (Exception e) {
			logger.error("multi-language (%s) excel" + filename + "load error",
					e);
		}
		HSSFSheet sheet = workbook.getSheetAt(0);
		for (int i = 0; i <= sheet.getLastRowNum(); i++) {
			HSSFRow row = sheet.getRow(i);
			if (row == null) {
				continue;
			} else {
				String key = PoiUtils.getStringValue(row.getCell((int) 0));
				String value = PoiUtils.getStringValue(row.getCell((int) 1));
				if (key != null && key.trim().length() > 0) {
					tmp_map.put(key, value);
				}
			}
		}
		return tmp_map;
	}

}
