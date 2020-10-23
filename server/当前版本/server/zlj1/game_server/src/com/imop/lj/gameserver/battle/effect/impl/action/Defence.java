package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.effect.AbstractEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.BaseBuffEffect;
import com.imop.lj.gameserver.battle.helper.EffectFactory;
import com.imop.lj.gameserver.battle.report.ReportItem;

/**
 * 防御技能
 * 在回合开始时，给自己加防御buff
 * @author yu.zhao
 *
 */
public class Defence extends AbstractEffect {

	public Defence(int effectId) {
		super(effectId, EffectType.Defence, new Phase[] {Phase.ROUND_START});
	}

	@Override
	protected List<ReportItem> doExecute(Phase phase, Object context) {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("call effectId=" + effectId + " doExecute()");
		}

		List<ReportItem> content = new ArrayList<ReportItem>();
		
		BaseBuffEffect buffEffect = EffectFactory.buildBuffEffect(this);
		List<ReportItem> report = buffEffect.addTo(this.getOwner(), 0);
		content.addAll(report);

		if (content.isEmpty()) {
			return null;
		}
		return content;
	}
	
}
