package com.imop.lj.gameserver.timelimit.handler;

import com.imop.lj.gameserver.timelimit.msg.CGTlMonsterAccept;
import com.imop.lj.gameserver.timelimit.msg.CGGiveUpTlMonster;
import com.imop.lj.gameserver.timelimit.msg.CGFinishTlMonster;
import com.imop.lj.gameserver.timelimit.msg.CGTlNpcAccept;
import com.imop.lj.gameserver.timelimit.msg.CGGiveUpTlNpc;
import com.imop.lj.gameserver.timelimit.msg.CGFinishTlNpc;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.activity.function.ActivityDef;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class TimelimitMessageHandler {	
	
	public TimelimitMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.TIME_LIMIT_MONSTER)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.TIME_LIMIT_MONSTER);
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.TIME_LIMIT_NPC)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.TIME_LIMIT_NPC);
			return false;
		}
		
		Human human = player.getHuman();
		if(human.getTimeLimitManager() == null){
			return false;
		}
		if(ActivityDef.TimeLimitType.valueOf(human.getTimeLimitManager().getPushType()) == null){
			return false;
		}
		return true;
	}
	
		/**
 	* 接受任务
 	* 
 	* CodeGenerator
 	*/
	public void handleTlMonsterAccept(Player player, CGTlMonsterAccept cgTlMonsterAccept) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		
		Globals.getTimeLimitMonsterTaskService().acceptTask(player.getHuman());
	}
		/**
 	* 放弃已接任务
 	* 
 	* CodeGenerator
 	*/
	public void handleGiveUpTlMonster(Player player, CGGiveUpTlMonster cgGiveUpTlMonster) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		
		Globals.getTimeLimitMonsterTaskService().giveUpTask(player.getHuman());
	}
		/**
 	* 完成任务
 	* 
 	* CodeGenerator
 	*/
	public void handleFinishTlMonster(Player player, CGFinishTlMonster cgFinishTlMonster) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		
		Globals.getTimeLimitMonsterTaskService().finishTask(player.getHuman());
	}
		/**
 	* 接受任务
 	* 
 	* CodeGenerator
 	*/
	public void handleTlNpcAccept(Player player, CGTlNpcAccept cgTlNpcAccept) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		
		Globals.getTimeLimitNpcTaskService().acceptTask(player.getHuman());
	}
		/**
 	* 放弃已接任务
 	* 
 	* CodeGenerator
 	*/
	public void handleGiveUpTlNpc(Player player, CGGiveUpTlNpc cgGiveUpTlNpc) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		
		Globals.getTimeLimitNpcTaskService().giveUpTask(player.getHuman());
	}
		/**
 	* 完成任务
 	* 
 	* CodeGenerator
 	*/
	public void handleFinishTlNpc(Player player, CGFinishTlNpc cgFinishTlNpc) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		
		Globals.getTimeLimitNpcTaskService().finishTask(player.getHuman());
	}
	}
