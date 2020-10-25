package com.imop.lj.gameserver.item.operation.impl;

import java.text.MessageFormat;
import java.util.Collection;

import com.imop.lj.common.LogReasons.ItemLogReason;
import com.imop.lj.common.LogReasons.MoneyLogReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.item.Item;
import com.imop.lj.gameserver.item.ItemDef;
import com.imop.lj.gameserver.item.ItemDef.ConsumableFunc;
import com.imop.lj.gameserver.item.template.ConsumeItemTemplate;
import com.imop.lj.gameserver.role.Role;

/**
 * 给货币的道具，包括金银卡，体力丹等
 */
public class UseGiveMoney extends AbstractConsumeOperation {

	@Override
	protected <T extends Role> boolean useImpl(Human user, Item item, int count, T role) {
		if(count <= 0){
			return false;
		}
		
		ConsumeItemTemplate template = (ConsumeItemTemplate)item.getTemplate();
		int currencyId = template.getArgA();
		long currencyAmount = template.getArgB();
		Currency currency = Currency.valueOf(currencyId);
		if (currency == Currency.BOND) {
			// 不能给元宝
			Loggers.itemLogger.error("#UseGiveMoney#useImpl#can not give bond!");
			return false;
		}
		
		long canGiveNum = user.getCanGiveMoneyNum(currency);
		// 判断能否给货币，如果不能给，则给错误提示
		if (canGiveNum <= 0) {
			user.sendErrorMessage(LangConstants.USE_GIVE_MONEY_ITEM_FAIL, Globals.getLangService().readSysLang(currency.getNameKey()));
			return false;
		}
		
		long canUseNum = (long)Math.ceil(1D * canGiveNum / currencyAmount);
		int costNum = canUseNum < Integer.MAX_VALUE ? (int)canUseNum : Integer.MAX_VALUE;
		
		// 实际消耗道具数量
		count = Math.min(count, costNum);
		// 实际给货币数量
		currencyAmount = Math.min(currencyAmount * count, canGiveNum);
		
		// 扣道具
		String detailReason = MessageFormat.format(ItemLogReason.USED.getReasonText(), item.getTemplateId(),count, getConsumableFunc().getIndex());
		Collection<Item> itemList = user.getInventory().removeItem(item.getTemplateId(), count, ItemLogReason.USED, detailReason, true);
		if(itemList.isEmpty()){
			// 扣道具失败，记录错误日志
			Loggers.itemLogger.error("#UseGiveMoney#useImpl#removeItem return empty!humanId=" + user.getUUID() + 
					";itemTplId=" + item.getTemplateId() + ";canUseNum=" + canUseNum + ";canGiveNum=" + canGiveNum);
			return false;
		}
		
		// 给货币
		String detailReasonMoney = MessageFormat.format(MoneyLogReason.OPEN_CONSUMABLE_GIVE_MONEY_ITEM.getReasonText(), item.getTemplateId(),count, currencyId,currencyAmount);
		boolean giveMoneyFlag = user.giveMoney(currencyAmount, currency, true, MoneyLogReason.OPEN_CONSUMABLE_GIVE_MONEY_ITEM, detailReasonMoney);
		if (!giveMoneyFlag) {
			// 给货币失败，记录错误日志
			Loggers.itemLogger.error("#UseGiveMoney#useImpl#giveMoney return false!humanId=" + user.getUUID() + 
					";itemTplId=" + item.getTemplateId() + ";canUseNum=" + canUseNum + ";canGiveNum=" + canGiveNum);
		}
		return true;
	}

	@Override
	public ConsumableFunc getConsumableFunc() {
		return ItemDef.ConsumableFunc.GIVE_MONEY;
	}
	
}
