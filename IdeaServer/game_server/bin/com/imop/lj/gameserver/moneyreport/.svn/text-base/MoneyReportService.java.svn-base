package com.imop.lj.gameserver.moneyreport;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.ItemCostRecordLogReason;
import com.imop.lj.common.LogReasons.ItemGenLogReason;
import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.CommonUtil;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.model.ItemCostRecordEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.localscribe.LocalScribeService;
import com.imop.lj.gameserver.moneyreport.updater.ItemCostRecord;

/***
 * 财报服务
 *
 */
public class MoneyReportService implements InitializeRequired {
	
	/** 财报开关 */
	public static boolean isMoneyReportOpen = true;

	/** 财报服务相关数据缓存 */
	protected Map<ItemGenLogReason,MoneyLogReason> bindItemReasons;
	
	/** 使用元宝永久性增加的东西 */
	protected Set<MoneyLogReason> bindEnternalReasons;

	/**以Key：玩家ID,Value：该玩家的所有道具的消耗记录Map<Integer,ItemCostRecord> Key:道具ID, Value：该道具的消耗记录**/
	protected Map<Long,Map<Integer,ItemCostRecord>> allPlayersItemCostRecordMap = Maps.newHashMap();

	@Override
	public void init() {
		// XXX 初始化所有的道具消耗记录
		initAllItemCostRecords();
		bindItemReasons = new HashMap<ItemGenLogReason,MoneyLogReason>();
		bindItemReasons.put(ItemGenLogReason.MS_BUY_ITEM, MoneyLogReason.MS_BUY_ITEM_COST);
		bindItemReasons.put(ItemGenLogReason.MALL_BUY_ITEM, MoneyLogReason.MALL_BUY_ITEM_COST);
		bindItemReasons.put(ItemGenLogReason.CHARGE_ITEM_COST, MoneyLogReason.CHARGE_ITEM_COST);
		
		bindEnternalReasons = new HashSet<MoneyLogReason>();
//		bindEnternalReasons.add(MoneyLogReason.CD_ADD);
//		bindEnternalReasons.add(MoneyLogReason.OPEN_HUNT_MAIN_BAG);
//		bindEnternalReasons.add(MoneyLogReason.OPEN_CHIP_MAIN_BAG);
//		bindEnternalReasons.add(MoneyLogReason.OPEN_BAG_SIZE);
//		bindEnternalReasons.add(MoneyLogReason.BUY_TRAINING_QUEUE);
//		bindEnternalReasons.add(MoneyLogReason.BUY_LUCKY_DICE);
	}
	
	/***
	 * 初始化所有的道具消耗记录
	 */
	public void initAllItemCostRecords() {
		List<ItemCostRecordEntity> itemCostRecordEntitys = Globals.getDaoService().getItemCostRecordDao().loadAllItemCostRecord();
		for (ItemCostRecordEntity itemCostRecordEntity : itemCostRecordEntitys) {
			//初始化记录实例
			ItemCostRecord itemCostRecord = new ItemCostRecord();
			itemCostRecord.fromEntity(itemCostRecordEntity);
			
			//获得该记录所属玩家的 此道具记录的集合
			Map<Integer,ItemCostRecord> itemCostMapByHumanMap = allPlayersItemCostRecordMap.get(itemCostRecord.getCharId());
			if(itemCostMapByHumanMap == null) {
				itemCostMapByHumanMap = new HashMap<Integer, ItemCostRecord>();
				allPlayersItemCostRecordMap.put(itemCostRecord.getCharId(), itemCostMapByHumanMap);
			}
			
			//将此记录存储到该玩家的道具消耗集合中
			itemCostMapByHumanMap.put(itemCostRecord.getTemplateId(), itemCostRecord);
		}
	}

	/***
	 * 获得财报缓存中所有道具消耗的实例集合
	 * @return
	 */
	public Map<Long, Map<Integer, ItemCostRecord>> getAllPlayersItemCostRecordMap() {
		return allPlayersItemCostRecordMap;
	}

	public Map<ItemGenLogReason, MoneyLogReason> getBindItemReasons() {
		return bindItemReasons;
	}

	public Set<MoneyLogReason> getBindEnternalReasons() {
		return bindEnternalReasons;
	}

	/***
	 * 记录添加道具的财报记录
	 *
	 * @param itemTemplateId
	 *            道具ID
	 * @param itemNum
	 *            道具个数
	 * @param currency
	 *            金钱类型
	 * @param totalCost
	 *            总消耗金钱数量
	 * @param actualCost
	 *            实际消耗金钱数量（即消耗的非绑定元宝数量，非系统赠送元宝个数）
	 */
	public void onAddItem(Human human, ItemGenLogReason reason, int itemTemplateId, int itemNum, int originalNum, 
			Currency currency, long totalCost, long actualCost) {
		try {
			if (human == null) {
				printLog("human == null,记录添加道具的财报记录");
				return;
			}

			if (itemNum <= 0) {
				printLog("num <= 0，不能处理使用道具的道具消耗");
				return;
			}

			if (!isMoneyReportOpen) {
				printLog("财报开关已经关闭，不能添加道具的财报记录");
				return;
			}
			// 获得该道具消耗记录
			ItemCostRecord itemCostRecord = getItemCostRecord(human.getCharId(), itemTemplateId);

			// 检查此金钱类型是否为财报所需要的金钱类型
			if (!checkIsReportMoneyType(currency)) {
				// 判断record是不是为空
				if (itemCostRecord == null) {
					printLog("currency is avaialbe to report money onAddItem");
					return;
				}
				int originalItemNum = itemCostRecord.getItemNum();
				long originalTotalCost = itemCostRecord.getTotalCost();
				long originalActualCost = itemCostRecord.getActualCost();
				int originalFreeNum = itemCostRecord.getFreeNum();
				// 如果不是一级货币，只增加freeNum
				itemCostRecord.setFreeNum(itemCostRecord.getFreeNum() + itemNum);

				//记录财报record日志
				this.saveLogRecordLog(human,ItemCostRecordLogReason.MODIFY_ADD_RECORD, originalFreeNum, originalItemNum, originalActualCost, originalTotalCost, itemCostRecord);
			} else {
				// 如果实际消耗为0，并且消耗记录没有则不增加消耗记录
				if (itemCostRecord == null && actualCost <= 0) {
					printLog("itemCostRecord is null and actualCost = 0");
					return;
				}

				// 如果没有该记录则创一条该道具消耗记录 ，并且实际消耗大于0
				if (itemCostRecord == null) {
					itemCostRecord = new ItemCostRecord();
					itemCostRecord.setId(Globals.getUUIDService().getNextUUID(UUIDType.MONEY_REPORT_ITEM_COST));
					itemCostRecord.setCharId(human.getCharId());
					itemCostRecord.setTemplateId(itemTemplateId);
					// 添加道具前此道具原有个数
					// 需要确认OnAddItem 的最终调用
					// 如果OnAddItem 调用在添加道具成功之后 计算此道具原有个数数如下
					if (originalNum > 0) {
						itemCostRecord.setFreeNum(originalNum);
					}
					// 将此道具记录添加到集合中
					setItemCostRecord(human.getCharId(), itemCostRecord);
				}

				/** 计算加成数据道具 **/
				addOnItemCostRecord(human, itemCostRecord,reason, itemNum, totalCost, actualCost);
			}
		} catch (Exception e) {
			printLog(CommonUtil.exceptionToString(e));
		}

	}

	/***
	 * 处理使用道具的道具消耗
	 *
	 * @param human
	 * @param itemTempId
	 * @param num
	 */
	public void onRemoveItem(Human human, ItemLogReason reason, int itemTempId, int num) {
		LocalScribeService scribeService = Globals.getLocalScribeService();
		try {
			if (human == null) {
				printLog("human == null，不能处理使用道具的道具消耗");
				return;
			}

			if (num <= 0) {
				printLog("num <= 0，不能处理使用道具的道具消耗");
				return;
			}

			if (!isMoneyReportOpen) {
				printLog("财报开关已经关闭，处理使用道具的道具消耗");
				return;
			}

			// 获得该道具消耗记录
			ItemCostRecord itemCostRecord = getItemCostRecord(human.getCharId(), itemTempId);

			if (itemCostRecord == null) {
				printLog("没有此道具的消耗记录，不能处理使用道具的道具消耗");
				return;
			}
			int originalItemNum = itemCostRecord.getItemNum();
			long originalTotalCost = itemCostRecord.getTotalCost();
			long originalActualCost = itemCostRecord.getActualCost();
			int originalFreeNum = itemCostRecord.getFreeNum();

			// 先计算免费消耗
			// 获得免费数量
			int freeNum = itemCostRecord.getFreeNum();
			// 如果免费数量大于即将消耗数量，只修正免费数量
			if (num <= freeNum) {
				itemCostRecord.setFreeNum(freeNum - num);
				printLog("消耗免费道具" + num + "个itemTempId=" + itemTempId);
				//记录财报record日志
				this.saveLogRecordLog(human,ItemCostRecordLogReason.MODIFY_REDUCE_RECORD, originalFreeNum, originalItemNum, originalActualCost, originalTotalCost, itemCostRecord);
				return;
			} else {
				// 如果免费数量小于即将消耗数量
				int left = num - freeNum;
				// 免费数量清0
				itemCostRecord.setFreeNum(0);
				// 获得非免费数量
				int itemNum = itemCostRecord.getItemNum();
				// 如果剩余消耗数量大于等于非免费数量，则数量清0，汇报实际消耗，数量为itemNum
				if (left >= itemNum) {
					// 修改非免费数量
					itemCostRecord.setItemNum(0);
					// 修改总价
					itemCostRecord.setTotalCost(0);
					// 修改单价
					itemCostRecord.setActualCost(0);
				} else {
					// 如果剩余消耗数量小于非免费数量，则计算单价，汇报相应数量，单价向下取整，已经做过相应调整，并且单价会大于1，
					// 单价
					long singlePrice = itemCostRecord.getTotalCost() / itemCostRecord.getItemNum();
					// 总共消耗金钱=单价*剩余数量
					long costAllPrice = singlePrice * left;
					// 系统赠送金钱消耗
					long sysCost = itemCostRecord.getTotalCost() - itemCostRecord.getActualCost();
					// 修改非免费数量
					itemCostRecord.setItemNum(itemNum - left);
					// 先消耗系统赠送金钱，如果系统赠送金钱大于等于要消耗的金钱总数，则不需要消耗实际货币
					if (sysCost >= costAllPrice) {
						// 修改总价，不需要修改实际价格，不需要汇报
						itemCostRecord.setTotalCost(itemCostRecord.getTotalCost() - costAllPrice);
					} else {
						// 如果免费金钱小于消耗的金钱总数，免费金钱已经消耗完成，此情况总价=实际消耗货币
						// 计算剩余金钱
						long leftCostPrice = costAllPrice - sysCost;
						long leftActualCost = itemCostRecord.getActualCost() - leftCostPrice;
						// 做个异常处理
						if (leftActualCost <= 0) {
							// XXX 此情况不可能，肯定有异常
							leftActualCost = 0;
							// 修改非免费数量
							itemCostRecord.setItemNum(0);
							// 修改总价
							itemCostRecord.setTotalCost(0);
							// 修改单价
							itemCostRecord.setActualCost(0);
							printLog("汇报系统异常itemTempId=" + itemTempId);
						}
						// 修改总价
						itemCostRecord.setTotalCost(leftActualCost);
						// 修改单价
						itemCostRecord.setActualCost(leftActualCost);
					}
				}
			}
			itemCostRecord.setModified();

			// XXX 汇报财务汇报
			int reportItemNum = originalItemNum - itemCostRecord.getItemNum();
			long reportActualCost = originalActualCost - itemCostRecord.getActualCost();
			long reportTotalCost = originalTotalCost - itemCostRecord.getTotalCost();
			//记录财报record日志
			this.saveLogRecordLog(human,ItemCostRecordLogReason.MODIFY_REDUCE_RECORD, originalFreeNum, originalItemNum, originalActualCost, originalTotalCost, itemCostRecord);
			scribeService.sendScribeGamePropConsumeItemServiceReport(human, reason, itemCostRecord.getTemplateId(), reportItemNum, reportTotalCost, reportActualCost);
//			// 发送kaiying的log
//			Globals.getQQKaiYingLogService().sendPropConsumeItemServiceReport(human.getPlayer(), reason, itemCostRecord.getTemplateId(), reportItemNum, reportTotalCost, reportActualCost);
		} catch (Exception e) {
			printLog(CommonUtil.exceptionToString(e));
		}
	}

	public void saveLogRecordLog(Human human,ItemCostRecordLogReason reason,int originalFreeNum,int originalItemNum,long originalActualCost,long originalTotalCost,ItemCostRecord itemCostRecord){
		if(human == null){
			return;
		}
		if(itemCostRecord == null){
			return;
		}
		if((originalFreeNum - itemCostRecord.getFreeNum()) == 0
				&& (originalItemNum - itemCostRecord.getItemNum()) == 0
				&& (originalActualCost - itemCostRecord.getActualCost()) == 0
				&& (originalTotalCost - itemCostRecord.getTotalCost()) == 0
		){
			//记录没有修改不计log
			return;
		}

		Globals.getLogService().sendItemCostRecordLog(human, reason, reason.getReasonText(), originalFreeNum, originalItemNum, originalTotalCost, originalActualCost, itemCostRecord.getFreeNum(), itemCostRecord.getItemNum(),itemCostRecord.getTotalCost(), itemCostRecord.getActualCost());
	}

	/***
	 * 计算新添加的道具记录
	 *
	 * @param itemCostRecord
	 * @param itemNum
	 * @param totalCost
	 * @param actualCost
	 */
	protected void addOnItemCostRecord(Human human,ItemCostRecord itemCostRecord, ItemGenLogReason reason, int itemNum, long totalCost, long actualCost) {
		LocalScribeService scribeService = Globals.getLocalScribeService();
		if (itemCostRecord == null) {
			return;
		}

		// 加成道具个数
		int originalItemNum = itemCostRecord.getItemNum();
		itemCostRecord.setItemNum(originalItemNum + itemNum);

		// 加成总消耗金钱值
		long originalTotalCost = itemCostRecord.getTotalCost();
		itemCostRecord.setTotalCost(originalTotalCost + totalCost);

		// 加成实际消耗金钱值
		long originalActualCost = itemCostRecord.getActualCost();
		itemCostRecord.setActualCost(originalActualCost + actualCost);

		//原始免费物品
		int originalFreeNum = itemCostRecord.getFreeNum();

		/** 计算单价= 总金钱数/道具个数 */
		float signlePrice = (1.0f * itemCostRecord.getTotalCost()) / itemCostRecord.getItemNum();
		// 在每次添加道具消耗记录的时候 保证道具消耗单价 必须不小于1
		// 在单价小于1的情况下 保持总消耗金钱数不变的情况下 每个道具以1为单价 多余的道具 转移到免费的道具中
		if (signlePrice < 1) {
			// 免费的个数
			int changeTofreeNum = (int)(itemCostRecord.getItemNum() - itemCostRecord.getTotalCost());
			itemCostRecord.setItemNum(itemCostRecord.getItemNum() - changeTofreeNum);
			itemCostRecord.setFreeNum(itemCostRecord.getFreeNum() + changeTofreeNum);
		}
		// 保存道具消耗记录
		itemCostRecord.setModified();

		//XXX 财报
		int reportItemNum = itemCostRecord.getItemNum() - originalItemNum ;
		long reportActualCost = itemCostRecord.getActualCost() - originalActualCost;
		long reportTotalCost = itemCostRecord.getTotalCost() - originalTotalCost;
		long goldLeft = human.getMoney(Currency.BOND);
		MoneyLogReason moneyLogReason = getBindItemReasons().get(reason);

		//记录财报record日志
		this.saveLogRecordLog(human, ItemCostRecordLogReason.MODIFY_ADD_RECORD, originalFreeNum, originalItemNum, originalActualCost, originalTotalCost, itemCostRecord);

		scribeService.sendScribeGamePropBuyItemServiceReport(human, moneyLogReason,itemCostRecord.getTemplateId(), reportItemNum, reportTotalCost, reportActualCost, goldLeft);
		
//		// 发送kaiying的log
//		Globals.getQQKaiYingLogService().sendPropBuyItemServiceReport(human.getPlayer(), moneyLogReason,itemCostRecord.getTemplateId(), reportItemNum, reportTotalCost, reportActualCost, goldLeft);
	}

	public void printLog(String log) {
		if (Loggers.chargeLogger.isInfoEnabled()) {
			Loggers.chargeLogger.info(log);
		} else {
			Loggers.gameLogger.debug(log);
		}
	}

	/***
	 * 检查财报的金钱类型
	 *
	 * @param currency
	 */
	public boolean checkIsReportMoneyType(Currency currency) {

		if (currency == null) {
			return false;
		}

		switch (currency) {
		case GIFT_BOND:
		case BOND:
		case SYS_BOND:
			return true;
		default :
			break;
		}
		return false;
	}

	/***
	 * 获得该玩家的一个道具的消耗记录
	 *
	 * @param charId
	 *            玩家ID
	 * @param itemTemplateId
	 *            道具模版ID
	 */
	public ItemCostRecord getItemCostRecord(long charId, int itemTemplateId) {
		// 获得该玩家所有道具消耗记录的集合
		Map<Integer, ItemCostRecord> itemCostMapByHumanMap = getAllPlayersItemCostRecordMap().get(charId);
		if (itemCostMapByHumanMap == null) {
			return null;
		}

		ItemCostRecord itemCostRecord = itemCostMapByHumanMap.get(itemTemplateId);
		return itemCostRecord;
	}

	/***
	 * 添加玩家一条道具消耗记录
	 *
	 * @param charId
	 * @param itemCostRecord
	 */
	public void setItemCostRecord(long charId, ItemCostRecord itemCostRecord) {
		if (itemCostRecord == null) {
			return;
		}
		// 获得该玩家所有道具消耗记录的集合
		Map<Integer, ItemCostRecord> itemCostMapByHumanMap = getAllPlayersItemCostRecordMap().get(charId);
		if (itemCostMapByHumanMap == null) {
			itemCostMapByHumanMap = new HashMap<Integer, ItemCostRecord>();
			getAllPlayersItemCostRecordMap().put(charId, itemCostMapByHumanMap);
		}
		itemCostMapByHumanMap.put(itemCostRecord.getTemplateId(), itemCostRecord);
	}

}
