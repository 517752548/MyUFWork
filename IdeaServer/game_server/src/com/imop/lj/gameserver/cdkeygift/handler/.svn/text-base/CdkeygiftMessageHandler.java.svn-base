
package com.imop.lj.gameserver.cdkeygift.handler;

import com.imop.lj.gameserver.cdkeygift.msg.CGCdkeyGetGiftMsg;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class CdkeygiftMessageHandler {	
	
	public CdkeygiftMessageHandler() {	
	}	
		/**
 	* 通过cdkey领礼包
 	* 
 	* CodeGenerator
 	*/
	public void handleCdkeyGetGiftMsg(Player player, CGCdkeyGetGiftMsg cgCdkeyGetGiftMsg) {
		if(null == player || null == player.getHuman()) {
			return;
		}
		
		Globals.getCDKeyService().takeCDKeyGiftRequestWS(player.getHuman(), cgCdkeyGetGiftMsg.getCdKeyStr());
	}
	}
