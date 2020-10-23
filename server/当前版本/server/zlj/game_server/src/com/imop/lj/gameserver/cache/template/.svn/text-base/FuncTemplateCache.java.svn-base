package com.imop.lj.gameserver.cache.template;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Map.Entry;
import java.util.Set;
import java.util.TreeMap;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.func.template.FuncOpenTemplate;
import com.imop.lj.gameserver.func.template.FuncTemplate;

/**
 * 功能开启模版缓存
 * 
 */
public class FuncTemplateCache implements InitializeRequired {
	/** 模板 */
	protected TemplateService templateService;

	/** 默认开启的功能 */
	private Set<FuncTypeEnum> defaultOpendFuncSet = new HashSet<FuncTypeEnum>();
	
	/** 任务限制开启的功能Map<任务Id，功能开启模板列表> */
	private Map<Integer, Set<FuncOpenTemplate>> questLimitFuncMap = new HashMap<Integer, Set<FuncOpenTemplate>>();
	/** 关卡限制开启的功能Map<任务Id，功能开启模板列表> */
	private Map<Integer, Set<FuncOpenTemplate>> missionLimitFuncMap = new HashMap<Integer, Set<FuncOpenTemplate>>();
	/** 等级限制开启的功能Map<任务Id，功能开启模板列表> */
	private Map<Integer, Set<FuncOpenTemplate>> levelLimitFuncMap = new TreeMap<Integer, Set<FuncOpenTemplate>>();
	
	private Map<Integer, Set<FuncOpenTemplate>> vipLevelLimitFuncMap = new TreeMap<Integer, Set<FuncOpenTemplate>>();
	/** enemyArmy限制开启的功能Map<enemyArmyId，功能开启模板列表> */
	private Map<Integer, Set<FuncOpenTemplate>> enemyArmyLimitFuncMap = new HashMap<Integer, Set<FuncOpenTemplate>>();

	public FuncTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		// 检查是否所有的功能枚举都有对应的配置
		for (FuncTypeEnum funcType : FuncTypeEnum.values()) {
			if (null == templateService.get(funcType.getIndex(), FuncTemplate.class)) {
				throw new TemplateConfigException("", 0, String.format("功能Id[%d]不存在！", funcType.getIndex()));
			}
			if (null == templateService.get(funcType.getIndex(), FuncOpenTemplate.class)) {
				throw new TemplateConfigException("", 0, String.format("功能Id[%d]不存在！", funcType.getIndex()));
			}
		}
				
		// 初始化3个map的数据
		for (FuncOpenTemplate funcOpenTpl : templateService.getAll(FuncOpenTemplate.class).values()) {
			FuncTypeEnum funcType = FuncTypeEnum.valueOf(funcOpenTpl.getId());
			int limitQuestId = funcOpenTpl.getLimitQuestId();
			int limitMissionId = funcOpenTpl.getLimitMissionId();
			int limitLevel = funcOpenTpl.getLimitLevel();
			int limitVipLevel = funcOpenTpl.getLimitVipLevel();
			int limitEnemyArmyId = funcOpenTpl.getLimitEnemyArmyId();
			
			// 三个限制条件都为0，则表示是默认开启的
			if (limitQuestId <= 0 && limitMissionId <= 0 && limitLevel <= 0 && limitVipLevel <= 0 && limitEnemyArmyId <= 0) {
				// 默认开启的功能
				defaultOpendFuncSet.add(funcType);
				continue;
			} 
			
			// 任务限制的功能
			if (limitQuestId > 0) {
				Set<FuncOpenTemplate> questLimitList = questLimitFuncMap.get(limitQuestId);
				if (null == questLimitList) {
					questLimitList = new HashSet<FuncOpenTemplate>();
					questLimitFuncMap.put(limitQuestId, questLimitList);
				}
				questLimitList.add(funcOpenTpl);
			}
			// 关卡限制的功能
			if (limitMissionId > 0) {
				Set<FuncOpenTemplate> missionLimitList = missionLimitFuncMap.get(limitMissionId);
				if (null == missionLimitList) {
					missionLimitList = new HashSet<FuncOpenTemplate>();
					missionLimitFuncMap.put(limitMissionId, missionLimitList);
				}
				missionLimitList.add(funcOpenTpl);
			}
			// 等级限制的功能
			if (limitLevel > 0) {
				Set<FuncOpenTemplate> levelLimitList = levelLimitFuncMap.get(limitLevel);
				if (null == levelLimitList) {
					levelLimitList = new HashSet<FuncOpenTemplate>();
					levelLimitFuncMap.put(limitLevel, levelLimitList);
				}
				levelLimitList.add(funcOpenTpl);
			}
			// vip等级限制的功能
			if (limitVipLevel > 0) {
				Set<FuncOpenTemplate> totalChargeLimitList = vipLevelLimitFuncMap.get(limitVipLevel);
				if (null == totalChargeLimitList) {
					totalChargeLimitList = new HashSet<FuncOpenTemplate>();
					vipLevelLimitFuncMap.put(limitVipLevel, totalChargeLimitList);
				}
				totalChargeLimitList.add(funcOpenTpl);
			}
			// enemyArymy限制的
			if (limitEnemyArmyId > 0) {
				Set<FuncOpenTemplate> enemyArmyLimitList = enemyArmyLimitFuncMap.get(limitEnemyArmyId);
				if (null == enemyArmyLimitList) {
					enemyArmyLimitList = new HashSet<FuncOpenTemplate>();
					enemyArmyLimitFuncMap.put(limitEnemyArmyId, enemyArmyLimitList);
				}
				enemyArmyLimitList.add(funcOpenTpl);
			}
		}
		
		// 等级数据填充，将等级段中空的等级数据填上
		updateLevelLimitFuncMap();
		// 更新vip等级限制功能数据
		updateVipLevelLimitMap();
		
		
	}
	
	/**
	 * 等级数据填充，将等级段中空的等级数据填上
	 */
	protected void updateLevelLimitFuncMap() {
		if (levelLimitFuncMap.isEmpty()) {
			return;
		}
		// 填充至map中最后一个级别
		Map<Integer, Set<FuncOpenTemplate>> levelTmpMap = new HashMap<Integer, Set<FuncOpenTemplate>>();
		int preLevel = 0;
		if (levelLimitFuncMap.size() > 1) {
			int i = 0;
			for (Integer level : levelLimitFuncMap.keySet()) {
				i++;
				if (i > 1) {
					Set<FuncOpenTemplate> preSet = new HashSet<FuncOpenTemplate>(levelLimitFuncMap.get(preLevel));
					// 把前一等级的所有功能开启模板放入当前等级中
					levelLimitFuncMap.get(level).addAll(preSet);
					
					if (level > preLevel + 1) {
						for (int t = preLevel + 1; t < level; t++) {
//							// 超过最高等级的不需要填充
//							if (t > Globals.getGameConstants().getLevelMax()) {
//								break;
//							}
							levelTmpMap.put(t, preSet);
						}
					}
				}
				preLevel = level;
			}
			// 将中间的空挡数据加入map中
			levelLimitFuncMap.putAll(levelTmpMap);
		} else {
			for (Integer level : levelLimitFuncMap.keySet()) {
				preLevel = level;
			}
		}
		
		// 填充map中最后一个级别+1到最高级
		int maxMaybe = 100;//FIXME Math.max(Globals.getGameConstants().getLevelMax(), templateService.getAll(PetUpgradeTemplate.class).size());
		if (preLevel < maxMaybe) {
			Set<FuncOpenTemplate> lastSet = new HashSet<FuncOpenTemplate>(levelLimitFuncMap.get(preLevel));
			// 从preLevel+1开始至最高级，都跟preLevel这个集合一样
			for (int i = preLevel + 1; i <= maxMaybe; i++) {
				levelLimitFuncMap.put(i, lastSet);
			}
		}
	}
	
	protected void updateVipLevelLimitMap() {
		// 数额大的需要包含所有小于他的功能集合
		Integer preKey = 0;
		for (Entry<Integer, Set<FuncOpenTemplate>> entry : vipLevelLimitFuncMap.entrySet()) {
			Integer key = entry.getKey();
			if (preKey > 0) {
				vipLevelLimitFuncMap.get(key).addAll(vipLevelLimitFuncMap.get(preKey));
			}
			preKey = key;
		}
	}
	

	/**
	 * 获取默认开启的功能
	 * @return
	 */
	public Set<FuncTypeEnum> getDefaultOpenedFuncSet() {
		return defaultOpendFuncSet;
	}
	
	/**
	 * 获取任务限制的功能列表
	 * @param questId
	 * @return
	 */
	public Set<FuncOpenTemplate> getOpenedFuncListByQuest(int questId) {
		return questLimitFuncMap.get(questId);
	}
	
	/**
	 * 获取关卡限制的功能列表
	 * @param missionId
	 * @return
	 */
	public Set<FuncOpenTemplate> getOpenedFuncListByMission(int missionId) {
		return missionLimitFuncMap.get(missionId);
	}
	
	/**
	 * 获取等级限制的功能列表
	 * @param level
	 * @return
	 */
	public Set<FuncOpenTemplate> getOpenedFuncListByLevel(int level) {
		return levelLimitFuncMap.get(level);
	}
	
	/**
	 * 获取vip等级限制的功能列表
	 * @param vipLevel
	 * @return
	 */
	public Set<FuncOpenTemplate> getOpenedFuncListByVipLevel(int vipLevel) {
		Set<FuncOpenTemplate> funcSet = new HashSet<FuncOpenTemplate>();
		for (Integer key : vipLevelLimitFuncMap.keySet()) {
			if (vipLevel >= key) {
				funcSet = vipLevelLimitFuncMap.get(key);
			} else {
				// 因为是排序的，所以可以break
				break;
			}
		}
		return funcSet;
	}
	
	/**
	 * 获取enemyArmyId限制的功能列表
	 * @param enemyArmyId
	 * @return
	 */
	public Set<FuncOpenTemplate> getOpenedFuncListByEnemyArmyId(int enemyArmyId) {
		return enemyArmyLimitFuncMap.get(enemyArmyId);
	}
}
