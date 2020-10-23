package com.imop.lj.gameserver.lifeskill.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.lifeskill.msg.CGLsMineGetPannel;
import com.imop.lj.gameserver.lifeskill.msg.CGLsMineStart;
import com.imop.lj.gameserver.lifeskill.msg.CGLsMineGain;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class LifeskillMessageHandler {	
	
	public LifeskillMessageHandler() {	
	}	
		/**
 	* 申请采矿界面
 	* 
 	* CodeGenerator
 	*/
	public void handleLsMineGetPannel(Player player, CGLsMineGetPannel cgLsMineGetPannel) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.MINE)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.MINE);
			return ;
		}
		Globals.getMineService().showMineInfos(player.getHuman());
	}
		/**
 	* 申请开始采矿
 	* 
 	* CodeGenerator
 	*/
	public void handleLsMineStart(Player player, CGLsMineStart cgLsMineStart) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.MINE)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.MINE);
			return ;
		}
		if(cgLsMineStart.getMineId()<0){
			return ;
		}
		if(cgLsMineStart.getMinerId() < 0){
			return ;
		}
		if(cgLsMineStart.getMiningTypeId()<0){
			return ;
		}
		if(cgLsMineStart.getPitId()<0){
			return ;
		}
		Globals.getMineService().startMining(player.getHuman(),cgLsMineStart.getPitId(),cgLsMineStart.getMineId(),cgLsMineStart.getMinerId(),cgLsMineStart.getMiningTypeId());
	}
		/**
 	* 申请取得矿石
 	* 
 	* CodeGenerator
 	*/
	public void handleLsMineGain(Player player, CGLsMineGain cgLsMineGain) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.MINE)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.MINE);
			return ;
		}
		if(cgLsMineGain.getPitId() < 0){
			return ;
		}
		Globals.getMineService().gainMineReward(player.getHuman(), cgLsMineGain.getPitId());
	}
	}
