package com.imop.lj.gameserver.common.log;

import com.imop.lj.logserver.model.ArenaLog;
import com.imop.lj.logserver.model.BehaviorLog;
import com.imop.lj.logserver.model.ChargeLog;
import com.imop.lj.logserver.model.ChatLog;
import com.imop.lj.logserver.model.DropItemLog;
import com.imop.lj.logserver.model.GmCommandLog;
import com.imop.lj.logserver.model.ItemGenLog;
import com.imop.lj.logserver.model.ItemLog;
import com.imop.lj.logserver.model.MailLog;
import com.imop.lj.logserver.model.MoneyLog;
import com.imop.lj.logserver.model.OnlineTimeLog;
import com.imop.lj.logserver.model.PlayerLoginLog;
import com.imop.lj.logserver.model.VipLog;
import com.imop.lj.logserver.model.TaskLog;
import com.imop.lj.logserver.model.FormationLog;
import com.imop.lj.logserver.model.MissionLog;
import com.imop.lj.logserver.model.RewardLog;
import com.imop.lj.logserver.model.EquipLog;
import com.imop.lj.logserver.model.PetLog;
import com.imop.lj.logserver.model.PrizeLog;
import com.imop.lj.logserver.model.MysteryShopLog;
import com.imop.lj.logserver.model.PetExpLog;
import com.imop.lj.logserver.model.HorseLog;
import com.imop.lj.logserver.model.MallLog;
import com.imop.lj.logserver.model.ItemCostRecordLog;
import com.imop.lj.logserver.model.PopTipsLog;
import com.imop.lj.logserver.model.GoodActivityLog;
import com.imop.lj.logserver.model.BattleResultLog;
import com.imop.lj.logserver.model.PubTaskLog;
import com.imop.lj.logserver.model.PubExpLog;
import com.imop.lj.logserver.model.ExamLog;
import com.imop.lj.logserver.model.CorpsLog;
import com.imop.lj.logserver.model.TheSweeneyTaskLog;
import com.imop.lj.logserver.model.TreasureMapLog;
import com.imop.lj.logserver.model.TitleLog;
import com.imop.lj.logserver.model.ForageTaskLog;
import com.imop.lj.logserver.model.OvermanLog;
import com.imop.lj.logserver.model.WingLog;
import com.imop.lj.logserver.model.CommoditySellLog;
import com.imop.lj.logserver.model.CommodityBuyLog;
import com.imop.lj.logserver.model.CorpsTaskLog;
import com.imop.lj.logserver.model.CorpsBuildLog;
import com.imop.lj.logserver.model.CorpsBenefitLog;
import com.imop.lj.logserver.model.TowerLog;
import com.imop.lj.logserver.model.CorpsBossLog;
import com.imop.lj.logserver.model.TimeLimitMonsterLog;
import com.imop.lj.logserver.model.TimeLimitNpcLog;
import com.imop.lj.logserver.model.SiegeDemonTaskLog;
import com.imop.lj.core.log.UdpLoggerClient;
import com.imop.lj.logserver.BaseLogMessage;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import com.imop.lj.common.LogReasons;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.common.Globals;

/**
 * This is an auto generated source,please don't modify it.
 */
public class LogService {
	private static final Logger logger = LoggerFactory.getLogger(LogService.class);
	/** 日志客户端 */
	private final UdpLoggerClient udpLoggerClient = UdpLoggerClient.getInstance();
	/**  游戏区ID */
	private int regionID;
	/** 游戏服务器ID */
	private int serverID;

	/**
	 * 初始化
	 * 
	 * @param logServerIp
	 *            日志服务器IP
	 * @param logServerPort
	 *            日志服务器端口
	 * @param regionID
	 *            游戏区ID
	 * @param serverID
	 *            游戏服务器ID
	 */
	public LogService(String logServerIp, int logServerPort, int regionID, int serverID) {
		udpLoggerClient.initialize(logServerIp, logServerPort);
		udpLoggerClient.setRegionId(regionID);
		udpLoggerClient.setServerId(serverID);

		this.regionID = regionID;
		this.serverID = serverID;
		
		if (logger.isInfoEnabled()) {
			logger.info("Connnect to Log server : " + logServerIp + " : " + logServerPort);
		}
	}
	
	public void sendLogMessage(BaseLogMessage msg) {
		if (Globals.getServerConfig().getSelfLogServer()) {
			Globals.getLogServerService().sendLogMessage(msg);
		} else {
			udpLoggerClient.sendMessage(msg);
		}
	}

	/**
	 * 发送竞技场日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param battleResult 战斗结果
	 * @param attackerId 攻击者id
	 * @param attackerBeforeCwinTimes 攻击者战斗前连胜数
	 * @param attackerAfterCwinTimes 攻击者战斗后连胜数
	 * @param attackerBeforeRank 攻击者战斗前名次
	 * @param attackerAfterRank 攻击者战斗后名次
	 * @param defenderId 防御方id
	 * @param defenderBeforeCwinTimes 防御方战斗前连胜数
	 * @param defenderAfterCwinTimes 防御方战斗后连胜数
	 * @param defenderBeforeRank 防御方战斗前名次
	 * @param defenderAfterRank 防御方战斗后名次
	 */
	public void sendArenaLog(Human human,
				LogReasons.ArenaLogReason reason,				String param			,String battleResult
			,long attackerId
			,int attackerBeforeCwinTimes
			,int attackerAfterCwinTimes
			,int attackerBeforeRank
			,int attackerAfterRank
			,long defenderId
			,int defenderBeforeCwinTimes
			,int defenderAfterCwinTimes
			,int defenderBeforeRank
			,int defenderAfterRank
		) {
		this.sendLogMessage(new ArenaLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,battleResult
			,attackerId
			,attackerBeforeCwinTimes
			,attackerAfterCwinTimes
			,attackerBeforeRank
			,attackerAfterRank
			,defenderId
			,defenderBeforeCwinTimes
			,defenderAfterCwinTimes
			,defenderBeforeRank
			,defenderAfterRank
		));
	}
	/**
	 * 发送用户特定行为日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param behaviorType 行为类型
	 * @param oldOpCount 旧行为次数
	 * @param newOpCount 新行为次数
	 * @param oldAddCount 旧附加次数
	 * @param newAddCount 新附加次数
	 */
	public void sendBehaviorLog(Human human,
				LogReasons.BehaviorLogReason reason,				String param			,int behaviorType
			,int oldOpCount
			,int newOpCount
			,int oldAddCount
			,int newAddCount
		) {
		this.sendLogMessage(new BehaviorLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,behaviorType
			,oldOpCount
			,newOpCount
			,oldAddCount
			,newAddCount
		));
	}
	/**
	 * 发送充值日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param moneyType 货币类型
	 * @param currencyBefore 充值前数量
	 * @param currencyAfter 充值后数量
	 * @param mmCost 要兑换多少MM
	 * @param result 接口返回的充值结果
	 * @param transfer 订单号即平台orderId
	 */
	public void sendChargeLog(Human human,
				LogReasons.ChargeLogReason reason,				String param			,int moneyType
			,int currencyBefore
			,int currencyAfter
			,int mmCost
			,String result
			,String transfer
		) {
		this.sendLogMessage(new ChargeLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,moneyType
			,currencyBefore
			,currencyAfter
			,mmCost
			,result
			,transfer
		));
	}
	/**
	 * 发送聊天日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param scope 聊天范围
	 * @param recCharName 如果为私聊，则记录私聊消息的接收玩家角色名称,否则该字段无意义
	 * @param content 聊天的内容
	 */
	public void sendChatLog(Human human,
				LogReasons.ChatLogReason reason,				String param			,int scope
			,String recCharName
			,String content
		) {
		this.sendLogMessage(new ChatLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,scope
			,recCharName
			,content
		));
	}
	/**
	 * 发送掉落日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param fromReason 来源处reason
	 * @param dropId 掉落id
	 * @param templateId 道具模板ID
	 * @param itemName 道具名称
	 * @param fromDetailReason 来源处detailReason
	 */
	public void sendDropItemLog(Human human,
				LogReasons.DropItemLogReason reason,				String param			,int fromReason
			,int dropId
			,int templateId
			,String itemName
			,String fromDetailReason
		) {
		this.sendLogMessage(new DropItemLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,fromReason
			,dropId
			,templateId
			,itemName
			,fromDetailReason
		));
	}
	/**
	 * 发送GM操作日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param operatorName 操作者姓名
	 * @param targetIp 目标机器
	 * @param command 命令
	 * @param commandDesc 命令描述
	 * @param commandDetail 命令内容
	 * @param returnResult 返回结果
	 */
	public void sendGmCommandLog(Human human,
				LogReasons.GmCommandLogReason reason,				String param			,String operatorName
			,String targetIp
			,String command
			,String commandDesc
			,String commandDetail
			,String returnResult
		) {
		this.sendLogMessage(new GmCommandLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,operatorName
			,targetIp
			,command
			,commandDesc
			,commandDetail
			,returnResult
		));
	}
	/**
	 * 发送物品产出日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param templateId 道具模板ID
	 * @param itemName 道具名称
	 * @param count 道具数量
	 * @param deadline 使用有限期限
	 * @param properties 物品其他属性
	 * @param itemGenId 物品产生ID
	 */
	public void sendItemGenLog(Human human,
				LogReasons.ItemGenLogReason reason,				String param			,int templateId
			,String itemName
			,int count
			,long deadline
			,String properties
			,String itemGenId
		) {
		this.sendLogMessage(new ItemGenLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,templateId
			,itemName
			,count
			,deadline
			,properties
			,itemGenId
		));
	}
	/**
	 * 发送物品改变日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param bagId 包裹id
	 * @param bagIndex 在包裹中的位置索引
	 * @param templateId 道具模板ID
	 * @param instUUID 道具实例ID
	 * @param delta 变化值
	 * @param resultCount 操作后的最终叠加数
	 * @param itemGenId 道具产生ID：对应ItemGenLog
	 * @param itemData 道具大字段信息，用于在删除贵重道具时将道具二进制信息备份
	 */
	public void sendItemLog(Human human,
				LogReasons.ItemLogReason reason,				String param			,int bagId
			,int bagIndex
			,int templateId
			,String instUUID
			,int delta
			,int resultCount
			,String itemGenId
			,byte[] itemData
		) {
		this.sendLogMessage(new ItemLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,bagId
			,bagIndex
			,templateId
			,instUUID
			,delta
			,resultCount
			,itemGenId
			,itemData
		));
	}
	/**
	 * 发送邮件日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param uuid 唯一Id
	 * @param senderId 发件人ID
	 * @param senderName 发件人姓名
	 * @param recieverId 收件人ID
	 * @param recieverName 收件人姓名
	 * @param title 标题
	 * @param readStatus 阅读状态
	 * @param sendTime 发件时间
	 */
	public void sendMailLog(Human human,
				LogReasons.MailLogReason reason,				String param			,String uuid
			,String senderId
			,String senderName
			,String recieverId
			,String recieverName
			,String title
			,int readStatus
			,long sendTime
		) {
		this.sendLogMessage(new MailLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,uuid
			,senderId
			,senderName
			,recieverId
			,recieverName
			,title
			,readStatus
			,sendTime
		));
	}
	/**
	 * 发送金钱日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param mainCurrency 主货币类型
	 * @param mainDelta 主货币钱数变化值
	 * @param mainCurrLeft 主货币剩余金钱
	 * @param altCurrency 辅助货币类型
	 * @param altDelta 辅助货币变化值
	 * @param altCurrLeft 辅助货币剩余金钱
	 * @param thirdCurrency 第三货币类型
	 * @param thirdDelta 第三货币变化值
	 * @param thirdCurrLeft 第三货币剩余金钱
	 */
	public void sendMoneyLog(Human human,
				LogReasons.MoneyLogReason reason,				String param			,int mainCurrency
			,long mainDelta
			,long mainCurrLeft
			,int altCurrency
			,long altDelta
			,long altCurrLeft
			,int thirdCurrency
			,long thirdDelta
			,long thirdCurrLeft
		) {
		this.sendLogMessage(new MoneyLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,mainCurrency
			,mainDelta
			,mainCurrLeft
			,altCurrency
			,altDelta
			,altCurrLeft
			,thirdCurrency
			,thirdDelta
			,thirdCurrLeft
		));
	}
	/**
	 * 发送玩家在线时间日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param minute 当天累计在线时间(分钟)
	 * @param totalMinute 累计在线时间(分钟)
	 * @param lastLoginTime 最后一次登录时间
	 * @param lastLogoutTime 最后一次登出时间
	 */
	public void sendOnlineTimeLog(Human human,
				LogReasons.OnlineTimeLogReason reason,				String param			,int minute
			,int totalMinute
			,long lastLoginTime
			,long lastLogoutTime
		) {
		this.sendLogMessage(new OnlineTimeLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,minute
			,totalMinute
			,lastLoginTime
			,lastLogoutTime
		));
	}
	/**
	 * 发送用户登陆日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param device 登陆终端
	 * @param playerLoginTime 登陆时间
	 * @param source 登陆信息--设备来源|终端id|设备类型|设备版本号|客户端版本号|客户端语言类型
	 */
	public void sendPlayerLoginLog(Human human,
				LogReasons.PlayerLoginLogReason reason,				String param			,String device
			,long playerLoginTime
			,String source
		) {
		this.sendLogMessage(new PlayerLoginLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,device
			,playerLoginTime
			,source
		));
	}
	/**
	 * 发送Vip日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param vipUuid VipUUID, 角色ID
	 * @param chargeDiamond 当次充值数量
	 * @param cardId 当前使用卡ID
	 * @param receiveOnceRewardId 领取每日奖励ID
	 * @param oldVipData 旧vip数据
	 * @param newVipData 新vip数据
	 */
	public void sendVipLog(Human human,
				LogReasons.VipLogReason reason,				String param			,long vipUuid
			,long chargeDiamond
			,int cardId
			,long receiveOnceRewardId
			,String oldVipData
			,String newVipData
		) {
		this.sendLogMessage(new VipLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,vipUuid
			,chargeDiamond
			,cardId
			,receiveOnceRewardId
			,oldVipData
			,newVipData
		));
	}
	/**
	 * 发送task日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param task_id 任务id
	 */
	public void sendTaskLog(Human human,
				LogReasons.TaskLogReason reason,				String param			,int task_id
		) {
		this.sendLogMessage(new TaskLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,task_id
		));
	}
	/**
	 * 发送布阵日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param result 当前布阵情况
	 */
	public void sendFormationLog(Human human,
				LogReasons.FormationLogReason reason,				String param			,String result
		) {
		this.sendLogMessage(new FormationLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,result
		));
	}
	/**
	 * 发送关卡日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param missionEnemyId 关卡Id
	 * @param enemyArmyIndex 敌人索引
	 * @param enemyArmyId 敌人Id
	 * @param totalRround 总轮数
	 * @param leftRound 剩余轮数
	 */
	public void sendMissionLog(Human human,
				LogReasons.MissionLogReason reason,				String param			,int missionEnemyId
			,int enemyArmyIndex
			,int enemyArmyId
			,int totalRround
			,int leftRound
		) {
		this.sendLogMessage(new MissionLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,missionEnemyId
			,enemyArmyIndex
			,enemyArmyId
			,totalRround
			,leftRound
		));
	}
	/**
	 * 发送奖励日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param createRewardCharId 生成奖励对应玩家角色id
	 * @param rewardUuid 奖励标示
	 * @param exp 经验
	 * @param currencyInfos 货币奖励
	 * @param itemInfos 物品奖励
	 * @param otherInfos 其他参数
	 */
	public void sendRewardLog(Human human,
				LogReasons.RewardLogReason reason,				String param			,long createRewardCharId
			,String rewardUuid
			,int exp
			,String currencyInfos
			,String itemInfos
			,String otherInfos
		) {
		this.sendLogMessage(new RewardLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,createRewardCharId
			,rewardUuid
			,exp
			,currencyInfos
			,itemInfos
			,otherInfos
		));
	}
	/**
	 * 发送装备相关日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param uuid UUID
	 * @param tempId 模版ID
	 * @param enhanceLevel 装备强化等级
	 * @param fumoLevel 装备附魔等级
	 * @param weaponSkillId 武器技能ID
	 * @param additionAttrStr 附加属性
	 * @param gemStr 宝石
	 * @param extraStr 备用
	 */
	public void sendEquipLog(Human human,
				LogReasons.EquipLogReason reason,				String param			,String uuid
			,int tempId
			,int enhanceLevel
			,int fumoLevel
			,int weaponSkillId
			,String additionAttrStr
			,String gemStr
			,String extraStr
		) {
		this.sendLogMessage(new EquipLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,uuid
			,tempId
			,enhanceLevel
			,fumoLevel
			,weaponSkillId
			,additionAttrStr
			,gemStr
			,extraStr
		));
	}
	/**
	 * 发送武将相关日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param templateId 武将模板ID
	 * @param instUUID 武将实例ID
	 * @param init 是否初始生成
	 */
	public void sendPetLog(Human human,
				LogReasons.PetLogReason reason,				String param			,int templateId
			,long instUUID
			,String init
		) {
		this.sendLogMessage(new PetLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,templateId
			,instUUID
			,init
		));
	}
	/**
	 * 发送补偿奖励
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param loginTime 登录时间
	 * @param prizeType 奖励物品
	 * @param drawCount 领取次数
	 */
	public void sendPrizeLog(Human human,
				LogReasons.PrizeLogReason reason,				String param			,long loginTime
			,int prizeType
			,int drawCount
		) {
		this.sendLogMessage(new PrizeLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,loginTime
			,prizeType
			,drawCount
		));
	}
	/**
	 * 发送神秘商店日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param text 
	 */
	public void sendMysteryShopLog(Human human,
				LogReasons.MysteryShopLogReason reason,				String param			,String text
		) {
		this.sendLogMessage(new MysteryShopLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,text
		));
	}
	/**
	 * 发送武将经验日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param templateId 武将模板ID
	 * @param instUUID 武将实例ID
	 * @param addExp 增加经验
	 * @param petLevel 当前级别
	 * @param petExp 武将当前经验
	 */
	public void sendPetExpLog(Human human,
				LogReasons.PetExpLogReason reason,				String param			,int templateId
			,long instUUID
			,long addExp
			,int petLevel
			,long petExp
		) {
		this.sendLogMessage(new PetExpLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,templateId
			,instUUID
			,addExp
			,petLevel
			,petExp
		));
	}
	/**
	 * 发送坐骑日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param preTrainStar 
	 * @param preTrainExp 
	 * @param afterTrainStar 
	 * @param afterTrainExp 
	 * @param preDrawSkill 
	 * @param afterDrawSkill 
	 */
	public void sendHorseLog(Human human,
				LogReasons.HorseLogReason reason,				String param			,int preTrainStar
			,long preTrainExp
			,int afterTrainStar
			,long afterTrainExp
			,String preDrawSkill
			,String afterDrawSkill
		) {
		this.sendLogMessage(new HorseLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,preTrainStar
			,preTrainExp
			,afterTrainStar
			,afterTrainExp
			,preDrawSkill
			,afterDrawSkill
		));
	}
	/**
	 * 发送商城日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param currQueueConfig 当前队列组
	 * @param currQueueUUID 当前队列UUID
	 * @param currQueueId 当前队列模版ID
	 * @param currStartTime 当前队列开始时间
	 * @param stock 库存
	 */
	public void sendMallLog(Human human,
				LogReasons.MallLogReason reason,				String param			,String currQueueConfig
			,String currQueueUUID
			,int currQueueId
			,long currStartTime
			,String stock
		) {
		this.sendLogMessage(new MallLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,currQueueConfig
			,currQueueUUID
			,currQueueId
			,currStartTime
			,stock
		));
	}
	/**
	 * 发送财务汇报日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param originalFreeNum 原始免费的个数
	 * @param originalItemNum 原始道具个数
	 * @param originalTotalCost 原始物品总价值
	 * @param originalActualCost 原始实际花费金钱
	 * @param freeNum 修改后免费的个数
	 * @param itemNum 修改后道具个数
	 * @param totalCost 修改后物品总价值
	 * @param actualCost 修改后实际花费金钱
	 */
	public void sendItemCostRecordLog(Human human,
				LogReasons.ItemCostRecordLogReason reason,				String param			,long originalFreeNum
			,long originalItemNum
			,long originalTotalCost
			,long originalActualCost
			,long freeNum
			,long itemNum
			,long totalCost
			,long actualCost
		) {
		this.sendLogMessage(new ItemCostRecordLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,originalFreeNum
			,originalItemNum
			,originalTotalCost
			,originalActualCost
			,freeNum
			,itemNum
			,totalCost
			,actualCost
		));
	}
	/**
	 * 发送小助手
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param humanUuid 角色id
	 * @param poptipLintType poptip类型
	 * @param poptipsLinkId poptipid
	 * @param humanOrignalValue 角色poptip操作前原始值
	 * @param humanAfterOperatorValue 角色poptip操作后的值
	 */
	public void sendPopTipsLog(Human human,
				LogReasons.PopTipsLogReason reason,				String param			,long humanUuid
			,int poptipLintType
			,int poptipsLinkId
			,int humanOrignalValue
			,int humanAfterOperatorValue
		) {
		this.sendLogMessage(new PopTipsLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,humanUuid
			,poptipLintType
			,poptipsLinkId
			,humanOrignalValue
			,humanAfterOperatorValue
		));
	}
	/**
	 * 发送精彩活动
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param goodActivityId 活动唯一Id
	 * @param tplId 活动模板Id
	 * @param rewardId 奖励Id
	 * @param targetId 目标Id
	 */
	public void sendGoodActivityLog(Human human,
				LogReasons.GoodActivityLogReason reason,				String param			,long goodActivityId
			,int tplId
			,int rewardId
			,int targetId
		) {
		this.sendLogMessage(new GoodActivityLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,goodActivityId
			,tplId
			,rewardId
			,targetId
		));
	}
	/**
	 * 发送战斗结果日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param battleResult 战斗结果
	 * @param battleType 战斗类型
	 * @param target 战斗目标
	 */
	public void sendBattleResultLog(Human human,
				LogReasons.BattleResultLogReason reason,				String param			,String battleResult
			,int battleType
			,String target
		) {
		this.sendLogMessage(new BattleResultLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,battleResult
			,battleType
			,target
		));
	}
	/**
	 * 发送酒馆任务日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param backupMap 备选任务状态字符串
	 * @param curQuestId 当前任务Id
	 * @param curQuestStatus 当前任务状态
	 */
	public void sendPubTaskLog(Human human,
				LogReasons.PubTaskLogReason reason,				String param			,String backupMap
			,int curQuestId
			,int curQuestStatus
		) {
		this.sendLogMessage(new PubTaskLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,backupMap
			,curQuestId
			,curQuestStatus
		));
	}
	/**
	 * 发送酒馆经验日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param addExp 增加经验
	 * @param pubLevel 当前级别
	 * @param pubExp 当前经验
	 */
	public void sendPubExpLog(Human human,
				LogReasons.PubExpLogReason reason,				String param			,long addExp
			,int pubLevel
			,long pubExp
		) {
		this.sendLogMessage(new PubExpLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,addExp
			,pubLevel
			,pubExp
		));
	}
	/**
	 * 发送科举日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param examId 试题ID
	 * @param indexE 第几道题
	 * @param resultE 答题结果 1,正确 2,错误
	 */
	public void sendExamLog(Human human,
				LogReasons.ExamLogReason reason,				String param			,int examId
			,int indexE
			,int resultE
		) {
		this.sendLogMessage(new ExamLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,examId
			,indexE
			,resultE
		));
	}
	/**
	 * 发送军团日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param corpsId 商会ID
	 * @param corpsName 商会名
	 * @param corpsLevel 商会等级
	 * @param memberNum 商会人数
	 * @param operatorJob 操作者职位
	 * @param targetId 被操作者玩家id
	 * @param targetName 被操作者玩家名称
	 * @param targetJob 被操作者职位
	 */
	public void sendCorpsLog(Human human,
				LogReasons.CorpsLogReason reason,				String param			,long corpsId
			,String corpsName
			,int corpsLevel
			,int memberNum
			,int operatorJob
			,long targetId
			,String targetName
			,int targetJob
		) {
		this.sendLogMessage(new CorpsLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,corpsId
			,corpsName
			,corpsLevel
			,memberNum
			,operatorJob
			,targetId
			,targetName
			,targetJob
		));
	}
	/**
	 * 发送除暴安良日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param curQuestId 当前任务Id
	 * @param curQuestStatus 当前任务状态
	 */
	public void sendTheSweeneyTaskLog(Human human,
				LogReasons.TheSweeneyTaskLogReason reason,				String param			,int curQuestId
			,int curQuestStatus
		) {
		this.sendLogMessage(new TheSweeneyTaskLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,curQuestId
			,curQuestStatus
		));
	}
	/**
	 * 发送藏宝图日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param curQuestId 当前任务Id
	 * @param curQuestStatus 当前任务状态
	 */
	public void sendTreasureMapLog(Human human,
				LogReasons.TreasureMapLogReason reason,				String param			,int curQuestId
			,int curQuestStatus
		) {
		this.sendLogMessage(new TreasureMapLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,curQuestId
			,curQuestStatus
		));
	}
	/**
	 * 发送称号log
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param titleid 称号id
	 */
	public void sendTitleLog(Human human,
				LogReasons.TitleLogReason reason,				String param			,String titleid
		) {
		this.sendLogMessage(new TitleLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,titleid
		));
	}
	/**
	 * 发送护送粮草任务日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param backupMap 备选任务状态字符串
	 * @param curQuestId 当前任务Id
	 * @param curQuestStatus 当前任务状态
	 */
	public void sendForageTaskLog(Human human,
				LogReasons.ForageTaskLogReason reason,				String param			,String backupMap
			,int curQuestId
			,int curQuestStatus
		) {
		this.sendLogMessage(new ForageTaskLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,backupMap
			,curQuestId
			,curQuestStatus
		));
	}
	/**
	 * 发送师徒关系
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param overmancharid 称号id
	 * @param lowermancharid 
	 * @param status 
	 */
	public void sendOvermanLog(Human human,
				LogReasons.OvermanLogReason reason,				String param			,long overmancharid
			,long lowermancharid
			,int status
		) {
		this.sendLogMessage(new OvermanLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,overmancharid
			,lowermancharid
			,status
		));
	}
	/**
	 * 发送翅膀日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param tempId 模版ID
	 * @param wingLevel 翅膀阶数
	 * @param wingBless 翅膀祝福值
	 * @param wingPower 翅膀战斗力
	 */
	public void sendWingLog(Human human,
				LogReasons.WingLogReason reason,				String param			,int tempId
			,int wingLevel
			,int wingBless
			,int wingPower
		) {
		this.sendLogMessage(new WingLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,tempId
			,wingLevel
			,wingBless
			,wingPower
		));
	}
	/**
	 * 发送寄售商品日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param sellInfo 出售商品详细信息
	 */
	public void sendCommoditySellLog(Human human,
				LogReasons.CommoditySellLogReason reason,				String param			,String sellInfo
		) {
		this.sendLogMessage(new CommoditySellLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,sellInfo
		));
	}
	/**
	 * 发送购买商品日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param buyInfo 购买商品详细信息
	 */
	public void sendCommodityBuyLog(Human human,
				LogReasons.CommodityBuyLogReason reason,				String param			,String buyInfo
		) {
		this.sendLogMessage(new CommodityBuyLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,buyInfo
		));
	}
	/**
	 * 发送帮派任务日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param curQuestId 当前任务Id
	 * @param curQuestStatus 当前任务状态
	 */
	public void sendCorpsTaskLog(Human human,
				LogReasons.CorpsTaskLogReason reason,				String param			,int curQuestId
			,int curQuestStatus
		) {
		this.sendLogMessage(new CorpsTaskLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,curQuestId
			,curQuestStatus
		));
	}
	/**
	 * 发送帮派建设日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param corpsId 帮派ID
	 * @param corpsName 帮派名
	 * @param corpsLevel 帮派等级
	 * @param memberNum 帮派人数
	 * @param currExp 帮派当前经验
	 * @param curFund 帮派当前资金
	 */
	public void sendCorpsBuildLog(Human human,
				LogReasons.CorpsBuildLogReason reason,				String param			,long corpsId
			,String corpsName
			,int corpsLevel
			,int memberNum
			,long currExp
			,long curFund
		) {
		this.sendLogMessage(new CorpsBuildLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,corpsId
			,corpsName
			,corpsLevel
			,memberNum
			,currExp
			,curFund
		));
	}
	/**
	 * 发送帮派福利日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param corpsId 帮派ID
	 * @param corpsName 帮派名
	 * @param corpsLevel 帮派等级
	 * @param memberNum 帮派人数
	 * @param operatorId 操作者玩家id
	 * @param operatorJob 操作者职位
	 * @param benefitCount 获得福利数量
	 */
	public void sendCorpsBenefitLog(Human human,
				LogReasons.CorpsBenefitLogReason reason,				String param			,long corpsId
			,String corpsName
			,int corpsLevel
			,int memberNum
			,long operatorId
			,int operatorJob
			,long benefitCount
		) {
		this.sendLogMessage(new CorpsBenefitLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,corpsId
			,corpsName
			,corpsLevel
			,memberNum
			,operatorId
			,operatorJob
			,benefitCount
		));
	}
	/**
	 * 发送通天塔日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param curTowerLevel 当前玩家的通天塔层数
	 * @param curDoublePoint 当前双倍点数
	 * @param isOpenDouble 是否开启双倍,1:是,0:否
	 */
	public void sendTowerLog(Human human,
				LogReasons.TowerLogReason reason,				String param			,int curTowerLevel
			,int curDoublePoint
			,int isOpenDouble
		) {
		this.sendLogMessage(new TowerLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,curTowerLevel
			,curDoublePoint
			,isOpenDouble
		));
	}
	/**
	 * 发送帮派boss日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param curCorpsBossLevel 当前玩家的帮派boss进度
	 */
	public void sendCorpsBossLog(Human human,
				LogReasons.CorpsBossLogReason reason,				String param			,int curCorpsBossLevel
		) {
		this.sendLogMessage(new CorpsBossLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,curCorpsBossLevel
		));
	}
	/**
	 * 发送限时杀怪日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param curQuestId 当前任务Id
	 * @param curQuestStatus 当前任务状态
	 */
	public void sendTimeLimitMonsterLog(Human human,
				LogReasons.TimeLimitMonsterLogReason reason,				String param			,int curQuestId
			,int curQuestStatus
		) {
		this.sendLogMessage(new TimeLimitMonsterLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,curQuestId
			,curQuestStatus
		));
	}
	/**
	 * 发送限时挑战Npc日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param curQuestId 当前任务Id
	 * @param curQuestStatus 当前任务状态
	 */
	public void sendTimeLimitNpcLog(Human human,
				LogReasons.TimeLimitNpcLogReason reason,				String param			,int curQuestId
			,int curQuestStatus
		) {
		this.sendLogMessage(new TimeLimitNpcLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,curQuestId
			,curQuestStatus
		));
	}
	/**
	 * 发送围剿魔族任务日志
	 * @param logTime 日志产生时间
	 * @param accountId 玩家账号Id
	 * @param accountName 玩家的账号名
	 * @param charId 角色ID
	 * @param charName 玩家的角色名
	 * @param level 玩家等级
	 * @param countryId 国家Id
	 * @param vipLevel 玩家VIP等级
	 * @param totalCharge 总充值数量
	 * @param deviceId 终端id
	 * @param deviceType 设备类型
	 * @param deviceVersion 设备版本号
	 * @param clientVersion 客户端版本号
	 * @param clientLanguage 客户端语言类型
	 * @param appid 客户端appid
	 * @param fValue f值
	 * @param reason 原因
	 * @param param 其他参数
	 * @param curQuestId 当前任务Id
	 * @param curQuestStatus 当前任务状态
	 */
	public void sendSiegeDemonTaskLog(Human human,
				LogReasons.SiegeDemonTaskLogReason reason,				String param			,int curQuestId
			,int curQuestStatus
		) {
		this.sendLogMessage(new SiegeDemonTaskLog(
			
				Globals.getTimeService().now(),			
				this.regionID,			
				this.serverID,			
				human == null ? "" : human.getPassportId(),			
				human == null ? "" : human.getPassportName(),			
				human == null ? 0 : human.getUUID(),			
				human == null ? "" : human.getName(),			
				human == null ? 0 : human.getLevel(),			
				human == null ? 0 : human.getCountry(),			
				human == null ? 0 : human.getVipLevel(),			
				human == null ? 0 : human.getTotalCharge(),			
				human == null ? "-1" : human.getPlayer().getDeviceID() ,			
				human == null ? "-1" : human.getPlayer().getDeviceType() ,			
				human == null ? "-1" : human.getPlayer().getDeviceVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientVersion() ,			
				human == null ? "-1" : human.getPlayer().getClientLanguage() ,			
				human == null ? "-1" : human.getPlayer().getAppid() ,			
				human == null ? "-1" : human.getPlayer().getfValue() ,			
				reason.reason,			
				param			
			,curQuestId
			,curQuestStatus
		));
	}

}