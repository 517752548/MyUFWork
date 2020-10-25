package com.imop.lj.gameserver.battle.core;

import java.util.Collection;
import java.util.List;
import java.util.Map;

import com.imop.lj.gameserver.battle.core.BattleDef.BattleStatus;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.report.IReportRecord;
import com.imop.lj.gameserver.battle.report.RoundReportRecord;

public interface IBattle {
	/**
	 * 初始化战斗对象
	 * @param attackers 攻击者
	 * @param attackerEffects 附加战斗效果
	 * @param defenders 防御者
	 * @param defenderEffects 附加战斗效果
	 * @param config battleConfig
	 */
	public void initialize(List<FightUnit> attackers, List<IEffect> attackerEffects, List<FightUnit> defenders,
			List<IEffect> defenderEffects, IFightConfig config);

	/** 开始 */
	public void start();

	/** 结束 */
	public void end();

	/** 返回当前 */
	public IRound getCurrent();

	/** 是否在战斗中 */
	public boolean inProgress();

	/** 返回战斗状态 */
	public BattleStatus getStatus();
	
	public boolean isEnd();

	/** 下一个 */
	public void next();

	/** 返回report */
	public IReportRecord getReportRecord();

	/** 返回所有攻击者 */
	public Collection<FightUnit> getInitialAttackers();

	/** 返回所有防御者 */
	public Collection<FightUnit> getInitialDefenders();

	/** 返回所有攻击者Map */
	public Map<String, FightUnit> getAttackers();

	/** 返回所有攻击者Map */
	public Map<String, FightUnit> getDefenders();
	
	/** 返回所有死亡的攻击者Map */
	public Map<String, FightUnit> getDeadAttackers();

	/** 返回所有死亡的防守者Map */
	public Map<String, FightUnit> getDeadDefenders();
	
	/** 返回所有死亡攻击方里面可以操作的对象 */
	public List<FightUnit> getCanOpDeadAttackers();
	/** 返回所有死亡防守方里面可以操作的对象 */
	public List<FightUnit> getCanOpDeadDefenders();

	/** 返回逃跑的攻击方单位 */
	public Map<String, FightUnit> getEscapeAttackers();
	/** 返回逃跑的防守方单位 */
	public Map<String, FightUnit> getEscapeDefenders();
	public void addEscapeAttacker(FightUnit fu);
	public void addEscapeDefender(FightUnit fu);
	
	/** 返回回合数 */
	public int getRound();

	/** 返回战斗类型 */
	public BattleType getType();
	
	public void setType(BattleType type);
	
	/**返回最大轮数*/
	public int getMaxRound();
	
	public RoundReportRecord getLastRoundReport();
	
	public int getUseDrugsTimes(boolean isAttacker);
	
	public void addUseDrugsTimes(boolean isAttacker);

	public void delFightUnit(FightUnit fu, boolean isAttacker);
	
	public void addFightUnit(FightUnit fu, boolean isAttacker);
	
	public FightUnit getBattleFU(boolean isAttacker, boolean leaderOrPet, long ownerId);
}
