package com.imop.lj.gameserver.task;

import java.awt.Point;
import java.util.ArrayList;
import java.util.EnumMap;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.quest.QuestInfo;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.offlinereward.OfflineRewardDef.OfflineRewardType;
import com.imop.lj.gameserver.pet.PetDef.JobType;
import com.imop.lj.gameserver.pet.PetDef.Sex;
import com.imop.lj.gameserver.quest.msg.GCAcceptQuest;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.task.TaskDef.DestType;
import com.imop.lj.gameserver.task.TaskDef.QuestType;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.dest.IQuestDestination;
import com.imop.lj.gameserver.task.template.QuestTemplate;

public abstract class AbstractTask<T extends ITaskOwner> {
	/** 任务唯一id */
	protected String id;
	
	/** 任务所属的拥有者 */
	protected T owner;
	
	/** 任务模板 */
	protected QuestTemplate template;
	/** 任务计数Map<目标类型，Map<计数key，计数对象>> */
	protected EnumMap<DestType, Map<Object, DestCounter>> recordMap;
	/** 任务状态 */
	protected TaskStatus status;
	
	/** 任务开始时间 */
	protected long startTime;
	/** 任务最后更新时间 */
	protected long lastUpdateTime;
	
	public AbstractTask() {
		
	}
	
	public AbstractTask(T owner, QuestTemplate template) {
		this.owner = owner;
		this.template = template;
		init();
	}

	protected void init() {
		// 设置任务为初始状态
		setStatus(TaskStatus.INIT);
		
		// 设置任务计数属性
		recordMap = new EnumMap<DestType, Map<Object, DestCounter>>(DestType.class);
		List<IQuestDestination> dests = template.getQuestDestList();
		if (dests != null) {
			for (IQuestDestination dest : dests) {
				genTypeMap(dest.getDestType(), dest.getInstKey(), dest.getRequiredNum(), dest);
			}
		}
	}
	
	protected void genTypeMap(DestType type, Object instKey, int reqNum, IQuestDestination dest) {
		Map<Object, DestCounter> typeMap = recordMap.get(type);
		if (null == typeMap) {
			typeMap = new HashMap<Object, DestCounter>();
			recordMap.put(type, typeMap);
		}
		typeMap.put(instKey, new DestCounter(dest, reqNum));
	}
	
	protected void recordMapFromJsonStr(String jsonStr) {
		// 已完成个数转换
		List<Map<String, Object>> list = JsonUtils.jsonToList(jsonStr);
		for (Map<String, Object> map : list) {
			int index = Integer.valueOf(map.get(TaskDef.TYPE_KEY).toString());
			DestType type = DestType.valueOf(index);
			int gotNum = Integer.valueOf(map.get(TaskDef.GOT_NUM_KEY).toString());
			Object instKey = map.get(TaskDef.INST_KEY);
			if (type != null) {
				Map<Object, DestCounter> typeMap = recordMap.get(type);
				if (typeMap != null) {
					DestCounter dest = typeMap.get(instKey);
					if (dest != null) {
						dest.setGotNum(gotNum);
					}
				}
			}
		}
	}
	
	public String recordMapToJsonStr() {
		List<Map<String, Object>> list = new ArrayList<Map<String, Object>>();
		Iterator<Map.Entry<DestType, Map<Object, DestCounter>>> iter = recordMap.entrySet().iterator();
		while (iter.hasNext()) {
			Map.Entry<DestType, Map<Object, DestCounter>> entry = iter
					.next();
			int type = entry.getKey().getType();

			Iterator<Map.Entry<Object, DestCounter>> destIter = entry
					.getValue().entrySet().iterator();
			while (destIter.hasNext()) {
				Map.Entry<Object, DestCounter> destEntry = destIter.next();
				Map<String, Object> map = new HashMap<String, Object>();
				map.put(TaskDef.TYPE_KEY, type);
				map.put(TaskDef.INST_KEY, destEntry.getKey());
				map.put(TaskDef.GOT_NUM_KEY, destEntry.getValue().getGotNum());
				list.add(map);
			}
		}
		return JsonUtils.listToJson(list);
	}
	
	public void reset(QuestTemplate tpl) {
		if (null != tpl) {
			this.template = tpl;
			init();
		}
	}
	
	public String getId() {
		return id;
	}
	
	public void setId(String id) {
		this.id = id;
	}
	
	public TaskStatus getStatus() {
		return status;
	}

	public void setStatus(TaskStatus status) {
		this.status = status;
	}

	public T getOwner() {
		return owner;
	}
	
	public Human getOwnerHuman() {
		if (owner instanceof Human) {
			return (Human)owner;
		}
		return null;
	}
	
	public QuestTemplate getTemplate() {
		return template;
	}
	
	public long getStartTime() {
		return startTime;
	}

	public void setStartTime(long startTime) {
		this.startTime = startTime;
	}

	public long getLastUpdateTime() {
		return lastUpdateTime;
	}

	public void setLastUpdateTime(long lastUpdateTime) {
		this.lastUpdateTime = lastUpdateTime;
	}
	
	/**
	 * 获取任务类型
	 * @return
	 */
	public QuestType getQuestType() {
		int questType = template.getQuestType();
		return QuestType.indexOf(questType);
	}

	/**
	 * 得到一个给定类型，和实例key的任务目标的已完成数
	 * 
	 * @param type
	 * @param instKey
	 * @return
	 */
	public int getCount(DestType type, Object instKey) {
		if (!recordMap.containsKey(type)) {
			return 0;
		}
		Map<Object, DestCounter> typeMap = recordMap.get(type);

		if (!typeMap.containsKey(instKey)) {
			return 0;
		}
		return typeMap.get(instKey).getGotNum();
	}
	
	/**
	 * 为一个目标实例的计数加1
	 * 
	 * @param destType
	 *            任务目标的类型
	 * @param instKey
	 *            任务目标实例的key
	 * @return 如果成功更新了一个目标返回true,否则返回false
	 */
	public boolean increaseOne(DestType destType, Object instKey) {
		boolean updateFlag = false;
		
		// 增加type类型的instKey指定的目标的完成数量
		Map<Object, DestCounter> countMap = null;
		if (recordMap.containsKey(destType)) {
			countMap = recordMap.get(destType);
		} else {
			// 不存在这种类型的目标
			return updateFlag;
		}

		if (!countMap.containsKey(instKey)) {
			return updateFlag;
		}
		// 已经完成了该任务
		if (hasFinished()) {
			return updateFlag;
		}
		
		DestCounter ct = countMap.get(instKey);
		int oldGotNum = ct.getGotNum();
		//不可回退的任务
		if (!ct.canStatusBack()) {
			//不可回退的任务，状态为可完成，则不用再走后边了
			if (canFinishTask()) {
				return updateFlag;
			}
			// 更新计数
			if (ct.getGotNum() < ct.getReqNum()) {
				ct.setGotNum(ct.getGotNum() + 1);
				updateFlag = true;
			}
		}
		
		TaskStatus oldStatus = getStatus();
		if (isReachAllDest()) {
			// 任务目标当前为可完成状态
			onTaskCanFinish();
		} else {
			//可回退类型的任务，则回退状态，由可完成，变为已接受
			if (ct.canStatusBack() && 
					oldStatus == TaskStatus.CAN_FINISH) {
				//回退任务状态为已接受
				updateStatus(TaskStatus.ACCEPTED);
			}
		}
		TaskStatus newStatus = getStatus();
		//计数有变化或状态有变化，则需要更新
		if (oldGotNum != ct.getGotNum()
				|| oldStatus != newStatus) {
			updateFlag = true;
		}

		//任务如果在前面完成了，则前面就会发消息通知客户端，所以这里就不再发了
		if (updateFlag && 
				newStatus != TaskStatus.FINISHED) {
			onUpdateRecordMap();
		}
		return updateFlag;
	}
	
	/**
	 * 检查任务是否达到了完成条件，将所有条件都再判断一遍
	 * @return
	 */
	public boolean isReachAllDest() {
		boolean flag = false;
		List<IQuestDestination> dests = getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			flag = false;
			DestType destType = dest.getDestType();
			Object instKey = dest.getInstKey();
			if (recordMap.get(destType) != null) {
				DestCounter destCounter = recordMap.get(destType).get(instKey);
				if (destCounter != null) {
					flag = destCounter.getDest().evaluate(this);
					
					//可回退类型的，直接获取gotNum并重置
					if (destCounter.canStatusBack()) {
						destCounter.setGotNum(destCounter.getDestGotNum(this));
					}
				}
			}
			if (!flag) {
				break;
			}
		}
		return flag;
	}
	
	public boolean hasFinished() {
		return status == TaskStatus.FINISHED;
	}
	
	public final void updateStatus(TaskStatus taskStatus) {
		setStatus(taskStatus);
		updateStatusImpl(taskStatus);
	}
	
	public abstract void updateStatusImpl(TaskStatus taskStatus);
	
	protected abstract void onUpdateRecordMap();
	
	protected void onTaskCanFinish() {
		// 任务状态是否合法
		if (!isTaskValid()) {
			return;
		}
		// 已接受状态才能变为可完成，其他状态不能变到可完成
		if (getStatus() != TaskStatus.ACCEPTED) {
			return;
		}
		
		// 更新任务状态，变为可完成
		updateStatus(TaskStatus.CAN_FINISH);
		
		//检查是否自动完成任务
		if (getTemplate().isAutoFinish()) {
			onFinishTask();
		}
	}
	
	public boolean canAcceptTask() {
		// 任务状态是否合法
		if (!isTaskValid()) {
			return false;
		}
		// 如果任务已经有合法的状态，则不能再接
		if (getStatus() == TaskStatus.CAN_FINISH || 
				getStatus() == TaskStatus.FINISHED || 
				getStatus() == TaskStatus.ACCEPTED) {
			return false;
		}
		
		//如果任务不是自动接的，查看接受任务者是否在改任务的npc附近，如果不在则不能接
		QuestTemplate questTemplate= getTemplate();
		if (questTemplate != null && !getTemplate().isAutoAccept()) {
			//目前只检测玩家身上的任务，组队的暂时不检测
			if (getOwnerHuman() != null && questTemplate.getStartNpc() >0) {
				Point point = Globals.getTemplateCacheService().getMapTemplateCache().getNpcPoint(
						questTemplate.getStartNpcMapId(), questTemplate.getStartNpc());
				if (!Globals.getMapService().isInArea(getOwnerHuman(), 
						questTemplate.getStartNpcMapId(), point.x, point.y)) {
					return false;
				}
			}
		}
		
		return true;
	}
	
	public boolean canFinishTask() {
		// 任务状态是否合法
		if (!isTaskValid()) {
			return false;
		}
		// 任务当前是否为可完成状态，如果不是，则不能完成
		if (getStatus() != TaskStatus.CAN_FINISH) {
			return false;
		}
		
		return true;
	}
	
	protected final boolean onAcceptTask(boolean noticeClient) {
		// 任务状态是否合法
		if (!canAcceptTask()) {
			return false;
		}
		
		// 初始化
		List<IQuestDestination> dests = getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			boolean dFlag = dest.init(this);
			if (!dFlag) {
				//初始化如果失败，则不能接受任务
				return false;
			}
		}
		
		// 更新任务状态为已接受
		updateStatus(TaskStatus.ACCEPTED);
		
		if (getOwnerHuman() != null) {
			//通知客户端接受了任务
			if (noticeClient) {
				getOwnerHuman().sendMessage(new GCAcceptQuest(getQuestId()));
			}
			//汇报热云
			Globals.getReyunService().reportQuest(getOwnerHuman().getPlayer(), this);
		}
		
		// 检查任务是否可完成，如果是，则更新任务状态
		if (isReachAllDest()) {
			onTaskCanFinish();
		}
		
		boolean flag = onAcceptTaskImpl();
		return flag;
	}
	
	public final boolean onAcceptTask() {
		return onAcceptTask(true);
	}
	
	public final boolean onAcceptTaskNotNotice() {
		return onAcceptTask(false);
	}
	
	public boolean onAcceptTaskImpl() {
		return true;
	}

	/**
	 * 检测玩家是否在结束任务的npc附近（非自动完成任务）
	 * @return
	 */
	public boolean checkEndNpc() {
		boolean flag = true;
		//如果任务不是自动完成的，查看接受任务者是否在改任务的npc附近，如果不在则不能接
		QuestTemplate questTemplate= getTemplate();
		if (questTemplate != null && !questTemplate.isAutoFinish()) {
			//XXX 目前只检测玩家身上的任务，组队的暂时不检测
			if (getOwnerHuman() != null && questTemplate.getEndNpc() > 0) {
				Point point = Globals.getTemplateCacheService().getMapTemplateCache().getNpcPoint(
						questTemplate.getEndNpcMapId(), questTemplate.getEndNpc());
				if (!Globals.getMapService().isInArea(getOwnerHuman(), 
						questTemplate.getEndNpcMapId(), point.x, point.y)) {
					flag = false;
				}
			}
		}
		return flag;
	}
	
	/**
	 * XXX 注意：可能返回false，外层需要做判断 
	 * @return
	 */
	public final boolean onFinishTask() {
		//任务是否可完成
		if (!canFinishTask()) {
			return false;
		}
		
		if (!checkEndNpc()) {
			Loggers.questLogger.error("human not in end npc area!questId=" + getQuestId());
			return false;
		}
		
		//完成任务时需要进行一些额外操作
		boolean dFlag = onFinishTaskAddition();
		if (!dFlag) {
			//如果完成任务进行的额外操作失败，则无法完成
			return false;
		}
		
		// 更新任务状态为已完成
		updateStatus(TaskStatus.FINISHED);
		
		// 给任务奖励
		giveTaskReward();
		
		//汇报热云
		if (getOwnerHuman() != null) {
			Globals.getReyunService().reportQuest(getOwnerHuman().getPlayer(), this);
			//汇报dataEye
			Globals.getDataEyeService().finishTaskLog(getOwnerHuman(), this);
		}
				
		return onFinishTaskImpl();
	}
	
	/**
	 * 完成任务时需要进行一些额外操作
	 */
	protected boolean onFinishTaskAddition() {
		boolean flag = true;
		List<IQuestDestination> dests = getTemplate().getQuestDestList();
		for (IQuestDestination dest : dests) {
			flag &= dest.onFinishTask(this);
		}
		return flag;
	}
	
	protected void giveTaskReward() {
		//默认只处理owner是human的奖励，其他类型的任务，自己处理
		if (getOwnerHuman() != null) {
			//1.基本奖励
			giveBaseReward(getOwnerHuman().getCharId());
			//2.条件奖励 
			giveConditionReward(getOwnerHuman().getCharId());
		}
	}

	protected void giveBaseReward(long roleId) {
		Reward baseReward = Globals.getRewardService().createReward(roleId, getTemplate().getRewardId(), 
				"taskId = " + getQuestId());
		
		boolean giveRewardFlag = false;
		//玩家在线，直接给奖励
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
			giveRewardFlag = Globals.getRewardService().giveReward(human, baseReward, true);
		} else {
			//玩家离线，给离线奖励
			giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId, OfflineRewardType.TASK, baseReward, "");
		}
		
		if (!giveRewardFlag) {
			// 给奖励失败，记录错误日志
			Loggers.questLogger.error("#AbstractTask#onFinishTask#ERROR!giveBaseReward failed!humanId=" + 
					roleId + ";rewardId=" + getTemplate().getRewardId());
		}
	}

	protected void giveConditionReward(long roleId) {
		//条件属于互斥条件 故直接读取下标
		boolean giveRewardFlag;
		if (getTemplate().hasConditionReward()) {
			Sex s = null;
			JobType j = null;
			Human human = null;
			if (Globals.getTeamService().isPlayerOnline(roleId)) {
				human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
				s = human.getSex();
				j = human.getJobType();
			} else {
				UserSnap us = Globals.getOfflineDataService().getUserSnap(roleId);
				s = us.getHumanSex();
				j = us.getHumanJobType();
			}
			
			int index = calculateArrayIndex(s, j);
			if(index>=0 && index<getTemplate().getRewardIdOnCondition().size()){
				Integer rewardId = getTemplate().getRewardIdOnCondition().get(index);
				Reward condReward = Globals.getRewardService().createReward(roleId, rewardId, "taskId=" + getQuestId());
				if (human != null) {
					giveRewardFlag = Globals.getRewardService().giveReward(human, condReward, true);
				} else {
					//玩家离线，给离线奖励
					giveRewardFlag = Globals.getOfflineRewardService().sendOfflineReward(roleId, OfflineRewardType.TASK, condReward, "");
				}
				
				if (!giveRewardFlag) {
					// 给奖励失败，记录错误日志
					Loggers.questLogger.error("#AbstractTask#onFinishTask#ERROR!giveConditionReward failed!humanId=" + 
							roleId + ";rewardId=" + rewardId);
				}
			}else{
				// 条件奖励查询失败，记录错误日志
				Loggers.questLogger.error("#AbstractTask#onFinishTask#ERROR!conditionReward search failed!humanId=" + 
						roleId + ";TaskId=" + getTemplate().getId());
			}
		}
	}
	
	//通过计算来确定目标在数组的位置
	private static Integer calculateArrayIndex(Sex sex, JobType jobType){
		int num_1 = 0,num_2 = 0,len = 4;
		//性别判断 jobType.len*(n-1)
		switch(sex){
		case FEMALE: num_1 = 1;break;
		case MALE: num_1 = 2;break;
		}
		//职业判断
		switch(jobType){
			case XIAKE: num_2 = 1;break;
			case CIKE: num_2 = 2;break;
			case SHUSHI: num_2 = 3;break;
			case XIUZHEN: num_2 = 4;break;
		}
		//jobType.len*(n-1)
		return len*(num_1-1)+num_2-1;
	}
	
	protected boolean onFinishTaskImpl() {
		return true;
	}
	
	public boolean canGiveUpTask() {
		//已接受或可完成的任务才能放弃，未接的或已完成的已放弃的都不能放弃
		if (getStatus() == TaskStatus.ACCEPTED || 
				getStatus() == TaskStatus.CAN_FINISH) {
			return true;
		}
		return false;
	}
	
	public final boolean onGiveUpTask() {
		if (!canGiveUpTask()) {
			return false;
		}
		
		//更新状态为已放弃
		updateStatus(TaskStatus.GIVEUP);
		
		if (getOwnerHuman() != null) {
			//汇报dataEye
			Globals.getDataEyeService().giveupTaskLog(getOwnerHuman(), this);
		}
		
		return onGiveupTaskImpl();
	}
	
	protected boolean onGiveupTaskImpl() {
		return true;
	}
	
	/**
	 * 是否已放弃
	 * @return
	 */
	public boolean isGiveup() {
		return status == TaskStatus.GIVEUP;
	}
	
	public boolean isDoing() {
		return status == TaskStatus.ACCEPTED || status == TaskStatus.CAN_FINISH;
	}
	
	public boolean isTaskValid() {
		return getStatus() != TaskStatus.INVALID;
	}
	
	public int getQuestId() {
		if (null != template) {
			return template.getId();
		}
		return 0;
	}
	
	public QuestInfo buildQuestInfo() {
		QuestInfo questInfo = new QuestInfo();
		// 设置基础数据
		questInfo.setQuestId(template.getId());
		
		// 设置任务计数
		List<IQuestDestination> dests = template.getQuestDestList();
		for (IQuestDestination iq : dests) {
			int gotNum = getCount(iq.getDestType(), iq.getInstKey());
			// 如果接任务已完成，则设置接任务为完成的数量为所需数量
			if (iq.evaluate(this)) {
				gotNum = iq.getRequiredNum();
			}
			questInfo.setDestGotNum(gotNum);
			questInfo.setDestReqNum(iq.getRequiredNum());
		}
		// 未完成的任务，检查是否可完成，如果是，则更新状态
		if (getStatus() == TaskStatus.ACCEPTED && isReachAllDest()) {
			onTaskCanFinish();
		}
		// 设置任务状态
		questInfo.setQuestStatus(getStatus().getOrder());
//		// 设置奖励，不用设置了，前台自己解析了
//		questInfo.setShowRewardInfo(template.getRewardStr());

		return questInfo;
	}
	
	public static QuestInfo buildNotAcceptQuestInfo(int questId, TaskStatus ts) {
		QuestInfo info = new QuestInfo();
		info.setQuestId(questId);
		info.setQuestStatus(ts.getOrder());
		return info;
	}
	
}
