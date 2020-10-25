package com.imop.lj.gameserver.wing.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.wing.Wing;
import com.imop.lj.gameserver.wing.msg.CGWingPanel;
import com.imop.lj.gameserver.wing.msg.CGWingSet;
import com.imop.lj.gameserver.wing.msg.CGWingTakedown;
import com.imop.lj.gameserver.wing.msg.CGWingUpgrade;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class WingMessageHandler {	
	
	public WingMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.WING)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.WING);
			return false;
		}
		return true;
	}
		/**
 	* 打开翅膀面板
 	* 
 	* CodeGenerator
 	*/
	public void handleWingPanel(Player player, CGWingPanel cgWingPanel) {
		if (!checkRoleAndFunc(player)) {
			return ;
		}
		Globals.getWingService().openWingPanel(player.getHuman());
	}
		/**
 	* 卸下翅膀
 	* 
 	* CodeGenerator
 	*/
	public void handleWingTakedown(Player player, CGWingTakedown cgWingTakedown) {
		if (!checkRoleAndFunc(player)) {
			return ;
		}
		
		Globals.getWingService().taskDownWing(player.getHuman(),cgWingTakedown.getTemplateId());
	}
		/**
 	* 装备翅膀
 	* 
 	* CodeGenerator
 	*/
	public void handleWingSet(Player player, CGWingSet cgWingSet) {
		if (!checkRoleAndFunc(player)) {
			return ;
		}
		
		Globals.getWingService().useWing(player.getHuman(),cgWingSet.getTemplateId());
	}
		/**
 	* 升阶翅膀
 	* 
 	* CodeGenerator
 	*/
	public void handleWingUpgrade(Player player, CGWingUpgrade cgWingUpgrade) {
		if (!checkRoleAndFunc(player)) {
			return ;
		}
		//翅膀最大上限
		Wing w =player.getHuman().getWingManager().getWingByTemplateId(cgWingUpgrade.getTemplateId());
		if (null == w) {
			return ;
		}
		if (w.getWingLevel() == Globals.getGameConstants().getWingMaxLevel()) {
			return ;
		}
		
		Globals.getWingService().upgradeWing(player.getHuman(),w,cgWingUpgrade.getTemplateId()
				,cgWingUpgrade.getUpgradeType());
	}
	}
