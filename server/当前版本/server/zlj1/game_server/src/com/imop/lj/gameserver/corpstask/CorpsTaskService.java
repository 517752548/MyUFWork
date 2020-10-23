package com.imop.lj.gameserver.corpstask;

import java.util.List;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.CorpsTaskLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corpstask.msg.GCCorpstaskUpdate;
import com.imop.lj.gameserver.corpstask.msg.GCOpenCorpstaskPanel;
import com.imop.lj.gameserver.corpstask.template.CorpsTaskTemplate;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

public class CorpsTaskService implements InitializeRequired {

	@Override
	public void init() {
		
	}

	public boolean canAcceptTask(Human human, int questId) {
		checkHumanValid(human);
		
		if(human.getCorpsTaskManager().isDoing()){
			return false;
		}
		
		//任务是否可做
		boolean canDoFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.CORPS_TASK_NUM);
		if(!canDoFlag){
			return false;
		}
		
		return true;
	}
	
	
	/**
	 * 接受任务
	 * @param human
	 * @param corpsLevel 
	 */
	public void acceptTask(Human human, int corpsLevel) {
		checkHumanValid(human);
		
		//任务是否可做
		boolean canDoFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.CORPS_TASK_NUM);
		if(!canDoFlag){
			human.sendErrorMessage(LangConstants.CORPSTASK_MAX_NUM,
					human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.CORPS_TASK_NUM));
			return;
		}
		//任务状态是否正确
		CorpsTask curTask = human.getCorpsTaskManager().getCurTask();
		
		CorpsTaskTemplate corpsTpl = null;
		if(curTask == null || curTask.getStatus() != TaskStatus.CAN_ACCEPT){
			corpsTpl = randTask(corpsLevel);
		}
		
		if(corpsTpl == null){
			return;
		}
		
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(corpsTpl.getQuestId(), QuestTemplate.class);
		if(questTpl == null){
			Loggers.corpsTaskLogger.error("#CorpsTaskService#acceptTask get QuestTemplate is null!questId="+ corpsTpl.getQuestId());
			return;
		}
		
		CorpsTask task = buildInitTask(human, questTpl);
		task.onAcceptTask();
	}

	/**
	 * 验证human是否有效
	 * @param human
	 */
	protected void checkHumanValid(Human human) {
		if(human == null || human.getCorpsTaskManager() == null){
			return;
		}
	}

	/**
	 * 构建初始的任务数据
	 * @param human
	 * @param questTpl
	 * @return
	 */
	protected CorpsTask buildInitTask(Human human, QuestTemplate questTpl) {
		checkHumanValid(human);
		CorpsTask task = new CorpsTask(human, questTpl);
		task.setStatus(TaskStatus.CAN_ACCEPT);
		task.setId(KeyUtil.UUIDKey());
		task.setStartTime(Globals.getTimeService().now());
		task.setLastUpdateTime(Globals.getTimeService().now());
		// 激活并存库
		task.active();
		task.setModified();
		return task;
	}

	protected CorpsTaskTemplate randTask(int level) {
		List<CorpsTaskTemplate> lst = Globals.getTemplateCacheService().getCorpsTaskTemplateCache().getCorpsTaskListByLevel(level);
		if(lst == null || lst.isEmpty()){
			Loggers.corpsTaskLogger.error("#CorpsTaskService#randTask result is null!level="+ level);
			return null;
		}
		List<CorpsTaskTemplate> cList = RandomUtils.hitObjects(lst, 1);
		if(cList != null){
			return cList.get(0);
		}
		return null;
	}

	public boolean onAcceptTaskImpl(Human human, CorpsTask corpsTask) {
		checkHumanValid(human);
		
		//当前是否已领取帮派任务
		if(human.getCorpsTaskManager().isDoing()){
			return false;
		}
		
		//设置当前任务
		human.getCorpsTaskManager().setCurTask(corpsTask);
		human.setModified();
		
		//给前台发消息,更新进行中的任务
		human.sendMessage(buildGCOpenCorpstaskPanel(human));
		human.sendMessage(buildGCCorpstaskUpdate(corpsTask));
		
		//记录日志
		Globals.getLogService().sendCorpsTaskLog(human, CorpsTaskLogReason.ACCEPT_TASK, "",
				corpsTask.getQuestId(), corpsTask.getStatus().getIndex());
		
		return true;
	}
	
	protected GCCorpstaskUpdate buildGCCorpstaskUpdate(CorpsTask corpsTask){
		GCCorpstaskUpdate msg = new GCCorpstaskUpdate();
		msg.setQuestInfo(corpsTask.buildQuestInfo());
		return msg;
	}
	
	protected GCOpenCorpstaskPanel buildGCOpenCorpstaskPanel(Human human){
		int finishTimes = human.getBehaviorManager().getCount(BehaviorTypeEnum.CORPS_TASK_NUM);
		int totalTimes = human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.CORPS_TASK_NUM);
		
		GCOpenCorpstaskPanel msg = new GCOpenCorpstaskPanel();
		msg.setFinishTimes(finishTimes);
		msg.setTotalTimes(totalTimes);
		return msg;
	}

	/**
	 * 放弃 帮派任务
	 * @param human
	 */
	public void giveUpTask(Human human) {
		checkHumanValid(human);
		
		//是否有帮派任务
		if(!human.getCorpsTaskManager().isDoing()){
			return;
		}
		
		//获取当前任务
		CorpsTask curTask = human.getCorpsTaskManager().getCurTask();
		if(curTask == null ||!curTask.canGiveUpTask()){
			return;
		}
		
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		curTask.onGiveUpTask();
		
		//记录日志
		Globals.getLogService().sendCorpsTaskLog(human, CorpsTaskLogReason.GIVEUP_TASK,	 "",
				questId, status);
		
	}

	public boolean onGiveupTaskImpl(Human human) {
		checkHumanValid(human);
		
		//放弃任务后，扣除本次任务次数
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.CORPS_TASK_NUM);
		
		//获取当前任务
		CorpsTask curTask = human.getCorpsTaskManager().getCurTask();
		if(curTask == null){
			return false;
		}
		
		//发消息更新任务
		human.sendMessage(buildGCOpenCorpstaskPanel(human));
		human.sendMessage(buildGCCorpstaskUpdate(curTask));
		human.getCorpsTaskManager().clearCurTask();
		human.setModified();
		return true;
	}

	/**
	 * 完成帮派任务
	 * @param human
	 */
	public void finishTask(Human human) {
		checkHumanValid(human);
		
		//是否有帮派任务
		if(!human.getCorpsTaskManager().isDoing()){
			return;
		}
		
		//获取当前任务
		CorpsTask curTask = human.getCorpsTaskManager().getCurTask();
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
		Globals.getLogService().sendCorpsTaskLog(human, CorpsTaskLogReason.FINISH_TASK, "",
				questId, status);
	}

	public boolean onFinishTaskImpl(Human human) {
		checkHumanValid(human);
		
		//任务完成计数
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.CORPS_TASK_NUM);
		
		
		//获取当前任务
		CorpsTask curTask = human.getCorpsTaskManager().getCurTask();
		if(curTask == null){
			return false;
		}
		
		//发消息更新任务
		human.sendMessage(buildGCOpenCorpstaskPanel(human));
		human.sendMessage(buildGCCorpstaskUpdate(curTask));
		
		//玩家能否继续做任务,如不可以,则发消息通知
		boolean canDo = human.getBehaviorManager().canDo(BehaviorTypeEnum.CORPS_TASK_NUM);
		if(!canDo){
			//通知客户端,本周的任务已经做完了
			human.sendErrorMessage(LangConstants.CORPSTASK_FINISH_ALL
					, human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.CORPS_TASK_NUM));
		}
		else{
			//发送下一个任务
			int corpsLevel = Globals.getCorpsService().getUserCorpsLevel(human.getCharId());
			if(corpsLevel <= 0){
				return false;
			}
			this.acceptTask(human, corpsLevel);
		}
		
		return true;
	}

	/**
	 * 玩家登陆时发送帮派任务信息
	 * @param human
	 */
	public void sendCurCorpsTaskMsg(Human human) {
		checkHumanValid(human);

		//是否有 帮派
		Corps corps = Globals.getCorpsService().getUserCorps(human.getCharId());
		if(corps == null){
			return;
		}
		
		//是否有进行中的任务
		if(!human.getCorpsTaskManager().isDoing()){
			return;
		}
		
		CorpsTask curTask = human.getCorpsTaskManager().getCurTask();
		if(curTask == null){
			return;
		}
		
		//发送前台消息
		human.sendMessage(buildGCOpenCorpstaskPanel(human));
		human.sendMessage(buildGCCorpstaskUpdate(curTask));
		
	}

	/**
	 * 功能开启时，初始化数据
	 * @param human
	 * @param funcType
	 */
	public void onOpenFunc(Human human, FuncTypeEnum funcType) {
		if(funcType != FuncTypeEnum.CORPSTASK){
			return;
		}
		
		human.snapChangedProperty(true);
		
		//TODO
	}

}