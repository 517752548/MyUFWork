package com.imop.lj.gameserver.guaji;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.common.model.human.GuaJiInfo;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.guaji.GuaJiDef.GuaJiParam;
import com.imop.lj.gameserver.guaji.msg.GCGuaJiPanel;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.tower.msg.GCGuaji;

public class GuaJiService implements InitializeRequired {

	@Override
	public void init() {
		
	}

	/**
	 * 开始挂机
	 * @param human
	 * @param encounterSecond
	 * @param humanExpTimes
	 * @param petExpTimes
	 * @param fullEnemy
	 * @param switchScene
	 * @param guaJiMinute
	 * @param needGuaJiPoint
	 */
	public void handleStartGuaJi(Human human, int encounterSecond,
			int humanExpTimes, int petExpTimes, boolean fullEnemy, boolean switchScene, int guaJiMinute, int needGuaJiPoint) {
		if(human == null || human.getGuaJiManager() == null){
			return;
		}
		
		//必须通过通天塔NPC
		if (Globals.getMapService().isTower(human.getMapId())) {
			if(!Globals.getTowerService().isPassNPC(human, human.getMapId(), false)){
				human.sendErrorMessage(LangConstants.GUA_JI_NOT_PASS_TOWER);
				human.sendMessage(new GCGuaji(ResultTypes.FAIL.getIndex()));
				return;
			}
		}
		
		//采集状态下,不允许挂机
		if(human.isInGather()){
			human.sendErrorMessage(LangConstants.GUA_JI_NOT_OK);
			human.sendMessage(new GCGuaji(ResultTypes.FAIL.getIndex()));
			return;
		}
		
		//是否在队伍中
		if(Globals.getTeamService().isInTeamNormal(human.getCharId())){
			//是否是队长
			if(!Globals.getTeamService().isTeamLeader(human.getCharId())){
				human.sendErrorMessage(LangConstants.GUA_JI_NOT_LEADER);
				human.sendMessage(new GCGuaji(ResultTypes.FAIL.getIndex()));
				return;
			}
		}
		
		//是否满足地图当前遇怪等级
		if(!Globals.getTeamService().triggerBattleLevelLimit(human.getCharId())){
			human.sendErrorMessage(LangConstants.GUA_JI_MAP_LEVEL_NOT_ENOUGH, Globals.getGameConstants().getMapMeetMonsterLevelLimit());
			human.sendMessage(new GCGuaji(ResultTypes.FAIL.getIndex()));
			return;
		}
		
		//玩家当前地图是否位于安全区
		if(Globals.getMapService().isInSafeMap(human.getMapId())){
			human.sendErrorMessage(LangConstants.GUA_JI_IN_SAFE_MAP);
			human.sendMessage(new GCGuaji(ResultTypes.FAIL.getIndex()));
			return;
		}
		
		GuaJiManager guaJiManager = human.getGuaJiManager();
		
		//必须是未挂机状态
		if(guaJiManager.isGuaJi()){
			return;
		}
		
		//挂机剩余时间为0,说明是重新开始挂机,此时需要扣除挂机点
		if(this.calculateGuaJiLeftTime(human) <= 0){
			//是否和计算的一致
			if(needGuaJiPoint != this.calculateGuajiPoint(encounterSecond, humanExpTimes, petExpTimes, fullEnemy, guaJiMinute)){
				return;
			}
			//挂机点数是否充足
			if(!human.hasEnoughMoney(needGuaJiPoint, Currency.GUA_JI_POINT, false)){
				human.sendErrorMessage(LangConstants.GUA_JI_POINT_NOT_ENOUGH, needGuaJiPoint);
				human.sendMessage(new GCGuaji(ResultTypes.FAIL.getIndex()));
				return;
			}
			//扣除挂机点数
			String moneyDetail = LogUtils.genReasonText(MoneyLogReason.START_GUA_JI_COST, needGuaJiPoint);
			if (!human.costMoney(needGuaJiPoint, Currency.GUA_JI_POINT, true, 0, 
					MoneyLogReason.START_GUA_JI_COST, moneyDetail, 0)) {
				return;
			}
			//改变挂机信息
			guaJiManager.setEncounterSecond(encounterSecond);
			guaJiManager.setHumanExpTimes(humanExpTimes);
			guaJiManager.setPetExpTimes(petExpTimes);
			guaJiManager.setFullEnemy(fullEnemy);
			guaJiManager.setSwitchScene(switchScene);
			guaJiManager.setGuaJiMinute(guaJiMinute);
			guaJiManager.setPassTime(0L);
		}
		
		guaJiManager.setStartTime(Globals.getTimeService().now());
		
		guaJiManager.setGuaJi(true);
		human.setModified();
		
		//发送消息
		human.sendMessage(new GCGuaji(ResultTypes.SUCCESS.getIndex()));
		//刷新界面
		this.noticeGuaJiInfo(human);
		
	}

	/**
	 * 暂停挂机
	 * @param human
	 */
	public void pauseGuaJi(Human human) {
		if(human == null || human.getGuaJiManager() == null){
			return;
		}
		GuaJiManager guaJiManager = human.getGuaJiManager();
		
		//已经是暂停状态了
		if(!guaJiManager.isGuaJi()){
			return;
		}
		
		//记录暂停时间
		guaJiManager.setLastPauseTime(Globals.getTimeService().now());
		guaJiManager.setPassTime(guaJiManager.getPassTime() + (guaJiManager.getLastPauseTime() - guaJiManager.getStartTime()));
		//设置暂停状态
		guaJiManager.setGuaJi(false);
		human.setModified();
		
		//刷新界面
		this.noticeGuaJiInfo(human);
	}

	public void noticeGuaJiInfo(Human human) {
		if(human == null || human.getGuaJiManager() == null){
			return;
		}
		
		GuaJiManager guaJiManager = human.getGuaJiManager();
		GuaJiInfo info = new GuaJiInfo();
		info.setEncounterSecond(guaJiManager.getEncounterSecond());
		info.setHumanExpTimes(guaJiManager.getHumanExpTimes());
		info.setPetExpTimes(guaJiManager.getPetExpTimes());
		info.setFullEnemy(guaJiManager.isFullEnemy());
		info.setSwitchScene(guaJiManager.isSwitchScene());
		info.setGuaJiMinute(guaJiManager.getGuaJiMinute());
		info.setLeftTime(this.calculateGuaJiLeftTime(human));
		info.setNeedGuaJiPoint(calculateGuajiPoint(guaJiManager.getEncounterSecond(), guaJiManager.getHumanExpTimes()
				, guaJiManager.getPetExpTimes(), guaJiManager.isFullEnemy(), guaJiManager.getGuaJiMinute()));
		info.setGuaJi(guaJiManager.isGuaJi());
		
		human.sendMessage(new GCGuaJiPanel(info));
	}
	
	public long calculateGuaJiLeftTime(Human human){
		if(human == null || human.getGuaJiManager() == null){
			return 0;
		}
		
		GuaJiManager guaJiManager = human.getGuaJiManager();
		//剩余时间  = 总时长 - 挂机走的时间
		long leftTime = 0;
		if(human.isInGuaJi()){
			leftTime = guaJiManager.getGuaJiMinute() * 60 * 1000 - (Globals.getTimeService().now() - guaJiManager.getStartTime() + guaJiManager.getPassTime());
		}else{
			leftTime = guaJiManager.getGuaJiMinute() * 60 * 1000 - guaJiManager.getPassTime();
		}
		
		if(leftTime < 0){
			leftTime = 0;
		}
		
		return leftTime;
	}

	private int calculateGuajiPoint(int encounterSecond, int humanExpTimes, int petExpTimes, boolean fullEnemy, int guaJiMinute) {
		int result = 0;
		int part1 = Globals.getTemplateCacheService().getGuaJiTemplateCache().getValueByGuaJiPara(GuaJiParam.ENCOUNTER, encounterSecond);
		int part2 = Globals.getTemplateCacheService().getGuaJiTemplateCache().getValueByGuaJiPara(GuaJiParam.HUMAN_EXP_TIMES, humanExpTimes);
		int part3 = Globals.getTemplateCacheService().getGuaJiTemplateCache().getValueByGuaJiPara(GuaJiParam.PET_EXP_TIMES, petExpTimes);
		int part4 = Globals.getTemplateCacheService().getGuaJiTemplateCache().getValueByGuaJiPara(GuaJiParam.FULL_ENEMY, fullEnemy ? 1 : 0);
		int part5 = Globals.getTemplateCacheService().getGuaJiTemplateCache().getValueByGuaJiPara(GuaJiParam.GUA_JI_MINUTE, guaJiMinute);
		
		//【遇敌时间设置价值+人物收益设置价值+宠物人物收益设置价值+满怪设置值价值】*挂机时间设置*折扣
		result = (int) ((part1 + part2 + part3 + part4) * part5 * Globals.getGameConstants().getGuaJiProb());
		return result;
	}
	
	

}
