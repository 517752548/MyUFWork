package com.imop.lj.gameserver.ringtask.handler;

import com.imop.lj.gameserver.ringtask.msg.CGRingtaskAccept;
import com.imop.lj.gameserver.ringtask.msg.CGGiveUpRingtask;
import com.imop.lj.gameserver.ringtask.msg.CGFinishRingtask;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class RingtaskMessageHandler {	
	
	public RingtaskMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.RING)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.RING);
			return false;
		}

		return true;
	}
	
		/**
 	* 接受任务
 	* 
 	* CodeGenerator
 	*/
	public void handleRingtaskAccept(Player player, CGRingtaskAccept cgRingtaskAccept) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		
		Globals.getRingTaskService().acceptTask(player.getHuman());
	}
		/**
 	* 放弃已接任务
 	* 
 	* CodeGenerator
 	*/
	public void handleGiveUpRingtask(Player player, CGGiveUpRingtask cgGiveUpRingtask) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		
		Globals.getRingTaskService().giveUpTask(player.getHuman());
	}
		/**
 	* 完成任务
 	* 
 	* CodeGenerator
 	*/
	public void handleFinishRingtask(Player player, CGFinishRingtask cgFinishRingtask) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		
		Globals.getRingTaskService().finishTask(player.getHuman());
	}
	}
