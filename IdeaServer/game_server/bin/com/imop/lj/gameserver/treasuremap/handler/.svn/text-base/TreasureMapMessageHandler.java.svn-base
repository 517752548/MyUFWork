
package com.imop.lj.gameserver.treasuremap.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.treasuremap.msg.CGFinishTreasuremap;
import com.imop.lj.gameserver.treasuremap.msg.CGGiveUpTreasuremap;
import com.imop.lj.gameserver.treasuremap.msg.CGTreasuremapAccept;
/**
 * $message.comment
 * @author CodeGenerator, don't modify this file please.
 */

public class TreasureMapMessageHandler {	
	
	public TreasureMapMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.TREASURE_MAP)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.TREASURE_MAP);
			return false;
		}
		return true;
	}

   /**
 	* 接受任务
 	* CodeGenerator
 	*/
	public void handleTreasuremapAccept(Player player, CGTreasuremapAccept cgTtreasuremapAccept) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getTreasureMapService().acceptTask(player.getHuman());
	}
	
   /**
 	* 放弃已接任务
 	* CodeGenerator
 	*/
	public void handleGiveUpTreasuremap(Player player, CGGiveUpTreasuremap cgGiveUpTtreasuremap){
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getTreasureMapService().giveupTask(player.getHuman());
	}
	
   /**
 	* 完成任务
 	* CodeGenerator
 	*/
	public void handleFinishTreasuremap(Player player, CGFinishTreasuremap cgFinishTtreasuremap) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getTreasureMapService().finishTask(player.getHuman());
	}

}
