package com.imop.lj.gameserver.plotdungeon;

import java.util.ArrayList;
import java.util.List;
import java.util.Set;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.plotdungeon.PlotDungeonInfo;
import com.imop.lj.gameserver.battle.BattleProcess;
import com.imop.lj.gameserver.battle.core.Fighter;
import com.imop.lj.gameserver.battle.core.BattleDef.BattleType;
import com.imop.lj.gameserver.battle.core.BattleDef.FighterType;
import com.imop.lj.gameserver.behavior.bindid.BindIdBehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.enemy.EnemyParamContent;
import com.imop.lj.gameserver.enemy.template.EnemyArmyTemplate;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.plotdungeon.PlotDungeonDef.DungeonType;
import com.imop.lj.gameserver.plotdungeon.PlotDungeonDef.RewardType;
import com.imop.lj.gameserver.plotdungeon.msg.GCDailyPlotDungeonInfo;
import com.imop.lj.gameserver.plotdungeon.msg.GCPlotDungeonInfo;
import com.imop.lj.gameserver.plotdungeon.msg.PlotDungeonMsgBuilder;
import com.imop.lj.gameserver.plotdungeon.template.PlotDungeonTemplate;
import com.imop.lj.gameserver.quest.CommonTaskManager;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.task.template.QuestTemplate;

public class PlotDungeonService implements InitializeRequired {

	@Override
	public void init() {
		
	}
	
	protected boolean canStartBattle(Human human, DungeonType type, int reqPlotLevel) {
		long roleId = human.getCharId();
		int curPlotLevel = this.getCurPlotDungeonLevel(human, type);
		//请求挑战副本关数是否正确,不等于当前关数 + 1
		if(reqPlotLevel != curPlotLevel + 1){
			Loggers.plotDungeonLogger.error("PlotDungeonService#handlePlotDungeonStart is invalid!charId = " + roleId
					+";reqPlotLevel = " + reqPlotLevel
					+";curPlotDungeonLevel + 1 = " + (curPlotLevel + 1));
			return false;
		}
		PlotDungeonTemplate tpl = Globals.getTemplateCacheService().getPlotDungeonTemplateCache().getPlotDungeonInfoByLevel(reqPlotLevel, type);
		if(tpl == null){
			Loggers.plotDungeonLogger.error("PlotDungeonService#getPlotDungeonInfoByLevel result is null!charId = "+ roleId +";curPlotLevel= "+ curPlotLevel);
			return false;
		}
		
		//主线剧情是否通过
		if(human == null || human.getCommonTaskManager() == null){
			return false;
		}
		CommonTaskManager commonTaskManager = human.getCommonTaskManager();
		Set<Integer> finishedSet = commonTaskManager.getFinishedSet();
		if(!finishedSet.contains(tpl.getTriggerQuestId())){
			QuestTemplate questTemplate = Globals.getTemplateCacheService().get(tpl.getTriggerQuestId(), QuestTemplate.class);
			if(questTemplate != null){
				human.sendErrorMessage(LangConstants.PLOT_DUNGEON_QUEST_ID_NOT_ENOUGH, questTemplate.getFinishDesc());
			}
			return false;
		}
		//是否组队
		if(Globals.getTeamService().isInTeamNormal(roleId)){
			human.sendErrorMessage(LangConstants.PLOT_DUNGEON_NOT_PERMIT_TEAM);
			return false;
		}
		
		return true;
	}
	
	/**
	 * 得到玩家当前副本的关数
	 * @param human
	 * @param type
	 * @return
	 */
	protected int getCurPlotDungeonLevel(Human human, DungeonType type) {
		if(human == null || human.getEasyPlotDungeonManager() == null){
			return 0;
		}
		if(type == DungeonType.EASY){
			return human.getEasyPlotDungeonManager().getPlotLevel();
		}else if(type == DungeonType.HARD){
			return human.getHardPlotDungeonManager().getPlotLevel();
		}else{
			return 0;
		}
		
	}
	
	/**
	 * 得到玩家当前副本的关数
	 * @param human
	 * @param type
	 * @return
	 */
	protected boolean updateCurPlotDungeonLevel(Human human, DungeonType type) {
		if(human == null || human.getEasyPlotDungeonManager() == null || human.getHardPlotDungeonManager() == null){
			return false;
		}
		if(type == DungeonType.EASY){
			int plotLevel = human.getEasyPlotDungeonManager().getPlotLevel();
			human.getEasyPlotDungeonManager().setPlotLevel(plotLevel + 1);
			human.getEasyPlotDungeonManager().setLastUpdateTime(Globals.getTimeService().now());
			human.setModified();
			return true;
		}else if(type == DungeonType.HARD){
			int plotLevel = human.getHardPlotDungeonManager().getPlotLevel();
			human.getHardPlotDungeonManager().setPlotLevel(plotLevel + 1);
			human.getHardPlotDungeonManager().setLastUpdateTime(Globals.getTimeService().now());
			human.setModified();
		}else{
			
		}
		return false;
		
	}
	
	/**
	 * GM 命令使用
	 * @param human
	 * @param chapter
	 */
	public void updateCurPlotDungeonLevel(Human human, DungeonType type, int plotLevel){
		if(type == DungeonType.EASY){
			human.getEasyPlotDungeonManager().setPlotLevel(plotLevel);
			human.getEasyPlotDungeonManager().setLastUpdateTime(Globals.getTimeService().now());
			human.setModified();
		}else if(type == DungeonType.HARD){
			human.getHardPlotDungeonManager().setPlotLevel(plotLevel);
			human.getHardPlotDungeonManager().setLastUpdateTime(Globals.getTimeService().now());
			human.setModified();
		}
	}
	
	/**
	 * 查看当前剧情副本情况
	 * @param human
	 * @param plotDungeonType
	 */
	public void handlePlotDungeonInfo(Human human, int plotDungeonType) {
		long roleId = human.getCharId();
		int curPlotDungeonLevel = this.getCurPlotDungeonLevel(human, DungeonType.valueOf(plotDungeonType));
		int curPlotChapter = this.getPlotChapter(curPlotDungeonLevel);
		//主线剧情是否通过
		if(human == null || human.getCommonTaskManager() == null){
			return;
		}
		PlotDungeonTemplate tpl = Globals.getTemplateCacheService().getPlotDungeonTemplateCache().getPlotDungeonInfoByLevel(curPlotDungeonLevel + 1, DungeonType.valueOf(plotDungeonType));
		if(tpl == null){
			Loggers.plotDungeonLogger.error("PlotDungeonService#handlePlotDungeonInfo result is null!charId = "+ roleId +";curPlotLevel= "+ curPlotDungeonLevel);
			return ;
		}
		int plotDungeonChapter = 0;
		CommonTaskManager commonTaskManager = human.getCommonTaskManager();
		Set<Integer> finishedSet = commonTaskManager.getFinishedSet();
		//可以开启新的一章了
		if(finishedSet.contains(tpl.getTriggerQuestId())){
			plotDungeonChapter = curPlotChapter + 1;
		}else{
			plotDungeonChapter = curPlotChapter;
		}
		GCPlotDungeonInfo msg = PlotDungeonMsgBuilder.createGCPlotDungeonInfo(plotDungeonChapter, plotDungeonType, curPlotDungeonLevel);
		human.sendMessage(msg);
	}

	/**
	 * 请求挑战剧情副本
	 * @param human
	 * @param plotDungeonType
	 * @param reqPlotLevel
	 */
	public void handlePlotDungeonStart(Human human, int plotDungeonType, int reqPlotLevel) {
		if(!canStartBattle(human, DungeonType.valueOf(plotDungeonType), reqPlotLevel)){
			return;
		}
		
		startPlotDungeonFight(human, plotDungeonType, reqPlotLevel);
		
		//刷新面板
		this.handlePlotDungeonInfo(human, plotDungeonType);
		
	}
	
	/**
	 * 打剧情副本
	 * @param human
	 * @param plotDungeonType
	 * @param reqPlotLevel
	 */
	private void startPlotDungeonFight(Human human, int plotDungeonType, int reqPlotLevel) {
		long roleId = human.getCharId();
		//获取到该层的怪物组
		PlotDungeonTemplate tpl = Globals.getTemplateCacheService().getPlotDungeonTemplateCache().getPlotDungeonInfoByLevel(reqPlotLevel, DungeonType.valueOf(plotDungeonType));
		if(tpl == null){
			return;
		}
		
		EnemyParamContent epc = null;
		int sum = 0;
		int mapId = human.getMapId();
		if (Globals.getTeamService().canTriggerSingleBattle(roleId)) {
			//主将+伙伴的个数
			sum = 1; 
			epc = new EnemyParamContent(tpl.getEnemyArmyId(), sum, human.getLevel(), mapId, false);
			
			Fighter<?> attacker = new Fighter<Human>(FighterType.FORMATION, human, true);
			Fighter<?> defender = Fighter.valueOf(FighterType.ENEMY, epc, false);
			//开始单人战斗
			Globals.getBattleService().startPVEBattle(human, BattleType.PLOT_DUNGEON, attacker, defender, null);
		}
	}

	public void updatePlotDungeonRecord(long roleId, EnemyArmyTemplate eaTpl, int mapId, BattleProcess bp) {
		PlotDungeonTemplate tpl = Globals.getTemplateCacheService().getPlotDungeonTemplateCache().getPlotDungeonInfoByEnemy(eaTpl.getId());
		if(tpl == null){
			return;
		}
		if (Globals.getTeamService().isPlayerOnline(roleId)) {
			Human human = Globals.getOnlinePlayerService().getPlayer(roleId).getHuman();
			//更新剧情副本DB
			if(tpl.getHardFlag() == DungeonType.EASY.getIndex()){
				updateCurPlotDungeonLevel(human, DungeonType.EASY);
			}else if(tpl.getHardFlag() == DungeonType.HARD.getIndex()){
				updateCurPlotDungeonLevel(human, DungeonType.HARD);
			}
		}
	}
	
	/**
	 * 领取每日剧情副本奖励
	 * @param human
	 * @param plotDungeonType
	 * @param plotDungeonChapter
	 * @return
	 */
	public void getDailyPlotDungeonReward(Human human, int plotDungeonType, int plotDungeonChapter) {
		long roleId = human.getCharId();
		//玩家是否可以领取当前章的奖励
		int curPlotDungeonLevel = this.getCurPlotDungeonLevel(human, DungeonType.valueOf(plotDungeonType));
		if(curPlotDungeonLevel < plotDungeonChapter * Globals.getGameConstants().getChapterByPlotDungeon()){
			Loggers.plotDungeonLogger.error("PlotDungeonService#getDailyPlotDungeonReward can not get reward!charId = "+ roleId +";plotDungeonChapter= "+ plotDungeonChapter
					+";curPlotDungeonLevel = " + curPlotDungeonLevel);
			return;
		}
		//每日可以领取一次
		if(plotDungeonType == DungeonType.EASY.getIndex()
				&& human.getBindIdBehaviorManager().canDo(BindIdBehaviorTypeEnum.EASY_PLOT_DUNGEON_REWARD, plotDungeonChapter)){
			human.getBindIdBehaviorManager().doBehavior(BindIdBehaviorTypeEnum.EASY_PLOT_DUNGEON_REWARD, plotDungeonChapter);
			sendReward(human, plotDungeonType, plotDungeonChapter);
			//刷新界面
			this.noticePlotDungeonReward(human);
		}else if(plotDungeonType == DungeonType.HARD.getIndex()
				&& human.getBindIdBehaviorManager().canDo(BindIdBehaviorTypeEnum.HARD_PLOT_DUNGEON_REWARD, plotDungeonChapter)){
			human.getBindIdBehaviorManager().doBehavior(BindIdBehaviorTypeEnum.HARD_PLOT_DUNGEON_REWARD, plotDungeonChapter);
			sendReward(human, plotDungeonType, plotDungeonChapter);
			//刷新界面
			this.noticePlotDungeonReward(human);
		}else{
			human.sendErrorMessage(LangConstants.PLOT_DUNGEON_GET_REWARD_REPEATLY);
		}
		
		
		
	}

	private void sendReward(Human human, int plotDungeonType, int plotDungeonChapter) {
		long roleId = human.getCharId();
		//发奖励
		PlotDungeonTemplate tpl = Globals.getTemplateCacheService().getPlotDungeonTemplateCache().getPlotDungeonInfoByLevel(
				plotDungeonChapter * Globals.getGameConstants().getChapterByPlotDungeon(),
				DungeonType.valueOf(plotDungeonType));
		if(tpl == null){
			return;
		}
		Reward reward = Globals.getRewardService().createReward(roleId, tpl.getDailyRewardId(),
				"gain reward by plot dungeon battle end.");
		if (!Globals.getRewardService().giveReward(human, reward, true)) {
			// 记录错误日志
			Loggers.plotDungeonLogger
					.error("PlotDungeonService#getDailyPlotDungeonReward give reward error!humanId=" + roleId);
			return;
		}
	}

	protected int getPlotChapter(int curPlotDungeonLevel) {
		//默认返回章节数是0
		if(curPlotDungeonLevel < Globals.getGameConstants().getChapterByPlotDungeon()){
			return 0;
		}else{
			return curPlotDungeonLevel / Globals.getGameConstants().getChapterByPlotDungeon();
		}
	}

	public boolean canGetDailyPlotDungeonReward(Human human) {
		 //1. 简单副本是否可领取
		 int easyChapterMaxNum = Globals.getTemplateCacheService().getPlotDungeonTemplateCache().getPlotDungeonChapterNumByType(DungeonType.EASY);
		 boolean easyFlag = false;
		 for(int i = 1;i<= easyChapterMaxNum;i++){
			 if(human.getBindIdBehaviorManager().canDo(BindIdBehaviorTypeEnum.EASY_PLOT_DUNGEON_REWARD, i)){
				 easyFlag = true;
				 break;
			 }
		 }
		
		//2. 精英副本可否领取
		 int hardChapterMaxNum = Globals.getTemplateCacheService().getPlotDungeonTemplateCache().getPlotDungeonChapterNumByType(DungeonType.HARD);
		 boolean hardFlag = false;
		 for(int i = 1;i<= hardChapterMaxNum;i++){
			 if(human.getBindIdBehaviorManager().canDo(BindIdBehaviorTypeEnum.HARD_PLOT_DUNGEON_REWARD, i)){
				 hardFlag = true;
				 break;
			 }
		 }
		
		return easyFlag || hardFlag;
	}

	
	public void noticePlotDungeonReward(Human human) {
		if (human == null || human.getBindIdBehaviorManager() == null) {
			return;
		}
		
		List<PlotDungeonInfo> lst = new ArrayList<PlotDungeonInfo>();
		//简单副本
		int curEasyPlotDungeonLevel = this.getCurPlotDungeonLevel(human, DungeonType.EASY);
		int curEasyPlotChapter = this.getPlotChapter(curEasyPlotDungeonLevel);
		int easyChapterMaxNum = Globals.getTemplateCacheService().getPlotDungeonTemplateCache().getPlotDungeonChapterNumByType(DungeonType.EASY);
		for (int i = 1; i <= easyChapterMaxNum; i++) {
			PlotDungeonInfo info = new PlotDungeonInfo();
			info.setPlotDungeonChapter(i);
			info.setPlotDungeonType(DungeonType.EASY.getIndex());
			//已领取
			if (!human.getBindIdBehaviorManager().canDo(BindIdBehaviorTypeEnum.EASY_PLOT_DUNGEON_REWARD, i)) {
				info.setPlotDungeonStatus(RewardType.FINISHED.getIndex());
			}else{
				//可领取,但未领
				info.setPlotDungeonStatus(RewardType.CAN_GET.getIndex());
				
			}
			//不可领取
			if(curEasyPlotChapter < i){
				info.setPlotDungeonStatus(RewardType.CAN_NOT_GET.getIndex());
			}
			
			lst.add(info);
		}
		//精英副本
		int curHardPlotDungeonLevel = this.getCurPlotDungeonLevel(human, DungeonType.HARD);
		int curHardPlotChapter = this.getPlotChapter(curHardPlotDungeonLevel);
		int hardChapterMaxNum = Globals.getTemplateCacheService().getPlotDungeonTemplateCache().getPlotDungeonChapterNumByType(DungeonType.HARD);
		for (int i = 1; i <= hardChapterMaxNum; i++) {
			PlotDungeonInfo info = new PlotDungeonInfo();
			info.setPlotDungeonChapter(i);
			info.setPlotDungeonType(DungeonType.HARD.getIndex());
			//已领取
			if (!human.getBindIdBehaviorManager().canDo(BindIdBehaviorTypeEnum.HARD_PLOT_DUNGEON_REWARD, i)) {
				info.setPlotDungeonStatus(RewardType.FINISHED.getIndex());
			}else{
				//可领取,但未领
				info.setPlotDungeonStatus(RewardType.CAN_GET.getIndex());
				
			}
			//不可领取
			if(curHardPlotChapter < i){
				info.setPlotDungeonStatus(RewardType.CAN_NOT_GET.getIndex());
			}
			
			lst.add(info);
		}
		GCDailyPlotDungeonInfo msg = PlotDungeonMsgBuilder.createGCDailyPlotDungeonInfo(lst);
		human.sendMessage(msg);
	}

}
