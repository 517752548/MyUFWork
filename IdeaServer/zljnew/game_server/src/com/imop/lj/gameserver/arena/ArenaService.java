package com.imop.lj.gameserver.arena;

import java.text.MessageFormat;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

import org.apache.commons.lang.ArrayUtils;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.ArenaLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.model.arena.ArenaReportHistoryInfo;
import com.imop.lj.common.model.template.TimeEventTemplate;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.db.model.ArenaSnapEntity;
import com.imop.lj.gameserver.arena.async.ArenaBattleOperation;
import com.imop.lj.gameserver.arena.model.ArenaMember;
import com.imop.lj.gameserver.arena.model.ArenaOpponent;
import com.imop.lj.gameserver.arena.msg.ArenaMsgBuilder;
import com.imop.lj.gameserver.arena.msg.GCArenaKillCd;
import com.imop.lj.gameserver.arena.msg.GCArenaRankRewardList;
import com.imop.lj.gameserver.arena.msg.GCArenaTopRankList;
import com.imop.lj.gameserver.arena.template.ArenaBattleRewardTemplate;
import com.imop.lj.gameserver.arena.template.ArenaBuyTimesTemplate;
import com.imop.lj.gameserver.arena.template.ArenaConWinNoticeTemplate;
import com.imop.lj.gameserver.arena.template.ArenaRankChallengeTemplate;
import com.imop.lj.gameserver.arena.template.ArenaRankRewardTemplate;
import com.imop.lj.gameserver.arena.template.ArenaRobotTemplate;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleResult;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.cd.CdTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.TipsUtil;
import com.imop.lj.gameserver.common.event.ArenaRefreshEvent;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.task.TaskDef;
import com.imop.lj.gameserver.timeevent.template.RefreshArenaTemplate;

/**
 * 竞技场服务
 * @author yu.zhao
 *
 */
public class ArenaService implements InitializeRequired {
	/** 竞技场对手列表排序器 */
	protected static ArenaOpponentComparator opponentSortor;
	
	/** 竞技场成员Map<玩家Id，竞技场成员对象> */
	protected Map<Long, ArenaMember> arenaMemberMap = new HashMap<Long, ArenaMember>();
	/** 竞技场排名成员Map<排名，竞技场成员对象> */
	protected Map<Integer, ArenaMember> arenaRankMember = new HashMap<Integer, ArenaMember>();
	
	/** 正在进行战斗的竞技场玩家Id集合 */
	protected Set<Long> inBattleSet = new HashSet<Long>();
	
	public ArenaService() {
		opponentSortor = new ArenaOpponentComparator();
	}

	@Override
	public void init() {
		Globals.getTemplateCacheService().getArenaTemplateCache().initShowRankRewardList();
		//加载所有的竞技场成员对象
		initAllMember();
	}
	
	/**
	 * 加载所有的竞技场成员对象
	 */
	protected void initAllMember() {
		List<ArenaSnapEntity> arenaMemberEntities = Globals.getDaoService().getArenaMemberDao().loadAllArenaSnap();
		if (arenaMemberEntities == null || arenaMemberEntities.size() == 0) {
			return;
		}

		for (ArenaSnapEntity arenaMemberEntity : arenaMemberEntities) {
			ArenaMember arenaMember = new ArenaMember();
			arenaMember.fromEntity(arenaMemberEntity);
			// 初始化内存对象
			this.addMember(arenaMember);
		}
	}
	
	/**
	 * 往map中增加成员
	 * @param member
	 */
	protected void addMember(ArenaMember member) {
		if (null == member || member.getRank() <= 0) {
			return;
		}
		arenaMemberMap.put(member.getId(), member);
		onMemberRankChanged(member);
	}
	
	/**
	 * 成员的排名变化时，更新排名map
	 * @param member
	 */
	protected void onMemberRankChanged(ArenaMember member) {
		if (null == member || member.getRank() <= 0) {
			// 非法数据
			Loggers.arenaLogger.error("#ArenaService#onMemberRankChanged#member is null or member.getRank()<=0;member=" + 
					(member == null ? "null" : member + ";mid=" + member.getCharId() + ";mrank=" + member.getRank()));
			return;
		}
		arenaRankMember.put(member.getRank(), member);
	}
	
	protected void removeMemberRank(int rank) {
		arenaRankMember.remove(rank);
	}
	
	/**
	 * 得到竞技场的总人数
	 *
	 * @return
	 */
	protected int getArenaMemberMax() {
		return arenaMemberMap.size();
	}
	
	/**
	 * 根据角色id得到玩家竞技场成员对象
	 *
	 * @param playerId
	 */
	public ArenaMember getArenaMember(long roleId) {
		return this.arenaMemberMap.get(roleId);
	}
	
	/**
	 * 获取玩家的竞技场排名
	 * @param roleId
	 * @return
	 */
	public int getArenaRank(long roleId) {
		int rank = 0;
		ArenaMember am = getArenaMember(roleId);
		if (am != null) {
			rank = am.getRank();
		}
		return rank;
	}
	
	/**
	 * 根据排名获取玩家竞技场成员对象
	 * @param rank
	 * @return
	 */
	public ArenaMember getArenaMemberByRank(int rank) {
		return this.arenaRankMember.get(rank);
	}
	
	public boolean isInBattle(long roleId) {
		return this.inBattleSet.contains(roleId);
	}
	
	protected void addInBattle(long roleId) {
		this.inBattleSet.add(roleId);
	}
	
	protected void removeInBattle(long roleId) {
		this.inBattleSet.remove(roleId);
	}
	
	/**
	 * 刷新竞技场，只在定时任务调用
	 */
	public void refreshArena(String source) {
		// 刷新竞技场，记录排名快照，生成奖励
		Loggers.arenaLogger.info("#ArenaService#refreshArena#begin to gen arena reward.source=" + source);
		
		Map<Integer, Long> memList = new HashMap<Integer, Long>();
		long now = Globals.getTimeService().now();
		// 给奖励的排名上限
		int rewardRankMax = Globals.getGameConstants().getArenaRankRewardMax();
		// 从第一名开始给奖励
		for (int rank = 1; rank <= rewardRankMax; rank++) {
			ArenaMember member = getArenaMemberByRank(rank);
			if (null == member) {
				continue;
			}
			if (rank != member.getRank()) {
				// 玩家的排名和排名map中的数据不匹配，不应该出现这种情况，记录错误日志
				Loggers.arenaLogger.error("#ArenaService#refreshArena#ERROR!rank conflict!rank=" + rank + ";memberRank=" + member.getRank() + ";member=" + member);
				continue;
			}
			
			UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(member.getId());
			if (null == userSnap) {
				// 记录错误日志
				Loggers.arenaLogger.error("#ArenaService#refreshArena#userSnap is null!uuid=" + member.getId());
				return;
			}
			// 设置玩家获得奖励时的快照数据
			member.setSnapRank(rank);
			// level从离线玩家数据中获得
			int snapLevel = userSnap.getLevel();
			member.setSnapLevel(snapLevel);
			
			// 存库
			member.setModified();
			
			// 奖励处理
			ArenaRankRewardTemplate tpl = Globals.getTemplateCacheService().getArenaTemplateCache().getRankRewardTpl(rank);
			// 如果获取不到玩家所在的区间，则说明此排名没有奖励
			if (null != tpl) {
				int rewardId = tpl.getRewardId();
				Reward reward = Globals.getRewardService().createReward(member.getId(), rewardId, "arenaRank=" + rank);
				// 将奖励给玩家发邮件
				String title = Globals.getLangService().readSysLang(LangConstants.ARENA_RANK_REWARD_MAIL_TITLE);
				String content = Globals.getLangService().readSysLang(LangConstants.ARENA_RANK_REWARD_MAIL_CONTENT);
				Globals.getMailService().sendSysMail(userSnap.getCharId(), MailType.SYSTEM, title, content, reward);
				
				// 记录日志
				Loggers.arenaLogger.info("#ArenaService#refreshArena#ArenaMember get reward.rank=" + 
						rank + ";memberId=" + member.getId() + ";rewardId=" + rewardId);
			} else {
				// 记录日志
				Loggers.arenaLogger.warn("#ArenaService#refreshArena#rank has no tpl!rank=" + 
						rank + ";memberId=" + member.getId());
			}
			
			memList.put(rank, member.getCharId());
		}
		
		// 竞技场刷新事件监听
		Globals.getEventService().fireEvent(new ArenaRefreshEvent(null, memList));
		
		// 记录日志，刷新完成
		Loggers.arenaLogger.info("#ArenaService#refreshArena#Arena refresh end.time=" + TimeUtils.formatYMDHMSTime(now) + ";source=" + source);
	}
	
	/**
	 * 注册竞技场，玩家首次进入竞技场时调用此方法
	 *
	 * @param uuid
	 * @return
	 */
	protected ArenaMember registerArena(long uuid) {
		// 获得名次最大值
		int memberMax = this.getArenaMemberMax();
		// 名次=当前人数+偏移量
		int rank = memberMax + 1 + Globals.getGameConstants().getArenaRankOffset();

		// 构建新的竞技场成员对象
		ArenaMember newArenaMember = new ArenaMember();
		newArenaMember.setInDb(false);
		newArenaMember.setId(uuid);
		newArenaMember.setRank(rank);

		//生成对手列表
		resetOpList(newArenaMember);
		
		// 激活并存库
		newArenaMember.active();
		newArenaMember.setModified();

		// 加入新成员
		this.addMember(newArenaMember);
		
		return newArenaMember;
	}
	
	/**
	 * 检查对手是否合法
	 *
	 * @param selfMember
	 * @param targetOp
	 * @return
	 */
	protected boolean checkOpponent(ArenaMember selfMember, ArenaOpponent targetOp) {
		int targetRank = targetOp.getRank();
		ArenaMember targetMember = getArenaMemberByRank(targetRank);
		if (!targetOp.isRobot()) {
			//目标玩家排名没变，则合法
			if (targetMember != null && 
					targetMember.getCharId() == targetOp.getRoleId()) {
				return true;
			}
		} else {
			//对应排名是否还是机器人
			if (targetMember == null) {
				return true;
			}
		}
		return false;
	}
	
	protected List<ArenaOpponent> randChallengeMemberList(ArenaMember selfMember) {
		int selfRank = selfMember.getRank();
		ArenaRankChallengeTemplate tpl = Globals.getTemplateCacheService().getArenaTemplateCache().getRankChallengeTpl(selfRank);
		if (tpl == null) {
			Loggers.arenaLogger.error("member rank no tpl!selfRank=" + selfRank + ";roleId=" + selfMember.getCharId());
			return null;
		}
		
		List<ArenaOpponent> opList = new ArrayList<ArenaOpponent>();
		
		int targetMin = 0;
		int targetMax = 0;
		//排名小于临界值，直接取模板的数据
		if (selfRank <= Globals.getTemplateCacheService().getArenaTemplateCache().getChallengeRankCritical()) {
			targetMin = tpl.getPMin();
			targetMax = tpl.getPMax();
		} else {
			//排名大于临界值，取自身排名减去模板值
			targetMin = selfRank - tpl.getPMax();
			targetMax = selfRank - tpl.getPMin();
		}
		
		List<Integer> rankList = new ArrayList<Integer>();
		for (int i = targetMin; i <= targetMax; i++) {
			if (i != selfRank) {
				rankList.add(i);
			}
		}
		
		int count = Math.min(ArenaDef.ARENA_MAX_CHALLENGER_SIZE, rankList.size());
		for (int i = 0; i < count; i++) {
			List<Integer> randRankRet = RandomUtils.hitObjects(rankList, 1);
			if (randRankRet == null || randRankRet.isEmpty()) {
				Loggers.arenaLogger.error("hitObjects return null or empty!");
				return null;
			}
			
			Integer randRank = randRankRet.get(0);
			rankList.remove(randRank);
			
			ArenaOpponent ao = null;
			//如果该排名有人，则取玩家数据，如果没人，则使用机器人数据
			ArenaMember targetMember = getArenaMemberByRank(randRank);
			if (targetMember != null) {
				//真人
				ao = new ArenaOpponent(targetMember.getCharId(), randRank);
			} else {
				//机器人
				int roleLevel = Globals.getOfflineDataService().getUserLevel(selfMember.getCharId());
				ao = new ArenaOpponent(rankRobotTplId(), randRank, roleLevel);
			}
			ao.setOwnerId(selfMember.getCharId());
			opList.add(ao);
		}
		
		//排序
		Collections.sort(opList, opponentSortor);
		
		return opList;
	}
	
	public int randRobotFightPower(int robotLevel) {
		ArenaRobotTemplate tpl = Globals.getTemplateCacheService().get(robotLevel, ArenaRobotTemplate.class);
		if (tpl != null) {
			return MathUtils.random(tpl.getFightPower() - tpl.getDelta(), tpl.getFightPower() + tpl.getDelta());
		}
		return 0;
	}
	
	/**
	 * 随机机器人模板Id
	 * @return
	 */
	protected int rankRobotTplId() {
		List<Integer> lst = Globals.getTemplateCacheService().getPetTemplateCache().getCreateRoleTplIdList();
		int rankKey = MathUtils.random(0, lst.size() - 1);
		return lst.get(rankKey);
	}
	
	/**
	 * 获取显示需要的当前是否可攻击的状态
	 * @param human
	 * @return
	 */
	public boolean getCanChallengeShow(Human human) {
		// 战斗cd未到
		if (!human.getCdManager().canAddTime(CdTypeEnum.battleCd)) {
			return false;
		}
		// 竞技场战斗cd未到
		if (!human.getCdManager().canAddTime(CdTypeEnum.ArenaBattle)) {
			return false;
		}
		// 行为次数不足
		if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.ARENA_CHALLENGE_NUM)) {
			return false;
		}
		return true;
	}
	
	/**
	 * 玩家请求刷新对手列表
	 * @param human
	 */
	public void refreshOpponent(Human human) {
		//获取攻击方玩家的竞技场成员对象
		ArenaMember member = getArenaMember(human.getUUID());
		if (member == null) {
			return;
		}
		
		//刷新对手列表
		resetOpList(member);
		//前台刷面板
		showArenaPanel(human);
	}
	
	/**
	 * 攻击另一个玩家
	 *
	 * @param human
	 * @param targetHumanUUId
	 *
	 */
	public void attack(Human self, int targetNum) {
		long selfId = self.getCharId();
		//玩家是否正在战斗中
		if (self.isInAnyBattle()) {
			return;
		}
		
		//玩家挂机中
		if(self.isInGuaJi()){
			return;
		}
		
		//玩家采集中
		if(self.isInGather()){
			self.sendErrorMessage(LangConstants.USE_LIFE_SKILL_DOING);
			return;
		}
		
		//获取攻击方玩家的竞技场成员对象
		ArenaMember selfMember = getArenaMember(self.getUUID());
		if (selfMember == null) {
			return;
		}
		if (targetNum > selfMember.getOpList().size()) {
			return;
		}
		ArenaOpponent targetOp = selfMember.getOpList().get(targetNum - 1);
		if (null == targetOp) {
			return;
		}
		
		//目标是否可攻击
		boolean targetFlag = checkOpponent(selfMember, targetOp);
		if (!targetFlag) {
			//刷新对手列表
			refreshOpponent(self);
			return;
		}
		
		//目标玩家是否正在战斗中
		if (!targetOp.isRobot() &&
				isInBattle(targetOp.getRoleId())) {
			self.sendErrorMessage(LangConstants.ARENA_ATTACK_FAIL_INBATTLE);
			return;
		}
		
		// 行为次数不足
		if (!self.getBehaviorManager().canDo(BehaviorTypeEnum.ARENA_CHALLENGE_NUM)) {
			self.sendErrorMessage(LangConstants.ARENA_CHALLENGE_TIME_IS_EMPTY);
			return;
		}
		
		// 竞技场战斗cd未到
		if (Globals.getTimeService().now() < selfMember.getAttackCdTime()) {
			self.sendErrorMessage(LangConstants.ARENA_BATTLE_HAVE_CD_TIME);
			return;
		}
		
		//行为次数记录
		self.getBehaviorManager().doBehavior(BehaviorTypeEnum.ARENA_CHALLENGE_NUM);
		
		//在线打离线，or打机器人

		//设置为进入竞技场战斗状态
		addInBattle(selfId);
		
		// 获取攻击方战斗对象
		Fighter<?> attacker = new Fighter<Human>(FighterType.FORMATION, self, true);
		Fighter<?> defender = null;
		if (!targetOp.isRobot()) {
			// 获取防守方玩家的离线战斗对象
			defender = new Fighter<Long>(FighterType.OFFLINE, targetOp.getRoleId(), false);
			//设置为进入竞技场战斗状态
			addInBattle(targetOp.getRoleId());
		} else {
			defender = new Fighter<ArenaOpponent>(FighterType.ARENA_ROBOT, targetOp, false);
		}
		
		//构造竞技场战斗，创建异步战斗operation
		ArenaBattleOperation battleOperation = new ArenaBattleOperation(selfId, targetOp, BattleType.ARENA, 
				attacker, defender);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(battleOperation);
	}
	
	/**
	 * 战斗结果处理
	 * @param human
	 * @param targetHumanId
	 * @param battleReport
	 */
	public void onBattleEnd(long humanId, ArenaOpponent targetOp, BattleProcess bp) {
		//攻击方退出战斗
		removeInBattle(humanId);
		long targetId = targetOp.getRoleId();
		ArenaMember targetMember = getArenaMember(targetId);
		if (targetMember != null) {
			//防守方退出战斗
			removeInBattle(targetId);
		}
		
		//数据校验
		if (bp == null) {
			//记录错误日志
			Loggers.arenaLogger.error("#ArenaService#processBattleResult#bp is null!humanId=" + 
					humanId + ";targetId=" + targetId);
			return;
		}
		//玩家竞技场数据
		ArenaMember selfMember = getArenaMember(humanId);
		if (selfMember == null) {
			//记录错误日志
			Loggers.arenaLogger.error("#ArenaService#processBattleResult#selfMember is null!humanId=" + 
					humanId + ";targetId=" + targetId);
			return;
		}
		
		//攻击方血、蓝、宠物寿命更新
		Globals.getBattleService().onBattleEndPropUpdate(humanId, 
				bp.getBattleFU(true, true, humanId), bp.getBattleFU(true, false, humanId));
		
		//获取玩家
		Human human = Globals.getOnlinePlayerService().getPlayer(humanId).getHuman();
		//更改骑宠属性
		Globals.getBattleService().onBattleEndPetHorsePropUpdate(human, bp.getBattleResult() == BattleResult.ATTACKER);
		
		//保存战报
		long reportId = Globals.getBattleService().saveReport(bp);
		
		int selfRankOld = selfMember.getRank();
		int targetRankOld = targetOp.getRank();
		int selfConWinTimesOld = selfMember.getConWinTimes();
		int targetConWinTimesOld = targetMember != null ? targetMember.getConWinTimes() : 0;
		// 攻击方是否胜利
		boolean isAttackerWin = bp.getBattleResult() == BattleResult.ATTACKER;
		
		// 更新连胜等数据
		updateMemberData(selfMember, true, isAttackerWin);
		//目标玩家数据更新
		if (targetMember != null) {
			updateMemberData(targetMember, false, !isAttackerWin);
		}
		
		//攻击方胜利，且排名上升，才更新排名
		boolean needUpdateRank = isAttackerWin && selfRankOld > targetRankOld;
		
		//更新排名
		if (needUpdateRank) {
			//自己排名更新
			selfMember.setRank(targetRankOld);
			onMemberRankChanged(selfMember);
			if (targetMember != null) {
				//目标玩家排名更新
				targetMember.setRank(selfRankOld);
				onMemberRankChanged(targetMember);
			} else {
				//机器人，则将原排名的自己移除掉
				removeMemberRank(selfRankOld);
			}
		}
		
		//刷新对手列表
		if (needUpdateRank) {
			//战斗胜利，重新刷新对手列表
			resetOpList(selfMember);
			//对手的列表重新刷新
			if (targetMember != null) {
				resetOpList(targetMember);
			}
		}
		
		//战斗失败，增加cd时间
		if (!isAttackerWin) {
			selfMember.setAttackCdTime(Globals.getTimeService().now() + Globals.getGameConstants().getArenaBattleCd());
		}
		
		//记录成员的日志和防守方的公告
		memberLogAndNotice(selfMember, targetOp, selfRankOld, targetRankOld, isAttackerWin, reportId);
		
		//存库
		selfMember.setModified();
		if (targetMember != null) {
			targetMember.setModified();
		}
		
		// 竞技场全服公告
		if (isAttackerWin) {
			arenaNotice(selfMember, targetOp, selfRankOld, targetRankOld, targetConWinTimesOld, reportId);
		}
		
		//玩家是否还在线 
		if (Globals.getTeamService().isPlayerOnline(humanId)) {
			//给玩家发战报，需要先发战报，否则后边给奖励的冒泡就先冒了
			Globals.getBattleReportService().sendBattleReportMsg(human, bp.getFinalReport(), reportId, false, false, bp.getBattleType().getToBackType(), "");
			
//			//通知玩家胜负结果
//			if (isAttackerWin) {
//				human.sendErrorMessage(LangConstants.ARENA_BATTLE_END_NOTICE_WIN);
//			} else {
//				human.sendErrorMessage(LangConstants.ARENA_BATTLE_END_NOTICE_LOSS);
//			}
			
			//给玩家奖励
			Reward reward = createAttackReward(human, isAttackerWin);
			boolean rewardFlag = Globals.getRewardService().giveReward(human, reward, false);
			if (!rewardFlag) {
				Loggers.arenaLogger.error("#ArenaService#processBattleResult#giveRewad failed!humanId=" + 
						humanId + ";targetId=" + targetId + ";selfRankOld=" + selfRankOld + 
						";targetRankOld=" + targetRankOld + ";isAttackerWin=" + isAttackerWin);
			}
			
			//任务监听
			human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.ARENA_ATTACK, 0, 1);
		} else {
			// 记录错误日志
			Loggers.arenaLogger.warn("#ArenaService#processBattleResult#player or human is null!humanId=" + 
					humanId + ";targetId=" + targetId);
		}
		
		//记录日志
		Globals.getLogService().sendArenaLog(human, ArenaLogReason.RANK_CHANGE, reportId + "", bp.getBattleResult().toString(), selfMember.getId(), selfConWinTimesOld,
				selfMember.getConWinTimes(), selfRankOld, selfMember.getRank(), targetOp.getRoleId(), targetOp.getTplId(), targetConWinTimesOld,
				targetRankOld, targetOp.getRank());
	}
	
	/**
	 * 重置竞技场玩家的对手列表
	 * @param member
	 */
	protected void resetOpList(ArenaMember member) {
		if (member == null) {
			return;
		}
		//战斗胜利，重新刷新对手列表
		List<ArenaOpponent> opList = this.randChallengeMemberList(member);
		if (opList != null) {
			member.setOpList(opList);
			member.setModified();
		}
	}
	
	/**
	 * 获取竞技场剩余挑战次数，功能按钮角标显示用
	 * @param human
	 * @return
	 */
	public int getCanChallengeNum(Human human) {
		int num = 0;
		if (human != null && human.getBehaviorManager() != null) {
			num = human.getBehaviorManager().getLeftCount(BehaviorTypeEnum.ARENA_CHALLENGE_NUM);
		}
		return num;
	}
	
	/**
	 * 生成攻击奖励
	 * @param human
	 * @param isAttackerWin
	 * @return
	 */
	protected Reward createAttackReward(Human human, boolean isAttackerWin) {
		ArenaBattleRewardTemplate tpl = Globals.getTemplateCacheService().getArenaTemplateCache().getBattleRewardTpl(human.getLevel());
		if (tpl == null) {
			Loggers.arenaLogger.error("ArenaBattleRewardTemplate is null!humanId=" + human.getCharId());
			return null;
		}
		
		int rewardId = isAttackerWin ? tpl.getWinRewardId() : tpl.getLossRewardId();
		String logContent = "arenaAttack;" + "isAttackerWin=" + isAttackerWin;
		Reward reward = Globals.getRewardService().createReward(human.getUUID(), rewardId, logContent);
		return reward;
	}
	
	protected void updateMemberData(ArenaMember member, boolean isAttacker, boolean isWin) {
		// 攻击总次数+1
		if (isAttacker) {
			member.setAttackTotalTimes(member.getAttackTotalTimes() + 1);
		}
		//胜利
		if (isWin) {
			// 自己数据更新，连胜+1，累计胜利次数+1
			member.setConWinTimes(member.getConWinTimes() + 1);
			member.setWinTimes(member.getWinTimes() + 1);
		} else {
			//失败，连胜清零，失败次数+1
			member.setConWinTimes(0);
			member.setLossTimes(member.getLossTimes() + 1);
		}
	}
	
	/**
	 * 处理成员的日志和防守方的公告
	 * 
	 * @param selfMember
	 * @param targetOp
	 * @param selfRankOld
	 * @param targetRankOld
	 * @param isAttackerWin
	 * @param reportId
	 */
	protected void memberLogAndNotice(ArenaMember selfMember, ArenaOpponent targetOp, int selfRankOld, int targetRankOld,
			boolean isAttackerWin, long reportId) {
		ArenaMember targetMember = !targetOp.isRobot() ? getArenaMember(targetOp.getRoleId()) : null;
		// 战斗日志处理
		String reportIdStr = reportId + "";
		int selfRankNew = selfMember.getRank();
		int targetRankNew = targetOp.getRank();
		
		int aRankDelta = Math.abs(selfRankOld-selfRankNew);
		long targetRoleId = targetOp.getRoleId();
		int targetTplId = 0;
		int targetLevel = 0;
		String targetName = "";
		if (!targetOp.isRobot()) {
			targetTplId = Globals.getOfflineDataService().getUserTplId(targetRoleId);
			targetLevel = Globals.getOfflineDataService().getUserLevel(targetRoleId);
			targetName = Globals.getOfflineDataService().getUserName(targetRoleId);
		} else {
			targetTplId = targetOp.getTplId();
			targetLevel = Globals.getOfflineDataService().getUserLevel(selfMember.getCharId());
			targetName = targetOp.getName();
		}
		// 攻击方战报
		ArenaReportHistoryInfo aInfo = buildArenaReportHistoryInfo(reportIdStr, isAttackerWin, aRankDelta, 
				targetRoleId, targetTplId, targetLevel, targetName);
		// 攻击者增加战斗日志
		selfMember.addFightLog(aInfo);
		
		// 防守方战报公告处理
		if (targetMember != null) {
			int dRankDelta = Math.abs(targetRankOld-targetRankNew);
			long dTargetRoleId = selfMember.getCharId();
			int dTargetTplId = Globals.getOfflineDataService().getUserTplId(selfMember.getCharId());
			int dTargetLevel = Globals.getOfflineDataService().getUserLevel(selfMember.getCharId());
			String dTargetName = Globals.getOfflineDataService().getUserName(selfMember.getCharId());
			// 防守方战报
			ArenaReportHistoryInfo dInfo = buildArenaReportHistoryInfo(reportIdStr, !isAttackerWin, dRankDelta, 
					dTargetRoleId, dTargetTplId, dTargetLevel, dTargetName);
			// 防守方增加战斗日志
			targetMember.addFightLog(dInfo);
		}
	}
	
	/**
	 * 竞技场全服公告
	 * 
	 * @param selfMember
	 * @param targetMember
	 * @param selfRankOld
	 * @param targetRankOld
	 * @param targetConWinTimesOld
	 * @param reportId
	 */
	protected void arenaNotice(ArenaMember selfMember, ArenaOpponent targetOp, int selfRankOld, int targetRankOld, 
			int targetConWinTimesOld, long reportId) {
		int selfRankNew = selfMember.getRank();
		// 获取带颜色的玩家名字
		String attackerName = TipsUtil.getRoleLinkStr(selfMember.getId());
		String defenderName = targetOp.getNameWithColor();
		
		// 公告处理
		// 连胜公告，如果玩家的连胜达到指定场数，则发送公告
		ArenaConWinNoticeTemplate conWinNoticeTpl = Globals.getTemplateCacheService().getArenaTemplateCache().getConWinNoticeTplByConWinTimes(selfMember.getConWinTimes());
		if (null != conWinNoticeTpl) {
			// 连胜公告
			Globals.getBroadcastService().broadcastWorldMessage(conWinNoticeTpl.getNoticeId(), attackerName);
		}
		
		// 终结连胜公告
		if (targetConWinTimesOld >= Globals.getGameConstants().getArenaNoticeEndConWinNum()) {
			Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getArenaEndConWinNoticeId(), 
					attackerName, defenderName, targetConWinTimesOld);
		}
		
		// 榜首变更全局公告
		if (selfRankNew == 1 && selfRankNew != selfRankOld) {
			Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getArenaWinFirstNoticeId(),
					attackerName, defenderName);
		}
	}
	
	/**
	 * 构建竞技场挑战日志
	 * @param reportId
	 * @param reportDesc
	 * @return
	 */
	protected ArenaReportHistoryInfo buildArenaReportHistoryInfo(String reportId, boolean isWin, int rankDelta,
			long targetRoleId, int targetTplId, int targetLevel, String targetName) {
		ArenaReportHistoryInfo info = new ArenaReportHistoryInfo();
		info.setReportId(reportId);
		info.setReportTime(Globals.getTimeService().now());
		info.setIsWin(isWin ? 1 : 0);
		info.setRankDelta(rankDelta);
		info.setTargetRoleId(targetRoleId);
		info.setTargetTplId(targetTplId);
		info.setTargetLevel(targetLevel);
		info.setTargetName(targetName);
		return info;
	}
	
	public int getMemberLevel(ArenaMember member) {
		int level = 0;
		UserSnap userSnap = Globals.getOfflineDataService().getUserSnap(member.getId());
		if (null != userSnap) {
			level = userSnap.getLevel();
		}
		return level;
	}
	
	/**
	 * 获取下次领奖时间的倒计时
	 * @return
	 */
	public long getNextRewardTimeCountDown() {
		long countDown = 0;
		long now = Globals.getTimeService().now();
		// 如果今天的时间都已经过了，那么明天的一定会命中，否则就非法
		loop : for (int i = 0; i < 2; i++) {
			RefreshArenaTemplate refreshArenaTemplate = Globals.getTemplateCacheService().get(SharedConstants.CONFIG_TEMPLATE_DEFAULT_ID, RefreshArenaTemplate.class);
			for (int timeEventId : refreshArenaTemplate.getTimeEventIds()) {
				TimeEventTemplate timeEventTpl = Globals.getTemplateCacheService().get(timeEventId, TimeEventTemplate.class);
				long timePoint = TimeUtils.DAY * i;
				try {
					timePoint += TimeUtils.getBeginOfDay(now) + TimeUtils.getHMTime(timeEventTpl.getTriggerTime());
				} catch (ParseException e) {
					Loggers.arenaLogger.error(e.getMessage());
					e.printStackTrace();
				}
				if (timePoint > now) {
					countDown = timePoint - now;
					break loop;
				}
			}
		}
		return countDown;
	}
	
	/**
	 * 获取英雄榜玩家列表
	 * @return
	 */
	public List<ArenaMember> getTopRankMemberList() {
		List<ArenaMember> memberList = new ArrayList<ArenaMember>();
		for (int rank = 1; rank <= ArenaDef.ARENA_TOP_RANK_NUM; rank++) {
			ArenaMember topMember = getArenaMemberByRank(rank);
			if (null != topMember) {
				memberList.add(topMember);
			}
		}
		return memberList;
	}
	
	/**
	 * 显示竞技场面板
	 * @param human
	 */
	public void showArenaPanel(Human human) {
		long uuid = human.getUUID();
		ArenaMember member = getArenaMember(uuid);
		// 如果玩家第一次进入竞技场，则创建玩家的竞技场成员对象
		if (member == null) {
			// 注册玩家
			member = registerArena(uuid);
		} 
		
		// 发送显示面板信息 
		human.sendMessage(ArenaMsgBuilder.buildGCShowArenaPanelMain(human, member));
	}
	
	/**
	 * 获取竞技场排名前100的玩家信息列表
	 * @param human
	 */
	public void showTopRankList(Human human) {
		// 发送top100玩家信息
		GCArenaTopRankList gcArenaTopRankList = ArenaMsgBuilder.buildGCArenaTopRankList(human);
		human.sendMessage(gcArenaTopRankList);
	}
	
	public boolean canChallengeForShow(Human human) {
		// 行为次数不足
		if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.ARENA_CHALLENGE_NUM)) {
			return false;
		}
		
		ArenaMember member = getArenaMember(human.getCharId());
		// 竞技场战斗cd未到
		if (Globals.getTimeService().now() < member.getAttackCdTime()) {
			return false;
		}
		
		return true;
	}
	
	public long getChallengeCdTimeForShow(Human human) {
		ArenaMember member = getArenaMember(human.getCharId());
		if (Globals.getTimeService().now() < member.getAttackCdTime()) {
			return member.getAttackCdTime() - Globals.getTimeService().now();
		}
		return 0;
	}
	
	/**
	 * 计算购买竞技场次数花费的元宝数
	 * @param human
	 * @return
	 */
	public int calBuyChallengeTimeCost(Human human) {
		int count = human.getBehaviorManager().getCount(BehaviorTypeEnum.BUY_ARENA) + 1;
		ArenaBuyTimesTemplate tpl = Globals.getTemplateCacheService().getArenaTemplateCache().getBuyTimesTpl(count);
		return tpl.getCost();
	}
	
	public int getChallengeLeftTimes(Human human) {
		return human.getBehaviorManager().getLeftCount(BehaviorTypeEnum.ARENA_CHALLENGE_NUM);
	}
	
	/**
	 * 购买竞技场次数
	 * @param human
	 */
	public void buyChallengeTimes(Human human) {
		long uuid = human.getUUID();
		ArenaMember member = getArenaMember(uuid);
		if (member == null) {
			return;
		}
		
		// 行为是否可做
		boolean canDoFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.BUY_ARENA);
		if (!canDoFlag) {
			human.sendErrorMessage(LangConstants.ARENA_ERR_BATTLE_TIME_CANNOT_BUY);
			return;
		}
		
		int needBond = calBuyChallengeTimeCost(human);
		// 货币是否足够
		if (!human.hasEnoughMoney(needBond, Currency.BOND, true)) {
			return;
		}
		
		// 扣钱
		String detailReason = MoneyLogReason.ARENA_BUY_TIMES.getReasonText();
		detailReason = MessageFormat.format(detailReason, human.getBehaviorManager().getCount(BehaviorTypeEnum.ARENA_CHALLENGE_NUM), 
				human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.ARENA_CHALLENGE_NUM));
		if (!human.costMoney(needBond, Currency.BOND, true, 0, MoneyLogReason.ARENA_BUY_TIMES, detailReason, 0)) {
			Loggers.arenaLogger.error("#ArenaService#buyChallengeTimesConfirm#ERROR!costMoney return false!");
			return;
		}
		
		// 增加次数
		// 扣除竞技场购买行为
		if (human.getBehaviorManager().doBehavior(BehaviorTypeEnum.BUY_ARENA)) {
			// 增加竞技场次数上限
			human.getBehaviorManager().addOp(BehaviorTypeEnum.ARENA_CHALLENGE_NUM, 
					Globals.getGameConstants().getArenaBuyAddTimes());
		}
		
		// 给玩家发消息，刷新次数
		human.sendMessage(ArenaMsgBuilder.buildGCBuyChallengeTime(human));
		
		// 功能按钮角标变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.ARENA);
	}
	
	/**
	 * 确认消除挑战cd时间
	 * @param human
	 */
	public void killCdTime(Human human) {
		long uuid = human.getUUID();
		ArenaMember member = getArenaMember(uuid);
		if (member == null) {
			return;
		}
		//cd时间已过
		if (Globals.getTimeService().now() >= member.getAttackCdTime()) {
			return;
		}
		
		int cost = getKillCdCost(human);
		// 货币是否足够
		if (!human.hasEnoughMoney(cost, Currency.GOLD, true)) {
			return;
		}
		//扣钱
		boolean flag = human.costMoney(cost, Currency.GOLD, true, 0, 
				MoneyLogReason.ARENA_KILL_CD, MoneyLogReason.ARENA_KILL_CD.getReasonText(), 0);
		if (!flag) {
			return;
		}
		
		//设置冷却时间为0
		member.setAttackCdTime(0);
		member.setModified();
		//发清除cd成功的消息
		human.sendMessage(new GCArenaKillCd());
	}
	
	/**
	 * 获取秒cd消耗的货币数
	 * @param human
	 * @return
	 */
	public int getKillCdCost(Human human) {
		return Globals.getGameConstants().getArenaKillCdCost();
	}
	
	/**
	 * 显示竞技场战斗日志列表
	 * @param human
	 */
	public void showBattleLogList(Human human) {
		long uuid = human.getUUID();
		ArenaMember member = getArenaMember(uuid);
		if (member == null) {
			return;
		}
		
		human.sendMessage(ArenaMsgBuilder.buildGCArenaBattleRecord(human, member.getFightLogList()));
	}
	
	/**
	 * 显示竞技场奖励列表
	 * @param human
	 */
	public void showRankRewardList(Human human) {
		List<Integer> rankList = Globals.getTemplateCacheService().getArenaTemplateCache().getRankRewardKeyList();
		List<String> showRewardList = Globals.getTemplateCacheService().getArenaTemplateCache().getShowRewardList();
  		human.sendMessage(new GCArenaRankRewardList(showRewardList.toArray(new String[0]), ArrayUtils.toPrimitive(rankList.toArray(new Integer[0]))));
	}
	
	class ArenaOpponentComparator implements Comparator<ArenaOpponent> {
		@Override
		public int compare(ArenaOpponent o1, ArenaOpponent o2) {
			//先按rank排，rank相同按score排，score相同按id排
			if (o1.getRank() < o2.getRank()) {
				return -1;
			}
			return 1;
		}
	}
}
