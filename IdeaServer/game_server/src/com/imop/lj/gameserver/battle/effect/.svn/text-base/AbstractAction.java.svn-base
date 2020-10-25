package com.imop.lj.gameserver.battle.effect;

import java.text.MessageFormat;
import java.util.List;

import com.imop.lj.gameserver.battle.core.Action;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnitStatus;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.report.ReportItem;

/**
 * 行动类战斗效果
 * 
 */
public abstract class AbstractAction extends AbstractEffect {
	

	public AbstractAction(int effectId, EffectType effectType, Phase[] phases) {
		super(effectId, effectType, phases);
	}

	/**
	 * 执行战斗效果
	 */
	@Override
	protected List<ReportItem> doExecute(Phase phase, Object context) {
		Action action = (Action) context;
		switch (phase) {
		case ACTION_START:
			return doActionStart(phase, action);
		case ACTION_TARGET:
			return doActionTarget(phase, action);
		case ACTION_TARGET_AFTER:
			return doActionTargetAfter(phase, action);
		case ACTION_EXECUTE:
		case ACTION_EXECUTE_AFTER:
			Context ctx = action.getContext();
			if (TargetHelper.targetNotFound(action, this)) {
				if (this.logger.isDebugEnabled()) {
					String message = MessageFormat.format("战斗单位[{0}]的攻击效果[{1}]由于找不到目标被取消", getOwner().getIdentifier(), getIdentifier());
					this.logger.debug(message);
				}
				//XXX 如果找不到目标就取消
				ctx.put(BattleDef.CANCEL, Boolean.valueOf(true));

				return null;
			}

			if (this.logger.isDebugEnabled()) {
				String message = MessageFormat.format(getOwner() + "战斗单位[{0}]执行效果[{1}]", getOwner().getIdentifier(), getIdentifier());
				this.logger.debug(message);
			}
			return doActionExecute(phase, action);
		case ACTION_END:
			return doActionEnd(phase, action);
		default:
			String message = MessageFormat.format("行动效果[{0}]执行了一个无效的阶段[{1}]", getIdentifier(), phase);
			this.logger.error(message);
			return null;
		}
	}

	/**
	 * 根据此技能寻找目标类型寻找目标
	 * 
	 * @param phase
	 * @param action
	 * @return
	 */
	protected List<ReportItem> doActionTarget(Phase phase, Action action) {
		if (!action.getOwner().hasStatus(FightUnitStatus.CHAOS)) {
			TargetHelper.selectTargets(action, (IEffect) this, getEffectTpl(), getTargetNum(action.getOwner()));
		} else {
			TargetHelper.selectTargetOnChaos(action, (IEffect) this);
		}
		return null;
	}
	
	protected List<ReportItem> doActionTargetAfter(Phase phase, Action action) {
		return null;
	}

	/**
	 * 行动开始阶段
	 * @param paramPhase
	 * @param paramAction
	 * @return
	 */
	protected abstract List<ReportItem> doActionStart(Phase paramPhase, Action paramAction);

	/**
	 * 行动执行阶段
	 * @param paramPhase
	 * @param paramAction
	 * @return
	 */
	protected abstract List<ReportItem> doActionExecute(Phase paramPhase, Action paramAction);
	
	/**
	 * 行动结束阶段
	 * @param paramPhase
	 * @param paramAction
	 * @return
	 */
	protected abstract List<ReportItem> doActionEnd(Phase paramPhase, Action paramAction);

	/**
	 * 获取额外的目标人数，默认为模板配置的人数
	 * @return
	 */
	protected int getTargetNum(FightUnit owner) {
		return effectTpl.getTargetNum();
	}
	
	/**
	 * 直接调用行为的执行，在效果嵌套的时候会用
	 * @param paramPhase
	 * @param paramAction
	 * @return
	 */
	public List<ReportItem> doActionExecuteDirectly(Phase paramPhase, Action paramAction) {
		return doActionExecute(paramPhase, paramAction);
	}
}