package com.imop.lj.gameserver.timelimit.monster;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.TimeLimitMonsterLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.activity.function.ActivityDef;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;
import com.imop.lj.gameserver.timelimit.msg.GCOpenTlMonsterPanel;
import com.imop.lj.gameserver.timelimit.msg.GCTlMonsterUpdate;

public class TimeLimitMonsterTaskService implements InitializeRequired {

	@Override
	public void init() {
		
	}

	public boolean canAcceptTask(Human human, int questId) {
		checkHumanValid(human);
		
		if(human.getTimeLimitMonsterManager().isDoing()){
			return false;
		}
		
		//任务是否可做
		boolean canDoFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.TIME_LIMIT_MONSTER);
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
		boolean canDoFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.TIME_LIMIT_MONSTER);
		if(!canDoFlag){
			human.sendErrorMessage(LangConstants.TIMELIMIT_MONSTER_MAX_NUM,
					human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.TIME_LIMIT_MONSTER));
			return;
		}
		//任务状态是否正确
		TimeLimitMonster curTask = human.getTimeLimitMonsterManager().getCurTask();
		
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
			Loggers.timeLimitMonsterLogger.error("#TimeLimitMonsterService#acceptTask get QuestTemplate is null!questId="+ questId);
			return;
		}
		
		TimeLimitMonster task = buildInitTask(human, questTpl);
		task.onAcceptTask();
	}

	/**
	 * 验证human是否有效
	 * @param human
	 */
	protected void checkHumanValid(Human human) {
		if(human == null || human.getTimeLimitMonsterManager() == null){
			return;
		}
	}

	/**
	 * 构建初始的任务数据
	 * @param human
	 * @param questTpl
	 * @return
	 */
	protected TimeLimitMonster buildInitTask(Human human, QuestTemplate questTpl) {
		checkHumanValid(human);
		TimeLimitMonster task = new TimeLimitMonster(human, questTpl);
		task.setStatus(TaskStatus.CAN_ACCEPT);
		task.setId(KeyUtil.UUIDKey());
		task.setStartTime(Globals.getTimeService().now());
		task.setLastUpdateTime(Globals.getTimeService().now());
		// 激活并存库
		task.active();
		task.setModified();
		return task;
	}

	public boolean onAcceptTaskImpl(Human human, TimeLimitMonster TimeLimitMonster) {
		checkHumanValid(human);
		
		//当前是否已领取限时任务
		if(human.getTimeLimitMonsterManager().isDoing()){
			return false;
		}
		
		//设置当前任务
		human.getTimeLimitMonsterManager().setCurTask(TimeLimitMonster);
		human.setModified();
		
		//给前台发消息,更新进行中的任务
		human.sendMessage(buildGCOpenTimeLimitMonsterPanel(human));
		human.sendMessage(buildGCTimeLimitMonsterUpdate(TimeLimitMonster));
		
		//记录日志
		Globals.getLogService().sendTimeLimitMonsterLog(human, TimeLimitMonsterLogReason.ACCEPT_TASK, "",
				TimeLimitMonster.getQuestId(), TimeLimitMonster.getStatus().getIndex());
		
		//领取成功
		human.sendErrorMessage(LangConstants.TIMELIMIT_ACCEPT_OK);
		
		return true;
	}
	
	protected GCTlMonsterUpdate buildGCTimeLimitMonsterUpdate(TimeLimitMonster TimeLimitMonster){
		GCTlMonsterUpdate msg = new GCTlMonsterUpdate();
		msg.setQuestInfo(TimeLimitMonster.buildQuestInfo());
		return msg;
	}
	
	protected GCOpenTlMonsterPanel buildGCOpenTimeLimitMonsterPanel(Human human){
		int finishTimes = human.getBehaviorManager().getCount(BehaviorTypeEnum.TIME_LIMIT_MONSTER);
		int totalTimes = human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.TIME_LIMIT_MONSTER);
		
		GCOpenTlMonsterPanel msg = new GCOpenTlMonsterPanel();
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
		if(!human.getTimeLimitMonsterManager().isDoing()){
			return;
		}
		
		//获取当前任务
		TimeLimitMonster curTask = human.getTimeLimitMonsterManager().getCurTask();
		if(curTask == null ||!curTask.canGiveUpTask()){
			return;
		}
		
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		curTask.onGiveUpTask();
		
		//记录日志
		Globals.getLogService().sendTimeLimitMonsterLog(human, TimeLimitMonsterLogReason.GIVEUP_TASK,	 "",
				questId, status);
		
	}

	public boolean onGiveupTaskImpl(Human human) {
		checkHumanValid(human);
		
		//放弃任务后，扣除本次任务次数
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.TIME_LIMIT_MONSTER);
		
		//获取当前任务
		TimeLimitMonster curTask = human.getTimeLimitMonsterManager().getCurTask();
		if(curTask == null){
			return false;
		}
		
		//发消息更新任务
		human.sendMessage(buildGCOpenTimeLimitMonsterPanel(human));
		human.sendMessage(buildGCTimeLimitMonsterUpdate(curTask));
		human.getTimeLimitMonsterManager().clearCurTask();
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
		if(!human.getTimeLimitMonsterManager().isDoing()){
			return;
		}
		
		//获取当前任务
		TimeLimitMonster curTask = human.getTimeLimitMonsterManager().getCurTask();
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
		Globals.getLogService().sendTimeLimitMonsterLog(human, TimeLimitMonsterLogReason.FINISH_TASK, "",
				questId, status);
	}

	public boolean onFinishTaskImpl(Human human) {
		checkHumanValid(human);
		
		//任务完成计数
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.TIME_LIMIT_MONSTER);
		
		
		//获取当前任务
		TimeLimitMonster curTask = human.getTimeLimitMonsterManager().getCurTask();
		if(curTask == null){
			return false;
		}
		
		//发消息更新任务
		human.sendMessage(buildGCOpenTimeLimitMonsterPanel(human));
		human.sendMessage(buildGCTimeLimitMonsterUpdate(curTask));
		
		//玩家能否继续做任务,如不可以,则发消息通知
		boolean canDo = human.getBehaviorManager().canDo(BehaviorTypeEnum.TIME_LIMIT_MONSTER);
		if(!canDo){
			//通知客户端,任务已经做完了
			human.sendErrorMessage(LangConstants.TIMELIMIT_MONSTER_FINISH_ALL
					, human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.TIME_LIMIT_MONSTER));
		}
		//初始化限时活动
		human.getTimeLimitManager().resetTimeLimit(human);
		
		//世界广播
		Globals.getBroadcastService().broadcastWorldMessage(Globals.getGameConstants().getTimeLimitMonsterNoticeId(),
				human.getName());
		
		return true;
	}

	/**
	 * 玩家登陆时发送限时任务信息
	 * @param human
	 */
	public void sendCurTimeLimitMonsterMsg(Human human) {
		checkHumanValid(human);

		//是否有进行中的任务
		if(!human.getTimeLimitMonsterManager().isDoing()){
			return;
		}
		
		//玩家身上是否有限时杀怪活动
		if(ActivityDef.TimeLimitType.valueOf(human.getTimeLimitManager().getPushType()) == null
				|| human.getTimeLimitManager().getPushType() != ActivityDef.TimeLimitType.SG.index ){
			return;
		}
		//超时
		if(Globals.getTimeService().now() - human.getTimeLimitManager().getStartTime() > Globals.getGameConstants().getTimeLimitExistenceTime()){
			human.getTimeLimitManager().resetTimeLimit(human);
			return;
		} 
		
		TimeLimitMonster curTask = human.getTimeLimitMonsterManager().getCurTask();
		if(curTask == null){
			return;
		}
		
		//发送前台消息
		human.sendMessage(buildGCOpenTimeLimitMonsterPanel(human));
		human.sendMessage(buildGCTimeLimitMonsterUpdate(curTask));
		
	}

	/**
	 * 功能开启时，初始化数据
	 * @param human
	 * @param funcType
	 */
	public void onOpenFunc(Human human, FuncTypeEnum funcType) {
		if(funcType != FuncTypeEnum.TIME_LIMIT_MONSTER){
			return;
		}
	}

}