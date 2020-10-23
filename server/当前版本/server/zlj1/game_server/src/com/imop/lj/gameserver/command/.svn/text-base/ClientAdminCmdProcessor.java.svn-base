package com.imop.lj.gameserver.command;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 *
 * GameServer的命令处理器，客户端Debug
 *
 * @param <T>
 *
 */
public class ClientAdminCmdProcessor<T extends ISession> extends
	CommandBaseProcessorGameServer<T> {

	/**
	 * 检查权限是否足够执行命令
	 *
	 * @return
	 */
	@Override
	protected boolean checkPermission(T sender, String cmd, String content) {
		if (!(sender instanceof GameClientSession)) {
			return false;
		}
		Player player = ((GameClientSession) sender).getPlayer();

		if (player.getPermission() != SharedConstants.ACCOUNT_ROLE_DEBUG) {
			return false;
		}

		return true;
	}
}
