package com.imop.lj.gameserver.onlinegift.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.onlinegift.msg.CGDaliyGiftListApply;
import com.imop.lj.gameserver.onlinegift.msg.CGDaliyGiftPannelApply;
import com.imop.lj.gameserver.onlinegift.msg.CGDaliyGiftRetroactive;
import com.imop.lj.gameserver.onlinegift.msg.CGDaliyGiftSign;
import com.imop.lj.gameserver.onlinegift.msg.CGGetOnlinegiftInfo;
import com.imop.lj.gameserver.onlinegift.msg.CGGetSpecOnlineGiftShowInfo;
import com.imop.lj.gameserver.onlinegift.msg.CGReceiveOnlinegift;
import com.imop.lj.gameserver.onlinegift.msg.CGReceiveSpecOnlineGift;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class OnlinegiftMessageHandler {	
	
	
	public OnlinegiftMessageHandler() {	
	}	
	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.DAILY_SIGN)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.DAILY_SIGN);
			return false;
		}
		return true;
	}
	
	/**
 	* 申请每日签到奖励信息
 	* 
 	* CodeGenerator
 	*/
	public void handleDaliyGiftListApply(Player player, CGDaliyGiftListApply cgDaliyGiftListApply) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		Globals.getOnlineGiftService().applyDailyGiftGiftList(player.getHuman());
	}
	
	
		/**
 	* 申请每日签到面板信息
 	* 
 	* CodeGenerator
 	*/
	public void handleDaliyGiftPannelApply(Player player, CGDaliyGiftPannelApply cgDaliyGiftPannelApply) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		Globals.getOnlineGiftService().applyDailyGiftPannelInfo(player.getHuman());
	}
		/**
 	* 申请签到
 	* 
 	* CodeGenerator
 	*/
	public void handleDaliyGiftSign(Player player, CGDaliyGiftSign cgDaliyGiftSign) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		Globals.getOnlineGiftService().applyDailyGiftSign(player.getHuman());
		
	}
		/**
 	* 申请补签
 	* 
 	* CodeGenerator
 	*/
	public void handleDaliyGiftRetroactive(Player player, CGDaliyGiftRetroactive cgDaliyGiftRetroactive) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		Globals.getOnlineGiftService().applyRetroactiveDailyGiftSign(player.getHuman());
	}
	
	/**
 	* 获取在线奖励信息
 	* 
 	* CodeGenerator
 	*/
	public void handleGetOnlinegiftInfo(Player player, CGGetOnlinegiftInfo cgGetOnlineGiftInfo) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		Globals.getOnlineGiftService().handleGetOnlinegiftInfo(player.getHuman());
	}
		/**
 	* 领取在线礼包
 	* 
 	* CodeGenerator
 	*/
	public void handleReceiveOnlinegift(Player player, CGReceiveOnlinegift cgReceiveOnlineGift) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		Globals.getOnlineGiftService().handleReceiveOnlinegift(player.getHuman());
	}

	/**
 	* 获取特殊在线奖励信息
 	* 
 	* CodeGenerator
 	*/
	public void handleReceiveSpecOnlineGift(Player player, CGReceiveSpecOnlineGift cgReceiveSpecOnlineGift) {
		// TODO Auto-generated method stub
		
	}

	/**
 	* 领取特殊在线礼包
 	* 
 	* CodeGenerator
 	*/
	public void handleGetSpecOnlineGiftShowInfo(Player player,
			CGGetSpecOnlineGiftShowInfo cgGetSpecOnlineGiftShowInfo) {
		// TODO Auto-generated method stub
		
	}
	}
