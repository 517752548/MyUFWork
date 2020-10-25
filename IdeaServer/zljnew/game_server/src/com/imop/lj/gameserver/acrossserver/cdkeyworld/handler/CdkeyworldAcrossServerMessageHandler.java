
package com.imop.lj.gameserver.acrossserver.cdkeyworld.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.acrossserver.ServerClient;
import com.imop.lj.gameserver.acrossserver.WGlobals;
import com.imop.lj.gameserver.acrossserver.cdkeyworld.msg.GWCdkeyCheckMsg;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class CdkeyworldAcrossServerMessageHandler {	
	
	public CdkeyworldAcrossServerMessageHandler() {	
	}	
		/**
 	* 向worldserver请求验证激活码是否可用
 	* 
 	* CodeGenerator
 	*/
	public void handleCdkeyCheckMsg(ServerClient serverClient, GWCdkeyCheckMsg gwCdkeyCheckMsg) {
		String openId = gwCdkeyCheckMsg.getOpenId();
		long charUUID = gwCdkeyCheckMsg.getCharUUId();
		String cdKeyStr = gwCdkeyCheckMsg.getCdKeyStr();
		String serverId = gwCdkeyCheckMsg.getOnServerId();
		String charName = "";
		if (openId == null || openId.length() <= 0 || null == cdKeyStr || cdKeyStr.isEmpty() || charUUID < 0) {
			Loggers.cdKeyLogger.error("#CdkeyworldAcrossServerMessageHandler#handleCdkeyCheckMsg#invalid params!openId=" + 
					openId + ", charUUID=" + charUUID + ", cdKeyStr=" + cdKeyStr);
			return;
		}
		
		WGlobals.getCdKeyWorldService().ckeckCDKeyEffective(serverClient, charUUID, openId, cdKeyStr, serverId, charName);
	}
	}
