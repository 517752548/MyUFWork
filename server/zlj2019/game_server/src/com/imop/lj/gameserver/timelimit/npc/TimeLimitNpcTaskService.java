package com.imop.lj.gameserver.timelimit.npc;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.TimeLimitNpcLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.activity.function.ActivityDef;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinereward.OfflineRewardDef.OfflineRewardType;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;
import com.imop.lj.gameserver.team.TeamBattleProcess;
import com.imop.lj.gameserver.timelimit.msg.GCOpenTlNpcPanel;
import com.imop.lj.gameserver.timelimit.msg.GCTlNpcUpdate;

public class TimeLimitNpcTaskService implements InitializeRequired {

	@Override
	public void init() {
		
	}

	public boolean canAcceptTask(Human human, int questId) {
		checkHumanValid(human);
		
		if(human.getTimeLimitNpcManager().isDoing()){
			return false;
		}
		
		//任务是否可做
		boolean canDoFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.TIME_LIMIT_NPC);
		if(!canDoFlag){
			return false;
		}
		
		return true;
	}
	
	
	/**
	 * 接受任务
	 * @param human
	 */
	public void acceptTask(Human human) {
		checkHumanValid(human);
		
		//任务是否可做
		boolean canDoFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.TIME_LIMIT_NPC);
		if(!canDoFlag){
			human.sendErrorMessage(LangConstants.TIMELIMIT_NPC_MAX_NUM,
					human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.TIME_LIMIT_NPC));
			return;
		}
		//任务状态是否正确
		TimeLimitNpc curTask = human.getTimeLimitNpcManager().getCurTask();
		
		int questId = 0;
		if(curTask == null || curTask.getStatus() != TaskStatus.CAN_ACCEPT){
			questId = human.getTimeLimitManager().getPushQuestId();
		}
		//当前玩家身上没有限时活动
		if(questId <= 0){
			return;
		}
		
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
		if(questTpl == null){
			Loggers.timeLimitNpcLogger.error("#TimeLimitNpcService#acceptTask get QuestTemplate is null!questId="+ questId);
			return;
		}
		
		TimeLimitNpc task = buildInitTask(human, questTpl);
		task.onAcceptTask();
	}

	/**
	 * 验证human是否有效
	 * @param human
	 */
	protected void checkHumanValid(Human human) {
		if(human == null || human.getTimeLimitNpcManager() == null){
			return;
		}
	}

	/**
	 * 构建初始的任务数据
	 * @param human
	 * @param questTpl
	 * @return
	 */
	protected TimeLimitNpc buildInitTask(Human human, QuestTemplate questTpl) {
		checkHumanValid(human);
		TimeLimitNpc task = new TimeLimitNpc(human, questTpl);
		task.setStatus(TaskStatus.CAN_ACCEPT);
		task.setId(KeyUtil.UUIDKey());
		task.setStartTime(Globals.getTimeService().now());
		task.setLastUpdateTime(Globals.getTimeService().now());
		// 激活并存库
		task.active();
		task.setModified();
		return task;
	}

	public boolean onAcceptTaskImpl(Human human, TimeLimitNpc TimeLimitNpc) {
		checkHumanValid(human);
		
		//当前是否已领取限时任务
		if(human.getTimeLimitNpcManager().isDoing()){
			return false;
		}
		
		//设置当前任务
		human.getTimeLimitNpcManager().setCurTask(TimeLimitNpc);
		human.setModified();
		
		//给前台发消息,更新进行中的任务
		human.sendMessage(buildGCOpenTimeLimitNpcPanel(human));
		human.sendMessage(buildGCTimeLimitNpcUpdate(TimeLimitNpc));
		
		//记录日志
		Globals.getLogService().sendTimeLimitNpcLog(human, TimeLimitNpcLogReason.ACCEPT_TASK, "",
				TimeLimitNpc.getQuestId(), TimeLimitNpc.getStatus().getIndex());
		
		//领取成功
		human.sendErrorMessage(LangConstants.TIMELIMIT_ACCEPT_OK);
		
		return true;
	}
	
	protected GCTlNpcUpdate buildGCTimeLimitNpcUpdate(TimeLimitNpc TimeLimitNpc){
		GCTlNpcUpdate msg = new GCTlNpcUpdate();
		msg.setQuestInfo(TimeLimitNpc.buildQuestInfo());
		return msg;
	}
	
	protected GCOpenTlNpcPanel buildGCOpenTimeLimitNpcPanel(Human human){
		int finishTimes = human.getBehaviorManager().getCount(BehaviorTypeEnum.TIME_LIMIT_NPC);
		int totalTimes = human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.TIME_LIMIT_NPC);
		
		GCOpenTlNpcPanel msg = new GCOpenTlNpcPanel();
		msg.setFinishTimes(finishTimes);
		msg.setTotalTimes(totalTimes);
		return msg;
	}

	/**
	 * 放弃 限时任务
	 * @param human
	 */
	public void giveUpTask(Human human) {
		checkHumanValid(human);
		
		//是否有限时任务
		if(!human.getTimeLimitNpcManager().isDoing()){
			return;
		}
		
		//获取当前任务
		TimeLimitNpc curTask = human.getTimeLimitNpcManager().getCurTask();
		if(curTask == null ||!curTask.canGiveUpTask()){
			return;
		}
		
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		curTask.onGiveUpTask();
		
		//记录日志
		Globals.getLogService().sendTimeLimitNpcLog(human, TimeLimitNpcLogReason.GIVEUP_TASK,	 "",
				questId, status);
		
	}

	public boolean onGiveupTaskImpl(Human human) {
		checkHumanValid(human);
		
		//放弃任务后，扣除本次任务次数
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.TIME_LIMIT_NPC);
		
		//获取当前任务
		TimeLimitNpc curTask = human.getTimeLimitNpcManager().getCurTask();
		if(curTask == null){
			return false;
		}
		
		//发消息更新任务
		human.sendMessage(buildGCOpenTimeLimitNpcPanel(human));
		human.sendMessage(buildGCTimeLimitNpcUpdate(curTask));
		human.getTimeLimitNpcManager().clearCurTask();
		human.setModified();
		
		//初始化限时活动
		human.getTimeLimitManager().resetTimeLimit(human);
		
		return true;
	}

	/**
	 * 完成限时任务
	 * @param human
	 */
	public void finishTask(Human human) {
		checkHumanValid(human);
		
		//是否有限时任务
		if(!human.getTimeLimitNpcManager().isDoing()){
			return;
		}
		
		//获取当前任务
		TimeLimitNpc curTask = human.getTimeLimitNpcManager().getCurTask();
		if(curTask == null ||!curTask.canFinishTask()){
			return;
		}
		
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		
		boolean flag = curTask.onFinishTask();
		if(!flag){
			Loggers.questLogger.error("玩家试图完成一个不可完成的任务！humanId=" + 
					human.getCharId() + ";questId=" + questId);
			return;
		}
		
		//记录日志
		Globals.getLogService().sendTimeLimitNpcLog(human, TimeLimitNpcLogReason.FINISH_TASK, "",
				questId, status);
	}

	public boolean onFinishTaskImpl(Human human) {
		checkHumanValid(human);
		
		//任务完成计数
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.TIME_LIMIT_NPC);
		
		
		//获取当前任务
		TimeLimitNpc curTask = human.getTimeLimitNpcManager().getCurTask();
		if(curTask == null){
			return false;
		}
		
		//发消息更新任务
		human.sendMessage(buildGCOpenTimeLimitNpcPanel(human));
		human.sendMessage(buildGCTimeLimitNpcUpdate(curTask));
		
		//玩家能否继续做任务,如不可以,则发消息通知
		boolean canDo = human.getBehaviorManager().canDo(BehaviorTypeEnum.TIME_LIMIT_NPC);
		if(!canDo){
			//通知客户端,任务已经做完了
			human.sendErrorMessage(LangConstants.TIMELIMIT_NPC_FINISH_ALL
					, human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.TIME_LIMIT_NPC));
		}
		//初始化限时活动
		human.getTimeLimitManager().resetTimeLimit(human);
		
		//世界广播
		Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getTimeLimitNpcNoticeId(),
				human.getName());
		return true;
	}

	/**
	 * 玩家登陆时发送限时任务信息
	 * @param human
	 */
	public void sendCurTimeLimitNpcMsg(Human human) {
		checkHumanValid(human);

		//是否有进行中的任务
		if(!human.getTimeLimitNpcManager().isDoing()){
			return;
		}
		
		//玩家身上是否有限时挑战npc活动
		if(ActivityDef.TimeLimitType.valueOf(human.getTimeLimitManager().getPushType()) == null
				|| human.getTimeLimitManager().getPushType() != ActivityDef.TimeLimitType.NPC.index){
			return;
		}
		//超时
		if(Globals.getTimeService().now() - human.getTimeLimitManager().getStartTime() > Globals.getGameConstants().getTimeLimitExistenceTime()){
			human.getTimeLimitManager().resetTimeLimit(human);
			return;
		}
		
		TimeLimitNpc curTask = human.getTimeLimitNpcManager().getCurTask();
		if(curTask == null){
			return;
		}
		
		//发送前台消息
		human.sendMessage(buildGCOpenTimeLimitNpcPanel(human));
		human.sendMessage(buildGCTimeLimitNpcUpdate(curTask));
		
	}

	/**
	 * 功能开启时，初始化数据
	 * @param human
	 * @param funcType
	 */
	public void onOpenFunc(Human human, FuncTypeEnum funcType) {
		if(funcType != FuncTypeEnum.TIME_LIMIT_NPC){
			return;
		}
	}

	/**
	 * 组队打限时Npc的时候,要给没有任务的玩家助战奖励
	 * @param bp
	 * @param npcInfo
	 * @param isAttackerWin
	 * @param isForceEnd
	 */
	public void onNpcBattleEnd(BattleProcess bp, NpcInfo npcInfo, boolean isAttackerWin, boolean isForceEnd) {
		if (isAttackerWin && !isForceEnd) {
			// 参与战斗的每个玩家的处理
			if (bp instanceof TeamBattleProcess) {
				TeamBattleProcess tbp = (TeamBattleProcess) bp;
				boolean giveRewardFlag = false;
				Reward reward = null;
				for (Long roleId : tbp.getBattleInfoMap().keySet()) {
					Human human = Globals.getHumanCacheService().getHumanOnlineOrCache(roleId);
					if (human != null) {
						
						//是否可以获得助战奖励
						if(!canGetAssistReward(human)){
							continue;
						}
						
						//发助战奖励
						int assisRewardId = Globals.getTemplateCacheService().getTimeLimitTemplateCache().getAssistRewardIdByLevel(human.getLevel());
						if(assisRewardId <= 0){
							continue;
						}
						reward = Globals.getRewardService().createReward(roleId, assisRewardId,
								"gain assist reward by timelimt npc battle end.");
						
						giveRewardFlag = Globals.getRewardService().giveReward(human, reward, true);
					} else {
						// 玩家真正离线,离线奖励
						giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId,
								OfflineRewardType.TIMELIMIT_NPC, reward, "");
					}

					if (!giveRewardFlag) {
						// 记录错误日志
						Loggers.devilIncarnateLogger
								.error("TimeLimitNpcTaskService#onNpcBattleEnd give reward error!humanId=" + roleId);
						return;
					}
				}

			}
		}
	}
	
	protected boolean canGetAssistReward(Human human){
		long roleId = human.getCharId();
		// 跳过队长
		if (Globals.getTeamService().isTeamLeader(roleId)) {
			return false;
		}
		//跳过有该限时Npc任务的玩家
		if(human.getTimeLimitNpcManager() != null
				&& human.getTimeLimitNpcManager().getCurTask() != null){
			int questId = human.getTimeLimitNpcManager().getCurTask().getQuestId();
			QuestTemplate tpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
			if(tpl != null){
				int targetQuestId = Integer.parseInt(tpl.getSpecialDestination().get(0).getParam2nd());
				if(questId == targetQuestId){
					return false;
				}
			}
		}
		return true;
	}
}