
package com.imop.lj.gameserver.humanskill.handler;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.humanskill.msg.CGHsMainChange;
import com.imop.lj.gameserver.humanskill.msg.CGHsMainSkillUpgrade;
import com.imop.lj.gameserver.humanskill.msg.CGHsOpenPanel;
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
 	* 心法切换
 	* 
 	* CodeGenerator
 	*/
	public void handleHsMainChange(Player player, CGHsMainChange cgHsMainChange) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		if (cgHsMainChange.getType() <= 0) {
			return;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getHumanSkillService().changeMainSkillType(player.getHuman(), cgHsMainChange.getMainSkillType());
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
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getHumanSkillService().upgradeMainSkill(player.getHuman());
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
		if(cgHsSubSkillUpgrade.getSkillId()<=0){
			return ;
		}
		if(cgHsSubSkillUpgrade.getIsBatch()!=1 && cgHsSubSkillUpgrade.getIsBatch()!=2){
			return ;
		}
		//战斗中，不能进行此操作
		if (player.getHuman().isInAnyBattle()) {
			player.sendErrorMessage(LangConstants.BATTLE_NOT_ALLOW_OP);
			return;
		}
		Globals.getHumanSkillService().upgradeSubSkill(player.getHuman(),cgHsSubSkillUpgrade.getSkillId(),cgHsSubSkillUpgrade.getIsBatch()==1?true:false);
	}
	}
