package com.imop.lj.gameserver.wizardraid.handler;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.wizardraid.msg.CGWizardraidAnswerEnterTeam;
import com.imop.lj.gameserver.wizardraid.msg.CGWizardraidAskEnterTeam;
import com.imop.lj.gameserver.wizardraid.msg.CGWizardraidEnterSingle;
import com.imop.lj.gameserver.wizardraid.msg.CGWizardraidLeave;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class WizardraidMessageHandler {	
	
	public WizardraidMessageHandler() {	
	}	
		/**
 	* 请求进入单人副本
 	* 
 	* CodeGenerator
 	*/
	public void handleWizardraidEnterSingle(Player player, CGWizardraidEnterSingle cgWizardraidEnterSingle) {
		if (!checkFunc(player)) {
			return;
		}
		
		int raidId = cgWizardraidEnterSingle.getRaidId();
		if (raidId <= 0) {
			return;
		}
		
		Globals.getWizardRaidService().enterRaidSingle(player.getHuman(), raidId);
	}
		/**
 	* 队长请求进入组队副本
 	* 
 	* CodeGenerator
 	*/
	public void handleWizardraidAskEnterTeam(Player player, CGWizardraidAskEnterTeam cgWizardraidAskEnterTeam) {
		if (!checkFunc(player)) {
			return;
		}
		
		int raidId = cgWizardraidAskEnterTeam.getRaidId();
		if (raidId <= 0) {
			return;
		}
		
		Globals.getWizardRaidService().askEnterRaidTeam(player.getHuman(), raidId);
	}
		/**
 	* 应答进入组队副本的请求
 	* 
 	* CodeGenerator
 	*/
	public void handleWizardraidAnswerEnterTeam(Player player, CGWizardraidAnswerEnterTeam cgWizardraidAnswerEnterTeam) {
		if (!checkFunc(player)) {
			return;
		}
		
		boolean agree = cgWizardraidAnswerEnterTeam.getAgree() == 1 ? true : false;
		
		Globals.getWizardRaidService().answerEnterRaidTeam(player.getHuman(), agree);
	}
	
	/**
	 * 退出副本
	 * @param player
	 * @param cgWizardraidLeave
	 */
	public void handleWizardraidLeave(Player player, CGWizardraidLeave cgWizardraidLeave) {
		if (!checkFunc(player)) {
			return;
		}
		
		Globals.getWizardRaidService().leaveRaid(player.getHuman());
	}
	
	protected boolean checkFunc(Player player) {
		if (player == null || player.getHuman() == null) {
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.WIZARD_RAID)) {
			return false;
		}
		return true;
	}
	}
