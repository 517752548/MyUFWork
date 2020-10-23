
package com.imop.lj.gameserver.humanskill.handler;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.humanskill.msg.CGHsMainSkillUpgrade;
import com.imop.lj.gameserver.humanskill.msg.CGHsOpenPanel;
import com.imop.lj.gameserver.humanskill.msg.CGHsSubSkillAddProficiency;
import com.imop.lj.gameserver.humanskill.msg.CGHsSubSkillUpgrade;
import com.imop.lj.gameserver.player.Player;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class HumanskillMessageHandler {	
	
	public HumanskillMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.MINDSKILL)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.MINDSKILL);
			return false;
		}
		return true;
	}
	
	/**
	 * 打开心法技能面板
	 * @param player
	 * @param cgHsOpenPanel
	 */
	public void handleHsOpenPanel(Player player, CGHsOpenPanel cgHsOpenPanel) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getHumanSkillService().openHsPanel(player.getHuman());
	}
	
		/**
 	* 心法升级
 	* 
 	* CodeGenerator
 	*/
	public void handleHsMainSkillUpgrade(Player player, CGHsMainSkillUpgrade cgHsMainSkillUpgrade) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		//是否批量
		int type = cgHsMainSkillUpgrade.getIsBatch();
		if(type > 2 || type < 0){
			return;
		}
		boolean isBatch = type == 1 ? true : false;
		
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getHumanSkillService().upgradeMainSkill(player.getHuman(), cgHsMainSkillUpgrade.getMindId(), isBatch);
	}
		/**
 	* 人物技能升级
 	* 
 	* CodeGenerator
 	*/
	public void handleHsSubSkillUpgrade(Player player, CGHsSubSkillUpgrade cgHsSubSkillUpgrade) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		if(cgHsSubSkillUpgrade.getItemId()<=0){
			return ;
		}
		
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getHumanSkillService().upgradeOrStudySubSkill(player.getHuman(),cgHsSubSkillUpgrade.getItemId());
	}

	public void handleHsSubSkillAddProficiency(Player player, CGHsSubSkillAddProficiency cgHsSubSkillAddProficiency) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		if(cgHsSubSkillAddProficiency.getSkillId()<=0){
			return ;
		}
		
		Globals.getHumanSkillService().addSkillProficiency(player.getHuman(), cgHsSubSkillAddProficiency.getSkillId());
	}
	
	
	
	
	}
