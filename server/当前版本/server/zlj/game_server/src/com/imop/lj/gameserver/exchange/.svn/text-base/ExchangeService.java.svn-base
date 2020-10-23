package com.imop.lj.gameserver.exchange;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;

public class ExchangeService implements InitializeRequired{

	@Override
	public void init() {
		
	}

	public void currencyExchange(Human human, int costId, int exchangeId, int exchangeNum){
		Currency costCurrency = Currency.valueOf(costId);
		if (costCurrency == null) {
			return;
		}
		
		int scale = Globals.getTemplateCacheService().getExchangeTemplateCache().getScale(costId, exchangeId);
		if(scale <= 0){
			Loggers.humanLogger.error("ExchangeService#currencyExchange get ExchangeTemplate return null!charId = " + human.getCharId()
		 	 +";costId = " + costId
			 +";exchangeId = " + exchangeId);
			return;
		}
		
		//花费货币数量
		long costNum = exchangeNum;
		//给货币数量
		long giveNum = exchangeNum * scale;
		
		//货币是否足够
		if (!human.hasEnoughMoney(costNum, costCurrency, false)) {
			human.sendErrorMessage(LangConstants.CURRENCY_EXCHANGE_FAIL);
			return;
		}
		
		//扣货币
		MoneyLogReason costReason = MoneyLogReason.CURRENCY_EXCHANGE_COST;
		String costDetail = LogUtils.genReasonText(costReason, 
				Globals.getLangService().readSysLang(costCurrency.getNameKey()),
				costNum+"");
		boolean costFlag = human.costMoney(costNum, costCurrency, true, 0, costReason, costDetail, 0);
		if (!costFlag) {
			return;
		}
		
		//给货币
		Currency giveCurrency = Currency.valueOf(exchangeId);
		if(giveCurrency == null){
			return;
		}
		MoneyLogReason giveReason = MoneyLogReason.CURRENCY_EXCHANGE_GIVE;
		String giveDetail = LogUtils.genReasonText(giveReason,
				Globals.getLangService().readSysLang(costCurrency.getNameKey()),
				giveNum+"");
		
		boolean giveFlag = human.giveMoney(giveNum, giveCurrency, true, giveReason, giveDetail);
		if (!giveFlag) {
			Loggers.humanLogger.error("ExchangeService#currencyExchange#giveMoney return false!roleId=" + human.getUUID());
		}
	}
}
