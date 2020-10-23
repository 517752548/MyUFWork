package com.imop.lj.gameserver.charge;

import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.charge.template.MonthCardTemplate;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.human.msg.GCMonthCardInfo;

public class MonthCardService implements InitializeRequired{

	@Override
	public void init() { 
		
	}
	
	public void noticeMonthCardInfo(Human human){
		GCMonthCardInfo msg = new GCMonthCardInfo();
		msg.setMonthFlag(this.isMonthCardState(human));
		msg.setGiftFlag(!human.getBehaviorManager().canDo(BehaviorTypeEnum.MONTH_CARD_GIFT_TODAY));
		msg.setLeftDay(this.calMonthCardLeftDay(human));
		
		human.sendMessage(msg);
	}
	
	public boolean canGetDayGift(Human human){
		if(isMonthCardState(human)){
			return human.getBehaviorManager().canDo(BehaviorTypeEnum.MONTH_CARD_GIFT_TODAY);
		}
		
		return false;
	}
	
	public void buyMonthCard(Human human, int tplId) {
		//获取模板
		MonthCardTemplate tpl = Globals.getTemplateCacheService().get(tplId, MonthCardTemplate.class);
		if(tpl == null){
			Loggers.humanLogger.error("MonthCardService#buyMonthCard#get monthCard tpl return null!charId =" + human.getCharId()
					+ ";tplId = "+ tplId);
			return;
		}
		
		//不可重复购买月卡
		if(isMonthCardState(human)){
			return;
		}
		
		//金子是否足够
		if(!human.hasEnoughMoney(tpl.getMonthCurrNum(), Currency.valueOf(tpl.getMonthCurrId()), true)){
			return;
		}
		
		//扣除金子
		String costReason = MoneyLogReason.BUY_MONTH_CARD_COST.getReasonText();
		costReason = MessageFormat.format(costReason, Globals.getLangService().readSysLang(Currency.valueOf(tpl.getMonthCurrId()).getNameKey()), 
				tpl.getMonthCurrNum());
		if (!human.costMoney(tpl.getMonthCurrNum(), Currency.valueOf(tpl.getMonthCurrId()),
				true, 0, MoneyLogReason.BUY_MONTH_CARD_COST, costReason, 0)) {
			return;
		}
		
		//给金票
		String giveReason = MoneyLogReason.BUY_MONTH_CARD_REBATE.getReasonText();
		giveReason = MessageFormat.format(giveReason, Globals.getLangService().readSysLang(Currency.valueOf(tpl.getRebateCurrId()).getNameKey()), 
				tpl.getRebateCurrNum());
		if(!human.giveMoney(tpl.getRebateCurrNum(), Currency.valueOf(tpl.getRebateCurrId()), true, MoneyLogReason.BUY_MONTH_CARD_REBATE, giveReason)){
			return;
		}
		
		//更新月卡信息
		human.setBuyMonthCardTime(Globals.getTimeService().now());
		human.setModified();
		
		//功能更新
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MONTH_CARD);
		
		this.noticeMonthCardInfo(human);
	}

	public void getMonthCardGift(Human human) {
		//必须是月卡状态,才可以领取
		if(!isMonthCardState(human)){
			return;
		}
		
		//是否已经领取
		if(!human.getBehaviorManager().canDo(BehaviorTypeEnum.MONTH_CARD_GIFT_TODAY)){
			return;
		}
		
		human.getBehaviorManager().doBehavior(BehaviorTypeEnum.MONTH_CARD_GIFT_TODAY);
		
		//获取模板
		MonthCardTemplate tpl = null;
		List<MonthCardTemplate> lst = new ArrayList<MonthCardTemplate>();
		lst.addAll(Globals.getTemplateCacheService().getAll(MonthCardTemplate.class).values());
		tpl = lst.get(0);
		
		if(tpl == null){
			Loggers.humanLogger.error("MonthCardService#buyMonthCard#get monthCard tpl return null!charId =" + human.getCharId());
			return;
		}
		
		//给金票
		String giveReason = MoneyLogReason.MONTH_CARD_GIFT.getReasonText();
		giveReason = MessageFormat.format(giveReason, Globals.getLangService().readSysLang(Currency.valueOf(tpl.getDayRebateCurrId()).getNameKey()), 
				tpl.getDayRebateCurrNum());
		if(!human.giveMoney(tpl.getDayRebateCurrNum(), Currency.valueOf(tpl.getDayRebateCurrId()), true, MoneyLogReason.MONTH_CARD_GIFT, giveReason)){
			return;
		}
		
		this.noticeMonthCardInfo(human);
		
		//功能更新
		Globals.getFuncService().onFuncChanged(human, FuncTypeEnum.MONTH_CARD);
	}
	
	protected int calMonthCardLeftDay(Human human) {
		int leftDay = 0;
		if(!isMonthCardState(human)){
			leftDay = Globals.getGameConstants().getMonthCardDayNum();
		}else{
			leftDay = Globals.getGameConstants().getMonthCardDayNum() - 
					TimeUtils.getSoFarWentDays(human.getBuyMonthCardTime(), Globals.getTimeService().now());
		}
		
		if(leftDay < 0){
			leftDay = 0;
		}
		
		return leftDay;
		 
	}
	
	protected boolean isMonthCardState(Human human) {
		if(human.getBuyMonthCardTime() > 0 
				&& Globals.getTimeService().now() < TimeUtils.getDeadLine(
						TimeUtils.getEndOfDay(human.getBuyMonthCardTime()),
						Globals.getGameConstants().getMonthCardDayNum(),
						TimeUtils.DAY) ){
			return true;
		}
		
		return false;
	}

	
}
