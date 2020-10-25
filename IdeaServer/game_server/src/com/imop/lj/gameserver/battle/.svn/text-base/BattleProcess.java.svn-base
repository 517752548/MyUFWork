package com.imop.lj.gameserver.battle;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import net.sf.json.JSONObject;

import org.slf4j.Logger;

import com.google.gson.Gson;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.exception.BattleCreateException;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleResult;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.battle.core.IAction;
import com.imop.lj.gameserver.battle.core.IBattle;
import com.imop.lj.gameserver.battle.core.IFightConfig;
import com.imop.lj.gameserver.battle.core.IRound;
import com.imop.lj.gameserver.battle.effect.IEffect;
import com.imop.lj.gameserver.battle.helper.IntIdHelper;
import com.imop.lj.gameserver.battle.helper.IntIdHelper.IntIdType;
import com.imop.lj.gameserver.battle.pvp.PvpPlayerInfo;
import com.imop.lj.gameserver.battle.report.BattleReportRecord;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.pet.PetDef.PetType;

/**
 * 战斗过程构建器
 * 
 */
public class BattleProcess {
	protected final Logger logger = Loggers.battleLogger;
	protected static final String BATTLE_TYPE_KEY = "battleType";
	
	protected int battleId;
	
	protected IBattle battle;
	/** 是否生成战报 */
	protected boolean genReport;
	
	/** 攻击方玩家id */
	protected long attackerId;
	/** 战斗开始时间，用于超时检测 */
	protected long startTime;
	
	protected Object defender;
	
	protected List<String> report = new ArrayList<String>();
	protected String finalReport = null;
	//战斗结束保存战报的时候赋值
	protected long reportId;
	
	/** 最近一轮开始时间 */
	protected long lastRoundStartTime;
	/** 最近一轮播放时间 */
	protected int lastRoundPerformTime;
	/** 最近一轮播放时间最小值 */
	protected int lastRoundPerformTimeMin;
	
	/** 战斗的额外参数 */
	protected Object param;
	
	/** 嗑药次数累计 */
	protected int useDrugsTimes;
	
	public BattleProcess(long attackerId, BattleType type, Fighter<?> attacker, Fighter<?> defender) throws BattleCreateException {
		this(attackerId, type, attacker, defender, true);
	}
	
	public BattleProcess(long attackerId, BattleType type, Fighter<?> attacker, Fighter<?> defender, boolean genReport) throws BattleCreateException {
		this.genReport = genReport;
		try {
			int battleId = IntIdHelper.genNextIntId(IntIdType.BATTLE);
			this.setBattleId(battleId);
			
			this.attackerId = attackerId;
			this.defender = defender.getContent();
			startTime = Globals.getTimeService().now();
			battle = createBattle(type, attacker, defender);
			
			if (battle == null) {
				throw new RuntimeException("battle creating error!");
			}
		} catch(Exception e) {
			e.printStackTrace();
			throw new BattleCreateException("create battle error!", e);
		}
	}
	
	/**
	 * 获取战斗开始时间
	 * @return
	 */
	public long getStartTime() {
		return this.startTime;
	}

	/**
	 * 获取攻击方角色Id
	 * @return
	 */
	public long getAttackerId() {
		return attackerId;
	}
	
	public Object getDefenderContent() {
		return defender;
	}

	/**
	 * 开始战斗
	 */
	public String start() {
		if (Loggers.battleLogger.isDebugEnabled()) {
			Loggers.battleLogger.debug("====战斗开始====");
		}
		
		Map<Integer, Object> js = new HashMap<Integer, Object>();
		getBattleReportRecord().makeBeforeRoundAttrReport(js, getSpeed());
		
		battle.start();
		
		getBattleReportRecord().makeBattleStartReport(js);
		
		String reportStr = makeReportStr(js);
		report.add(reportStr);
		return reportStr;
	}
	
	/**
	 * 一轮战斗
	 * @return
	 */
	public String round() {
		lastRoundStartTime = Globals.getTimeService().now();
		
		//战报速度
		int reportSpeed = getSpeed();
		
		Map<Integer, Object> js = new HashMap<Integer, Object>();
		getBattleReportRecord().makeBeforeRoundAttrReport(js, reportSpeed);
		
		do {
			int roundNum = battle.getRound();
			//如果战斗超过指定轮数，则强制结束
			if (roundNum > battle.getMaxRound()) {
				Loggers.battleLogger.warn("battle reach max round,will force end!");
				end(true);
				break;
			}
			
			if (Loggers.battleLogger.isDebugEnabled()) {
				Loggers.battleLogger.debug("第 " + (roundNum) + " 轮战斗开始-----");
			}
			
			if (!battle.inProgress()) {
				Loggers.battleLogger.error("battle is not in progress!");
				return null;
			}
			
			IRound round = battle.getCurrent();
			round.start();
			
			// 执行武将行动
			for (int j = 0; j < round.getMaxAction(); j++) {
				if (!round.inProgress()) {
					break;
				}
				
				IAction action = round.getCurrent();
				action.execute();
				
				round.addPerformTime(action.getActionTime());
				round.addPerformTimeMin(action.getActionTimeMin());
			}
			lastRoundPerformTime = round.getPerformTime();
			lastRoundPerformTimeMin = round.getPerformTimeMin();
			
			if (Loggers.battleLogger.isDebugEnabled()) {
				Loggers.battleLogger.debug("第 " + (roundNum) + " 轮战斗结束-----lastRoundPerformTime=" + 
						lastRoundPerformTime + ";lastRoundPerformTimeMin=" + lastRoundPerformTimeMin);
			}
			
			//判断战斗是否需要结束，如果是，则结束
			if (battle.isEnd()) {
				end(false);
			}
		} while (false);
		
		getBattleReportRecord().makeLastRoundReport(js, reportSpeed);
		
		String reportStr = makeReportStr(js);
		report.add(reportStr);
		
//		//战斗结束，生成最终战报
//		if (isBattleEnd()) {
//			this.finalReport = makeFinalReport();
//		}
		
		return reportStr;
	}
	
	public String getBeforeRoundReport() {
		Map<Integer, Object> js = new HashMap<Integer, Object>();
		getBattleReportRecord().makeBeforeRoundAttrReport(js, getSpeed());
		String reportStr = makeReportStr(js);
		return reportStr;
	}
	
	public boolean isBattleEnd() {
		return battle.isEnd();
	}
	
	public boolean isGenReport() {
		return genReport;
	}
	
	public String getLastReport() {
		if (!report.isEmpty()) {
			return report.get(report.size() - 1);
		}
		return null;
	}
	
	public List<String> getReportList() {
		return report;
	}
	
	/**
	 * 这个数据一般情况为null，只有竞技场的战报不是null
	 * @return
	 */
	public String getFinalReport() {
		return this.finalReport;
	}
	
	/**
	 * 这句话执行很慢，需要放到IO操作里面执行，不要随便调用
	 * @return
	 */
	public String makeFinalReport() {
		this.finalReport = makeReportStr(report);
		return finalReport;
	}
	
	public BattleResult getBattleResult() {
		return getBattleReportRecord().getBattleResult();
	}
	
	/**
	 * 战斗结束
	 */
	protected void end(boolean isForce) {
		if (!battle.isEnd()) {
			return;
		}
		
		if (Loggers.battleLogger.isDebugEnabled()) {
			Loggers.battleLogger.debug("====战斗结束==== isForce=" + isForce);
		}
	}
	
	public FightUnit getBattleFU(boolean isAttacker, boolean leaderOrPet, long ownerId) {
		return battle.getBattleFU(isAttacker, leaderOrPet, ownerId);
	}
	
	private FightUnit getAttackerFULive(boolean leaderOrPet) {
		FightUnit fu = null;
		Map<String, FightUnit> atkMap = battle.getAttackers();
		for (FightUnit f : atkMap.values()) {
			if ((leaderOrPet && f.getUnitType() == PetType.LEADER) ||
					(!leaderOrPet && f.getUnitType() == PetType.PET)) {
				fu = f;
				break;
			}
		}
		return fu;
	}
	
	public FightUnit getAttackerFULive(boolean leaderOrPet, long ownerId) {
		if (ownerId <= 0) {
			return getAttackerFULive(leaderOrPet);
		}
		FightUnit fu = null;
		Map<String, FightUnit> atkMap = battle.getAttackers();
		for (FightUnit f : atkMap.values()) {
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
	
	private FightUnit getDefenderFULive(boolean leaderOrPet) {
		FightUnit fu = null;
		Map<String, FightUnit> defMap = battle.getDefenders();
		for (FightUnit f : defMap.values()) {
			if ((leaderOrPet && f.getUnitType() == PetType.LEADER) ||
					(!leaderOrPet && f.getUnitType() == PetType.PET)) {
				fu = f;
				break;
			}
		}
		return fu;
	}
	
	public FightUnit getDefenderFULive(boolean leaderOrPet, long ownerId) {
		if (ownerId <= 0) {
			return getDefenderFULive(leaderOrPet);
		}
		FightUnit fu = null;
		Map<String, FightUnit> atkMap = battle.getDefenders();
		for (FightUnit f : atkMap.values()) {
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
	
	public Collection<FightUnit> getFUs(boolean isLive, boolean isAttacker) {
		return isLive ? getLiveFUs(isAttacker) : getDeadFUs(isAttacker);
	}
	
	public Collection<FightUnit> getAllFUs(boolean isAttacker) {
		return isAttacker ? battle.getInitialAttackers() : battle.getInitialDefenders();
	}
	
	public Collection<FightUnit> getAllCanOpFUs(boolean isAttacker) {
		List<FightUnit> ret = new ArrayList<FightUnit>();
		ret.addAll(getLiveFUs(isAttacker));
		ret.addAll(getCanOpDeadFUs(isAttacker));
		return ret;
	} 
	
	protected Collection<FightUnit> getLiveFUs(boolean isAttacker) {
		return isAttacker ? battle.getAttackers().values() : battle.getDefenders().values();
	}
	
	protected Collection<FightUnit> getDeadFUs(boolean isAttacker) {
		return isAttacker ? battle.getDeadAttackers().values() : battle.getDeadDefenders().values();
	}
	
	protected Collection<FightUnit> getEscapeFUs(boolean isAttacker) {
		return isAttacker ? battle.getEscapeAttackers().values() : battle.getEscapeDefenders().values();
	}
	
	protected Collection<FightUnit> getCanOpDeadFUs(boolean isAttacker) {
		return isAttacker ? battle.getCanOpDeadAttackers() : battle.getCanOpDeadDefenders();
	}
	
	public int getAttackerCatchPetTplId() {
		int petTplId = 0;
		if (battle.getDeadDefenders() != null && !battle.getDeadDefenders().isEmpty()) {
			for (FightUnit fu : battle.getDeadDefenders().values()) {
				if (fu.isCaught()) {
					petTplId = fu.getCatchPetId();
					break;
				}
			}
		}
		return petTplId;
	}
	
	public long getAttackerCatchPetOwnerId() {
		long ownerId = 0;
		if (battle.getDeadDefenders() != null && !battle.getDeadDefenders().isEmpty()) {
			for (FightUnit fu : battle.getDeadDefenders().values()) {
				if (fu.isCaught()) {
					ownerId = fu.getCatcherOwnerId();
					break;
				}
			}
		}
		return ownerId;
	}
	
	/**
	 * 获取最近一轮开始时间，如果还没开始战斗，则返回战斗开始时间
	 * @return
	 */
	public long getLastRoundStartTime() {
		if (lastRoundStartTime != 0) {
			return lastRoundStartTime;
		} else {
			return startTime;
		}
	}

	public int getLastRoundPerformTime() {
		return lastRoundPerformTime;
	}
	
	public int getLastRoundPerformTimeMin() {
		return lastRoundPerformTimeMin;
	}
	
	/**
	 * 获取最后一轮战斗显示上的结束时间
	 * @return
	 */
	public long getLastRoundEndTime() {
		return this.getLastRoundStartTime() + this.getLastRoundPerformTime();
	}
	
	/**
	 * 获取最后一轮战斗最小的结束时间
	 * @return
	 */
	public long getLastRoundEndTimeMin(int speed) {
		return this.getLastRoundStartTime() + (int)(this.getLastRoundPerformTimeMin() * 1.0f / speed);
	}

	public Object getParam() {
		return param;
	}

	public void setParam(Object param) {
		this.param = param;
	}
	
	public PvpPlayerInfo getPlayerInfo(long roleId) {
		return null;
	}
	
	public boolean isAllSet() {
		return false;
	}
	
	public boolean isAllReadLast() {
		return false;
	}

	protected IBattle createBattle(BattleType type, Fighter<?> attacker, Fighter<?> defender) {
		UnitService unitService = Globals.getUnitService();
		List<FightUnit> attackers = unitService.transform(attacker, type);		
		//是否有攻击方
		if(attackers == null || attackers.isEmpty()){
			Loggers.battleLogger.error("attackers is empty or null!");
			return null;
		}
		
		List<IEffect> attackerEffects = unitService.getAttackerEffects(attacker);
		
		List<FightUnit> defenders = unitService.transform(defender, type);
		//是否有防御方
		if(defenders == null || defenders.isEmpty()){
			Loggers.battleLogger.error("defenders is empty or null!");
			return null;
		}

		List<IEffect> defenderEffects = unitService.getDefenderEffects(defender);

		return createBattle(type, attackers, attackerEffects, defenders, defenderEffects);
	}
	
	protected IBattle createBattle(BattleType type, List<FightUnit> attackers, List<IEffect> attackerEffects,
			List<FightUnit> defenders, List<IEffect> defenderEffects) {
		IFightConfig config = type.getFightConfig();
		IBattle battle = config.buildBattle(attackers, attackerEffects, defenders, defenderEffects);
		battle.setType(type);
		return battle;
	}
	
	protected BattleReportRecord getBattleReportRecord() {
		return (BattleReportRecord)battle.getReportRecord();
	}
	
	public static String makeReportStr(Object js) {
		Gson gs = new Gson();
		return gs.toJson(js);
	}
	
	public BattleType getBattleType() {
		return this.battle.getType();
	}
	
	public IBattle getBattle() {
		return this.battle;
	}
	
	public final int getBattleId() {
		return this.battleId;
	}
	
	protected void setBattleId(int battleId) {
		this.battleId = battleId;
	}

	public String buildAdditionPack() {
		JSONObject obj = new JSONObject();
		obj.put(BATTLE_TYPE_KEY,this.battle.getType().getToBackType());
		return obj.toString();
	}
	
	/**
	 * 获取战报速度
	 * @return
	 */
	public int getSpeed() {
		//默认取攻击方的速度，竞技场没有加速过滤掉
		int speed = SharedConstants.REPORT_SPEED_DEFAULT;
		if (attackerId > 0 
				&& getBattleType() != BattleType.ARENA) {
			speed = Globals.getBattleService().getBattleSpeedByRoleId(attackerId);
		}
		return speed;
	}

	public long getReportId() {
		return reportId;
	}

	public void setReportId(long reportId) {
		this.reportId = reportId;
	}
	
}