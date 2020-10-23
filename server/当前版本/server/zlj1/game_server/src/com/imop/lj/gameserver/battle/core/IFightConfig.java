package com.imop.lj.gameserver.battle.core;

import java.util.Comparator;
import java.util.List;

import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.effect.IEffect;

/**
 * 根据不同战斗不同配置，不同战斗类型（BattleType）对应不同战斗配置
 * 
 * @author yuanbo.gao
 * 
 */
public interface IFightConfig {
	/**
	 * 生成battle对象
	 * 
	 * @param attackers
	 * @param attackerEffects
	 * @param defenders
	 * @param defenderEffects
	 * @return
	 */
	public IBattle buildBattle(List<FightUnit> attackers, List<IEffect> attackerEffects, List<FightUnit> defenders,
			List<IEffect> defenderEffects);

	/**
	 * 创建新的回合
	 * 
	 * @param paramIBattle
	 * @return
	 */
	public IRound buildCurrentRound(IBattle battle);

	/**
	 * 创建新的行动
	 * 
	 * @param paramIRound
	 * @return
	 */
	public IAction buildCurrentAction(IRound round);

	/**
	 * 返回战斗类型
	 * 
	 * @return
	 */
	public BattleType getType();

	/**
	 * 返回最大回合数
	 * 
	 * @return
	 */
	public int getMaxRound();
	
	/**
	 * 返回最大行动数
	 * 
	 * @return
	 */
	public int getMaxAction();

	/**
	 * 返回战斗单位比较器
	 * 
	 * @return
	 */
	public abstract Comparator<FightUnit> getUnitComparator();

	/**
	 * 调整战斗结果，平局的战斗结果调整，根据业务逻辑调整攻防方的输赢
	 * @param paramIBattle
	 * @param paramBattleReport
	 */
	public abstract void adjustResult(IBattle battle);
}
