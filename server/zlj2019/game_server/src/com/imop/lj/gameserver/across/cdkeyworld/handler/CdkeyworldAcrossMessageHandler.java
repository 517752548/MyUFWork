
package com.imop.lj.gameserver.across.cdkeyworld.handler;

import com.imop.lj.gameserver.across.cdkeyworld.msg.WGCdkeyCheckResultMsg;
import com.imop.lj.gameserver.common.Globals;
/**
 * worldservice 消息处理
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class CdkeyworldAcrossMessageHandler {	
	
	public CdkeyworldAcrossMessageHandler() {	
	}	
		/**
 	* 向gameserver请求验证结果
 	* 
 	* CodeGenerator
 	*/
	public void handleCdkeyCheckResultMsg(WGCdkeyCheckResultMsg wgCdkeyCheckResultMsg) {
		long charUUID = wgCdkeyCheckResultMsg.getCharUUId();
		int canUse = wgCdkeyCheckResultMsg.getCanUse();
		int failReason = wgCdkeyCheckResultMsg.getFailReason();
		String rewardStr = wgCdkeyCheckResultMsg.getRewardStr();
		
		Globals.getCDKeyService().takeCDKeyWorldServerResponse(charUUID, canUse, failReason, rewardStr);
	}
	}
