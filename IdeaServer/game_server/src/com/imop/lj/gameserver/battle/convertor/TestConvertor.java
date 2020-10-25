package com.imop.lj.gameserver.battle.convertor;

import java.util.Collections;
import java.util.List;

import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;

/**
 * 返回游戏中enemy战斗对象
 * 
 * @author yuanbo.gao
 * 
 */
public class TestConvertor extends UnitConvertor {

	/**
	 * 转换成FightUnit对象
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<FightUnit> convert(Object object, boolean isAttacker, BattleType type) {
		return null;
//		List<StoryTestBattleTemplate> gList = (List<StoryTestBattleTemplate>) object;
//		
//		List<FightUnit> result = new ArrayList<FightUnit>();
//		//生成战斗单元
//		for (StoryTestBattleTemplate tpl : gList) {
//			int enemyId = isAttacker ? tpl.getAtkEnmeyId() : tpl.getDefEnmeyId();
//			if (enemyId > 0) {
//				EnemyTemplate enemyTpl = Globals.getTemplateCacheService().get(enemyId, EnemyTemplate.class);
//				String id = genFighterId(tpl.getPosId(), isAttacker);
//				result.add(FightUnitHelper.toFightUnit(id, tpl.getPosId(), enemyTpl, 1));
//			}
//		}
//		
//		return result;
	}

	/**
	 * 返回战斗类型
	 */
	@Override
	public FighterType getType() {
		return FighterType.TEST;
	}

	/**
	 * 没有附加类型战斗类型效果
	 */
	@SuppressWarnings("unchecked")
	@Override
	public List<IEffect> getEffects(Object object, boolean attacker) {
		return Collections.EMPTY_LIST;
	}
}