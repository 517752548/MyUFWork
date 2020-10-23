package com.imop.lj.gameserver.player;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.locks.Lock;
import java.util.concurrent.locks.ReentrantReadWriteLock;

import org.slf4j.Logger;

import com.google.common.collect.Lists;
import com.google.common.collect.Maps;
import com.imop.lj.common.LogReasons;
import com.imop.lj.common.NonThreadSafe;
import com.imop.lj.common.constants.DisconnectReason;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.RoleConstants;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.exception.CrossThreadException;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.core.orm.DataAccessException;
import com.imop.lj.core.session.ISession;
import com.imop.lj.core.util.Assert;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gameserver.chat.ChatOperation;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.common.unit.GameUnitList;
import com.imop.lj.gameserver.corps.msg.OnPlayerOfflineMessage;
import com.imop.lj.gameserver.human.Country;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetDef.PetQuality;
import com.imop.lj.gameserver.pet.PetDef.PetState;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.helper.PetHelper;
import com.imop.lj.gameserver.player.async.ReportLogout2Local;
import com.imop.lj.gameserver.player.async.SavePlayerRoleOperation;
import com.imop.lj.gameserver.player.model.RoleInfo;
import com.imop.lj.gameserver.player.msg.GCNotifyException;
import com.imop.lj.gameserver.scene.PlayerLeaveSceneCallback;
import com.imop.lj.gameserver.scene.SceneService;
import com.imop.lj.gameserver.startup.GameServerRuntime;
import com.imop.lj.probe.PIProbeCollector;
import com.imop.lj.probe.PIProbeConstants.ProbeName;
import com.opi.gibp.probe.category.user.UsersExt;

/**
 * 在线玩家管理器
 * 
 * 
 */
public class OnlinePlayerService implements NonThreadSafe {
	/** 最多同时在线的人数 */
	private int maxPlayerNum;
	/** 维护当前Server所有在线玩家实例 */
	private GameUnitList<Player> onlinePlayers;
	/** 在线玩家列表，方便查询，key：玩家当前角色UUID，value：玩家引用 */
	private Map<Long, Player> onlinePlayersMap;

	/** 在线玩家的会话管理 */
	private Map<ISession, Player> sessionPlayers;

	/** 登录用户集合 <Long passportId,Player loginUser> */
	private Map<String, Player> passportIdPlayers;
//	/** 登录用户集合 <String roleName, Player loginUser> */
//	private Map<String, Player> roleNamePlayers;

	/** 管理器所属线程Id，为主线程Id */
	private long threadId;
	private final ReentrantReadWriteLock rwl = new ReentrantReadWriteLock();
	private final Lock readLock = rwl.readLock();
	private final Lock writeLock = rwl.writeLock();
	/** */
	public static final Logger logoutLogger = Loggers.logoutLogger;
	
	private int onlinePlayerNumCache = 0;

	/**
	 * 初始化在线玩家实例数组
	 * 
	 * @param maxPlayerNum
	 *            最多同时在线的人数
	 */
	public OnlinePlayerService(int maxPlayerNum) {
		this.maxPlayerNum = maxPlayerNum;
		onlinePlayers = new GameUnitList<Player>(maxPlayerNum);
		onlinePlayersMap = new ConcurrentHashMap<Long, Player>(maxPlayerNum);
		passportIdPlayers = new ConcurrentHashMap<String, Player>();
//		roleNamePlayers = new ConcurrentHashMap<String, Player>();
		sessionPlayers = Maps.newConcurrentHashMap();
	}

	/**
	 * 根据 passportId 查找在线用户
	 * 
	 * @param passportId
	 * @return
	 */
	public Player getPlayerByPassportId(String passportId) {
		return passportIdPlayers.get(passportId);
	}

	/**
	 * 根据玩家角色uuid获得玩家对象的引用
	 * 
	 * @param roleUUID
	 *            玩家当前角色UUID
	 * @return
	 */
	public Player getPlayer(long roleUUID) {
		return onlinePlayersMap.get(roleUUID);
	}

	/**
	 * 根据玩家的session获得玩家对象的引用
	 * 
	 * @param session
	 * @return
	 */
	public Player getPlayer(ISession session) {
		if (session == null) {
			return null;
		}
		return sessionPlayers.get(session);
	}

//	/**
//	 * 根据玩家的角色名称获得玩家对象的引用
//	 * 
//	 * @param roleName
//	 * @return
//	 * 
//	 */
//	public Player getPlayer(String roleName) {
//		return roleNamePlayers.get(roleName);
//	}

	/**
	 * 建立连接时建立Session与Player的对应关系
	 * 
	 * @param session
	 * @param user
	 */
	public void putPlayer(ISession session, Player user) {
		sessionPlayers.put(session, user);
	}

//	/**
//	 * 将在线角色名称保存到map
//	 * 
//	 * @param roleName
//	 * @param user
//	 */
//	public void putPlayer(String roleName, Player user) {
//		roleNamePlayers.put(roleName, user);
//	}

	/**
	 * @return
	 */
	public int getOnlinePlayerCount() {
		return onlinePlayers.size();
	}

	public void setThreadId(long threadId) {
		this.threadId = threadId;
	}

	public long getThreadId() {
		return threadId;
	}

	/**
	 * 玩家进入当前服务器
	 * 
	 * @param player
	 * @param roleUUID
	 *            玩家当前角色的UUID
	 */
	public boolean onPlayerEnterServer(Player player, long roleUUID) {
		if (!this.addPlayer(player, roleUUID)) {
			logoutLogger.error("#OnlinePlayerService#onPlayerEnterServer#addPlayer return false;playerId=" + 
					player.getCharId() + ";passportId=" + player.getPassportId() + ";roleUUID=" + roleUUID);
			return false;
		}
		// if(onlinePlayersMap.containsKey(roleUUID) ||
		// passportIdPlayers.containsKey(player.getPassportId())){
		// return false;
		// }
		// Player _player = onlinePlayersMap.get(roleUUID);
		// XXX 临时
		// if(_player != null){
		// _player.disconnect();
		// }
		// _player = passportIdPlayers.get(player.getPassportId());
		// if(_player != null){
		// _player.disconnect();
		// }
		return true;
	}

	/**
	 * 遍历维护在线玩家实例的数组，找到数组中第一 个引用为<code>null</code>的 索引，将当前<code>player</code>
	 * 对象的引用存储到数组的该位置
	 * <p>
	 * 注意：<b>此方法只能在主线程中调用</b>，否则会 抛出异常{@link CrossThreadException}
	 * 
	 * @param player
	 * @return
	 */
	private boolean addPlayer(Player player, long roleUUID) {
		Assert.notNull(player);
		checkThread();
		if (onlinePlayers.size() >= maxPlayerNum) {
			logoutLogger.info(player.getClientIp() + " Online player number reaches the upper limit");
			return false;
		}
		writeLock.lock();
		try {
			boolean addFlag = onlinePlayers.add(player);
			logoutLogger.info("#OnlinePlayerService#addPlayer#addFlag=" + addFlag + ";playerId="+player.getCharId() + ";passportId=" + player.getPassportId());
			if (addFlag) {
				onlinePlayersMap.put(roleUUID, player);
				passportIdPlayers.put(player.getPassportId(), player);
			} else {
				logoutLogger.error("#OnlinePlayerService#addPlayer#add return false;playerId=" + 
						player.getCharId() + ";passportId=" + player.getPassportId() + ";roleUUID=" + roleUUID);
			}
			return addFlag;
		} finally {
			writeLock.unlock();
		}
	}

	/**
	 * 向所有在线玩家广播消息，如果当前线程不是主线程，会将此消息转发到主线程进行广播
	 * 
	 * @param msg
	 */
	public void broadcastMessage(final GCMessage msg) {
		if (Thread.currentThread().getId() == Globals.getMessageProcessor().getThreadId()) {
			// 获取在线玩家
			List<Player> onlinePlayerList = this.getOnlinePlayers();

			for (Player onlinePlayer : onlinePlayerList) {
				if (onlinePlayer.getState() == PlayerState.gaming) {
					// 如果玩家已经进入游戏状态,
					// 向玩家发送聊天信息
					onlinePlayer.sendMessage(msg);
				} else if (onlinePlayer.getState() == PlayerState.entering || 
						onlinePlayer.getState() == PlayerState.leaving) {
					// 玩家正在切换场景中（也可能正在进入或离开游戏），发送广播是确保玩家切换场景时也能收到类似boss被击杀的公告。
					onlinePlayer.sendMessage(msg);
					// 该状态记录日志
					Loggers.playerLogger.info("#OnlinePlayerService#broadcastMessage#player state=" + 
							onlinePlayer.getState() + ";humanId=" + onlinePlayer.getCharId() + 
							";pid=" + onlinePlayer.getPassportId());
				}
			}
		} else {
			Globals.getMessageProcessor().put(new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getOnlinePlayerService().broadcastMessage(msg);
				}
			});
		}
	}
	
	/**
	 * 在聊天的IO线程中发
	 * @param msg
	 */
	public void broadcastMsg(final GCMessage msg) {
		Globals.getAsyncService().createOperationAndExecuteAtOnce(new ChatOperation(msg));
	}
	
	/**
	 * 向在线玩家中，指定国家的玩家广播消息
	 * @param country
	 * @param msg
	 */
	public void broadcastCountryMessage(final Country country, final GCMessage msg) {
		if (country == Country.NO_COUNTRY) {
			return;
		}
		if (Thread.currentThread().getId() == Globals.getMessageProcessor().getThreadId()) {
			// 获取在线玩家
			List<Player> onlinePlayerList = this.getOnlinePlayers();

			for (Player onlinePlayer : onlinePlayerList) {
				// 如果玩家已经进入游戏状态
				if (onlinePlayer.getState() == PlayerState.gaming) {
					// 如果玩家的国家是指定国家
					if (onlinePlayer.getHuman() != null && 
							onlinePlayer.getHuman().getCountryType() == country) {
						// 向玩家发送聊天信息
						onlinePlayer.sendMessage(msg);
					}
				}
			}
		} else {
			Globals.getMessageProcessor().put(new SysInternalMessage() {
				@Override
				public void execute() {
					Globals.getOnlinePlayerService().broadcastCountryMessage(country, msg);
				}
			});
		}
	}
	
	// /**
	// * 向所有在线玩家广播消息，如果当前线程不是主线程，会将此消息转发到主线程进行广播
	// *
	// * @param msg
	// */
	// public void broadcastMessage(final GCArenaNotice msg) {
	// if (Thread.currentThread().getId() ==
	// Globals.getMessageProcessor().getThreadId()) {
	// // 获取在线玩家
	// List<Player> onlinePlayerList = this.getOnlinePlayers();
	//
	// for (Player onlinePlayer : onlinePlayerList) {
	// if (onlinePlayer.getState() == PlayerState.gaming) {
	// // 如果玩家已经进入游戏状态,
	// // 向玩家发送聊天信息
	// if(onlinePlayer.isInArena())
	// {
	// onlinePlayer.sendMessage(msg);
	// }
	// }
	// }
	// } else {
	// Globals.getMessageProcessor().put(new SysInternalMessage() {
	// @Override
	// public void execute() {
	// Globals.getOnlinePlayerService().broadcastMessage(msg);
	// }
	// });
	// }
	// }

	/**
	 * 向一个在线玩家发送消息
	 * 
	 * @param playerId
	 * @param msg
	 */
	public void sendMessage(int playerId, GCMessage msg) {
		Player player = onlinePlayers.get(playerId);
		if (player != null) {
			player.sendMessage(msg);
		}
	}

	/**
	 * 获得玩家实例
	 * 
	 * @param playerId
	 * @return
	 */
	public Player getPlayerByTempId(int playerId) {
		readLock.lock();
		try {
			Player player = onlinePlayers.get(playerId);
			return player;
		} finally {
			readLock.unlock();
		}
	}

	/**
	 * 获取所有在线玩家passportId列表
	 * 
	 * <pre>
	 * 需要遍历在线玩家列表时调用此方法
	 * 不应该将onlinePlayers对外暴露
	 * 
	 * </pre>
	 * 
	 * @return
	 */
	public Collection<Long> getAllOnlinePlayerRoleUUIDs() {
		Set<Long> onlinePlayerUUIDs = this.onlinePlayersMap.keySet();
		return onlinePlayerUUIDs;
	}

	/**
	 * 使所有玩家下线，注意一定要在调用{@link SceneService#stop()}方法之后调用此方法
	 * 
	 * @param reason
	 *            服务器主动发起的
	 */
	public void offlineAllPlayers(PlayerExitReason reason) {
		checkThread();
		Assert.isTrue(reason == PlayerExitReason.SERVER_SHUTDOWN);
		Loggers.playerLogger.info("All players will be offline,to save players " + this.onlinePlayers.size());
		Collection<Player> players = onlinePlayersMap.values();

		for (Player player : players) {
			if (player != null && player.getState() != PlayerState.logouting) {
				try {
					this.offlinePlayer(player, reason);
				} catch (Exception e) {
					Loggers.playerLogger.error("Error occurs when offline all players", e);
				}
			}
		}
	}

	/**
	 * <pre>
	 * 玩家下线，此方法在主线程中调用
	 * </pre>
	 * 
	 * @param player
	 * @param reason
	 */
	public void offlinePlayer(Player player, final PlayerExitReason reason) {
		checkThread();
		player.exitReason = reason;

		boolean isNeedReportLogout = false;
		if (player.getState() != PlayerState.connected && player.getState() != PlayerState.auth) {
			isNeedReportLogout = true;
		}
		
		if (player.getHuman() != null) {
			long now = Globals.getTimeService().now();
			Globals.getLogService().sendPlayerLoginLog(player.getHuman(), LogReasons.PlayerLoginLogReason.PLAYER_LOGOUT, player.getClientIpOnLoginLog(),
					player.getCurrTerminalType().getSource(), now, player.getSource());
		}
		// System.out.println("++++++:"+player.getState());
		// if(player.getState() != PlayerState.logouting){
		// Globals.getOnlinePlayerService().removeSession(player.getSession());
		// }

		// XXX 蛋疼 因为有玩家状态为logouted，登录不上去了就
		if (player.getState() == PlayerState.logouted) {
			Globals.getOnlinePlayerService().removeSession(player.getSession());
			if (player.getHuman() != null) {
				player.getHuman().setPlayer(null);
				onlinePlayersMap.remove(player.getHuman().getUUID());
//				roleNamePlayers.remove(player.getHuman().getName());
			}
			passportIdPlayers.remove(player.getPassportId());
			onlinePlayersMap.remove(player.getRoleUUID());
			onlinePlayers.remove(player);
		}

		if (player.getState() == PlayerState.connected || player.getState() == PlayerState.auth || player.getState() == PlayerState.loadingrolelist
				|| player.getState() == PlayerState.waitingselectrole || player.getState() == PlayerState.creatingrole
		// || player.getState() == PlayerState.init
		)

		{
			player.setState(PlayerState.logouting);
			Globals.getOnlinePlayerService().removeSession(player.getSession());
			Globals.getOnlinePlayerService().removePlayer(player);

			if (isNeedReportLogout && Globals.getServerConfig().isTurnOnLocalInterface()
					&& Globals.getServerConfig().getAuthType() == SharedConstants.AUTH_TYPE_INTERFACE) {
				ReportLogout2Local _reportLogoutTask = new ReportLogout2Local(player);
				Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_reportLogoutTask);
			}
			logoutLogger.info(player.getClientIp() + " 9、Player logout OnlinePlayerService.offlinePlayer " + " player passportId" + player.getPassportId() + " player state"
					+ player.getState().name());
			return;
		}

		if (player.getState() == PlayerState.loading || player.getState() == PlayerState.entering || player.getState() == PlayerState.leaving) {
			player.setState(PlayerState.logouting);
		}

		Human human = player.getHuman();
		// TODO
		if (human != null) {
			//下线时，游戏相关业务的处理
			IMessage offlineMsg = new OnPlayerOfflineMessage(human.getUUID());
			Globals.getSceneService().getCommonScene().putMessage(offlineMsg);
			
			// 防沉迷
			Globals.getWallowService().onPlayerExit(player.getPassportId());
		}

		// 增加离线保存战斗信息快照的mask
		SavePlayerRoleOperation _saveTask = new SavePlayerRoleOperation(player, PlayerConstants.CHARACTER_INFO_MASK_BASE, true);

		if (reason == PlayerExitReason.SERVER_SHUTDOWN) {
			_saveTask.setShutDownServer(true);
		}
		
		if (reason == PlayerExitReason.SERVER_SHUTDOWN) {
			logoutLogger.info(player.getClientIp() + " 10、Player logout OnlinePlayerService.offlinePlayer " + " player passportId" + player.getPassportId() + " player state"
					+ player.getState().name());
			player.setState(PlayerState.logouting);
			Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_saveTask);
			if (isNeedReportLogout && Globals.getServerConfig().isTurnOnLocalInterface()
					&& Globals.getServerConfig().getAuthType() == SharedConstants.AUTH_TYPE_INTERFACE) {
				ReportLogout2Local _reportLogoutTask = new ReportLogout2Local(player);
				Globals.getAsyncService().createSyncOperationAndExecuteAtOnce(_reportLogoutTask);
			}
		} else {
			if (player.isInScene()) {
				logoutLogger.info(player.getClientIp() + " 11、Player logout OnlinePlayerService.offlinePlayer " + " player passportId" + player.getPassportId()
						+ " player state" + player.getState().name());
				// 离开场景后会自动调存库方法，存库之后会自动移除玩家
				Globals.getSceneService().onPlayerLeaveScene(player, new PlayerLeaveSceneCallback() {
					@Override
					public void afterLeaveScene(final Player player) {
						logoutLogger.info(player.getClientIp() + " 14、Player logout OnlinePlayerService.offlinePlayer " + " player passportId" + player.getPassportId()
								+ " player state" + player.getState().name());
						// 移除玩家角色
						player.setState(PlayerState.logouting);
						Globals.getOnlinePlayerService().offlinePlayer(player, player.exitReason);
					}
				});
			} else {
				// 异步存库，存库之后会将玩家移除
				if (human != null) {
					logoutLogger.info(player.getClientIp() + " 12、Player logout OnlinePlayerService.offlinePlayer " + " player passportId" + player.getPassportId()
							+ " player state" + player.getState().name());
					Globals.getAsyncService().createOperationAndExecuteAtOnce(_saveTask);
					if (isNeedReportLogout && Globals.getServerConfig().isTurnOnLocalInterface()
							&& Globals.getServerConfig().getAuthType() == SharedConstants.AUTH_TYPE_INTERFACE) {
						ReportLogout2Local _reportLogoutTask = new ReportLogout2Local(player);
						Globals.getAsyncService().createOperationAndExecuteAtOnce(_reportLogoutTask);
					}
				} else {
					logoutLogger.info(player.getClientIp() + " 13、Player logout OnlinePlayerService.offlinePlayer " + " player passportId" + player.getPassportId()
							+ " player state" + player.getState().name());
					player.setState(PlayerState.logouting);
					if (player.getPassportId() == null || "".endsWith(player.getPassportId())) {
						logoutLogger.error("14、Player passportId is zero!");
					} else {
						ReportLogout2Local _reportLogoutTask = new ReportLogout2Local(player);
						Globals.getAsyncService().createOperationAndExecuteAtOnce(_reportLogoutTask);
					}
					Globals.getOnlinePlayerService().removeSession(player.getSession());
					Globals.getOnlinePlayerService().removePlayer(player);
				}
			}
		}
	}

	/**
	 * 根据玩家临时id移除一个在线玩家，同时通知WorldServer
	 * 
	 * <pre>
	 * 1、如果正在异步加载角色信息或退出保存，则只修改状态为logout，不进行移除操作
	 * 2、注意&lt;b&gt;此方法只能在主线程中调用&lt;/b&gt;，否则会 抛出异常{@link CrossThreadException}
	 * </pre>
	 * 
	 * @param playerId
	 *            玩家在场景中的Id
	 */
	public void removePlayer(Player player) {
		// System.out.println("++++++++"+player);
		checkThread();
		if (player.getState() != PlayerState.logouting) {
			logoutLogger.error("Only player with state [logouting] can be remove " + player.getPassportId());
			return;
		}
		logoutLogger.info("offline player passport=" + player.getPassportId());
		// if(player.getPassportId()==0)
		// {
		// System.out.println("a");
		// }
		writeLock.lock();
		try {

//			if (player.getHuman() != null) {
//				// System.out.println("+++++++++removeuiser");
//				player.getHuman().setPlayer(null);
//				onlinePlayersMap.remove(player.getHuman().getUUID());
////				roleNamePlayers.remove(player.getHuman().getName());
//			}
			
//			// System.out.println("++++:"+passportIdPlayers.size());
//			passportIdPlayers.remove(player.getPassportId());
//			// System.out.println("++++:"+passportIdPlayers.size()+":"+onlinePlayersMap.size());
//			onlinePlayersMap.remove(player.getRoleUUID());
//			// System.out.println("++++:"+onlinePlayersMap.size()+":"+onlinePlayers.size());
			
			Player pPlayer = passportIdPlayers.get(player.getPassportId());
			if (pPlayer != null && pPlayer == player) {
				passportIdPlayers.remove(player.getPassportId());
				logoutLogger.info("#removePlayer#passportIdPlayers#offline player passportId=" + player.getPassportId() + 
						";player=" + player.getClientIp() + ";pPlayer=" + pPlayer.getClientIp());
			} else {
				// 两个player不是一个，记录警告日志
				logoutLogger.warn("#removePlayer#passportIdPlayers#not same!offline player passportId=" + player.getPassportId() + 
						";player=" + player.getClientIp() + ";pPlayer=" + (pPlayer != null ? pPlayer.getClientIp() : "null"));
			}
			
			Player oPlayer = onlinePlayersMap.get(player.getRoleUUID());
			if (oPlayer != null && oPlayer == player) {
				if (player.getHuman() != null) {
					player.getHuman().setPlayer(null);
				}
				onlinePlayersMap.remove(player.getRoleUUID());
				logoutLogger.info("#removePlayer#onlinePlayersMap#offline player passportId=" + player.getPassportId() + 
						";player=" + player.getClientIp() + ";pPlayer=" + oPlayer.getClientIp() + 
						";player.getRoleUUID()=" + player.getRoleUUID());
			} else {
				// 两个player不是一个，记录警告日志
				logoutLogger.warn("#removePlayer#onlinePlayersMap#not same!offline player passportId=" + player.getPassportId() + 
						";player=" + player.getClientIp() + ";pPlayer=" + (oPlayer != null ? oPlayer.getClientIp() : "null") + 
						";player.getRoleUUID()=" + player.getRoleUUID());
			}
			
			onlinePlayers.remove(player);
			// System.out.println("++++:"+onlinePlayers.size());
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			writeLock.unlock();
		}
		player.setState(PlayerState.logouted);
		PIProbeCollector.collect(ProbeName.USERS_EXT, UsersExt.LOGOUT, 1);
	}

	/**
	 * 去除session
	 * 
	 * @param session
	 */
	public void removeSession(ISession session) {
		if (session == null) {
			return;
		}
		// System.out.println("++++++++++"+session);
		Player removePlayer = sessionPlayers.remove(session);
		if (removePlayer == null) {
			return;
		}
		removePlayer.setSession(null);
	}

	/**
	 * 获得全部的session数量
	 * 
	 * @return
	 */
	public int getSessionCount() {
		return sessionPlayers.size();
	}

	/**
	 * 根据 roleUUID 判断用户是否在游戏中
	 * 
	 * @param roleUUID
	 * @return
	 */
	public boolean isRoleOnline(long roleUUID) {
		return onlinePlayersMap.containsKey(roleUUID);
	}

	/**
	 * 如果当前线程不合法，则抛出异常{@link CrossThreadException}
	 */
	@Override
	public boolean checkThread() {
		if (GameServerRuntime.isShutdowning() || !GameServerRuntime.isOpen() || Globals.getMessageProcessor().isStop()) {
			return true;
		}
		if (Thread.currentThread().getId() != Globals.getMessageProcessor().getThreadId()) {
			throw new CrossThreadException();
		}
		return true;
	}

	public GameUnitList<Player> getOnlinePlayers() {
		return onlinePlayers;
	}

	/**
	 * 检查世界否已经爆满
	 * 
	 * @return
	 */
	public boolean isFull() {
		// 当世界总人数达到世界人数上限时爆满
		int onlinePlayerCount = getOnlinePlayerCount();

		if (onlinePlayerCount >= Globals.getServerConfig().getMaxOnlineUsers()) {
			return true;
		}
		return false;
	}

	/**
	 * @param passportId
	 * @return
	 */
	public List<RoleInfo> loadPlayerRoleList(String passportId) {
		try {
			// 从数据库中读取
			List<HumanEntity> humans = Globals.getDaoService().getHumanDao().loadHumans(passportId);
			List<RoleInfo> roles = new ArrayList<RoleInfo>(humans.size());
			// 进行转换
			for (int i = 0; i < humans.size(); i++) {
				HumanEntity human = humans.get(i);
				RoleInfo roleInfo = new RoleInfo();
				roleInfo.setRoleUUID(human.getId());
				roleInfo.setName(human.getName());
				roleInfo.setServerId(human.getServerId());
				// roleInfo.setFirstLogin(human.getSceneId() <= 0);
				roles.add(roleInfo);

				// if (roleInfo.getFirstLogin()) {
				//
				// 如果是第一次登陆, 则获取玩家武将列表!
				// 主要目的是用于引导步骤第一步的战报播放, 战报会根据兵种的不同而不同!
				// XXX 注意, 新注册的玩家此时只有一个主(武)将
				//
				// List<PetEntity> petEntities =
				// Globals.getDaoService().getPetDao().getPetsByCharId(human.getId());
				// PetEntity petEntity = petEntities.get(0);
				// CustomPetSelection petSel = new CustomPetSelection();
				// petSel.setTemplateId(petEntity.getTemplateId());
				// petSel.setHair(petEntity.getHair());
				// petSel.setFeature(petEntity.getFeature());
				// petSel.setJob(petEntity.getSoldierId());
				// roleInfo.setSelection(petSel);
				// }
			}
			return roles;
		} catch (DataAccessException e) {
			Loggers.playerLogger.error(LogUtils.buildLogInfoStr(passportId, "#GS.PlayerManagerImpl.loadPlayersByPid"), e);
			return null;
		}
	}

	/**
	 * 
	 * @param playerChar
	 */
	public boolean createRole(Player player, RoleInfo roleInfo) {
		try {
			List<RoleInfo> rolesCheck = Globals.getOnlinePlayerService().loadPlayerRoleList(player.getPassportId());
			// 如果此账号有角色创建
			if (!Globals.getLoginLogicalProcessor().canCreateRole(player, rolesCheck)) {
				player.sendErrorMessage(Globals.getLangService().getSysLangSerivce().read(LangConstants.CREATE_EXIST_ROLE_ERROR));
				return false;
			}
			
			// 插入角色对象
			// 获得UUID
			roleInfo.setRoleUUID(Globals.getUUIDService().getNextUUID(UUIDType.HUMAN));
			// 设置来源服务器
			roleInfo.setServerId(player.getFromServerId());
			HumanEntity humanEntity = roleInfo.toEntity();
			// 2014-05-28 增加创角ip
//			humanEntity.setCreateCharacterIp(player.getClientIp());
			
			long petUUID = Globals.getUUIDService().getNextUUID(UUIDType.PET);
			final long humanUUID = roleInfo.getRoleUUID();
			final int petTemplateId = roleInfo.getSelection().getPetTemplateId();
			PetEntity petEntity = createNewPetEntity(humanUUID, petUUID, petTemplateId);
			
//			long horseUUID = Globals.getUUIDService().getNextUUID(UUIDType.HORSE);
//			HorseEntity horseEntity= createNewHorseEntity(humanUUID, horseUUID);

			// 将两个SAVE变成一个数据库事务执行Human和Pet以及坐骑的存储操作
			boolean _saveSucc = Globals.getDaoService().getQueryHelper().saveHumanPetHibTransaction(humanEntity, petEntity);
			if (_saveSucc) {
				List<RoleInfo> roles = Lists.newArrayList();
				roles.add(roleInfo);
				player.setRoles(roles);
				return true;
			} else {
				return false;
			}
		} catch (DataAccessException e) {
			Loggers.playerLogger.error(LogUtils.buildLogInfoStr(player.getPassportId(), "PlayerManagerImpl.createCharacter"), e);
			player.sendErrorMessage(Globals.getLangService().getSysLangSerivce().read(LangConstants.LOGIN_UNKOWN_ERROR));
			return false;
		} finally {
			player.setCreatingRole(false);
		}
	}

	/**
	 * @description: 创建新的武将
	 * @param charId
	 * @param generalTmplId
	 * @return
	 */
	public PetEntity createNewPetEntity(long charId, long customPetId, int generalTmplId) {
		Pet _createCustomPet = PetHelper.createNewPetFromTemplate(generalTmplId, customPetId);
		PetEntity _entity = _createCustomPet.toEntity();
		_entity.setCharId(charId);
		//主将
		_entity.setPetType(PetType.LEADER.getIndex());
		//状态为正常
		_entity.setPetState(PetState.NORMAL.index);
		
//		PetTemplate tpl = Globals.getTemplateCacheService().get(generalTmplId, PetTemplate.class);
		//默认一级，白色
		_entity.setLevel(RoleConstants.PET_INIT_LEVEL_NUM);
		_entity.setColorId(PetQuality.WHITE.index);
//		//星级读模板
//		_entity.setStarId(tpl.getStars());
		
		return _entity;
	}
	
//	/**
//	 * @description: 创建新的坐骑
//	 * @param charId
//	 * @param generalTmplId
//	 * @return
//	 */
//	public HorseEntity createNewHorseEntity(long charId, long customPetId) {
//		Horse _createCustomPet = PetHelper.createNewHorse(customPetId);
//		HorseEntity _entity = _createCustomPet.toEntity();
//		_entity.setCharId(charId);
//		return _entity;
//	}

	/**
	 * 根据姓名获得角色信息
	 * 
	 * @param name
	 * @return
	 */
	public String loadPlayerByName(String name) {
		HumanEntity humanEntity = Globals.getDaoService().getHumanDao().loadHuman(name);
		if (humanEntity != null) {
			return humanEntity.getName();
		} else {
			return null;
		}
	}

	/**
	 * XXX 强制下线，用于普通踢人无法成功
	 * 
	 * @param player
	 * @return
	 */
	public boolean forceKickOutPlayer(long _charId) {

		Player player = Globals.getOnlinePlayerService().getPlayer(_charId);
		if (player == null) {
			logoutLogger.info("ForceKickOutCommand.doExec The player found,but offline uuid=" + _charId);
			return false;
		}
		player.sendMessage(new GCNotifyException(DisconnectReason.GM_KICK.code, Globals.getLangService().readSysLang(LangConstants.GM_KICK)));

		Human human = player.getHuman();
		// TODO
		if (human != null) {
			
			long now = Globals.getTimeService().now();
			Globals.getLogService().sendPlayerLoginLog(player.getHuman(), LogReasons.PlayerLoginLogReason.PLAYER_LOGOUT_TICK, player.getClientIpOnLoginLog(),
					player.getCurrTerminalType().getSource(), now, player.getSource());
			
			logoutLogger.info("ForceKickOutCommand.doExec Human is found uuid = " + _charId + ";" + "name=" + human.getName());
			// 离开boss战场景
			// Globals.getBossWarService().onPlayerQuitBossWar(human.getUUID());
			// logoutLogger.info("ForceKickOutCommand.doExec onPlayerQuitBossWar uuid = "
			// + _charId +";" + "name=" + human.getName());
			// if(human.getRelationManager() != null){
			// human.getRelationManager().onHumanLogout();
			// logoutLogger.info("ForceKickOutCommand.doExec onHumanLogout uuid = "
			// + _charId +";" + "name=" + human.getName());
			// }

			// 退出护航场景， 改为向场景发消息来修改map
			// IMessage escortOnPlayerOfflineMessage = new
			// EscortOnPlayerOfflineMessage(human.getUUID());
			// Globals.getSceneService().getEscortScene().putMessage(escortOnPlayerOfflineMessage);
			// logoutLogger.info("ForceKickOutCommand.doExec EscortOnPlayerOfflineMessage uuid = "
			// + _charId +";" + "name=" + human.getName());

			// 退出阵营战场景，改为往场景里发消息，否则会多线程 读/改 map
			// IMessage campwarPlayerOfflineMsg = new
			// CampWarOnPlayerOfflineMessage(human.getUUID());
			// Globals.getSceneService().getCampWarScene().putMessage(campwarPlayerOfflineMsg);
			// logoutLogger.info("ForceKickOutCommand.doExec CampWarOnPlayerOfflineMessage uuid = "
			// + _charId +";" + "name=" + human.getName());

			// 防沉迷
			Globals.getWallowService().onPlayerExit(player.getPassportId());
			logoutLogger.info("ForceKickOutCommand.doExec Wallow.onPlayerExit uuid = " + _charId + ";" + "name=" + human.getName());
		}
		ISession session = player.getSession();
		if (session != null) {
			Globals.getOnlinePlayerService().removeSession(player.getSession());
		}
		logoutLogger.info("ForceKickOutCommand.doExec removeSession uuid = " + _charId + ";");
		if (player.getHuman() != null) {
			player.getHuman().setPlayer(null);
			logoutLogger.info("ForceKickOutCommand.doExec setPlayer(null) uuid = " + _charId + ";");
			onlinePlayersMap.remove(_charId);
			logoutLogger.info("ForceKickOutCommand.doExec onlinePlayersMap.remove uuid = " + _charId + ";");
//			roleNamePlayers.remove(player.getHuman().getName());
			logoutLogger.info("ForceKickOutCommand.doExec roleNamePlayers.remove uuid = " + _charId + ";");
		}
		passportIdPlayers.remove(player.getPassportId());
		logoutLogger.info("ForceKickOutCommand.doExec passportIdPlayers.remove uuid = " + _charId + ";");
		onlinePlayersMap.remove(_charId);
		logoutLogger.info("ForceKickOutCommand.doExec onlinePlayersMap.remove uuid = " + _charId + ";");
		onlinePlayers.remove(player);
		logoutLogger.info("ForceKickOutCommand.doExec onlinePlayers.remove uuid = " + _charId + ";");
		player.setState(PlayerState.logouting);
		logoutLogger.info("ForceKickOutCommand.doExec player.setState(PlayerState.logouting) uuid = " + _charId + ";");
		if (session != null) {
			session.close(false);
		}
		logoutLogger.info("ForceKickOutCommand.doExec session.close uuid = " + _charId + ";");
		return true;
	}
	
	/**
	 * 遍历session集合对象,检查非法链接
	 */
	public void checkISessions() {
//		int i = 0;
		long now = Globals.getTimeService().now();
		Collection<Player> players = onlinePlayersMap.values();
//		logoutLogger.info("OnlinePlayerService.checkISessions begin close session!");
		for (ISession session : sessionPlayers.keySet()) {
			Player player = sessionPlayers.get(session);
			if (players.contains(player)) {
				continue;
			} else {
				if (player == null || player.getCreateSessionTime() + Globals.getConfig().getSessionExpireTime() < now) {
//					++i;
					session.close(true);
				}
			}
		}
//		logoutLogger.info("OnlinePlayerService.checkISessions close " + i + " session!");
	}

	public int getOnlinePlayerNumCache() {
		return onlinePlayerNumCache;
	}

	public void setOnlinePlayerNumCache(int onlinePlayerNumCache) {
		this.onlinePlayerNumCache = onlinePlayerNumCache;
	}

}
