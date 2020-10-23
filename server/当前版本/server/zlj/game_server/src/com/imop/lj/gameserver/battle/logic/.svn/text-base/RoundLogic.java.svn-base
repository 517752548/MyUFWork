package com.imop.lj.gameserver.battle.logic;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Map;

import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.Phase;
import com.imop.lj.gameserver.battle.core.BattleDef.RoundStatus;
import com.imop.lj.gameserver.battle.core.Context;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.IAction;
import com.imop.lj.gameserver.battle.core.IBattle;
import com.imop.lj.gameserver.battle.core.IFightConfig;
import com.imop.lj.gameserver.battle.core.IRound;
import com.imop.lj.gameserver.battle.report.ActionReportRecord;
import com.imop.lj.gameserver.battle.report.RoundReportRecord;

public abstract class RoundLogic extends LogicBase implements IRound {
	private final IFightConfig config;
	private IBattle battle;
	private int round;
	private RoundStatus status = RoundStatus.PREPARE;
	
	private Map<String, FightUnit> attackers;
	private Map<String, FightUnit> defenders;
	
	//死亡的战斗单位，用于复活；另外这里面还有被捕捉的单位，这样的单位不能被复活
	private Map<String, FightUnit> deadAttackers;
	private Map<String, FightUnit> deadDefenders;
	
	/** 逃跑的战斗单位集合 */
	private Map<String, FightUnit> escapeAttackers;
	private Map<String, FightUnit> escapeDefenders;
	
	private List<FightUnit> sequence = new ArrayList<FightUnit>();
	private IAction current;
	private Context context = new Context();

	private List<ActionReportRecord> actionReports = new ArrayList<ActionReportRecord>();
	private boolean start;
	private boolean end;

	private int performTime;
	private int performTimeMin;
	
	public RoundLogic(IFightConfig config) {
		//XXX 回合
		super(new RoundReportRecord());
		this.config = config;
		
	}

	@Override
	public void initialize(IBattle owner, IFightConfig config) {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("回合:初始化");
		}
		this.battle = owner;
		this.round = battle.getRound();
		((RoundReportRecord)this.reportRecord).setRoundNum(this.round);
		
		initialize(owner);
	}

	public abstract void initialize(IBattle paramIBattle);

	@Override
	public void next() {
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("回合:下一次行动");
		}

		if (this.current.getReportRecord() != null) {
			this.actionReports.add((ActionReportRecord)this.current.getReportRecord());
		}

		if (this.sequence.size() == 0) {
			end();
			return;
		}
		
		if (this.attackers.isEmpty() || this.defenders.isEmpty()){
			end();
			return;
		}
		
		this.current = this.config.buildCurrentAction(this);
	}
	
	public boolean inProgress() {
		if (this.status == RoundStatus.PREPARE) {
			return false;
		}
		if (this.status == RoundStatus.END) {
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
			this.logger.debug("回合:开始");
		}

		beforeStart();
		List<FightUnit> units = new ArrayList<FightUnit>(this.attackers.size() + this.defenders.size());
		units.addAll(this.attackers.values());
		units.addAll(this.defenders.values());
		saveReports(Phase.ROUND_START, executeEffects(Phase.ROUND_START,  units));
		afterStart();
		this.start = true;

		//排序所有战斗单位
		sequence();
		
		this.status = RoundStatus.IN_PROGRESS;
		this.current = this.config.buildCurrentAction(this);
	}

	private void sequence() {
		this.sequence.addAll(this.attackers.values());
		this.sequence.addAll(this.defenders.values());
		Collections.sort(this.sequence, this.config.getUnitComparator());
		
		if (this.logger.isDebugEnabled()) {
			String ss = "";
			for (FightUnit unit : this.sequence) {
				ss += unit.getIdentifier() + "=" + unit.getAttr(BattleDef.SPEED) + "; ";
			}
			this.logger.debug("回合出手顺序为：" + ss);
		}
	}
	
	private void end() {
		if (this.end) {
			return;
		}
		if (this.logger.isDebugEnabled()) {
			this.logger.debug("回合:结束");
		}

		RoundReportRecord report = (RoundReportRecord)getReportRecord();
		
		report.addActionRecodes(this.actionReports);

		beforeEnd();
		List<FightUnit> units = new ArrayList<FightUnit>(this.attackers.size() + this.defenders.size());
		units.addAll(this.attackers.values());
		units.addAll(this.defenders.values());
		saveReports(Phase.ROUND_END, executeEffects(Phase.ROUND_END, units));
		afterEnd();
		this.end = true;

		this.status = RoundStatus.END;
		this.battle.next();
	}

	@Override
	public int getMaxAction() {
		return this.config.getMaxAction();
	}
	
	public RoundStatus getStatus() {
		return this.status;
	}

	public Context getContext() {
		return this.context;
	}

	@Override
	public IBattle getBattle() {
		return this.battle;
	}

	public void setBattle(IBattle battle) {
		this.battle = battle;
	}

	@Override
	public int getRound() {
		return this.round;
	}

	public void setRound(int round) {
		this.round = round;
	}

	public Map<String, FightUnit> getAttackers() {
		return this.attackers;
	}

	public void setAttackers(Map<String, FightUnit> attackers) {
		this.attackers = attackers;
	}

	public Map<String, FightUnit> getDefenders() {
		return this.defenders;
	}

	public void setDefenders(Map<String, FightUnit> defenders) {
		this.defenders = defenders;
	}

	public void addAttacker(FightUnit fu) {
		this.attackers.put(fu.getIdentifier(), fu);
	}
	
	public void addDefender(FightUnit fu) {
		this.defenders.put(fu.getIdentifier(), fu);
	}
	
	public Map<String, FightUnit> getDeadAttackers() {
		return deadAttackers;
	}

	public void setDeadAttackers(Map<String, FightUnit> deadAttackers) {
		this.deadAttackers = deadAttackers;
	}

	public Map<String, FightUnit> getDeadDefenders() {
		return deadDefenders;
	}

	public void setDeadDefenders(Map<String, FightUnit> deadDefenders) {
		this.deadDefenders = deadDefenders;
	}
	
	public void addDeadAttacker(FightUnit deadUnit) {
		this.deadAttackers.put(deadUnit.getIdentifier(), deadUnit);
	}
	
	public void addDeadDefender(FightUnit deadUnit) {
		this.deadDefenders.put(deadUnit.getIdentifier(), deadUnit);
	}

	public FightUnit getDeadAttacker(String id) {
		return this.deadAttackers.get(id);
	}
	
	public FightUnit getDeadDefender(String id) {
		return this.deadDefenders.get(id);
	}
	
	public void addEscapeAttacker(FightUnit fu) {
		this.escapeAttackers.put(fu.getIdentifier(), fu);
	}
	
	public void addEscapeDefender(FightUnit fu) {
		this.escapeDefenders.put(fu.getIdentifier(), fu);
	}
	
	public Map<String, FightUnit> getEscapeAttackers() {
		return escapeAttackers;
	}

	public void setEscapeAttackers(Map<String, FightUnit> escapeAttackers) {
		this.escapeAttackers = escapeAttackers;
	}

	public Map<String, FightUnit> getEscapeDefenders() {
		return escapeDefenders;
	}

	public void setEscapeDefenders(Map<String, FightUnit> escapeDefenders) {
		this.escapeDefenders = escapeDefenders;
	}

	public List<FightUnit> getSequence() {
		return this.sequence;
	}

	public void setSequence(List<FightUnit> sequence) {
		this.sequence = sequence;
	}
	
	/**
	 * 行动列表中移除指定的战斗对象
	 */
	public void removeFightUnitFromSequence(FightUnit fu) {
		int index = -1;
		for (int i = 0; i < sequence.size(); i++) {
			 FightUnit f = sequence.get(i);
			if (f.getIdentifier() == fu.getIdentifier()) {
				index = i;
				break;
			}
		}
		if (index >= 0) {
			sequence.remove(index);
		}
	}

	public IAction getCurrent() {
		return this.current;
	}

	public void setCurrent(IAction current) {
		this.current = current;
	}

	public boolean isStart() {
		return this.start;
	}

	public void setStart(boolean start) {
		this.start = start;
	}

	public boolean isEnd() {
		return this.end;
	}

	public void setEnd(boolean end) {
		this.end = end;
	}

	public IFightConfig getConfig() {
		return this.config;
	}

	public void setStatus(RoundStatus status) {
		this.status = status;
	}

	@Override
	public int getPerformTime() {
		return performTime;
	}

	@Override
	public void addPerformTime(int time) {
		this.performTime += time;
	}
	
	@Override
	public int getPerformTimeMin() {
		return performTimeMin;
	}

	@Override
	public void addPerformTimeMin(int time) {
		this.performTimeMin += time;
	}
	
	protected void beforeStart() {
	}

	protected void afterStart() {
	}

	protected void beforeEnd() {
	}

	protected void afterEnd() {
	}
}