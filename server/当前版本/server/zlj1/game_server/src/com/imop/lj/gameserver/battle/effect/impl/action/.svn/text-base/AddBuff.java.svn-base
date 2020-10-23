package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.FightUnitStatus;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.effect.impl.buff.BaseBuffEffect;
import com.imop.lj.gameserver.battle.helper.EffectFactory;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;

public class AddBuff extends AbstractAction {

	public AddBuff(int effectId) {
		super(effectId, EffectType.AddBuff, new Phase[] {Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
	}

	@Override
	public boolean isVaild(Phase phase) {
		if (!super.isVaild(phase)) {
			return false;
		}
		
		//判断概率是否命中
		double prob = calcAddBuffProb();
		boolean isHit = RandomUtils.isHit(prob, getOwner().getRandom());
		
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("AddBuff prob=" + prob + ";isHit=" + isHit + 
					";effectId=" + getEffectTpl().getId());
		}
		
		return isHit;
	}
	
	/**
	 * 加buff的概率
	 * @return
	 */
	protected double calcAddBuffProb() {
		return EffectHelper.int2Double(getEffectTpl().getExtraCoef5());
	}
	
	protected boolean preCost(FightUnit owner, FightUnit target, List<ReportItem> content) {
		return true;
	}
	
	@Override
	protected List<ReportItem> doActionExecute(Phase paramPhase,
			Action action) {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("call " + effectId + ".doActionExecute()");
		}
		FightUnit owner = getOwner();
		
		if (TargetHelper.targetNotFound(action, this)) {
			return null;
		}
		
		boolean isBuffTargetRevive = getEffectTpl().isBuffTargetRevive();

		List<ReportItem> content = new ArrayList<ReportItem>();
		for (FightUnit target : action.getTargets(this)) {
			//按照死亡类型判断
			if (!isBuffTargetRevive) {
				//普通的buff，必须活着的对象才能加
				if (!target.isAlive()) {
					this.logger.warn("target " + target.getIdentifier() + " is not alive,can not add buff!buffEffectId=" + effectId);
					continue;
				}
			} else {
				if (!target.isCanRevive()) {
					this.logger.warn("target " + target.getIdentifier() + " can not revive,can not add buff!buffEffectId=" + effectId);
					continue;
				}
			}
			
			//有无敌buff的人，不受负面buff影响
			if (getEffectTpl().isBad() && target.hasStatus(FightUnitStatus.NBDZT)) {
				if (this.logger.isDebugEnabled()) {
					this.logger.debug("target " + target.getIdentifier() + " has NBDZT status,can not add buff.buffEffectId=" + effectId);
				}
				continue;
			}
			
			//加buff之前的处理
			boolean canCost = preCost(owner, target, content);
			if(!canCost){
				if (this.logger.isDebugEnabled()) {
					this.logger.debug("target " + target.getIdentifier() + " preCost ret value is invalid,can not add buff.buffEffectId=" + effectId);
				}
				continue;
			}
			
			BaseBuffEffect buffEffect = EffectFactory.buildBuffEffect(this);
			List<ReportItem> report = buffEffect.addTo(target, Math.abs(buffEffect.getValue().intValue()));
			content.addAll(report);
		}

		if (content.isEmpty()) {
			return null;
		}
		return content;
	}
	
	@Override
	protected List<ReportItem> doActionStart(Phase paramPhase,
			Action paramAction) {
		return null;
	}
	
	@Override
	protected List<ReportItem> doActionEnd(Phase paramPhase, Action paramAction) {
		return null;
	}

}
