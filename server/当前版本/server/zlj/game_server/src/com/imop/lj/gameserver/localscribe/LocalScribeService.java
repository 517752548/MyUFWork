package com.imop.lj.gameserver.localscribe;

import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

import org.slf4j.Logger;

import com.imop.lj.common.LogReasons.ChatLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.LoginLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.LogReasons.ReasonDesc;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.LoginTypeEnum;
import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.template.ItemTemplate;
import com.imop.lj.gameserver.localscribe.LocalScribeDef.ScribeItemType;
import com.imop.lj.gameserver.localscribe.reporter.ScribeGameLoginOrOutReport;
import com.imop.lj.gameserver.localscribe.reporter.ScribeGameOnlineReport;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.charge.async.ChargeOrderInfo;
import com.imop.platform.collector.config.DataReportConfig;
import com.imop.platform.collector.config.GameServerConfig;
import com.imop.platform.collector.data.ScribeDataReportManager;
import com.imop.platform.collector.data.enums.Platform;
import com.imop.platform.collector.reporter.data.AbstractDataReport;
import com.imop.platform.collector.reporter.data.ScribeChatDataReport;
import com.imop.platform.collector.reporter.data.ScribeGameGoldRemainReport;
import com.imop.platform.collector.reporter.data.ScribeGameIncomeReport;
import com.imop.platform.collector.reporter.data.ScribeGamePropBuyReport;
import com.imop.platform.collector.reporter.data.ScribeGamePropConsumeReport;

/**
 * 汇报scribe日志
 * 
 * @author yuanbo.gao
 *
 */
public class LocalScribeService {
	
	public static final Logger CHARGE_LOGGER = Loggers.chargeLogger;

	protected ScribeDataReportManager reportManager;
	
	protected final ExecutorService reportExecutor;
	
	public LocalScribeService() {
		GameServerConfig serverConfig = new GameServerConfig(
				Platform.RENREN_COM.name, 
				Globals.getServerConfig().getGameId(), 
				Globals.getServerConfig().getRegionId(), 
				Globals.getServerConfig().getServerId(), 
				Globals.getServerConfig().getServerName(), 
				Globals.getServerConfig().getServerDomain());
		
		DataReportConfig reportConfig = new DataReportConfig(Globals.getServerConfig().getScribeServerIp(),1463,1000);
		reportConfig.setDebugEnabled(true);
		reportManager = new ScribeDataReportManager(reportConfig, serverConfig);
		
		reportExecutor = Executors.newSingleThreadExecutor();
	}
	
	public void start(){
		reportManager.start();
	}
	
	/**
	 * 异步加汇报数据
	 * @param reportData
	 */
	public void addReportData(final AbstractDataReport report) {
		//TODO FIXME 暂时不汇报了
//		reportExecutor.submit(new Runnable() {
//			@Override
//			public void run() {
//				reportManager.addToReport(report);
//			}
//		});
	}
	
	
//	/**
//	 * 冲入记录，qq
//	 * @param human Human
//	 * @param reason MoneyLogReason
//	 * @param chargeType 充值方式
//	 * @param charge_amount 充入钱数、
//	 * @param gold_get 获得元宝数
//	 * @param gold_current 充值完毕元宝数
//	 */
//	public void sendScribeGameIncomeReportForQQ(Human human,MoneyLogReason reason,QQChargeOrderInfo orderInfo){
//		if(!Globals.getServerConfig().isScribeOnTurn()){
//			CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGameIncomeReport: is return;");
//			return;
//		}
//		
//		//用户实际IP地址
//		String log_ip = human.getPlayer().getClientIp();
//		// 去掉端口号
//		if(log_ip.indexOf(":") != -1){
//			log_ip = log_ip.substring(0,log_ip.indexOf(":"));
//		}
//		
//		//账号ID
//		String account_id	= human.getPlayer().getPassportId() + "";
//		
//		//账号名（登录名）
//		String account_name	= human.getPlayer().getPassportName();
//		
//		//角色ID
//		String char_id = human.getCharId() + "";
//		
//		//角色名
//		String char_name = human.getName();
//		
//		//角色等级（用户的核心评价数据，如无等级的游戏可以使用主城的等级、人口、声望等），默认设置为-1
//		long charLevel = human.getLevel();
//		
//		//VIP等级。默认为-1
//		int charVip = human.getVipLevel();
//		
//		//终端设备分类：PC，IOS，Android
//		String device = human.getCurrTerminalType().getTerminalTypeName();
//
//		//设备型号，如ipad、HTC Desire等，PC类型此项设置为-1
//		String device_type = human.getPlayer().getDeviceType();
//		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
//			device_type = -1 + "";
//		}
//		
//		//操作系统版本，IOS和Android的版本，PC类型此项设置为-1
//		String device_version = human.getPlayer().getDeviceVersion();
//		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
//			device_version = -1 + "";
//		}
//		
//		//设备唯一识别id
//		String guid	= human.getPlayer().getDeviceID();
//		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
//			guid = -1 + "";
//		}
//		
//		String reasonName = "";
//		//XXX 修改平台数据汇报从reasonText修改成reasonDesc，yuanbo.gao修改
//		try{
//			ReasonDesc _reasonDesc = reason.getClass().getField(reason.name()).getAnnotation(ReasonDesc.class);
//			if(_reasonDesc != null){
//				reasonName = _reasonDesc.value();
//			}else{
//				CHARGE_LOGGER.error("");
//				reasonName = reason.getReasonText();
//			}
//		}catch(Exception e){
//			e.printStackTrace();
//			reasonName = reason.getReasonText();
//		}
//		
//		
//		ScribeGameIncomeReport report = new ScribeGameIncomeReport(
//				log_ip,							//clientIp
//				account_id,						//accountID
//				account_name,					// accountName
//				char_id,						// charId 
//				char_name,						//charName
//				charLevel,						//charLevel
//				charVip,						//charVip
//				device, 						//device
//				device_type,					//deviceType
//				device_version,					//deviceVersion
//				guid,							//deviceGUID
//				reason.getReason(),				// reasonId
//				reasonName,						// reasonName
//				"expend", //getChargeType
//				orderInfo.getBillno(), 
//				orderInfo.getAmtToRMB(), 
//				orderInfo.getAddBond(),
//				orderInfo.getBondAfter(), 
//				orderInfo.getChannel(), 
//				"",//getSub_channel
//				"CNY");
////		orderInfo.getChargeType(), 
////		orderInfo.getOrderId(), 
////		orderInfo.getAmount(), 
////		orderInfo.getAddBond(),
////		orderInfo.getBondAfter(), 
////		orderInfo.getChannel(), 
////		orderInfo.getSub_channel(),
////		orderInfo.getCurrency());
//
//		addReportData(report);
//		
//		CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGameIncomeReport:" + 
//				"clientIp=" + log_ip+";" + 						//clientIp
//				"accountID=" + account_id+";" + 				//accountID
//				"accountName=" + account_name+";" + 			// accountName
//				"charId=" + char_id+";" + 						// charId 
//				"charName=" + char_name+";" + 					//charName
//				"charLevel=" + charLevel+";" + 					//charLevel
//				"charVip=" + charVip+";" + 						//charVip
//				"device=" + device+";" +  						//device
//				"deviceType=" + device_type+";" + 				//deviceType
//				"deviceVersion=" + device_version+";" +  		//deviceVersion
//				"deviceGUID=" + guid+";" +  					//deviceGUID
//				"orderInfo=" + orderInfo+";"					//orderInfo
//				);
//	}
	
	/**
	 * 冲入记录，平台
	 * @param human Human
	 * @param reason MoneyLogReason
	 * @param chargeType 充值方式
	 * @param charge_amount 充入钱数、
	 * @param gold_get 获得元宝数
	 * @param gold_current 充值完毕元宝数
	 */
	public void sendScribeGameIncomeReport(Human human,MoneyLogReason reason,ChargeOrderInfo orderInfo){
		if(!Globals.getServerConfig().isScribeOnTurn()){
			CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGameIncomeReport: is return;");
			return;
		}
		
		//用户实际IP地址
		String log_ip = human.getPlayer().getClientIp();
		// 去掉端口号
		if(log_ip.indexOf(":") != -1){
			log_ip = log_ip.substring(0,log_ip.indexOf(":"));
		}
		
		//账号ID
		String account_id	= human.getPlayer().getPassportId() + "";
		
		//账号名（登录名）
		String account_name	= human.getPlayer().getPassportName();
		
		//角色ID
		String char_id = human.getCharId() + "";
		
		//角色名
		String char_name = human.getName();
		
		//角色等级（用户的核心评价数据，如无等级的游戏可以使用主城的等级、人口、声望等），默认设置为-1
		long charLevel = human.getLevel();
		
		//VIP等级。默认为-1
		int charVip = human.getVipLevel();
		
		//终端设备分类：PC，IOS，Android
		String device = human.getCurrTerminalType().getTerminalTypeName();

		//设备型号，如ipad、HTC Desire等，PC类型此项设置为-1
		String device_type = human.getPlayer().getDeviceType();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			device_type = -1 + "";
		}
		
		//操作系统版本，IOS和Android的版本，PC类型此项设置为-1
		String device_version = human.getPlayer().getDeviceVersion();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			device_version = -1 + "";
		}
		
		//设备唯一识别id
		String guid	= human.getPlayer().getDeviceID();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			guid = -1 + "";
		}
		
		String reasonName = "";
		//XXX 修改平台数据汇报从reasonText修改成reasonDesc，yuanbo.gao修改
		try{
			ReasonDesc _reasonDesc = reason.getClass().getField(reason.name()).getAnnotation(ReasonDesc.class);
			if(_reasonDesc != null){
				reasonName = _reasonDesc.value();
			}else{
				CHARGE_LOGGER.error("");
				reasonName = reason.getReasonText();
			}
		}catch(Exception e){
			e.printStackTrace();
			reasonName = reason.getReasonText();
		}
		
		
		ScribeGameIncomeReport report = new ScribeGameIncomeReport(
				log_ip,							//clientIp
				account_id,						//accountID
				account_name,					// accountName
				char_id,						// charId 
				char_name,						//charName
				charLevel,						//charLevel
				charVip,						//charVip
				device, 						//device
				device_type,					//deviceType
				device_version,					//deviceVersion
				guid,							//deviceGUID
				reason.getReason(),				// reasonId
				reasonName,						// reasonName
				orderInfo.getChargeType(), 
				orderInfo.getOrderId(), 
				orderInfo.getAmount(), 
				orderInfo.getAddBond(),
				orderInfo.getBondAfter(), 
				orderInfo.getChannel(), 
				orderInfo.getSub_channel(),
				orderInfo.getCurrency());

		addReportData(report);
		
		CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGameIncomeReport:" + 
				"clientIp=" + log_ip+";" + 						//clientIp
				"accountID=" + account_id+";" + 				//accountID
				"accountName=" + account_name+";" + 			// accountName
				"charId=" + char_id+";" + 						// charId 
				"charName=" + char_name+";" + 					//charName
				"charLevel=" + charLevel+";" + 					//charLevel
				"charVip=" + charVip+";" + 						//charVip
				"device=" + device+";" +  						//device
				"deviceType=" + device_type+";" + 				//deviceType
				"deviceVersion=" + device_version+";" +  		//deviceVersion
				"deviceGUID=" + guid+";" +  					//deviceGUID
				"orderInfo=" + orderInfo+";"					//orderInfo
				);
	}
	
	/**
	 * 购买服务log 
	 * @param human Human
	 * @param reason MoneyLogReason
	 * @param price 服务单价
	 * @param goldActual 实际花费
	 * @param goldLeft 剩余
	 */
	public void sendScribeGamePropBuyServiceReport(Human human,ScribeItemType scribeItemType,MoneyLogReason reason,String detailReason1,long price,long goldActual,long goldLeft){
		if(!Globals.getServerConfig().isScribeOnTurn()){
			CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGamePropBuyServiceReport: is return;");
			return;
		}
		//用户实际IP地址
		String log_ip = human.getPlayer().getClientIp();
		// 去掉端口号
		if(log_ip.indexOf(":") != -1){
			log_ip = log_ip.substring(0,log_ip.indexOf(":"));
		}
		//账号ID
		String account_id	= human.getPlayer().getPassportId() + "";
		
		//账号名（登录名）
		String account_name	= human.getPlayer().getPassportName();
		
		//角色ID
		String char_id = human.getCharId() + "";
		
		//角色名
		String char_name = human.getName();
		
		//角色等级（用户的核心评价数据，如无等级的游戏可以使用主城的等级、人口、声望等），默认设置为-1
		long charLevel = human.getLevel();
		
		//VIP等级。默认为-1
		int charVip = human.getVipLevel();
		
		//终端设备分类：PC，IOS，Android
		String device = human.getCurrTerminalType().getTerminalTypeName();

		//设备型号，如ipad、HTC Desire等，PC类型此项设置为-1
		String device_type = human.getPlayer().getDeviceType();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			device_type = -1 + "";
		}
		
		//操作系统版本，IOS和Android的版本，PC类型此项设置为-1
		String device_version = human.getPlayer().getDeviceVersion();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			device_version = -1 + "";
		}
		
		//设备唯一识别id
		String guid	= human.getPlayer().getDeviceID();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			guid = -1 + "";
		}
		
		String reasonName = "";
		//XXX 修改平台数据汇报从reasonText修改成reasonDesc，yuanbo.gao修改
		try{
			ReasonDesc _reasonDesc = reason.getClass().getField(reason.name()).getAnnotation(ReasonDesc.class);
			if(_reasonDesc != null){
				reasonName = _reasonDesc.value();
			}else{
				CHARGE_LOGGER.error(reason + " ReasonDesc 为空");
				reasonName = detailReason1;
			}
		}catch(Exception e){
			e.printStackTrace();
			reasonName = detailReason1;
		}
		
		int goodsAliveDays = 0;
		if (scribeItemType == ScribeItemType.ETERNAL) {
			goodsAliveDays = -1;
		}
		
		ScribeGamePropBuyReport report = new ScribeGamePropBuyReport(
				log_ip,							//clientIp
				account_id,						//accountID
				account_name,					// accountName
				char_id,						// charId 
				char_name,						//charName
				charLevel,						//charLevel
				charVip,						//charVip
				device, 						//device
				device_type,					//deviceType
				device_version,					//deviceVersion
				guid,							//deviceGUID
				reason.getReason(),				// reasonId
				reasonName,						// reasonName
				"",								// itemId
				"",								// itemName
				scribeItemType.getParam(),	// itemType
				reason.getReason() + "",		// propId
				reasonName,						// propName
				1,								// quantity
				price,							// price
				goldActual,						// goldActual
				price,							// goldPaid
				goldLeft,						// goldLeft
				goodsAliveDays					//goodsAliveDays
		);
//		reportManager.addToReport(report);
		addReportData(report);
		
		
		CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGamePropBuyServiceReport:" + 
				"clientIp=" + log_ip+";" + 						//clientIp
				"accountID=" + account_id+";" + 				//accountID
				"accountName=" + account_name+";" + 			// accountName
				"charId=" + char_id+";" + 						// charId 
				"charName=" + char_name+";" + 					//charName
				"charLevel=" + charLevel+";" + 					//charLevel
				"charVip=" + charVip+";" + 						//charVip
				"device=" + device+";" +  						//device
				"deviceType=" + device_type+";" + 				//deviceType
				"deviceVersion=" + device_version+";" +  		//deviceVersion
				"deviceGUID=" + guid+";" +  					//deviceGUID
				"reasonId=" + reason.getReason()+";" + 			// reasonId
				"reasonName=" + reasonName+";" +  				// reasonName
				"itemId=" + ""+";" +							// itemId
				"itemName=" + ""+";" +								// itemName
				"itemType=" + scribeItemType.getParam()+";" +	// itemType
				"propId=" + reason.getReason() + ""+";" +		// propId
				"propName=" + reasonName+";" +					// propName
				"quantity=" + 1+";" +								// quantity
				"price=" + price+";" +							// price
				"goldActual=" + goldActual+";" +						// goldActual
				"goldPaid=" + price+";" +							// goldPaid
				"goldLeft=" + goldLeft+";"						// goldLeft
				);
	}
	
	
	
	/**
	 * 购买物品服务log 
	 * @param human Human
	 * @param reason MoneyLogReason
	 * @param itemTemplateId 物品模板文件
	 * @param quantity 物品数量
	 * @param totalCost 物品总价
	 * @param actualCost 物品实际单价
	 * @param goldLeft 剩余
	 */
	public void sendScribeGamePropBuyItemServiceReport(Human human,MoneyLogReason reason,int itemTemplateId,int quantity,long totalCost,long actualCost,long goldLeft){
		if(!Globals.getServerConfig().isScribeOnTurn()){
			CHARGE_LOGGER.warn("#GS.LocalScribeService.sendScribeGamePropBuyServiceReport: is return;");
			return;
		}
		
		if(human == null){
			CHARGE_LOGGER.warn("#GS.LocalScribeService.human: is null;");
			return;
		}
		
		//角色ID
		String char_id = human.getCharId() + "";
		
		//角色名
		String char_name = human.getName();
		
		ItemTemplate itemTemplate = Globals.getTemplateCacheService().get(itemTemplateId, ItemTemplate.class);
		if(itemTemplate == null || reason == null || quantity <= 0 || totalCost <= 0 || actualCost <= 0){
			CHARGE_LOGGER.warn("#GS.LocalScribeService.data is error: "
					+ "templateId=" + itemTemplateId + ";" 
					+ "charId=" + char_id+";" 
					+ "reason=" + reason+";" 
					+ "charName=" + char_name+";" 
					+ "quantity=" + quantity+";"
					+ "goldActual=" + actualCost+";"
					+ "goldPaid=" + totalCost+";");
			return;
		}
		
		String detailReason1 = reason.getReasonText();
		
		//用户实际IP地址
		String log_ip = human.getPlayer().getClientIp();
		// 去掉端口号
		if(log_ip.indexOf(":") != -1){
			log_ip = log_ip.substring(0,log_ip.indexOf(":"));
		}
		//账号ID
		String account_id	= human.getPlayer().getPassportId() + "";
		
		//账号名（登录名）
		String account_name	= human.getPlayer().getPassportName();
		
		//角色等级（用户的核心评价数据，如无等级的游戏可以使用主城的等级、人口、声望等），默认设置为-1
		long charLevel = human.getLevel();
		
		//VIP等级。默认为-1
		int charVip = human.getVipLevel();
		
		//终端设备分类：PC，IOS，Android
		String device = human.getCurrTerminalType().getTerminalTypeName();

		//设备型号，如ipad、HTC Desire等，PC类型此项设置为-1
		String device_type = human.getPlayer().getDeviceType();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			device_type = -1 + "";
		}
		
		//操作系统版本，IOS和Android的版本，PC类型此项设置为-1
		String device_version = human.getPlayer().getDeviceVersion();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			device_version = -1 + "";
		}
		
		//设备唯一识别id
		String guid	= human.getPlayer().getDeviceID();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			guid = -1 + "";
		}
		
		String reasonName = "";
		//XXX 修改平台数据汇报从reasonText修改成reasonDesc，yuanbo.gao修改
		try{
			ReasonDesc _reasonDesc = reason.getClass().getField(reason.name()).getAnnotation(ReasonDesc.class);
			if(_reasonDesc != null){
				reasonName = _reasonDesc.value();
			}else{
				CHARGE_LOGGER.error(reason + " ReasonDesc 为空");
				reasonName = detailReason1;
			}
		}catch(Exception e){
			e.printStackTrace();
			reasonName = detailReason1;
		}
		
		ScribeGamePropBuyReport report = new ScribeGamePropBuyReport(
				log_ip,							//clientIp
				account_id,						//accountID
				account_name,					// accountName
				char_id,						// charId 
				char_name,						//charName
				charLevel,						//charLevel
				charVip,						//charVip
				device, 						//device
				device_type,					//deviceType
				device_version,					//deviceVersion
				guid,							//deviceGUID
				reason.getReason(),				// reasonId
				reasonName,						// reasonName
				itemTemplateId + "",			// itemId
				itemTemplate.getName(),						// itemName
				ScribeItemType.PROP.getParam(),	// itemType
				itemTemplateId + "",			// propId
				itemTemplate.getName(),						// propName
				quantity,						// quantity
				(long)Math.ceil(1.0f * totalCost / quantity),					// price
				actualCost,						// goldActual
				totalCost,						// goldPaid
				goldLeft,						// goldLeft
				0								//goodsAliveDays
		);
//		reportManager.addToReport(report);
		addReportData(report);
		
		
		CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGamePropBuyServiceReport:" + 
				"clientIp=" + log_ip+";" + 						//clientIp
				"accountID=" + account_id+";" + 				//accountID
				"accountName=" + account_name+";" + 			// accountName
				"charId=" + char_id+";" + 						// charId 
				"charName=" + char_name+";" + 					//charName
				"charLevel=" + charLevel+";" + 					//charLevel
				"charVip=" + charVip+";" + 						//charVip
				"device=" + device+";" +  						//device
				"deviceType=" + device_type+";" + 				//deviceType
				"deviceVersion=" + device_version+";" +  		//deviceVersion
				"deviceGUID=" + guid+";" +  					//deviceGUID
				"reasonId=" + reason.getReason()+";" + 			// reasonId
				"reasonName=" + reasonName+";" +  				// reasonName
				"itemId=" + itemTemplateId+";" +							// itemId
				"itemName=" + itemTemplate.getName()+";" +								// itemName
				"itemType=" + ScribeItemType.PROP.getParam()+";" +	// itemType
				"propId=" + itemTemplateId + ""+";" +		// propId
				"propName=" + itemTemplate.getName()+";" +					// propName
				"quantity=" + quantity+";" +								// quantity
				"price=" + (long)Math.ceil(1.0f * totalCost / quantity)+";" +							// price
				"goldActual=" + actualCost+";" +						// goldActual
				"goldPaid=" + totalCost+";" +							// goldPaid
				"goldLeft=" + goldLeft+";"						// goldLeft
				);
	}
	
	/*
	 * 聊天记录
	 * param human Human
	 * @param reason ChatLogReason
	 * @param detailReason 详细原因
	 * @param filterType 0普通信息,1过滤信息
	 * @param param 扩展参数
	 * @param chatType 聊天类型(聊天频道 私聊,国家,地区,战役)
	 * @param receiveId 接受者id
	 * @param chatContent 聊天内容
	 */
	public void sendScribeGamePropChatReport(Human human,ChatLogReason reason,String detailReason1,int filterType,String param,
			int chatType,long receiveId,String chatContent){
		if(!Globals.getServerConfig().isScribeOnTurn()){
			CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGamePropChatReport: is return;");
			return;
		}
		
		//用户实际IP地址       String 
		String log_ip = human.getPlayer().getClientIp();
		// 去掉端口号
		if(log_ip.indexOf(":") != -1){
			log_ip = log_ip.substring(0,log_ip.indexOf(":"));
		}
		//账号ID
		String account_id	= human.getPlayer().getPassportId() + "";
		
		//账号名（登录名）
		String account_name	= human.getPlayer().getPassportName();
		
		//角色ID
		String char_id = human.getCharId() + "";
		
		//角色名
		String char_name = human.getName();
		
		//角色等级（用户的核心评价数据，如无等级的游戏可以使用主城的等级、人口、声望等），默认设置为-1
		int charLevel = human.getLevel();
		
		//VIP等级。默认为-1
//		int charVip = human.getVipLevel();

		//设备型号，如ipad、HTC Desire等，PC类型此项设置为-1
		String device_type = human.getPlayer().getDeviceType();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			device_type = -1 + "";
		}

		AbstractDataReport chatReport = new ScribeChatDataReport(
				chatContent,					// chatContent
				account_id,						//accountID
				account_name,					// accountName
				char_id,						// charId 
				char_name,						//charName
				charLevel,						//charLevel
				"",								// job
				"",								// map
				0,								// mapX
				0,								// mapY
				device_type,					//terminal
				reason.getReason(),				// reasonId
				param,							// param
				chatType+"",						//scope
				receiveId+""						//recId
			);
		addReportData(chatReport);
	}
	
	/**
	 * 消耗服务
	 * @param human Human
	 * @param reason MoneyLogReason
	 * @param price 服务单价
	 * @param goldActual 实际花费
	 */
	public void sendScribeGamePropConsumeServiceReport(Human human,ScribeItemType scribeItemType,MoneyLogReason reason,String detailReason1,long price,long goldActual){
		if(!Globals.getServerConfig().isScribeOnTurn()){
			CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGamePropConsumeServiceReport: is return;");
			return;
		}
		//用户实际IP地址
		String log_ip = human.getPlayer().getClientIp();
		// 去掉端口号
		if(log_ip.indexOf(":") != -1){
			log_ip = log_ip.substring(0,log_ip.indexOf(":"));
		}
		//账号ID
		String account_id	= human.getPlayer().getPassportId() + "";
		
		//账号名（登录名）
		String account_name	= human.getPlayer().getPassportName();
		
		//角色ID
		String char_id = human.getCharId() + "";
		
		//角色名
		String char_name = human.getName();
		
		//角色等级（用户的核心评价数据，如无等级的游戏可以使用主城的等级、人口、声望等），默认设置为-1
		long charLevel = human.getLevel();
		
		//VIP等级。默认为-1
		int charVip = human.getVipLevel();
		
		//终端设备分类：PC，IOS，Android
		String device = human.getCurrTerminalType().getTerminalTypeName();

		//设备型号，如ipad、HTC Desire等，PC类型此项设置为-1
		String device_type = human.getPlayer().getDeviceType();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			device_type = -1 + "";
		}
		
		//操作系统版本，IOS和Android的版本，PC类型此项设置为-1
		String device_version = human.getPlayer().getDeviceVersion();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			device_version = -1 + "";
		}
		
		//设备唯一识别id
		String guid	= human.getPlayer().getDeviceID();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			guid = -1 + "";
		}
		
		String reasonName = "";
		//XXX 修改平台数据汇报从reasonText修改成reasonDesc，yuanbo.gao修改
		try{
			ReasonDesc _reasonDesc = reason.getClass().getField(reason.name()).getAnnotation(ReasonDesc.class);
			if(_reasonDesc != null){
				reasonName = _reasonDesc.value();
			}else{
				CHARGE_LOGGER.error(reason + " ReasonDesc 为空");
				reasonName = detailReason1;
			}
		}catch(Exception e){
			e.printStackTrace();
			reasonName = detailReason1;
		}
		
		int goodsAliveDays = 0;
		if (scribeItemType == ScribeItemType.ETERNAL) {
			goodsAliveDays = -1;
		}
		
		ScribeGamePropConsumeReport report = new ScribeGamePropConsumeReport(
				log_ip,							//clientIp
				account_id,						//accountID
				account_name,					// accountName
				char_id,						// charId 
				char_name,						//charName
				charLevel,						//charLevel
				charVip,						//charVip
				device, 						//device
				device_type,					//deviceType
				device_version,					//deviceVersion
				guid,							//deviceGUID
				reason.getReason(),				// reasonId
				reasonName,						// reasonName
				"",								// itemId
				"",								// itemName
				scribeItemType.getParam(),	// itemType
				reason.getReason() + "",		// propId
				reasonName,						// propName
				1,								// quantity
				price,							// price
				goldActual,						// goldActual
				price,							// goldPaid
				goodsAliveDays								//goodsAliveDays
		);
//		reportManager.addToReport(report);
		addReportData(report);
		
		CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGamePropConsumeServiceReport:" + 
				"clientIp=" + log_ip+";" + 						//clientIp
				"accountID=" + account_id+";" + 				//accountID
				"accountName=" + account_name+";" + 			// accountName
				"charId=" + char_id+";" + 						// charId 
				"charName=" + char_name+";" + 					//charName
				"charLevel=" + charLevel+";" + 					//charLevel
				"charVip=" + charVip+";" + 						//charVip
				"device=" + device+";" +  						//device
				"deviceType=" + device_type+";" + 				//deviceType
				"deviceVersion=" + device_version+";" +  		//deviceVersion
				"deviceGUID=" + guid+";" +  					//deviceGUID
				"reasonId=" + reason.getReason()+";" + 			// reasonId
				"reasonName=" + reasonName+";" +  	// reasonName
				"itemId=" + ""+";" +							// itemId
				"itemName=" + ""+";" +								// itemName
				"itemType=" + ScribeItemType.SERVICE.getParam()+";" +	// itemType
				"propId=" + reason.getReason() + ""+";" +		// propId
				"propName=" + reasonName+";" +					// propName
				"quantity=" + 1+";" +								// quantity
				"price=" + price+";" +							// price
				"goldActual=" + goldActual+";" +						// goldActual
				"goldPaid=" + price+";"						// goldPaid
				);
	}
	
	
	/**
	 * 消耗物品服务
	 * @param human Human
	 * @param reason MoneyLogReason
	 * @param price 服务单价
	 * @param goldActual 实际花费
	 */
	public void sendScribeGamePropConsumeItemServiceReport(Human human,ItemLogReason reason,int itemTemplateId,int quantity,long totalCost,long actualCost){
		if(!Globals.getServerConfig().isScribeOnTurn()){
			CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGamePropConsumeServiceReport: is return;");
			return;
		}
		
		if(human == null){
			CHARGE_LOGGER.warn("#GS.LocalScribeService.human: is null;");
			return;
		}
		
		//角色ID
		String char_id = human.getCharId() + "";
		
		//角色名
		String char_name = human.getName();
		
		ItemTemplate itemTemplate = Globals.getTemplateCacheService().get(itemTemplateId, ItemTemplate.class);
		if(itemTemplate == null || reason == null || quantity <= 0 || totalCost <= 0 || actualCost <= 0){
			CHARGE_LOGGER.warn("#GS.LocalScribeService.data is error: "
					+ "templateId=" + itemTemplateId + ";" 
					+ "charId=" + char_id+";" 
					+ "reason=" + reason+";" 
					+ "charName=" + char_name+";" 
					+ "quantity=" + quantity+";"
					+ "goldActual=" + actualCost+";"
					+ "goldPaid=" + totalCost+";");
			return;
		}
		String detailReason1 = reason.getReasonText();
		
		//用户实际IP地址
		String log_ip = human.getPlayer().getClientIp();
		// 去掉端口号
		if(log_ip.indexOf(":") != -1){
			log_ip = log_ip.substring(0,log_ip.indexOf(":"));
		}
		//账号ID
		String account_id	= human.getPlayer().getPassportId() + "";
		
		//账号名（登录名）
		String account_name	= human.getPlayer().getPassportName();
		
		//角色等级（用户的核心评价数据，如无等级的游戏可以使用主城的等级、人口、声望等），默认设置为-1
		long charLevel = human.getLevel();
		
		//VIP等级。默认为-1
		int charVip = human.getVipLevel();
		
		//终端设备分类：PC，IOS，Android
		String device = human.getCurrTerminalType().getTerminalTypeName();

		//设备型号，如ipad、HTC Desire等，PC类型此项设置为-1
		String device_type = human.getPlayer().getDeviceType();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			device_type = -1 + "";
		}
		
		//操作系统版本，IOS和Android的版本，PC类型此项设置为-1
		String device_version = human.getPlayer().getDeviceVersion();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			device_version = -1 + "";
		}
		
		//设备唯一识别id
		String guid	= human.getPlayer().getDeviceID();
		if(human.getCurrTerminalType() == TerminalTypeEnum.WEB){
			guid = -1 + "";
		}
		
		String reasonName = "";
		//XXX 修改平台数据汇报从reasonText修改成reasonDesc，yuanbo.gao修改
		try{
			ReasonDesc _reasonDesc = reason.getClass().getField(reason.name()).getAnnotation(ReasonDesc.class);
			if(_reasonDesc != null){
				reasonName = _reasonDesc.value();
			}else{
				CHARGE_LOGGER.error(reason + " ReasonDesc 为空");
				reasonName = detailReason1;
			}
		}catch(Exception e){
			e.printStackTrace();
			reasonName = detailReason1;
		}
		
		ScribeGamePropConsumeReport report = new ScribeGamePropConsumeReport(
				log_ip,							//clientIp
				account_id,						//accountID
				account_name,					// accountName
				char_id,						// charId 
				char_name,						//charName
				charLevel,						//charLevel
				charVip,						//charVip
				device, 						//device
				device_type,					//deviceType
				device_version,					//deviceVersion
				guid,							//deviceGUID
				reason.getReason(),				// reasonId
				reasonName,						// reasonName
				itemTemplateId + "",								// itemId
				itemTemplate.getName(),								// itemName
				ScribeItemType.PROP.getParam(),	// itemType
				itemTemplateId + "",		// propId
				itemTemplate.getName(),						// propName
				quantity,								// quantity
				(long)Math.ceil(1.0f * totalCost / quantity),							// price
				actualCost,						// goldActual
				totalCost,							// goldPaid
				0								//goodsAliveDays
		);
//		reportManager.addToReport(report);
		addReportData(report);
		
		CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGamePropConsumeServiceReport:" + 
				"clientIp=" + log_ip+";" + 						//clientIp
				"accountID=" + account_id+";" + 				//accountID
				"accountName=" + account_name+";" + 			// accountName
				"charId=" + char_id+";" + 						// charId 
				"charName=" + char_name+";" + 					//charName
				"charLevel=" + charLevel+";" + 					//charLevel
				"charVip=" + charVip+";" + 						//charVip
				"device=" + device+";" +  						//device
				"deviceType=" + device_type+";" + 				//deviceType
				"deviceVersion=" + device_version+";" +  		//deviceVersion
				"deviceGUID=" + guid+";" +  					//deviceGUID
				"reasonId=" + reason.getReason()+";" + 			// reasonId
				"reasonName=" + reasonName+";" +  	// reasonName
				"itemId=" + itemTemplateId+";" +							// itemId
				"itemName=" + itemTemplate.getName()+";" +								// itemName
				"itemType=" + ScribeItemType.SERVICE.getParam()+";" +	// itemType
				"propId=" + itemTemplateId + ""+";" +		// propId
				"propName=" + itemTemplate.getName()+";" +					// propName
				"quantity=" + quantity+";" +								// quantity
				"price=" + (long)Math.ceil(1.0f * totalCost / quantity)+";" +							// price
				"goldActual=" + actualCost+";" +						// goldActual
				"goldPaid=" + totalCost+";"						// goldPaid
				);
	}
	
	/**
	 * 登陆情况汇报
	 * 
	 * @param human
	 * @param loginLogReason
	 * @param loginLogReasonText
	 */
	public void sendScribeGameLoginOrOutReport(Human human, LoginLogReason loginLogReason, String loginLogReasonText){
		if(!Globals.getServerConfig().isScribeOnTurn()){
			CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGameLoginOrOutReport: is return;");
			return;
		}
		
		if(human == null || human.getPlayer() == null){
			CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGameLoginOrOutReport: human or player == null;");
			return;
		}
		
		Player player = human.getPlayer();
		
		String charName = human.getName() == null ? "" : human.getName();
		String deviceType = player.getDeviceType() == null ? "-1" : player.getDeviceType().toLowerCase();
		int charLevel = human.getLevel();
		String channelCode = "";
		if(player.getLoginType() == LoginTypeEnum.COMMONCHANNEL){
			if(player.getAuthPlatform() != null){
				channelCode = Integer.toString(player.getAuthPlatform().getIndex());
			}
		}
		
		String charId = Long.toString(human.getUUID()) ;
		String deviceGuid = player.getDeviceGuid() == null ? "" : player.getDeviceGuid();
		String logId = "";
		String loginType = player.getLoginType() == null ? "" : player.getLoginType().getLoginTypeName();
		String deviceUserAgent = player.getDeviceUserAgent() == null ? "-1" : player.getDeviceUserAgent();
		String promotionCode = player.getfValue() == null ? "" : player.getfValue();
		String channelUserid = "";
		String accountId = player.getPassportId() == null ? "" : player.getPassportId();
		
		long totalLoginTime = player.getTodayOnlineTime();
		long lastLoginTime = player.getLastLoginTime().getTime();
		String logClientIp = player.getClientIp() == null ? "" : player.getClientIpNoPort();
		int lineNumber = Globals.getOnlinePlayerService().getOnlinePlayerCount();
		String functionName = "write_scribe_log_for_login_logout";
		String deviceConnentType = player.getDeviceConnectType() == null ? "-1" : player.getDeviceConnectType();
		int charVip = 0;//Globals.getVipService().getVipLevel(human.getUUID());
		String accountName = player.getPassportName() == null ? "" : player.getPassportName().toLowerCase();
		String loginAction = loginLogReason == LoginLogReason.LOGIN ? "login":"logout";
		String deviceVersion = player.getDeviceVersion() == null ? "-1" : player.getDeviceVersion();
		String device = player.getCurrTerminalType() == null ? "" : player.getCurrTerminalType().getTerminalTypeName().toLowerCase();
		String deviceImei = player.getDeviceImei() == null ? "-1" : player.getDeviceImei();
		String deviceMac = player.getDeviceMac() == null ? "-1" : player.getDeviceMac();
		int deviceJailbroken = human.getPlayer().getDeviceJailbroken();
		
		ScribeGameLoginOrOutReport report = new ScribeGameLoginOrOutReport(charName, 
				deviceType, 
				charLevel, 
				channelCode, 
				charId, 
				deviceGuid, 
				logId, 
				loginType,
				deviceUserAgent, 
				promotionCode, 
				channelUserid, 
				accountId, 
				totalLoginTime, 
				lastLoginTime, 
				logClientIp, 
				lineNumber, 
				functionName, 
				deviceConnentType, 
				charVip, 
				accountName, 
				loginAction, 
				deviceVersion, 
				device, 
				deviceImei, 
				deviceMac, 
				deviceJailbroken);
		
		addReportData(report);
	}
	
	/**
	 * 在线人数回报
	 */
	public void sendScribeGameOnlineReport(){
		if(!Globals.getServerConfig().isScribeOnTurn()){
			CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGameOnlineReport: is return;");
			return;
		}
		String logId = "";
		String productId = "zlj";
		int onlineNum = Globals.getOnlinePlayerService().getOnlinePlayerCount();
		ScribeGameOnlineReport report = new ScribeGameOnlineReport(logId, productId, onlineNum);
		addReportData(report);
	}
	
	/**
	 * 冲入记录
	 * @param human
	 */
	public void sendScribeGameGoldRemainReport(long goldCurrent,long propGoldCurrent,long eternal){
		if(!Globals.getServerConfig().isScribeOnTurn()){
			CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGameGoldRemainReport: is return;");
			return;
		}
		ScribeGameGoldRemainReport report = new ScribeGameGoldRemainReport(
				goldCurrent,		//goldCurrent
				propGoldCurrent + eternal		//propGoldCurrent
		);
//		reportManager.addToReport(report);
		addReportData(report);
		
		CHARGE_LOGGER.info("#GS.LocalScribeService.sendScribeGameGoldRemainReport:" + 
				"goldCurrent=" + goldCurrent+";" + 						//goldCurrent
				"propGoldCurrent=" + propGoldCurrent+";" + 				//propGoldCurrent
				"eternal=" + eternal+";" 				//propGoldCurrent
				);
	}
	
	/**
	 * 冲入记录
	 * @param human
	 */
	public void localScribedAllLeftBond(){
		// TODO
//		if(Globals.getConfig().getWorldServerConfig().getServerType() == SharedConstants.AcrossServer_type){
//			Loggers.gameLogger.info("world server not need report!");
//		}else{
			LocalScribedAllLeftBondOperation op = new LocalScribedAllLeftBondOperation();
			Globals.getAsyncService().createOperationAndExecuteAtOnce(op);
//		}
	}
}




















