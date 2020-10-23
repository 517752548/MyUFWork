package com.imop.lj.gameserver.foragetask;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Map;

import com.google.common.collect.Maps;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.LogReasons.ForageTaskLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.BackupForageTaskInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.foragetask.msg.GCForagetaskDone;
import com.imop.lj.gameserver.foragetask.msg.GCForagetaskUpdate;
import com.imop.lj.gameserver.foragetask.msg.GCOpenForagetaskPanel;
import com.imop.lj.gameserver.foragetask.template.ForageTaskGroupTemplate;
import com.imop.lj.gameserver.foragetask.template.ForageTaskRewardTemplate;
import com.imop.lj.gameserver.foragetask.template.ForageTaskTemplate;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.task.TaskDef;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

public class ForageTaskService {
	
	/**
	 * 校验任务管理器和等级是否合法
	 * @param human
	 * @return
	 */
	protected boolean checkHumanTaskAndLevel(Human human) {
		if (human == null || human.getForageTaskManager() == null) {
			return false;
		}
		//护送粮草等级是否合法，挪到了功能判断模块中
		return true;
	}

	public boolean onAcceptTask(Human human, ForageTask forageTask) {
		if (!checkHumanTaskAndLevel(human) || forageTask == null) {
			return false;
		}
		//当前是否有任务正在执行
		if (human.getForageTaskManager().isDoing()) {
			return false;
		}
		//设置当前任务
		human.getForageTaskManager().setCurTask(forageTask);
		//设置备选任务状态
		BackupForageTask bft = human.getForageTaskManager().getBackupForageTask(forageTask.getQuestId());
		//更新数据库
		bft.setStatus(forageTask.getStatus());
		human.setModified();
		
		//给前台发消息，更新该任务为进行中
		human.sendMessage(new GCForagetaskUpdate(forageTask.buildQuestInfo()));
		
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.ENTER_FORAGE, 0, 1);
		
		//记录日志
		Globals.getLogService().sendForageTaskLog(human, ForageTaskLogReason.ACCEPT_TASK, "",
				human.getForageTaskManager().getBackupMap().toString(), forageTask.getQuestId(), forageTask.getStatus().getIndex());
		
		return true;
	}
	
	public void finishTask(Human human) {
		if (!checkHumanTaskAndLevel(human)) {
			return ;
		}
		
		//当前任务是否进行中
		if (!human.getForageTaskManager().isDoing()) {
			return;
		}
		
		ForageTask curTask = human.getForageTaskManager().getCurTask();
		if (!curTask.canFinishTask()) {
			return ;
		}
		
		int questId = curTask.getQuestId();
		//任务id是否正常
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(questId, QuestTemplate.class);
		if (questTpl == null) {
			Loggers.humanLogger.error("#ForageTaskService#acceptTask#ERROR!quest not exist!humanId=" + human.getCharId());
			return ;
		}
		
		ForageTaskRewardTemplate  rewardTpl = Globals.getTemplateCacheService().getForageTaskTemplateCache().getForageTemplateByStart(curTask.getStar());
		if (rewardTpl  == null) {
			return ;
		}
		
		//完成任务
		boolean flag = curTask.onFinishTask();
		if (!flag) {
			Loggers.questLogger.error("玩家试图完成一个不可完成的任务！humanId=" + 
					human.getCharId() + ";questId=" + questId);
			return;
		}
	}

	public boolean onFinishTask(Human human) {
		if (!checkHumanTaskAndLevel(human)) {
			return false;
		}
		//任务计数和活力值更新
		doBehavior(human);
		//发消息更新任务
		human.sendMessage(new GCForagetaskUpdate(human.getForageTaskManager().getCurTask().buildQuestInfo()));
		
		ForageTask curTask = human.getForageTaskManager().getCurTask();
		int questId = curTask.getQuestId();
		
		ForageTaskRewardTemplate  rewardTpl = Globals.getTemplateCacheService().getForageTaskTemplateCache().getForageTemplateByStart(curTask.getStar());
		if (rewardTpl  == null) {
			return false;
		}
		
		int leftCount = human.getBehaviorManager().getLeftCount(BehaviorTypeEnum.FORAGE_TASK_NUM);
		int deposit = rewardTpl.getDeposit();
		int failCount = curTask.getBattleFailCount();
		int realMoney = 0;
		if (failCount > 0) {
			realMoney = (int) (rewardTpl.getRewardNum1()*failCount*(double)rewardTpl.getDeductProp1()/Globals.getGameConstants().getGemSynthesisBaseNum());
		}else{
			realMoney = rewardTpl.getRewardNum1();
		}
		
		//额外奖励
		int additionMoney = rewardTpl.getRewardNum2();
		//有一定几率获得奖励银子
		if (RandomUtils.isHit((double)rewardTpl.getRewardProp2()/Globals.getGameConstants().getGemSynthesisBaseNum())) {
			//押金（粮草任务配置的rewardId） + 粮草特殊获得的奖励(这一部分不算在rewardId里面，单独计算)
			
			human.giveMoney(realMoney, Currency.valueOf(rewardTpl.getRewardType1()), false, 
					MoneyLogReason.FORAGETASK_MONEY_REWARD, MoneyLogReason.FORAGETASK_MONEY_REWARD.getReasonText());
			
			human.giveMoney(rewardTpl.getRewardNum2(), Currency.valueOf(rewardTpl.getRewardType2()), 
					false, MoneyLogReason.FORAGETASK_MONEY_REWARD, MoneyLogReason.FORAGETASK_MONEY_REWARD.getReasonText());
			
			
			human.sendErrorMessage(LangConstants.FORAGE_TASK_END_REWARD_YP_AND_YZ,deposit,realMoney,additionMoney,
					leftCount);
		}else{

			//押金（粮草任务配置的rewardId）
			human.giveMoney(realMoney, Currency.valueOf(rewardTpl.getRewardType1()), false, 
					MoneyLogReason.FORAGETASK_MONEY_REWARD, MoneyLogReason.FORAGETASK_MONEY_REWARD.getReasonText());
			
			human.sendErrorMessage(LangConstants.FORAGE_TASK_END_REWARD_YP,deposit,realMoney,leftCount);
			
		}
		
		
		int status = curTask.getStatus().getIndex();
		String backupLog = human.getForageTaskManager().getBackupMap().toString();

		//记录日志
		Globals.getLogService().sendForageTaskLog(human, ForageTaskLogReason.FINISH_TASK, "", 
				backupLog, questId, status);
		
		
		
		//做完任务要刷新一下
		refreshTask(human,"onFinishTask");
		
		boolean canDo = human.getBehaviorManager().canDo(BehaviorTypeEnum.FORAGE_TASK_NUM);
		if (!canDo) {
			//通知客户端，今天的任务次数用光
			human.sendErrorMessage(LangConstants.FORAGE_TASK_MAX_NUM);
		}else{
			//发面板消息
			human.sendMessage(buildGCOpenForagetaskPanel(human));
		}
		return true;
	}
	
	/**
	 * 构造服务器返回面板消息内容
	 * @param human
	 * @return
	 */
	protected GCOpenForagetaskPanel buildGCOpenForagetaskPanel(Human human) {
		int finishTimes = human.getBehaviorManager().getCount(BehaviorTypeEnum.FORAGE_TASK_NUM);
		int totalTimes = human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.FORAGE_TASK_NUM);
		
		GCOpenForagetaskPanel msg = new GCOpenForagetaskPanel();
		msg.setBackupForageTaskInfos(buildBackupTaskInfoList(human).toArray(new BackupForageTaskInfo[0]));
		msg.setFinishTimes(finishTimes);
		msg.setTotalTimes(totalTimes);
		return msg;
	}

	/**
	 * 构造服务器返回面板消息List
	 * @param human
	 * @return
	 */
	protected List<BackupForageTaskInfo> buildBackupTaskInfoList(Human human) {
		List<BackupForageTaskInfo> infoList = new ArrayList<BackupForageTaskInfo>();
		Map<Integer,BackupForageTask> backupMap = human.getForageTaskManager().getBackupMap();
		for (BackupForageTask bft : backupMap.values()) {
			infoList.add(buildBackupForageTaskInfo(human,bft));
		}
		return infoList;
	}

	/**
	 * 构造服务器返回面板消息单元
	 * @param human
	 * @param bft
	 * @return
	 */
	protected BackupForageTaskInfo buildBackupForageTaskInfo(Human human, BackupForageTask bft) {
		BackupForageTaskInfo info = new BackupForageTaskInfo();
		info.setQuestId(bft.getQuestId());
		info.setStar(bft.getStar());
		info.setStatus(bft.getStatus().getOrder());
		
		return info;
	}

	protected void refreshTask(Human human, String source) {
		//如果当前有进行的任务，则先放弃
		giveupTask(human);
		
		//清除当前所有的任务
		human.getForageTaskManager().clearTask();
		
		//重新随机3个任务
		List<ForageTaskTemplate> randList = randTaskList(human.getLevel());
		if (randList == null || randList.isEmpty()
				|| randList.size() < Globals.getGameConstants().getForageTaskCanDoNum()) {
			Loggers.humanLogger.error("#ForageTaskService#refreshTask#ERROR!randList size is "
				+randList.size()+"!humanId"+ human.getCharId());
			return ;
		}
		
		Map<Integer,BackupForageTask> backupMap = Maps.newHashMap();
		for (ForageTaskTemplate tpl : randList) {
			ForageTaskGroupTemplate targetTpl = randTask(tpl.getQuestGroupId());
			BackupForageTask task = new BackupForageTask(targetTpl.getQuestId(), targetTpl.getForageStar(), TaskStatus.CAN_ACCEPT);
			//初始都为可接状态
			backupMap.put(task.getQuestId(), task);
		}
		
		//设置随机出来的备选任务列表
		human.getForageTaskManager().setBackupMap(backupMap);
		human.setModified();
		
		//记录日志
		Globals.getLogService().sendForageTaskLog(human, ForageTaskLogReason.REFRESH_TASK,
				source, backupMap.toString(), 0, 0);
	}

	protected ForageTaskGroupTemplate randTask(int groupId) {
		return RandomUtils.hitObject(Globals.getTemplateCacheService().getForageTaskTemplateCache().getGroupWeightList(groupId), 
				Globals.getTemplateCacheService().getForageTaskTemplateCache().getGroupRandList(groupId), 
				Globals.getTemplateCacheService().getForageTaskTemplateCache().getGroupWeightTotal(groupId));
	}

	protected List<ForageTaskTemplate> randTaskList(int level) {
		List<ForageTaskTemplate> result = null;
		result = RandomUtils.hitObjectsWithWeightNum(
				Globals.getTemplateCacheService().getForageTaskTemplateCache().getLevelWeightList(level), 
				Globals.getTemplateCacheService().getForageTaskTemplateCache().getLevelRandList(level), 
				Globals.getGameConstants().getForageTaskCanDoNum());
		return result;
	}

	public void giveupTask(Human human) {
		if (!checkHumanTaskAndLevel(human)) {
			return ;
		}
		//有任务执行才可放弃
		if (!human.getForageTaskManager().isDoing()) {
			return ;
		}
		
		//任务管理器的判断
		ForageTask curTask = human.getForageTaskManager().getCurTask();
		if (!curTask.canGiveUpTask()) {
			return ;
		}
		
		//记录日志
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		String backupLog = human.getForageTaskManager().getBackupMap().toString();
		curTask.onGiveUpTask();
		Globals.getLogService().sendForageTaskLog(human, ForageTaskLogReason.GIVEUP_TASK,
				human.getForageTaskManager().getBackupMap().toString(), backupLog, questId, status);
		
	}

	protected void doBehavior(Human human) {
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.FORAGE_TASK_NUM);
	}

	public boolean onGiveupTask(Human human) {
		if (!checkHumanTaskAndLevel(human)) {
			return false;
		}
		
		ForageTask curTask = human.getForageTaskManager().getCurTask();
		if (curTask == null) {
			return false;
		}
		
		//更新对应的备选任务的状态
		BackupForageTask bft = human.getForageTaskManager().getBackupForageTask(curTask.getQuestId());
		if (bft == null) {
			Loggers.humanLogger.error("#ForageTaskService#onGiveupTask#ERROR!BackupForageTask is null!humanId=" + human.getCharId());
			return false;
		}
		bft.setStatus(curTask.getStatus());
		
		//发送消息更新任务
		human.sendMessage(new GCForagetaskUpdate(curTask.buildQuestInfo()));
		
		human.getForageTaskManager().clearCurTask();
		human.setModified();
		
		return true;
	}

	public void openForageTaskPanel(Human human) {
		if (!checkHumanTaskAndLevel(human)) {
			return ;
		}
		
		//是否可做
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.FORAGE_TASK_NUM);
		if (!bFlag) {
			//通知客户端，今天的任务做完了
			human.sendMessage(new GCForagetaskDone());
			return ;
		}
		
		//刷新备选任务
		refreshTaskAuto(human);
		
		//发面板消息
		human.sendMessage(buildGCOpenForagetaskPanel(human));
	}

	public void refreshTaskAuto(Human human) {
		if (!canRefreshTaskAuto(human)) {
			return ;
		}
		
		refreshTask(human, "refreshTaskAuto");
	}

	protected boolean canRefreshTaskAuto(Human human) {
		if (!checkHumanTaskAndLevel(human)) {
			return false;
		}
		//有正在进行的任务，则不刷新
		if (human.getForageTaskManager().isDoing()) {
			return false;
		}
		
		//如果玩家从没做过运粮任务，已经有备选数据了，就不能再刷新了，因为这时候还没有behavior记录，所以behavior返回的一直是可以刷新
		if (!human.getBehaviorManager().hasBehaviorRecord(BehaviorTypeEnum.PUB_TASK_NUM)) {
			if (!human.getForageTaskManager().getBackupMap().isEmpty()) {
				return false;
			}
		}
		
		//当天能否刷新
		boolean flag = human.getBehaviorManager().isCanRefreshBehavior(BehaviorTypeEnum.FORAGE_TASK_NUM);
		if (flag) {
			return true;
		}
		
		return false;
	}

	public void acceptTask(Human human, int questId) {
		if (!checkHumanTaskAndLevel(human) || questId <= 0) {
			return ;
		}
		
		//是否可做
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.FORAGE_TASK_NUM);
		if (!bFlag) {
			human.sendErrorMessage(LangConstants.FORAGE_TASK_MAX_NUM);
			return ;
		}
		
		//任务状态是否正确
		BackupForageTask bft = human.getForageTaskManager().getBackupForageTask(questId);
		if (bft == null || bft.getStatus() != TaskStatus.CAN_ACCEPT) {
			Loggers.humanLogger.warn("#ForageTaskService#acceptTask#BackupForageTask is invalid!humanId=" + human.getCharId());
			return ;
		}
		
		//任务id是否正常
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(bft.getQuestId(), QuestTemplate.class);
		if (questTpl == null) {
			Loggers.humanLogger.error("#ForageTaskService#acceptTask#ERROR!quest not exist!humanId=" + human.getCharId());
			return ;
		}
		
		ForageTaskRewardTemplate  rewardTpl = Globals.getTemplateCacheService().getForageTaskTemplateCache().getForageTemplateByStart(bft.getStar());
		if (rewardTpl  == null) {
			return ;
		}
		int ypCount = rewardTpl.getDeposit();
		Currency ypCurrency = Currency.GOLD;
		
		//里面会判断银子
		boolean ypFlag = human.hasEnoughMoney(ypCount, ypCurrency, false);
		if (ypFlag) {
			//优先银票
			boolean isYPCost = human.costMoney(ypCount, ypCurrency, false, 0, 
							MoneyLogReason.FORAGETASK_REFRESH_COST, MoneyLogReason.FORAGETASK_REFRESH_COST.getReasonText(), 0);
			if (!isYPCost) {
				return ;
			}
			
			human.sendErrorMessage(LangConstants.FORAGE_TASK_ACTION_WITH_YP,ypCount);
		}else{
			human.sendErrorMessage(LangConstants.FORAGE_TASK_DEPOSIT_NOT_ENOUGH);
			return ;
			
		}
		
		//构建任务
		ForageTask task = buildInitTask(human,questTpl,bft.getStar());
		task.onAcceptTask();
		
	}
	
	protected ForageTask buildInitTask(Human human, QuestTemplate questTpl, int star) {
		long now = Globals.getTimeService().now();
		//构建任务数据
		ForageTask task = new ForageTask(human, questTpl);
		
		task.setId(KeyUtil.UUIDKey());
		task.setStartTime(now);
		task.setLastUpdateTime(now);
		task.setStar(star);
		task.setBattleFailCount(0);
		task.active();
		task.setModified();
		return task;
	}


	public void refreshTaskManual(Human human) {
		if (!checkHumanTaskAndLevel(human)) {
			return ;
		}
		
		//当前任务是否进行中
		if (human.getForageTaskManager().isDoing()) {
			return ;
		}
		
		
		//是否还有做护送粮草任务的次数，如果没有，则不能刷新
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.FORAGE_TASK_NUM);
		if (!bFlag) {
			return ;
		}
		
		//粮草令校验
		int itemId = Globals.getGameConstants().getForageTaskRefreshManulItemId();
		int count = Globals.getGameConstants().getForageTaskRefreshManulItemNum();
		
		boolean itemFlag = human.getInventory().hasItemByTmplId(itemId, count);
		if (!itemFlag) {
			human.sendErrorMessage(LangConstants.FORAGE_TASK_REFRESH_FAILED);
			return ;
		}
		//扣除粮草令
		Collection<Item> baseList =  human.getInventory().removeItem(itemId, count,
				LogReasons.ItemLogReason.FORAGETASK_REFRESH_COST, LogUtils.genReasonText(LogReasons.ItemLogReason.FORAGETASK_REFRESH_COST));
		if(baseList==null||baseList.size()<=0){
			return ;
		}
		
		//刷新任务
		refreshTask(human, "refreshTaskManual");
		
		//发面板消息
		human.sendMessage(buildGCOpenForagetaskPanel(human));
	}

	public boolean canAcceptTask(Human human, int questId) {
		if (!checkHumanTaskAndLevel(human) || questId <= 0) {
			return false;
		}
		//当前任务是否进行中
		if (human.getForageTaskManager().isDoing()) {
			return false;
		}
		
		//行为是否可做
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.FORAGE_TASK_NUM);
		if (!bFlag) {
			return false;
		}
		
		//检查备选任务列表中是否有可接任务
		Map<Integer, BackupForageTask> backupMap = human.getForageTaskManager().getBackupMap();
		for (BackupForageTask task : backupMap.values()) {
			if (task.getStatus() == TaskStatus.CAN_ACCEPT) {
				return true;
			}
		}
		return false;
	}

	/**
	 * 功能开启时，初始化数据
	 * @param human
	 * @param funcType
	 */
	public void onOpenFunc(Human human, FuncTypeEnum funcType) {
		if (funcType != FuncTypeEnum.FORAGE) {
			return ;
		}
		
		human.snapChangedProperty(true);
		
		//功能开启后，刷任务
		refreshTask(human, "onOpenFunc");
	}

	/**
	 * GM命令刷新护送粮草任务
	 * @param human
	 */
	public void gmRefreshTask(Human human) {
		refreshTask(human, "gmRefreshTask");
		//清除behavior的次数
		human.getBehaviorManager().gmClear(BehaviorTypeEnum.FORAGE_TASK_NUM);
	}

	public void sendCurForageTaskMsg(Human human) {
		if (!checkHumanTaskAndLevel(human)) {
			return ;
		}
		//是否有正在进行的任务
		if (!human.getForageTaskManager().isDoing()) {
			return ;
		}
		
		ForageTask curTask = human.getForageTaskManager().getCurTask();
		//给前台发消息，更新进行中的任务
		human.sendMessage(new GCForagetaskUpdate(curTask.buildQuestInfo()));
	}

	/**
	 *如果银票不足,但银票+银子=50000押金
	 * @param human
	 */
	public void depositWithOtherCurrency(Human human) {
		//TODO 
	}

	public void addBattleFailCount(Human human) {
		if (!checkHumanTaskAndLevel(human)) {
			return ;
		}
		ForageTask curTask = human.getForageTaskManager().getCurTask();
		curTask.addBattleFailCount();
		//更新数据库
		curTask.setModified();
		
		//任务id是否正常
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(curTask.getQuestId(), QuestTemplate.class);
		if (questTpl == null) {
			Loggers.humanLogger.error("#ForageTaskService#addBattleFailCount#ERROR!quest not exist!humanId=" + human.getCharId());
			return ;
		}
		
		ForageTaskRewardTemplate  rewardTpl = Globals.getTemplateCacheService().getForageTaskTemplateCache().getForageTemplateByStart(curTask.getStar());
		if (rewardTpl  == null) {
			return ;
		}
		human.sendErrorMessage(LangConstants.FORAGE_TASK_BATTLE_FAIL,rewardTpl.getDeductProp1()/10);
		
	}

	public void notifyForageInfoChanged(Human human, boolean isAttackerWin) {
		if (!checkHumanTaskAndLevel(human)) {
			return ;
		}
		
		ForageTask curTask = human.getForageTaskManager().getCurTask();
		if (curTask == null) {
			return ;
		}
		
		if (curTask.getQuestType()==QuestType.FORAGE) {
			//护送粮草任务成功
			if (isAttackerWin) {
				human.sendErrorMessage(LangConstants.FORAGE_TASK_BATTLE_WIN);
			}else{
				//护送粮草战斗失败增加次数,总共5次,最后统一计算
				if (curTask.getBattleFailCount() < 
						Globals.getGameConstants().getForageTaskBattleFailMaxNum()) {
					addBattleFailCount(human);
					Loggers.forageTaskLogger.info("#ForageTaskService#notifyForageInfoChanged#BattleFailCount is "
							+curTask.getBattleFailCount());
				}
			}
		}
	}
	
	
}
