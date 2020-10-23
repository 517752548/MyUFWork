package com.imop.lj.gameserver.reward;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import net.sf.json.JSONArray;
import net.sf.json.JSONObject;

import com.imop.lj.common.LogReasons;
import com.imop.lj.common.model.reward.RewardInfo;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.model.CorpsStorageItem;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedFromType;
import com.imop.lj.gameserver.reward.RewardDef.RewardAddedType;
import com.imop.lj.gameserver.reward.RewardDef.RewardAmendType;
import com.imop.lj.gameserver.reward.RewardDef.RewardCalculateType;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.RewardDef.RewardType;
import com.imop.lj.gameserver.reward.template.RandomRewardTemplate;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.reward.template.RewardSetTemplate;
import com.imop.lj.gameserver.reward.template.RewardTemplate;
import com.imop.lj.gameserver.reward.template.ShowRewardTemplate;

/**
 * 所有奖励管理器 负责所有奖励生成包括：关卡奖励、副本奖励，随机礼包，特殊奖励等
 * 
 * @author xiaowei.liu
 *
 */
public class RewardService {
	/** 是否记录createReward的log，目前关闭 */
	protected static boolean LOG_FLAG = false;
	
	protected List<IRewardAmend> amendList = new ArrayList<IRewardAmend>();
	
	/**
	 * 生成空的奖励对象
	 * @return
	 */
	public Reward createEmptyReward() {
		return new Reward();
	}
	public RewardService(){
//		// 关卡奖励修正
//		amendList.add(new CorpsRewardAmend());
//		// 关卡低于世界等级的奖励修正
//		amendList.add(new MissionWorldLevelRewardAmend());
	}

	/**
	 * 生成奖励对象
	 * 
	 * @param createRewardCharId 生成奖励的玩家角色对象，因为离线模块也调用奖励模块，所以不能传human对象
	 * @param rewardId 奖励模板id
	 * @param logContent 生成所要记录的log内容
	 * @param params 动态奖励所需参数
	 * @return
	 */
	public Reward createReward(long createRewardCharId, int rewardId, String logContent, Map<String, Object> params) {
		return this.createReward(createRewardCharId, rewardId, logContent, params, true, RewardAmendType.HUMAN, null);
	}
	
	/**
	 * 生成奖励对象，不记录日志
	 * 
	 * @param createRewardCharId
	 * @param rewardId
	 * @param logContent
	 * @param params
	 * @return
	 */
	public Reward createRewardUnSaveLog(long createRewardCharId,int rewardId, String logContent, Map<String, Object> params) {
		return this.createReward(createRewardCharId, rewardId, logContent, params, false, RewardAmendType.HUMAN, null);
	}
	
	/**
	 * 根据rewardid获得相应奖励对象
	 * 
	 * @param rewardId
	 *            物品id
	 * @param logContent
	 *            logreason对应参数，用于log记录
	 * 
	 * @return
	 */
	public Reward createReward(long createRewardCharId, int rewardId, String logContent) {
		return this.createReward(createRewardCharId,rewardId, logContent, null);
	}
	
	/**
	 * 创建带有修正参数的奖励，多个修正奖励
	 * @param createRewardCharId
	 * @param rewardId
	 * @param logContent
	 * @param addAmendMap
	 * @return
	 */
	public Reward createRewardWithAmend(long createRewardCharId, int rewardId, String logContent, Map<RewardAddedFromType, IRewardAmend> addAmendMap) {
		return this.createReward(createRewardCharId, rewardId, logContent, null, true, RewardAmendType.HUMAN, addAmendMap);
	}
	
	/**
	 * 创建带有修正参数的奖励，一个修正奖励
	 * @param createRewardCharId
	 * @param rewardId
	 * @param logContent
	 * @param addAmend
	 * @return
	 */
	public Reward createRewardWithAmend(long createRewardCharId, int rewardId, String logContent, IRewardAmend addAmend) {
		Map<RewardAddedFromType, IRewardAmend> addAmendMap = new HashMap<RewardAddedFromType, IRewardAmend>();
		if (addAmend != null) {
			addAmendMap.put(addAmend.getAddedType(), addAmend);
		}
		return this.createRewardWithAmend(createRewardCharId, rewardId, logContent, addAmendMap);
	}
	
	/**
	 * 生成奖励对象
	 * 
	 * @param createRewardCharId 生成奖励的玩家角色对象，因为离线模块也调用奖励模块，所以不能传human对象
	 * @param rewardId 奖励模板id
	 * @param logContent 生成所要记录的log内容
	 * @param params 动态奖励所需参数
	 * @return
	 */
	public RewardInfo createRewardInfo(long createRewardCharId,int rewardId, String logContent, Map<String, Object> params){
		Reward reward = this.createRewardUnSaveLog(createRewardCharId, rewardId, logContent, params);
		return reward.toRewardInfo();
	}
	
	
	/**
	 * 生成奖励对象
	 * 
	 * @param createRewardCharId 生成奖励的玩家角色对象，因为离线模块也调用奖励模块，所以不能传human对象
	 * @param rewardId 奖励模板id
	 * @param logContent 生成所要记录的log内容
	 * @param params 动态奖励所需参数
	 * @return
	 */
	protected Reward createReward(long createRewardCharId, int rewardId, String logContent, Map<String, Object> params, boolean saveLog, 
			RewardAmendType amendType, Map<RewardAddedFromType, IRewardAmend> addAmendMap) {
		// 先获得奖励奖励模板
		RewardConfigTemplate rewardConfigTemplate = Globals.getTemplateCacheService().get(rewardId, RewardConfigTemplate.class);
		if (rewardConfigTemplate == null) {
			return new Reward();
		}

		List<RewardTemplate> createRewardTemplateList = new ArrayList<RewardTemplate>();
		// 生成固定奖励
		int fixedRewardSetId = rewardConfigTemplate.getFixedRewardSetId();
		if (fixedRewardSetId != 0) {
			RewardSetTemplate rewardSetTemplate = Globals.getTemplateCacheService().get(fixedRewardSetId, RewardSetTemplate.class);
			if(rewardSetTemplate.getRewardTempalteSet().size() <= rewardConfigTemplate.getFixedRewardNum()){
				createRewardTemplateList.addAll(rewardSetTemplate.getRewardTempalteSet());
			}else{
				List<RewardTemplate> rewardTemplateList = RandomUtil.hitObjects(rewardSetTemplate.getRewardTempalteSet(), rewardConfigTemplate.getFixedRewardNum());
				if (rewardTemplateList != null && rewardTemplateList.size() > 0) {
					createRewardTemplateList.addAll(rewardTemplateList);
				}
			}
		}

		// 生成随机奖励
		List<RandomRewardTemplate> randomRewardTemplateList = rewardConfigTemplate.getRandomRewardTempalteList();
		if (randomRewardTemplateList != null && randomRewardTemplateList.size() > 0) {
			// 命中随机
			RandomRewardTemplate randomRandomRewardTemplate = RandomUtil.hitObject(rewardConfigTemplate.getRandomList(), randomRewardTemplateList,
					Globals.getGameConstants().getRandomBase());
			if (randomRandomRewardTemplate != null) {
				// 命中奖励集合
				RewardSetTemplate rewardSetTemplate = Globals.getTemplateCacheService().get(randomRandomRewardTemplate.getRandomRewardSetId(),
						RewardSetTemplate.class);
				List<RewardTemplate> rewardTemplateList = RandomUtil.hitObjects(rewardSetTemplate.getRewardTempalteSet(),
						randomRandomRewardTemplate.getRandomRewardNum());
				if (rewardTemplateList != null && rewardTemplateList.size() > 0) {
					createRewardTemplateList.addAll(rewardTemplateList);
				}
			}
		}
		
		// 合并相同奖励
		StringBuffer rewardLog = new StringBuffer();
		StringBuffer calRewardLog = new StringBuffer();
		List<RewardParam> paramList = new ArrayList<RewardParam>();
		for (RewardTemplate tmpl : createRewardTemplateList) {
			switch (tmpl.getRewardType()) {
			case REWARD_CALCULATE:
				RewardCalculateType calcType = RewardCalculateType.valueOf(tmpl.getParam1());
				if (null != calcType) {
					// 按照对应的公式计算
					List<RewardParam> resultList = calcType.getRewardCalculator().calcReward(rewardConfigTemplate.getRewardReasonType(), params);
					if (null != resultList && !resultList.isEmpty()) {
						for(RewardParam param : resultList){
							calRewardLog.append(param.toString());
							calRewardLog.append("|");
						}
						
						paramList.addAll(resultList);
					}
				}
				break;
			default:
				RewardParam rewardParam = tmpl.toRewardParam();
				paramList.add(rewardParam);
				rewardLog.append(rewardParam.toString());
				rewardLog.append("|");
				break;
			}
		}

		// 生成奖励对象
		Reward reward = new Reward();
		reward.setReasonType(rewardConfigTemplate.getRewardReasonType());
		reward.initReward(paramList);
		reward.setUuid(KeyUtil.UUIDKey());

		// 处理日志参数，只负责存log记录
		JSONObject rewardObject = new JSONObject();
		if (params != null && params.size() > 0) {
			rewardObject.put(RewardDef.REWARD_LOG_PARAMS, JsonUtils.toJsonString(params));
		}
		rewardObject.put(RewardDef.REWARD_LOG_TEMPLATE_ID, rewardId);
		rewardObject.put(RewardDef.REWARD_LOG_CONTENT, logContent != null ? logContent : "");
		rewardObject.put(RewardDef.REWARD_UUID, reward.getUuid());
		reward.setParams(rewardObject.toString());
		
		//奖励修正
		List<IRewardAmend> tmpAmendList = new ArrayList<IRewardAmend>();
		//全局
		if (!this.amendList.isEmpty()) {
			tmpAmendList.addAll(this.amendList);
		}
		//额外修正
		if (addAmendMap != null && !addAmendMap.isEmpty()) {
			tmpAmendList.addAll(addAmendMap.values());
		}
		//奖励修正
		if(!tmpAmendList.isEmpty()){
			Map<RewardAddedType, Integer> amendMap = null;
			Map<RewardAddedFromType, Map<RewardAddedType, Integer>> addedMap = null;
			for(IRewardAmend amend : tmpAmendList) {
				Map<RewardAddedType, Integer> map = amend.getAmendMap(createRewardCharId, reward.getReasonType(), amendType);
				if(map != null && !map.isEmpty()){
					if(amendMap == null){
						amendMap = new HashMap<RewardAddedType, Integer>();
					}
					
					// 合并
					for(Entry<RewardAddedType, Integer> entry : map.entrySet()){
						Integer value = amendMap.get(entry.getKey());
						if(value == null){
							value = 0;
						}
						
						if(value > Integer.MAX_VALUE - entry.getValue()){
							value = Integer.MAX_VALUE;
						}else{
							value += entry.getValue();
						}
						amendMap.put(entry.getKey(), value);
					}
					
					// 加成来源
					if(addedMap == null){
						addedMap = new HashMap<RewardAddedFromType, Map<RewardAddedType,Integer>>();
					}
					
					addedMap.put(amend.getAddedType(), map);
				}
				
			}

			// 加成Map
			reward.setAmendMap(addedMap);
			if(amendMap != null && !amendMap.isEmpty()){
				reward.amend(amendMap);
			}
		}
		if(saveLog){
			// TODO 记录生成log，需要传
			if (LOG_FLAG) {
				Globals.getLogService().sendRewardLog(null,LogReasons.RewardLogReason.CREATE_REWARD, "", createRewardCharId, reward.getUuid(), reward.getReasonType().getIndex(), rewardLog.toString(), calRewardLog.toString(), reward.getParams());
			}
		}
		return reward;
	}
	
	/**
	 * 根据指定的内容生成奖励
	 * 
	 * @param createRewardCharId
	 * @param reasonType
	 * @param exp
	 * @param itemInfoList
	 * @param currencyInfoList
	 * @param logContent
	 * @return
	 */
	public Reward createRewardByFixedContent(long createRewardCharId, RewardReasonType reasonType, List<RewardParam> paramList, String logContent) {
		if (null == reasonType) {
			return new Reward();
		}
		
		// 生成奖励对象
		Reward reward = new Reward();
		reward.setReasonType(reasonType);
		if(!reward.initReward(paramList)){
			// 如果有参数不合法
			return new Reward();
		}
		
		//奖励参数日志
		StringBuffer rewardLog = new StringBuffer();
		for(RewardParam param : paramList){
			rewardLog.append(param.toString());
			rewardLog.append("|");
		}

		reward.setUuid(KeyUtil.UUIDKey());
		// 处理日志参数，只负责存log记录
		JSONObject rewardObject = new JSONObject();
		rewardObject.put(RewardDef.REWARD_LOG_TEMPLATE_ID, "fixed");
		rewardObject.put(RewardDef.REWARD_LOG_CONTENT, logContent != null ? logContent : "");
		rewardObject.put(RewardDef.REWARD_UUID, reward.getUuid());
		reward.setParams(rewardObject.toString());
		
		//FIXME 统一调用宏观调控接口

		// 记录生成log，需要传
		if (LOG_FLAG) {
			Globals.getLogService().sendRewardLog(null, LogReasons.RewardLogReason.CREATE_REWARD, "createRewardByFixedContent",
					createRewardCharId, reward.getUuid(), 0, rewardLog.toString(), "", reward.getParams());
		}
		return reward;
	}
	
	/**
	 * 创建军团奖励，不做参数校验，军团长分配宝箱时使用
	 * 
	 * @return
	 */
	public Reward createCorpsReward(long createRewardCharId, List<CorpsStorageItem> rewardList){
		if(rewardList == null || rewardList.isEmpty()){
			return null;
		}
		
		Reward reward = new Reward();
		reward.setReasonType(RewardReasonType.CORPS_ALLOCATION);
		reward.setUuid(KeyUtil.UUIDKey());
		
		//奖励物品
		List<RewardParam> paramlist = new ArrayList<RewardParam>();
		StringBuffer rewardLog = new StringBuffer();
		for(CorpsStorageItem item : rewardList){
			RewardParam param = new RewardParam();
			param.setRewardType(RewardType.REWARD_ITEM);
			param.setParam1(item.getItemTempId());
			param.setParam2(item.getNum());
			paramlist.add(param);
			
			rewardLog.append(param.toString());
			rewardLog.append("|");
			
		}
		if(!reward.initReward(paramlist)){
			return null;
		}
		if (LOG_FLAG) {
			Globals.getLogService().sendRewardLog(null,LogReasons.RewardLogReason.CREATE_REWARD, "",createRewardCharId, reward.getUuid(), 0, rewardLog.toString(), "", reward.getParams());
		}
		return reward;
	}
	
	/**
	 * 创建给军团的奖励，与创建普通奖励一样，只是id由玩家id变为军团id 一些活动需要生成给军团的奖励的时候调用
	 * 
	 * @param corpsId
	 * @param rewardId
	 * @param logContent
	 * @param params
	 * @return
	 */
	public Reward createCorpsReward(long corpsId, int rewardId, String logContent, Map<String, Object> params) {
		// 生成军团奖励，与普通奖励一样，只是id是军团id
		return this.createReward(corpsId, rewardId, logContent, params, true, RewardAmendType.CORPS, null);
	}

	/**
	 * 给奖励
	 * 
	 * @param reward
	 * @param needNotify 是否需要提示玩家
	 * @return 返回是否给奖励成功
	 */
	public boolean giveReward(Human human, Reward reward, boolean needNotify) {
		if(human == null){
			return false;
		}
		
		if(reward == null || reward.isNull()){
			return false;
		}
		
		return reward.giveReward(human, needNotify);
	}
	
	/**
	 * 给军团奖励
	 * 
	 * @param corpsId
	 * @param reward 
	 * @param needNotify
	 * @return
	 */
	public boolean giveCoprsReward(long corpsId, Reward reward, boolean needNotify){
		if(reward == null || reward.isNull()){
			return false;
		}
		
		// 仅支持帮派boss排行榜奖励
		if(reward.getReasonType() != RewardReasonType.CORPS_BOSS_RANK_REWARD
				&& reward.getReasonType() != RewardReasonType.CORPS_BOSS_COUNT_RANK_REWARD){
			return false;
		}
		
		return reward.giveCorpsReward(corpsId, needNotify);
	}

	/**
	 * XXX 慎用此方法，一般是相同rewardReasonType才合并一个奖励，合并的奖励rewardReasonType用第一个对象的值为准
	 * 
	 * @param templateList
	 * @return
	 */
	public Reward mergeReward(List<Reward> rewardList){
		if(rewardList == null || rewardList.size() <= 0){
			return new Reward();
		}
		
		//合并之后reasonType变成一个
		RewardReasonType reasonType = null;
		
		List<String> rewardUUIDs = new ArrayList<String>();
		
		JSONArray rewardUUIDJson = new JSONArray();
		
		List<RewardParam> paramList = new ArrayList<RewardParam>();
		for(Reward reward : rewardList){
			// 如果奖励为空则跳过
			if(reward == null){
				continue;
			}
			
			// reasonType 是否有效，一般不会出现此情况
			if(!reward.isNull()){
				//取出第一个有reasonType
				if(reasonType == null || reward.getReasonType() == RewardReasonType.NULL_REWARD) {
					reasonType = reward.getReasonType();
				}
				
				paramList.addAll(reward.getRewardParamList());
				
				rewardUUIDs.add(reward.getUuid());
				rewardUUIDJson.add(reward.getUuid());
			}else{
				// TODO 无效reward的日志LOG
				
			}
		}
		
		// 如果reasonType有问题,没有找到一个合法的reward
		if(reasonType == null || reasonType == RewardReasonType.NULL_REWARD){
			return new Reward();
		}
		
		// 生成奖励对象
		Reward reward = new Reward();
		reward.setReasonType(reasonType);
		if(!reward.initReward(paramList)){
			// 初始化奖励失败
			return new Reward();
		}

		// 处理日志参数，只负责存log记录
		JSONObject rewardObject = new JSONObject();
		if (rewardUUIDs != null && rewardUUIDs.size() > 0) {
			rewardObject.put(RewardDef.REWARD_LOG_MERGE_REWARD_IDS, rewardUUIDJson.toString());
		}
		
		reward.setParams(rewardObject.toString());
		reward.setUuid(KeyUtil.UUIDKey());

		return reward;
	}

	/**
	 * 多个奖励合并成一个奖励
	 * 
	 * @param rewards
	 * @return
	 */
	public Reward mergeReward(Reward... rewards) {
		return mergeReward(Arrays.asList(rewards));
	}
	

	/**
	 * 将奖励对象转化为消息中需要的对象
	 * 
	 * @param reward
	 * @return
	 */
	public RewardInfo convertReward(Reward reward) {
		RewardInfo rewardInfo = new RewardInfo();
		if (null != reward) {
			rewardInfo = reward.toRewardInfo();
		}
		return rewardInfo;
	}

	/**
	 * 将奖励对象列表转化为消息中需要的列表
	 * 
	 * @param rewardList
	 * @return
	 */
	public List<RewardInfo> convertRewardList(List<Reward> rewardList) {
		List<RewardInfo> rewardInfoList = new ArrayList<RewardInfo>();
		if (rewardList != null && !rewardList.isEmpty()) {
			for (Reward reward : rewardList) {
				rewardInfoList.add(convertReward(reward));
			}
		}
		return rewardInfoList;
	}

//	/**
//	 * 击败一个敌人时给奖励
//	 * 
//	 * @param human
//	 * @param enemyArmyTpl
//	 * @param isFirstDefeated
//	 *            是否首次击败
//	 * @param params
//	 *            创建奖励的参数
//	 * @return 给玩家的奖励，出错时可能为null
//	 */
//	public Reward giveDefeatEnemyArmyReward(Human human, EnemyArmyTemplate enemyArmyTpl, boolean isFirstDefeated, String params) {
//		// 给玩家击败一个enemyArmy的奖励，如果是第一次击败，则还需给第一次击败的奖励
//		Reward reward = null;
//		int rewardId = enemyArmyTpl.getWinRewardId();
//		params += ";enemyArmyId=" + enemyArmyTpl != null ? enemyArmyTpl.getId() : 0;
//		params += ";isFirstDefeated=" + isFirstDefeated;
//		Reward rewardWin = null;
//		if (rewardId > 0) {
//			rewardWin = this.createReward(human.getUUID(), rewardId, params);
//		}
//		Reward rewardFirstDefeated = null;
//		if (isFirstDefeated) {
//			rewardFirstDefeated = this.createReward(human.getUUID(),enemyArmyTpl.getFirstWinRewarId(), params);
//		}
//
//		// 奖励确定，可能会合并
//		if (null != rewardWin && null != rewardFirstDefeated) {
//			reward = this.mergeReward(rewardWin, rewardFirstDefeated);
//		} else if (null == rewardFirstDefeated) {
//			if (null != rewardWin) {
//				reward = rewardWin;
//			}
//		} else {
//			if (null != rewardFirstDefeated) {
//				reward = rewardFirstDefeated;
//			}
//		}
//
//		if (reward != null) {
//			// 给玩家奖励，不提示
//			boolean flag = reward.giveReward(human, false);
//			if (!flag) {
//				// 记录错误日志
//				Loggers.humanLogger.error("#RewardService#giveDefeatEnemyArmyReward# giveReward failed!uuid=" + human.getUUID());
//				return null;
//			}
//		} else {
//			// 记录错误日志
//			Loggers.humanLogger.error("#RewardService#giveDefeatEnemyArmyReward# reward is null!uuid=" + human.getUUID());
//		}
//		return reward;
//	}
	
	/**
	 * 创建仅显示用的rewardInfo，子奖励之间不叠加不排重
	 * @param showRewardId
	 * @return
	 */
	public RewardInfo createShowRewardInfo(int showRewardId) {
		RewardInfo rewardInfo = new RewardInfo();
		ShowRewardTemplate showRewardTpl = Globals.getTemplateCacheService().get(showRewardId, ShowRewardTemplate.class);
		if (null == showRewardTpl) {
			return rewardInfo;
		}
		
		JSONObject obj = new JSONObject();
		JSONArray array = new JSONArray();
		
		List<RewardTemplate> rewardTplList = showRewardTpl.getRewardTempalteSet();
		for (RewardTemplate rewardTpl : rewardTplList) {
			ISubReward subReward = rewardTpl.getRewardType().getSubReward().createEmptySubReward(null);
			subReward.addReward(rewardTpl.toRewardParam());
			
			JSONObject temp = new JSONObject();
			temp.put(RewardKeyDefine.REWARD_TYPE_KEY, subReward.getRewardType().getIndex());
			temp.put(RewardKeyDefine.REWARD_CONTENT_KEY, subReward.getMsgString());
			array.add(temp);
		}
		obj.put(RewardKeyDefine.REWARD_INFO_KEY, array.toString());
		rewardInfo.setRewardStr(obj.toString());
		
		return rewardInfo;
	}
	
}
