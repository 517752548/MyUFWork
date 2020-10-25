package com.imop.lj.gameserver.activityui;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import com.google.common.collect.Maps;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.reward.RewardInfo;
import com.imop.lj.gameserver.activity.function.ActivityDef;
import com.imop.lj.gameserver.activityui.ActivityUIDef.ActivitySpecialType;
import com.imop.lj.gameserver.activityui.ActivityUIDef.ActivityUIType;
import com.imop.lj.gameserver.activityui.ActivityUIDef.FinishStatue;
import com.imop.lj.gameserver.activityui.msg.GCAcitvityUiRewardInfo;
import com.imop.lj.gameserver.activityui.msg.GCActivityUiInfo;
import com.imop.lj.gameserver.activityui.template.ActivityUIRewardTemplate;
import com.imop.lj.gameserver.activityui.template.ActivityUITemplate;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.behavior.bindid.BindIdBehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.Reward;

public class ActivityUIService {
	
	//行为id对应的活动ui模板Id
	protected Map<BehaviorTypeEnum, ActivityUITemplate> actTypeMap = Maps.newHashMap();
	
	protected Integer recommendActivityId = -1;
	
	/**确定推荐任务以及特殊节日任务(每天校验)*/
	public void init(){
		//重置被推荐的活动ID
		recommendActivityId = -1;
		//没有推荐活动就返回
		Double dProb = EffectHelper.int2Double(Globals.getGameConstants().getRecommendActivityProb())>1D?1D:EffectHelper.int2Double(Globals.getGameConstants().getRecommendActivityProb());
		boolean hasRecommendActivity = RandomUtils.isHit(dProb);
		if(!hasRecommendActivity){
			return ;
		}
		//有推荐活动
		List<Integer> res = new ArrayList<Integer>();
		Map<Integer, ActivityUITemplate> uiTemplateMap = Globals.getTemplateCacheService().getAll(ActivityUITemplate.class);
		for(Entry<Integer,ActivityUITemplate> entry : uiTemplateMap.entrySet()){
			if(entry.getValue().getParticipateRecommendRandom() == 1){
				res.add(entry.getKey());
			}
		}
		//没有参与随机的就返回
		if(res == null || res.size() == 0){
			return ;
		}
		//取得一个推荐活动
		List<Integer> ids = RandomUtils.hitObjects(res, 1);
		if(ids == null || ids.size() == 0 || ids.get(0) == null || ids.get(0) < 0){
			return ;
		}
		recommendActivityId = ids.get(0);
		
		//构造map
		for (ActivityUITemplate tpl : Globals.getTemplateCacheService().getAll(ActivityUITemplate.class).values()) {
			if (tpl.getBehaviorId() > 0) {
				BehaviorTypeEnum bt = BehaviorTypeEnum.valueOf(tpl.getBehaviorId());
				actTypeMap.put(bt, tpl);
			}
		}
	}
	/**
	 * 判断是否是推荐活动
	 * @param activityId
	 * @return
	 */
	public boolean isRecommendActivity(Integer activityId){
		return activityId == recommendActivityId;
	}
	/**
	 * 刷新活动面板
	 * @param human
	 */
	public void freshActivityUI(Human human) {
		//1.获取infoList,各个活动的信息
		ActivityUIInfo[] infoArr = getInfoList(human);
		
		//2.获取可以领取的奖励对应活力值list
		int[] rewardArr = getRewardGainList(human);
		
		//3.获取当前的总活力值
		Integer totalVitality = human.getBehaviorManager().getCount(BehaviorTypeEnum.TOTAL_ACTIVITY_NUM);
		
		//4.组装消息并发送
		GCActivityUiInfo gcMessage = buildGCActivityUiInfoMessage(infoArr,
				rewardArr, totalVitality);
		human.sendMessage(gcMessage);
	}

	protected GCActivityUiInfo buildGCActivityUiInfoMessage(ActivityUIInfo[] infoArr,
			int[] rewardArr, Integer totalVitality) {
		GCActivityUiInfo gcMessage = new GCActivityUiInfo();
		gcMessage.setActivityList(infoArr);
		gcMessage.setRewardGainList(rewardArr);
		gcMessage.setTotalActivityVitality(totalVitality);
		return gcMessage;
	}

	protected int[] getRewardGainList(Human human) {
		List<Integer> rewardGainList = new ArrayList<Integer>();
		Map<Integer, ActivityUIRewardTemplate> uiRewardTemplateMap = Globals.getTemplateCacheService().getAll(ActivityUIRewardTemplate.class);
		for(Entry<Integer,ActivityUIRewardTemplate> entry : uiRewardTemplateMap.entrySet()){
			if(human.getBindIdBehaviorManager().canDo(BindIdBehaviorTypeEnum.ACTIVITY_REWARD, entry.getKey())){
				rewardGainList.add(entry.getKey());
			}
		}
		int[] rewardArr = new int[rewardGainList.size()];
		for(int i = 0; i < rewardArr.length; i++){
			rewardArr[i] = rewardGainList.get(i);
		}
		return rewardArr;
	}

	protected ActivityUIInfo[] getInfoList(Human human) {
		boolean isInCorps = Globals.getCorpsService().inCorps(human.getCharId());
		
		List<ActivityUIInfo> infoList = new ArrayList<ActivityUIInfo>();
		Map<Integer, ActivityUITemplate> uiTemplateMap = Globals.getTemplateCacheService().getActivityUITemplateCache().getUITemplateMap();
		for(Entry<Integer,ActivityUITemplate> entry : uiTemplateMap.entrySet()){
			ActivityUIInfo info = new ActivityUIInfo();
			BehaviorTypeEnum behaviorType = null;
			//1.计算id
			if (entry.getValue().getBehaviorId() > 0) {
				behaviorType = BehaviorTypeEnum.valueOf(entry.getValue().getBehaviorId());
				if (behaviorType == null || behaviorType == BehaviorTypeEnum.UNKNOWN){
					Loggers.activityUILogger.error("behaviorType is not extis with key:"+entry.getKey());
					continue;
				}
			}
			
			//帮派任务
			if(behaviorType == BehaviorTypeEnum.CORPS_TASK_NUM && !isInCorps){
				continue;
			}
			
			info.setActivityId(entry.getKey());
			//2.计算type
			ActivityUIType uiType  = ActivityUIType.NULL;
			if(!human.getFuncManager().hasOpenedFunc(FuncTypeEnum.valueOf(entry.getValue().getFuncId()))){
				uiType = ActivityUIType.NOTABLE;
			}else if(entry.getValue().getActivityTimeEventId() <= 0 
					|| (entry.getValue().getActivityTimeEventId() > 0 
							&& Globals.getActivityService().activityIsOpen(entry.getValue().getActivityTimeEventId()))){ 
			
				uiType = ActivityUIType.USUAL;
			}else if(entry.getValue().getActivityTimeEventId() > 0){
				uiType = ActivityUIType.TIMELIMIT;
			}
			if(uiType == ActivityUIType.NULL){
				Loggers.activityUILogger.error("uiType is not extis with key:"+entry.getKey());
				continue;
			}
			info.setActivityType(uiType.index);
			//3.计算times
			info.setActivityTimes(behaviorType != null ? human.getBehaviorManager().getCount(behaviorType) : 0);
			//4.计算specialType 推荐 TODO 节日 
			Integer specialType = ActivitySpecialType.NORMAL.index;
			if(entry.getKey() == recommendActivityId){
				specialType = ActivitySpecialType.RECOMMEND.index;
			}
			//5.计算完成情况
			if(behaviorType == null || 
					(behaviorType != null && human.getBehaviorManager().canDo(behaviorType))) {
				info.setFinishStatue(FinishStatue.UN_FINISH.index);
			}else{
				info.setFinishStatue(FinishStatue.FINISH.index);
			}
			info.setSpecialType(specialType);
			//6.准备奖励信息
			RewardInfo rewardInfo = Globals.getRewardService().createShowRewardInfo(entry.getValue().getShowRewardId());
			info.setRewardInfo(rewardInfo);
			//7.放入list
			infoList.add(info);
		}
		
		//单独构造限时推送活动信息
		ActivityUIInfo timeLimitinfo = genTimeLimitActLst(human);
		if(timeLimitinfo != null){
			infoList.add(timeLimitinfo);
		}
		
		ActivityUIInfo[] infoArr = new ActivityUIInfo[infoList.size()];
		infoArr = infoList.toArray(infoArr);
		return infoArr;
	}
	
	/**
	 * 根据模板单独构造限时活动信息
	 * @param human
	 * @return
	 */
	protected ActivityUIInfo genTimeLimitActLst(Human human){
		if(human == null || human.getTimeLimitManager() == null){
			return null;
		}
		
		List<ActivityUITemplate> lst = Globals.getTemplateCacheService().getActivityUITemplateCache().getTimeLimitTplLst();
		ActivityUIInfo info = null;
		for (ActivityUITemplate tpl : lst) {
			//判断限时活动类型
			if(ActivityDef.TimeLimitType.valueOf(tpl.getTimeLimitActivityId()) == null){
				continue;
			}
			//玩家身上是否有限时活动
			if(human.getTimeLimitManager().getPushType() != tpl.getTimeLimitActivityId()){
				continue;
			}
			
			info = new ActivityUIInfo();
			
			BehaviorTypeEnum behaviorType = null;
			if (tpl.getBehaviorId() > 0) {
				behaviorType = BehaviorTypeEnum.valueOf(tpl.getBehaviorId());
				if (behaviorType == null || behaviorType == BehaviorTypeEnum.UNKNOWN){
					Loggers.activityUILogger.error("behaviorType is not extis with key:"+tpl.getId());
					continue;
				}
			}
			//1.计算id
			info.setActivityId(tpl.getId());
			
			//2.计算type
			info.setActivityType(ActivityUIType.TIMELIMIT.index);
			
			//3.计算times
			info.setActivityTimes(behaviorType != null ? human.getBehaviorManager().getCount(behaviorType) : 0);
			
			//4.计算specialType
			Integer specialType = ActivitySpecialType.NORMAL.index;
			if(tpl.getId() == recommendActivityId){
				specialType = ActivitySpecialType.RECOMMEND.index;
			}
			info.setSpecialType(specialType);
			
			//5.计算完成情况
			if(behaviorType == null || 
					(behaviorType != null && human.getBehaviorManager().canDo(behaviorType))) {
				info.setFinishStatue(FinishStatue.UN_FINISH.index);
			}else{
				info.setFinishStatue(FinishStatue.FINISH.index);
			}
			
			//6.准备奖励信息
			RewardInfo rewardInfo = Globals.getRewardService().createShowRewardInfo(tpl.getShowRewardId());
			info.setRewardInfo(rewardInfo);
			
			//7.倒计时
			long cd = human.getTimeLimitManager().getStartTime() + Globals.getGameConstants().getTimeLimitExistenceTime() - Globals.getTimeService().now();
			if(cd < 0){
				cd = 0;
			}
			info.setCd(cd);
		}
		
		return info;
	}
	
	
	/**获得对应奖励*/
	public void getRewardByVitality(Human human, int rewardId) {
		//1.存在这个奖励
		Map<Integer, ActivityUIRewardTemplate> uiRewardTemplateMap = Globals.getTemplateCacheService().getAll(ActivityUIRewardTemplate.class);
		if(uiRewardTemplateMap==null || !uiRewardTemplateMap.containsKey(rewardId)){
			human.sendErrorMessage(LangConstants.REWARD_IS_NOT_EXTIS);
			return ;
		}
		//2.活力大于要求
		if(human.getBehaviorManager().getCount(BehaviorTypeEnum.TOTAL_ACTIVITY_NUM) < rewardId){
			human.sendErrorMessage(LangConstants.VITALITY_IS_NOT_ENOUGH);
			return ;
		}
		//3.还没有领取这个奖励
		if(!human.getBindIdBehaviorManager().canDo(BindIdBehaviorTypeEnum.ACTIVITY_REWARD, rewardId)){
			human.sendErrorMessage(LangConstants.REWARD_IS_ALREADY_GAIN);
			return ;
		}
		//4.记录奖励已经被领取
		human.getBindIdBehaviorManager().doBehavior(BindIdBehaviorTypeEnum.ACTIVITY_REWARD, rewardId);
		//5.发奖励
		Reward reward = Globals.getRewardService().createReward(
				human.getCharId(),
				uiRewardTemplateMap.get(rewardId).getRewardId(),
				"human gain activity vitality reward!  petId="
						+ human.getUUID() + ",vitalityNum=" + rewardId
						+ ",rewardId="
						+ uiRewardTemplateMap.get(rewardId).getRewardId());
		Globals.getRewardService().giveReward(human, reward, true);
		//6.刷新信息
		freshActivityUI(human);
		
		//功能按钮变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.ACTIVITY_UI);
	}
	
	/**
	 * 是否有可领取的活力值奖励
	 * @param human
	 * @return
	 */
	public boolean canGetActivityUIReward(Human human) {
		for (Integer rId : Globals.getTemplateCacheService().getAll(ActivityUIRewardTemplate.class).keySet()) {
			//活力大于要求
			if (human.getBehaviorManager().getCount(BehaviorTypeEnum.TOTAL_ACTIVITY_NUM) > rId) {
				//还没有领取这个奖励
				if(human.getBindIdBehaviorManager().canDo(BindIdBehaviorTypeEnum.ACTIVITY_REWARD, rId)){
					return true;
				}
			}
		}
		return false;
	}
	
	/**
	 * 返回被推荐的活动Id. 若没有则为-1
	 * @return
	 */
	public Integer getRecommendActivityId() {
		return recommendActivityId;
	}
	
	/**返回奖励infoList*/
	public void getRewardInfoList(Human human) {
		List<ActivityUIRewardInfo> list  = new ArrayList<ActivityUIRewardInfo>();
		Map<Integer, ActivityUIRewardTemplate> uiRewardTemplateMap = Globals.getTemplateCacheService().getAll(ActivityUIRewardTemplate.class);
		for(Entry<Integer, ActivityUIRewardTemplate> entry : uiRewardTemplateMap.entrySet()){
			RewardInfo rewardInfo = Globals.getRewardService().createShowRewardInfo(entry.getValue().getShowRewardId());
//			RewardInfo rewardInfo = Globals.getRewardService().createRewardInfo(human.getCharId(),
//					entry.getValue().getRewardId(),
//					"create vitality activity rewardInfo!  petId="
//							+ human.getUUID() + ",vitalityNum=" + entry.getKey()
//							+ ",rewardId="
//							+ entry.getValue().getRewardId(),null);
			list.add(new ActivityUIRewardInfo(entry.getKey(),rewardInfo));
		}
		ActivityUIRewardInfo[] arr = new ActivityUIRewardInfo[list.size()];
		arr = list.toArray(arr);
		GCAcitvityUiRewardInfo gc = new GCAcitvityUiRewardInfo();
		gc.setActivityUIRewardInfoList(arr);
		human.sendMessage(gc);
	}
	
	public void onDoBehavior(Human human, BehaviorTypeEnum behaviorType, int oldCount) {
		ActivityUITemplate uit = actTypeMap.get(behaviorType);
		if (uit != null) {
			//活跃度
			int vitalityNum = uit.getActivityNumPerTime();
			if (Globals.getActivityUIService().isRecommendActivity(uit.getId())) {
				vitalityNum = vitalityNum * Globals.getGameConstants().getRecommendActivityMultiple();
			}
			
			if (vitalityNum > 0 && oldCount < uit.getActivityTotalTime()) {
				human.getBehaviorManager().doBehavior(BehaviorTypeEnum.TOTAL_ACTIVITY_NUM, vitalityNum);
			}
			
			//活力值
			int energyNum = uit.getEnergyNumPerTime();
			if (Globals.getActivityUIService().isRecommendActivity(uit.getId())) {
				energyNum = energyNum * Globals.getGameConstants().getRecommendEnergyMultiple();
			}
			
			if (energyNum > 0 && oldCount < uit.getActivityTotalTime()
					&& human.canGiveMoney(energyNum, Currency.ENERGY)) {
				human.giveMoney(energyNum, Currency.ENERGY, false, MoneyLogReason.ENERGY_REWARD, MoneyLogReason.ENERGY_REWARD.getReasonText());
			}
			
		}
	}
	
}
