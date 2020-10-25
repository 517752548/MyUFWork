package com.imop.lj.gameserver.exp.service;

import java.util.BitSet;
import java.util.HashMap;
import java.util.Map;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.exp.model.ExpLevelInfo;
import com.imop.lj.gameserver.exp.model.ExpResultInfo;

/**
 * 经验管理器，用于所有经验逻辑，加经验等
 * 
 * 
 * @author yuanbo.gao
 * 
 */
public class ExpService {

	/**
	 * 提供基础经验配置对象初始化，包括排序，初始化最大值
	 * 
	 * @param Map
	 *            <经验等级,升级到下一等级所需经验(增量)> config 配置
	 * @param isSum
	 *            返回经验结果是否是累加经验
	 * @param maxLevel
	 *            最大等级
	 */
	public ExpConfigInfo createExpConfig(Map<Integer, Long> config, boolean isSum, int maxLevel) {
		// 先找到最大等级
		int max = maxLevel;
		if (maxLevel == 0) {
			// 找到最大值
			for (Integer level : config.keySet()) {
				if (max < level) {
					max = level;
				}
			}
		}

		int min = max;
		for (Integer level : config.keySet()) {
			if (min > level) {
				min = level;
			}
		}

		// 如果最大和最小出问题
		if (max == 0) {
			return null;
		}

		// 创建经验等级对象
		Map<Integer, ExpLevelInfo> expLevelInfos = this.createExpLevelInfo(config, max, min);
		if (expLevelInfos == null || expLevelInfos.isEmpty()) {
			return null;
		}

		ExpConfigInfo configInfo = new ExpConfigInfo(isSum, max);
		configInfo.setExpLevelConfigs(expLevelInfos);
		return configInfo;
	}

	/**
	 * 检查一系列级别段是否合法,并初始化各个级别对象
	 * 
	 * @param ranges
	 * @throws Exception
	 */
	protected Map<Integer, ExpLevelInfo> createExpLevelInfo(Map<Integer, Long> config, int maxLevel, int min) {
		Map<Integer, ExpLevelInfo> levels = new HashMap<Integer, ExpLevelInfo>();

		BitSet bs = new BitSet(maxLevel + 1);
		// 检查级别有没有重复的
		for (Integer level : config.keySet()) {
			if (bs.get(level)) {
				// 有重叠的级别段
				Loggers.gameLogger.error("初始化级别错误有重叠的部分");
				return null;
			}
			bs.set(level);
		}
		// 检查级别是不是重复的
		for (int i = min; i <= maxLevel; i++) {
			if (!bs.get(i)) {
				Loggers.gameLogger.error("初始化级别错误级别不连续");
				return null;
			}
		}

		// 组装经验等级对象
		for (int i = min; i <= maxLevel; i++) {
			ExpLevelInfo level = new ExpLevelInfo();
			level.setLevel(i);
			level.setRequireExp(config.get(i));
			long sum = 0;
			for (int j = i; j >= min; j--) {
				sum += config.get(j);
			}
			level.setSumExp(sum);
			levels.put(i, level);
		}

//		// 对最高级进行处理,最高级的requireExp要被赋值为0
//		ExpLevelInfo maxExpLevelInfo = levels.get(maxLevel);
//		maxExpLevelInfo.setRequireExp(0);
		return levels;
	}
	
	/**
	 * 加经验,最大经验为默认最大经验
	 * 
	 * @param expConfigInfo
	 *            经验配置对象
	 * @param originalLevel
	 *            现在等级
	 * @param originalExp
	 *            现在经验
	 * @param addExp
	 *            加的经验值
	 * @return
	 */
	public ExpResultInfo addExp(ExpConfigInfo expConfigInfo, int originalLevel, long originalExp, long addExp) {
		return this.addExp(expConfigInfo, originalLevel, originalExp, addExp, 0);
	}
	
	/**
	 * 加经验
	 * 
	 * @param expConfigInfo
	 *            经验配置对象
	 * @param originalLevel
	 *            现在等级
	 * @param originalExp
	 *            现在经验
	 * @param addExp
	 *            加的经验值
	 * @param limitLevel
	 *            等级限制
	 * @return
	 */
	public ExpResultInfo addExp(ExpConfigInfo expConfigInfo, int originalLevel, long originalExp, long addExp, int limitLevel) {
		ExpResultInfo result = new ExpResultInfo();
		result.setOriginalExp(originalExp);
		result.setOriginalLevel(originalLevel);

		// 首先判断经验显示是否叠加显示
		boolean isSum = expConfigInfo.isSum();

		// 如果限制等级大于所有等级或者限制等级等于0或者当前等级大于等级限制，最大等级为系统默认等级
		int maxLevel = limitLevel;
		if (limitLevel == 0 || limitLevel > maxLevel || originalLevel > limitLevel) {
			maxLevel = expConfigInfo.getMaxLevel();
		}

		// 如果是叠加显示，originalExp+addExp与ExpLevelInfo的sumExp进行比较
		if (isSum) {
			// 当前经验显示是累加的，currencyExp=originalExp+addExp
			long currencyExp = originalExp + addExp;

			// 依次查询经验等级对象，直到小于SumExp，找到对应等级
			ExpLevelInfo expLevelInfo = expConfigInfo.getExpLevelConfigs().get(originalLevel);
			for (int i = originalLevel; i <= maxLevel; i++) {
				expLevelInfo = expConfigInfo.getExpLevelConfigs().get(i);
				long sum = expLevelInfo.getSumExp();
				// 需要判断sumExp值
				if (currencyExp < sum) {
					break;
				}
			}

			currencyExp = Math.min(currencyExp, expLevelInfo.getSumExp() - 1);
			result.setCurrencyExp(currencyExp);
			result.setLevel(expLevelInfo.getLevel());
			result.setMaxExp(expLevelInfo.getSumExp());
			result.setNextLevelRequire(expLevelInfo.getSumExp() - currencyExp);
			// 如果是最大等级
			if (expLevelInfo.getLevel() != expConfigInfo.getMaxLevel()) {
				result.setNextLevel(expLevelInfo.getLevel() + 1);
			}
		} else {
			// 如果不是叠加显示，originalExp+addExp与ExpLevelInfo的requireExp进行比较
			long currencyExp = originalExp + addExp;
			ExpLevelInfo expLevelInfo = expConfigInfo.getExpLevelConfigs().get(originalLevel);
			for (int i = originalLevel; i <= maxLevel; i++) {
				expLevelInfo = expConfigInfo.getExpLevelConfigs().get(i);
				long requiredExp = expLevelInfo.getRequireExp();
				if (currencyExp < requiredExp) {
					break;
				}
				if (i < maxLevel) {
					// 需要将此等级的经验减去
					currencyExp = currencyExp - requiredExp;
				}
			}
			currencyExp = Math.min(currencyExp, expLevelInfo.getRequireExp() - 1);
			result.setCurrencyExp(currencyExp);
			result.setLevel(expLevelInfo.getLevel());
			result.setMaxExp(expLevelInfo.getRequireExp());
			result.setNextLevelRequire(expLevelInfo.getRequireExp() - currencyExp);
			// 如果是最大等级
			if (expLevelInfo.getLevel() != expConfigInfo.getMaxLevel()) {
				result.setNextLevel(expLevelInfo.getLevel() + 1);
			}
		}

		return result;
	}

	/**
	 * 获得当前经验对象
	 * 
	 * @param expConfigInfo
	 * @param originalLevel
	 * @param originalExp
	 * @return
	 */
	public ExpResultInfo getCurrencyExpInfo(ExpConfigInfo expConfigInfo, int originalLevel, long originalExp) {
		return this.addExp(expConfigInfo, originalLevel, originalExp, 0, 0);
	}
	
	/**
	 * 是否达到最大经验值
	 * @param expConfigInfo
	 * @param originalLevel 当前等级
	 * @param originalExp 当前经验值
	 * @param limitLevel 限制等级，0表示maxLevel
	 * @return originalLevel>=限制/最高等级且originalExp>=最大经验[限制/最高等级对应的升级经验值-1]时返回true
	 */
	public boolean isReachMaxExp(ExpConfigInfo expConfigInfo, int originalLevel, long originalExp, int limitLevel) {
		boolean flag = false;
		int maxLevel = expConfigInfo.getMaxLevel();
		// 范围检查，修正
		if (limitLevel <= 0 || limitLevel > maxLevel) {
			limitLevel = maxLevel;
		}
		long limitLevelExp = expConfigInfo.getExpLevelConfigs().get(limitLevel).getRequireExp();
		if (originalLevel >= limitLevel && 
				originalExp >= limitLevelExp - 1) {
			flag = true;
		}
		return flag;
	}
}
