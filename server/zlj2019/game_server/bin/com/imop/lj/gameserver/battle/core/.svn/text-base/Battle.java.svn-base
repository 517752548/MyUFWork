package com.imop.lj.gameserver.battle.core;

import com.imop.lj.gameserver.battle.core.BattleDef.BattleResult;
import com.imop.lj.gameserver.battle.logic.BattleLogic;
import com.imop.lj.gameserver.battle.report.BattleReportRecord;

/**
 * 战斗对象，包含多个回合对象（Round）
 * @author yuanbo.gao
 *
 */
public class Battle extends BattleLogic {
	
	public Battle(IFightConfig config) {
		super(config);
	}

	/**
	 * 战斗阶段结束
	 */
	@Override
	protected void afterEnd() {
		BattleReportRecord report = (BattleReportRecord)getReportRecord();
		//没有逃跑时
		if ((getAttackers().size() == 0) && (getDefenders().size() == 0)) {
			if (this.logger.isDebugEnabled()) {
				this.logger.debug("攻击方、防守方全都死光光");
			}
			report.setBattleResult(BattleResult.TIE);
		} else if (getAttackers().size() == 0) {
			if (this.logger.isDebugEnabled()) {
				this.logger.debug("防守方胜利");
			}
			report.setBattleResult(BattleResult.DEFENDER);
		} else if (getDefenders().size() == 0) {
			if (this.logger.isDebugEnabled()) {
				this.logger.debug("攻击方胜利");
			}
			report.setBattleResult(BattleResult.ATTACKER);
		} else {
			if (this.logger.isDebugEnabled()) {
				this.logger.debug("最大回合数");
			}
			report.setBattleResult(BattleResult.TIE);
		}
		//这里会修正战斗结果
		IFightConfig config = getType().getFightConfig();
		config.adjustResult(this);
	}
	
}