package com.imop.lj.gameserver.promote.handler;

import com.imop.lj.gameserver.promote.msg.CGPromotePanel;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class PromoteMessageHandler {	
	
	public PromoteMessageHandler() {	
	}	
		/**
 	* 打开提升面板
 	* 
 	* CodeGenerator
 	*/
	public void handlePromotePanel(Player player, CGPromotePanel cgPromotePanel) {
		if(player == null || player.getHuman() == null){
			return;
		}
		
		Globals.getPromoteService().sendPromotePanel(player.getHuman());
		
	}
	}
