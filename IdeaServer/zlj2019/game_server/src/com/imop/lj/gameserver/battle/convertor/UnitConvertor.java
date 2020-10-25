package com.imop.lj.gameserver.battle.convertor;

import java.util.List;

import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.IEffect;
//import com.imop.lj.gameserver.pet.template.PetDef.PositionType;

/**
 * 战斗对象转换对象 根据战斗对象标识类型FighterType，从Fighter中的content参数转化成战斗战斗对象FightUnit对象
 * 
 * @author yuanbo.gao
 * 
 */
public abstract class UnitConvertor {

	/** 根据参数返回战斗对象 */
	public abstract List<FightUnit> convert(Object param,boolean isAttacker, BattleType type);
	
	

	/** 返回战斗对象类型 */
	public abstract FighterType getType();

	/** 返回根据参数返回附加效果对象 */
	public abstract List<IEffect> getEffects(Object param, boolean paramBoolean);
	
	/**
	 * 根据参数获得战斗唯一id
	 * @param position
	 * @param index
	 * @param isAttacker
	 * @return
	 */
	public static String genFighterId(int index, boolean isAttacker) {
		String id = (isAttacker ? "a":"d") + index;
		return id;
	}
}
