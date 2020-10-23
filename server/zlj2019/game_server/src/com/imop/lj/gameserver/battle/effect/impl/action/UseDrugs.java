package com.imop.lj.gameserver.battle.effect.impl.action;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.FightUnitStatus;
import com.imop.lj.gameserver.battle.effect.AbstractAction;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battlereport.BattleReportDefine;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.item.ItemDef.FightDrugsType;

/**
 * 嗑药技能
 * @author yu.zhao
 *
 */
public class UseDrugs extends AbstractAction {

	public UseDrugs(int effectId) {
		super(effectId, EffectType.UseDrugs, new Phase[] {Phase.ACTION_TARGET, Phase.ACTION_EXECUTE});
	}

	@Override
	protected List<ReportItem> doActionExecute(Phase paramPhase, Action action) {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("call " + effectId + ".doActionExecute()");
		}
		
		Context context = action.getContext();
		List<FightUnit> tList = action.getTargets(this);
		//目前只有一个目标
		FightUnit target = null;
		if (tList != null && !tList.isEmpty()) {
			target = tList.get(0);
		}
		
		List<ReportItem> content = new ArrayList<ReportItem>();
		ReportItem report = ReportItem.valueOf(getOwner(), this);
		
		boolean flag = false;
		
		//如果可以对目标嗑药
		if (target != null && 
				canUseItem(target) &&
				costItem()) {
			//使用药物
			ReportItem ri = useItem(target, context);
			if (ri != null) {
				//统计嗑药次数
				action.getRound().getBattle().addUseDrugsTimes(getOwner().isAttacker());
				
				//嗑药成功
				report.updateAction(BattleReportDefine.REPORT_ITEM_USE_DRUGS, Boolean.valueOf(true));
				content.add(report);
				//嗑药效果
				content.add(ri);
				
				flag = true;
			}
		}
		
		//嗑药失败
		if (!flag) {
			report.updateAction(BattleReportDefine.REPORT_ITEM_USE_DRUGS, Boolean.valueOf(false));
			content.add(report);
		}
		
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("嗑药结果=" + flag);
		}
		
		return content;
	}
	
	protected boolean canUseItem(FightUnit target) {
		FightUnit fu = getOwner();
		if (fu.isDead()) {
			return false;
		}
		// 玩家/宠物自身混乱状态下,可以使用物品,但是使用后无效果操作无效,不扣除物品
		if (fu.hasStatus(FightUnitStatus.CHAOS)) {
			return false;
		}
		
		// 玩家/宠物眩晕状态下,可以对目标使用药
		//是否有对应道具
		boolean flag = Globals.getBattleService().hasItem(fu.getOwnerId(), fu.getSelItemId());
		if (!flag) {
			return false;
		}
		
		//处于不可操作状态的战斗单元，不能嗑药
		if (!target.canOp()) {
			return false;
		}
		
		return true;
	}
	
	protected boolean costItem() {
		FightUnit fu = getOwner();
		return Globals.getBattleService().costUseDrugsItemInFight(fu.getOwnerId(), fu.getSelItemId(), fu);
	}
	
	protected ReportItem useItem(FightUnit target, Context context) {
		int itemId = getOwner().getSelItemId();
		if (!Globals.getBattleService().isValidUseDrugsItem(itemId)) {
			return null;
		}
		
		ReportItem ri = ReportItem.valueOf(target, this);
		
		FightDrugsType dt = Globals.getBattleService().getUseDrugsItemTemplate(itemId).getFightDrugsType();
		int value = Globals.getBattleService().getUseDrugsItemValue(itemId);
		if (dt == FightDrugsType.HP) {
			if (!target.isDead()) {
				//加血
				context.increaseValue(target, BattleDef.HP, value);
				
				//没死的加血
				ri.updateAttr(BattleReportDefine.REPORT_ITEM_HP, value);
			} else {
				if (Globals.getBattleService().canUseDrugsItemRevive(itemId)) {
					//复活参数设置
					target.getReviveAttrMap().put(BattleDef.HP, Double.valueOf(value));
					
					//死了，该药可复活，则复活&加血
					ri.updateAction(BattleReportDefine.REPORT_ITEM_REVIVE, Boolean.valueOf(true));
					ri.updateAttr(BattleReportDefine.REPORT_ITEM_HP, value);
				} else {
					//死了，药不能复活，使用失败
					return null;
				}
			}
			
		} else if (dt == FightDrugsType.MP) {
			//加蓝，死了，使用失败
			if (target.isDead()) {
				return null;
			}
			ri.updateAttr(BattleReportDefine.REPORT_ITEM_MP, value);
			
			//加蓝
			context.increaseValue(target, BattleDef.MP, value);
		}
		
		return ri;
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
