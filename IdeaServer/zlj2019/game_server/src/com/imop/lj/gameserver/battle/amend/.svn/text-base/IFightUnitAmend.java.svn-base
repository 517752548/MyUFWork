package com.imop.lj.gameserver.battle.amend;

import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.offlinedata.PetBattleSnap;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.template.BattleTypeTemplate;

/**
 * 战斗单位修正接口
 * 
 * @author xiaowei.liu
 * 
 */
public interface IFightUnitAmend {
	/**
	 * 在线修正
	 * 
	 * @param unit
	 *            被修正单位
	 * @param pet
	 *            被修正武将
	 * @param battleIndex
	 * @param id
	 * @param horseBattle
	 * @param isAttacker
	 */
	void onlineAmend(FightUnit unit, Pet pet, int battleIndex, String id,
			BattleTypeTemplate battleTypeTemplate, boolean isAttacker);

	/**
	 * 离线数据修正
	 * 
	 * @param unit
	 *            被修正单位
	 * @param userSnap
	 *            被修正角色
	 * @param petSnap
	 *            被修正单位
	 * @param battleIndex
	 * @param id
	 * @param horseBattle
	 * @param isAttacker
	 */
	void offlineAmend(FightUnit unit, UserSnap userSnap, PetBattleSnap petSnap,
			int battleIndex, String id,	BattleTypeTemplate battleTypeTemplate, 
			boolean isAttacker);
}
