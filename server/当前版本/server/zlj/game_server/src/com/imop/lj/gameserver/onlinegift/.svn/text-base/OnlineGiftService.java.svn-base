package com.imop.lj.gameserver.onlinegift;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.model.reward.RewardInfo;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.onlinegift.msg.*;
import com.imop.lj.gameserver.onlinegift.template.DailySignGiftTemplate;
import com.imop.lj.gameserver.onlinegift.template.OnlineGiftTemplate;
import com.imop.lj.gameserver.onlinegift.template.SpecOnlineGiftTemplate;
import com.imop.lj.gameserver.reward.Reward;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

/**
 * 在线礼包服务
 * 
 * @author xiaowei.liu
 * 
 */
public class OnlineGiftService implements InitializeRequired {
	
	/** 每日签到奖励的map **/
	protected Map<Integer,DailySignGiftTemplate> giftMap = Maps.newHashMap();

	protected Map<Long,List<RewardInfo>> tempRewardList =Maps.newHashMap(); //缓存
	/** 每日签到奖励的MSG **/
	protected GCDaliyGiftListApply gcMsg = new GCDaliyGiftListApply();
	
	@Override
	public void init() {
		//初始化map
		giftMap = Globals.getTemplateCacheService().getAll(DailySignGiftTemplate.class);
		
		//初始化MSG
		RewardInfo[] rewardArr = new RewardInfo[giftMap.size()];
		for(Entry<Integer,DailySignGiftTemplate> entry : giftMap.entrySet()){
			rewardArr[entry.getKey()-1] = Globals.getRewardService().createShowRewardInfo(entry.getValue().getShowRewardId());
		}
		gcMsg.setRewardInfoList(rewardArr);
	}

	/**
	 * 获取在线礼包信息
	 * 
	 * @param human
	 */
	public void handleGetOnlinegiftInfo(Human human) {
		OnlineGiftTemplate tmpl = human.getOnlineGiftManager().getCurrReceiveOnlineGiftTemplate();
		if(tmpl == null){
			return;
		}
		Globals.getOnlineGiftService().sendCurHumanOnlineGiftRewardList(human);

	}

	protected void sendCurHumanOnlineGiftRewardList(Human human) {
		List<RewardInfo> rewardInfoList = getRewardInfoList(human.getCharId());
		GCOnlinegiftInfo resp = new GCOnlinegiftInfo();
		resp.setRewardId(human.getOnlineGiftManager().getCurrReceiveId());
		resp.setCdTime(human.getOnlineGiftManager().getCd());
		RewardInfo[] rewardInfo = new RewardInfo[rewardInfoList.size()];
		resp.setRewardInfo(rewardInfoList.toArray(rewardInfo));
		human.sendMessage(resp);
	}


	protected List<RewardInfo> getRewardInfoList(long humanCharid) {
		if(tempRewardList.containsKey(humanCharid))
			return tempRewardList.get(humanCharid);

		List<RewardInfo> rewardInfoList = Lists.newArrayList();
		for(OnlineGiftDev.OnlineGiftReward onlinegift:OnlineGiftDev.OnlineGiftReward.values()){
			OnlineGiftTemplate tmpl =Globals.getTemplateCacheService().get(onlinegift.getIndex(), OnlineGiftTemplate.class);
			RewardInfo rewardInfo = Globals.getRewardService().createShowRewardInfo(tmpl.getShowRewardId());
			rewardInfoList.add(rewardInfo);
		}
		tempRewardList.put(humanCharid,rewardInfoList);
		return rewardInfoList;
	}

	/**
	 * 领取在线礼包
	 * 
	 * @param human
	 */
	public void handleReceiveOnlinegift(Human human){
		OnlineGiftTemplate tmpl = human.getOnlineGiftManager().getCurrReceiveOnlineGiftTemplate();
		if(tmpl == null){
			return;
		}
		
		if(!human.getOnlineGiftManager().isOpening()){
			return;
		}
		if(human.getOnlineGiftManager().getCd() > 0){
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.ONLINE_GIFT);
			return;
		}
		
		human.getOnlineGiftManager().next();
		int rewardId = tmpl.getRewardId();
		Reward reward = Globals.getRewardService().createReward(human.getUUID(), rewardId, "");
		Globals.getRewardService().giveReward(human, reward, false);
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.ONLINE_GIFT);
//		human.sendErrorMessage(reward.getRewardString());
		this.sendCurHumanOnlineGiftRewardList(human); //发送onlinegift消息

		
		
	}
	
	/**
	 * 获取特殊在线礼包信息
	 * 
	 * @param human
	 */
	public void handleGetSpecOnlinegiftInfo(Human human) {
		SpecOnlineGiftTemplate tmpl = human.getSpecOnlineGiftManager().getCurrReceiveOnlineGiftTemplate();
		if(tmpl == null){
			return;
		}
		
		GCSpecOnlineGiftShowInfo resp = new GCSpecOnlineGiftShowInfo();
		resp.setOffsetX(tmpl.getOffsetX());
		resp.setOffsetY(tmpl.getOffsetY());
		resp.setCd(human.getSpecOnlineGiftManager().getCd());
		resp.setResType(tmpl.getResType());
		resp.setResId(tmpl.getResId());
		resp.setArtFontId(tmpl.getArtFontId());
		resp.setShowDesc(tmpl.getRewardDesc());
		resp.setReceiveDesc(tmpl.getReceiveDesc());
		human.sendMessage(resp);
	}
	
	/**
	 * 领取特殊在线礼包
	 * 
	 * @param human
	 */
	public void handleReceiveSpecOnlinegift(Human human){
		SpecOnlineGiftTemplate tmpl = human.getSpecOnlineGiftManager().getCurrReceiveOnlineGiftTemplate();
		if(tmpl == null){
			return;
		}
		
		if(!human.getSpecOnlineGiftManager().isOpening()){
			return;
		}
		if(human.getSpecOnlineGiftManager().getCd() > 0){
			Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.SPEC_ONLINE_GIFT);
			return;
		}
		
		human.getSpecOnlineGiftManager().next();
		int rewardId = tmpl.getRewardId();
		Reward reward = Globals.getRewardService().createReward(human.getUUID(), rewardId, "");
		Globals.getRewardService().giveReward(human, reward, false);
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.SPEC_ONLINE_GIFT);
		human.sendErrorMessage(reward.getRewardString());		
	}

	/**------ 	下面开始是每日签到的方法	-------**/
	
	/**
	 * 申请每日签到面板信息
	 * @param human
	 */
	public void applyDailyGiftPannelInfo(Human human) {
		if(human == null ){
			return ;
		}
		
		Calendar ca = Calendar.getInstance();
		ca.setTimeInMillis(Globals.getTimeService().now());
		//当前日期(几号)
		int n1 = ca.get(Calendar.DAY_OF_MONTH);
		
		//初始日期，本月1日 或者 是建号当天日期
		int initTime = 1; 
		if(TimeUtils.isInSameMonth(human.getCreateTime(), ca.getTimeInMillis())){
			ca.setTimeInMillis(human.getCreateTime());
			initTime = ca.get(Calendar.DAY_OF_MONTH);
		}
		
		//已经签到了的天数
		int n2 = human.getBehaviorManager().getCount(BehaviorTypeEnum.MONTH_SIGN_NUM);
		
		//今天签到的天数 1或者0 不算补签
		int n3 = human.getBehaviorManager().getCount(BehaviorTypeEnum.MONTH_SIGN_TODAY);
		
		//可以补签的天数 漏签的天数 = 应该签到的天数(当前日期 - 初始计算签到的日期/月初) 减去 （总签到数 减去 今天签到数）
		int canRetroactiveNum = (n1 - initTime) - (n2 - n3);
		
		//剩余的可以补签的次数
		int restNum = human.getBehaviorManager().getLeftCount(BehaviorTypeEnum.MONTH_SIGN_USED_RETROACTIVE_NUM);
		
		//可以使用的补签次数与可以补签的天数 取较小值 则为最后可以使用的补签次数
		int restRetroactiveNum =  canRetroactiveNum > restNum ? restNum : canRetroactiveNum;
		
		//封装消息
		GCDaliyGiftPannelApply gc = new GCDaliyGiftPannelApply();
		if(restRetroactiveNum > 0){
			gc.setCanUseRetroacte(1);
		}else{
			gc.setCanUseRetroacte(2);
		}
		gc.setRestRetroactiveNum(restNum);
		gc.setSignedNum(n2);
		gc.setRestRetroactiveNum(restRetroactiveNum);
		gc.setDaysOfMonth(TimeUtils.getCurrentMaxDaysOfMonth());
		gc.setIsAlreadySign(n3==0?2:1);
		//发送
		human.sendMessage(gc);
	}
	
	/**
	 * 申请签到信息
	 * @param human
	 */
	public void applyDailyGiftSign(Human human) {
		if(human == null ){
			return ;
		}
		
		//今天已经签到过了
		if(!human.getBehaviorManager().canDo(BehaviorTypeEnum.MONTH_SIGN_TODAY) 
				|| !human.getBehaviorManager().canDo(BehaviorTypeEnum.MONTH_SIGN_NUM)){
			human.sendErrorMessage(LangConstants.TODAY_IS_ALREADY_SIGN);
			return ;
		}
		
		//开始签到
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.MONTH_SIGN_TODAY);
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.MONTH_SIGN_NUM);
		
		DailySignGiftTemplate tpl = giftMap.get(human.getBehaviorManager().getCount(BehaviorTypeEnum.MONTH_SIGN_NUM));
		//发送奖励
		int rewardId = tpl.getRewardId();
		Reward reward = Globals.getRewardService().createReward(
				human.getCharId(),
				rewardId,
				"human gain dailySignGift reward!  petId="
						+ human.getUUID() 
						+ ",rewardId="
						+rewardId);
		Globals.getRewardService().giveReward(human, reward, true);
		
		//给vip额外奖励
		giveVipExtraReward(human, tpl);
		
		//发送消息
		applyDailyGiftPannelInfo(human);
		
		GCDaliyGiftSign gc = new GCDaliyGiftSign();
		gc.setResult(1);
		human.sendMessage(gc);
		
		//功能按钮变化
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.DAILY_SIGN);
	}
	
	/**
	 * 申请补签信息
	 * @param human
	 */
	public void applyRetroactiveDailyGiftSign(Human human) {
		if(human == null ){
			return ;
		}
		
		Calendar ca = Calendar.getInstance();
		ca.setTimeInMillis(Globals.getTimeService().now());
		//当前日期(几号)
		int n1 = ca.get(Calendar.DAY_OF_MONTH);
		
		//初始日期，本月1日 或者 是建号当天日期
		int initTime = 1; 
		if(TimeUtils.isInSameMonth(human.getCreateTime(), ca.getTimeInMillis())){
			ca.setTimeInMillis(human.getCreateTime());
			initTime = ca.get(Calendar.DAY_OF_MONTH);
		}
		
		//已经签到了的天数
		int n2 = human.getBehaviorManager().getCount(BehaviorTypeEnum.MONTH_SIGN_NUM);
		
		//今天签到的天数 1或者0 不算补签
		int n3 = human.getBehaviorManager().getCount(BehaviorTypeEnum.MONTH_SIGN_TODAY);
		
		//可以补签的天数
		int canRetroactiveNum = (n1 - initTime) - (n2 - n3);
		
		//剩余的可以补签的次数
		int restNum = human.getBehaviorManager().getLeftCount(BehaviorTypeEnum.MONTH_SIGN_USED_RETROACTIVE_NUM);
			
		//可以使用的补签次数与可以补签的天数 取较小值
		int restRetroactiveNum =  canRetroactiveNum > restNum ? restNum : canRetroactiveNum;
				
		//补签次数判断
		if(restRetroactiveNum<=0 || !human.getBehaviorManager().canDo(BehaviorTypeEnum.MONTH_SIGN_NUM)){
			human.sendErrorMessage(LangConstants.CAN_NOT_RETROACTIVE);
			return ;
		}	
		
		//开始签到
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.MONTH_SIGN_NUM);
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.MONTH_SIGN_USED_RETROACTIVE_NUM);
		
		DailySignGiftTemplate tpl = giftMap.get(human.getBehaviorManager().getCount(BehaviorTypeEnum.MONTH_SIGN_NUM));
		//发送奖励
		int rewardId = tpl.getRewardId();
		Reward reward = Globals.getRewardService().createReward(
				human.getCharId(),
				rewardId,
				"human gain dailySignGift reward!  petId="
						+ human.getUUID() 
						+ ",rewardId="
						+rewardId);
		Globals.getRewardService().giveReward(human, reward, true);
		
		//给vip额外奖励
		giveVipExtraReward(human, tpl);
		
		//发送消息
		applyDailyGiftPannelInfo(human);
		GCDaliyGiftRetroactive gc = new GCDaliyGiftRetroactive();
		gc.setResult(1);
		human.sendMessage(gc);
	}
	
	protected void giveVipExtraReward(Human human, DailySignGiftTemplate tpl) {
		//vip额外奖励
		if (Globals.getVipService().getCurVipLevel(human.getUUID()) < tpl.getVipLevelLimit()) {
			return;
		}
		
		//合并奖励
		List<Reward> rewardList = new ArrayList<Reward>();
		for (int i = 0; i < tpl.getVipRewardTimes(); i++) {
			Reward reward = Globals.getRewardService().createReward(human.getCharId(), tpl.getRewardId(), "sign vip extra");
			rewardList.add(reward);
		}
		//给奖励
		Globals.getRewardService().giveReward(human, Globals.getRewardService().mergeReward(rewardList), true);
	}
	
	/**
	 * 是否能领取签到奖励
	 * @param human
	 * @return
	 */
	public boolean canGetSignGift(Human human) {
		//可以签到
		if (human.getBehaviorManager().canDo(BehaviorTypeEnum.MONTH_SIGN_TODAY) 
				&& human.getBehaviorManager().canDo(BehaviorTypeEnum.MONTH_SIGN_NUM)) {
			return true;
		}
		return false;
	}
	
	/**
	 * 发送每日签到的奖励信息表
	 * @param human
	 */
	public void applyDailyGiftGiftList(Human human) {
		if(human == null ){
			return ;
		}
		human.sendMessage(gcMsg);
	}
	
	
}
