package com.imop.lj.gm.service.xls;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

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
public class XlsSecretaryLoadService {
	
	public GmConfig gmConfig;

	public void setGmConfig(GmConfig gmConfig) {
		this.gmConfig = gmConfig;
	}


	public static final String SEC_MODEL = "secretary";
	
	public static final String SKILL_MODEL = "skill";
	
	public static final String SEC_FILE_NAME = SEC_MODEL+".xls";
	
	public static final String SKILL_FILE_NAME = SKILL_MODEL+".xls";
	
	
	public static final String MOBLIEACTIVITY_MODEL = "goodactivity";
	public static final String MOBLIEACTIVITY_FILE_NAME = MOBLIEACTIVITY_MODEL+".xls";
	
	public static final String GIFT_MODEL = "gift";
	public static final String GIFT_MODEL_FILE_NAME = GIFT_MODEL+".xls";
	
	/** ExcelLangManagerService Log */
	private static final Logger logger = Logger.getLogger(XlsSecretaryLoadService.class);

	/** 
	 * 数据结构定义 <ExcelNameKey,<ID,NAME>>  
	 */
	private static Map<String, SecretaryInfo> secInfoData = new HashMap<String, SecretaryInfo>();
	
	/**
	 * KEY:templateId, VALUE:skillName
	 */
	private static Map<String, String> skillData = new HashMap<String, String>();
	
	/**
	 * KEY:templateId, VALUE:MobileActivityInfo
	 */
	private static Map<Integer, List<MobileActivityInfo>> mobileActivityInfoMap = new HashMap<Integer, List<MobileActivityInfo>>();
	private static Map<Integer, MobileActivityInfo> mobileActivityInfoAllMap = new HashMap<Integer, MobileActivityInfo>();
	private static List<MobileActivityInfo> mobileActivityInfoAllMapList = new ArrayList<MobileActivityInfo>();
	
	private static Map<Integer,MobileActivityPrizeInfo> mobileActivityPrizeMap = new HashMap<Integer,MobileActivityPrizeInfo>();

//	private String rootPath = gmConfig.baseResourceDir + File.separator	+ gmConfig.scriptDir + File.separator;
	private String getRootPath(){
		return gmConfig.baseResourceDir + File.separator	+ gmConfig.scriptDir + File.separator;
	}
	private boolean isDebug;
	
	/** 是否初始化数据 */
	private static boolean isInit = false;
	
	public void init(){
		gmConfig =GmConfig.GetInstance();
		
		isDebug = (gmConfig.isDebugMode == 1);

//		loadSec();
		
//		loadSkill();
		
		loadMobileActivity();

		isInit = true;
	}

	public XlsSecretaryLoadService() {
		if(!isInit){
			init();
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
	private static SecretaryInfo readSecInfo(String id) {
		if (secInfoData.get(id) != null) {
			return secInfoData.get(id);
		} else {
			return null;
		}
		
	}
	
	/**
	 * 加载物品excel
	 * 
	 */
	public void loadSec() {
		HSSFWorkbook wb;
		InputStream inp = null;
		try {
			
			logger.error(System.getProperty("user.dir"));
			logger.error(System.getProperty("user.dir")+getRootPath() + SEC_FILE_NAME);
			Map<String,SecretaryInfo> secInfos = new LinkedHashMap<String,SecretaryInfo>();
			
			inp = isDebug ? new FileInputStream(getRootPath() + SEC_FILE_NAME)
					: new XorDecryptedInputStream(getRootPath() + SEC_FILE_NAME);
			wb = new HSSFWorkbook(new POIFSFileSystem(inp));
			// 道具
			HSSFSheet sheet1 = wb.getSheetAt(0);
			logger.error("sheet总长度："+sheet1.getLastRowNum());
			for (int i = 1; i <= sheet1.getLastRowNum(); i++) {
				HSSFRow row = sheet1.getRow(i);
//				String itemId = PoiUtils.getStringValue(row.getCell(0));	
				SecretaryInfo secInfo = new SecretaryInfo();
				String secTmpId = PoiUtils.getIntString(row.getCell(0));
				String name = PoiUtils.getStringValue(row.getCell(2));
				String skillId = PoiUtils.getStringValue(row.getCell(8));
				
				secInfo.setTemplateId(secTmpId);
				secInfo.setName(name);
				secInfo.setSkill(skillId);
				
				// itemName = ExcelLangManagerService.readItems(itemName);
				secInfos.put(secTmpId, secInfo);
				logger.error(secTmpId+name);
			}
			
			addSecInfoMap(secInfos);
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
	 * 加载物品excel
	 * 
	 */
	public void loadSkill() {
		HSSFWorkbook wb;
		InputStream inp = null;
		try {
			
			logger.error(System.getProperty("user.dir"));
			logger.error(System.getProperty("user.dir")+getRootPath() + SKILL_FILE_NAME);
			Map<String,SecretaryInfo> secInfos = new LinkedHashMap<String,SecretaryInfo>();
			
			inp = isDebug ? new FileInputStream(getRootPath() + SKILL_FILE_NAME)
					: new XorDecryptedInputStream(getRootPath() + SKILL_FILE_NAME);
			wb = new HSSFWorkbook(new POIFSFileSystem(inp));
			// 道具
			HSSFSheet sheet1 = wb.getSheetAt(0);
			logger.error("sheet总长度："+sheet1.getLastRowNum());
			for (int i = 1; i <= sheet1.getLastRowNum(); i++) {
				HSSFRow row = sheet1.getRow(i);
//				String itemId = PoiUtils.getStringValue(row.getCell(0));	
				SecretaryInfo secInfo = new SecretaryInfo();
				String skillTempId = PoiUtils.getIntString(row.getCell(0));
				String name = PoiUtils.getStringValue(row.getCell(2));
				addSkillMap(skillTempId, name);
				// itemName = ExcelLangManagerService.readItems(itemName);
				logger.error(skillTempId+name);
			}
			
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
	 * 加载可配置活动excel
	 * 
	 */
	public void loadMobileActivity() {
		HSSFWorkbook wb;
		InputStream inp = null;
		Map<Integer,MobileActivityInfo> mobileActivityMap = new HashMap<Integer,MobileActivityInfo>();
		Map<Integer,List<MobileActivityPrize>> listMap = new HashMap<Integer,List<MobileActivityPrize>>();
		Map<Integer,List<MobileActivityPrizeItem>> mobileActivityMapList = new HashMap<Integer,List<MobileActivityPrizeItem>>();
		try {
			
			logger.error(System.getProperty("user.dir"));
			logger.error(System.getProperty("user.dir")+getRootPath() + MOBLIEACTIVITY_FILE_NAME);

			inp = isDebug ? new FileInputStream(getRootPath() + MOBLIEACTIVITY_FILE_NAME)
					: new XorDecryptedInputStream(getRootPath() + MOBLIEACTIVITY_FILE_NAME);
			wb = new HSSFWorkbook(new POIFSFileSystem(inp));
			// 活动信息
			HSSFSheet sheet1 = wb.getSheetAt(0);
			logger.error("sheet总长度loadMobileActivity："+sheet1.getLastRowNum());
			for (int i = 1; i <= sheet1.getLastRowNum(); i++) {
				HSSFRow row = sheet1.getRow(i);	
				MobileActivityInfo mobileActivityInfo = new MobileActivityInfo();
				mobileActivityInfo.setTemplateId(PoiUtils.getIntValue(row.getCell(0)));
				mobileActivityInfo.setSubType(PoiUtils.getIntValue(row.getCell(1)));
				mobileActivityInfo.setName(PoiUtils.getStringValue(row.getCell(6)));
				mobileActivityInfo.setDesc(PoiUtils.getStringValue(row.getCell(8)));
				mobileActivityInfo.setUseOrNot(1);
				mobileActivityInfo.setDay(PoiUtils.getIntValue(row.getCell(9)));
				mobileActivityInfo.setHour(PoiUtils.getIntValue(row.getCell(10)));
				
				mobileActivityMap.put(mobileActivityInfo.getTemplateId(), mobileActivityInfo);
				logger.info("XlsSecretaryLoadService.loadMobileActivity() sheet1 templateId="+mobileActivityInfo.getTemplateId()+" name="+mobileActivityInfo.getName()+" subType="+mobileActivityInfo.getSubType());
			}
			
//			//活动奖励
//			HSSFSheet sheet2 = wb.getSheetAt(1);
//			logger.error("sheet总长度："+sheet2.getLastRowNum());
//			for (int i = 1; i <= sheet2.getLastRowNum(); i++) {
//				HSSFRow row = sheet2.getRow(i);	
//				MobileActivityPrize mobileActivityPrize = new MobileActivityPrize();
//				if(row==null){
//					continue;
//				}
//				mobileActivityPrize.setGroups(PoiUtils.getIntValue(row.getCell(1)));
//				mobileActivityPrize.setNum(PoiUtils.getIntValue(row.getCell(3)));
//				mobileActivityPrize.setPrizeTemplateId(PoiUtils.getIntValue(row.getCell(2)));
//				mobileActivityPrize.setStage(PoiUtils.getIntValue(row.getCell(4)));
//				
//				if(listMap.containsKey(mobileActivityPrize.getGroups())){
//					listMap.get(mobileActivityPrize.getGroups()).add(mobileActivityPrize);
//				}else{
//					List<MobileActivityPrize> _list = new ArrayList<MobileActivityPrize>();
//					_list.add(mobileActivityPrize);
//					listMap.put(mobileActivityPrize.getGroups(), _list);
//				}
//				logger.info("XlsSecretaryLoadService.loadMobileActivity() sheet2 templateId="+mobileActivityPrize.getGroups());
//			}
			
//			logger.error(System.getProperty("user.dir"));
//			logger.error(System.getProperty("user.dir")+rootPath + MOBLIEACTIVITY_FILE_NAME);
//
//			inp = isDebug ? new FileInputStream(rootPath + GIFT_MODEL_FILE_NAME)
//					: new XorDecryptedInputStream(rootPath + GIFT_MODEL_FILE_NAME);
//			wb = new HSSFWorkbook(new POIFSFileSystem(inp));
//			//活动奖励
//			HSSFSheet sheet3 = wb.getSheetAt(5);
//			logger.error("sheet总长度："+sheet3.getLastRowNum());
//			for (int i = 1; i <= sheet3.getLastRowNum(); i++) {
//				HSSFRow row = sheet3.getRow(i);	
//				List<MobileActivityPrizeItem> list = new ArrayList<MobileActivityPrizeItem>();
//				mobileActivityMapList.put(PoiUtils.getIntValue(row.getCell(0)), list);
//				
//				int j=1;
//				while(j<41){
//					MobileActivityPrizeItem _temp = new MobileActivityPrizeItem();
//					if(PoiUtils.getIntValue(row.getCell(j))<=0){
//						j++;
//						j++;
//						continue;
//					}
//					
//					_temp.setTemplateId(PoiUtils.getIntValue(row.getCell(j)));
//					j++;
//					_temp.setNum(PoiUtils.getIntValue(row.getCell(j)));
//					j++;
//					
//					list.add(_temp);
//					
//					logger.info("XlsSecretaryLoadService.loadMobileActivity() sheet3 templateId="+_temp.getTemplateId()+" num="+_temp.getNum());
//				}
//				logger.info("XlsSecretaryLoadService.loadMobileActivity() sheet3 templateId=");
//			}
			
			inp.close();// 关闭流
		} catch (FileNotFoundException e) {
			logger.error(ErrorsUtil.error(this.getClass().toString(),
					"loadMobileActivity", e.getMessage()));
			e.printStackTrace();
			logger.error(e);
		} catch (IOException e) {
			logger.error(ErrorsUtil.error(this.getClass().toString(),
					"loadMobileActivity", e.getMessage()));
			e.printStackTrace();
			logger.error(e);
		}
		
		loadMobileActivityForMap(mobileActivityMap);
		loadMobileActivityPrizeMap(listMap,mobileActivityMapList);
	}
	
	//可配置活动奖励
	private void loadMobileActivityPrizeMap(Map<Integer,List<MobileActivityPrize>> listMap,Map<Integer,List<MobileActivityPrizeItem>> mobileActivityMapList){
		//mobileActivityPrizeMap   mobileActivityInfoAllMap
		for(Entry<Integer,List<MobileActivityPrize>> _entry:listMap.entrySet()){
			MobileActivityPrizeInfo _mobileActivityPrizeInfo = new MobileActivityPrizeInfo();
			_mobileActivityPrizeInfo.setMobilePrizeGroupId(_entry.getKey());
//			String prizeStr =  _entry.getKey()+" :: ";
			
			String prizeStr =  "";
			for(MobileActivityPrize _mobileActivityPrize:_entry.getValue()){
				prizeStr = prizeStr + _mobileActivityPrize.getStage()+" :: ";
				if(!mobileActivityMapList.containsKey(_mobileActivityPrize.getPrizeTemplateId())){
					String str = XlsItemLoadService.getItemName(_mobileActivityPrize.getPrizeTemplateId()+"");
					if(str==null){
						str="";
					}
					prizeStr = prizeStr + str+"("+_mobileActivityPrize.getPrizeTemplateId()+")"
					+"="+_mobileActivityPrize.getNum()+";";
					
					prizeStr = prizeStr +"<br>";
					continue;
				}
				
				List<MobileActivityPrizeItem> _list = mobileActivityMapList.get(_mobileActivityPrize.getPrizeTemplateId());
				for(MobileActivityPrizeItem _mobileActivityPrizeItem:_list){
					String str = XlsItemLoadService.getItemName(_mobileActivityPrizeItem.getTemplateId()+"");
					if(str==null){
						str="";
					}
					prizeStr = prizeStr + str+"("+_mobileActivityPrizeItem.getTemplateId()+")"
					+"="+_mobileActivityPrizeItem.getNum()+";";
				}
				prizeStr = prizeStr +"<br>";
				continue;
			}
			_mobileActivityPrizeInfo.setPrize(prizeStr);
			mobileActivityPrizeMap.put(_mobileActivityPrizeInfo.getMobilePrizeGroupId(), _mobileActivityPrizeInfo);
		}
		
		listMap=null;
		mobileActivityMapList=null;
	}
	
	//可配置活动
	private void loadMobileActivityForMap(Map<Integer,MobileActivityInfo> mobileActivityMap){
		if(mobileActivityMap==null){
			return ;
		}
		
		mobileActivityInfoAllMap = mobileActivityMap ;
		
		for(MobileActivityInfo mobileActivityInfo:mobileActivityMap.values()){
			if(mobileActivityInfoMap.containsKey(mobileActivityInfo.getSubType())){
				mobileActivityInfoMap.get(mobileActivityInfo.getSubType()).add(mobileActivityInfo);
			}else{
				List<MobileActivityInfo> list = new ArrayList<MobileActivityInfo>();
				list.add(mobileActivityInfo);
				mobileActivityInfoMap.put(mobileActivityInfo.getSubType(), list);
			}
			System.out.println("now add activityinfo"+mobileActivityInfo.getName());
			mobileActivityInfoAllMapList.add(mobileActivityInfo);
		}
	}
	
	/***
	 * 获得活动奖励  
	 */
	public String getMobileActivityPrize(int groupsId){
		MobileActivityPrizeInfo _mobileActivityPrizeInfo = mobileActivityPrizeMap.get(groupsId);
		if(_mobileActivityPrizeInfo==null){
			return "";
		}
		return _mobileActivityPrizeInfo.getPrize();
	}
	
	/**
	 * 由活动类型获得活动list
	 */
	public List<MobileActivityInfo> getMobileActivityOnSubType(int subType){
		return mobileActivityInfoMap.get(subType);
	}
	
	/**
	 * 由活动id活动
	 */
	public MobileActivityInfo getMobileActivityOnId(int id){
		return mobileActivityInfoAllMap.get(id);
	}
	
	/***
	 * 获得 可配置活动 活动奖励组名称
	 */
	public List<MobileActivityInfo> getMobileActivityInfoAllMapList(){
		return mobileActivityInfoAllMapList;
	}
	
	/**
	 * 由物品id得到物品名
	 * @param petTmplId
	 * @return
	 */
	public SecretaryInfo getSecretaryInfo(String itemTmplId){
		SecretaryInfo secInfo = readSecInfo(itemTmplId);
		if(secInfo == null) {
			logger.error(SEC_FILE_NAME+"中itemTmplId="+itemTmplId+"不存在");
		}
		return secInfo;
	}
	
	public String getSkillName(String templateId) {
		if(templateId != null) {
			return skillData.get(templateId);
		}
		return null;
 	}


	private void addSecInfoMap(Map<String,SecretaryInfo> secInfos) {
		if(secInfos != null) {
			secInfoData.putAll(secInfos);
		}
	}

	@SuppressWarnings("static-access")
	public static void setSecInfoData(Map<String, SecretaryInfo> secInfoData) {
		XlsSecretaryLoadService.secInfoData = secInfoData;
	}
	
	public static Map<String, String> getSkillData() {
		return skillData;
	}

	@SuppressWarnings("static-access")
	public static void setSkillData(Map<String, String> skillData) {
		XlsSecretaryLoadService.skillData = skillData;
	}

	private void addSkillMap(String key,String value) {
		if(key != null && value != null) {
			skillData.put(key, value);
		}
	}
	
	//活动奖励
	private class MobileActivityPrize{
		private int prizeTemplateId;
		private int stage;
		private int groups;
		private int num;
		private int type;
		public int getPrizeTemplateId() {
			return prizeTemplateId;
		}
		public void setPrizeTemplateId(int prizeTemplateId) {
			this.prizeTemplateId = prizeTemplateId;
		}
		public int getStage() {
			return stage;
		}
		public void setStage(int stage) {
			this.stage = stage;
		}
		public int getGroups() {
			return groups;
		}
		public void setGroups(int groups) {
			this.groups = groups;
		}
		public int getNum() {
			return num;
		}
		public void setNum(int num) {
			this.num = num;
		}
		public int getType() {
			return type;
		}
		public void setType(int type) {
			this.type = type;
		}
		
	}
	
	//活动奖励
	private class MobileActivityPrizeItem{
		private int templateId;
		private int num;
		public int getTemplateId() {
			return templateId;
		}
		public void setTemplateId(int templateId) {
			this.templateId = templateId;
		}
		public int getNum() {
			return num;
		}
		public void setNum(int num) {
			this.num = num;
		}
	}
}
