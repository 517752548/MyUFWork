package com.imop.lj.gameserver.currency;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.UUID;

import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.CostMoneyEvent;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.localscribe.LocalScribeDef.ScribeItemType;
import com.imop.lj.gameserver.moneyreport.CurrencyCostDetail;

/**
 * 金钱处理器,单实例
 * 
 * 
 */
public enum CurrencyProcessor {

	instance;

	/**
	 * 获得消耗细节，只针对元宝类
	 * @param human
	 * @param amount
	 * @param mainCurrency
	 * @param altCurrency
	 * @param thirdCurrency
	 * @return
	 */
	public CurrencyCostDetail getCurrencyCostDetail(Human human, final long amount, final Currency mainCurrency, final Currency altCurrency, final Currency thirdCurrency) {
		if(!hasEnoughMoney(human, amount, mainCurrency, altCurrency, false)){
			return null;
		}
		
		if (amount < 0 || mainCurrency == null || mainCurrency == Currency.NULL) {
			return null;
		}
		
		long mainCost = 0, altCost = 0, thirdCost = 0;
		// 取玩家身上的钱数
		long mainCurrAmount = getMoney(human, mainCurrency);
		long altCurrAmount = 0;
		long thirdCurrAmount = 0;
		if (mainCurrAmount >= amount) {
			// 只扣主货币就够了
			mainCost = amount;
			altCost = 0;
			thirdCost = 0;
		} else {
			// 需要扣辅助货币，看看够不够
			if (altCurrency != null && altCurrency != Currency.NULL) {
				// 还需要扣这么多辅助货币
				long mainLack = amount - mainCurrAmount;
				altCurrAmount = getMoney(human, altCurrency);
				if (altCurrAmount >= mainLack) {
					// 住货币全部扣掉
					mainCost = mainCurrAmount;
					// 辅助货币扣掉剩下的
					altCost = mainLack;
					thirdCost = 0;
				} else if (thirdCurrency != null && thirdCurrency != Currency.NULL) {
					// 辅助货币不够，第三货币看看够不够
					long altLack = mainLack - altCurrAmount;
					thirdCurrAmount = getMoney(human, thirdCurrency);
					if (thirdCurrAmount >= altLack) {
						// 主货币全部扣掉
						mainCost = mainCurrAmount;
						// 辅助货币全部扣掉
						altCost = altCurrAmount;
						// 第三货币扣掉剩下的
						thirdCost = altLack;
					} else {
						// 辅助货币和第三货币都不够
//						return false;
					}
				} else {
					// 辅助货币不足，且没有第三货币，不够扣
//					return false;
				}
			} else {
				// 没有辅助货币，不够扣
//				return false;
			}
		}
		if (mainCost > 0 || altCost > 0 || thirdCost > 0) {
			CurrencyCostDetail detail = new CurrencyCostDetail();
			// 实际消耗元宝数量为第三货币优先，如果第三货币没有则为第二货币
			long bondCost = thirdCurrency != null ? thirdCost : altCost;
			detail.setActualCost(bondCost);
			
			detail.setTotalCost(amount);
			detail.setCurrency(mainCurrency);
			return detail;
		}
		return null;
	}
	
	/**
	 * 扣钱，如果扣钱的数量为0则抛出{@link IllegalArgumentException}
	 * 
	 * @param human
	 *            玩家角色
	 * @param amount
	 *            扣得数量，>0才有效
	 * @param mainCurrency
	 *            主货币类型，不为NULL/null才有效
	 * @param altCurrency
	 *            替补货币类型，可以为NULL/null
	 * @param needNotify
	 *            是否在该函数内通知玩家货币改变，为true时信息格式为"您花费了xx（货币单位）用于xx"， false时不在本函数内提示
	 * @param usageLangId
	 *            用途多语言Id,如果needNotify为true，这里提供的用途会被加载提示信息“用于”后面
	 * @param reason
	 *            扣钱的原因
	 * @param detailReason
	 *            详细原因，通常为null，扩展使用
	 * @param reportItemId
	 *            向平台汇报贵重物品消耗时的itemTemplateId，非物品的消耗时使用-1
	 * @return 扣钱成功返回true,否则返回false,失败可能是钱已经超出了最大限额,参数不合法等
	 */
	public boolean costMoney(Human human, final long amount, final Currency mainCurrency, final Currency altCurrency, final Currency thirdCurrency, boolean needNotify,
			Integer usageLangId, MoneyLogReason reason, String detailReason, int reportItemId) {
		// 无效参数
		if (amount <= 0 || mainCurrency == null || mainCurrency == Currency.NULL) {
			throw new IllegalArgumentException(String.format(
					"扣钱参数有误：amount=%d mainCurrency=%s altCurrency=%s thirdCurrency=%s reason=%s detailReason=%s reportItemId=%d", amount, mainCurrency, altCurrency, thirdCurrency,
					reason, detailReason, reportItemId));
		}
		long mainCost = 0, altCost = 0, thirdCost = 0;
		// 取玩家身上的钱数
		long mainCurrAmount = getMoney(human, mainCurrency);
		long altCurrAmount = 0;
		long thirdCurrAmount = 0;
		if (mainCurrAmount >= amount) {
			// 只扣主货币就够了
			mainCost = amount;
			altCost = 0;
			thirdCost = 0;
		} else {
			// 需要扣辅助货币，看看够不够
			if (altCurrency != null && altCurrency != Currency.NULL) {
				// 还需要扣这么多辅助货币
				long mainLack = amount - mainCurrAmount;
				altCurrAmount = getMoney(human, altCurrency);
				if (altCurrAmount >= mainLack) {
					// 住货币全部扣掉
					mainCost = mainCurrAmount;
					// 辅助货币扣掉剩下的
					altCost = mainLack;
					thirdCost = 0;
				} else if (thirdCurrency != null && thirdCurrency != Currency.NULL) {
					// 辅助货币不够，第三货币看看够不够
					long altLack = mainLack - altCurrAmount;
					thirdCurrAmount = getMoney(human, thirdCurrency);
					if (thirdCurrAmount >= altLack) {
						// 主货币全部扣掉
						mainCost = mainCurrAmount;
						// 辅助货币全部扣掉
						altCost = altCurrAmount;
						// 第三货币扣掉剩下的
						thirdCost = altLack;
					} else {
						// 辅助货币和第三货币都不够
						return false;
					}
				} else {
					// 辅助货币不足，且没有第三货币，不够扣
					return false;
				}
			} else {
				// 没有辅助货币，不够扣
				return false;
			}
		}
		// 扣钱成功
		long mainLeft = mainCurrAmount, altLeft = altCurrAmount, thirdLeft = thirdCurrAmount;
		if (mainCost > 0) {
			mainLeft = substractAndFixMoney(human, mainCost, mainCurrency);
		}
		if (altCost > 0) {
			altLeft = substractAndFixMoney(human, altCost, altCurrency);
		}
		if (thirdCost > 0) {
			thirdLeft = substractAndFixMoney(human, thirdCost, thirdCurrency);
		}

		if (mainCurrency == Currency.BOND || 
				mainCurrency == Currency.SYS_BOND || 
				altCurrency == Currency.BOND || 
				altCurrency == Currency.SYS_BOND ||
				thirdCurrency == Currency.BOND ||
				thirdCurrency == Currency.SYS_BOND) {
			human.resetAllBand();
		}

		// 实时更新钱
		human.setModified();
		// 更新客户端任务属性
		human.snapChangedProperty(true);

		// 通知
		if (needNotify) {
			if (isNotifyCurrency(mainCurrency) && mainCost > 0) {
				human.sendErrorMessage(LangConstants.CURRENCY_COST_NOTICE, mainCost, 
						Globals.getLangService().readSysLang(mainCurrency.getNameKey()));
			}
			if (isNotifyCurrency(altCurrency) && altCost > 0) {
				human.sendErrorMessage(LangConstants.CURRENCY_COST_NOTICE, altCost, 
						Globals.getLangService().readSysLang(altCurrency.getNameKey()));
			}
			if (isNotifyCurrency(thirdCurrency) && thirdCost > 0) {
				human.sendErrorMessage(LangConstants.CURRENCY_COST_NOTICE, thirdCost, 
						Globals.getLangService().readSysLang(thirdCurrency.getNameKey()));
			}
		}

//		// 汇报贵重物品消耗
//		reportTransrecord(human, mainCurrency, amount, reportItemId, reason);
		
		try {
			// 消耗货币相关事件监听
			CostMoneyEvent event = new CostMoneyEvent(human, mainCurrency, altCurrency, thirdCurrency, 
					mainCost, altCost, thirdCost, reason);
			Globals.getEventService().fireEvent(event);
			
			// TODO 汇报，判断元宝有没有消耗
			long goldActual = 0;
			if (mainCurrency == Currency.BOND) {
				goldActual = mainCost;
			} else if (altCurrency == Currency.BOND) {
				goldActual = altCost;
			} else if (thirdCurrency == Currency.BOND) {
				goldActual = thirdCost;
			}
			if (goldActual > 0) {
				long goldLeft = human.getBond();
				this.reportLocalScribeService(human, reason, detailReason, amount, goldActual, goldLeft);
			}
	
			int altCurrencyIndex = (altCurrency == null ? 0 : altCurrency.index);
			int thirdCurrencyIndex = (thirdCurrency == null ? 0 : thirdCurrency.index);
			// 发送金钱日志
			Globals.getLogService().sendMoneyLog(human, reason, detailReason, mainCurrency.index, -mainCost, mainLeft, 
					altCurrencyIndex, -altCost, altLeft, 
					thirdCurrencyIndex, -thirdCost, thirdLeft
					);
			
			//汇报dataEye
			Globals.getDataEyeService().costMoneyLog(human.getPlayer(), mainCurrency, mainCost, 
					getMoney(human, mainCurrency), reason, detailReason);
			//汇报热云
			Map<Currency, Long> costList = new LinkedHashMap<Currency, Long>();
			costList.put(mainCurrency, mainCost);
			if (altCurrency != null && altCost > 0) {
				costList.put(altCurrency, altCost);
				Globals.getDataEyeService().costMoneyLog(human.getPlayer(), altCurrency, altCost, 
						getMoney(human, altCurrency), reason, detailReason);
			}
			if (thirdCurrency != null && thirdCost > 0) {
				costList.put(thirdCurrency, thirdCost);
				Globals.getDataEyeService().costMoneyLog(human.getPlayer(), thirdCurrency, thirdCost, 
						getMoney(human, thirdCurrency), reason, detailReason);
			}
			Globals.getReyunService().reportCostMoneyList(human.getPlayer(), costList, reason.getReasonText());
			
		} catch (Exception e) {
			Loggers.charLogger.error(LogUtils.buildLogInfoStr(human.getUUID() + "", "记录扣钱日志时出错"), e);
		}
		return true;
	}
	
	protected boolean isNotifyCurrency(Currency currency) {
		if (currency == Currency.BOND || currency == Currency.SYS_BOND 
				|| currency == Currency.GOLD || currency == Currency.GOLD2) {
			return true;
		}
		return false;
	}

	protected long addAndFixMoney(Human human, final long addValue, final Currency currency) {
		int propIndex = currency.getPropIndex();
		long orgMoney = human.getBaseStrProperties().getLong(propIndex);
		long regularNewValue = orgMoney + addValue;
		human.getBaseStrProperties().setLong(propIndex, regularNewValue);
		return regularNewValue;
	}

	public long substractAndFixMoney(Human human, final long subValue, final Currency currency) {
		int propIndex = currency.getPropIndex();
		long orgMoney = human.getBaseStrProperties().getLong(propIndex);
		long maxCanSub = orgMoney - 0; // 金钱下限统一定为0
		long regularNewValue = orgMoney;
		if (subValue > maxCanSub) {
			Loggers.gameLogger.error(LogUtils.buildLogInfoStr(human.getUUID() + "",
					String.format("money not enough orgMoney=%d subValue=%d", orgMoney, subValue)));
			regularNewValue = 0;
		} else {
			regularNewValue = orgMoney - subValue;
		}
		human.getBaseStrProperties().setLong(propIndex, regularNewValue);
		return regularNewValue;
	}

	/**
	 * 给钱
	 * 
	 * @param human
	 *            玩家角色
	 * @param amount
	 *            改变数量，>0才有效
	 * @param currency
	 *            货币类型
	 * @param needNotify
	 *            是否在该函数内通知玩家货币改变，为true时信息格式为"您获得xx（货币单位）"， false时不在本函数内提示
	 * @param reason
	 *            给钱原因
	 * @param detailReason
	 *            详细原因，通常为null，扩展使用
	 * @param consumeDescs
	 *            返回给调用者的货币改变信息
	 * @return 给钱成功返回true,否则返回false,失败可能是钱已经超出了最大限额,参数不合法等
	 */
	public boolean giveMoney(Human human, final long amount, final Currency currency, boolean needNotify, MoneyLogReason reason, String detailReason, boolean noticeClient) {
		// 无效参数
		if (amount <= 0 || currency == null || currency == Currency.NULL) {
			throw new IllegalArgumentException(String.format("给钱参数有误：amount=%d currency=%s reason=%s detailReason=%s", amount, currency, reason,
					detailReason));
		}

		// TODO 根据货币产生原因,再判断是否超过该类货币上限,进行操作限制
		long newAmount = addAndFixMoney(human, amount, currency);

		if (currency == Currency.BOND || currency == Currency.SYS_BOND) {
			human.resetAllBand();
		}

		// 实时更新钱
		human.setModified();
		// 更新客户端任务属性
		if (noticeClient) {
			human.snapChangedProperty(true);
		}

		// 通知
		if (needNotify) {
			// XXX 先都注掉，客户端自己冒
//			human.sendSystemMessage(LangConstants.GIVE_MONEY_REASON, amount,Globals.getLangService().readSysLang(currency.getNameKey()));
		}

		// 发送金钱日志
		try {
			Globals.getLogService().sendMoneyLog(human, reason, detailReason, currency.index, amount, newAmount, 0, 0, 0, 0, 0, 0);
			
			//dataeye数据汇报
			Globals.getDataEyeService().giveMoneyLog(human.getPlayer(), currency, amount, newAmount, reason, detailReason);
			
			//汇报热云
			Globals.getReyunService().reportAddMoney(human.getPlayer(), currency, amount, reason.getReasonText());
		} catch (Exception e) {
			Loggers.charLogger.error(LogUtils.buildLogInfoStr(human.getUUID() + "", "记录给钱日志时出错"), e);
		}
		return true;
	}

	/**
	 * 检查玩家是否足够指定货币，如果替补货币为NULL/null则只检查主货币，主货币不可以为NULL/null
	 * 
	 * @param human
	 *            玩家角色
	 * @param amount
	 *            数量，>=0才有效，==0时永远返回true
	 * @param mainCurrency
	 *            主货币类型
	 * @param altCurrency
	 *            替补货币类型，为NULL/null时只检测主货币
	 * @param needNotify
	 *            是否需要通知，如果为true则当返回false时会提示，您的xxx（主货币名称）不足
	 * @return 
	 *         如果主货币够amount返回true，主货币不够看替补货币够不够除现有主货币外剩下的，够也返回true，加起来都不够返回false，
	 *         参数无效也会返回false
	 */
	public boolean hasEnoughMoney(Human human, final long amount, final Currency mainCurrency, final Currency altCurrency, boolean needNotify) {
		if (amount < 0 || mainCurrency == null || mainCurrency == Currency.NULL) {
			return false;
		}
		long mainCurrAmount = getMoney(human, mainCurrency);
		if (mainCurrAmount >= amount) {
			// 主货币就足够了
			return true;
		} else if (altCurrency == null || altCurrency == Currency.NULL) {
			// 主货币不足，没有替补货币，就不够了
			if (needNotify) {
				human.sendSystemMessage(LangConstants.COMMON_NOT_ENOUGH, Globals.getLangService().readSysLang(mainCurrency.getNameKey()));
			}
			return false;
		} else {
			// 还缺多少钱
			long lack = amount - mainCurrAmount;
			long altCurrAmount = getMoney(human, altCurrency);
			if (altCurrAmount >= lack) {
				// 辅助货币够
				return true;
			} else {
				// 辅助货币不够
				if (needNotify) {
					human.sendSystemMessage(LangConstants.COMMON_NOT_ENOUGH, Globals.getLangService().readSysLang(mainCurrency.getNameKey()));
				}
				return false;
			}
		}
	}

	/**
	 * 查询玩家身上有多少钱，或得玩家钱币需要封装，钱币操作提供相关接口
	 * 
	 * @param human
	 *            玩家角色
	 * @param currency
	 *            货币类型
	 * @return 钱的数量
	 */
	protected long getMoney(Human human, final Currency currency) {
		int propIndex = currency.getPropIndex();
		return human.getBaseStrProperties().getLong(propIndex);
	}

	/**
	 * 报告贵重物品消耗（只记录了钻石的消耗）
	 * 
	 * @param human
	 *            角色
	 * @param currency
	 *            货币类型
	 * @param amount
	 *            消耗货币数量
	 * @param reportItemId
	 *            temTemplateId，非物品的消耗时使用-1
	 * @param reason
	 *            扣钱的原因
	 */
	protected void reportTransrecord(Human human, Currency currency, long amount, int reportItemId, MoneyLogReason reason) {
		if (currency == Currency.BOND) {
			if (reportItemId < 0) {
				reportItemId = reason.reason;
			}

			String orderId = UUID.randomUUID().toString();

			if (Globals.getServerConfig().isTurnOnLocalInterface()) {
				try {
					//XXX 强制转换amount 因为元宝不可能消耗20亿
					Globals.getAsyncLocalService().reportTransRecord(orderId, human.getPlayer().getPassportId(), String.valueOf(human.getUUID()),
							(int)amount, String.valueOf(reportItemId), human.getPlayer().getClientIp());
				} catch (Exception e) {
					Loggers.gameLogger.error(LogUtils.buildLogInfoStr(human.getUUID() + "", "汇报贵重物品时异常"), e);
				}
			}
		}
	}

	/**
	 * 消耗元宝时汇报给local
	 * @param human
	 * @param reason
	 * @param detailReason
	 * @param price
	 * @param goldActual
	 * @param goldLeft
	 */
	protected void reportLocalScribeService(Human human, MoneyLogReason reason, String detailReason, long price, long goldActual, long goldLeft) {
		//服务消耗，抛去商城购买
		if(!Globals.getMoneyReportService().getBindItemReasons().containsValue(reason)){
			if(!Globals.getMoneyReportService().getBindEnternalReasons().contains(reason)){
				Globals.getLocalScribeService().sendScribeGamePropBuyServiceReport(human,ScribeItemType.SERVICE, reason,detailReason, price, goldActual, goldLeft);
				Globals.getLocalScribeService().sendScribeGamePropConsumeServiceReport(human,ScribeItemType.SERVICE, reason,detailReason, price, goldActual);
				
//				// kaiying的汇报
//				Globals.getQQKaiYingLogService().sendPropBuyServiceReport(human.getPlayer(),ScribeItemType.SERVICE, reason,detailReason, price, goldActual, goldLeft);
//				Globals.getQQKaiYingLogService().sendPropConsumeServiceReport(human.getPlayer(),ScribeItemType.SERVICE, reason, detailReason, price, goldActual);
			}else{
//				long originalEternalCostMoney = human.getEternalCostMoney();
//				human.setEternalCostMoney((originalEternalCostMoney + goldActual));
				Globals.getLocalScribeService().sendScribeGamePropBuyServiceReport(human,ScribeItemType.ETERNAL, reason,detailReason, price, goldActual, goldLeft);
				Globals.getLocalScribeService().sendScribeGamePropConsumeServiceReport(human,ScribeItemType.ETERNAL, reason,detailReason, price, goldActual);
				
//				// kaiying的汇报
//				Globals.getQQKaiYingLogService().sendPropBuyServiceReport(human.getPlayer(), ScribeItemType.ETERNAL, reason,detailReason, price, goldActual, goldLeft);
//				Globals.getQQKaiYingLogService().sendPropConsumeServiceReport(human.getPlayer(),ScribeItemType.ETERNAL, reason, detailReason, price, goldActual);
			}
		}
	}
}
