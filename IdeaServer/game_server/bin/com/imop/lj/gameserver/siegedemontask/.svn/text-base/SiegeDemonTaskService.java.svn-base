package com.imop.lj.gameserver.siegedemontask;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.SiegeDemonTaskLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.quest.QuestPanelInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.func.template.FuncOpenTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.siegedemon.SiegeDemonDef.SiegeDemonType;
import com.imop.lj.gameserver.siegedemon.msg.GCOpenSiegedemontaskPanel;
import com.imop.lj.gameserver.siegedemon.msg.GCSiegedemontaskUpdate;
import com.imop.lj.gameserver.siegedemon.template.SiegeDemonTemplate;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

public class SiegeDemonTaskService implements InitializeRequired {

	@Override
	public void init() {
		
	}

	public boolean canAcceptTask(Human human, int questId) {
		
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
		if(questTpl == null){
			return false;
		}
		if(isNormalSiege(questTpl.getQuestType())){
			if(human.getSiegeDemonNormalTaskManager().isDoing()){
				return false;
			}
		}else if(isHardSiege(questTpl.getQuestType())){
			if(human.getSiegeDemonHardTaskManager().isDoing()){
				return false;
			}
		}
		
		//任务是否可做
		boolean canDoFlag = isNormalSiege(questTpl.getQuestType()) ? human.getBehaviorManager().canDo(BehaviorTypeEnum.SIEGE_DEMON_NORMAL)
							: human.getBehaviorManager().canDo(BehaviorTypeEnum.SIEGE_DEMON_HARD);
		if(!canDoFlag){
			return false;
		}
		
		return true;
	}

	/**
	 * 接受任务
	 * @param human
	 * @param siegeType
	 */
	public void acceptTask(Human human, int siegeType) {
		if(human == null){
			return;
		}
		
		SiegeDemonTemplate siegeTpl = null;
		SiegeDemonTask curTask = null;
		if (isNormalSiege(siegeType)) {
			if (human.getSiegeDemonNormalTaskManager() == null) {
				return;
			}
			
			curTask = human.getSiegeDemonNormalTaskManager().getCurTask();
			//任务状态是否正确
			if(curTask == null || curTask.getStatus() != TaskStatus.CAN_ACCEPT){
				List<SiegeDemonTemplate> monsterTplList = Globals.getTemplateCacheService().getSiegeDemonTemplateCache().getMonsterTplList(siegeType);
				if(monsterTplList != null && !monsterTplList.isEmpty()){
					if(human.getSiegeDemonNormalTaskManager().getFinishedSet().isEmpty()){
						//第一个任务
						siegeTpl = monsterTplList.get(0);
					}else{
						//后续任务
						for (SiegeDemonTemplate tpl : monsterTplList) {
							//已完成的任务，跳过
							if (human.getSiegeDemonNormalTaskManager().isFinished(tpl.getTaskId())) {
								continue;
							}
							siegeTpl = tpl;
							break;
						}
					}
				}
			}
			
			
		}else if(isHardSiege(siegeType)){
			if (human.getSiegeDemonHardTaskManager() == null) {
				return;
			}
			curTask = human.getSiegeDemonHardTaskManager().getCurTask();
			//任务状态是否正确
			if(curTask == null || curTask.getStatus() != TaskStatus.CAN_ACCEPT){
				List<SiegeDemonTemplate> monsterTplList = Globals.getTemplateCacheService().getSiegeDemonTemplateCache().getMonsterTplList(siegeType);
				if(monsterTplList != null && !monsterTplList.isEmpty()){
					if(human.getSiegeDemonHardTaskManager().getFinishedSet().isEmpty()){
						//第一个任务
						siegeTpl = monsterTplList.get(0);
					}else{
						//后续任务
						for (SiegeDemonTemplate tpl : monsterTplList) {
							//已完成的任务，跳过
							if (human.getSiegeDemonHardTaskManager().isFinished(tpl.getTaskId())) {
								continue;
							}
							siegeTpl = tpl;
							break;
						}
					}
				}
			}
			
		}
		
		if(siegeTpl == null){
			return;
		}
		
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(siegeTpl.getTaskId(), QuestTemplate.class);
		if(questTpl == null){
			Loggers.siegeDemonLogger.error("#SiegeDemonTaskService#acceptTask get QuestTemplate is null!questId="+ siegeTpl.getTaskId());
			return;
		}
		
		SiegeDemonTask task = buildInitTask(human, questTpl);
		task.onAcceptTask();
	}
	

	public boolean onAcceptTask(Human human, SiegeDemonTask siegeDemonTask) {
		if(human == null ){
			return false;
		}
		
		int siegeType = siegeDemonTask.getQuestType().getIndex();
		if (isNormalSiege(siegeType)) {
			if (human.getSiegeDemonNormalTaskManager() == null) {
				return false;
			}
			//当前是否已领取任务
			if(human.getSiegeDemonNormalTaskManager().isDoing()){
				return false;
			}
			//设置当前任务
			human.getSiegeDemonNormalTaskManager().setCurTask(siegeDemonTask);
			human.setModified();
		}else if (isHardSiege(siegeType)) {
			if (human.getSiegeDemonHardTaskManager() == null) {
				return false;
			}
			//当前是否已领取任务
			if(human.getSiegeDemonHardTaskManager().isDoing()){
				return false;
			}
			//设置当前任务
			human.getSiegeDemonHardTaskManager().setCurTask(siegeDemonTask);
			human.setModified();
		}
		
		
		//给前台发消息,更新进行中的任务
		human.sendMessage(buildGCOpenSiegedemontaskPanel(human));
		human.sendMessage(buildGCSiegedemontaskUpdate(siegeDemonTask));
		
		//记录日志
		Globals.getLogService().sendSiegeDemonTaskLog(human, SiegeDemonTaskLogReason.ACCEPT_TASK, "",
				siegeDemonTask.getQuestId(), siegeDemonTask.getStatus().getIndex());
		
		return true;
	}
	
	
	protected GCSiegedemontaskUpdate buildGCSiegedemontaskUpdate(SiegeDemonTask siegeDemonTask){
		GCSiegedemontaskUpdate msg = new GCSiegedemontaskUpdate();
		msg.setQuestInfo(siegeDemonTask.buildQuestInfo());
		msg.setQuestType(siegeDemonTask.getQuestType().getIndex());
		return msg;
	}
	
	protected GCOpenSiegedemontaskPanel buildGCOpenSiegedemontaskPanel(Human human){
		GCOpenSiegedemontaskPanel msg = new GCOpenSiegedemontaskPanel();
		List<QuestPanelInfo> lst = new ArrayList<QuestPanelInfo>();
		 SiegeDemonType[] values = SiegeDemonType.values();
		 for (int i = 0; i < values.length; i++) {
			 QuestPanelInfo info = new QuestPanelInfo();
			int questType = values[i].getIndex();
			int finishTimes = isNormalSiege(questType) ? human.getBehaviorManager().getCount(BehaviorTypeEnum.SIEGE_DEMON_NORMAL)
					: human.getBehaviorManager().getCount(BehaviorTypeEnum.SIEGE_DEMON_HARD);
			int totalTimes = isNormalSiege(questType) ? human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.SIEGE_DEMON_NORMAL)
					: human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.SIEGE_DEMON_HARD);
			int funcIndex = isNormalSiege(questType) ? FuncTypeEnum.SIEGE_DEMON_NORMAL.getIndex() 
					: FuncTypeEnum.SIEGE_DEMON_HARD.getIndex();
			FuncOpenTemplate funcOpenTpl = Globals.getTemplateCacheService().get(funcIndex, FuncOpenTemplate.class);
			if(funcOpenTpl == null){
				continue;
			}
			
			info.setQuestType(questType);
			info.setQuestMinLevel(funcOpenTpl.getLimitLevel());
			info.setFinishTimes(finishTimes);
			info.setTotalTimes(totalTimes);
			lst.add(info);
		}
		msg.setQuestPanelInfo(lst.toArray(new QuestPanelInfo[0]));
		return msg;
	}
	
	/**
	 * 构建初始的任务数据
	 * @param human
	 * @param questTpl
	 * @return
	 */
	protected SiegeDemonTask buildInitTask(Human human, QuestTemplate questTpl) {
		SiegeDemonTask task = new SiegeDemonTask(human, questTpl);
		task.setStatus(TaskStatus.CAN_ACCEPT);
		task.setId(KeyUtil.UUIDKey());
		task.setStartTime(Globals.getTimeService().now());
		task.setLastUpdateTime(Globals.getTimeService().now());
		// 激活并存库
		task.active();
		task.setModified();
		return task;
	}

	protected boolean isNormalSiege(int siegeType) {
		return siegeType == QuestType.SIEGE_DEMON_NOMAL.getIndex();
	}
	
	protected boolean isHardSiege(int siegeType) {
		return siegeType == QuestType.SIEGE_DEMON_HARD.getIndex();
	}

	/**
	 * 放弃任务
	 * @param human
	 * @param siegeType
	 */
	public void giveTask(Human human, int siegeType) {
		if(human == null){
			return ;
		}
		SiegeDemonTask curTask = null;
		if (isNormalSiege(siegeType)) {
			if (human.getSiegeDemonNormalTaskManager() == null) {
				return;
			}
			//是否有围剿魔族任务
			if(!human.getSiegeDemonNormalTaskManager().isDoing()){
				return;
			}
			//获取当前任务
			curTask = human.getSiegeDemonNormalTaskManager().getCurTask();
			if(curTask == null ||!curTask.canGiveUpTask()){
				return;
			}
		}else if (isHardSiege(siegeType)) {
			if (human.getSiegeDemonHardTaskManager() == null) {
				return;
			}
			//是否有围剿魔族任务
			if(!human.getSiegeDemonHardTaskManager().isDoing()){
				return;
			}
			//获取当前任务
			curTask = human.getSiegeDemonHardTaskManager().getCurTask();
			if(curTask == null ||!curTask.canGiveUpTask()){
				return;
			}
		}
		
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		curTask.onGiveUpTask();
		
		//记录日志
		Globals.getLogService().sendSiegeDemonTaskLog(human,SiegeDemonTaskLogReason.GIVEUP_TASK,	 "",
				questId, status);
		
	}

	public boolean onGiveupTask(Human human, SiegeDemonTask siegeDemonTask) {
		if(human == null ){
			return false;
		}
		SiegeDemonTask curTask = null;
		int siegeType = siegeDemonTask.getQuestType().getIndex();
		if (isNormalSiege(siegeType)) {
			if (human.getSiegeDemonNormalTaskManager() == null) {
				return false;
			}
			//放弃任务后，扣除本次任务次数
			human.getBehaviorManager().doBehavior(BehaviorTypeEnum.SIEGE_DEMON_NORMAL);
			//获取当前任务
			curTask = human.getSiegeDemonNormalTaskManager().getCurTask();
			if(curTask == null){
				return false;
			}
			
			//发消息更新任务
			human.sendMessage(buildGCOpenSiegedemontaskPanel(human));
			human.sendMessage(buildGCSiegedemontaskUpdate(curTask));
			human.getSiegeDemonNormalTaskManager().clearCurTask();
			human.setModified();
		}else if(isHardSiege(siegeType)){
			if (human.getSiegeDemonHardTaskManager() == null) {
				return false;
			}
			//放弃任务后，扣除本次任务次数
			human.getBehaviorManager().doBehavior(BehaviorTypeEnum.SIEGE_DEMON_HARD);
			//获取当前任务
			curTask = human.getSiegeDemonHardTaskManager().getCurTask();
			if(curTask == null){
				return false;
			}
			//发消息更新任务
			human.sendMessage(buildGCOpenSiegedemontaskPanel(human));
			human.sendMessage(buildGCSiegedemontaskUpdate(curTask));
			human.getSiegeDemonHardTaskManager().clearCurTask();
			human.setModified();
		}
	
		return true;
	}

	/**
	 * 完成任务
	 * @param human
	 * @param siegeType
	 */
	public void finishTask(Human human, int siegeType) {
		if(human == null){
			return ;
		}
		SiegeDemonTask curTask = null;
		if(isNormalSiege(siegeType)){
			if(human.getSiegeDemonNormalTaskManager() == null){
				return;
			}
			//是否有围剿魔族任务
			if(!human.getSiegeDemonNormalTaskManager().isDoing()){
				return;
			}
			//获取当前任务
			curTask = human.getSiegeDemonNormalTaskManager().getCurTask();
			if(curTask == null ||!curTask.canFinishTask()){
				return;
			}
		}else if(isHardSiege(siegeType)){
			if(human.getSiegeDemonHardTaskManager() == null){
				return;
			}
			//是否有围剿魔族任务
			if(!human.getSiegeDemonHardTaskManager().isDoing()){
				return;
			}
			curTask = human.getSiegeDemonHardTaskManager().getCurTask();
			if(curTask == null ||!curTask.canFinishTask()){
				return;
			}
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
		Globals.getLogService().sendSiegeDemonTaskLog(human, SiegeDemonTaskLogReason.FINISH_TASK, "",
				questId, status);
		
	}
	
	public boolean onFinishTask(Human human, SiegeDemonTask siegeDemonTask) {
		if(human == null){
			return false;
		}
		
		SiegeDemonTask curTask = null;
		int siegeType = siegeDemonTask.getQuestType().getIndex();
		if(isNormalSiege(siegeType)){
			if(human.getSiegeDemonNormalTaskManager() == null){
				return false;
			}
			
			//加入已完成任务Set
			human.getSiegeDemonNormalTaskManager().addFinishedTask(siegeDemonTask.getQuestId());
			
			//任务完成计数
			human.getBehaviorManager().doBehavior(BehaviorTypeEnum.SIEGE_DEMON_NORMAL);
			//获取当前任务
			curTask = human.getSiegeDemonNormalTaskManager().getCurTask();
			if(curTask == null){
				return false;
			}
		}else if(isHardSiege(siegeType)){
			if(human.getSiegeDemonHardTaskManager() == null){
				return false;
			}
			//加入已完成任务Set
			human.getSiegeDemonHardTaskManager().addFinishedTask(siegeDemonTask.getQuestId());
			
			//任务完成计数
			human.getBehaviorManager().doBehavior(BehaviorTypeEnum.SIEGE_DEMON_HARD);
			//获取当前任务
			curTask = human.getSiegeDemonHardTaskManager().getCurTask();
			if(curTask == null){
				return false;
			}
		}
		
		
		//发消息更新任务
		human.sendMessage(buildGCOpenSiegedemontaskPanel(human));
		human.sendMessage(buildGCSiegedemontaskUpdate(curTask));
		
		//玩家能否继续做任务,如不可以,则发消息通知
		boolean canDoFlag = isNormalSiege(siegeType) ? human.getBehaviorManager().canDo(BehaviorTypeEnum.SIEGE_DEMON_NORMAL)
				 : human.getBehaviorManager().canDo(BehaviorTypeEnum.SIEGE_DEMON_HARD);
		if(!canDoFlag){
			if(isNormalSiege(siegeType)){
				human.sendErrorMessage(LangConstants.SIEGEDEMONTASK_NORMAL_FINISH_ALL,
						human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.SIEGE_DEMON_NORMAL));
			}else{
				human.sendErrorMessage(LangConstants.SIEGEDEMONTASK_HARD_FINISH_ALL,
						human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.SIEGE_DEMON_HARD));
			}
		}else{
			//发送下一个任务
			this.acceptTask(human, siegeType);
		}
		
		return true;
	}
	
	
	/**
	 * 玩家登陆时发送围剿魔族任务信息
	 * @param human
	 */
	public void sendCurSiegeDemonNormalTaskMsg(Human human) {
		if(human == null || human.getSiegeDemonNormalTaskManager() == null){
			return ;
		}

		//是否有进行中的任务
		if(!human.getSiegeDemonNormalTaskManager().isDoing()){
			return;
		}
		
		SiegeDemonTask curTask = human.getSiegeDemonNormalTaskManager().getCurTask();
		if(curTask == null){
			return;
		}
		
		//发送前台消息
		human.sendMessage(buildGCOpenSiegedemontaskPanel(human));
		human.sendMessage(buildGCSiegedemontaskUpdate(curTask));
		
	}
	
	/**
	 * 玩家登陆时发送围剿魔族任务信息
	 * @param human
	 */
	public void sendCurSiegeDemonHardTaskMsg(Human human) {
		if(human == null || human.getSiegeDemonHardTaskManager() == null){
			return ;
		}
		
		//是否有进行中的任务
		if(!human.getSiegeDemonHardTaskManager().isDoing()){
			return;
		}
		
		SiegeDemonTask curTask = human.getSiegeDemonHardTaskManager().getCurTask();
		if(curTask == null){
			return;
		}
		
		//发送前台消息
		human.sendMessage(buildGCOpenSiegedemontaskPanel(human));
		human.sendMessage(buildGCSiegedemontaskUpdate(curTask));
		
	}
}
