package com.imop.lj.gameserver.battle.core;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.helper.TargetHelper;
import com.imop.lj.gameserver.battle.logic.ActionLogic;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.BattleEscapeEvent;

/**
 * 战斗行动对象，多个行动对象组成一个回合
 * 
 */
public class Action extends ActionLogic {
	
	public Action(IFightConfig config) {
		super(config);
	}

	/**
	 * 初始化
	 */
	public void initialize(IRound owner) {
		Round mRound = (Round) owner;

		FightUnit unit = (FightUnit) mRound.getSequence().remove(0);
		setOwner(unit);

		Collection<FightUnit> enemies = TargetHelper.getEnemies(unit, 
				mRound.getAttackers().values(), mRound.getDefenders().values());
		Collection<FightUnit> friends = TargetHelper.getFriends(unit, 
				mRound.getAttackers().values(), mRound.getDefenders().values());
		setEnemies(enemies);
		setFriends(friends);
		
		Collection<FightUnit> deadEnemies = TargetHelper.getEnemies(unit, 
				mRound.getDeadAttackers().values(), mRound.getDeadDefenders().values());
		Collection<FightUnit> deadFriends = TargetHelper.getFriends(unit, 
				mRound.getDeadAttackers().values(), mRound.getDeadDefenders().values());
		setDeadEnemies(deadEnemies);
		setDeadFriends(deadFriends);
		
	}
	
	@Override
	public List<IEffect> getEffects(Phase phase) {
		if (phase == Phase.ACTION_TARGET) {
			List<IEffect> result = null;
			int round = 0;
			if (getRound() != null) {
				round = getRound().getRound();
			}
			result = getOwner().getActionEffectsForAction(phase, round);
			if (result != null) {
				this.setEffects(result);
			}
			return result;
		}
		return super.getEffects();
	}

	/**
	 * 行动结束
	 */
	@Override
	public void afterEnd() {
		//hp、mp、sp等属性结算
		saveResult();
		//死亡流程处理
		deadProcess();
		//复活流程处理
		reviveProcess();
		//逃跑处理
		escapeProcess();
	}
	
	/**
	 * 计算血和怒气并保存结果
	 */
	private void saveResult() {
		for (FightUnit target : getAliveFightUnits()) {
			Integer value = (Integer) getContext().get(target, BattleDef.HP);
			if (value != null && value != 0) {
				target.updateAttr(BattleDef.HP, value);
			}
			
			value = (Integer) getContext().get(target, BattleDef.MP);
			if (value != null && value != 0) {
				target.updateAttr(BattleDef.MP, value);
			}

			value = (Integer) getContext().get(target, BattleDef.SP);
			if (value != null && value != 0) {
				target.updateAttr(BattleDef.SP, value);
			}
			
			value = (Integer) getContext().get(target, BattleDef.LIFE);
			if (value != null && value != 0) {
				target.updateAttr(BattleDef.LIFE, value);
			}
		}
	}

	/**
	 * 获得所有战斗对象，包括所有攻击者和防御者
	 */
	public List<FightUnit> getAliveFightUnits() {
		List<FightUnit> result = new ArrayList<FightUnit>();
		result.addAll(getEnemies());
		result.addAll(getFriends());
		return result;
	}
	
	public List<FightUnit> getAllDeadFightUnits() {
		List<FightUnit> result = new ArrayList<FightUnit>();
		result.addAll(getDeadEnemies());
		result.addAll(getDeadFriends());
		return result;
	}

	/**
	 * 死亡处理
	 */
	private void deadProcess() {
//		List<RecordContent> lt = new ArrayList<RecordContent>();
		
		Round round = (Round) getRound();
		for (FightUnit unit : getAliveFightUnits()) {
			
//			if (unit.isDeadFly()) {
//				List<ReportItem> reportItems = new ArrayList<ReportItem>();
//				ReportItem r = ReportItem.valueOf(unit);
//				r.updateAction(BattleReportDefine.REPORT_ITEM_DEAD_FLY, Boolean.valueOf(true));
//				reportItems.add(r);
//				RecordContent rc = new RecordContent(unit.getIdentifier(), BattleDef.NORMAL_ATTACK_SKILL_ID, reportItems);
//				lt.add(rc);
//			}
			
			//死亡、被捕捉的状态处理
			if (unit.isGeneralDead()) {
				if (this.logger.isDebugEnabled()) {
					String message = MessageFormat.format("战斗单位[{0}]:" + (unit.hasStatus(FightUnitStatus.DEAD) ? "死亡" : "被捕捉") , 
							unit.getIdentifier());
					this.logger.debug(message);
				}

				//出手顺序中，移除死亡的战斗单元
				round.getSequence().remove(unit);

				String id = unit.getIdentifier();
				if (round.getAttackers().containsKey(id)) {
					round.getAttackers().remove(id);
					round.addDeadAttacker(unit);
				} else if (round.getDefenders().containsKey(id)) {
					round.getDefenders().remove(id);
					round.addDeadDefender(unit);
				}
			}
		}
		
//		saveReports(Phase.ACTION_END, lt);
	}
	
	/**
	 * 复活处理
	 */
	private void reviveProcess() {
		Round round = (Round) getRound();
		for (FightUnit target : getAllDeadFightUnits()) {
			if (target.isCanRevive()) {
				String id = target.getIdentifier();
				if (this.logger.isDebugEnabled()) {
					String message = MessageFormat.format("战斗单位[{0}]复活", id);
					this.logger.debug(message);
				}
				
				//复活
				target.onRevive();
				
				if (round.getDeadAttackers().containsKey(id)) {
					round.getDeadAttackers().remove(id);
					round.addAttacker(target);
				} else if (round.getDeadDefenders().containsKey(id)) {
					round.getDeadDefenders().remove(id);
					round.addDefender(target);
				}
				
				//根据该战斗对象该轮是否出手过，判断是否再加进行动列表
				if (!target.isActionFlag()) {
					round.getSequence().add(target);
				}
			}
		}
	}
	
	/**
	 * 逃跑处理
	 */
	private void escapeProcess() {
		Round round = (Round) getRound();
		List<FightUnit> tmpList = new ArrayList<FightUnit>();
		tmpList.addAll(getAliveFightUnits());
		tmpList.addAll(getAllDeadFightUnits());
		
		long ownerId = 0;
		for (FightUnit unit : tmpList) {
			//逃跑单位处理
			if (unit.isEscape()) {
				if (this.logger.isDebugEnabled()) {
					String message = MessageFormat.format("战斗单位[{0}]:" + "逃跑！", unit.getIdentifier());
					this.logger.debug(message);
				}
				ownerId = unit.getOwnerId();
				
				//出手顺序中，移除逃跑的战斗单元
				round.getSequence().remove(unit);
				
				//从活着或死亡的map中移除，加入escapeMap
				String id = unit.getIdentifier();
				if (round.getAttackers().containsKey(id)) {
					round.getAttackers().remove(id);
					round.addEscapeAttacker(unit);
				} else if (round.getDefenders().containsKey(id)) {
					round.getDefenders().remove(id);
					round.addEscapeDefender(unit);
				} else if (round.getDeadAttackers().containsKey(id)) {
					round.getDeadAttackers().remove(id);
					round.addEscapeAttacker(unit);
				} else if (round.getDeadDefenders().containsKey(id)) {
					round.getDeadDefenders().remove(id);
					round.addEscapeDefender(unit);
				}
			}
		}
		
		//逃跑成功，外部可能需要处理，增加逃跑事件监听
		if (ownerId > 0) {
			Globals.getEventService().fireEvent(new BattleEscapeEvent(ownerId));
		}
	}

}