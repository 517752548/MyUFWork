package com.imop.lj.gameserver.goodactivity.userdatamodel.impl;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.PlayerChargeDiamondEvent;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.target.impl.DayTotalChargeTargetUnit;
import com.imop.lj.gameserver.goodactivity.useractivity.impl.DayTotalChargeUserGoodActivity;
import com.imop.lj.gameserver.goodactivity.userdatamodel.AbstractGoodActivityUserDataModel;
import com.imop.lj.gameserver.human.event.Event;
import com.imop.lj.gameserver.human.event.EventType;

/**
 * 每日累计充值活动玩家数据对象类
 * @author yu.zhao
 *
 */
public class DayTotalChargeUserDataModel extends AbstractGoodActivityUserDataModel {

	public static EventType BIND_EVENT_TYPE = EventType.PlayerChargeDiamondEvent;
	
	public static final String TOTAY_TOTAL_CHARGE_KEY = "1";
	public static final String LAST_UPDATE_CHARGE_TIME_KEY = "2";
	public static final String CHARGE_DAY_MAP_KEY = "3";
	public static final String DAY_CHARGE_INFO_KEY = "4";
	public static final String DAY_CHARGE_INFO_NUM_KEY = "5";
	public static final String DAY_CHARGE_INFO_TIME_KEY = "6";
	
	/** 今日累计充值数量 */
	protected int toadyTotalCharge;
	/** 最后一次更新toadyTotalCharge的时间 */
	protected long lastUpdateChargeTime;
	/** 每个目标对应的达成天数数据Map<目标Id，达成天数数据> */
	protected Map<Integer, DayChargeInfo> chargeDayMap = new HashMap<Integer, DayChargeInfo>(); 
	
	public DayTotalChargeUserDataModel(DayTotalChargeUserGoodActivity userActivity) {
		super(userActivity);
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
		
		PlayerChargeDiamondEvent event = (PlayerChargeDiamondEvent) e;
		int chargeNum = event.getChargeDiamond();
		if (chargeNum <= 0) {
			return updateFlag;
		}
		
		updateFlag = onCharge(chargeNum);
		return updateFlag;
	}
	
	/**
	 * 充值时更新相关数据
	 * @param chargeNum
	 * @return
	 */
	protected boolean onCharge(int chargeNum) {
		long now = Globals.getTimeService().now();
		// 如果最后一次更新充值时间和现在不是一天，则需要重新计数
		if (!TimeUtils.isSameDay(now, lastUpdateChargeTime)) {
			toadyTotalCharge = chargeNum;
			lastUpdateChargeTime = now;
		} else {
			// 是同一天，充值数累计
			toadyTotalCharge += chargeNum;
		}
		
		Collection<AbstractGoodActivityTargetUnit> targetList = getUserActivity().getGoodActivity().getTargetList();
		for (AbstractGoodActivityTargetUnit target : targetList) {
			DayTotalChargeTargetUnit curTarget = (DayTotalChargeTargetUnit) target;
			int targetId = curTarget.getTargetId();
			int needChargeNum = curTarget.getChargeNum();
			int needDayNum = curTarget.getDayNum();
			// 该类奖励只有能领取一次，所以如果还有未领取的奖励就不再处理了
			if (hasUnGiveBonus(targetId)) {
				continue;
			}
			// 如果充值数量满足，且今天还未更新过，则计数+1
			if (toadyTotalCharge >= needChargeNum) {
				DayChargeInfo dcInfo = chargeDayMap.get(targetId);
				if (null == dcInfo) {
					dcInfo = new DayChargeInfo();
					chargeDayMap.put(targetId, dcInfo);
				}
				// 如果最后一次更新天数的时间和现在不是一天，则计数+1，即每天最多+1
				if (!TimeUtils.isSameDay(now, dcInfo.getLastUpdateDayNumTime())) {
					dcInfo.setDayNum(dcInfo.getDayNum() + 1);
				}
				if (dcInfo.getDayNum() >= needDayNum) {
					setReachNumOne(targetId);
				}
			}
		}
		// 存库
		save();
		// 只要充值就得记录玩家数据，所以直接返回true
		return true;
	}
	
	@Override
	public int getCurNum(int targetId) {
		int dayNum = 0;
		// 取达成的天数
		DayChargeInfo dcInfo = chargeDayMap.get(targetId);
		if (null != dcInfo) {
			dayNum = dcInfo.getDayNum();
		}
		return dayNum;
	}
	
	@Override
	public int getCurNumSecond(int targetId) {
		int chargeNum = 0;
		AbstractGoodActivityTargetUnit target = getUserActivity().getGoodActivity().getTargetUnit(targetId);
		if (null != target) {
			DayTotalChargeTargetUnit curTarget = (DayTotalChargeTargetUnit) target;
			int needDayNum = curTarget.getDayNum();
			int needChargeNum = curTarget.getChargeNum();
			
			int dayNum = 0;
			long dayNumTime = 0;
			DayChargeInfo dcInfo = chargeDayMap.get(targetId);
			if (null != dcInfo) {
				dayNum = dcInfo.getDayNum();
				dayNumTime = dcInfo.getLastUpdateDayNumTime();
			}
			
			long now = Globals.getTimeService().now();
			// 还差一天达到指定天数
			if (dayNum == needDayNum - 1) {
				// 如果上次达到天数的时间不是今天（即昨天或更以前），且最后一次充值时间是今天，则显示充值进度（这时今天才有可能达成这个目标的条件）
				if (!TimeUtils.isSameDay(now, dayNumTime) && 
						TimeUtils.isSameDay(now, lastUpdateChargeTime)) {
					chargeNum = toadyTotalCharge;
				}
			}
			
			// 如果天数已经达成了，则满足条件了，数量显示为需求数量
			if (dayNum >= needDayNum) {
				chargeNum = needChargeNum;
			}
		}
		return chargeNum;
	}
	
	@Override
	public String paramToJsonStr() {
		JSONObject jsonObj = new JSONObject();
		jsonObj.put(TOTAY_TOTAL_CHARGE_KEY, toadyTotalCharge);
		jsonObj.put(LAST_UPDATE_CHARGE_TIME_KEY, lastUpdateChargeTime);
		
		JSONArray jsonArr = new JSONArray();
		for (Entry<Integer, DayChargeInfo> entry : chargeDayMap.entrySet()) {
			JSONObject json = new JSONObject();
			if (null == entry.getValue()) {
				continue;
			}
			json.put(DAY_CHARGE_INFO_KEY, entry.getKey());
			json.put(DAY_CHARGE_INFO_NUM_KEY, entry.getValue().getDayNum());
			json.put(DAY_CHARGE_INFO_TIME_KEY, entry.getValue().getLastUpdateDayNumTime());
			jsonArr.add(json);
		}
		jsonObj.put(CHARGE_DAY_MAP_KEY, jsonArr);
		
		return jsonObj.toString();
	}
	
	@Override
	public void paramFromJson(String jsonStr) {
		if (null == jsonStr || jsonStr.equalsIgnoreCase("")) {
			return;
		}
		JSONObject jsonObj = JSONObject.fromObject(jsonStr);
		if (null == jsonObj || jsonObj.isNullObject() || jsonObj.isEmpty()) {
			return;
		}
		
		toadyTotalCharge = JsonUtils.getInt(jsonObj, TOTAY_TOTAL_CHARGE_KEY);
		lastUpdateChargeTime = JsonUtils.getLong(jsonObj, LAST_UPDATE_CHARGE_TIME_KEY);
		JSONArray jsonArr = JsonUtils.getJSONArray(jsonObj, CHARGE_DAY_MAP_KEY);
		if (null == jsonArr || jsonArr.isEmpty()) {
			return;
		}
		for (int i = 0; i < jsonArr.size(); i++) {
			JSONObject json = jsonArr.getJSONObject(i);
			if (null == json || json.isNullObject() || json.isEmpty()) {
				continue;
			}
			int k = JsonUtils.getInt(json, DAY_CHARGE_INFO_KEY);
			int dayNum = JsonUtils.getInt(json, DAY_CHARGE_INFO_NUM_KEY);
			long time = JsonUtils.getLong(json, DAY_CHARGE_INFO_TIME_KEY);
			DayChargeInfo dcInfo = new DayChargeInfo();
			dcInfo.setDayNum(dayNum);
			dcInfo.setLastUpdateDayNumTime(time);
			chargeDayMap.put(k, dcInfo);
		}
	}
	
	/**
	 * 达成天数对象
	 * @author yu.zhao
	 *
	 */
	protected static class DayChargeInfo {
		/** 达成的天数 */
		protected int dayNum;
		/** 最后一次更新天数的时间 */
		protected long lastUpdateDayNumTime;
		
		public int getDayNum() {
			return dayNum;
		}
		
		public void setDayNum(int dayNum) {
			this.dayNum = dayNum;
			setLastUpdateDayNumTime(Globals.getTimeService().now());
		}
		
		public long getLastUpdateDayNumTime() {
			return lastUpdateDayNumTime;
		}
		
		public void setLastUpdateDayNumTime(long lastUpdateDayNumTime) {
			this.lastUpdateDayNumTime = lastUpdateDayNumTime;
		}
	}
	
	@Override
	public boolean needHideOnNothingToDo() {
		return true;
	}
}
