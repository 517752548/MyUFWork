package com.imop.lj.gameserver.common.event;

import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.CostSourceEnum;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.CostSourceTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

public class CostMoneyEvent extends Event<Human>{

	/** 玩家角色 */
	private final Human human;
	
	private Currency mainCurrency;
	private Currency altCurrency;
	private Currency thirdCurrency;
	
	private long mainCost;
	private long altCost;
	private long thirdCost;
	
	private MoneyLogReason reason;

	private final static EventType eventType = EventType.CostMoney;
	
	public CostMoneyEvent(Human human, Currency mainCurrency, Currency altCurrency, Currency thirdCurrency,
			long mainCost, long altCost, long thirdCost, MoneyLogReason reason) {
		super(human, eventType);
		this.human = human;
		
		this.mainCurrency = mainCurrency;
		this.altCurrency = altCurrency;
		this.thirdCurrency = thirdCurrency;
		this.mainCost = mainCost;
		this.altCost = altCost;
		this.thirdCost = thirdCost;
		this.reason = reason;
	}

	@Override
	public Human getInfo() {
		return human;
	}

	/**
	 * 获取消耗来源
	 * @return
	 */
	public MoneyLogReason getReason() {
		return reason;
	}

	/**
	 * 获取消耗的元宝和绑定元宝的总数，礼券不算
	 * @return
	 */
	protected long getCostBond() {
		long costBond = 0;
		if (mainCurrency == Currency.BOND || mainCurrency == Currency.SYS_BOND) {
			costBond += mainCost;
		}
		if (altCurrency == Currency.BOND || altCurrency == Currency.SYS_BOND) {
			costBond += altCost;
		}
		if (thirdCurrency == Currency.BOND || thirdCurrency == Currency.SYS_BOND) {
			costBond += thirdCost;
		}
		return costBond;
	}
	
	/**
	 * 获取礼券消耗数，包含绑定元宝和元宝
	 * @return
	 */
	protected long getCostGiftBond() {
		long costGiftBond = 0;
		if (mainCurrency == Currency.BOND || mainCurrency == Currency.SYS_BOND || mainCurrency == Currency.GIFT_BOND) {
			costGiftBond += mainCost;
		}
		if (altCurrency == Currency.BOND || altCurrency == Currency.SYS_BOND || altCurrency == Currency.GIFT_BOND) {
			costGiftBond += altCost;
		}
		if (thirdCurrency == Currency.BOND || thirdCurrency == Currency.SYS_BOND || thirdCurrency == Currency.GIFT_BOND) {
			costGiftBond += thirdCost;
		}
		return costGiftBond;
	}
	
	/**
	 * 获取指定货币类型的消耗数量
	 * 注意：
	 * 1、careCurrency=元宝或绑定元宝，消耗数量=绑定元宝+元宝之和
	 * 2、careCurrency=礼券，消耗数量=礼券+绑定元宝+元宝之和
	 * 3、careCurrency=其他，消耗数量=主货币消耗数量
	 * 
	 * @param careCurrency
	 * @return
	 */
	protected long getCareCurrencyCost(Currency careCurrency) {
		long costNum = 0;
		// 获取关注的货币的消耗数量
		if (careCurrency == Currency.BOND || careCurrency == Currency.SYS_BOND) {
			costNum = getCostBond();
		} else if (careCurrency == Currency.GIFT_BOND) {
			costNum = getCostGiftBond();
		} else {
			// 非礼券、元宝、绑定元宝的，只看主货币，因为这些没有辅助货币
			if (careCurrency == mainCurrency) {
				costNum = mainCost;
			}
		}
		return costNum;
	}
	
	/**
	 * 获取指定货币类型和指定来源的消耗数量
	 * 注意：
	 * 1、careCurrency=元宝或绑定元宝，消耗数量=绑定元宝+元宝之和
	 * 2、careCurrency=礼券，消耗数量=礼券+绑定元宝+元宝之和
	 * 3、careCurrency=其他，消耗数量=主货币消耗数量
	 * 
	 * @param careCurrency
	 * @param careSource
	 * @return
	 */
	public long getCareCurrencyCostNum(Currency careCurrency, CostSourceEnum careSource) {
		long costNum = 0;
		// 检查是否关注的来源，所有来源的话不用做检查
		if (careSource != CostSourceEnum.ALL) {
			if (careSource.getCt() == CostSourceTypeEnum.CONTAIN) {
				// 如果是包含类型，关心集合不包含该reason则返回0
				if (!careSource.getCareReasonSet().contains(getReason())) {
					return costNum;
				}
			} else if (careSource.getCt() == CostSourceTypeEnum.EXCEPT) {
				// 如果是排除类型，关心集合包含该reason则返回0
				if (careSource.getCareReasonSet().contains(getReason())) {
					return costNum;
				}
			}
		}
		
		// 获取关注的货币的消耗数量
		costNum = getCareCurrencyCost(careCurrency);
		return costNum;
	}
}
