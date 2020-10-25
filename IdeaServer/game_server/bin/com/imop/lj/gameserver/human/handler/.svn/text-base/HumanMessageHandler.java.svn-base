package com.imop.lj.gameserver.human.handler;

import java.text.MessageFormat;

import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.behavior.template.BehaviorBuyPowerCostTemplate;
import com.imop.lj.gameserver.cd.CdTypeEnum;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.msg.CGAddCd;
import com.imop.lj.gameserver.human.msg.CGBuyMonthCard;
import com.imop.lj.gameserver.human.msg.CGBuyPower;
import com.imop.lj.gameserver.human.msg.CGBuyPowerTips;
import com.imop.lj.gameserver.human.msg.CGChannelExchange;
import com.imop.lj.gameserver.human.msg.CGChargeGmTest;
import com.imop.lj.gameserver.human.msg.CGCurrencyExchange;
import com.imop.lj.gameserver.human.msg.CGDay7TaskFinish;
import com.imop.lj.gameserver.human.msg.CGFuncUpdate;
import com.imop.lj.gameserver.human.msg.CGGetMonthCardGift;
import com.imop.lj.gameserver.human.msg.CGKillCdTime;
import com.imop.lj.gameserver.human.msg.CGMonthCardInfo;
import com.imop.lj.gameserver.human.msg.CGOfflinerewardGet;
import com.imop.lj.gameserver.human.msg.CGOfflinerewardInfo;
import com.imop.lj.gameserver.human.msg.CGVipGetDayReward;
import com.imop.lj.gameserver.human.msg.CGXianhuGive;
import com.imop.lj.gameserver.human.msg.CGXianhuOpen;
import com.imop.lj.gameserver.human.msg.CGXianhuPanel;
import com.imop.lj.gameserver.human.msg.CGXianhuRankList;
import com.imop.lj.gameserver.human.msg.CGXianhuRankReward;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.async.PlayerUseCodeExchange;
import com.imop.lj.gameserver.xianhu.XianhuDef.XianhuRankType;

public class HumanMessageHandler {


	/**
	 * 处理清除冷却队列时间消息
	 *
	 * @param player
	 * @param cgKillCdTime
	 */
	public void handleKillCdTime(Player player, CGKillCdTime cgKillCdTime) {
	
	}

	/**
	 * 增加冷却队列
	 *
	 * @param player
	 * @param cgAddCd
	 */
	public void handleAddCd(Player player, CGAddCd cgAddCd) {

	}

	/**
	 * 返回要操作的提示信息框。cdtypeenum和consumeconfirm做对应
	 *
	 * @param cdType
	 * @return
	 */
	static ConsumeConfirm returnConsumeConfirmType(CdTypeEnum cdType) {
		ConsumeConfirm refreshEnumType = null;
		switch (cdType) {
//		case branchupdate:
//			refreshEnumType = ConsumeConfirm.BRANCHUPDATE_CD;
//			break;
//		case levy:
//			refreshEnumType = ConsumeConfirm.LEVY_CD;
//			break;
//		case refreshemployee:
//
//			refreshEnumType = ConsumeConfirm.REFRESHEMPLOYEE_CD;
//			// usageLangId = LangConstants.EMPLOYEE_REFRESH_MUCH_REASON;
//			break;
//		case weaponsUpgrade:
//
//			refreshEnumType = ConsumeConfirm.WEAPONSUPGRADE_CD;
//			// usageLangId = LangConstants.EMPLOYEE_REFRESH_STAR_REASON;
//			break;
//		case rapidTraining:
//			refreshEnumType = ConsumeConfirm.RAPIDTRAINING_CD;
//			break;
//		case arenabattle:
//			refreshEnumType = ConsumeConfirm.ARENA_BATTLE_CD;
//			break;
//		case escortattack:
//			refreshEnumType = ConsumeConfirm.ESCORT_ATTACK_CD;
//			break;
		default:
			return refreshEnumType;
		}
//		return refreshEnumType;
	}
	
	/**
	 * 客户端请求更新一个按钮的状态
	 * @param player
	 * @param cgFuncUpdate
	 */
	public void handleFuncUpdate(Player player, CGFuncUpdate cgFuncUpdate) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		FuncTypeEnum funcType = FuncTypeEnum.valueOf(cgFuncUpdate.getFuncType());
		if (null == funcType) {
			return;
		}
		
		Globals.getFuncService().onFuncChanged(player.getHuman(), funcType);
	}
	
	/**
	 * 显示一个离线奖励的详细信息
	 * @param player
	 * @param cgOfflinerewardInfo
	 */
	public void handleOfflinerewardInfo(Player player, CGOfflinerewardInfo cgOfflinerewardInfo) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		FuncTypeEnum funcType = FuncTypeEnum.valueOf(cgOfflinerewardInfo.getFuncTypeId());
		if (null == funcType) {
			return;
		}
		
		Globals.getOfflineRewardService().showOfflineRewardInfoByFunc(player.getHuman(), funcType);
	}
	
	/**
	 * 领取一个离线奖励
	 * @param player
	 * @param cgOfflinerewardGet
	 */
	public void handleOfflinerewardGet(Player player, CGOfflinerewardGet cgOfflinerewardGet) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		FuncTypeEnum funcType = FuncTypeEnum.valueOf(cgOfflinerewardGet.getFuncTypeId());
		if (null == funcType) {
			return;
		}
		
		Globals.getOfflineRewardService().giveLastOfflineRewardByFunc(player.getHuman(), funcType);
	}
	
	
	/**
	 * 购买体力
	 * @param player
	 * @param cgBuyPower
	 */
	public void handleBuyPower(Player player, CGBuyPower cgBuyPower) {
		//目前没这个功能，先干掉
		return;
//		if(player == null){
//			return;
//		}
//		
//		Human human = player.getHuman();
//		if(human == null){
//			return;
//		}
//		
//		// 是否有可购买次数
//		if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.BUY_POWER_NUM)) {
//			human.sendErrorMessage(LangConstants.BUY_POWER_FAIL_NOT_ENOUGH_TIMES);
//			return;
//		}
//		
//		// 体力是否已满
//		if (human.getPower() >= Globals.getGameConstants().getSysPowerBuyMax()) {
//			human.sendErrorMessage(LangConstants.BUY_POWER_FAIL_REACH_MAX);
//			return;
//		}
//
//		int costBond = getBuyPowerCost(human);
//		int leftCount = human.getBehaviorManager().getLeftCount(BehaviorTypeEnum.BUY_POWER_NUM);
//		
//		// 二次确认框
//		IStaticHandler buyPowerHandler = new BuyPowerStaticHandler();
//		if (human.getConsumeConfirm(ConsumeConfirm.BUY_POWER_NUM)) {
//			buyPowerHandler.exec(human, true);
//		} else {
//			human.getStaticHandlelHolder().setHandler(buyPowerHandler);
//			human.sendOptionDialogMessage(human.getStaticHandlelHolder().getTag(), "",
//					Globals.getLangService().readSysLang(LangConstants.CONFIRM_OK_TEXT), 
//					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CANCEL_TEXT), 
//					Globals.getLangService().readSysLang(LangConstants.CONFIRM_CONFIRM_TEXT), 
//					LangConstants.BUY_POWER_NUM_CONFIRM, 
//					leftCount, costBond, Globals.getGameConstants().getSysBuyPowerNum()
//					);
//		}
	}
	
	/**
	 * 获取购买体力的花费
	 * @param human
	 * @return
	 */
	protected int getBuyPowerCost(Human human) {
		int cost = 0;
		int count = getNextBuyPowerCount(human);
		BehaviorBuyPowerCostTemplate tpl = Globals.getTemplateCacheService().get(count, BehaviorBuyPowerCostTemplate.class);
		if (null != tpl) {
			cost = tpl.getBuyPowerCost();
		}
		return cost;
	}
	
	protected int getNextBuyPowerCount(Human human) {
		return human.getBehaviorManager().getCount(BehaviorTypeEnum.BUY_POWER_NUM) + 1;
	}
	
	protected long getAddPower(Human human) {
		return Math.min(Globals.getGameConstants().getSysBuyPowerNum(), 
				Globals.getGameConstants().getSysPowerBuyMax() - human.getPower());
	}
	
	/**
	 * 确认购买体力
	 * @param human
	 */
	public void buyPowerConfirm(Human human) {
		if(human == null){
			return;
		}
		
		// 是否有可购买次数
		if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.BUY_POWER_NUM)) {
			human.sendErrorMessage(LangConstants.BUY_POWER_FAIL_NOT_ENOUGH_TIMES);
			return;
		}
		
		// 体力是否已满
		if (human.getPower() >= Globals.getGameConstants().getSysPowerBuyMax()) {
			human.sendErrorMessage(LangConstants.BUY_POWER_FAIL_REACH_MAX);
			return;
		}
		
		int costBond = getBuyPowerCost(human);
		// 货币是否足够
		if (!human.hasEnoughMoney(costBond, Currency.GIFT_BOND, false)) {
			human.sendErrorMessage(LangConstants.BUY_POWER_FAIL_NOT_ENOUGH_MONEY);
			return;
		}
		
		// 增加体力值不能超过上限
		long addPower = getAddPower(human);
		if (addPower <= 0) {
			Loggers.humanLogger.error("#HumanMessageHandler#buyPowerConfirm#ERROR!addPower is invalide!addPower=" + 
					addPower + "; humanId=" + human.getCharId());
			return;
		}
		
		// 扣钱
		String detailReason = MoneyLogReason.BUY_POWER_NUM.getReasonText();
		detailReason = MessageFormat.format(detailReason, getNextBuyPowerCount(human), addPower);
		boolean flag = human.costMoney(costBond, Currency.GIFT_BOND, false, 0, MoneyLogReason.BUY_POWER_NUM, detailReason, 0);
		if (!flag) {
			Loggers.humanLogger.error("#HumanMessageHandler#buyPowerConfirm#costMoney return flase!addPower=" + 
					addPower + "; humanId=" + human.getCharId());
			return;
		}
		
		// 行为记录
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.BUY_POWER_NUM);
		
		// 加体力
		String detailReasonGivePower = MoneyLogReason.BUY_POWER_NUM_GIVE.getReasonText();
		detailReasonGivePower = MessageFormat.format(detailReasonGivePower, getNextBuyPowerCount(human), addPower);
		human.giveMoney(addPower, Currency.POWER, false, MoneyLogReason.BUY_POWER_NUM_GIVE, detailReason);

		// 提示成功
		human.sendErrorMessage(LangConstants.BUY_POWER_OK, addPower);
		
//		// 每日必做
//		Globals.getEveryDayTargetService().doTarget(human, EveryDayTargetEnum.BUY_POWER, 1);
			
	}
	
	/**
	 * 购买体力的tips
	 * @param player
	 * @param cgBuyPowerTips
	 */
	public void handleBuyPowerTips(Player player, CGBuyPowerTips cgBuyPowerTips) {
		//目前没这个功能，先干掉
		return;
//		if(player == null){
//			return;
//		}
//		
//		Human human = player.getHuman();
//		if(human == null){
//			return;
//		}
//		
//		String tips = "";
//		if (!human.getBehaviorManager().canDo(BehaviorTypeEnum.BUY_POWER_NUM)) {
//			// 是否还有可购买次数
//			tips = Globals.getLangService().readSysLang(LangConstants.BUY_POWER_FAIL_NOT_ENOUGH_TIMES);
//		} else	if (human.getPower() >= Globals.getGameConstants().getSysPowerBuyMax()) {
//			// 体力是否已满
//			tips = Globals.getLangService().readSysLang(LangConstants.BUY_POWER_FAIL_REACH_MAX);
//		} else {
//			int costBond = getBuyPowerCost(human);
//			int leftCount = human.getBehaviorManager().getLeftCount(BehaviorTypeEnum.BUY_POWER_NUM);
//			long addPower = getAddPower(human);
//			tips = Globals.getLangService().readSysLang(LangConstants.BUY_POWER_TIPS, leftCount, costBond, addPower);
//		}
//		human.sendMessage(new GCBuyPowerTips(tips));
	}
	
	/**
	 * 通过兑换码兑奖励
	 * @param player
	 * @param cgChannelExchange
	 */
	public void handleChannelExchange(Player player, CGChannelExchange cgChannelExchange) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		String code = cgChannelExchange.getCode();
		if (code == null || code.isEmpty()) {
			return;
		}
		//兑换功能是否开启
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.CHANNEL_EXCHANGE)) {
			return;
		}
		//local是否开了
		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
			Loggers.playerLogger.error("#PrizeMessageHandler#handlePrizeActivationcode#isTurnOnLocalInterface is false!charId=" + player.getRoleUUID());
			return;
		}
		
		PlayerUseCodeExchange operation = new PlayerUseCodeExchange(player.getRoleUUID(), player.getClientIp(), code);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(operation, player.getRoleUUID());
	}
	
	/**
	 * 领取每日vip奖励
	 * @param player
	 * @param cgVipGetDayReward
	 */
	public void handleVipGetDayReward(Player player, CGVipGetDayReward cgVipGetDayReward) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		Globals.getVipService().giveDayReward(player.getHuman());
	}
	
	/**
	 * 充值的测试消息 TODO FIXME
	 * @param player
	 * @param cgChargeGmTest
	 */
	public void handleChargeGmTest(Player player, CGChargeGmTest cgChargeGmTest) {
//		if (player == null || player.getHuman() == null) {
//			return;
//		}
//		
//		Globals.getChargeLogicalProcessor().gmCharge(player.getHuman(), cgChargeGmTest.getTplId());
	}
	
	/**
	 * 七日目标领取奖励
	 * @param player
	 * @param cgDay7TaskFinish
	 */
	public void handleDay7TaskFinish(Player player, CGDay7TaskFinish cgDay7TaskFinish) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (cgDay7TaskFinish.getQuestId() <= 0) {
			return;
		}
		
		Globals.getDay7TargetService().finishTask(player.getHuman(), cgDay7TaskFinish.getQuestId());
	}
	
	/**
	 * 打开仙葫面板
	 * @param player
	 * @param cgXianhuPanel
	 */
	public void handleXianhuPanel(Player player, CGXianhuPanel cgXianhuPanel) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		//功能是否开启
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.XIANHU)) {
			return;
		}
		
		Globals.getXianhuService().openXianhuPanel(player.getHuman());
	}
	
	/**
	 * 开启仙葫
	 * @param player
	 * @param cgXianhuOpen
	 */
	public void handleXianhuOpen(Player player, CGXianhuOpen cgXianhuOpen) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		//功能是否开启
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.XIANHU)) {
			return;
		}
		
		if (cgXianhuOpen.getOpenType() == 0) {
			Globals.getXianhuService().playZhufu(player.getHuman());
		} else {
			Globals.getXianhuService().playQifu(player.getHuman());
		}
	}
	
	/**
	 * 领取富贵、至尊仙葫
	 * @param player
	 * @param cgXianhuGive
	 */
	public void handleXianhuGive(Player player, CGXianhuGive cgXianhuGive) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		//功能是否开启
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.XIANHU)) {
			return;
		}
		
		boolean isZhizun =  cgXianhuGive.getGiveType() != 0;
		Globals.getXianhuService().giveExtraReward(player.getHuman(), isZhizun);
	}
	
	/**
	 * 领取仙葫排名奖励
	 * @param player
	 * @param cgXianhuRankReward
	 */
	public void handleXianhuRankReward(Player player, CGXianhuRankReward cgXianhuRankReward) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		XianhuRankType type = XianhuRankType.valueOf(cgXianhuRankReward.getRankType());
		if (type == null) {
			return;
		}
		
		Globals.getXianhuService().giveRankReward(player.getHuman(), type);
	}
	
	/**
	 * 显示仙葫排行榜
	 * @param player
	 * @param cgXianhuRankList
	 */
	public void handleXianhuRankList(Player player, CGXianhuRankList cgXianhuRankList) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		XianhuRankType type = XianhuRankType.valueOf(cgXianhuRankList.getRankType());
		if (type == null) {
			return;
		}
		
		Globals.getXianhuService().showRankPanel(player.getHuman(), type);
	}
	
	/**
	 * 货币兑换，金子兑换银子，金票兑换银票
	 * @param player
	 * @param cgCurrencyExchange
	 */
	public void handleCurrencyExchange(Player player, CGCurrencyExchange cgCurrencyExchange) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		int costId = cgCurrencyExchange.getCostId();
		Currency costCurrency = Currency.valueOf(costId);
		if (costCurrency == null) {
			return;
		}
		
		int exchangeId = cgCurrencyExchange.getExchangeId();
		Currency giveCurrency = Currency.valueOf(exchangeId);
		if (giveCurrency == null) {
			return;
		}
		
		int exchangeNum = cgCurrencyExchange.getExchangeNum();
		if (exchangeNum <= 0) {
			return;
		}
		
		Globals.getExchangeService().currencyExchange(player.getHuman(), costId, exchangeId, exchangeNum);
		
	}

	/**
	 * 购买月卡
	 * @param player
	 * @param cgBuyMonthCard
	 */
	public void handleBuyMonthCard(Player player, CGBuyMonthCard cgBuyMonthCard) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		int tplId = cgBuyMonthCard.getTplId();
		if(tplId <= 0){
			return;
		}
		
		Globals.getMonthCardService().buyMonthCard(player.getHuman(), tplId);
	}

	/**
	 * 领取月卡返利
	 * @param player
	 * @param cgGetMonthCardGift
	 */
	public void handleGetMonthCardGift(Player player, CGGetMonthCardGift cgGetMonthCardGift) {
		if (player == null || player.getHuman() == null) {
			return;
		}

		Globals.getMonthCardService().getMonthCardGift(player.getHuman());
	}

	/**
	 * 请求月卡信息
	 * @param player
	 * @param cgMonthCardInfo
	 */
	public void handleMonthCardInfo(Player player, CGMonthCardInfo cgMonthCardInfo) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getMonthCardService().noticeMonthCardInfo(player.getHuman());
	}
	
	
}
