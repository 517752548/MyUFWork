package com.imop.lj.gameserver.goodactivity.userdatamodel;

import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.goodactivity.target.AbstractGoodActivityTargetUnit;
import com.imop.lj.gameserver.goodactivity.useractivity.AbstractUserGoodActivity;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.event.Event;

/**
 * 玩家活动数据对象抽象类
 * @author yu.zhao
 *
 */
public abstract class AbstractGoodActivityUserDataModel implements IGoodActivityUserDataModel {
	/** 目标对象key */
	public static final String T_KEY = "1";
	/** 其他参数key */
	public static final String P_KEY = "2";
	
	public static final String TARGET_KEY = "1";
	public static final String TARGET_VALUE = "2";
	public static final String TARGET_INFO_REACH_NUM = "3";
	public static final String TARGET_INFO_BONUS_NUM = "4";
	public static final String TARGET_INFO_UPDATE_REACH_NUM_TIME = "5";
	public static final String TARGET_INFO_UPDATE_BONUS_NUM_TIME = "6";
	
	/** 目标对象，用于记录玩家相应目标Id已达成次数和已领奖次数  Map<目标Id，计数对象> */
	protected Map<Integer, TargetInfo> targetMap = new LinkedHashMap<Integer, TargetInfo>();
	
	/** 所属的玩家活动对象 */
	private AbstractUserGoodActivity userActivity;
	
	public AbstractGoodActivityUserDataModel(AbstractUserGoodActivity userActivity) {
		this.userActivity = userActivity;
	}
	
	public AbstractUserGoodActivity getUserActivity() {
		return userActivity;
	}
	
	public Map<Integer, TargetInfo> getTargetMap() {
		return targetMap;
	}
	
	/**
	 * 是否关心的事件
	 */
	@Override
	public boolean isCareEvent(Event<?> event) {
		if (event.getType() == getBindEventType()) {
			return true;
		}
		return false;
	}
	
	/**
	 * 自动加入活动/登录时，进行的数据更新，一些特殊的活动如等级排名、vip等级等需要
	 * 注意：需要保证奖励不能重复给，因为每次登录都会触发autoJoin
	 */
	@Override
	public boolean autoJoin(Human human) {
		return false;
	}
	
	/**
	 * 直接达成指定目标
	 * @param targetId
	 * @return
	 */
	public boolean directReachTarget(int targetId) {
		// 默认不做任何处理
		return false;
	}
	
	/**
	 * 存库
	 */
	public void save() {
		if (null != getUserActivity().getGoodActivityUserPO()) {
			getUserActivity().getGoodActivityUserPO().setModified();
		}
	}
	
	/**
	 * 获取指定目标的已达成数，即进度条的分子
	 * @return
	 */
	public int getCurNum(int targetId) {
		return 0;
	}
	
	/**
	 * 获取指定目标的第二个条件的已达成数，即进度条的分子
	 * @return
	 */
	public int getCurNumSecond(int targetId) {
		return 0;
	}
	
	/**
	 * 其他参数转为json串
	 * @return
	 */
	public String paramToJsonStr() {
		return "";
	}
	
	/**
	 * 其他参数从json串解析
	 * @param jsonStr
	 */
	public void paramFromJson(String jsonStr) {
		return;
	}
	
	/**
	 * 玩家该活动是否有可领取的奖励
	 * 注：如果没在可领奖阶段，则视为不能领奖
	 * @return
	 */
	@Override
	public boolean hasBonus() {
		boolean flag = false;
		// 如果没在可领奖阶段，则视为不能领奖
		if (userActivity.getGoodActivity().isInGiveBonusState()) {
			for (TargetInfo targetInfo : targetMap.values()) {
				flag |= hasUnGiveBonus(targetInfo.getTargetId());
				if (flag) {
					break;
				}
			}
		}
		return flag;
	}
	
	/**
	 * 给奖励时，增加给奖励的计数
	 */
	@Override
	public boolean onGiveBonus(int targetId, int giveBonusNum) {
		if (hasUnGiveBonus(targetId)) {
			// 领取奖励的次数+1
			TargetInfo targetInfo = targetMap.get(targetId);
			targetInfo.setGiveBonusNum(targetInfo.getGiveBonusNum() + giveBonusNum);
			// 存库
			save();
			return true;
		}
		return false;
	}
	
	/**
	 * 是否有未领取的奖励
	 */
	@Override
	public boolean hasUnGiveBonus(int targetId) {
		TargetInfo targetInfo = targetMap.get(targetId);
		if (targetInfo != null && 
				targetInfo.getReachNum() > targetInfo.getGiveBonusNum()) {
			return true;
		}
		return false;
	}
	
	/**
	 * 是否已领取过奖励
	 */
	@Override
	public boolean hasGiveReward(int targetId) {
		TargetInfo targetInfo = targetMap.get(targetId);
		if (targetInfo != null && 
				targetInfo.getGiveBonusNum() > 0) {
			return true;
		}
		return false;
	}
	
	/**
	 * 获取指定目标未领取的奖励个数
	 * @param targetId
	 * @return
	 */
	public int getUnGiveBonusNum(int targetId) {
		int num = 0;
		TargetInfo targetInfo = targetMap.get(targetId);
		if (targetInfo != null) {
			num = targetInfo.getReachNum() - targetInfo.getGiveBonusNum();
		}
		if (num < 0) {
			num = 0;
		}
		return num;
	}
	
	/**
	 * 获取指定目标达到条件的次数
	 * @param targetId
	 * @return
	 */
	public int getReachNum(int targetId) {
		int num = 0;
		TargetInfo targetInfo = targetMap.get(targetId);
		if (targetInfo != null) {
			num = targetInfo.getReachNum();
		}
		return num;
	}
	
	/**
	 * 将达成条件的次数设为1，针对只能领取一次奖励的目标
	 * @param targetId
	 * @return
	 */
	protected boolean setReachNumOne(int targetId) {
		TargetInfo targetInfo = targetMap.get(targetId);
		if (null == targetInfo) {
			targetInfo = new TargetInfo(targetId);
			targetMap.put(targetId, targetInfo);
		}
		if (targetInfo.getReachNum() <= 0) {
			// 该种奖励只能领取一次，所以只设置为1
			targetInfo.setReachNum(1);
			return true;
		}
		return false;
	}
	
	/**
	 * 达成条件的次数+1，针对可领取多次奖励的目标
	 * @param targetId
	 * @return
	 */
	public boolean addReachNum(int targetId) {
		TargetInfo targetInfo = targetMap.get(targetId);
		if (null == targetInfo) {
			targetInfo = new TargetInfo(targetId);
			targetMap.put(targetId, targetInfo);
		}
		targetInfo.setReachNum(targetInfo.getReachNum() + 1);
		return true;
	}
	
	/**
	 * 达成条件的次数+n，针对可领取多次奖励的目标
	 * @param targetId
	 * @return
	 */
	protected boolean addReachNum(int targetId, int addNum) {
		TargetInfo targetInfo = targetMap.get(targetId);
		if (null == targetInfo) {
			targetInfo = new TargetInfo(targetId);
			targetMap.put(targetId, targetInfo);
		}
		targetInfo.setReachNum(targetInfo.getReachNum() + addNum);
		return true;
	}
	
//	/**
//	 * 获取消耗货币类的关注来源和关注货币消耗数量，仅消耗货币类活动有用
//	 * @param careCurrency
//	 * @param event
//	 * @return
//	 */
//	protected long getCareCurrencyCostNum(Currency careCurrency, CostSourceEnum careSource, CostMoneyEvent event) {
//		long costNum = 0;
//		// 检查是否关注的来源，所有来源的话不用做检查
//		if (careSource != CostSourceEnum.ALL) {
//			if (careSource.getCt() == CostSourceTypeEnum.CONTAIN) {
//				// 如果是包含类型，关心集合不包含该reason则返回0
//				if (!careSource.getCareReasonSet().contains(event.getReason())) {
//					return costNum;
//				}
//			} else if (careSource.getCt() == CostSourceTypeEnum.EXCEPT) {
//				// 如果是排除类型，关心集合包含该reason则返回0
//				if (careSource.getCareReasonSet().contains(event.getReason())) {
//					return costNum;
//				}
//			}
//		}
//		
//		// 获取关注的货币的消耗数量
//		costNum = event.getCareCurrencyCost(careCurrency);
//		return costNum;
//	}
	
	@Override
	public boolean checkOnFinishTarget(long goodActivityId, int finishTargetId) {
		return false;
	}
	
	/**
	 * 活动是否已经都做完，没有可做的了
	 * @return
	 */
	public boolean hasNothingToDo() {
		if (!needHideOnNothingToDo()) {
			return false;
		}
		
		//所有目标的奖励都领取过了，就没有什么可干的了
		for (AbstractGoodActivityTargetUnit target : getUserActivity().getGoodActivity().getTargetList()) {
			if (!hasGiveReward(target.getTargetId())) {
				return false;
			}
		}
		return true;
	}
	
	/**
	 * 活动是否需要在【没有可做的了】时隐藏掉
	 * @return
	 */
	public boolean needHideOnNothingToDo() {
		return false;
	}
	
	/**
	 * 玩家目标数据及其它参数转为json串
	 */
	@Override
	public String userDataToJson() {
		JSONObject json = new JSONObject();
		
		// targetMap
		JSONArray jsonArr = new JSONArray();
		for (Entry<Integer, TargetInfo> entry : targetMap.entrySet()) {
			JSONObject jsonObj = new JSONObject();
			jsonObj.put(TARGET_KEY, entry.getKey());
			
			JSONObject targetInfoJsonObj = new JSONObject();
			targetInfoJsonObj.put(TARGET_INFO_REACH_NUM, entry.getValue().getReachNum());
			targetInfoJsonObj.put(TARGET_INFO_BONUS_NUM, entry.getValue().getGiveBonusNum());
			targetInfoJsonObj.put(TARGET_INFO_UPDATE_REACH_NUM_TIME, entry.getValue().getLastUpdateReachNumTime());
			targetInfoJsonObj.put(TARGET_INFO_UPDATE_BONUS_NUM_TIME, entry.getValue().getLastUpdateGiveBonusNumTime());
			
			jsonObj.put(TARGET_VALUE, targetInfoJsonObj);
			jsonArr.add(jsonObj);
		}
		
		// param
		String paramJson = paramToJsonStr();
		
		json.put(T_KEY, jsonArr);
		json.put(P_KEY, paramJson);
		return json.toString();
	}
	
	/**
	 * json串转为玩家目标对象及其它参数
	 */
	@Override
	public void userDataFromJson(String jsonStr) {
		if (null == jsonStr || jsonStr.equalsIgnoreCase("")) {
			return;
		}
		JSONObject json = JSONObject.fromObject(jsonStr);
		if (json.isNullObject() || json.isEmpty()) {
			return;
		}
		
		// targetMap
		JSONArray jsonArr = JsonUtils.getJSONArray(json, T_KEY);
		if (null != jsonArr && !jsonArr.isEmpty()) {
			for (int i = 0; i < jsonArr.size(); i++) {
				JSONObject jsonObj = JSONObject.fromObject(jsonArr.get(i));
				int key = JsonUtils.getInt(jsonObj, TARGET_KEY);
				
				JSONObject targetInfoJsonObj = JsonUtils.getJSONObject(jsonObj, TARGET_VALUE);
				int reachNum = JsonUtils.getInt(targetInfoJsonObj, TARGET_INFO_REACH_NUM);
				int giveBonusNum = JsonUtils.getInt(targetInfoJsonObj, TARGET_INFO_BONUS_NUM);
				long lastUpdateReachNumTime = JsonUtils.getLong(targetInfoJsonObj, TARGET_INFO_UPDATE_REACH_NUM_TIME);
				long lastUpdateGiveBonusNumTime = JsonUtils.getLong(targetInfoJsonObj, TARGET_INFO_UPDATE_BONUS_NUM_TIME);
				TargetInfo targetInfo = new TargetInfo(key, reachNum, giveBonusNum);
				targetInfo.setLastUpdateReachNumTime(lastUpdateReachNumTime);
				targetInfo.setLastUpdateGiveBonusNumTime(lastUpdateGiveBonusNumTime);
				targetMap.put(key, targetInfo);
			}
		}
		
		// param
		String paramJsonStr = JsonUtils.getString(json, P_KEY);
		paramFromJson(paramJsonStr);
	}

	@Override
	public String toString() {
		return "targetMap=" + userDataToJson() + ";param=" + paramToJsonStr();
	}
	
}
