package com.imop.lj.gameserver.lifeskill;

import java.util.Map;
import java.util.Map.Entry;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.ResultTypes;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.lifeskill.LifeSkillDef.MineCostTime;
import com.imop.lj.gameserver.lifeskill.msg.GCLsMineGain;
import com.imop.lj.gameserver.lifeskill.msg.GCLsMineGetPannel;
import com.imop.lj.gameserver.lifeskill.msg.GCLsMineStart;
import com.imop.lj.gameserver.lifeskill.template.LifeSkillMineCostTemplate;
import com.imop.lj.gameserver.lifeskill.template.LifeSkillMineMinerTemplate;
import com.imop.lj.gameserver.lifeskill.template.LifeSkillMineTemplate;
import com.imop.lj.gameserver.mail.MailDef.MailType;
import com.imop.lj.gameserver.offlinedata.UserSnap;
import com.imop.lj.gameserver.relation.Relation;
import com.imop.lj.gameserver.reward.Reward;

public class MineService implements InitializeRequired{

	@Override
	public void init() {
		return ;
	}
	public static final int MINER_TYPE_NULL = 0;
	public static final int MINER_TYPE_BASE = 1;
	public static final int MINER_TYPE_FRIEND = 2;
	
	/**
	 * 显示采矿面板信息
	 * @param human
	 */
	public void showMineInfos(Human human){
		if(human == null){
			return ;
		}
		Map<Integer, MinePit> map =  human.getMineManager().getPitMap();
		MinePitInfo[] mpis = new MinePitInfo[map.size()];
		int i = 0;
		for(Entry<Integer, MinePit> entry : map.entrySet()){
			MinePitInfo mpi = new MinePitInfo();
			mpi.setId(entry.getKey());
			mpi.setEndTime(entry.getValue().getEndTime());
			mpi.setMineTypeId(entry.getValue().getMineTypeId());
			mpi.setMiningTypeId(entry.getValue().getMiningTypeId());
			setMinerInfo(mpi,entry.getValue().getMinerId());
			mpis[i] = mpi;
			i++;
		}
		GCLsMineGetPannel gc = new GCLsMineGetPannel();
		gc.setPitList(mpis);
		gc.setServerTime(Globals.getTimeService().now());
		human.sendMessage(gc);
	}
	
	public void setMinerInfo(MinePitInfo mp ,long MinerId){
		if(mp == null || MinerId<0){
			return ;
		}
		
		//1.基础矿工
		Map<Integer, LifeSkillMineMinerTemplate> map = Globals.getTemplateCacheService().getAll(LifeSkillMineMinerTemplate.class);
		for(LifeSkillMineMinerTemplate temp : map.values()){
			if(temp.getId() == MinerId){
				mp.setMinerId(MinerId);
				mp.setMinerName(temp.getName());
				mp.setMinerTplId(temp.getMinerModelId());
				return ;
			}
		}
		
		//2.玩家
		 UserSnap us = Globals.getOfflineDataService().getUserSnap(MinerId);
		 if(us == null){
			 mp.setMinerId(0L);
			 mp.setMinerName("");
			 mp.setMinerTplId(0);
			 return ;
		 }
		 mp.setMinerId(MinerId);
		 mp.setMinerName(us.getName());
		 mp.setMinerTplId(us.getHumanTplId());
	}
	
	/**
	 * 通过Id 返回矿工类型  0不存在，1基本矿工，2好友
	 * @param human
	 * @param minerId
	 * @return
	 */
	public int getMinerTypeByMinerId(Human human, long minerId){
		if(minerId<0){
			return MINER_TYPE_NULL;
		}
		Map<Integer, LifeSkillMineMinerTemplate> map = Globals.getTemplateCacheService().getAll(LifeSkillMineMinerTemplate.class);
		for(LifeSkillMineMinerTemplate temp : map.values()){
			if(temp.getId() == minerId){
				return MINER_TYPE_BASE;
			}
		}
		
		Map<Long, Relation> relationMap = human.getRelationManager().getFriendRelationList();
		for(Relation relation : relationMap.values()){
			if(relation.getTargetCharId() == minerId){
				return MINER_TYPE_FRIEND;
			}
		}
		return MINER_TYPE_NULL;
	}
	
	
	/**
	 * 判断矿工是否在使用中
	 * @param human
	 * @param minerId
	 * @return
	 */
	protected boolean minerIsAlreadyUsed(Human human, long minerId){
		boolean flag = false;
		if(minerId <0){
			return flag;
		}
		Map<Integer, MinePit> map =  human.getMineManager().getPitMap();
		for(Entry<Integer, MinePit> entry : map.entrySet()){
			if(entry.getValue().getMinerId() == minerId){
				flag = true;
				break;
			}
		}
		return flag;
	}
	
	
	/**
	 * 开始挖矿
	 * @param human
	 * @param pitId
	 * @param mineId
	 * @param minerId
	 * @param miningTypeId
	 */
	public void startMining(Human human, int pitId, int mineId, long minerId,
			int miningTypeId) {
		//1.基础校验
		if(human == null || pitId<0 || mineId<0 || miningTypeId<0 || minerId <0L ){
			return ;
		}
		GCLsMineStart gc = new GCLsMineStart();
		gc.setResult(ResultTypes.FAIL.getIndex());
		//2.矿坑
		Map<Integer, MinePit> map =  human.getMineManager().getPitMap();
		if(!map.containsKey(pitId)){
			human.sendErrorMessage(LangConstants.THIS_PIT_IS_NOT_OPEN_YET);
			human.sendMessage(gc);
			return ;
		}
		if(map.get(pitId).isOnWorking()){
			human.sendErrorMessage(LangConstants.THIS_PIT_IS_ALREADY_USING);
			human.sendMessage(gc);
			return ;
		}
		//3.矿石
		LifeSkillMineTemplate lsmt = Globals.getTemplateCacheService().get(mineId, LifeSkillMineTemplate.class);
		if(lsmt == null){
			human.sendErrorMessage(LangConstants.THIS_MINE_IS_NOT_EXTIS);
			human.sendMessage(gc);
			return ;
		}
		if(human.getMineLevel() < lsmt.getOpenLevel()){
			human.sendErrorMessage(LangConstants.MINE_LEVEL_IS_NOT_ENOUGH);
			human.sendMessage(gc);
			return ;
		}
		//4.采矿方式
		LifeSkillMineCostTemplate lsmct = Globals.getTemplateCacheService().get(miningTypeId, LifeSkillMineCostTemplate.class);
		if(lsmct == null){
			human.sendMessage(gc);
			return ;
		}
		
		//TODO 活力暂时不配置
		if(Currency.valueOf(lsmct.getCurrencyType()) == Currency.ENERGY){
			if(!human.hasEnoughMoney(lsmct.getCurrencyNum(), Currency.valueOf(lsmct.getCurrencyType()), false)){
				human.sendErrorMessage(LangConstants.VITALITY_DEFICIENT_TO_MINING);
				human.sendMessage(gc);
				return ;
			}
		}
		if(Currency.valueOf(lsmct.getCurrencyType()) == Currency.GOLD){
			//方便测试
			if(!human.hasEnoughMoney(lsmct.getCurrencyNum(), Currency.valueOf(lsmct.getCurrencyType()), false)){
				human.sendErrorMessage(LangConstants.GOLD_DEFICIENT_TO_MINING);
				human.sendMessage(gc);
				return ;
			}
		}
		//5.矿工
		if(minerIsAlreadyUsed(human,minerId)){
			human.sendErrorMessage(LangConstants.MINER_IS_ALREADY_WORKING);
			human.sendMessage(gc);
			return ;
		}
		Integer minerType = getMinerTypeByMinerId(human,minerId);
		if(minerType == MINER_TYPE_NULL){
			human.sendErrorMessage(LangConstants.MINER_IS_NOT_BASE_OR_FRIEND);
			human.sendMessage(gc);
			return ;
		}
		//6.扣除活力
		if(!human.costMoney(lsmct.getCurrencyNum(), Currency.valueOf(lsmct.getCurrencyType()), true, 0, LogReasons.MoneyLogReason.MINING_COST_VITALITY, LogUtils.genReasonText(LogReasons.MoneyLogReason.MINING_COST_VITALITY), 0)){
			//活力扣除失败	
			human.sendMessage(gc);
			return ;
		}
		//7.设置参数
		map.get(pitId).setEndTime(Globals.getTimeService().now() + lsmct.getCostTime() * 60 * 60 * 1000);
		map.get(pitId).setMinerId(minerId);
		map.get(pitId).setMineTypeId(mineId);
		map.get(pitId).setMiningTypeId(miningTypeId);
		map.get(pitId).setOnWorking(true);
		human.setModified();
		//8.发送消息
		gc.setResult(ResultTypes.SUCCESS.getIndex());
		human.sendMessage(gc);
		showMineInfos(human);
	}
	
	/**
	 * 收获采矿奖励
	 * @param human
	 * @param pitId
	 */
	public void gainMineReward(Human human, int pitId) {
		//1.基础校验
		if(human == null || pitId<0){
			return ;
		}
		GCLsMineGain gc = new GCLsMineGain();
		gc.setResult(ResultTypes.FAIL.getIndex());
		//2.矿点验证
		Map<Integer, MinePit> map =  human.getMineManager().getPitMap();
		if(!map.containsKey(pitId)){
			human.sendErrorMessage(LangConstants.THIS_PIT_IS_NOT_OPEN_YET);
			human.sendMessage(gc);
			return ;
		}
		if(!map.get(pitId).isOnWorking()){
			human.sendErrorMessage(LangConstants.THIS_PIT_IS_NOT_PRODUCTING);
			human.sendMessage(gc);
			return ;
		}
		if(Globals.getTimeService().now() < map.get(pitId).getEndTime()){
			human.sendErrorMessage(LangConstants.THIS_PIT_IS_NOT_FINISHED);
			human.sendMessage(gc);
			return ;
		}
		//3.获得奖励ID
		LifeSkillMineCostTemplate lsmct = Globals.getTemplateCacheService().get(map.get(pitId).getMiningTypeId(), LifeSkillMineCostTemplate.class);
		LifeSkillMineTemplate lsmt = Globals.getTemplateCacheService().get(map.get(pitId).getMineTypeId(), LifeSkillMineTemplate.class);
		if(lsmct == null || lsmt == null){
			human.sendMessage(gc);
			return ;
		}
		Integer selfRewardId = 0;
		Integer friendRewardId = 0;
		if(lsmct.getCostTime() == MineCostTime.ONE_HOUR.getHours()){
			selfRewardId = lsmt.getSelfReward1();
			friendRewardId = lsmt.getFriendReward1();
		}else if(lsmct.getCostTime() == MineCostTime.THREE_HOUR.getHours()){
			selfRewardId = lsmt.getSelfReward2();
			friendRewardId = lsmt.getFriendReward2();
		}else if(lsmct.getCostTime() == MineCostTime.TEN_HOUR.getHours()){
			selfRewardId = lsmt.getSelfReward3();
			friendRewardId = lsmt.getFriendReward3();
		}else{
			human.sendMessage(gc);
			return ;
		}
		
		//4.复位信息
		Long minerId = map.get(pitId).getMinerId();
		map.get(pitId).reset();
		human.setModified();
		
		//5.发自己的奖励
		Reward selfReward =  Globals.getRewardService().createReward(human.getUUID(), selfRewardId, "pet gain reward by mining. ");
		Globals.getRewardService().giveReward(human, selfReward, true);
		
		//6.好友的奖励
		if(getMinerTypeByMinerId(human,map.get(pitId).getMinerId()) == MINER_TYPE_FRIEND){
			Reward firendReward =  Globals.getRewardService().createReward(human.getUUID(), friendRewardId, "pet gain reward by help mining others. ");
			Globals.getMailService().sendSysMail(minerId, MailType.SYSTEM, "帮助好友<"+human.getName()+">挖矿的酬劳", "", firendReward);
		}
		
		//8.发送消息
		gc.setResult(ResultTypes.SUCCESS.getIndex());
		human.sendMessage(gc);
		showMineInfos(human);
	}
	
	
	
}
