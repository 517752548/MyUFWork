package com.imop.lj.gameserver.goodactivity.userdatamodel.impl;

import java.util.Collection;

import com.imop.lj.gameserver.common.event.CostMoneyEvent;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.CostSourceEnum;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.target.impl.TotalCostTargetUnit;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.TotalCostUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 累计消耗活动玩家数据对象类
 * @author yu.zhao
 *
 */
public class TotalCostUserDataModel extends AbstractGoodActivityUserDataModel {

	public static EventType BIND_EVENT_TYPE = EventType.CostMoney;
	
	/** 累计消耗的货币类型 */
	protected Currency careCurrency;
	protected CostSourceEnum careSource;
	
	/** 累计消耗数 */
	protected long totalCost;
	
	public TotalCostUserDataModel(TotalCostUserGoodActivity userActivity) {
		super(userActivity);
		// 初始化货币类型
		initCurrencyId();
	}
	
	protected void initCurrencyId() {
		// 以目标列表的第一个为准，也就是目标列表的每一个货币类型必须相同
		Collection<AbstractGoodActivityTargetUnit> targetList = getUserActivity().getGoodActivity().getTargetList();
		for (AbstractGoodActivityTargetUnit target : targetList) {
			TotalCostTargetUnit curTarget = (TotalCostTargetUnit) target;
			careCurrency = curTarget.getCurrency();
			careSource = curTarget.getCostSource();
			break;
		}
	}
	
	@Override
	public EventType getBindEventType() {
		return BIND_EVENT_TYPE;
	}
	
	@Override
	public boolean onPlayerDoEvent(Event<?> e) {
		boolean updateFlag = false;
		if (!isCareEvent(e)) {
			return updateFlag;
		}
		
		CostMoneyEvent event = (CostMoneyEvent) e;
		long costNum = event.getCareCurrencyCostNum(careCurrency, careSource);
		if (costNum <= 0) {
			return updateFlag;
		}
		
		updateFlag = onCost(costNum);
		return updateFlag;
	}
	
	/**
	 * 消耗货币时更新数据
	 * @param costNum
	 * @return
	 */
	protected boolean onCost(long costNum) {
		// 累计消耗数
		totalCost += costNum;
		Collection<AbstractGoodActivityTargetUnit> targetList = getUserActivity().getGoodActivity().getTargetList();
		for (AbstractGoodActivityTargetUnit target : targetList) {
			TotalCostTargetUnit curTarget = (TotalCostTargetUnit) target;
			int targetId = curTarget.getTargetId();
			// 获取每个档位需要的消耗数量 
			int needNum = curTarget.getCostNum();
			if (totalCost >= needNum) {
				// 消耗数量满足对应的档位需求，则可领奖
				setReachNumOne(targetId);
			} else {
				break;
			}
		}
		// 存库
		save();
		// 消耗了就得计数，并创建玩家数据，所以直接返回true
		return true;
	}
	
	@Override
	public int getCurNum(int targetId) {
		return totalCost < Integer.MAX_VALUE ? (int)totalCost : Integer.MAX_VALUE;
	}
	
	@Override
	public String paramToJsonStr() {
		// 需要记录消耗数
		return totalCost + "";
	}
	
	@Override
	public void paramFromJson(String jsonStr) {
		if (null == jsonStr || jsonStr.equalsIgnoreCase("")) {
			return;
		}
		totalCost = Integer.parseInt(jsonStr);
	}
}
