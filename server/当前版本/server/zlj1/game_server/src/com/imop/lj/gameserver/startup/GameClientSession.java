package com.imop.lj.gameserver.startup;

import com.imop.lj.gameserver.player.Player;
import com.imop.lj.core.session.ISession;

/**
 * 与 GameServer 连接的客户端的会话信息
 *
 */
public interface GameClientSession extends ISession {

	void setPlayer(Player player);

	Player getPlayer();

	String getIp();
}
