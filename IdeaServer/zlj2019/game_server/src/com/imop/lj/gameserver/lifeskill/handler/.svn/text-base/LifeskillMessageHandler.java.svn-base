package com.imop.lj.gameserver.lifeskill.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.lifeskill.msg.CGCancelLifeSkill;
import com.imop.lj.gameserver.lifeskill.msg.CGLifeSkillUpgrade;
import com.imop.lj.gameserver.lifeskill.msg.CGUseLifeSkill;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class LifeskillMessageHandler {	
	
	public LifeskillMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player, FuncTypeEnum funcType){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), funcType)) {
			Loggers.humanLogger.warn("player not open func " + funcType);
			return false;
		}
		return true;
	}
	
	/**
	 * 生活技能升级
	 * @param player
	 * @param cgLifeSkillUpgrade
	 */
	public void handleLifeSkillUpgrade(Player player, CGLifeSkillUpgrade cgLifeSkillUpgrade) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.LIFE_SKILL)){
			return;
		}
		
		Globals.getLifeSkillService().upgradeLifeSkill(player.getHuman(), cgLifeSkillUpgrade.getItemId());
	}
	
	/**
	 * 使用生活技能
	 * @param player
	 * @param cgUseLifeSkill
	 */
	public void handleUseLifeSkill(Player player, CGUseLifeSkill cgUseLifeSkill) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.LIFE_SKILL)){
			return;
		}
		
		Globals.getLifeSkillService().useLifeSkill(player.getHuman(), cgUseLifeSkill.getSkillId(), cgUseLifeSkill.getResourceId(), true);
	}

	
	/**
	 * 取消采集
	 * @param player
	 * @param cgCancelLifeSkill
	 */
	public void handleCancelLifeSkill(Player player, CGCancelLifeSkill cgCancelLifeSkill) {
		if(!checkRoleAndFunc(player, FuncTypeEnum.LIFE_SKILL)){
			return;
		}
		
		Globals.getLifeSkillService().cancelLifeSkill(player.getHuman(), false);
	}
	
	}
