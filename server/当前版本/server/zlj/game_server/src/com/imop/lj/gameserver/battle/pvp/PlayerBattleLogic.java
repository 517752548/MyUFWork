package com.imop.lj.gameserver.battle.pvp;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.google.common.collect.Maps;
import com.imop.lj.common.HeartBeatAble;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.exception.BattleCreateException;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.battle.core.BattleDef;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.FightUnit;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;

public abstract class PlayerBattleLogic<T extends BattleProcess> implements HeartBeatAble {
	/** 每次check处理的战斗场数 */
	public static final int BATCH_FIGHT_NUM = 5;
	
	/** 战斗对象内存数据，保存当前正在进行的战斗key是battleId */
	protected Map<Integer, T> battleMap = Maps.newHashMap();
	/** 可以进行战斗的Id集合 */
	protected Set<Integer> canFightSet = new LinkedHashSet<Integer>();
	
	protected void addBattle(T bp) {
		this.battleMap.put(bp.getBattleId(), bp);
	}
	
	public T getBattle(int battleId) {
		return battleMap.get(battleId);
	}
	
	protected void removeBattle(int battleId) {
		if (battleMap.containsKey(battleId)) {
			battleMap.remove(battleId);
		}
	}
	
	protected Set<Integer> getCanFightSet() {
		return canFightSet;
	}
	
	protected void addCanFightSet(int battleId) {
		canFightSet.add(battleId);
	}
	
	protected boolean isInCanFightSet(int battleId) {
		return canFightSet.contains(battleId);
	}
	
	/**
	 * 开始战斗，构建战斗过程
	 * @param attackerId
	 * @param type
	 * @param attacker
	 * @param defender
	 * @param params
	 */
	protected int startBattle(long attackerId, BattleType type,
			Fighter<?> attacker, Fighter<?> defender, Object... params) {
		try {
			//构建战斗过程对象
			T bp = buildBattleProcess(attackerId, type, attacker, defender, params);
			
			//更新service的数据
			addBattle(bp);
			
			//开始战斗
			String startReport = bp.start();
			if (startReport == null) {
				Loggers.battleLogger.error("StartReport is null!attackerId=" + attackerId +
						";battleId=" + bp.getBattleId() + ";startTime=" + bp.getStartTime());
				return 0;
			}
			
			//发战报
			sendBattleStartReport(bp, startReport, params);
			return bp.getBattleId();
		} catch (BattleCreateException e) {
			e.printStackTrace();
			Loggers.battleLogger.error("pvp battle Exception!", e);
		}
		return 0;
	}
	
	protected abstract T buildBattleProcess(long attackerId, BattleType type,
			Fighter<?> attacker, Fighter<?> defender, Object... params) throws BattleCreateException;
	
	protected abstract void sendBattleStartReport(T bp, String startReport, Object... params);
	
	protected PvpPlayerInfo buildPvpPlayerInfo(long roleId, int autoActionId, int petAutoActionId, 
			boolean isAttacker) {
		PvpPlayerInfo info = new PvpPlayerInfo(roleId, isAttacker);
		info.setAuto(true);
		info.setAutoActionId(autoActionId);
		info.setPetAutoActionId(petAutoActionId);
		return info;
	}
	
	public abstract int getPlayerBattleId(long roleId);
	
	/**
	 * 更新自动战斗技能数据
	 * @param human
	 */
	public void onUpdateAutoAction(Human human) {
		long roleId = human.getUUID();
		int battleId = getPlayerBattleId(roleId);
		if (battleId > 0) {
			T bp = getBattle(battleId);
			if (bp != null) {
				PvpPlayerInfo info = bp.getPlayerInfo(roleId);
				if (info != null) {
					info.setAutoActionId(human.getAutoFightAction());
					info.setPetAutoActionId(human.getPetAutoFightAction());
				}
			}
		}
	}
	 
	/**
	 * 取消自动战斗
	 * @param human
	 */
	public abstract void cancelAuto(Human human);
	
	protected void onCancelAuto(T bp, long humanId) {
		PvpPlayerInfo info = bp.getPlayerInfo(humanId);
		if (info.isLastSetFlag()) {
			Loggers.battleLogger.warn("human already set this round action!humanId=" + humanId);
		}
		
		//设置为非自动战斗
		info.setAuto(false);
		//设置为该轮未设置技能
		info.setLastSetFlag(false);
	}
	
	public abstract void onLeaderReady(Human human);
	
	/**
	 * 每轮选择技能
	 * @param human
	 * @param isAuto
	 * @param selSkillId
	 * @param selTarget
	 * @param petSelSkillId
	 * @param petSelTarget
	 */
	public abstract void chooseSkillRound(Human human, boolean isAuto, 
			int selSkillId, int selTarget, int selItemId,
			int petSelSkillId, int petSelTarget, int petSelItemId, long summonPetId);
	
	protected void onChooseSkillRound(T bp, Human human, boolean isAuto,
			int selSkillId, int selTarget, int selItemId, 
			int petSelSkillId, int petSelTarget, int petSelItemId, long summonPetId) {
		PvpPlayerInfo info = bp.getPlayerInfo(human.getCharId());
		info.setAuto(isAuto);
		info.setLastSetFlag(true);
		//设置手动战斗的参数
		if (!isAuto) {
			Globals.getBattleService().onChooseSkill(human, bp, info.isAttacker(),
					selSkillId, selTarget, selItemId, petSelSkillId, petSelTarget, petSelItemId, summonPetId);
			
			info.setAutoActionId(human.getAutoFightAction());
			info.setPetAutoActionId(human.getPetAutoFightAction());
		}
		
		//选好技能后，通知其他人
		onChooseSkillNotice(bp, human, true);
		
		//如果都已经选了技能，则需要开始战斗
		if (bp.isAllSet()) {
			onCanFight(bp, true);
		}
	}
	
	/**
	 * 选技能后的通知
	 * @param bp
	 * @param human
	 * @param petpetFlag true包含宠物，false不包含
	 */
	protected abstract void onChooseSkillNotice(T bp, Human human, boolean petpetFlag);
	
	protected List<Long> genReadyPetIdList(T bp, Human human, boolean petpetFlag) {
		long ownerId = human.getCharId();
		PvpPlayerInfo info = bp.getPlayerInfo(ownerId);
		boolean isAttacker = info.isAttacker();
		FightUnit leader = null;
		FightUnit petpet = null;
		if (isAttacker) {
			leader = bp.getAttackerFULive(true, ownerId);
			petpet = bp.getAttackerFULive(false, ownerId);
		} else {
			leader = bp.getDefenderFULive(true, ownerId);
			petpet = bp.getDefenderFULive(false, ownerId);
		}
		List<Long> ret = new ArrayList<Long>();
		long leaderId = 0;
		long petpetId = 0;
		if (leader != null) {
			leaderId = leader.getPetUUId();
			ret.add(leaderId);
		}
		if (petpetFlag && petpet != null) {
			petpetId = petpet.getPetUUId();
			ret.add(petpetId);
		}
		return ret;
	}
	
	protected void onCanFight(T bp, boolean isPlayerTrigger) {
		setFightUnitAutoSkill(bp);
		addCanFightSet(bp.getBattleId());
		
		if (Loggers.battleLogger.isDebugEnabled()) {
			Loggers.battleLogger.debug("can fight isPlayerTrigger=" + isPlayerTrigger + ";bp=" + bp);
		}
	}
	
	protected abstract void setFightUnitAutoSkill(T bp);
	
	/**
	 * 每轮战斗处理，心跳调用
	 * @param bp
	 */
	protected void battleRound(T bp) {
		boolean isEnd = bp.isBattleEnd(); 
		if (isEnd) {
			Loggers.battleLogger.error("#PlayerBattleLogic#battleRound#battle is end!" + bp);
			return;
		}
		
		if(Loggers.battleLogger.isDebugEnabled()){
			Loggers.battleLogger.debug("battleRound bp=" + bp);
		}
		
		//进行一轮战斗
		String roundReport = bp.round();
		if (roundReport == null) {
			Loggers.battleLogger.error("battle round error!attackerId=" + bp.getAttackerId() + 
					";battleId=" + bp.getBattleId() + ";startTime=" + bp.getStartTime());
		}
		
		//进行完一轮战斗后，设置为未收到下一轮的技能选择数据
		setLastSetFlag(bp);
		
		//战斗结束，等待大家读完战报或到了战斗结束时间，然后再做战斗结束的处理
		if (bp.isBattleEnd()) {
//			onBattleEnd(bp);
		}
		
		//给双方发战报
		sendRoundReport(bp, roundReport);
	}
	
	protected abstract void setLastSetFlag(T bp);
	
	protected void onBattleEnd(T bp) {
		removeBattle(bp.getBattleId());
	}
	
	protected abstract void sendRoundReport(T bp, String roundReport);
	
	@Override
	public void heartBeat() {
		//每次心跳触发n场战斗
		try {
			if (canFightSet.isEmpty()) {
				return;
			}
			
			Iterator<Integer> it = canFightSet.iterator();
			for (int i = 0; i < BATCH_FIGHT_NUM; i++) {
				if (it.hasNext()) {
					Integer battleId = it.next();
					if (battleId != null) {
						T bp = getBattle(battleId);
						if (bp != null) {
							battleRound(bp);
						} else {
							Loggers.battleLogger.error("#PlayerBattleLogic#heartBeat#can fight bp is null!battleId=" + battleId);
						}
						it.remove();
					} else {
						break;
					}
				} else {
					break;
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.battleLogger.error("#PlayerBattleLogic#heartBeat#Exception!", e);
		}
	}
	
	/**
	 * 定时检测是否有超时的战斗，如果有则处理掉
	 */
	public void checkBattleOvertime() {
		long now = Globals.getTimeService().now();
		
		Set<T> needEndSet = new HashSet<T>();
		for (T bp : battleMap.values()) {
			long performEndTime = bp.getLastRoundEndTime();
			
			if (bp.isBattleEnd()) {
				//需要结束的战斗
				if (now >= performEndTime) {
					needEndSet.add(bp);
				}
				continue;
			}
			
			//检查是否有人超时
			onCheckPlayerOvertime(bp, performEndTime);
			
			if (!isInCanFightSet(bp.getBattleId()) && bp.isAllSet()) {
				onCanFight(bp, false);
			}
		}
		
		//将到时间的战斗，结束
		if (!needEndSet.isEmpty()) {
			for (T bp : needEndSet) {
				onBattleEnd(bp);
			}
		}
	}
	
	protected abstract void onCheckPlayerOvertime(T bp, long performEndTime);
	
	protected void checkPlayerOvertime(PvpPlayerInfo info, long performEndTime) {
		if (!info.isLastSetFlag()) {
			int opTime = info.isAuto() ? BattleDef.CHOOSE_SKILL_AUTO_TIME : BattleDef.CHOOSE_SKILL_MAX_TIME;
			if (Globals.getTimeService().now() > performEndTime + opTime + BattleDef.DELAY_TIME) {
				info.setAuto(true);
				info.setLastSetFlag(true);
				
				if (Loggers.battleLogger.isDebugEnabled()) {
					Loggers.battleLogger.debug("player " + info.getHumanId() + " is overtime,will set auto true.");
				}
			}
		}
	}
	
	/**
	 * 玩家登录时的处理
	 * @param human
	 */
	public abstract void onPlayerLogin(Human human);
	
	/**
	 * 玩家读完最后一轮战报的请求
	 * @param human
	 * @return
	 */
	public boolean readLastRoundReportEnd(Human human) {
		long roleId = human.getUUID();
		int battleId = getPlayerBattleId(roleId);
		if (battleId <= 0) {
			return false;
		}
		
		T bp = getBattle(battleId);
		if (bp == null) {
			return false;
		}
		//战斗未结束，不做处理
		if (!bp.isBattleEnd()) {
			return false;
		}
		
		PvpPlayerInfo info = bp.getPlayerInfo(roleId);
		if (info == null) {
			return false;
		}
		//如果之前没有读完，则设置为读完了
		if (!info.isReadLast()) {
			info.setReadLast(true);
			
			//大家都读完战报了，则进行战斗结束的处理
			if (bp.isAllReadLast()) {
				onBattleEnd(bp);
			}
			return true;
		}
		return false;
	}
	
	public abstract void forceEndBattle(T bp, String source);
	
	public Set<Integer> getAllBattleIdSet() {
		return battleMap.keySet();
	}
	
	public void onShutDownServer() {
		//TODO 正常关闭服务器时，结束玩家正在进行的战斗
		//TODO 可能需要服务器自己跑自动战斗
		
	}

}
