package com.imop.lj.gameserver.trade.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.currency.Currency;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.trade.TradeDef.CommodityType;
import com.imop.lj.gameserver.trade.TradeService;
import com.imop.lj.gameserver.trade.msg.CGTradeBoothinfo;
import com.imop.lj.gameserver.trade.msg.CGTradeBuy;
import com.imop.lj.gameserver.trade.msg.CGTradeSearch;
import com.imop.lj.gameserver.trade.msg.CGTradeSell;
import com.imop.lj.gameserver.trade.msg.CGTradeSimpleSearch;
import com.imop.lj.gameserver.trade.msg.CGTradeTakeOff;
import com.imop.lj.gameserver.trade.search.SimpleSearchInfo;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class TradeMessageHandler {

	public TradeMessageHandler() {
	}
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.TRADE)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.TRADE);
			return false;
		}
		return true;
	}
	
	/**
	 * 申请摊位信息
	 * 
	 * CodeGenerator
	 */
	public void handleTradeBoothinfo(Player player,
			CGTradeBoothinfo cgTradeBoothinfo) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		if (cgTradeBoothinfo == null) {
			return;
		}
		Globals.getTradeService().freshBoothInfo(player.getHuman());
	}

	/**
	 * 申请卖出商品
	 * 
	 * CodeGenerator
	 */
	public void handleTradeSell(Player player, CGTradeSell cgTradeSell) {
		if (!TradeService.isOpen()) {
			return;
		}
		
		if (!checkRoleAndFunc(player)) {
			return;
		}
		if (cgTradeSell == null) {
			return;
		}
		if (cgTradeSell.getBoothIndex() <= 0
				|| cgTradeSell.getBoothIndex() > Globals.getGameConstants()
						.getHumanBoothSize()) {
			return;
		}
		if (cgTradeSell.getCommodityId() == null) {
			return;
		}
		if (CommodityType.valueOf(cgTradeSell.getCommodityType()) == null
				|| CommodityType.valueOf(cgTradeSell.getCommodityType()) == CommodityType.NULL) {
			return;
		}
		//一次最多卖9999个
		if (cgTradeSell.getCommodityNum() <= 0 
				|| cgTradeSell.getCommodityNum() > Globals.getGameConstants().getItemMaxOverlapNum()) {
			return;
		}
		if (cgTradeSell.getCurrencyType() <= 0
				|| Currency.valueOf(cgTradeSell.getCurrencyType()) == null
				|| Currency.valueOf(cgTradeSell.getCurrencyType()) == Currency.NULL) {
			return;
		}
		if (cgTradeSell.getCurrencyNum() <= 0) {
			return;
		}
		Globals.getTradeService().sellCommodity(player.getHuman(),
				cgTradeSell.getBoothIndex(),
				Currency.valueOf(cgTradeSell.getCurrencyType()),
				cgTradeSell.getCurrencyNum(), cgTradeSell.getCommodityId(),
				cgTradeSell.getCommodityNum(), cgTradeSell.getCommodityType());
	}

	/**
	 * 商品查询
	 * 
	 * CodeGenerator
	 */
	public void handleTradeSearch(Player player, CGTradeSearch cgTradeSearch) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
	}

	/**
	 * 购买物品
	 * 
	 * CodeGenerator
	 */
	public void handleTradeBuy(Player player, CGTradeBuy cgTradeBuy) {
		if (!TradeService.isOpen()) {
			return;
		}
		
		if (!checkRoleAndFunc(player)) {
			return;
		}
		if (cgTradeBuy == null) {
			return;
		}
		if (cgTradeBuy.getSellerId() < 0L
				|| cgTradeBuy.getBoothIndex() <= 0
				|| cgTradeBuy.getCommodityId() == null
				|| cgTradeBuy.getCommodityId().equals("")
				|| CommodityType.valueOf(cgTradeBuy.getCommodityType()) == null
				|| CommodityType.valueOf(cgTradeBuy.getCommodityType()) == CommodityType.NULL) {
			return;
		}
		Globals.getTradeService().buyCommodity(player.getHuman(),
				CommodityType.valueOf(cgTradeBuy.getCommodityType()),
				cgTradeBuy.getSellerId(), cgTradeBuy.getBoothIndex(),
				cgTradeBuy.getCommodityId());
	}

	/**
	 * 申请下架物品
	 * 
	 * CodeGenerator
	 */
	public void handleTradeTakeOff(Player player, CGTradeTakeOff cgTradeTakeOff) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		if (cgTradeTakeOff == null) {
			return;
		}
		if (cgTradeTakeOff.getBoothIndex() < 0) {
			return;
		}
		if (CommodityType.valueOf(cgTradeTakeOff.getCommodityType()) == null
				|| CommodityType.valueOf(cgTradeTakeOff.getCommodityType()) == CommodityType.NULL) {
			return;
		}
		Globals.getTradeService().takeDownTrade(player.getHuman(),
				CommodityType.valueOf(cgTradeTakeOff.getCommodityType()),
				cgTradeTakeOff.getBoothIndex());
	}

	/**
	 * 简单商品查询
	 * 
	 * CodeGenerator
	 */
	public void handleTradeSimpleSearch(Player player,
			CGTradeSimpleSearch cgTradeSimpleSearch) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		if (cgTradeSimpleSearch == null) {
			return;
		}
		if (cgTradeSimpleSearch.getCommodityType() <= 0
				|| CommodityType.valueOf(cgTradeSimpleSearch.getCommodityType()) == null
				|| CommodityType.valueOf(cgTradeSimpleSearch.getCommodityType()) == CommodityType.NULL) {
			return;
		}
		if (cgTradeSimpleSearch.getEquipLevel() < -1) {
			return;
		}
		if (cgTradeSimpleSearch.getEquipColor() < -1) {
			return;
		}
		if (cgTradeSimpleSearch.getGemLevel() < -1) {
			return;
		}
		if (cgTradeSimpleSearch.getSortField() < 0) {
			return;
		}
		if (cgTradeSimpleSearch.getSortOrder() != 1 && cgTradeSimpleSearch.getSortOrder() != 2) {
			return;
		}
		if (cgTradeSimpleSearch.getPageNum() < 0) {
			return;
		}
		SimpleSearchInfo ssi = new SimpleSearchInfo(cgTradeSimpleSearch);
		if(!ssi.isValid()){
			return;
		}
		Globals.getTradeService().simpleTradeSearch(player.getHuman(),ssi);
	}
}
