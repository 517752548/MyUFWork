package com.imop.lj.gameserver.battle.config;

import java.util.Comparator;
import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.Battle;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleResult;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.IAction;
import com.imop.lj.gameserver.battle.core.IBattle;
import com.imop.lj.gameserver.battle.core.IFightConfig;
import com.imop.lj.gameserver.battle.core.IRound;
import com.imop.lj.gameserver.battle.core.Round;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.report.BattleReportRecord;

/**
 * 单人战役
 * 
 */
public class SingleFightConfig implements IFightConfig {
	/** 最大回合数 */
	public static final int MAX_ROUND = 20;
	/** 最大行动数 */
	public static final int MAX_ACTION = 20;
	/** 战斗序列排序按照速度排序 */
	public static final Comparator<FightUnit> COMPARATOR = FightUnit.COMPARATOR;

	/**
	 * 返回战斗类型
	 */
	public BattleType getType() {
		return BattleType.SINGLE;
	}

	/***
	 * 返回最大回合数
	 */
	public int getMaxRound() {
		return SingleFightConfig.MAX_ROUND;
	}
	
	@Override
	public int getMaxAction() {
		return  SingleFightConfig.MAX_ACTION;
	}

	/**
	 * 创建战斗对象
	 */
	public IBattle buildBattle(List<FightUnit> attackers, List<IEffect> attackerEffects, List<FightUnit> defenders,
			List<IEffect> defenderEffects) {
		Battle battle = new Battle(this);
		battle.initialize(attackers, attackerEffects, defenders, defenderEffects, this);
		return battle;
	}

	/**
	 * 创建当前回合对象
	 */
	public IRound buildCurrentRound(IBattle owner) {
		Round result = new Round(this);
		result.initialize(owner, this);
		return result;
	}

	/**
	 * 创建当前行动对象
	 */
	public IAction buildCurrentAction(IRound owner) {
		Action result = new Action(this);
		result.initialize(owner, this);
		return result;
	}

	/**
	 * 获得战斗对象比较器
	 */
	public Comparator<FightUnit> getUnitComparator() {
		return COMPARATOR;
	}

	/**
	 * 单人战役，如果平局攻方输、防御方赢
	 */
	public void adjustResult(IBattle battle) {
		BattleReportRecord brr = (BattleReportRecord)(battle.getReportRecord());
		if (brr.getBattleResult() == BattleResult.TIE) {
			brr.setBattleResult(BattleResult.DEFENDER);
		}
	}
}