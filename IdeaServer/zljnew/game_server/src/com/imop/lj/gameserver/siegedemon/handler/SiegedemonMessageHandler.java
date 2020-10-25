package com.imop.lj.gameserver.siegedemon.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.siegedemon.msg.CGGiveUpSiegedemontask;
import com.imop.lj.gameserver.siegedemon.msg.CGSiegedemonAnswerEnterTeam;
import com.imop.lj.gameserver.siegedemon.msg.CGSiegedemonAskEnterTeam;
import com.imop.lj.gameserver.siegedemon.msg.CGSiegedemonLeave;
import com.imop.lj.gameserver.task.TaskDef.QuestType;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class SiegedemonMessageHandler {	
	
	public SiegedemonMessageHandler() {	
	}	
	
	private boolean checkServiceInfo(Player player, int siegeType){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if(QuestType.indexOf(siegeType) == null ){
			Loggers.siegeDemonLogger.error("siegeType is invalid!" + siegeType);
			return false;
		}

		if (siegeType == QuestType.SIEGE_DEMON_NOMAL.getIndex()) {
			if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.SIEGE_DEMON_NORMAL)) {
				Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.SIEGE_DEMON_NORMAL);
				return false;
			}
		}
		
		if (siegeType == QuestType.SIEGE_DEMON_HARD.getIndex()) {
			if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.SIEGE_DEMON_HARD)) {
				Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.SIEGE_DEMON_HARD);
				return false;
			}
		}
		

		
		return true;
	}
	
		/**
 	* 放弃已接任务
 	* 
 	* CodeGenerator
 	*/
	public void handleGiveUpSiegedemontask(Player player, CGGiveUpSiegedemontask cgGiveUpSiegedemontask) {
		if(!checkServiceInfo(player, cgGiveUpSiegedemontask.getQuestType())){
			return;
		}
		
		Globals.getSiegeDemonTaskService().giveTask(player.getHuman(),cgGiveUpSiegedemontask.getQuestType());
	}

	/**
	 * 队长请求进入组队副本
	 * @param player
	 * @param cgSiegedemonAskEnterTeam
	 */
	public void handleSiegedemonAskEnterTeam(Player player, CGSiegedemonAskEnterTeam cgSiegedemonAskEnterTeam) {
		if(!checkServiceInfo(player, cgSiegedemonAskEnterTeam.getSiegeType())){
			return;
		}
		
		Globals.getSiegeDemonService().askEnterSiegeDemon(player.getHuman(),cgSiegedemonAskEnterTeam.getSiegeType());
	}

	/**
	 * 应答进入组队副本的请求
	 * @param player
	 * @param cgSiegedemonAnswerEnterTeam
	 */
	public void handleSiegedemonAnswerEnterTeam(Player player,
			CGSiegedemonAnswerEnterTeam cgSiegedemonAnswerEnterTeam) {
		if(!checkServiceInfo(player, cgSiegedemonAnswerEnterTeam.getSiegeType())){
			return;
		}
		boolean agree = cgSiegedemonAnswerEnterTeam.getAgree() == 1 ? true : false;
		
		
		Globals.getSiegeDemonService().answerEnterSiegeDemon(player.getHuman(), cgSiegedemonAnswerEnterTeam.getSiegeType(), agree);
	}

	/**
	 *  玩家点击离开副本
	 * @param player
	 * @param cgSiegedemonLeave
	 */
	public void handleSiegedemonLeave(Player player, CGSiegedemonLeave cgSiegedemonLeave) {
		
		if(player == null || player.getHuman() == null){
			return;
		}
		
		Globals.getSiegeDemonService().leaveSiegeDemon(player.getHuman());
	}
	}
