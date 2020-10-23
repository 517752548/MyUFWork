
package com.imop.lj.gameserver.mall.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mall.MallService;
import com.imop.lj.gameserver.mall.msg.CGItemListByCatalogid;
import com.imop.lj.gameserver.mall.msg.CGBuyExchangeItem;
import com.imop.lj.gameserver.mall.msg.CGBuyNormalItem;
import com.imop.lj.gameserver.mall.msg.CGBuyTimeLimitItem;
import com.imop.lj.gameserver.mall.msg.CGTimeLimitItemList;
import com.imop.lj.gameserver.player.Player;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class MallMessageHandler {	
	
	public MallMessageHandler() {	
	}	
		/**
 	* 根据标签ID获取物品列表
 	* 
 	* CodeGenerator
 	*/
	public void handleItemListByCatalogid(Player player, CGItemListByCatalogid cgItemListByCatalogid) {
		if(player == null){
			Loggers.mallLogger.error("MallMessageHandler.handleItemListByCatalogId player == null");
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isOpen(human)){
			Loggers.mallLogger.error("MallMessageHandler.handleItemListByCatalogId human id = " + player.getCharId() + "== null || func not open");
			return;
		}
		
		Globals.getMallService().handleItemListByCatalogid(human, cgItemListByCatalogid.getCatalogId());
	}
		/**
 	* 购买普通物品
 	* 
 	* CodeGenerator
 	*/
	public void handleBuyNormalItem(Player player, CGBuyNormalItem cgBuyNormalItem) {
		if (!MallService.isOpen()) {
			return;
		}
		
		if(player == null){
			Loggers.mallLogger.error("MallMessageHandler.handleBuyNormalItem player == null");
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isOpen(human)){
			Loggers.mallLogger.error("MallMessageHandler.handleBuyNormalItem human id = " + player.getCharId() + "== null || func not open");
			return;
		}
		
		Globals.getMallService().handleBuyNormalItem(human, cgBuyNormalItem.getMallItemId(), cgBuyNormalItem.getCount(), false);
	}
		/**
 	* 购买限时物品
 	* 
 	* CodeGenerator
 	*/
	public void handleBuyTimeLimitItem(Player player, CGBuyTimeLimitItem cgBuyTimeLimitItem) {
		if (!MallService.isOpen()) {
			return;
		}
		
		if(player == null){
			Loggers.mallLogger.error("MallMessageHandler.handleBuyTimeLimitItem player == null");
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isOpen(human)){
			Loggers.mallLogger.error("MallMessageHandler.handleBuyTimeLimitItem human id = " + player.getCharId() + "== null || func not open");
			return;
		}
		
		Globals.getMallService().handleBuyTimeLimitItem(human, cgBuyTimeLimitItem.getQueueUUID(), cgBuyTimeLimitItem.getMallItemId(), cgBuyTimeLimitItem.getCount(), false);
	}
	
	/**
 	* 请求限时抢购队列
 	* 
 	* CodeGenerator
 	*/
	public void handleTimeLimitItemList(Player player, CGTimeLimitItemList cgTimeLimitItemList) {
		if(player == null){
			Loggers.mallLogger.error("MallMessageHandler.handleTimeLimitItemList player == null");
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isOpen(human)){
			Loggers.mallLogger.error("MallMessageHandler.handleTimeLimitItemList human id = " + player.getCharId() + "== null || func not open");
			return;
		}
		
		Globals.getMallService().sendTimeLimitQueueInfo(human);
	}
	
	private boolean isOpen(Human human){
		if(human == null){
			return false;
		}
		return Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.MAIL);
	}
	
	/**
	 * 兑换商城物品
	 * @param player
	 * @param cgBuyExchangeItem
	 */
	public void handleBuyExchangeItem(Player player, CGBuyExchangeItem cgBuyExchangeItem) {
		if (!MallService.isOpen()) {
			return;
		}
		
		if(player == null){
			Loggers.mallLogger.error("MallMessageHandler.handleBuyExchangeItem player == null");
			return;
		}
		
		Human human = player.getHuman();
		if(!this.isOpen(human)){
			Loggers.mallLogger.error("MallMessageHandler.handleBuyExchangeItem human id = " + player.getCharId() + "== null || func not open");
			return;
		}
		
		Globals.getMallService().handleExchangeItem(human, cgBuyExchangeItem.getMallItemId(), cgBuyExchangeItem.getCount());
	}
	}
