package com.imop.lj.gameserver.goodactivity.userdatamodel.impl;

import java.util.Collection;

import com.imop.lj.gameserver.common.event.CostMoneyEvent;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.CostSourceEnum;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.target.impl.EveryCostTargetUnit;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.EveryCostUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 每累计消耗活动玩家数据对象类
 * @author yu.zhao
 *
 */
public class EveryCostUserDataModel extends AbstractGoodActivityUserDataModel {

	public static EventType BIND_EVENT_TYPE = EventType.CostMoney;
	
	/** 累计消耗的货币类型 */
	protected Currency careCurrency;
	protected CostSourceEnum careSource;
	
	/** 累计消耗数 */
	protected long totalCost;
	
	public EveryCostUserDataModel(EveryCostUserGoodActivity userActivity) {
		super(userActivity);
		// 初始化货币类型
		initCurrencyId();
	}
	
	protected void initCurrencyId() {
		// 以目标列表的第一个为准，也就是目标列表的每一个货币类型必须相同
		Collection<AbstractGoodActivityTargetUnit> targetList = getUserActivity().getGoodActivity().getTargetList();
		for (AbstractGoodActivityTargetUnit target : targetList) {
			EveryCostTargetUnit curTarget = (EveryCostTargetUnit) target;
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
			EveryCostTargetUnit curTarget = (EveryCostTargetUnit) target;
			int targetId = curTarget.getTargetId();
			// 已经达到条件的次数
			int reachNum = getReachNum(targetId);
			// 未达到次数上限
			if (reachNum < curTarget.getMaxRewardTimes()) {
				// 获取每个档位需要的消耗数量 
				int needNum = curTarget.getCostNum();
				int shouldNum = (int)(totalCost / needNum);
				int addReachNum = Math.min(shouldNum, curTarget.getMaxRewardTimes()) - reachNum;
				if (addReachNum > 0) {
					addReachNum(targetId, addReachNum);
				}
			}
		}
		// 存库
		save();
		// 消耗就记录并存库，所以直接返回true
		return true;
	}
	
	@Override
	public int getCurNum(int targetId) {
		return getReachNum(targetId);
	}
	
	@Override
	public int getCurNumSecond(int targetId) {
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
