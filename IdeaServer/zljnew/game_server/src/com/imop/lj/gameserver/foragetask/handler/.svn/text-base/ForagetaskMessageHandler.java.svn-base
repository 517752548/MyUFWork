package com.imop.lj.gameserver.foragetask.handler;

import com.imop.lj.gameserver.foragetask.msg.CGOpenForagetaskPanel;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.foragetask.msg.CGForagetaskAccept;
import com.imop.lj.gameserver.foragetask.msg.CGGiveUpForagetask;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.foragetask.msg.CGFinishForagetask;
import com.imop.lj.gameserver.foragetask.msg.CGForagetaskRefresh;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class ForagetaskMessageHandler {	
	
	public ForagetaskMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.FORAGE)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.FORAGE);
			return false;
		}
		return true;
	}
	
		/**
 	* 打开护送粮草任务面板
 	* 
 	* CodeGenerator
 	*/
	public void handleOpenForagetaskPanel(Player player, CGOpenForagetaskPanel cgOpenForagetaskPanel) {
		if (!checkRoleAndFunc(player)) {
			return ;
		}
		
		Globals.getForageTaskService().openForageTaskPanel(player.getHuman());
	}
		/**
 	* 接受任务
 	* 
 	* CodeGenerator
 	*/
	public void handleForagetaskAccept(Player player, CGForagetaskAccept cgForagetaskAccept) {
		if (!checkRoleAndFunc(player)) {
			return ;
		}
		
		int questId = cgForagetaskAccept.getQuestId();
		if (questId <= 0) {
			return ;
		}
		
		Globals.getForageTaskService().acceptTask(player.getHuman(),questId);
	}
		/**
 	* 放弃已接任务
 	* 
 	* CodeGenerator
 	*/
	public void handleGiveUpForagetask(Player player, CGGiveUpForagetask cgGiveUpForagetask) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getForageTaskService().giveupTask(player.getHuman());
	}
		/**
 	* 完成任务
 	* 
 	* CodeGenerator
 	*/
	public void handleFinishForagetask(Player player, CGFinishForagetask cgFinishForagetask) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
	
		
		Globals.getForageTaskService().finishTask(player.getHuman());
	}
		/**
 	* 护送粮草任务手动刷新
 	* 
 	* CodeGenerator
 	*/
	public void handleForagetaskRefresh(Player player, CGForagetaskRefresh cgForagetaskRefresh) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getForageTaskService().refreshTaskManual(player.getHuman());
	}
	}
