package com.imop.lj.gameserver.cache.template;

import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.exception.TemplateConfigException;
import com.imop.lj.core.template.TemplateService;
import com.imop.lj.gameserver.goodactivity.activity.GoodActivityDef.GoodActivityType;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityBaseTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityEveryCostTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTargetTemplate;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityTotalCostTargetTemplate;

import java.util.*;

/**
 * 精彩活动模板缓存
 * @author yu.zhao
 *
 */
public class GoodActivityTemplateCache implements InitializeRequired {
	protected TemplateService templateService;
	
	/** 活动类型对应的活动Map<活动类型，该类型的活动列表> */
	protected Map<GoodActivityType, List<GoodActivityBaseTemplate>> activityTypeMap = Maps.newHashMap();
	/** 排序好的活动目标模板列表Map<活动模板Id，活动目标列表> */
	protected Map<Integer, List<GoodActivityTargetTemplate>> targetTplMap = Maps.newHashMap();
	
	
	public GoodActivityTemplateCache(TemplateService templateService) {
		this.templateService = templateService;
	}

	@Override
	public void init() {
		initTypeMap();
		initTargetList();
		checkSomeActivityTargetParam();
	}
	
	protected void initTypeMap() {
		for (GoodActivityBaseTemplate activityTpl : templateService.getAll(GoodActivityBaseTemplate.class).values()) {
			GoodActivityType type = activityTpl.getActivityType();
			List<GoodActivityBaseTemplate> activityTypeList = activityTypeMap.get(type);
			if (null == activityTypeList) {
				activityTypeList = new ArrayList<GoodActivityBaseTemplate>();
				activityTypeMap.put(type, activityTypeList);
			}
			activityTypeList.add(activityTpl);
		}
	}
	
	protected void initTargetList() {
		// 生成targetTplMap
		for (GoodActivityTargetTemplate targetTpl : templateService.getAll(GoodActivityTargetTemplate.class).values()) {
			int activityTplId = targetTpl.getGoodActivityId();
			List<GoodActivityTargetTemplate> targetList = targetTplMap.get(activityTplId);
			if (targetList == null) {
				targetList = new ArrayList<GoodActivityTargetTemplate>();
				targetTplMap.put(activityTplId, targetList);
			}
			targetList.add(targetTpl);
		}
		
		// 对目标列表排序
		for (Map.Entry<Integer, List<GoodActivityTargetTemplate>> entry : targetTplMap.entrySet()) {
			List<GoodActivityTargetTemplate> targetList = entry.getValue();
			Collections.sort(targetList, new Comparator<GoodActivityTargetTemplate>() {
				@Override
				public int compare(GoodActivityTargetTemplate o1,
						GoodActivityTargetTemplate o2) {
					if (o1.getOrder() < o2.getOrder()) {
						return -1;
					}
					if (o1.getOrder() > o2.getOrder()) {
						return 1;
					}
					throw new TemplateConfigException(o1.getSheetName(), o1.getId(), String.format("精彩活动目标配置和[%d]排序重复！[%d]", o2.getId(), o1.getOrder()));
				}
			});
		}
		
	}
	
	protected void checkSomeActivityTargetParam() {
		// 累计消耗活动检查，每个活动的目标货币类型必须一致
		{
			List<GoodActivityBaseTemplate> aList = activityTypeMap.get(GoodActivityType.TOTAL_COST);
			if (null != aList) {
				for (GoodActivityBaseTemplate aTpl : aList) {
					List<GoodActivityTargetTemplate> tList = targetTplMap.get(aTpl.getId());
					if (tList == null) {
						continue;
					}
					Set<Integer> currencyIdSet = new HashSet<Integer>();
					Set<Integer> sourceIdSet = new HashSet<Integer>();
					for (GoodActivityTargetTemplate tTpl : tList) {
						currencyIdSet.add(((GoodActivityTotalCostTargetTemplate)tTpl).getCurrencyId());
						sourceIdSet.add(((GoodActivityTotalCostTargetTemplate)tTpl).getSourceId());
					}
					if (currencyIdSet.size() > 1) {
						throw new TemplateConfigException("", 0, String.format("精彩活动 累计消耗 目标 货币类型 不一致！活动id[%d]", aTpl.getId()));
					}
					if (sourceIdSet.size() > 1) {
						throw new TemplateConfigException("", 0, String.format("精彩活动 累计消耗 目标 消耗来源 不一致！活动id[%d]", aTpl.getId()));
					}
				}
			}
		}
		// 每累计消耗活动检查，每个活动的目标货币类型必须一致
		{
			List<GoodActivityBaseTemplate> aList = activityTypeMap.get(GoodActivityType.EVERY_COST);
			if (null != aList) {
				for (GoodActivityBaseTemplate aTpl : aList) {
					List<GoodActivityTargetTemplate> tList = targetTplMap.get(aTpl.getId());
					if (tList == null) {
						continue;
					}
					Set<Integer> currencyIdSet = new HashSet<Integer>();
					Set<Integer> sourceIdSet = new HashSet<Integer>();
					for (GoodActivityTargetTemplate tTpl : tList) {
						currencyIdSet.add(((GoodActivityEveryCostTargetTemplate)tTpl).getCurrencyId());
						sourceIdSet.add(((GoodActivityEveryCostTargetTemplate)tTpl).getSourceId());
					}
					if (currencyIdSet.size() > 1) {
						throw new TemplateConfigException("", 0, String.format("精彩活动 每累计消耗 目标 货币类型 不一致！活动id[%d]", aTpl.getId()));
					}
					if (sourceIdSet.size() > 1) {
						throw new TemplateConfigException("", 0, String.format("精彩活动 累计消耗 目标 消耗来源 不一致！活动id[%d]", aTpl.getId()));
					}
				}
			}
		}
	}
	
	/**
	 * 获取活动目标列表，已排序
	 * @param activityTplId
	 * @return
	 */
	public List<GoodActivityTargetTemplate> getTargetTplList(int activityTplId) {
		return targetTplMap.get(activityTplId);
	}
	
	/**
	 * 获取指定活动类型的活动列表
	 * @param type
	 * @return
	 */
	public List<GoodActivityBaseTemplate> getGoodActivityListOfType(GoodActivityType type) {
		return activityTypeMap.get(type);
	}
	
}
