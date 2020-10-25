package com.imop.lj.gameserver.treasuremap;

import java.awt.Point;
import java.util.List;

import com.imop.lj.common.LogReasons.TreasureMapLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.KeyUtil;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.battle.helper.RandomUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.model.AbstractGameMap;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.task.TaskDef;
import com.imop.lj.gameserver.task.TaskDef.TaskStatus;
import com.imop.lj.gameserver.task.template.QuestTemplate;
import com.imop.lj.gameserver.treasuremap.msg.GCOpenTreasuremapPanel;
import com.imop.lj.gameserver.treasuremap.msg.GCTreasuremapUpdate;
import com.imop.lj.gameserver.treasuremap.template.TreasureMapGroupTemplate;
import com.imop.lj.gameserver.treasuremap.template.TreasureMapRewardTemplate;
import com.imop.lj.gameserver.treasuremap.template.TreasureMapTemplate;

public class TreasureMapService {
	 
	/**
	 * 随机藏宝图任务
	 * @param groupId
	 * @return
	 */
	protected TreasureMapGroupTemplate randTask(int groupId) {
			return RandomUtils.hitObject(Globals.getTemplateCacheService().getTreasureMapTemplateCache().getGroupWeightList(groupId), 
					Globals.getTemplateCacheService().getTreasureMapTemplateCache().getGroupRandList(groupId), 
					Globals.getTemplateCacheService().getTreasureMapTemplateCache().getGroupWeightTotal(groupId));
	}
	
	public boolean canAcceptTask(Human human, int questId) {
		if (human.getTreasureMapManager() == null) {
			return false;
		}
		//有正在进行的任务，则不能再接受
		if (human.getTreasureMapManager().isDoing()) {
			return false;
		}
		//任务是否可做
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.TREASURE_MAP_NUM);
		if (!bFlag) {
			return false;
		}
		
		return false;
	}
	
	public void sendCurTreasureMapMsg(Human human) {
		//给前台发正在进行的任务，可能没有
		if (human == null || human.getTreasureMapManager() == null) {
			return;
		}
		
		//发送消息
		human.sendMessage(buildGCOpenTreasuremapPanel(human));
		
		//是否有正在进行的任务
		if (!human.getTreasureMapManager().isDoing()) {
			return;
		}
		
		TreasureMap curTask = human.getTreasureMapManager().getCurTask();
		//给前台发消息，更新进行中的任务
		human.sendMessage(new GCTreasuremapUpdate(curTask.buildQuestInfo()));
	}
	
	
	public GCOpenTreasuremapPanel buildGCOpenTreasuremapPanel(Human human) {
		int finishTimes = human.getBehaviorManager().getCount(BehaviorTypeEnum.TREASURE_MAP_NUM);
		int totalTimes = human.getBehaviorManager().getMaxCount(BehaviorTypeEnum.TREASURE_MAP_NUM);
		
		GCOpenTreasuremapPanel msg = new GCOpenTreasuremapPanel();
		msg.setFinishTimes(finishTimes);
		msg.setTotalTimes(totalTimes);
		return msg;
	}
	
	/**
	 * 接受任务
	 * @param human
	 */
	public void acceptTask(Human human) {
		int questGroupId = 0;  //任务组ID
		TreasureMapGroupTemplate targetTpl = new TreasureMapGroupTemplate();
		if (human == null || human.getTreasureMapManager() == null) {
			return;
		}
		//行为是否可做
		boolean bFlag = human.getBehaviorManager().canDo(BehaviorTypeEnum.TREASURE_MAP_NUM);
		if (!bFlag) {
			human.sendErrorMessage(LangConstants.TREASURE_MAP_MAX_NUM);
			return;
		}
		
		//任务状态是否正确
		for (TreasureMapTemplate tpl : Globals.getTemplateCacheService().getAll(TreasureMapTemplate.class).values()){
			int minLevel = tpl.getLevelMin();
			int maxLevel = tpl.getLevelMax();
			if(human.getLevel() <= maxLevel && human.getLevel() >= minLevel){
				questGroupId = tpl.getQuestGroupId();
			}
		}
		
		TreasureMap bpt = human.getTreasureMapManager().getCurTask();
		if (bpt == null || bpt.getStatus() != TaskStatus.CAN_ACCEPT) {
			targetTpl = randTask(questGroupId);
		}
		
		QuestTemplate questTpl = Globals.getTemplateCacheService().get(targetTpl.getQuestId(), QuestTemplate.class);
		if (questTpl == null) {
			Loggers.humanLogger.error("#TreasureMapService#acceptTask#ERROR!quest not exist!humanId=" + human.getCharId());
			return;
		}
		
		//构建任务
		TreasureMap treasureMap = buildInitTask(human, questTpl);
		treasureMap.onAcceptTask();
	}
	
	/**
	 * 构建初始的任务数据
	 * @param human
	 * @param questTpl
	 * @return
	 */
	protected TreasureMap buildInitTask(Human human, QuestTemplate questTpl) {
		long now = Globals.getTimeService().now();
		// 构建任务数据
		TreasureMap task = new TreasureMap(human, questTpl);
		// 生成Id
		task.setId(KeyUtil.UUIDKey());
		// 设置时间
		task.setStartTime(now);
		task.setLastUpdateTime(now);
		
		// 激活并存库
		task.active();
		task.setModified();
		return task;
	}
	
	public boolean onAcceptTask(Human human, TreasureMap task) {
		if (human.getTreasureMapManager() == null || task == null) {
			return false;
		}
		if (human.getTreasureMapManager().isDoing()) {
			return false;
		}
		
		//设置当前任务
		human.getTreasureMapManager().setCurTask(task);
		human.setModified();
		
		//给前台发消息，更新进行中的任务
		human.sendMessage(new GCTreasuremapUpdate(task.buildQuestInfo()));
		
		//记录日志
		Globals.getLogService().sendTreasureMapLog(human, TreasureMapLogReason.ACCEPT_TASK, "", task.getQuestId(), task.getStatus().getIndex());
		return true;
	}

	/**
	 * 完成藏宝图任务
	 * @param human
	 */
	public void finishTask(Human human) {
		if (human.getTreasureMapManager() == null) {
			return;
		}
		//当前任务是否进行中
		if (!human.getTreasureMapManager().isDoing()) {
			return;
		}
		
		TreasureMap curTask = human.getTreasureMapManager().getCurTask();
		if (!curTask.canFinishTask()) {
			return;
		}
		
		//完成任务
		boolean flag = curTask.onFinishTask();
		if (!flag) {
			Loggers.questLogger.error("玩家试图完成一个不可完成的任务！humanId=" + 
					human.getCharId() + ";questId=" + curTask.getQuestId());
			return;
		}
	}
	
	public boolean onFinishTask(Human human) {
		if (human.getTreasureMapManager() == null) {
			return false;
		}
		//任务完成计数
		doBehavior(human);
		
		TreasureMap curTask = human.getTreasureMapManager().getCurTask();
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		
		human.sendMessage(buildGCOpenTreasuremapPanel(human));
		human.sendMessage(new GCTreasuremapUpdate(curTask.buildQuestInfo()));
		
		//玩家能否继续做任务，如不可以，则发消息通知
		boolean canDo = human.getBehaviorManager().canDo(BehaviorTypeEnum.TREASURE_MAP_NUM);
		if (!canDo) {
			//通知客户端，今天的任务已经做完了
			human.sendErrorMessage(LangConstants.TREASURE_MAP_MAX_NUM);
		} else {
			//自动接下一个任务
			Globals.getTreasureMapService().acceptTask(human);
		}
		
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.FINISH_TREASURE_MAP, 0, 1);
		
		
		//记录日志
		Globals.getLogService().sendTreasureMapLog(human, TreasureMapLogReason.FINISH_TASK, "", questId, status);
		return true;
	}

	protected void doBehavior(Human human) {
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.TREASURE_MAP_NUM);
	}
	
	/**
	 * 放弃任务
	 * @param human
	 */
	public void giveupTask(Human human) {
		if (human.getTreasureMapManager() == null) {
			return;
		}
		//当前任务是否进行中
		if (!human.getTreasureMapManager().isDoing()) {
			return;
		}
		
		TreasureMap curTask = human.getTreasureMapManager().getCurTask();
		if (!curTask.canGiveUpTask()) {
			return;
		}
		
		curTask.onGiveUpTask();
		
		int questId = curTask.getQuestId();
		int status = curTask.getStatus().getIndex();
		//记录日志
		Globals.getLogService().sendTreasureMapLog(human, TreasureMapLogReason.GIVEUP_TASK,"", questId, status);
	}
	
	public boolean onGiveupTask(Human human) {
		if (human.getTreasureMapManager() == null) {
			return false;
		}
		TreasureMap curTask = human.getTreasureMapManager().getCurTask();
		if (curTask == null) {
			return false;
		}
		
		
		//发消息更新任务
		human.sendMessage(new GCTreasuremapUpdate(curTask.buildQuestInfo()));
		
		human.getTreasureMapManager().clearCurTask();
		human.setModified();
		return true;
	}
	
	/**
	 * 使用藏宝图
	 * @param human
	 * @param itemId
	 */
	public void  useTreasureMap(Human human,int itemId){

		if (human == null || human.getTreasureMapManager() == null) {
			return;
		}
		
		TreasureMapRewardTemplate targetTpl = new TreasureMapRewardTemplate();
		targetTpl = randReward(itemId,human.getLevel());
		if(targetTpl == null){
			return;
		}
		
		//奖励或者战斗
		if(targetTpl.getTriggerType() == 1){
			//获得基础奖励
			Reward reward = Globals.getRewardService().createReward(
					human.getCharId(),
					targetTpl.getLoseReward(),
					"human thesweeney special reward!  petId="
							+ human.getUUID() 
							+ ",rewardId="
							+targetTpl.getLoseReward());
			Globals.getRewardService().giveReward(human, reward, true);
			//进入战斗
			Globals.getBattleService().meetTreasureMapMonsterBattle(human,targetTpl.getParam());
			
			triggerSealDemonOrKing(human);
		}else{
			//获得奖励
			Reward reward = Globals.getRewardService().createReward(
					human.getCharId(),
					targetTpl.getParam(),
					"human thesweeney special reward!  petId="
							+ human.getUUID() 
							+ ",rewardId="
							+targetTpl.getParam());
			Globals.getRewardService().giveReward(human, reward, true);
			
			human.sendErrorMessage(LangConstants.TREASURE_MAP_REWARD);
			
			triggerSealDemonOrKing(human);
		}
		
		//任务监听
		human.getTaskListener().onNumRecordDest(TaskDef.NumRecordType.USE_TREASURE_MAP, 0, 1);
	}

	/**
	 * 一定的概率会刷新魔王or小妖
	 * @param human
	 */
	protected void triggerSealDemonOrKing(Human human) {
		if (RandomUtils.isHit(Globals.getGameConstants().getDemonKingProb())) {
			Globals.getSealDemonService().randAddDemonKing(human);
		}else{
			Globals.getSealDemonService().randAddDemon(human);
		}
	}

	
	protected TreasureMapRewardTemplate randReward(int itemId, int level) {
		return RandomUtils.hitObject(Globals.getTemplateCacheService().getTreasureMapTemplateCache().getTreasureMapWeightTotalMap(itemId, level), 
				Globals.getTemplateCacheService().getTreasureMapTemplateCache().getTreasureMapTotal (itemId, level), 
				Globals.getTemplateCacheService().getTreasureMapTemplateCache().getTreasureMapRewardWeightTotalMap(itemId, level));
	}
	
	/**
	 * 随机地图
	 * @return
	 */
	public int randMapId() {
		List<Integer> allMapId  = Globals.getTemplateCacheService().getTreasureMapTemplateCache().getTreasureMap();
		int randMapId = allMapId.get(RandomUtil.nextEntireInt(0, allMapId.size() - 1));
		return randMapId;
	}

	/**
	 * 随机地图中的坐标点
	 * @param mapId
	 * @return
	 */
	public Point randMapPos(int mapId) {
		//获取地图中可用的点
		List<Integer> mapPoint = Globals.getMapService().getGameMap(mapId).getCanUsePoint();
		//随机一个点
		int randP = mapPoint.get(RandomUtil.nextEntireInt(0, mapPoint.size() - 1));
		int randX = AbstractGameMap.calcPointX(randP);
		int randY = AbstractGameMap.calcPointY(randP);
		Point pt = new Point(randX, randY);
		return pt;
	}
	
	
}
