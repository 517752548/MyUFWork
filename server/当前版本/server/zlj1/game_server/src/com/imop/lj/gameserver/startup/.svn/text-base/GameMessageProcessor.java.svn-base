package com.imop.lj.gameserver.startup;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.PlayerQueueMessage;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.core.msg.sys.ScheduledMessage;
import com.imop.lj.core.server.ExecutableMessageHandler;
import com.imop.lj.core.server.IMessageProcessor;
import com.imop.lj.core.server.QueueMessageProcessor;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerMessageHelper;

/**
 * 游戏服务器消息处理器
 *
 */
public class GameMessageProcessor implements IMessageProcessor {
	protected static final Logger log = Loggers.msgLogger;

	/** 主消息处理器，处理服务器内部消息、玩家不属于任何场景时发送的消息 */
	private QueueMessageProcessor mainMessageProcessor;

	public GameMessageProcessor() {
		mainMessageProcessor = new QueueMessageProcessor(
				new ExecutableMessageHandler());
	}

	@Override
	public boolean isFull() {
		return mainMessageProcessor.isFull();
	}

	/**
	 * <pre>
	 * 1、服务器内部消息、玩家不属于任何场景时发送的消息，单独一个消息队列进行处理
	 * 2、玩家在场景中发送过来的消息，添加到玩家的消息队列中，在场景的线程中进行处理
	 * </pre>
	 */
	@Override
	public void put(IMessage msg) {
		if (!GameServerRuntime.isOpen() && !(msg instanceof SysInternalMessage)
				&& !(msg instanceof ScheduledMessage)) {
			log.info("【Receive but will not process because server not open】"	+ msg);
			return;
		}
		if (msg instanceof CGMessage) {
			GameClientSession session = ((CGMessage) msg).getSession();
			if (session == null) {
				return;
			}
			Player player = session.getPlayer();
			if (player == null) {
				log.error("player not found. msg:" + msg);
				return;
			}
			if (log.isDebugEnabled()) {
				if (player.getHuman() != null) {
					//XXX log采样
					if(Globals.getConfig().isCollectStrategy() && !Globals.getSampleService().isIgnoreCollectStratety(msg.getType())){
						if(player.getHuman().getUUID() % Globals.getConfig().getCollectSimpling() == 0){
							log.debug(session.getIp() + "【Receive】" + msg
									+ "RN:"+ player.getHuman().getName()
									+ ",RID:" + player.getHuman().getUUID()
									+ ",PN:" + player.getPassportName()
									+ ",PId:" + player.getPassportId()
									);
						}
					}else{
						log.debug(session.getIp() + "【Receive】" + msg
								+ "RN:"+ player.getHuman().getName()
								+ ",RID:" + player.getHuman().getUUID()
								+ ",PN:" + player.getPassportName()
								+ ",PId:" + player.getPassportId()
								);
					}
				} else {
					log.debug(session.getIp() + "【Receive】" + msg 
							+ "PN:" + player.getPassportName()
							+ ",PId:" + player.getPassportId()
					);
				}
			}
			
			if (!player.getStateManager().canProcess(msg)) {
				if (player.getPermission() == SharedConstants.ACCOUNT_ROLE_DEBUG
						&& player.getPassportName().indexOf("robot") > -1) {
				} else {
					Loggers.gameLogger.warn(LogUtils.buildLogInfoStr(player
							.getRoleUUID() + "", "msg type " + msg.getType()
							+ " can't be processed in curState:"
							+ player.getStateManager().getState()));
				}
				return;
			}
			if (player.isInScene()) {
				player.putMessage(msg);
			} else {
				//防止在进入场景之前由主场景调用游戏业务消息
				if(!PlayerMessageHelper.isWithoutSceneMessage((CGMessage)msg)){
					player.putMessage(msg);
				}else{
					mainMessageProcessor.put(msg);
				}
			}
		}
		else if (msg instanceof PlayerQueueMessage) {
			PlayerQueueMessage playerQueueMsg = (PlayerQueueMessage) msg;
			long roleUUID = playerQueueMsg.getRoleUUID();
			Player player = Globals.getOnlinePlayerService().getPlayer(roleUUID);
			if (player == null) {
				log.error("player  with roleUUID:" + roleUUID + " not found");
				return;
			}
			if (log.isDebugEnabled()) {
				if (player.getHuman() != null) {
					log.debug(player.getClientIp() + "【Receive】" + msg 
							+ "un:"+ player.getHuman().getName() 
							+ ",rid:" + player.getHuman().getUUID() 
							+ ",PN:" + player.getPassportName()
							+ ",PId:" + player.getPassportId()
							);
				} else {
					log.debug(player.getClientIp() + "【Receive】" + msg 
							+ " PN:" + player.getPassportName()
							+ ", PId:" + player.getPassportId()
					);
				}
			}
			player.putMessage(msg);
		}
		else {
			if (log.isDebugEnabled() && !(msg instanceof ScheduledMessage)) {
				log.debug("【Receive】" + msg);
			}
			mainMessageProcessor.put(msg);

			return;
		}
	}

	@Override
	public void start() {
		mainMessageProcessor.start();
	}

	@Override
	public void stop() {
		mainMessageProcessor.stop();
	}

	/**
	 * 获得主消息处理线程Id
	 *
	 * @return
	 */
	public long getThreadId() {
		return mainMessageProcessor.getThreadId();
	}

	/**
	 * @return
	 */
	public boolean isStop() {
		return mainMessageProcessor.isStop();
	}
}
