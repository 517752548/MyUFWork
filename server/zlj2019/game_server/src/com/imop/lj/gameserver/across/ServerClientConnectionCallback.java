package com.imop.lj.gameserver.across;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.client.NIOClient;
import com.imop.lj.core.client.NIOClient.ConnectionCallback;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.common.Globals;

public class ServerClientConnectionCallback implements ConnectionCallback
{
	@Override
	public void onOpen(NIOClient client, IMessage msg) {
		//TODO 发送注册消息
		Loggers.gameLogger.info("已经与跨服服务器建立连接发送注册消息");
		Loggers.gameLogger.debug(Globals.getConfig().getServerId());
	}

	@Override
	public void onClose(NIOClient client, IMessage msg) {
		// TODO 发送重连消息
		Loggers.gameLogger.info("已经与跨服服务器断开连接");
	}
}
