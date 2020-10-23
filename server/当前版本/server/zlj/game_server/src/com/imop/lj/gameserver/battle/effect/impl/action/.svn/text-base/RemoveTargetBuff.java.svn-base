package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.effect.impl.buff.BaseBuffEffect;
import com.imop.lj.gameserver.battle.helper.EffectHelper;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;

/**
 * 我方清坏buff/敌方清好buff 
 */
public class RemoveTargetBuff extends AbstractAction {

	public RemoveTargetBuff(int effectId) {
		super(effectId, EffectType.RemoveTargetBuff, new Phase[] {Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
	}
	
	@Override
	protected List<ReportItem> doActionStart(Phase paramPhase,
			Action paramAction) {
		return null;
	}
	
	@Override
	public boolean isVaild(Phase phase) {
		if (!super.isVaild(phase)) {
			return false;
			
		}
		
		//判断概率是否命中
		double prob = calcRemoveProb();
		return RandomUtils.isHit(prob, getOwner().getRandom());
	}
	
	/**
	 * 移除buff的概率
	 * @return
	 */
	protected double calcRemoveProb() {
		//清除deBUFF的几率=初始几率
		double prob = EffectHelper.int2Double((int)getEffectTpl().getValueBase());
		return prob;
	}
	
	@Override
	protected List<ReportItem> doActionExecute(Phase paramPhase,
			Action action) {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("call " + effectId + ".doActionExecute()");
		}
		
		if (TargetHelper.targetNotFound(action, this)) {
			return null;
		}

		
		List<ReportItem> content = new ArrayList<ReportItem>();
		for (FightUnit target : action.getTargets(this)) {
			
			List<IEffect> rmList = new ArrayList<IEffect>();
			boolean isFriend = getOwner().isAttacker() == target.isAttacker();
			if(isFriend){
				// 我方清坏buff
				List<IEffect> badBuffList = target.getBadBuffEffectList();
				if (badBuffList == null || badBuffList.isEmpty()) {
					continue;
				}
				
				int removeNum = (int)EffectHelper.int2Double(getEffectTpl().getValueCoef());
				if (removeNum < 1) {
					continue;
				}
				
				int size = badBuffList.size();
				if (removeNum < size) {
					for (int i = 0; i < removeNum; i++) {
						int randIndex = RandomUtil.nextEntireInt(0, badBuffList.size() - 1);
						rmList.add(badBuffList.remove(randIndex));
					}
				} else {
					rmList = badBuffList;
				}
			}else{
				//敌方清好buff 
				
				List<IEffect> goodBuffList = target.getGoodBuffEffectList();
				if (goodBuffList == null || goodBuffList.isEmpty()) {
					continue;
				}
				
				int removeNum = (int)EffectHelper.int2Double(getEffectTpl().getValueCoef());
				if (removeNum < 1) {
					continue;
				}
				
				int size = goodBuffList.size();
				if (removeNum < size) {
					for (int i = 0; i < removeNum; i++) {
						int randIndex = RandomUtil.nextEntireInt(0, goodBuffList.size() - 1);
						rmList.add(goodBuffList.remove(randIndex));
					}
				} else {
					rmList = goodBuffList;
				}
				
			}
			
			for (IEffect e : rmList) {
				BaseBuffEffect buff = (BaseBuffEffect)e;
				
				if (this.logger.isDebugEnabled()) {
					this.logger.debug("移除随机debuff执行，将要删除buffId=" + buff.getEffectTpl().getBuffTypeId());
				}
				
				List<ReportItem> r = buff.remove();
				content.addAll(r);
			}
		}

		if (content.isEmpty()) {
			return null;
		}
		return content;
	}
	
	@Override
	protected List<ReportItem> doActionEnd(Phase paramPhase, Action paramAction) {
		return null;
	}
}
