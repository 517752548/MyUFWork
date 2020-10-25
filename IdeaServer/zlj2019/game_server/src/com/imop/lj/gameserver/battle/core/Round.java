package com.imop.lj.gameserver.battle.core;

import com.imop.lj.gameserver.battle.logic.RoundLogic;

/**
 * 回合对象，多个回合组成战斗，多个行动组成一个回合
 * 
 */
public class Round extends RoundLogic {
	public Round(IFightConfig config) {
		super(config);
	}

	/**
	 * 初始化
	 */
	public void initialize(IBattle owner) {
		setAttackers(owner.getAttackers());
		setDefenders(owner.getDefenders());
		
		setDeadAttackers(owner.getDeadAttackers());
		setDeadDefenders(owner.getDeadDefenders());
		
		setEscapeAttackers(owner.getEscapeAttackers());
		setEscapeDefenders(owner.getEscapeDefenders());
	}

	/**
	 * 回合结束以后
	 */
	@Override
	protected void afterEnd() {
		super.afterEnd();
		
		for (FightUnit unit : getAttackers().values()) {
			if (unit.isGeneralDead()) {
				addDeadAttacker(unit);
			}
			//回合结束，恢复为默认值
			unit.setSelSkillId(0);
			unit.setSelTarget(0);
			//设置为未出手
			unit.setActionFlag(false);
		}
		for (String id : getDeadAttackers().keySet()) {
			getAttackers().remove(id);
			//设置为未出手
			getDeadAttacker(id).setActionFlag(false);
		}

		for (FightUnit unit : getDefenders().values()) {
			if (unit.isGeneralDead()) {
				addDeadDefender(unit);
			}
			//回合结束，恢复为默认值
			unit.setSelSkillId(0);
			unit.setSelTarget(0);
			//设置为未出手
			unit.setActionFlag(false);
		}
		
		for (String id : getDeadDefenders().keySet()) {
			getDefenders().remove(id);
			//设置为未出手
			getDeadDefender(id).setActionFlag(false);
		}
		
	}
}