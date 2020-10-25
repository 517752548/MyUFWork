package com.imop.lj.gameserver.battle.helper;

import com.imop.lj.gameserver.battle.core.BattleDef.BattleResult;
import com.imop.lj.gameserver.battle.report.BattleReport;

public class BattleResultHelper {

	/**
	 * 攻击方是否胜利
	 * @param battleReport
	 * @return
	 */
	public static boolean isAttackerWin(BattleReport battleReport) {
		return battleReport.getResult() == BattleResult.ATTACKER ? true : false;
	}
	
	public static boolean isAttackerLost(BattleReport battleReport){
		return battleReport.getResult() == BattleResult.DEFENDER;
	}
	
}
