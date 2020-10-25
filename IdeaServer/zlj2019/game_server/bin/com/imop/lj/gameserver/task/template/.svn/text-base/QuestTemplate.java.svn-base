package com.imop.lj.gameserver.task.template;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.annotation.ExcelRowBinding;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.reward.RewardDef.RewardReasonType;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.reward.template.ShowRewardTemplate;
import com.imop.lj.gameserver.task.TaskDef.DestType;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.cond.IQuestCondition;
import com.imop.lj.gameserver.task.cond.PreQuestCondition;
import com.imop.lj.gameserver.task.dest.IQuestDestination;

/**
 * 任务模板，数据来源于配置表，表示一个任务所有相关的数据
 * 
 * 
 */
@ExcelRowBinding
public class QuestTemplate extends QuestTemplateVO {

	/** 金钱奖励类型 */
	private Currency currency;
	
	/** 任务类型 */
	private QuestType questTypeEnum;
	
	/** 任务目标列表 */
	private List<IQuestDestination> questDestList = new ArrayList<IQuestDestination>();

	/** 接任务条件列表 */
	private List<IQuestCondition> questConditionList = new ArrayList<IQuestCondition>();
	
	private List<Integer> taskEnemyArmyIdList = new ArrayList<Integer>();

	/** 显示奖励的字符串 */
	private String rewardStr = "";
	
	@Override
	public void check() throws TemplateConfigException {
		//检查如果是自动接收且自动完成的任务，任务条件不能为空
		if (isAutoAccept() && isAutoFinish()) {
			if (hasDestType(DestType.NULL)) {
				throw new TemplateConfigException(sheetName, this.id, "自动接取且自动完成的任务，不能没有 任务目标函数！");
			}
		}
		
		//前置任务需要和该任务的类型一致
		if (preQuestId > 0) {
			if (questType == QuestType.BRANCH.getIndex()) {
				if (templateService.get(preQuestId, QuestTemplate.class).questType != QuestType.COMMON.getIndex()
						&& templateService.get(preQuestId, QuestTemplate.class).questType != QuestType.BRANCH.getIndex()) {
					throw new TemplateConfigException(sheetName, this.id, "支线前置任务类型只能是主线或支线！");
				}
			} else if (questType != templateService.get(preQuestId, QuestTemplate.class).questType) {
				throw new TemplateConfigException(sheetName, this.id, "前置任务类型与该任务不一致！");
			}
		}
		
		//任务奖励判断，如果按照职业性别划分任务奖励，则每一个任务对应的各个职业性别应该都有奖励，或者都没有
		int sum = 0;
		for(Integer i : rewardIdOnCondition){
			if(i!=0){
				sum++;
			}
		}
		if(sum!=0&&sum!=rewardIdOnCondition.size()){
			throw new TemplateConfigException(sheetName, this.id, "配置的条件奖励个数不匹配(应为0或条件奖励列数)！");
		}
		
		//奖励检查
		RewardConfigTemplate rewardTpl = templateService.get(rewardId, RewardConfigTemplate.class);
		if (null == rewardTpl) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励Id不存在[%d]", rewardId));
		}
		RewardReasonType rewardReasonType = null;
		
		switch (questTypeEnum) {
		case COMMON:
		case BRANCH:
			rewardReasonType = RewardReasonType.QUEST_REWARD;
			break;
		case PUB:
			if (isAutoAccept() || isAutoFinish()) {
				throw new TemplateConfigException(sheetName, this.id, "酒馆任务不能自动接受或完成！");
			}
			if (preQuestId != 0) {
				throw new TemplateConfigException(sheetName, this.id, "酒馆任务不能有前置任务！");
			}
			rewardReasonType = RewardReasonType.PUB_TASK_REWARD;
			break;
		case TEAM:
			if (preQuestId == 0 && isAutoAccept()) {
				throw new TemplateConfigException(sheetName, this.id, "没有前置任务的组队任务，不能自动接收！");
			}
			break;
		case THESWEENEY:
			if (!isAutoAccept()) {
				throw new TemplateConfigException(sheetName, this.id, "除暴安良任务只能自动接受！");
			}
			if (!isAutoFinish()) {
				throw new TemplateConfigException(sheetName, this.id, "除暴安良任务只能自动完成！");
			}
			if (preQuestId != 0) {
				throw new TemplateConfigException(sheetName, this.id, "除暴安良任务不能有前置任务！");
			}
			rewardReasonType = RewardReasonType.SWEENEY_TASK_REWARD;
			break;
		case TREASUREMAP:
			if (!isAutoAccept()) {
				throw new TemplateConfigException(sheetName, this.id, "藏宝图任务只能自动接受！");
			}
			if (!isAutoFinish()) {
				throw new TemplateConfigException(sheetName, this.id, "藏宝图任务只能自动完成！");
			}
			if (preQuestId != 0) {
				throw new TemplateConfigException(sheetName, this.id, "藏宝图任务不能有前置任务！");
			}
			rewardReasonType = RewardReasonType.TREASURE_MAP_TASK_REWARD;
			break;
		case FORAGE:
			if (isAutoAccept() || isAutoFinish()) {
				throw new TemplateConfigException(sheetName, this.id, "护送粮草任务不能自动接受或完成！");
			}
			if (preQuestId != 0) {
				throw new TemplateConfigException(sheetName, this.id, "护送粮草任务不能有前置任务！");
			}
			rewardReasonType = RewardReasonType.FORAGE_TASK_REWARD;
			break;
		case CORPSTASK:
			if (preQuestId != 0) {
				throw new TemplateConfigException(sheetName, this.id, "帮派任务不能有前置任务！");
			}
			rewardReasonType = RewardReasonType.CORPS_TASK_REWARD;
			break;
		case TIME_LIMIT_MONSTER:
			if (!isAutoFinish()) {
				throw new TemplateConfigException(sheetName, this.id, "限时杀怪任务只能自动完成！");
			}
			if (preQuestId != 0) {
				throw new TemplateConfigException(sheetName, this.id, "限时杀怪不能有前置任务！");
			}
			rewardReasonType = RewardReasonType.TIME_LIMIT_MONSTER_REWARD;
			break;
		case TIME_LIMIT_NPC:
			if (!isAutoFinish()) {
				throw new TemplateConfigException(sheetName, this.id, "限时挑战Npc任务只能自动完成！");
			}
			if (preQuestId != 0) {
				throw new TemplateConfigException(sheetName, this.id, "限时挑战Npc不能有前置任务！");
			}
			rewardReasonType = RewardReasonType.TIME_LIMIT_NPC_REWARD;
			break;
		case DAY7_TARGET:
			if (preQuestId != 0) {
				throw new TemplateConfigException(sheetName, this.id, "七日目标任务不能有前置任务！");
			}
			if (startNpcMapId != 0 || startNpc != 0 || endNpcMapId != 0 || endNpc != 0 || autoAccept != 0 || autoFinish != 0) {
				throw new TemplateConfigException(sheetName, this.id, "七日目标任务npc配置和自动配置都必须为0！");
			}
			rewardReasonType = RewardReasonType.DAY7_TARGET_REWARD;
			break;
		case SIEGE_DEMON_NOMAL:
			if (!isAutoFinish()) {
				throw new TemplateConfigException(sheetName, this.id, "围剿魔族普通任务只能自动完成！");
			}
			rewardReasonType = RewardReasonType.SIEGE_DEMON_NORMAL_REWARD;
			break;
		case SIEGE_DEMON_HARD:
			if (!isAutoFinish()) {
				throw new TemplateConfigException(sheetName, this.id, "围剿魔族困难任务只能自动完成！");
			}
			rewardReasonType = RewardReasonType.SIEGE_DEMON_HARD_REWARD;
			break;
		case RING:
			if (preQuestId != 0) {
				throw new TemplateConfigException(sheetName, this.id, "跑环任务不能有前置任务！");
			}
			rewardReasonType = RewardReasonType.RING_TASK_REWARD;
			break;
		default:
			break;
		}
		// 奖励类型检查
		if (rewardReasonType == null || rewardTpl.getRewardReasonType() != rewardReasonType) {
			throw new TemplateConfigException(this.sheetName, getId(), String.format("奖励身份识别类型[%d]", rewardTpl.getRewardReasonTypeId()));
		}
		
		//接取任务的NPC必须配置，因为可能后来修改为自动接受的，这样程序就不会自动接受，需要手动接
		//酒馆任务和运粮跳过起始npc判断
		if (!questTypeEnum.equals(QuestType.PUB) 
				&& !questTypeEnum.equals(QuestType.FORAGE)
				&& !questTypeEnum.equals(QuestType.TIME_LIMIT_MONSTER)
				&& !questTypeEnum.equals(QuestType.TIME_LIMIT_NPC)
				&& !questTypeEnum.equals(QuestType.DAY7_TARGET)
				&& !questTypeEnum.equals(QuestType.SIEGE_DEMON_NOMAL)
				&& !questTypeEnum.equals(QuestType.SIEGE_DEMON_HARD)) {
			if (startNpcMapId == 0 || startNpc == 0) {
				throw new TemplateConfigException(sheetName, this.id, "接取任务的NPC必须配置！");
			}
		}
		
		//显示奖励检查
		if (showRewardId > 0) {
			ShowRewardTemplate showTpl = templateService.get(showRewardId, ShowRewardTemplate.class);
			if (showTpl == null) {
				throw new TemplateConfigException(this.sheetName, getId(), String.format("显示奖励Id不存在！[%d]", showRewardId));
			}
		}
	}

	@Override
	public void patchUp() {
		questTypeEnum = QuestType.indexOf(questType);
		if (null == questTypeEnum) {
			throw new TemplateConfigException("主任务表", id, "任务类型不存在：" + questType);
		}
		
		// 组装任务条件
		for (SpecialCondition cond : specialCondition) {

			try {
				// 检验所有的任务条件是否正确
				cond.check(id);
			} catch (Exception ex) {
				throw new TemplateConfigException("主任务表", id, ex.toString());
			}

			IQuestCondition questCondition = cond.buildQuestCondition();
			if (questCondition == null) {
				continue;
			}
			questConditionList.add(questCondition);
		}


		// 验证前置任务是否存在
		if (preQuestId != 0
				&& !templateService.isTemplateExist(preQuestId,
						QuestTemplate.class)) {
			throw new TemplateConfigException("主任务表", id, "前置任务不存在："
					+ preQuestId);
		}

		// 前置任务不可以是该任务本身
		if (preQuestId == id) {
			throw new TemplateConfigException("主任务表", id, "前置任务不可以是任务自身");
		}
		
		// 前置任务条件
		if (preQuestId != 0) {
			List<Integer> lst = new ArrayList<Integer>();
			lst.add(this.preQuestId);
			PreQuestCondition preCond = new PreQuestCondition(lst);
			questConditionList.add(preCond);
		}

		// 检验所有的任务目标是否正确
		try {
			specialDestination.get(0).check(id);
		} catch (Exception ex) {
			ex.printStackTrace();
			throw new TemplateConfigException("主任务表", id, ex.toString());
		}
		
		// 组装任务目标
		List<IQuestDestination> tmpDests = specialDestination.get(0).buildQuestDestination(id);
		if (tmpDests != null && !tmpDests.isEmpty()) {
			questDestList.addAll(tmpDests);
		}

		for(Integer id : this.getEnemyArmyIdList()){
			if(id > 0){
				taskEnemyArmyIdList.add(id);
			}
		}
		
		
	}

	/**
	 * 此任务是否包条件奖励
	 * 
	 * @return
	 */
	public boolean hasConditionReward() {
		boolean flag = true;
		if(this.getRewardIdOnCondition()==null||this.getRewardIdOnCondition().size()<=0){
			return false;
		}
		for(Integer i : this.getRewardIdOnCondition()){
			if(i<=0){
				flag = false;
			}
		}
		return flag;
	}
	
	/**
	 * 判断此任务是否包含任务怪物组
	 * @return
	 */
	public boolean hasTaskEnemyArmy(Integer ememyArmyId){
		if(taskEnemyArmyIdList != null && !taskEnemyArmyIdList.isEmpty()){
			for(Integer id : taskEnemyArmyIdList){
				if(ememyArmyId == id){
					return true;
				}
			}
		}
		return false;
	}
	
	
	/**
	 * 此任务是否包含此类型的任务目标
	 * 
	 * @param key
	 *            此目标的类型
	 * @return
	 */
	public boolean hasDestType(DestType key) {
		for (IQuestDestination dest : questDestList) {
			if (dest.getDestType() == key) {
				return true;
			}
		}
		return false;
	}
	
	/**
	 * 返回某个任务目标的索引
	 * 
	 * @param type
	 * @param instKey
	 * @return
	 */
	public int getDestIndex(DestType type, Object instKey) {
		int i = 0;
		for (IQuestDestination dest : questDestList) {
			if (dest.getDestType().equals(type)
					&& dest.getInstKey().equals(instKey)) {
				return i;
			}
			i++;
		}
		return -1;
	}

	public QuestType getQuestTypeEnum() {
		return questTypeEnum;
	}

	public String getHotLinkContent(){
		String hotLinkContent = this.specialDestination.get(0).getParam5th();
		if(hotLinkContent!=null){
			return hotLinkContent;
		}
		return "";
	}

	
//	public NpcTemplate getStartNpcTemplatet(){
//		return templateService.get(this.startNpc, NpcTemplate.class);
//	}
//	
//	public NpcTemplate getEndNpcTemplatet(){
//		return templateService.get(this.endNpc, NpcTemplate.class);
//	}

	public List<IQuestDestination> getQuestDestList() {
		return questDestList;
	}

	public List<IQuestCondition> getQuestConditionList() {
		return questConditionList;
	}

	public Currency getCurrency() {
		return currency;
	}
	
	public boolean isAutoAccept() {
		return autoAccept == 1;
	}
	
	public boolean isAutoFinish() {
		return autoFinish == 1;
	}

	public String getRewardStr() {
		return rewardStr;
	}

	public void setRewardStr(String rewardStr) {
		this.rewardStr = rewardStr;
	}
	
}
