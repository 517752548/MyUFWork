package com.imop.lj.gameserver.startup;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.StatisticsLoggerHelper;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.session.MinaSession;
import com.imop.lj.core.util.IpUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;

/**
 * 与 GameServer 连接的客户端的会话信息
 *
 */
public class MinaGameClientSession extends MinaSession implements
		GameClientSession {

	/** 当前会话绑定的玩家对象，登录验证成功之后实例化 */
	private Player player;

	public MinaGameClientSession(IoSession s) {
		super(s);
	}

	public void setPlayer(Player player) {
		this.player = player;
	}

	public Player getPlayer() {
		return player;
	}

	@Override
	public void write(IMessage msg) {
		if (session == null || !session.isConnected()) {
			return;
		}
		final IoSession _session = this.session;
		if (_session != null) {
			if (GameServerRuntime.isWriteTrafficControl()) {
				// 检查玩家的输出缓存是否达到上限,如果已经达到,则关闭连接,以此避免那些
				// 较慢连接对服务器的影响
				final long _sessionWriteSize = session.getScheduledWriteBytes();
				if (_sessionWriteSize > GameServerRuntime.MAX_WRITE_BYTES_INQUEUE) {
					Loggers.msgLogger.warn("SessionBufferSize" + msg + ";passportId=" + (player != null ? player.getPassportId() : ""));
					session.close(true);
					return;
				}
			}
			if (Loggers.msgLogger.isDebugEnabled()) {
				if (player.getHuman() != null) {
					if(Globals.getConfig().isCollectStrategy()  && !Globals.getSampleService().isIgnoreCollectStratety(msg.getType())){
						if(player.getHuman().getUUID() % Globals.getConfig().getCollectSimpling() == 0){
							Loggers.msgLogger.debug(this.getIp() + "【Send】" + Globals.getSampleService().msgToString(msg)
									+ ",RN:"+ player.getHuman().getName() 
									+ ",RID:" + player.getHuman().getUUID() 
									+ ",PN:" + player.getPassportName()
									+ ",PID:" + player.getPassportId());
						}
					}else{
						Loggers.msgLogger.debug(this.getIp() + "【Send】" + Globals.getSampleService().msgToString(msg)
								+ ",RN:"+ player.getHuman().getName() 
								+ ",RID:" + player.getHuman().getUUID() 
								+ ",PN:" + player.getPassportName()
								+ ",PID:" + player.getPassportId());
					}
				} else {
					Loggers.msgLogger.debug(this.getIp() + "【Send】" + Globals.getSampleService().msgToString(msg)
							+ ",PN:" + player.getPassportName()
							+ ",PID:" + player.getPassportId());
				}
			}
			StatisticsLoggerHelper.logMessageSent(msg);
			_session.write(msg);
		}
	}

	@Override
	public String getIp() {
		return IpUtils.getIp(this.getIoSession());
	}
}
