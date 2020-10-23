package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.effect.AbstractEffect;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.report.ReportItem;

/**
 * 连击
 * 
 */
public class DoubleAttackWithValue extends AbstractEffect {

	public DoubleAttackWithValue(int effectId) {
		super(effectId, EffectType.DoubleAttackWithValue, new Phase[]{Phase.ACTION_EXECUTE_AFTER});
	}
	
	@Override
	public boolean isVaild(Phase phase, Object context) {
		if (!super.isVaild(phase, context)) {
			return false;
		}
		
		// 连击概率
		double rate = EffectHelper.int2Double(getEffectTpl().getValueCoef());
		if (!RandomUtils.isHit(rate, owner.getRandom())) {
			return false;
		}
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("效果[{}]:连击触发，机率[{}]", this.getEffectTpl().getId(), Double.valueOf(rate));
		}
		return true;
	}
	
	@Override
	protected List<ReportItem> doExecute(Phase phase, Object context) {
		Action action = (Action) context;
		Context ctx = action.getContext();
		ctx.put(BattleDef.DOUBLE_ATTACK, Boolean.valueOf(true));
		List<IEffect> effects = action.getEffects(Phase.ACTION_EXECUTE);
		List<ReportItem> content = new ArrayList<ReportItem>();
		
		for (IEffect effect : effects) {
			List<ReportItem> reportLst = effect.execute(Phase.ACTION_EXECUTE, action);
			if(reportLst == null){
				if (Loggers.battleLogger.isDebugEnabled()) {
					logger.debug(action.getOwner().getIdentifier() + "effect execute ACTION_EXECUTE report is null!effectId=" + effect.getId()
					 +";action info= " + action);
				}
				continue;
			}
			content.addAll(reportLst);
		}
		//回复初始值
		ctx.put(BattleDef.DOUBLE_ATTACK, Boolean.valueOf(false));
		return content;
	}
	
	@Override
	public boolean isFrom(IEffect fromE) {
		if (fromE instanceof AttackCoef) {
			return true;
		}
		return false;
	}
}