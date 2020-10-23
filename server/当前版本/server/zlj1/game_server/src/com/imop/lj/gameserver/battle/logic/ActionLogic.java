package com.imop.lj.gameserver.battle.logic;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Collection;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.EffectType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.FightUnitStatus;
import com.imop.lj.gameserver.battle.core.IAction;
import com.imop.lj.gameserver.battle.core.IFightConfig;
import com.imop.lj.gameserver.battle.core.IRound;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.report.ActionReportRecord;
import com.imop.lj.gameserver.battle.report.RecordContent;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.common.Globals;

public abstract class ActionLogic extends LogicBase implements IAction {
	private final IFightConfig config;
	private IRound round;
	private Collection<FightUnit> enemies;
	private Collection<FightUnit> friends;
	private Collection<FightUnit> deadEnemies;
	private Collection<FightUnit> deadFriends;
	private FightUnit owner;
	private List<IEffect> effects;
	private Map<IEffect, List<FightUnit>> targets = new LinkedHashMap<IEffect, List<FightUnit>>();
	
	/** 效果执行阶段额外添加的效果 */
	private Map<IEffect, Set<IEffect>> addEMap = new LinkedHashMap<IEffect, Set<IEffect>>();

	private Context context = new Context();
	
	private int actionTime;
	
	public ActionLogic(IFightConfig config) {
		super(new ActionReportRecord());
		this.config = config;
	}

	public void initialize(IRound round, IFightConfig config) {
		this.round = round;
		initialize(round);
	}

	public abstract void initialize(IRound paramIRound);

	@Override
	public void execute() {
		if(Loggers.battleLogger.isDebugEnabled()){
			Loggers.battleLogger.debug("【"+getOwner().getIdentifier()+"】行动开始#####");
		}
		//设置为已出手
		getOwner().setActionFlag(true);
		
		if (!getOwner().hasStatus(FightUnitStatus.DISABLE)) {
			start(); 																	// 行动开始
			target();																	// 寻找目标
			targetAfter();																// 寻找目标后
			doExecute();																// 技能执行
			defence();																	// 防御			
			adjust();																	// 修正，如武器技能判定
			end();																		// 行动结束，数值计算，死亡判定
		} else {
			if (this.logger.isDebugEnabled()) {
				String message = MessageFormat.format("战斗单位[{0}]被行动禁止", getOwner().getIdentifier());
				this.logger.debug(message);
			}
		}
		
		if(Loggers.battleLogger.isDebugEnabled()){
			Loggers.battleLogger.debug("【"+getOwner().getIdentifier()+"】行动结束#####");
		}
		this.round.next();
	}

	private void start() {
		beforeStart();
		List<FightUnit> units = getAllUnits();
		saveReports(Phase.ACTION_START, executeEffects(Phase.ACTION_START, units));
		afterStart();
	}

	private void target() {
		beforeTarget();
		List<ReportItem> reportItems = new ArrayList<ReportItem>();
		List<IEffect> effects = this.getEffects(Phase.ACTION_TARGET);
		if(effects == null || effects.isEmpty()){
			return;
		}
		
		for (IEffect effect : effects) {
			List<ReportItem> items = effect.execute(Phase.ACTION_TARGET, this);
			if (items != null) {
				for (ReportItem item : items) {
					reportItems.add(item);
				}
			}
		}
		if (!reportItems.isEmpty()) {
			Phase phase = Phase.ACTION_TARGET;
			int skillId = getEffects().get(0).getSkillId();
			String owner = getOwner().getIdentifier();
//			List<RecordContent> list = new ArrayList<RecordContent>();
			RecordContent reportContent = new RecordContent(owner, skillId, reportItems);

//			list.add(reportContent);
//			saveReports(phase, list);
			saveReport(phase, reportContent);
		}
		afterTarget();
	}
	
	private void targetAfter() {
		List<ReportItem> reportItems = new ArrayList<ReportItem>();
		List<IEffect> effects = this.getEffects(Phase.ACTION_TARGET_AFTER);
		if(effects == null || effects.isEmpty()){
			return;
		}
		
		for (IEffect effect : effects) {
			List<ReportItem> items = effect.execute(Phase.ACTION_TARGET_AFTER, this);
			if (items != null) {
				for (ReportItem item : items) {
					reportItems.add(item);
				}
			}
		}
		if (!reportItems.isEmpty()) {
			Phase phase = Phase.ACTION_TARGET_AFTER;
			int skillId = getEffects().get(0).getSkillId();
			String owner = getOwner().getIdentifier();
//			List<RecordContent> list = new ArrayList<RecordContent>();
			RecordContent reportContent = new RecordContent(owner, skillId, reportItems);

//			list.add(reportContent);
//			saveReports(phase, list);
			saveReport(phase, reportContent);
		}
	}

	private void doExecute() {
		List<ReportItem> reportItems = new ArrayList<ReportItem>();
		ReportItem bri = beforeExecute();
		//添加寻找目标阶段免疫的单位
		List<ReportItem> targetItem = ((ActionReportRecord)this.getReportRecord()).getReportItemAtTarget();
		reportItems.addAll(targetItem);
		
		if (bri != null) {
			reportItems.add(bri);
		}
		
		List<IEffect> effects = this.getEffects(Phase.ACTION_EXECUTE);
		if(effects == null || effects.isEmpty()){
			return;
		}
		for (IEffect effect : effects) {
			List<ReportItem> items = effect.execute(Phase.ACTION_EXECUTE, this);
			if (items != null) {
				for (ReportItem item : items) {
					reportItems.add(item);
				}
				
				//只有主效果算时间
				if (effect.isMain()) {
					String composeId = getOwner().getModelId() + effect.getSkillId();
					addActionTime(Globals.getTemplateCacheService().getBattleTemplateCache().getSkillPerformTime(composeId));
				}
			}
		}
		if (!reportItems.isEmpty()) {
			Phase phase = Phase.ACTION_EXECUTE;
			int skillId = getEffects().get(0).getSkillId();
			String owner = getOwner().getIdentifier();
			
			//最近一次释放技能失败，提示玩家技能消耗失败
			if (!getOwner().isLastCheckSelSkillCostFlag() &&
					getOwner().getLastCheckSelSkillId() > BattleDef.NORMAL_ATTACK_SKILL_ID) {
				reportItems.get(0).setErrMsg(Globals.getBattleService().getSkillCostError(getOwner().getLastCheckSelSkillId()));
			}
			
//			List<RecordContent> list = new ArrayList<RecordContent>();
			RecordContent reportContent = new RecordContent(owner, skillId, reportItems);
//			list.add(reportContent);
//			saveReports(phase, list);
			saveReport(phase, reportContent);
		}
		afterExecute();
	}

	private void defence() {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("行动:防御");
		}

		beforeDefence();
		List<FightUnit> units = getAllUnits();
		saveReports(Phase.ACTION_DEFENCE, executeEffects(Phase.ACTION_DEFENCE, units));
		afterDefence();
	}

	private void adjust() {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("行动:调整");
		}

		beforeAdjust();
		List<FightUnit> units = getAllUnits();
		saveReports(Phase.ACTION_ADJUST, executeEffects(Phase.ACTION_ADJUST, units));
		afterAdjust();
	}

	private void end() {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("行动:结束");
		}

		beforeEnd();
		List<FightUnit> units = getAllUnits();
		saveReports(Phase.ACTION_END, executeEffects(Phase.ACTION_END, units));
		afterEnd();
	}

	private List<FightUnit> getAllUnits() {
		List<FightUnit> units = new ArrayList<FightUnit>(this.friends.size() + this.enemies.size());
		units.addAll(this.friends);
		units.addAll(this.enemies);
		return units;
	}

	public Context getContext() {
		return this.context;
	}

	public List<IEffect> getEffects() {
		return this.effects;
	}
	
	/**
	 * 获取技能，一个Action内，只可被顺序的调用一次，不可重复
	 * 
	 * @param phase
	 * @return
	 */
	public abstract List<IEffect> getEffects(Phase phase);

	public void setEffects(List<IEffect> effects) {
		this.effects = effects;
	}

	public List<FightUnit> getTargets(IEffect effect) {
		return this.targets.get(effect);
	}

	public Set<FightUnit> getTargets() {
		HashSet<FightUnit> result = new HashSet<FightUnit>();
		for (List<FightUnit> current : this.targets.values()) {
			result.addAll(current);
		}
		return result;
	}

	public void setTargets(IEffect effect, List<FightUnit> targets) {
		this.targets.put(effect, targets);
	}
	
	protected void addTarget(IEffect effect, FightUnit target) {
		List<FightUnit> curList = this.targets.get(effect);
		if (curList == null) {
			curList = new ArrayList<FightUnit>();
			setTargets(effect, curList);
		}
		curList.add(target);
	}

	/**
	 * 获取主效果的目标
	 * @return
	 */
	public List<FightUnit> getMainTarget() {
		for (IEffect e : targets.keySet()) {
			if (e.isMain()) {
				return getTargets(e);
			}
		}
		return null;
	}
	
	public IRound getRound() {
		return this.round;
	}

	public Collection<FightUnit> getEnemies() {
		return this.enemies;
	}

	public Collection<FightUnit> getFriends() {
		return this.friends;
	}

	public FightUnit getOwner() {
		return this.owner;
	}

	public IFightConfig getConfig() {
		return this.config;
	}

	public void setRound(IRound round) {
		this.round = round;
	}

	public void setEnemies(Collection<FightUnit> enemies) {
		this.enemies = enemies;
	}

	public void setFriends(Collection<FightUnit> friends) {
		this.friends = friends;
	}

	public void setOwner(FightUnit owner) {
		this.owner = owner;
	}
	
	protected Set<IEffect> getAddEList(IEffect fromEffect) {
		return addEMap.get(fromEffect);
	}
	
	public Collection<FightUnit> getDeadEnemies() {
		return deadEnemies;
	}

	public void setDeadEnemies(Collection<FightUnit> deadEnemies) {
		this.deadEnemies = deadEnemies;
	}

	public Collection<FightUnit> getDeadFriends() {
		return deadFriends;
	}

	public void setDeadFriends(Collection<FightUnit> deadFriends) {
		this.deadFriends = deadFriends;
	}

	/**
	 * 增加额外附加的效果，在执行一些效果时附加的
	 * @param fromE
	 * @param targets
	 * @param addEClz 需要指定是哪种类型的效果
	 */
	public <T extends IEffect> void addEffectExtra(IEffect fromE, FightUnit target, Class<T> addEClz) {
		List<IEffect> addList = new ArrayList<IEffect>();
		for (IEffect addE : getOwner().getAddEffectList()) {
			if (!addE.getClass().equals(addEClz)) {
				continue;
			}
			//判断要添加的效果是否来自指定的效果
			if (addE.isFrom(fromE)) {
				//设置效果的目标
				addTarget(addE, target);
				addList.add(addE);
			}
		}
		if (!addList.isEmpty()) {
			addAddEffect(fromE, addList);
		}
	}
	
	protected void addAddEffect(IEffect fromEffect, List<IEffect> addEList) {
		Set<IEffect> curList = addEMap.get(fromEffect);
		if (curList == null) {
			curList = new LinkedHashSet<IEffect>();
			addEMap.put(fromEffect, curList);
		}
		curList.addAll(addEList);
	}

	protected void beforeStart() {
	}

	protected void afterStart() {
	}

	protected void beforeTarget() {
	}

	protected void afterTarget() {
	}

	protected ReportItem beforeExecute() {
		//行动执行之前，扣除技能消耗
		ReportItem item = getOwner().doSkillCost();
		return item;
	}
	
	protected void afterExecute() {
		execAddE(Phase.ACTION_EXECUTE_AFTER);
	}

	protected void execAddE(Phase phase) {
		if (this.addEMap.isEmpty()) {
			return;
		}
		
		List<RecordContent> rcList = new ArrayList<RecordContent>();
		RecordContent preRc = null;
		for (IEffect fromEffect : this.addEMap.keySet()) {
			Set<IEffect> addList = getAddEList(fromEffect);
			if (addList == null || addList.isEmpty()) {
				continue;
			}
			for (IEffect effect : addList) {
				if (effect.isVaild(phase, this)) {
					List<ReportItem> items = effect.execute(phase, this);
					if (items != null) {
						int skillId = effect.getReportSkillId(this);
						RecordContent rc = null;
						if (preRc != null && preRc.getSkillId() == skillId) {
							rc = preRc;
						} else {
							rc = new RecordContent(getOwner().getIdentifier(), skillId, new ArrayList<ReportItem>());
							preRc = rc;
						}
						// 单独判断连击
						if(EffectType.DoubleAttackWithValue == effect.getType()){
							rc.setDoubleAttack(true);
						}
						
						rc.addAllReports(items);
						rcList.add(rc);
					}
				}
			}
		}
		
		if (!rcList.isEmpty()) {
			saveReports(phase, rcList);
		}
	}

	@Override
	public int getActionTime() {
		return this.actionTime;
	}

	@Override
	public void addActionTime(int add) {
		this.actionTime += add;
	}
	
//	public boolean isEscape() {
//		return isEscape;
//	}
//
//	public void setEscape(boolean isEscape) {
//		this.isEscape = isEscape;
//	}

	protected void beforeTalentTarget(){
	}
	
	protected void afterTalentTarget(){
	}
	
	protected void beforeTalentExecute(){
	}
	
	protected void afterTalentExecute(){
	}
	
	protected void beforeDefence() {
	}

	protected void afterDefence() {
	}

	protected void beforeAdjust() {
	}

	protected void afterAdjust() {
	}

	protected void beforeEnd() {
	}

	protected void afterEnd() {
	}
	
}