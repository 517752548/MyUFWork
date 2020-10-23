package com.imop.lj.gameserver.battle.helper;

import java.util.List;

import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.IBattle;
import com.imop.lj.gameserver.battle.report.BattleReport;

/**
 * 战斗评分辅助类
 * @author yu.zhao
 *
 */
public class RatingHelper {

	public static final int GRADE_MAX = 5;
	
	/**
	 * 获取战斗星级评分
	 * @param report
	 * @param standardList
	 * @return 1~5，如果平局或区间填错了，则为默认分数1分
	 */
	public static int getGrade(BattleReport report, List<Double> standardList) {
		// 默认评分1分
		int defaultRating = 1;
		double value = getRawValue(report);
		if (value <= 0) {
			return defaultRating;
		}
		
		for (int i = 1; i < standardList.size(); i++) {
			if ((value >= standardList.get(i - 1)) && (value <= standardList.get(i))) {
				defaultRating = i;
				break;
			}
		}
		return defaultRating;
	}
	
	/**
	 * 获取战斗评分的原始值，double类型
	 * @param report
	 * @return double
	 */
	public static double getRawValue(BattleReport report) {
		double value = 0;
		IBattle battle = report.getBattle();
		int round = battle.getRound();
		int max = 0;
		int current = 0;
		switch (report.getResult()) {
		case ATTACKER:
			for (FightUnit unit : battle.getInitialAttackers()) {
				max += unit.getAttr(BattleDef.HP + BattleDef.MAX).intValue();
			}
			for (FightUnit unit : battle.getAttackers().values()) {
				current += unit.getHp();
			}
			break;
		case DEFENDER:
			for (FightUnit unit : battle.getInitialDefenders()) {
				max += unit.getAttr(BattleDef.HP + BattleDef.MAX).intValue();
			}
			for (FightUnit unit : battle.getDefenders().values()) {
				current += unit.getHp();
			}
			break;
		default:
			// 平局返回0
			return value;
		}
		
		double average = 1.0D * current / max;
		value = average / (0.2D * round + 1.0D);
		
		return value;
	}
	
	/**
	 * 获取最终评分
	 * @param gradeList 评分列表
	 * @return 根据评分列表取平均值，结果四舍五入，如果gradeList非法则返回默认评分1分
	 */
	public static int getFinalGrade(List<Integer> gradeList) {
		int grade = 1;
		if (gradeList != null && !gradeList.isEmpty()) {
			int total = 0;
			for (Integer g : gradeList) {
				total += g;
			}
			grade = Math.round(total / gradeList.size());
		}
		return grade;
	}
}
