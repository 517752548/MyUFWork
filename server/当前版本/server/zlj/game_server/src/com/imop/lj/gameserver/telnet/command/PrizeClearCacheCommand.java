package com.imop.lj.gameserver.telnet.command;

import java.util.Map;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.gameserver.common.Globals;

/**
 * 清奖励缓存
 *
 *
 */
public class PrizeClearCacheCommand extends LoginedTelnetCommand {
	public PrizeClearCacheCommand() {
		super("PrizeClear");
	}

	@Override
	protected void doExec(String command, Map<String, String> params,
			IoSession session) {

		Globals.getPrizeService().clearCache();
	}
}
