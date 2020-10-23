package com.imop.lj.gm.service.xls;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.Map;

import org.apache.log4j.Logger;
import org.apache.poi.hssf.usermodel.HSSFRow;
import org.apache.poi.hssf.usermodel.HSSFSheet;
import org.apache.poi.hssf.usermodel.HSSFWorkbook;
import org.apache.poi.poifs.filesystem.POIFSFileSystem;

import com.imop.lj.core.encrypt.XorDecryptedInputStream;
import com.imop.lj.gm.config.GmConfig;
import com.imop.lj.gm.utils.ErrorsUtil;
import com.imop.lj.gm.utils.PoiUtils;

/**
 * 加载游戏内的excel数据到gm系统，主要是id与name的对应关系
 *
 *
 */
public class XlsItemLoadService {

	/** ExcelLangManagerService Log */
	private static final Logger logger = Logger.getLogger(XlsItemLoadService.class);
	
	public GmConfig gmConfig;

	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
		
	}

	/**
	 * 数据结构定义 <ExcelNameKey,<ID,NAME>>
	 */
	private static HashMap<String, Map<String, String>> xlsData = new HashMap<String, Map<String, String>>();

	public String getRootPath(){
		return gmConfig.baseResourceDir + File.separator	+ gmConfig.scriptDir + File.separator;
	}

	private boolean isDebug;

	/** 是否初始化数据 */
	private static boolean isInit = false;

	public void init(){
//		isDebug = (GmConfig.isDebugMode == 1);
		isDebug = true;
		gmConfig = GmConfig.GetInstance();
		loadItem();
		

		isInit = true;
	}

	public XlsItemLoadService() {
		if(!isInit){
			init();
		}
	}

	/**
	 * 由宠物id得到宠物名
	 * @param petTmplId
	 * @return
	 */
	public static String getPetName(String petTmplId){
		return read("pets",petTmplId);
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
	private static String read(String val, String id) {
		if (val != null) {
			val = val.trim();
		}
		if (xlsData.get(val) != null) {
			return xlsData.get(val).get(id);
		} else {
			return String.valueOf(id);
		}
	}

	/**
	 * 加载物品excel
	 *
	 */
	public void loadItem() {
		HSSFWorkbook wb;
		InputStream inp = null;
		try {

			logger.error(System.getProperty("user.dir"));
			logger.error(System.getProperty("user.dir")+getRootPath() + "item.xls");
			Map<String,String> items = new LinkedHashMap<String,String>();

//			inp = isDebug ? new FileInputStream(getRootPath() + "item.xls")
//					: new XorDecryptedInputStream(getRootPath() + "item.xls");
			inp = new FileInputStream(getRootPath()+"item.xls");
			wb = new HSSFWorkbook(new POIFSFileSystem(inp));
			// 道具
			for (int s = 0; s < gmConfig.itemSheetNum; s++) {
				HSSFSheet sheet1 = wb.getSheetAt(s);
				logger.error("sheet总长度："+sheet1.getLastRowNum());
				for (int i = 1; i <= sheet1.getLastRowNum(); i++) {
					HSSFRow row = sheet1.getRow(i);
					try{
					String itemId = PoiUtils.getStringValue(row.getCell(0));
					String itemName = PoiUtils.getStringValue(row.getCell(2));
					
					// itemName = ExcelLangManagerService.readItems(itemName);
					if(itemId == null || itemId.isEmpty()){
						continue;
					}
					items.put(itemId, itemName);
					logger.error(itemId+itemName);
					} catch (Exception e) {
						e.printStackTrace();
					}
				}
			}			

			addMap("items", items);
			inp.close();// 关闭流
		} catch (FileNotFoundException e) {
			logger.error(ErrorsUtil.error(this.getClass().toString(),
					"loadItem", e.getMessage()));
			e.printStackTrace();
			logger.error(e);
		} catch (IOException e) {
			logger.error(ErrorsUtil.error(this.getClass().toString(),
					"loadItem", e.getMessage()));
			e.printStackTrace();
			logger.error(e);
		}
	}
	/**
	 * 由物品id得到物品名
	 * @param petTmplId
	 * @return
	 */
	public static String getItemName(String itemTmplId){
		return read("items",itemTmplId);
	}

	public static String get(String type, String key) {
		if (key == null)
			return "";
		String obj = (String) xlsData.get(type).get(key);
		if (obj != null) {
			return obj;
		} else {
			return key;
		}
	}

	private void addMap(String key, Map<String, String> value) {
		xlsData.put(key, value);
	}


	public HashMap<String, Map<String, String>> getXlsData() {
		return xlsData;
	}

	public static HashMap<String, Map<String, String>> getStaticXlsData() {
		return xlsData;
	}

	@SuppressWarnings("static-access")
	public void setXlsData(HashMap<String, Map<String, String>> xlsData) {
		this.xlsData = xlsData;
	}

}
