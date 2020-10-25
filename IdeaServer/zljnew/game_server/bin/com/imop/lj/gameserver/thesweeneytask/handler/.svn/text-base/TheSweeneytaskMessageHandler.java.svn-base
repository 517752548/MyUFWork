
package com.imop.lj.gameserver.thesweeneytask.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.thesweeneytask.msg.CGFinishThesweeneytask;
import com.imop.lj.gameserver.thesweeneytask.msg.CGGiveUpThesweeneytask;
import com.imop.lj.gameserver.thesweeneytask.msg.CGThesweeneytaskAccept;
/**
 * $message.comment
 * @author CodeGenerator, don't modify this file please.
 */

public class TheSweeneytaskMessageHandler {	
	
	public TheSweeneytaskMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.THE_SWEENEY)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.THE_SWEENEY);
			return false;
		}
		return true;
	}

   /**
 	* 接受任务
 	* CodeGenerator
 	*/
	public void handleThesweeneytaskAccept(Player player,CGThesweeneytaskAccept cgThesweeneytaskAccept) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getTheSweeneyTaskService().acceptTask(player.getHuman());
	}
   /**
 	* 放弃已接任务
 	* CodeGenerator
 	*/
	public void handleGiveUpThesweeneytask(Player player, CGGiveUpThesweeneytask cgGiveUpThesweeneytask){
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getTheSweeneyTaskService().giveupTask(player.getHuman());
	}
   /**
 	* 完成任务
 	* CodeGenerator
 	*/
	public void handleFinishThesweeneytask(Player player, CGFinishThesweeneytask cgFinishThesweeneytask) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getTheSweeneyTaskService().finishTask(player.getHuman());
	}
	
}
