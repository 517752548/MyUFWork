package com.imop.lj.gameserver.battle.convertor;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.helper.FightUnitHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
//import com.imop.lj.gameserver.battle.service.PositionFightUnitAmend;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.EnemyParamContent;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.enemy.template.EnemyGuaJiNumTemplate;
import com.imop.lj.gameserver.enemy.template.EnemyNumTemplate;
import com.imop.lj.gameserver.enemy.template.EnemyTemplate;

/**
 * 返回游戏中enemy战斗对象
 * 
 * @author yuanbo.gao
 * 
 */
public class EnemyConvertor extends UnitConvertor {

	/**
	 * 转换成FightUnit对象
	 */
	@Override
	public List<FightUnit> convert(Object object,boolean isAttacker, BattleType type) {
		EnemyParamContent epc = (EnemyParamContent) object;
		Integer enemyArmyId = epc.getEnemyArmyId();
		Integer humanNum = epc.getHumanNum();
		int level = epc.getLevel();
		boolean isGuaJi = epc.isGuaji();
		EnemyArmyTemplate enemyArmyTpl = Globals.getTemplateCacheService().get(enemyArmyId, EnemyArmyTemplate.class);
		EnemyNumTemplate enemyNumTpl = Globals.getTemplateCacheService().get(humanNum, EnemyNumTemplate.class);
		EnemyGuaJiNumTemplate enemyGuaJiNumTpl = Globals.getTemplateCacheService().get(humanNum, EnemyGuaJiNumTemplate.class);
		
		if(enemyArmyTpl == null || enemyNumTpl == null
				|| enemyGuaJiNumTpl == null){
			Loggers.battleLogger.error("enemyArmyTpl or enemyNumTpl or enemyGuaJiNumTpl is null!");
			return null;
		}
		
		//确定本次固定+随机怪物
		List<Integer> targetList = new ArrayList<Integer>();
		List<FightUnit> result = new ArrayList<FightUnit>();
		Integer minRandomNum = 0;
		Integer maxRandomNum = 0;
		List<Integer> fixedList = enemyArmyTpl.getFixedEnemyIdList();
		//先将固定的怪物放入列表
		targetList.addAll(fixedList);
		//算出需要随机的怪物数量
		if(fixedList.size() >= enemyNumTpl.getMaxNum()){
			minRandomNum = 0;
			maxRandomNum = 0;
		}else if(fixedList.size() >= enemyNumTpl.getMinNum()){
			minRandomNum = 0;
			maxRandomNum = enemyNumTpl.getMaxNum()-fixedList.size();
		}else{
			minRandomNum = enemyNumTpl.getMinNum()-fixedList.size();
			maxRandomNum = enemyNumTpl.getMaxNum()-fixedList.size();
		}
		
		int resNum = isGuaJi ? enemyGuaJiNumTpl.getMaxNum() : RandomUtils.betweenInt(minRandomNum, maxRandomNum, true);
		//根据权重随机对应的怪物
		List<Integer> randomList = RandomUtils.hitObjectsWithWeightNum(enemyArmyTpl.getUnFixedEnemyProbList(), enemyArmyTpl.getUnFixedEnemyIdList(), resNum);
		if(randomList != null && randomList.size() != 0){
			targetList.addAll(randomList);
		}
		//生成战斗单元
		int pos = 0;
		for (Integer enemyId : targetList) {
			pos++;
			if (enemyId > 0) {
				EnemyTemplate enemyTpl = Globals.getTemplateCacheService().get(enemyId, EnemyTemplate.class);
				String id = genFighterId(pos, isAttacker);
				result.add(FightUnitHelper.toFightUnit(id, pos, enemyTpl, level));
			}
		}

		return result;
	}
	
	/**
	 * 返回战斗类型
	 */
	public FighterType getType() {
		return FighterType.ENEMY;
	}

	/**
	 * 没有附加类型战斗类型效果
	 */
	@SuppressWarnings("unchecked")
	public List<IEffect> getEffects(Object object, boolean attacker) {
		return Collections.EMPTY_LIST;
	}
}