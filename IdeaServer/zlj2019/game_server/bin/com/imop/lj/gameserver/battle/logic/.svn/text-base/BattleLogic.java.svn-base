package com.imop.lj.gameserver.battle.logic;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Collection;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.imop.lj.gameserver.battle.core.BattleDef.BattleStatus;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.BattleDef.RoundStatus;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.IBattle;
import com.imop.lj.gameserver.battle.core.IFightConfig;
import com.imop.lj.gameserver.battle.core.IRound;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.report.BattleReportRecord;
import com.imop.lj.gameserver.battle.report.RecordContent;
import com.imop.lj.gameserver.battle.report.ReportItem;
import com.imop.lj.gameserver.battle.report.RoundReportRecord;
import com.imop.lj.gameserver.pet.PetDef.PetType;

public abstract class BattleLogic extends LogicBase implements IBattle {
	private final IFightConfig config;
	private int maxRound;
	private BattleStatus status = BattleStatus.PREPARE;
	private IRound current;
	private int round = 1;
	private LinkedHashMap<String, FightUnit> initialAttackers;
	private LinkedHashMap<String, FightUnit> initialDefenders;
	
	//当前还活着的战斗单元集合
	private LinkedHashMap<String, FightUnit> attackers;
	private LinkedHashMap<String, FightUnit> defenders;
	
	//死亡的战斗单元，用于复活
	private Map<String, FightUnit> deadAttackers;
	private Map<String, FightUnit> deadDefenders;
	
	//当前逃跑的战斗单元集合
	private Map<String, FightUnit> escapeAttackers;
	private Map<String, FightUnit> escapeDefenders;
	
	private Set<IEffect> attackerEffects = new HashSet<IEffect>();
	private Set<IEffect> defenderEffects = new HashSet<IEffect>();
	
	private String attackerLeaderId;
	private String defenderLeaderId;

	private List<RoundReportRecord> roundReports = new ArrayList<RoundReportRecord>();
	private boolean start;
	private boolean end;
	
	private int attackerUseDrugsTimes;
	private int defenderUseDrugsTimes;
	
//	//使用过的宠物集合，key为玩家id，值是使用过的宠物集合
//	private Map<Long, Set<Long>> attackerPetPetSet = Maps.newHashMap();
//	private Map<Long, Set<Long>> defenderPetPetSet = Maps.newHashMap();
	
	private BattleType type;
	
	public BattleLogic(IFightConfig config) {
		//XXX 战斗
		super(new BattleReportRecord());
		this.config = config;
	}

	@Override
	public void initialize(List<FightUnit> attackers, List<IEffect> attackerEffects, List<FightUnit> defenders,
			List<IEffect> defenderEffects, IFightConfig config) {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("战斗:初始化");
		}

		this.initialAttackers = new LinkedHashMap<String, FightUnit>();
		for(FightUnit u : attackers){
			this.initialAttackers.put(u.getIdentifier(), u);
//			if (u.isPet()) {
//				addPetPet(u, true);
//			}
		}
		
		this.initialDefenders = new LinkedHashMap<String, FightUnit>();
		for(FightUnit u : defenders){
			this.initialDefenders.put(u.getIdentifier(), u);
//			if (u.isPet()) {
//				addPetPet(u, false);
//			}
		}

		this.attackers = new LinkedHashMap<String, FightUnit>(initialAttackers.size());
		for (FightUnit u : initialAttackers.values()) {
			String id = u.getIdentifier();
			this.attackers.put(id, u.clone());
			
			if (u.isLeader()) {
				this.attackerLeaderId = id;
			}
		}
		this.defenders = new LinkedHashMap<String, FightUnit>(initialDefenders.size());
		for (FightUnit u : initialDefenders.values()) {
			String id = u.getIdentifier();
			
			this.defenders.put(id, u.clone());
			if (u.isLeader()) {
				this.defenderLeaderId = id;
			}
		}

		this.maxRound = config.getMaxRound();

		this.attackerEffects.addAll(attackerEffects);
		this.defenderEffects.addAll(defenderEffects);

		this.deadAttackers = new HashMap<String, FightUnit>();
		this.deadDefenders = new HashMap<String, FightUnit>();
		
		this.escapeAttackers = new HashMap<String, FightUnit>();
		this.escapeDefenders = new HashMap<String, FightUnit>();
		
		this.reportRecord.setBattle(this);
	}

	protected void beforeStart() {
	}

	protected void afterStart() {
	}

	protected void beforeEnd() {
	}

	protected void afterEnd() {
	}

	public void next() {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("战斗:下一回合");
		}

		IRound round = getCurrent();
		if (round.getStatus() != RoundStatus.END) {
			String message = MessageFormat.format("当前回合的状态[{0}]不是[{1}]状态", round.getStatus(), RoundStatus.END);

			this.logger.error(message);
		}

		this.roundReports.add((RoundReportRecord)round.getReportRecord());

		if (this.attackers.size() == 0) {
			end();
		} else if (this.defenders.size() == 0) {
			end();
		} else if (this.round == this.maxRound) {
			//达到最大轮数
			end();
		} else {
			this.round += 1;
			this.current = this.config.buildCurrentRound(this);
		}
	}
	
	@Override
	public boolean inProgress() {
		if (this.status == BattleStatus.PREPARE) {
			return false;
		}
		if (this.status == BattleStatus.END) {
			return false;
		}

		return true;
	}

	@Override
	public void start() {
		if (this.start) {
			return;
		}

		if (this.logger.isDebugEnabled()) {
			this.logger.debug("战斗:开始");
		}
		
		beforeStart();
		List<FightUnit> units = new ArrayList<FightUnit>(this.attackers.size() + this.defenders.size());
		units.addAll(this.attackers.values());
		units.addAll(this.defenders.values());
		saveReports(Phase.BATTLE_START, executeEffects(Phase.BATTLE_START, units));
		afterStart();
		this.start = true;

		this.status = BattleStatus.IN_PROGRESS;
		this.current = this.config.buildCurrentRound(this);
	}

	@Override
	public void end() {
		if (this.end) {
			return;
		}
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("战斗:结束");
		}

//		BattleReportRecord report = (BattleReportRecord)getReportRecord();
		//FIXME
//		report.addRoundRecodes(this.roundReports);
//		report.addToContent(Phase.BATTLE_IN_PROGRESS.name(), this.roundReports);

		beforeEnd();
		List<FightUnit> units = new ArrayList<FightUnit>(this.attackers.size() + this.defenders.size());
		units.addAll(this.attackers.values());
		units.addAll(this.defenders.values());
		saveReports(Phase.BATTLE_END, executeEffects(Phase.BATTLE_END, units));

		units.clear();
		units.addAll(this.attackers.values());
		for (FightUnit unit : units) {
			if (unit.isGeneralDead()) {
				this.attackers.remove(unit.getIdentifier());
			}
		}
		units.clear();
		units.addAll(this.defenders.values());
		for (FightUnit unit : units) {
			if (unit.isGeneralDead()) {
				this.defenders.remove(unit.getIdentifier());
			}
		}

		afterEnd();
		this.end = true;

		this.status = BattleStatus.END;
	}

	@Override
	protected List<RecordContent> executeEffects(Phase phase, List<FightUnit> units) {
		List<IEffect> effects = new ArrayList<IEffect>();
		for (FightUnit u : units) {
			effects.addAll(u.getEffectsForExec(phase));
		}

		effects.addAll(this.attackerEffects);
		effects.addAll(this.defenderEffects);
		Collections.sort(effects);

		List<RecordContent> result = new ArrayList<RecordContent>();
		for (IEffect e : effects) {
			if (e.isVaild(phase, this)) {
				List<ReportItem> reportItems = e.execute(phase, this);
				if (reportItems != null && !reportItems.isEmpty()) {
					int skillId = e.getSkillId();
					String owner = e.getOwner().getIdentifier();
					RecordContent recordContent = new RecordContent(owner, skillId, reportItems);
					result.add(recordContent);
				}
			}
		}
		return result;
	}

	public Collection<FightUnit> getInitialAttackers() {
		return this.initialAttackers.values();
	}

	public Collection<FightUnit> getInitialDefenders() {
		return this.initialDefenders.values();
	}

	public Map<String, FightUnit> getAttackers() {
		return this.attackers;
	}

	public Map<String, FightUnit> getDefenders() {
		return this.defenders;
	}

	public int getRound() {
		return this.round;
	}

	public BattleType getType() {
		return this.type;
//		return this.config.getType();
	}

	public void setType(BattleType type) {
		this.type = type;
	}
	
	public BattleStatus getStatus() {
		return this.status;
	}

	@Override
	public int getMaxRound() {
		return this.maxRound;
	}

	public boolean isStart() {
		return this.start;
	}

	@Override
	public boolean isEnd() {
		return this.end;
	}

	public IRound getCurrent() {
		return this.current;
	}

	public IFightConfig getConfig() {
		return this.config;
	}
	
	/**
	 * 获取攻击方主将
	 * @return
	 */
	public FightUnit getAttakcerLeader() {
		return this.attackers.get(attackerLeaderId);
	}
	
	/**
	 * 获取防守方主将
	 * @return
	 */
	public FightUnit getDefenderLeader() {
		return this.defenders.get(defenderLeaderId);
	}

	/**
	 * 获取攻击方死亡对象中，可用于操作的集合
	 */
	public List<FightUnit> getCanOpDeadAttackers() {
		return getCanOpList(deadAttackers.values());
	}
	
	/**
	 * 获取防守方死亡对象中，可用于操作的集合
	 */
	public List<FightUnit> getCanOpDeadDefenders() {
		return getCanOpList(deadDefenders.values());
	}
	
	/**
	 * XXX 获取集合对象中，可用于操作的集合，即过滤掉 被捕捉、被击飞、逃跑的对象
	 * @param col
	 * @return
	 */
	private List<FightUnit> getCanOpList(Collection<FightUnit> col) {
		List<FightUnit> mList = new ArrayList<FightUnit>();
		mList.addAll(col);
		//过滤掉非法状态的对象
		Iterator<FightUnit> it = mList.iterator();
		while(it.hasNext()) {
			FightUnit fu = it.next();
			if (!fu.canOp()) {
				it.remove();
			}
		}
		return mList;
	}
	
	public Map<String, FightUnit> getDeadAttackers() {
		return deadAttackers;
	}

	public Map<String, FightUnit> getDeadDefenders() {
		return deadDefenders;
	}
	
	public Map<String, FightUnit> getEscapeAttackers() {
		return escapeAttackers;
	}

	public Map<String, FightUnit> getEscapeDefenders() {
		return escapeDefenders;
	}
	
	public void addEscapeAttacker(FightUnit fu) {
		this.escapeAttackers.put(fu.getIdentifier(), fu);
	}
	
	public void addEscapeDefender(FightUnit fu) {
		this.escapeDefenders.put(fu.getIdentifier(), fu);
	}

	public RoundReportRecord getLastRoundReport() {
		if (roundReports.size() > 0) {
			return roundReports.get(roundReports.size() - 1);
		}
		return null;
	}
	
	/**
	 * 获取攻击方or防守方嗑药次数
	 */
	public int getUseDrugsTimes(boolean isAttacker) {
		if (isAttacker) {
			return this.attackerUseDrugsTimes;
		} else {
			return this.defenderUseDrugsTimes;
		}
	}
	
	public void addUseDrugsTimes(boolean isAttacker) {
		if (isAttacker) {
			this.attackerUseDrugsTimes++;
		} else {
			this.defenderUseDrugsTimes++;
		}
	}
	
	public void delFightUnit(FightUnit fu, boolean isAttacker) {
		String id = fu.getIdentifier();
		if (isAttacker) {
			this.initialAttackers.remove(id);
			this.attackers.remove(id);
			this.deadAttackers.remove(id);
		} else {
			this.initialDefenders.remove(id);
			this.defenders.remove(id);
			this.deadDefenders.remove(id);
		}
	}
	
//	protected void addPetPet(FightUnit fu, boolean isAttacker) {
//		if (isAttacker) {
//			Set<Long> set = this.attackerPetPetSet.get(fu.getOwnerId());
//			if (set == null) {
//				set = new HashSet<Long>();
//				this.attackerPetPetSet.put(fu.getOwnerId(), set);
//			}
//			set.add(fu.getPetUUId());
//		} else {
//			Set<Long> set = this.defenderPetPetSet.get(fu.getOwnerId());
//			if (set == null) {
//				set = new HashSet<Long>();
//				this.defenderPetPetSet.put(fu.getOwnerId(), set);
//			}
//			set.add(fu.getPetUUId());
//		}
//	}
	
	public void addFightUnit(FightUnit fu, boolean isAttacker) {
		String id = fu.getIdentifier();
		if (isAttacker) {
			this.initialAttackers.put(id, fu);
			this.attackers.put(id, fu);
//			if (fu.isPet()) {
//				addPetPet(fu, true);
//			}
		} else {
			this.initialDefenders.put(id, fu);
			this.defenders.put(id, fu);
//			if (fu.isPet()) {
//				addPetPet(fu, false);
//			}
		}
	}

//	public Set<Long> getPetPetSet(long roleId, boolean isAttacker) {
//		if (isAttacker) {
//			return this.attackerPetPetSet.get(roleId);
//		} else {
//			return this.defenderPetPetSet.get(roleId);
//		}
//	}
	
	public FightUnit getBattleFU(boolean isAttacker, boolean leaderOrPet, long ownerId) {
		FightUnit fu = null;
		Collection<FightUnit> fuCol = isAttacker ? getInitialAttackers() : getInitialDefenders();
		for (FightUnit f : fuCol) {
			if (ownerId == f.getOwnerId()) {
				if ((leaderOrPet && f.getUnitType() == PetType.LEADER) ||
						(!leaderOrPet && f.getUnitType() == PetType.PET)) {
					fu = f;
					break;
				}
			}
		}
		return fu;
	}
}