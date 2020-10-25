package com.imop.lj.gameserver.battle;

import java.text.MessageFormat;
import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.convertor.UnitConvertor;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.battle.effect.IEffect;

/**
 * unit管理器
 *
 */
public class UnitService {

	protected final Logger logger = Loggers.battleLogger;

	public List<FightUnit> transform(Fighter<?> identifier, BattleType type) {
		UnitConvertor convertor = getUnitConvertor(identifier);
		List<FightUnit> result = convertor.convert(identifier.getContent(), identifier.isAttacker(), type);
		if(result == null || result.isEmpty()) {
			return result;
		}else{
			for(FightUnit unit : result) {
				unit.setAttacker(identifier.isAttacker());
				String id = this.genFighterId(unit.getPosition(), unit.isAttacker());
				unit.setId(id);
			}
			return result;
		}
	}

	public String genFighterId(int position, boolean isAttacker) {
		String id = (isAttacker ? "a":"d") + position;
		return id;
	}
	
	public String genHorseFighterId(boolean isAttacker) {
		String id = (isAttacker ? "ah":"dh");
		return id;
	}
	
	public List<IEffect> getAttackerEffects(Fighter<?> attacker) {
		UnitConvertor convertor = getUnitConvertor(attacker);
		return convertor.getEffects(attacker.getContent(), true);
	}

	public List<IEffect> getDefenderEffects(Fighter<?> defender) {
		UnitConvertor convertor = getUnitConvertor(defender);
		return convertor.getEffects(defender.getContent(), false);
	}

	protected UnitConvertor getUnitConvertor(Fighter<?> identifier) {
		FighterType type = identifier.getType();
		UnitConvertor convertor = type.getConvertor();
		if (convertor == null) {
			String message = MessageFormat.format("战斗单位类型[{0}]的转换器不存在", type);
			this.logger.error(message);
			// throw new ConfigurationException(message.getMessage());
		}
		return convertor;
	}
}