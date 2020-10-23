package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月5日 下午12:18:07
 * @version 1.0
 */
public class CDKeyCommand extends LoginedTelnetCommand {

	public CDKeyCommand() {
		super("CDKEYCOMMAND");
	}
	
	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {
	}

}
