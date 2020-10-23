package com.imop.lj.gameserver.mysteryshop.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.mysteryshop.msg.CGBuyMsItem;
import com.imop.lj.gameserver.mysteryshop.msg.CGFlushMystery;
import com.imop.lj.gameserver.mysteryshop.msg.CGReqMysteryShopInfo;
import com.imop.lj.gameserver.player.Player;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class MysteryshopMessageHandler {	
	
	public MysteryshopMessageHandler() {	
	}	
		/**
 	* 请求神秘商店信息
 	* 
 	* CodeGenerator
 	*/
	public void handleReqMysteryShopInfo(Player player, CGReqMysteryShopInfo cgReqMysteryShopInfo) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!isOpen(human)){
			Loggers.mysteryShopLogger.error("MysteryshopMessageHandler.handleReqMysteryShopInfo humanId = " + human.getUUID() + ", func not open");
			return;
		}
		
		Globals.getMysteryShopService().handleReqMysteryShopInfo(human);
	}
		/**
 	* 刷新神秘商店1：普通刷新2：Vip刷新
 	* 
 	* CodeGenerator
 	*/
	public void handleFlushMystery(Player player, CGFlushMystery cgFlushMystery) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!isOpen(human)){
			Loggers.mysteryShopLogger.error("MysteryshopMessageHandler.handleFlushMystery humanId = " + human.getUUID() + ", func not open");
			return;
		}
		
		Globals.getMysteryShopService().handleFlushMystery(human, cgFlushMystery.getFlushType(), true);
	}
		/**
 	* 购买神秘商店物品
 	* 
 	* CodeGenerator
 	*/
	public void handleBuyMsItem(Player player, CGBuyMsItem cgBuyMsItem) {
		if(player == null){
			return;
		}
		
		Human human = player.getHuman();
		if(!isOpen(human)){
			Loggers.mysteryShopLogger.error("MysteryshopMessageHandler.handleBuyMsItem humanId = " + human.getUUID() + ", func not open");
			return;
		}
		
		Globals.getMysteryShopService().handleBuyMsItem(human, cgBuyMsItem.getMsItemId(), true);
	}
	
	private boolean isOpen(Human human){
		if(human == null){
			Loggers.mysteryShopLogger.error("MysteryshopMessageHandler.isOpen human == null");
			return false;
		}
		//神秘商店开关
		if(!Globals.getMysteryShopService().isOpening()){
			return false;
		}
		
		return Globals.getFuncService().hasOpenedFunc(human, FuncTypeEnum.MYSTERY_SHOP);
	}
	}
