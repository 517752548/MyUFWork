package com.imop.lj.gameserver.pubtask;

import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.LogReasons.PubExpLogReason;
import com.imop.lj.common.LogReasons.PubTaskLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.BackupPubTaskInfo;
import com.imop.lj.common.model.reward.RewardInfo;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.exp.model.ExpConfigInfo;
import com.imop.lj.gameserver.exp.model.ExpResultInfo;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.pubtask.PubTaskDef.RefreshType;
import com.imop.lj.gameserver.pubtask.msg.GCOpenPubtaskPanel;
import com.imop.lj.gameserver.pubtask.msg.GCPubtaskDone;
import com.imop.lj.gameserver.pubtask.msg.GCPubtaskMaxStar;
import com.imop.lj.gameserver.pubtask.msg.GCPubtaskUpdate;
import com.imop.lj.gameserver.pubtask.template.PubTaskGroupTemplate;
import com.imop.lj.gameserver.pubtask.template.PubTaskTemplate;
import com.imop.lj.gameserver.task.TaskDef;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;

public class PubTaskService {
	
	/**
	 * 增加酒馆经验
	 * @param human
	 * @param addExp
	 * @param reason
	 * @param detailReason
	 * @return
	 */
	public boolean addPubExp(Human human, long addExp, PubExpLogReason reason, String detailReason, boolean needNotify) {
		int level = human.getPubLevel();
		//酒馆没开，等级为0，不加经验
		if (level <= 0) {
			return false;
		}
		long currExp = human.getPubExp();
		int maxLevel = Globals.getGameConstants().getPubMaxLevel();
		
		ExpConfigInfo info = Globals.getTemplateCacheService().getPubTaskTemplateCache().getPubExpConfigInfo();
		ExpResultInfo result = Globals.getExpService().addExp(info, level, currExp, addExp, maxLevel);
		//设置酒馆当前等级和经验
		human.setPubLevel(result.getLevel());
		human.setPubExp(result.getCurrencyExp());
		human.snapChangedProperty(true);
		if (needNotify) {
			//TODO 给前台发消息
			
		}
		// 记日志
		Globals.getLogService().sendPubExpLog(human, reason, "", addExp, human.getPubLevel(), human.getPubExp());
		
		//酒馆升级
		if (result.getLevel() > level) {
			this.noticePubTaskMaxStar(human);
		}
		return true;
	}
	
	/**
	 * 功能开启时，初始化数据
	 * @param human
	 * @param funcType
	 */
	public void onOpenFunc(Human human, FuncTypeEnum funcType) {
		if (funcType != FuncTypeEnum.PUB) {
			return;
		}
		
		human.setPubLevel(Globals.getGameConstants().getPubInitLevel());
		human.setPubExp(0);
		human.snapChangedProperty(true);
		
		//功能开启后，刷任务
		refreshTask(human, "onOpenFunc", RefreshType.NORMAL.getIndex());
		
		//功能开启后,通知前端酒馆最大星数
		this.noticePubTaskMaxStar(human);
	}
	
	public void gmRefreshTask(Human human, int refreshType) {
		refreshTask(human, "gmRefreshTask", refreshType);
		//清除behavior的次数
		human.getBehaviorManager().gmClear(BehaviorTypeEnum.PUB_TASK_NUM);
	}

	public boolean canRefreshTaskAuto(Human human) {
		if (human.getPubTaskManager() == null) {
			return false;
		}
		//有正在进行的任务，则不刷新
		if (human.getPubTaskManager().isDoing()) {
			return false;
		}
		//酒馆等级是否合法
		if (human.getPubLevel() <= 0) {
			return false;
		}
		
		//如果玩家从没做过酒馆任务，已经有备选数据了，就不能再刷新了，因为这时候还没有behavior记录，所以behavior返回的一直是可以刷新
		if (!human.getBehaviorManager().hasBehaviorRecord(BehaviorTypeEnum.PUB_TASK_NUM)) {
			if (!human.getPubTaskManager().getBackupMap().isEmpty()) {
				return false;
			}
		}
		
		//没有正在进行的任务，则看次数能否刷新，如果可以，则任务也能刷新
		boolean flag = human.getBehaviorManager().isCanRefreshBehavior(BehaviorTypeEnum.PUB_TASK_NUM);
		if (flag) {
			return true;
		}
		
		return false;
	}
	
	public void refreshTaskAuto(Human human) {
		if (!canRefreshTaskAuto(human)) {
			return;
		}
		
		refreshTask(human, "refreshTaskAuto", RefreshType.NORMAL.getIndex());
	}
	
	protected void refreshTask(Human human, String source, int refreshType) {
		//如果当前有进行的任务，则先放弃
		giveupTask(human);
		
		//清除当前所有的任务
		human.getPubTaskManager().clearTask();
		
		//重新随机3个任务
		List<PubTaskTemplate> randList = randTaskList(human.getPubLevel(), human.getLevel());
		if (randList == null || randList.isEmpty()) {
			Loggers.humanLogger.error("#PubTaskService#refreshTask#ERROR!randList is null!humanId=" + human.getCharId());
			return;
		}
		
		Map<Integer, BackupPubTask> backupMap = new HashMap<Integer, BackupPubTask>();
		
		for (PubTaskTemplate tpl : randList) {
			PubTaskGroupTemplate targetTpl = null;
			//普通刷新
			if(RefreshType.NORMAL.getIndex() == refreshType){
				targetTpl = randTask(tpl.getQuestGroupId());
			}else if(RefreshType.BOND.getIndex() == refreshType){
				targetTpl = randBondTask(tpl.getQuestGroupId());
			}
			BackupPubTask task = new BackupPubTask(targetTpl.getQuestId(), targetTpl.getQuestStar(), TaskStatus.CAN_ACCEPT);
			//初始都为可接状态
			backupMap.put(task.getQuestId(), task);
		}
		//设置随机出来的任务列表
		human.getPubTaskManager().setBackupMap(backupMap);
		human.setModified();
		
		//记录日志
		Globals.getLogService().sendPubTaskLog(human, PubTaskLogReason.REFRESH_TASK, source, backupMap.toString(), 0, 0);
	}
	
	/**
	 * 登录,酒馆升级,玩家升级,酒馆功能开启的时候
	 * @param human
	 */
	public void noticePubTaskMaxStar(Human human){
		int star = Globals.getTemplateCacheService().getPubTaskTemplateCache().getGroupRandMaxStar(human.getPubLevel(), human.getLevel());
		if(star == 0){
			Loggers.humanLogger.warn("#PubTaskService#refreshTask#ERROR!getGroupRandMaxStar is zero!humanId=" + human.getCharId()
			+ "pubLevel = " + human.getPubLevel()
			+ "playerLevel = " + human.getLevel());
		}
		human.sendMessage(new GCPubtaskMaxStar(star));
	}
	
	protected List<PubTaskTemplate> randTaskList(int pubLevel, int level) {
		List<PubTaskTemplate> result = null;
		result = RandomUtils.hitObjectsWithWeightNum(Globals.getTemplateCacheService().getPubTaskTemplateCache().getLevelWeightList(pubLevel, level),
				Globals.getTemplateCacheService().getPubTaskTemplateCache().getLevelRandList(pubLevel, level), 
				Globals.getGameConstants().getPubTaskRefreshNum());
		return result;
	}
	
	protected PubTaskGroupTemplate randTask(int groupId) {
		return RandomUtils.hitObject(Globals.getTemplateCacheService().getPubTaskTemplateCache().getGroupWeightList(groupId), 
				Globals.getTemplateCacheService().getPubTaskTemplateCache().getGroupRandList(groupId), 
				Globals.getTemplateCacheService().getPubTaskTemplateCache().getGroupWeightTotal(groupId));
	}
	
	protected PubTaskGroupTemplate randBondTask(int groupId) {
		return RandomUtils.hitObject(Globals.getTemplateCacheService().getPubTaskTemplateCache().getBondGroupWeightList(groupId), 
				Globals.getTemplateCacheService().getPubTaskTemplateCache().getBondGroupRandList(groupId), 
				Globals.getTemplateCacheService().getPubTaskTemplateCache().getBondGroupWeightTotal(groupId));
	}
	
	public boolean canAcceptTask(Human human, int questId) {
		if (human.getPubTaskManager() == null) {
			return false;
		}
		//酒馆等级是否合法
		if (human.getPubLevel() <= 0) {
			return false;
		}
		//有正在进行的任务，则不能再接受
		if (human.getPubTaskManager().isDoing()) {
			return false;
		}
		//行为是否可做
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.PUB_TASK_NUM);
		if (!bFlag) {
			return false;
		}
		
		//检查备选任务列表中是否有可接的
		Map<Integer, BackupPubTask> backupMap = human.getPubTaskManager().getBackupMap();
		for (BackupPubTask task : backupMap.values()) {
			if (task.getStatus() == TaskStatus.CAN_ACCEPT) {
				return true;
			}
		}
		return false;
	}
	
	public void sendCurPubTaskMsg(Human human) {
		//给前台发正在进行的任务，可能没有
		if (human == null || human.getPubTaskManager() == null) {
			return;
		}
		//酒馆等级是否合法
		if (human.getPubLevel() <= 0) {
			return;
		}
		//是否有正在进行的任务
		if (!human.getPubTaskManager().isDoing()) {
			return;
		}
		
		PubTask curTask = human.getPubTaskManager().getCurTask();
		//给前台发消息，更新进行中的任务
		human.sendMessage(new GCPubtaskUpdate(curTask.buildQuestInfo()));
	}
	
	/**
	 * 打开酒馆任务面板
	 * @param human
	 */
	public void openPubTaskPanel(Human human) {
		if (human == null || human.getPubTaskManager() == null) {
			return;
		}
		//酒馆等级是否合法
		if (human.getPubLevel() <= 0) {
			return;
		}
		//行为是否可做
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.PUB_TASK_NUM);
		if (!bFlag) {
			//通知客户端，今天的任务已经做完了
			human.sendMessage(new GCPubtaskDone());
			return;
		}
		
//		if (human.getPubTaskManager().isDoing()) {
//			//正在进行任务，不让打开面板了
//			return;
//		}
		
		//有可能需要刷新面板
		refreshTaskAuto(human);
		
		//发面板消息
		human.sendMessage(buildGCOpenPubtaskPanel(human));
	}
	
	public GCOpenPubtaskPanel buildGCOpenPubtaskPanel(Human human) {
		int finishTimes = human.getBehaviorManager().getCount(BehaviorTypeEnum.PUB_TASK_NUM);
		int totalTimes = human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.PUB_TASK_NUM);
		GCOpenPubtaskPanel msg = new GCOpenPubtaskPanel();
		msg.setBackupPubTaskInfos(buildBackupTaskInfoList(human).toArray(new BackupPubTaskInfo[0]));
		msg.setFinishTimes(finishTimes);
		msg.setTotalTimes(totalTimes);
		return msg;
	}
	
	protected BackupPubTaskInfo buildBackupPubTaskInfo(Human human, BackupPubTask bpt) {
		BackupPubTaskInfo info = new BackupPubTaskInfo();
		info.setQuestId(bpt.getQuestId());
		info.setStar(bpt.getStar());
		info.setStatus(bpt.getStatus().getOrder());
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(bpt.getQuestId(), QuestTemplate.class);
		if (questTpl != null) {
			RewardInfo rewardInfo = Globals.getRewardService().createRewardInfo(human.getUUID(), 
					questTpl.getRewardId(), "BackupPubTaskInfo questId=" + questTpl.getId(), null);
			info.setRewardInfo(rewardInfo);
		}
		return info;
	}
	
	protected List<BackupPubTaskInfo> buildBackupTaskInfoList(Human human) {
		List<BackupPubTaskInfo> infoList = new ArrayList<BackupPubTaskInfo>();
		Map<Integer, BackupPubTask> backupMap = human.getPubTaskManager().getBackupMap();
		for (BackupPubTask bpt : backupMap.values()) {
			infoList.add(buildBackupPubTaskInfo(human, bpt));
		}
		return infoList;
	}
	
	/**
	 * 接受任务
	 * @param human
	 * @param questId
	 */
	public void acceptTask(Human human, int questId) {
		if (human == null || human.getPubTaskManager() == null) {
			return;
		}
		//酒馆等级是否合法
		if (human.getPubLevel() <= 0) {
			return;
		}
		//行为是否可做
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.PUB_TASK_NUM);
		if (!bFlag) {
			human.sendErrorMessage(LangConstants.PUB_TASK_MAX_NUM);
			return;
		}
		
		//任务状态是否正确
		BackupPubTask bpt = human.getPubTaskManager().getBackupPubTask(questId);
		if (bpt == null || bpt.getStatus() != TaskStatus.CAN_ACCEPT) {
			Loggers.humanLogger.warn("#PubTaskService#acceptTask#BackupPubTask is invalid!humanId=" + human.getCharId());
			return;
		}
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(bpt.getQuestId(), QuestTemplate.class);
		if (questTpl == null) {
			Loggers.humanLogger.error("#PubTaskService#acceptTask#ERROR!quest not exist!humanId=" + human.getCharId());
			return;
		}
		
		//构建任务
		PubTask pubTask = buildInitTask(human, questTpl, bpt.getStar());
		pubTask.onAcceptTask();
	}
	
	/**
	 * 构建初始的任务数据
	 * @param questTpl
	 * @return
	 */
	protected PubTask buildInitTask(Human human, QuestTemplate questTpl, int star) {
		long now = Globals.getTimeService().now();
		// 构建任务数据
		PubTask task = new PubTask(human, questTpl);
		// 生成Id
		task.setId(KeyUtil.UUIDKey());
		// 设置时间
		task.setStartTime(now);
		task.setLastUpdateTime(now);
		
		//任务星数
		task.setStar(star);
		
		// 激活并存库
		task.active();
		task.setModified();
		return task;
	}
	
	public boolean onAcceptTask(Human human, PubTask task) {
		if (human.getPubTaskManager() == null || task == null) {
			return false;
		}
		//酒馆等级是否合法
		if (human.getPubLevel() <= 0) {
			return false;
		}
		if (human.getPubTaskManager().isDoing()) {
			return false;
		}
		
		//设置当前任务
		human.getPubTaskManager().setCurTask(task);
		//设置备选任务的状态
		BackupPubTask bpt = human.getPubTaskManager().getBackupPubTask(task.getQuestId());
		bpt.setStatus(task.getStatus());
		human.setModified();
		
		//给前台发消息，更新进行中的任务
		human.sendMessage(new GCPubtaskUpdate(task.buildQuestInfo()));
		
		//记录日志
		Globals.getLogService().sendPubTaskLog(human, PubTaskLogReason.ACCEPT_TASK, "", 
				human.getPubTaskManager().getBackupMap().toString(), task.getQuestId(), task.getStatus().getIndex());
		return true;
	}

	/**
	 * 完成酒馆任务
	 * @param human
	 */
	public void finishTask(Human human) {
		if (human.getPubTaskManager() == null) {
			return;
		}
		//酒馆等级是否合法
		if (human.getPubLevel() <= 0) {
			return;
		}
		//当前任务是否进行中
		if (!human.getPubTaskManager().isDoing()) {
			return;
		}
		
		PubTask curTask = human.getPubTaskManager().getCurTask();
		if (!curTask.canFinishTask()) {
			return;
		}
		
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		String backupLog = human.getPubTaskManager().getBackupMap().toString();
		
		//完成任务
		boolean flag = curTask.onFinishTask();
		if (!flag) {
			Loggers.questLogger.error("玩家试图完成一个不可完成的任务！humanId=" + 
					human.getCharId() + ";questId=" + questId);
			return;
		}
		
		//记录日志
		Globals.getLogService().sendPubTaskLog(human, PubTaskLogReason.FINISH_TASK, "", 
				backupLog, questId, status);
	}
	
	public boolean onFinishTask(Human human) {
		if (human.getPubTaskManager() == null) {
			return false;
		}
		//酒馆等级是否合法
		if (human.getPubLevel() <= 0) {
			return false;
		}
		//任务完成计数
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.PUB_TASK_NUM);
		
		//发消息更新任务
		human.sendMessage(new GCPubtaskUpdate(human.getPubTaskManager().getCurTask().buildQuestInfo()));
		
		//刷新任务，不管是否可做，都刷新一下，否则backupTask可能有问题
		refreshTask(human, "onFinishTask", RefreshType.NORMAL.getIndex());
		
		//玩家能否继续做任务，如不可以，则发消息通知
		boolean canDo = human.getBehaviorManager().canDo(BehaviorTypeEnum.PUB_TASK_NUM);
		if (!canDo) {
			//通知客户端，今天的任务已经做完了
			human.sendErrorMessage(LangConstants.PUB_TASK_MAX_NUM);
		} else {
			//发面板消息
			human.sendMessage(buildGCOpenPubtaskPanel(human));
		}
		
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.FINISH_PUB, 0, 1);
		
		return true;
	}

	/**
	 * 放弃任务
	 * @param human
	 */
	public void giveupTask(Human human) {
		if (human.getPubTaskManager() == null) {
			return;
		}
		//酒馆等级是否合法
		if (human.getPubLevel() <= 0) {
			return;
		}
		//当前任务是否进行中
		if (!human.getPubTaskManager().isDoing()) {
			return;
		}
		
		PubTask curTask = human.getPubTaskManager().getCurTask();
		if (!curTask.canGiveUpTask()) {
			return;
		}
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		String backupLog = human.getPubTaskManager().getBackupMap().toString();
		
		curTask.onGiveUpTask();
		
		//记录日志
		Globals.getLogService().sendPubTaskLog(human, PubTaskLogReason.GIVEUP_TASK, 
				human.getPubTaskManager().getBackupMap().toString(), backupLog, questId, status);
	}
	
	public boolean onGiveupTask(Human human) {
		if (human.getPubTaskManager() == null) {
			return false;
		}
		//酒馆等级是否合法
		if (human.getPubLevel() <= 0) {
			return false;
		}
		
		PubTask curTask = human.getPubTaskManager().getCurTask();
		if (curTask == null) {
			return false;
		}
		
		//更新对应的备选任务的状态
		BackupPubTask bpt = human.getPubTaskManager().getBackupPubTask(curTask.getQuestId());
		if (bpt == null) {
			Loggers.humanLogger.error("#PubTaskService#onGiveupTask#ERROR!BackupPubTask is null!humanId=" + human.getCharId());
			return false;
		}
		bpt.setStatus(curTask.getStatus());
		
		//发消息更新任务
		human.sendMessage(new GCPubtaskUpdate(curTask.buildQuestInfo()));
		
		human.getPubTaskManager().clearCurTask();
		human.setModified();
		return true;
	}
	
	/**
	 * 手动刷新酒馆
	 * @param human
	 * @param refreshType
	 */
	public void refreshTaskManual(Human human, int refreshType) {
		if (human.getPubTaskManager() == null || human.getPubLevel() <= 0) {
			return;
		}
		//有正在进行的任务，则不刷新
		if (human.getPubTaskManager().isDoing()) {
			return;
		}
		
		//是否还有做酒馆任务的次数，如果没有，则不能刷新
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.PUB_TASK_NUM);
		if (!bFlag) {
			return;
		}
		
		//需要的道具、钱
		int itemId = Globals.getGameConstants().getPubTaskRefreshManulItemId();
		int count = 1;
		boolean isBond = refreshType == RefreshType.BOND.getIndex() ? true : false;
		
		int costNum = isBond ? Globals.getGameConstants().getPubTaskRefreshManulBond() : 
						Globals.getGameConstants().getPubTaskRefreshManulGold();
		
		Currency costCurrency = isBond ? Currency.valueOf(Globals.getGameConstants().getPubTaskRefreshManulBondTypeId()) : 
								Currency.GOLD;
		
		
		//是否有刷新道具
		boolean itemFlag = human.getInventory().hasItemByTmplId(itemId, count);
		//银票是否足够
		boolean moneyFlag = human.hasEnoughMoney(costNum, costCurrency, false);
		//都不够，则不能刷新
		if (!itemFlag && !moneyFlag) {
			human.sendErrorMessage(LangConstants.PUB_TASK_REFRESH_FAILED, 
					Globals.getLangService().readSysLang(costCurrency.getNameKey()));
			return;
		}
		
		//优先扣道具，不足就扣钱
		if (itemFlag) {
			Collection<Item> ci = human.getInventory().removeItem(itemId, count, 
					ItemLogReason.PUBTASK_REFRESH_COST, ItemLogReason.PUBTASK_REFRESH_COST.getReasonText());
			if (ci == null || ci.isEmpty()) {
				return;
			}
		} else {
			boolean mf = human.costMoney(costNum, costCurrency, false, 0, 
					MoneyLogReason.PUBTASK_REFRESH_COST, MoneyLogReason.PUBTASK_REFRESH_COST.getReasonText(), 0);
			if (!mf) {
				return;
			}
		}
		
		//刷新任务
		refreshTask(human, "refreshTaskManual", refreshType);
		
		//发面板消息
		human.sendMessage(buildGCOpenPubtaskPanel(human));
	}
	
	public void onPlayerLogin(Human human) {
		//发面板消息
		human.sendMessage(buildGCOpenPubtaskPanel(human));
	}
}
