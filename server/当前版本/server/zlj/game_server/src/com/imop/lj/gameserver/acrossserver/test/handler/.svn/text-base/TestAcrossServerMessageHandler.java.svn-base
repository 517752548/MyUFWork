
package com.imop.lj.gameserver.acrossserver.test.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.acrossserver.ServerClient;
import com.imop.lj.gameserver.acrossserver.msg.WGMessage;
import com.imop.lj.gameserver.acrossserver.test.msg.GWTest;
import com.imop.lj.gameserver.acrossserver.test.msg.WGTest;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class TestAcrossServerMessageHandler {	
	
	public TestAcrossServerMessageHandler() {	
	}	
		/**
 	* 游戏服务器到跨服服务器测试消息
 	* 
 	* CodeGenerator
 	*/
	public void handleTest(ServerClient serverClient, GWTest gwTest) {
		Loggers.gameLogger.debug("receive gameserver content is " + gwTest.getContent());
		WGMessage msg = new WGTest("I am World Server ,It's test");
		serverClient.sendMessage(msg);
		Loggers.gameLogger.debug("send game Server :" + msg);
	}
	}
