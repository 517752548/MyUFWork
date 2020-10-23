package com.imop.lj.gm.config;

import java.net.URL;
import java.util.ArrayList;
import java.util.List;

/**
 * GM 常量配置
 *
 *
 */
public class GmConfig extends ConfigSupport {
	
	private static  GmConfig _gmConfig;

	/** 打签奖励的有效天数 */
	public  int validDays;

	/** GM补偿和礼包奖励金钱数量上限 */
	public int goldNum;
	
	/**内币*/
	public  int sysBond;
	
	/**礼券*/
	public  int giftBond = 10000;

	/** GM补偿和礼包奖励货币数量上限 */
	public  int currencyNum;

	/** GM补偿和礼包奖励物品数量上限 */
	public  int itemNum;

	/** GM补偿 声望上限 */
	public  int honorNum;

	/** GM补偿  体力上限 */
	public int powerNum;

	/** GM补偿  商魂碎片上限 */
	public int huntSuipianNum;

	/** GM补偿  原石上限 */
	public  int jewelryStoneNum;

	/** GM礼包奖励下限 */
	public  int prizeID;

	/** 公告最大长度字符个数限制 */
	public  int noticeLen;


	/**是否是调试模式，只有在开发阶段使用此模式*/
	public int isDebugMode;

	/**奖励有效期*/
	public  int prizeValidPeriod = 2 * 7 * 24 * 60 * 60 * 1000;
	/**
	 * resources 目录所在的实际地址
	 */
	public String baseResourceDir="";

	/**
	 * scripts 目录名称
	 */
	public  String scriptDir="";

	public  String gmDbName ="";
	
	public  String localKey="";

	public  int itemSheetNum = 5;
	
	/**
	 * 奖励数限制
	 */
	public  int prizeNum = 20;
	/**
	 * 奖励原因编号基底
	 */ 
	public  int resaonNum = 10000;
	/***
	 * 活动奖励批量存储 一次存储数
	 */
	public  int saveOnceNum = 500;
	
	/**
	 * 记录上次心跳检测执行时间
	 */
	public  int heartTimeSleepSendMessage = 5*60*1000;
	/**
	 * 发奖结算开始时间 3:00
	 */
	public  int givePrizeStartTime = 3*60*60*1000;
	/***
	 * 发奖结算开始时间 4:00
	 */
	public  int givePrizeEndTime = 4*60*60*1000;
	/***
	 * 发奖物品礼包解包数
	 */
	public  int prizeItemPackNum = 10;
	
	/***
	 * 延迟心跳时间 初始化 1分钟
	 */
	public  int sleepTimeStart = 1000;
	
	/**心跳间隔,单位为毫秒 */
	public  int heartTimeSleep = 1000;
	
	public  String worldserverid;
	
	
	public List<Integer> worldServerIdList = new ArrayList<Integer>();
	
	private static final GmConfig GmConfigInstance = new GmConfig();
	
	public static GmConfig GetInstance(){
		if (_gmConfig==null){
			_gmConfig = new GmConfig();
		}
		return _gmConfig;
	}
	
	private GmConfig() {
		
		ClassLoader _classLoader = Thread.currentThread()
				.getContextClassLoader();
		URL _url = _classLoader.getResource("gm.cfg.js");
		ConfigUtil.buildConfig(this, _url);
	}
	
	/***
	 * 获得   GM 常量配置 单例类
	 * @return
	 */
	public static GmConfig getGmConfigInstance(){
		return GmConfigInstance;
	}

	/***
	 * 获得 world 服 id
	 * @return
	 */
	public List<Integer> getWorldServerIdList(){
		return worldServerIdList;
	}

	@Override
	public void validate() {
		System.out.println("baseResourceDir"+baseResourceDir+"currencyNum"+currencyNum);
//		if (goldNum < 0) {
//			throw new ConfigException("The goldNum isn't correct!");
//		}
//		if (currencyNum < 0) {
//			throw new ConfigException("The currencyNum isn't correct!");
//		}
//		if (itemNum < 0) {
//			throw new ConfigException("The itemNum isn't correct!");
//		}
//		if (honorNum < 0) {
//			throw new ConfigException("The honorNum isn't correct!");
//		}
//		if (powerNum < 0) {
//			throw new ConfigException("The powerNum isn't correct!");
//		}
//		if (huntSuipianNum < 0) {
//			throw new ConfigException("The huntSuipianNum isn't correct!");
//		}
//		if (jewelryStoneNum < 0) {
//			throw new ConfigException("The jewelryStoneNum isn't correct!");
//		}
//		if (prizeID < 0) {
//			throw new ConfigException("The prizeID isn't correct!");
//		}
//		if (noticeLen < 0) {
//			throw new ConfigException("The noticeLen isn't correct!");
//		}
//		if(isDebugMode != 0 && isDebugMode != 1){
//			throw new ConfigException("The debug isn't correct!");
//		}
//		if(baseResourceDir == null || baseResourceDir.trim().equals("")){
//			throw new ConfigException("The baseResourceDir isn't correct!");
//		}
//		if(scriptDir == null || scriptDir.trim().equals("")){
//			throw new ConfigException("The scriptDir isn't correct!");
//		}
//		if(gmDbName == null || gmDbName.trim().equals("")){
//			throw new ConfigException("The gmDbName isn't correct!");
//		}
	}

	@Override
	public boolean isDebug() {
		return isDebugMode==1;
	}

}
