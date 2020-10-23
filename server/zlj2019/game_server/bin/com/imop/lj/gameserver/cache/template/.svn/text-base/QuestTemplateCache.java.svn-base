package com.imop.lj.gameserver.cache.template;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.TreeSet;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.day7target.template.Day7TargetTemplate;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.cond.IQuestCondition;
import com.imop.lj.gameserver.task.cond.PreQuestCondition;
import com.imop.lj.gameserver.task.template.QuestTemplate;

public class QuestTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	protected MapTemplateCache mapTemplateCache;
	
	/** 某一任务的所有前置任务列表，主线支线 */
	private Map<Integer, Set<Integer>> preQuest = new HashMap<Integer, Set<Integer>>();
	/** 所有依赖于该任务为前置任务的任务列表，主线支线 */
	private Map<Integer, Set<Integer>> postQuest = new HashMap<Integer, Set<Integer>>();
	
	/** 等级为key的【支线】任务Id集合 */
	private Map<Integer, Set<Integer>> branchLevelMap = new HashMap<Integer, Set<Integer>>();
	
	private int firstQuestId;
	
	/**七日目标任务Map<任务Id，天数>*/
	private Map<Integer, Integer> day7QuestMap = new HashMap<Integer, Integer>();
	/**七日目标任务Map<天数，任务Id集合> */
	private Map<Integer, Set<Integer>> day7QuestDayMap = new HashMap<Integer, Set<Integer>>();
	
	public QuestTemplateCache(TemplateService templateService, MapTemplateCache mapTemplateCache) {
		this.templateService = templateService;
		this.mapTemplateCache = mapTemplateCache;
	}

	@Override
	public void init() {
		initQuestMap();
		checkNpc();
		initDay7Task();
	}
	
	/**
	 * 初始化前置任务列表
	 */
	private void initQuestMap() {
		for (QuestTemplate tpl : templateService.getAll(QuestTemplate.class).values()) {
			//这里只处理主线和支线
			if (tpl.getQuestTypeEnum() != QuestType.BRANCH && tpl.getQuestTypeEnum() != QuestType.COMMON) {
				continue;
			}
			
			int actMinLevel = tpl.getAcceptMinLevel();
			
			//支线任务，以等级划分
			if (tpl.getQuestTypeEnum() == QuestType.BRANCH) {
				Set<Integer> levelSet = branchLevelMap.get(actMinLevel);
				if (levelSet == null) {
					levelSet = new HashSet<Integer>();
					branchLevelMap.put(actMinLevel, levelSet);
				}
				levelSet.add(tpl.getId());
			}
			
			// 无前置任务
			if (tpl.getPreQuestId() == 0 && tpl.getQuestTypeEnum() == QuestType.COMMON) {
				if (firstQuestId == 0) {
					firstQuestId = tpl.getId();
				} else if (tpl.getId() < firstQuestId) {
					firstQuestId = tpl.getId();
				}
				continue;
			}
	
			List<IQuestCondition> conditions = tpl.getQuestConditionList();
			for (IQuestCondition cond : conditions) {
				if (cond instanceof PreQuestCondition) {
					PreQuestCondition preCond = (PreQuestCondition) cond;
	
					// 添加所有前置任务
					Set<Integer> ids = preQuest.get(tpl.getId());
					if (ids == null) {
						ids = new HashSet<Integer>();
						preQuest.put(tpl.getId(), ids);
					}
					ids.addAll(preCond.getQuestIds());
	
					// 添加所有后置任务
					for (Integer postId : preCond.getQuestIds()) {
						Set<Integer> post = postQuest.get(postId);
						if (post == null) {
							post = new HashSet<Integer>();
							postQuest.put(postId, post);
						}
						post.add(tpl.getId());
					}
				}
			}
		}
		
		if (firstQuestId <= 0) {
			throw new TemplateConfigException("任务配置表", 0, "没有找到初始任务！");
		}
		
		//要求高的等级中，需要加入低等级要求的所有任务
		Set<Integer> lvKeySet = branchLevelMap.keySet();
		for (Integer outerLevel : lvKeySet) {
			for (Integer innerLv : lvKeySet) {
				if (innerLv > outerLevel) {
					branchLevelMap.get(innerLv).addAll(branchLevelMap.get(outerLevel));
				}
			}
		}
		
		//把两个等级段中间的数填充上
		Set<Integer> lvSet = new TreeSet<Integer>();
		lvSet.addAll(branchLevelMap.keySet());
		int pre = -1;
		int nex = -1;
		int last = -1;
		for (Integer lv : lvSet) {
			if (pre == -1) {
				pre = lv;
			} else if (nex == -1) {
				nex = lv;
			}
			
			if (pre != -1 && nex != -1) {
				if (nex > pre + 1) {
					for (int i = pre; i < nex; i++) {
						branchLevelMap.put(pre + 1, branchLevelMap.get(pre));
					}
				}
				
				pre = nex;
				nex = -1;
			}
			
			last = lv;
		}
		//把到最高等级的数填充上
		for (int i = last + 1; i <= Globals.getGameConstants().getLevelMax(); i++) {
			branchLevelMap.put(i, branchLevelMap.get(last));
		}
		
	}
	
	private void checkNpc() {
		for (QuestTemplate tpl : templateService.getAll(QuestTemplate.class).values()) {
			if (tpl.getStartNpc() > 0 && !mapTemplateCache.isNpcInMap(tpl.getStartNpcMapId(), tpl.getStartNpc())) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "任务的接受NPC配置错误！");
			}
			
			//如果任务不是自动完成的，则需要到npc处交，七日目标任务除外
			if (!tpl.isAutoFinish() 
					&& tpl.getQuestTypeEnum() != QuestType.DAY7_TARGET) {
				if (!mapTemplateCache.isNpcInMap(tpl.getEndNpcMapId(), tpl.getEndNpc())) {
					throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "交付任务的NPC配置错误！");
				}
			}
		}
	}
	
	private void initDay7Task() {
		for (Day7TargetTemplate tpl : templateService.getAll(Day7TargetTemplate.class).values()) {
			int day = tpl.getDay();
			int questId = tpl.getQuestId();
			if (day7QuestMap.containsKey(questId)) {
				throw new TemplateConfigException(tpl.getSheetName(), tpl.getId(), "任务Id不能重复！" + questId);
			}
			day7QuestMap.put(questId, day);
			
			Set<Integer> questSet = day7QuestDayMap.get(day);
			if (questSet == null) {
				questSet = new HashSet<Integer>();
				day7QuestDayMap.put(day, questSet);
			}
			questSet.add(questId);
		}
		
		int maxDay = day7QuestDayMap.keySet().size();
		for (int i = 1; i <= maxDay; i++) {
			if (!day7QuestDayMap.keySet().contains(i)) {
				throw new TemplateConfigException("七日目标", 0, "缺少天数的配置！" + i);
			}
		}
	}
	
	public Set<Integer> getPreQuestIdSet(int questId) {
		return preQuest.get(questId);
	}
	
	public Set<Integer> getPostQuestIdSet(int questId) {
		return postQuest.get(questId);
	}
	
	public Set<Integer> getBranchLevelQuestIdSet(int level) {
		return branchLevelMap.get(level);
	}
	
	public int getFirstQuestId() {
		return firstQuestId;
	}
	
	public int getDayOfDay7Task(int questId) {
		if (day7QuestMap.containsKey(questId)) {
			return day7QuestMap.get(questId);
		}
		return 0;
	}
	
	public int getMaxDayOfDay7Task() {
		return day7QuestDayMap.keySet().size();
	}
	
	public Set<Integer> getDay7QuestIdSet(int day) {
		return day7QuestDayMap.get(day);
	}
}
