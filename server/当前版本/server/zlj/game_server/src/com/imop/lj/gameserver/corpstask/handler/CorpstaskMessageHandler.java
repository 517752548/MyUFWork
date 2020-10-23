package com.imop.lj.gameserver.corpstask.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corps.model.Corps;
import com.imop.lj.gameserver.corpstask.msg.CGCorpstaskAccept;
import com.imop.lj.gameserver.corpstask.msg.CGGiveUpCorpstask;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.corpstask.msg.CGFinishCorpstask;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class CorpstaskMessageHandler {	
	
	public CorpstaskMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.CORPSTASK)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.CORPSTASK);
			return false;
		}



		return true;
	}
		/**
 	* 接受任务
 	* 
 	* CodeGenerator
 	*/
	public void handleCorpstaskAccept(Player player, CGCorpstaskAccept cgCorpstaskAccept) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		long roleId = player.getHuman().getCharId();
		Corps corps = Globals.getCorpsService().getUserCorps(roleId);
		if(corps == null){
			return;
		}
		
		
		Globals.getCorpsTaskService().acceptTask(player.getHuman(),corps.getLevel());
	}
		/**
 	* 放弃已接任务
 	* 
 	* CodeGenerator
 	*/
	public void handleGiveUpCorpstask(Player player, CGGiveUpCorpstask cgGiveUpCorpstask) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		long roleId = player.getHuman().getCharId();
		Corps corps = Globals.getCorpsService().getUserCorps(roleId);
		if(corps == null){
			return;
		}
		
		Globals.getCorpsTaskService().giveUpTask(player.getHuman());
	}
		/**
 	* 完成任务
 	* 
 	* CodeGenerator
 	*/
	public void handleFinishCorpstask(Player player, CGFinishCorpstask cgFinishCorpstask) {
		if(!checkRoleAndFunc(player)){
			return;
		}
		long roleId = player.getHuman().getCharId();
		Corps corps = Globals.getCorpsService().getUserCorps(roleId);
		if(corps == null){
			return;
		}
		
		Globals.getCorpsTaskService().finishTask(player.getHuman());
	}
	}
