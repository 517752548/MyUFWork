package com.imop.lj.gameserver.player;

import java.sql.Timestamp;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import net.sf.json.JSONObject;

import org.slf4j.Logger;

import com.imop.lj.common.HeartBeatAble;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.NonThreadSafe;
import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.common.constants.DisconnectReason;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.constants.LoginTypeEnum;
import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.constants.TerminalTypeEnum;
import com.imop.lj.common.constants.WallowConstants;
import com.imop.lj.common.constants.WallowConstants.WallowStatus;
import com.imop.lj.common.model.human.ChatInfo;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.MessageQueue;
import com.imop.lj.core.util.Assert;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.core.util.JsonUtils;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.gameserver.chat.msg.GCChatMsg;
import com.imop.lj.gameserver.chat.msg.GCChatMsgList;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.SysMsgShowTypes.SysMessageType;
import com.imop.lj.gameserver.common.event.BeforePlayerMsgExecuteEvent;
import com.imop.lj.gameserver.common.msg.GCPing;
import com.imop.lj.gameserver.common.msg.GCSystemMessage;
import com.imop.lj.gameserver.common.unit.GameUnit;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.auth.AuthPlatform;
import com.imop.lj.gameserver.player.model.RoleInfo;
import com.imop.lj.gameserver.player.msg.CGCreateRole;
import com.imop.lj.gameserver.player.msg.GCNotifyException;
import com.imop.lj.gameserver.player.persistance.PlayerDataNotifier;
import com.imop.lj.gameserver.player.persistance.PlayerDataUpdater;
import com.imop.lj.gameserver.player.sys.GameClientSessionClosedMsg;
import com.imop.lj.gameserver.startup.GameClientSession;
import com.imop.lj.probe.PIProbeCollector;
import com.imop.lj.probe.PIProbeConstants.ProbeName;
import com.opi.gibp.probe.category.ProcessResult;
import com.opi.gibp.probe.category.Request;

/**
 * 游戏中的玩家，维护玩家的会话和玩家所有角色的引用
 * 
 */
public class Player implements HeartBeatAble, NonThreadSafe, GameUnit,
		InitializeRequired {
	private static Logger dbLogger = Loggers.dbLogger;
	private Logger logoutLogger = Loggers.logoutLogger;

	/** 玩家上线时由玩家所属GameServer分配的 */
	private int id;
	/** 玩家当前使用的角色 */
	private Human human;
	/** 玩家所有已创建角色列表 */
	private List<Human> allHumans;
	/** 玩家所属场景线程Id */
	private long threadId;
	/** 玩家与GameServer的会话 */
	private GameClientSession session;
	/** 玩家的所有角色列表,登陆选择角色使用 */
	private List<RoleInfo> roles;
	/** 玩家的passport * */
	private String passportId;
	/** 玩家的passprot名称 */
	private String passportName;
	/** 玩家的权限 */
	private int permission;
	/** 玩家今日累计在线时长，分钟数 */
	private int todayOnlineTime;
	/** 玩家今天累计在线时长更新时间 */
	private Timestamp todayOnlineUpdateTime;
	/** 上次玩家登录时间 */
	private Timestamp lastLoginTime;
	/** 上次玩家登出时间 */
	private Timestamp lastLogoutTime;
	/** 玩家的消息队列 */
	private MessageQueue msgQueue;

	/** 是否已激活 */
	private boolean activity;

	/** 最后一次发送聊天消息的时间 */
	private transient Map<Integer, Long> lastChatTime;
	/** 最后一次执行好友搜索的时间 */
	private transient long lastSearchTime;
	/** 玩家的状态 */
	private PlayerStateManager stateManager;
	/** 玩家数据更新调度器 */
	private PlayerDataUpdater dataUpdater;
	/** 数据变更通知器 */
	private PlayerDataNotifier dataNotifier;
	/** 玩家ip地址 */
	private String clientIp;
	/** 退出原因 */
	public PlayerExitReason exitReason;
	/** 处理的消息总数,为避免同步，在主线程中修改 */
	private static volatile long playerMessageCount = 0;
	/** 处理的出错消息个数 */
	private static volatile int playerErrorMessageCount = 0;

	/** 累计在线时长 秒 */
	private int accOnlineTime;
	/** 防沉迷标识 */
	private int wallowFlag;
	/** 防沉迷状态 */
	private WallowStatus wallowState = WallowStatus.NORMAL;

	/** 目标场景id */
	private int targetSceneId;

	/** 是否在竞技场中 */
	private volatile boolean isInArena;

	/** 记录终端信息 */
	private String source;
	/** 屏幕宽度，用于计算同屏显示 */
	private int screenWidth;
	/** 屏幕高度，用于计算同屏显示 */
	private int screenHeight;
	/** 终端id */
	private String deviceID;
	/** 设备类型 */
	private String deviceType;
	/** 设备版本号 */
	private String deviceVersion;
	/** 客户端版本号 */
	private String clientVersion;
	/** 客户端语言类型 */
	private String clientLanguage;
	/** 客户端appid */
	private String appid;
	/** f值 */
	private String fValue;
	/** 禁言时间 */
	private long foribedTime;

	/** 当前终端类型 */
	private TerminalTypeEnum _currTerminalType = TerminalTypeEnum.WEB;
	/** 汇报代理 */
	private String logAgent = "platform-local-sdk";
	/** 汇报代理 */
	private String deviceGuid = "";
	/** MAC地址 */
	private String deviceMac = "";
	/** IMEI串号 */
	private String deviceImei = "";
	/** UDID */
	private String deviceUdid = "";
	/** iso idfa */
	private String deviceIdfa = "";
	/** iso idfv */
	private String deviceIdfv = "";
	/** 客户端代理串 */
	private String deviceUserAgent = "";
	/** 接入网络方式 */
	private String deviceConnectType = "";
	/** 是否越狱 */
	private int deviceJailbroken = -1;
	/** 当前会话的登陆方式 */
	private LoginTypeEnum loginType = null;

	/** cookie值 */
	private String cookieValue;
	/** 创建玩家时的锁，防止玩家用封包频繁发送{@link CGCreateRole}消息 */
	private volatile boolean creatingRole;

	private long dbUpdateTime;

	private long dbUpdateLogTime;

	// 其他平台相关
	// 其他平台名称
	private String channelName;
	// TODO 平台登陆方式，预留
	private String otherPlatformLogin;

	/** 登陆平台 */
	private AuthPlatform authPlatform;
	
	/** 创建player对象时时间*/
	private long createSessionTime;
	
//	/**
//	 * 玩家qq数据，登录后重置，下线时存库
//	 */
//	private QQDataManager qqDataManager;
	
	/** 最后一次发送GCPing的时间 */
	private long lastGCPingTime;
	
	/** 玩家来源服务器Id */
	private int fromServerId;

	public Player(GameClientSession session) {
		this.session = session;
		this.stateManager = new PlayerStateManager(this);
		this.source = "";
		this.passportId = "";
		this.createSessionTime = Globals.getTimeService().now();
//		this.qqDataManager = new QQDataManager();
		// 默认终端为web
	}

	@Override
	public void init() {
		this.msgQueue = new MessageQueue();
		dataUpdater = new PlayerDataUpdater();
		dataNotifier = new PlayerDataNotifier(Globals.getEventService());
		lastChatTime = new HashMap<Integer, Long>();
	}

	@Override
	public boolean checkThread() {
		return false;// FIXME
	}

	public void setSession(GameClientSession session) {
		this.session = session;
	}

	public void setHuman(Human human) {
		this.human = human;
	}

	public Human getHuman() {
		return human;
	}

	/**
	 * 获取当前终端类型
	 * 
	 * @return
	 */
	public TerminalTypeEnum getCurrTerminalType() {
		return this._currTerminalType;
	}

	/**
	 * 设置当前终端类型
	 * 
	 * @param value
	 */
	public void setCurrTerminalType(TerminalTypeEnum value) {
		this._currTerminalType = value;
	}

	/**
	 * 放置玩家需要处理的消息
	 * 
	 * @param msg
	 */
	public void putMessage(IMessage msg) {
//		if (msgQueue == null) {
//			System.out.println("msg queue is null! msg=" + msg);
//		}
		this.msgQueue.put(msg);
		// 记录玩家处理消息个数
		playerMessageCount++;
	}

	/**
	 * 处理服务器收到的来自玩家的消息，在玩家当前所属的场景线程中调用
	 */
	public void processMessage() {
		for (int i = 0; i < SharedConstants.PLAYER_EXEC_NUM; i++) {
			if (msgQueue.isEmpty()) {
				break;
			}
			IMessage msg = msgQueue.get();
			Assert.notNull(msg);
			long begin = System.nanoTime();
			// 收到请求
			PIProbeCollector.collect(ProbeName.REQUEST, Request.RECEIVE, 1);

			try {
				if (!stateManager.canProcess(msg)) {
					Loggers.playerLogger.warn(LogUtils.buildLogInfoStr(
							human.getUUID() + "", "msg type " + msg.getType()
									+ " can't be processed in curState:"
									+ stateManager.getState()));
					return;
				} else {
					if (Loggers.msgLogger.isDebugEnabled()) {
						Loggers.msgLogger.debug(this.human.getUUID()
								+ ":【execute】" + msg);
					}
					
					// 特殊事件处理，打坐等用
					try {
						Globals.getEventService().fireEvent(new BeforePlayerMsgExecuteEvent(this, msg));
					} catch (Exception e) {
						e.printStackTrace();
						Loggers.playerLogger.error("#Player#processMessage#fireEvent Exception!pid=" + 
								getPassportId() + ";charId=" + getCharId() + ";msg=" + msg, e);
					}
					
					msg.execute();
					long handleEndTime = System.nanoTime();
					long handleTime = (handleEndTime - begin) / 1000000;
					// 处理请求成功
					PIProbeCollector.collect(ProbeName.REQUEST,
							Request.SUCCESS, 1);
					// 处理消息成功
					PIProbeCollector.collect(ProbeName.MSG,
							ProcessResult.SUCCESS, handleTime);
				}
			} catch (Throwable e) {
				playerErrorMessageCount++;
				Loggers.playerLogger.error("Process input message error!msg=" + msg, e);
				e.printStackTrace();
				sendMessage(new GCNotifyException(
						DisconnectReason.HANDLE_MSG_EXCEPTION.code, ""));
				this.exitReason = PlayerExitReason.SERVER_ERROR;
				this.disconnect();
				// 处理请求成功
				PIProbeCollector.collect(ProbeName.REQUEST, Request.FAIL, 1);
				// 处理消息失败
				PIProbeCollector.collect(ProbeName.MSG, ProcessResult.FAIL,
						(System.nanoTime() - begin) / 1000000);
			} finally {
				// 特例，统计时间跨度
				long time = (System.nanoTime() - begin) / (1000 * 1000);
				if (time > 1) {
					int type = msg.getType();
					Loggers.clientLogger.info("Message:" + msg.getTypeName() + ":"
							+ msg.getClass().getSimpleName()
							+ " Type:" + type + " Time:" + time + "ms"
							+ " Total:" + playerMessageCount + " Error:"
							+ playerErrorMessageCount);
				}
			}
		}
	}

	/**
	 * 将消息发送给Player
	 * 
	 * @param msg
	 */
	public void sendMessage(IMessage msg) {
		Assert.notNull(msg);
		if (!stateManager.needSend(msg.getType())) {
			Loggers.msgLogger.debug("msg:" + msg
					+ " don't need to be send to player in curState:"
					+ stateManager.getState());
			return;
		}
		
		// 如果是聊天消息
		if (msg instanceof GCChatMsg) {
			// 如果发送消息者在该玩家的黑名单中，则不给该玩家发此消息
			if (((GCChatMsg) msg).getChatInfo() != null) {
				String fromRoleUUIDStr = ((GCChatMsg) msg).getChatInfo().getFromRoleUUID();
				if (null != fromRoleUUIDStr
						&& !fromRoleUUIDStr.equalsIgnoreCase("")) {
					if (Globals.getRelationService().isTargetInBlackList(
							getHuman(), Long.parseLong(fromRoleUUIDStr))) {
						return;
					}
				}
			}
		} else if (msg instanceof GCChatMsgList) {
			// 如果发送消息者在该玩家的黑名单中，则不给该玩家发此消息
			int len = ((GCChatMsgList) msg).getChatInfos().length;
			if (len > 0) {
				List<ChatInfo> tmpList = new ArrayList<ChatInfo>();
				for (int i = 0; i < len; i++) {
					String fromRoleUUIDStr = ((GCChatMsgList) msg).getChatInfos()[i].getFromRoleUUID();
					if (null != fromRoleUUIDStr
							&& !fromRoleUUIDStr.equalsIgnoreCase("")) {
						if (Globals.getRelationService().isTargetInBlackList(
								getHuman(), Long.parseLong(fromRoleUUIDStr))) {
							//黑名单的需要过滤掉
						} else {
							tmpList.add(((GCChatMsgList) msg).getChatInfos()[i]);
						}
					}
				}
				if (tmpList.size() != len) {
					((GCChatMsgList) msg).setChatInfos(tmpList.toArray(new ChatInfo[0]));
				}
			}
		}

		if (session != null) {
			session.write(msg);
		}
	}

	public void setThreadId(long threadId) {
		this.threadId = threadId;
	}

	public long getThreadId() {
		return threadId;
	}

	public void setAllHumans(List<Human> allHumans) {
		this.allHumans = allHumans;
	}

	public List<Human> getAllHumans() {
		return allHumans;
	}

	public List<RoleInfo> getRoles() {
		return roles;
	}

	public void setRoles(List<RoleInfo> roles) {
		this.roles = roles;
	}

	public void setPassportId(String passportId) {
		this.passportId = passportId;
	}

	public String getPassportId() {
		return passportId;
	}

	@Override
	public int getId() {
		return id;
	}

	@Override
	public void setId(int id) {
		this.id = id;
	}

	/**
	 * @param state
	 * @return 当状态设置成功返回真
	 */
	public boolean setState(PlayerState state) {
		if (state == PlayerState.logouting
				&& this.getState() == PlayerState.logouting) {
			return true;
		}
		return this.stateManager.setState(state);
	}

	/**
	 * @return
	 */
	public PlayerState getState() {
		return this.stateManager.getState();
	}

	/**
	 * 判断玩家当前是否在场景中
	 * 
	 * @return
	 */
	public boolean isInScene() {
		if (human != null) {
			return human.getScene() != null;
		} else {
			return false;
		}

	}

	/**
	 * @return
	 */
	public GameClientSession getSession() {
		return session;
	}

	/**
	 * 判断玩家是否在线
	 * 
	 * @return
	 */
	public boolean isOnline() {
		if (null == session) {
			return false;
		}
		return session.isConnected();
	}

	/**
	 * @return the lastChatTime
	 */
	public long getLastChatTime(int scope) {
		Long time = this.lastChatTime.get(scope);

		if (time == null) {
			return 0;
		}
		return time;
	}

	/**
	 * @param lastChatTime
	 *            the lastChatTime to set
	 */
	public void setLastChatTime(int scope, long lastChatTime) {
		this.lastChatTime.put(scope, lastChatTime);
	}

	public long getLastSearchTime() {
		return lastSearchTime;
	}

	public void setLastSearchTime(long lastSearchTime) {
		this.lastSearchTime = lastSearchTime;
	}

	/**
	 * @return
	 */
	public int getSceneId() {
		return human.getSceneId();
	}

	public void setTargetSceneId(int targetSceneId) {
		this.targetSceneId = targetSceneId;
	}

	public int getTargetSceneId() {
		return targetSceneId;
	}

	/**
	 * 获得玩家当前角色UUID
	 * 
	 * @return
	 */
	public long getRoleUUID() {
		if (human == null) {
			return -1l;
		} else {
			return human.getUUID();
		}
	}

	public PlayerStateManager getStateManager() {
		return stateManager;
	}

	/**
	 * 在处理玩家消息出现异常时调用
	 */
	public void onException() {
		if (session.closeOnException()) {
			// 此处会自动触发GameServerIoHandler#sessionClosed
			session.close(false);
		}
	}

	/**
	 * 关闭用户连接,解除和session的绑定
	 * 
	 */
	public void disconnect() {
		if (this.session != null && this.session.isConnected()) {
			// 此处会自动触发GameServerIoHandler#sessionClosed
			logoutLogger.info(this.getClientIp()
					+ " 1、Player logout player.disconnect "
					+ " player passportId" + this.passportId + " player state"
					+ this.getState().name() + " this.session = "
					+ this.session == null ? "" : this.session.isConnected()
					+ ";");
			this.session.close(false);
		} else {
			String aa = this.session == null ? "" : this.session.isConnected()
					+ ";";
			logoutLogger.info(this.getClientIp()
					+ " 2、Player logout player.disconnect " + " player passid"
					+ this.passportId + " player state"
					+ this.getState().name() + " this.session = " + aa);
			// XXX 这里应该有问题，session可能为空，改为可传入player
			IMessage msg = new GameClientSessionClosedMsg(this.session, this);
			Globals.getMessageProcessor().put(msg);
		}
	}

	public void setPassportName(String passportName) {
		this.passportName = passportName;
	}

	public String getPassportName() {
		return passportName;
	}

	public void setPermission(int permission) {
		this.permission = permission;
	}

	public int getPermission() {
		return permission;
	}

	public void setTodayOnlineTime(int todayOnlineTime) {
		this.todayOnlineTime = todayOnlineTime;
	}

	public int getTodayOnlineTime() {
		return todayOnlineTime;
	}

	public void setLastLoginTime(Timestamp lastLogoutTime) {
		this.lastLoginTime = lastLogoutTime;
	}

	public Timestamp getLastLoginTime() {
		return lastLoginTime;
	}

	public void setLastLogoutTime(Timestamp lastLogoutTime) {
		this.lastLogoutTime = lastLogoutTime;
	}

	public Timestamp getLastLogoutTime() {
		return lastLogoutTime;
	}

	public int getAccOnlineTime() {
		return accOnlineTime;
	}

	public void setAccOnlineTime(int accOnlineTime) {
		this.accOnlineTime = accOnlineTime;
	}

	public int getWallowFlag() {
		return wallowFlag;
	}

	public void setWallowFlag(int wallowFlag) {
		this.wallowFlag = wallowFlag;
	}

	public WallowStatus getWallowState() {
		return wallowState;
	}

	public void setWallowState(WallowStatus wallowState) {
		this.wallowState = wallowState;
	}
	
	/**
	 * 玩家是否防沉迷用户
	 * 1、防沉迷功能开启，且为web登录
	 * 2、玩家是防沉迷用户
	 * @return
	 */
	public boolean isWallowPlayer() {
		boolean flag = false;
		// 防沉迷控制开启
		if (Globals.getServerConfig().isWallowControlled() && 
				getCurrTerminalType() == TerminalTypeEnum.WEB) {
			// 玩家是防沉迷用户
			if (getWallowFlag() == WallowConstants.WALLOW_FLAG_ON) {
				flag = true;
			}
		}
		return flag;
	}

	/**
	 * 更新数据
	 */
	public void updateData() {
		try {
			dataUpdater.update();
		} catch (Exception e) {
			if (Loggers.updateLogger.isErrorEnabled()) {
				Loggers.updateLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.INVALID_STATE,
						"#GS.ServiceBuilder.buildGameMessageHandler", ""), e);
			}
		}
		try {
			dataNotifier.onChange();
		} catch (Exception e) {
			if (Loggers.updateLogger.isErrorEnabled()) {
				Loggers.updateLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.INVALID_STATE, "#GS..execute", ""),
						e);
			}
		}
	}

	/**
	 * @return
	 */
	public PlayerDataUpdater getDataUpdater() {
		return dataUpdater;
	}

	/**
	 * @return
	 */
	public PlayerDataNotifier getDataNotifier() {
		return dataNotifier;
	}

	@Override
	public void heartBeat() {
		stateManager.onHeartBeat();
		human.heartBeat();

		long now = Globals.getTimeService().now();
		if (Globals.getConfig().isUpgradeDbStrategy()) {
			// TODO 判断
			int dbUpdteInterval = Globals.getConfig().getDbUpdateInterval();
			if (now > (this.dbUpdateTime + dbUpdteInterval)) {
				this.updateData();
				this.dbUpdateTime = now;
				this.dbUpdateLogTime = now;
				if (dbLogger.isDebugEnabled()) {
					// XXX log采样
					if (Globals.getConfig().isCollectStrategy()) {
						if (this.getCharId()
								% Globals.getConfig().getCollectSimpling() == 0) {
							dbLogger.debug(String
									.format("UPDATE_DATA[pid=%s,charid=%s,interval=%s,time=%s] is successed with UpgradeDbStrategy",
											this.passportId + "",
											this.getCharId() + "",
											dbUpdteInterval + "",
											this.dbUpdateTime + ""));
						}
					} else {
						dbLogger.debug(String
								.format("UPDATE_DATA[pid=%s,charid=%s,interval=%s,time=%s] is successed with UpgradeDbStrategy",
										this.passportId + "", this.getCharId()
												+ "", dbUpdteInterval + "",
										this.dbUpdateTime + ""));
					}
				}
			} else {
				if (dbLogger.isDebugEnabled()) {
					if (now > (this.dbUpdateLogTime + 1000)) {
						this.dbUpdateLogTime = this.dbUpdateLogTime + 1000;
						// XXX log采样
						if (Globals.getConfig().isCollectStrategy()) {
							if (this.getCharId()
									% Globals.getConfig().getCollectSimpling() == 0) {
								dbLogger.debug(String
										.format("UPDATE_DATA[pid=%s,charid=%s,interval=%s,time=%s] is skipped with UpgradeDbStrategy ",
												this.passportId + "",
												this.getCharId() + "",
												dbUpdteInterval + "",
												this.dbUpdateTime + ""));
							}
						} else {
							dbLogger.debug(String
									.format("UPDATE_DATA[pid=%s,charid=%s,interval=%s,time=%s] is skipped with UpgradeDbStrategy ",
											this.passportId + "",
											this.getCharId() + "",
											dbUpdteInterval + "",
											this.dbUpdateTime + ""));
						}
					}
				}
			}
		} else {
			this.updateData();
			if (dbLogger.isDebugEnabled()) {
				this.dbUpdateTime = now;
				dbLogger.debug(String
						.format("UPDATE_DATA[pid=%s,charid=%s,time=%s] is successed without UpgradeDbStrategy",
								this.passportId + "", this.getCharId() + "",
								this.dbUpdateTime + ""));
			}
		}
	}

	public long getCharId() {
		if (this.human == null) {
			return -1;
		}
		return this.human.getUUID();
	}

	public void setClientIp(String clientIp) {
		this.clientIp = clientIp;
	}

	public String getClientIp() {
		return clientIp;
	}
	
	/**
	 * 获取不带端口号的客户端ip地址
	 * @return
	 */
	public String getClientIpNoPort() {
		String ipnoport = "";
		String ipandport = getClientIp();
		if (ipandport != null && !ipandport.equalsIgnoreCase("") && ipandport.contains(":")) {
			String[] arr = ipandport.split(":");
			ipnoport = arr[0];
		} else {
			ipnoport = ipandport;
		}
		if (ipnoport == null) {
			ipnoport = "";
		}
		return ipnoport;
	}

	/***
	 * 记录登陆日志用
	 * @return
	 */
	public String getClientIpOnLoginLog() {
		String str = "ip=";
		if(clientIp==null){
		}else{
			str = str +clientIp;
		}
		return str;
	}
	
	public boolean isInArena() {
		return isInArena;
	}

	public void setInArena(boolean isInArena) {
		this.isInArena = isInArena;
	}
	
	/**
	 * 获取玩家来源服务器Id
	 * @return
	 */
	public int getFromServerId() {
		return fromServerId;
	}

	/**
	 * 获取经过校验的来源服务器，如果非法，则返回本服的服务器Id
	 * @param source
	 * @return
	 */
	protected int getCheckedServerId(JSONObject jsonObj) {
		// 默认为本服
		int serverId = Globals.getServerConfig().getServerIdInt();
		
		int fromServerId = JsonUtils.getInt(jsonObj, "fromServerId");
		if (Globals.isValidServerId(fromServerId)) {
			serverId = fromServerId;
		}
		return serverId;
	}
	
	/**
	 * 解析source信息
	 * 
	 * @param source
	 */
	public void setSource(String source) {
		try {
			JSONObject jsonObj = JSONObject.fromObject(source);
			
			// 玩家来源服务器
			fromServerId = getCheckedServerId(jsonObj);
			
			// 设备来源|终端id|设备类型|设备版本号|客户端版本号|客户端语言类型
			// 设备来源
			String deviceStr = JsonUtils.getString(jsonObj, "source", "-1");
			
			//屏幕宽高
			screenWidth = JsonUtils.getInt(jsonObj, "screenWidth", Globals.getGameConstants().getScreenWidth());
			screenHeight = JsonUtils.getInt(jsonObj, "screenHeight", Globals.getGameConstants().getScreenHeight());
			
			// 终端id
			deviceID = JsonUtils.getString(jsonObj, "deviceID", "pc");
			// 设备类型
			deviceType = JsonUtils.getString(jsonObj, "deviceType", "-1");
			// 设备版本号
			deviceVersion = JsonUtils.getString(jsonObj, "deviceVersion", "-1");
			// 客户端版本号
			clientVersion = JsonUtils.getString(jsonObj, "clientVersion", "-1");
			// 客户端语言类型
			clientLanguage = JsonUtils.getString(jsonObj, "clientLanguage",
					"-1");
			// 客户端appid
			appid = JsonUtils.getString(jsonObj, "appid", "-1");
			// f值
			fValue = JsonUtils.getString(jsonObj, "fValue", "-1");
			// 汇报代理
			// logAgent = JsonUtils.getString(jsonObj, "logAgent", "-1");
			// 设备唯一识别id
			deviceGuid = JsonUtils.getString(jsonObj, "deviceGuid", "-1");
			// 设备mac地址
			deviceMac = JsonUtils.getString(jsonObj, "deviceMac", "-1");
			// IMEI串号
			deviceImei = JsonUtils.getString(jsonObj, "deviceImei", "-1");
			// udid
			deviceUdid = JsonUtils.getString(jsonObj, "deviceUdid", "-1");
			// idfa
			deviceIdfa = JsonUtils.getString(jsonObj, "deviceIdfa", "-1");
			// idfv
			deviceIdfv = JsonUtils.getString(jsonObj, "deviceIdfv", "-1");
			// 客户端代理串
			deviceUserAgent = JsonUtils.getString(jsonObj, "deviceUserAgent",
					"-1");
			// 接入网络方式
			deviceConnectType = JsonUtils.getString(jsonObj,
					"deviceConnectType", "-1");

			channelName = JsonUtils.getString(jsonObj, "channelName", "");

			otherPlatformLogin = JsonUtils.getString(jsonObj,
					"otherPlatformLogin", "");
			// 是否越狱
			deviceJailbroken = JsonUtils
					.getInt(jsonObj, "deviceJailbroken", -1);

			this.source = deviceStr + "|" + deviceID + "|" + deviceType + "|"
					+ deviceVersion + "|" + clientVersion + "|"
					+ clientLanguage + "|" + appid + "|" + fValue;

			if (deviceStr.equalsIgnoreCase("ipad")) {
				this.setCurrTerminalType(TerminalTypeEnum.IPAD);
				if (null == appid || "".equalsIgnoreCase(appid)
						|| "null".equalsIgnoreCase(appid)) {
					appid = "defaulthd";
				}
			} else if (deviceStr.equalsIgnoreCase("iphone")) {
				this.setCurrTerminalType(TerminalTypeEnum.IPHONE);
				if (null == appid || "".equalsIgnoreCase(appid)
						|| "null".equalsIgnoreCase(appid)) {
					appid = "default";
				}
			} else if (deviceStr.equalsIgnoreCase("android")) {
				this.setCurrTerminalType(TerminalTypeEnum.ANDROID);
				if (null == appid || "".equalsIgnoreCase(appid)
						|| "null".equalsIgnoreCase(appid)) {
					appid = "default";
				}
			} else {
				this.setCurrTerminalType(TerminalTypeEnum.WEB);
				appid = "";
			}

			if (null != channelName) {
				if ("37wanwan".equalsIgnoreCase(channelName)) {
					this.authPlatform = AuthPlatform.G37WANWAN;
					if (fValue == null || "".equalsIgnoreCase(fValue)
							|| "-1".equalsIgnoreCase(fValue)) {
						this.fValue = this.authPlatform.getfValue();
					}
				} 
//				else if (QQDef.QQ_CHANEL_NAME.equalsIgnoreCase(channelName)) {
//					this.authPlatform = AuthPlatform.QQ;
//					if (fValue == null || "".equalsIgnoreCase(fValue)
//							|| "-1".equalsIgnoreCase(fValue)) {
//						this.fValue = this.authPlatform.getfValue();
//					}
//					// 解析qq登录的数据
//					qqSourceExplain(jsonObj);
//				}
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
//	/**
//	 * 解析qq登录的数据
//	 * @param jsonObj
//	 */
//	protected void qqSourceExplain(JSONObject jsonObj) {
//		String seqid = JsonUtils.getString(jsonObj, QQDef.QQ_API_PARAM_KEY_SEQID, "");
//		String openid = JsonUtils.getString(jsonObj, QQDef.QQ_API_PARAM_KEY_OPENID, "");
//		String openkey = JsonUtils.getString(jsonObj, QQDef.QQ_API_PARAM_KEY_OPENKEY, "");
//		String pf = JsonUtils.getString(jsonObj, QQDef.QQ_API_PARAM_KEY_PF, "");
//		String pfkey = JsonUtils.getString(jsonObj, QQDef.QQ_API_PARAM_KEY_PFKEY, "");
//		
//		qqDataManager.setOpenId(openid);
//		qqDataManager.setOpenKey(openkey);
//		qqDataManager.setSeqId(seqid);
//		qqDataManager.setPf(pf);
//		qqDataManager.setPfKey(pfkey);
//		
//		// 邀请相关的参数
//		String iopenid = JsonUtils.getString(jsonObj, QQDef.QQ_API_PARAM_KEY_IOPENID, "");
//		String invkey = JsonUtils.getString(jsonObj, QQDef.QQ_API_PARAM_KEY_INVKEY, "");
//		String itime = JsonUtils.getString(jsonObj, QQDef.QQ_API_PARAM_KEY_ITIME, "");
//		qqDataManager.setIopenid(iopenid);
//		qqDataManager.setInvkey(invkey);
//		qqDataManager.setItime(itime);
//		// 邀请时app自带的参数
//		String app_custom = JsonUtils.getString(jsonObj, QQDef.QQ_API_PARAM_KEY_APPCUSTOM, "");
//		qqDataManager.setApp_custom(app_custom);
//		
//		Globals.getQQService().qqSourceExplain(jsonObj, qqDataManager);
//	}
//	
//	/**
//	 * 登录后解析数据，实际是v3/user/get_info的返回
//	 * @param jsonObj
//	 */
//	public void qqLoginRetExplain(JSONObject jsonObj) {
//		//{"ret":0,"is_lost":0,"nickname":"Peter","gender":"男","country":"中国","province":"广东","city":"深圳","figureurl":"http://imgcache.qq.com/qzone_v4/client/userinfo_icon/1236153759.gif","is_yellow_vip":1,"is_yellow_year_vip":1,"yellow_vip_level":7,"is_yellow_high_vip":0}
//		// 名字做特殊处理，转为十六进制字符串保存
//		String nickName = JsonUtils.getString(jsonObj, QQDef.QQ_RET_KEY_NICKNAME);
//		qqDataManager.setNickName(nickName);
//		
//		qqDataManager.setGender(JsonUtils.getString(jsonObj, QQDef.QQ_RET_KEY_GENDER));
//		qqDataManager.setFigureURL(JsonUtils.getString(jsonObj, QQDef.QQ_RET_KEY_FIGUREURL));
//		// 集市任务状态位
//		qqDataManager.setMarketTaskFlag(JsonUtils.getInt(jsonObj, QQDef.QQ_API_PARAM_KEY_MARKETTASK));
//		qqDataManager.setContractId(JsonUtils.getString(jsonObj, QQDef.QQ_API_PARAM_KEY_CONTRACTID));
//		// vip数据解析
//		qqIsVipRetExplain(jsonObj);
//		// 邀请参数校验
//		Globals.getQQService().qqInviteParamCheck(jsonObj, qqDataManager);
//	}
//	
//	/**
//	 * QQvip数据解析
//	 * @param jsonObj
//	 * @return 是否发生了变化
//	 */
//	public boolean qqIsVipRetExplain(JSONObject jsonObj) {
//		boolean changed = false;
//		changed |= qqDataManager.setIsYellowVip(JsonUtils.getInt(jsonObj, QQDef.QQ_RET_KEY_ISYELLOWVIP));
//		changed |= qqDataManager.setYellowVipLevel(JsonUtils.getInt(jsonObj, QQDef.QQ_RET_KEY_YELLOWVIPLEVEL));
//		changed |= qqDataManager.setIsYellowHighVip(JsonUtils.getInt(jsonObj, QQDef.QQ_RET_KEY_ISYELLOWHIGHVIP));
//		changed |= qqDataManager.setIsYellowYearVip(JsonUtils.getInt(jsonObj, QQDef.QQ_RET_KEY_ISYELLOWYEARVIP));
//		return changed;
//	}
	
	public String getSource() {
		return this.source;
	}

	public int getScreenWidth() {
		return screenWidth;
	}

	public int getScreenHeight() {
		return screenHeight;
	}

	public String getDeviceID() {
		return deviceID;
	}

	public String getDeviceType() {
		return deviceType;
	}

	public String getDeviceVersion() {
		return deviceVersion;
	}

	public String getClientVersion() {
		return clientVersion;
	}

	public String getClientLanguage() {
		return clientLanguage;
	}

	public String getAppid() {
		return appid;
	}

	public String getfValue() {
		return fValue;
	}

	/** 禁言时间 */
	public long getForibedTime() {
		return foribedTime;
	}

	/** 禁言时间 */
	public void setForibedTime(long foribedTime) {
		this.foribedTime = foribedTime;
	}

	public String getCookieValue() {
		return cookieValue;
	}

	public void setCookieValue(String cookieValue) {
		this.cookieValue = cookieValue;
	}

	public String getChannelName() {
		return channelName;
	}

	public void setChannelName(String channelName) {
		this.channelName = channelName;
	}

	public String getOtherPlatformLogin() {
		return otherPlatformLogin;
	}

	public void setOtherPlatformLogin(String otherPlatformLogin) {
		this.otherPlatformLogin = otherPlatformLogin;
	}

	/**
	 * @description: 理论上只需要锁住无需解锁，因为玩家只会创建一次角色，并且此变量下线不存
	 */
	public void setCreatingRole(boolean creatingRole) {
		this.creatingRole = creatingRole;
	}

	public boolean isCreatingRole() {
		return creatingRole;
	}

	/**
	 * 错误提示，3秒消失
	 * 
	 * @param content
	 */
	public void sendErrorMessage(String content) {
		if (human != null) {
			if (human.getMessageControl().reserverErrorMessage(content)) {
				// 如果记录出错信息则返回
				return;
			}
		}
		if (content != null && !"".equals(content)) {
			GCSystemMessage msg = SysMessageType.ERROR_MESSAGE
					.genSystemMessage(content);
			sendMessage(msg);
		}
	}

	/**
	 * 错误提示，3秒消失
	 * 
	 * @param key
	 */
	public void sendErrorMessage(Integer key) {
		String content = Globals.getLangService().readSysLang(key);
		sendErrorMessage(content);
	}

	/**
	 * 错误提示，3秒消失
	 * 
	 * @param key
	 * @param params
	 */
	public void sendErrorMessage(Integer key, Object... params) {
		String content = Globals.getLangService().readSysLang(key, params);
		sendErrorMessage(content);
	}

	/**
	 * 聊天框出现的基本系统提示
	 * 
	 * @param content
	 * @return
	 */
	public void sendSystemMessage(String content) {
		if (content != null && !"".equals(content)) {
			GCSystemMessage msg = SysMessageType.SYSTEM_MESSAGE
					.genSystemMessage(content);
			sendMessage(msg);
		}
	}

	/**
	 * 聊天框出现的基本系统提示
	 * 
	 * @param key
	 */
	public void sendSystemMessage(Integer key) {
		String content = Globals.getLangService().readSysLang(key);
		sendSystemMessage(content);
	}

	/**
	 * 聊天框出现的基本系统提示
	 * 
	 * @param key
	 * @param params
	 */
	public void sendSystemMessage(Integer key, Object... params) {
		String content = Globals.getLangService().readSysLang(key, params);
		sendSystemMessage(content);
	}

	/**
	 * 聊天通告类
	 * 
	 * @param content
	 * @return
	 */
	public void sendChatMessage(String content) {
		if (content != null && !"".equals(content)) {
			GCSystemMessage msg = SysMessageType.CHAT_MESSAGE
					.genSystemMessage(content);
			sendMessage(msg);
		}
	}

	/**
	 * 聊天通告类
	 * 
	 * @param key
	 */
	public void sendChatMessage(Integer key) {
		String content = Globals.getLangService().readSysLang(key);
		sendChatMessage(content);
	}

	/**
	 * 聊天通告类
	 * 
	 * @param key
	 * @param params
	 */
	public void sendChatMessage(Integer key, Object... params) {
		String content = Globals.getLangService().readSysLang(key, params);
		sendChatMessage(content);
	}

	/**
	 * 聊天中的系统信息
	 * 
	 * @param content
	 * @return
	 */
	public void sendChatSystemMessage(String content) {
		if (content != null && !"".equals(content)) {
			GCSystemMessage msg = SysMessageType.CHAT_SYSTEM_MESSAGE.genSystemMessage(content);
			sendMessage(msg);
		}
	}
	
	/**
	 * 聊天中的系统信息
	 * 
	 * @param key
	 */
	public void sendChatSystemMessage(Integer key) {
		String content = Globals.getLangService().readSysLang(key);
		sendChatSystemMessage(content);
	}

	/**
	 * 聊天中的系统信息
	 * 
	 * @param key
	 * @param params
	 */
	public void sendChatSystemMessage(Integer key, Object... params) {
		String content = Globals.getLangService().readSysLang(key, params);
		sendChatSystemMessage(content);
	}
	
	/**
	 * 屏幕中央出现的系统通告,滚屏
	 * 
	 * @param content
	 * @return
	 */
	public void sendNoticeMessage(String content) {
		if (content != null && !"".equals(content)) {
			GCSystemMessage msg = SysMessageType.NOTICE_MESSAGE
					.genSystemMessage(content);
			sendMessage(msg);
		}
	}

	/**
	 * 屏幕中央出现的系统通告,滚屏
	 * 
	 * @param key
	 */
	public void sendNoticeMessage(Integer key) {
		String content = Globals.getLangService().readSysLang(key);
		sendNoticeMessage(content);
	}

	/**
	 * 屏幕中央出现的系统通告,滚屏
	 * 
	 * @param key
	 * @param params
	 */
	public void sendNoticeMessage(Integer key, Object... params) {
		String content = Globals.getLangService().readSysLang(key, params);
		sendNoticeMessage(content);
	}

	/**
	 * 弹窗确定
	 * 
	 * @param content
	 * @return
	 */
	public void sendBoxMessage(String content) {
		if (content != null && !"".equals(content)) {
			GCSystemMessage msg = SysMessageType.BOX_MESSAGE
					.genSystemMessage(content);
			sendMessage(msg);
		}
	}

	/**
	 * 弹窗确定
	 * 
	 * @param key
	 */
	public void sendBoxMessage(Integer key) {
		String content = Globals.getLangService().readSysLang(key);
		sendBoxMessage(content);
	}

	/**
	 * 弹窗确定
	 * 
	 * @param key
	 * @param params
	 */
	public void sendBoxMessage(Integer key, Object... params) {
		String content = Globals.getLangService().readSysLang(key, params);
		sendBoxMessage(content);
	}

	/**
	 * 
	 * 发送商会广播信息
	 * 
	 * @param content
	 */
	public void sendCommerceSystemMessage(String content) {
		if (content != null) {
			GCSystemMessage msg = SysMessageType.GUILD_MESSAGE
					.genSystemMessage(content);
			sendMessage(msg);
		}
	}

	public String getLogAgent() {
		return logAgent;
	}

	public String getDeviceGuid() {
		return deviceGuid;
	}

	public String getDeviceMac() {
		return deviceMac;
	}

	public String getDeviceImei() {
		return deviceImei;
	}

	public String getDeviceUdid() {
		return deviceUdid;
	}

	public String getDeviceIdfa() {
		return deviceIdfa;
	}

	public String getDeviceIdfv() {
		return deviceIdfv;
	}

	public String getDeviceUserAgent() {
		return deviceUserAgent;
	}

	public String getDeviceConnectType() {
		return deviceConnectType;
	}

	public int getDeviceJailbroken() {
		return deviceJailbroken;
	}

	public LoginTypeEnum getLoginType() {
		return loginType;
	}

	public void setLoginType(LoginTypeEnum loginType) {
		this.loginType = loginType;
	}

	public Timestamp getTodayOnlineUpdateTime() {
		return todayOnlineUpdateTime;
	}

	public void setTodayOnlineUpdateTime(Timestamp todayOnlineUpdateTime) {
		this.todayOnlineUpdateTime = todayOnlineUpdateTime;
	}

	public AuthPlatform getAuthPlatform() {
		return authPlatform;
	}

	public void setAuthPlatform(AuthPlatform authPlatform) {
		this.authPlatform = authPlatform;
	}

	public boolean isActivity() {
		if(Globals.getServerConfig().isAccountActivityOpen()){
			return activity;
		}else{
			// 如果没有开启帐号激活策略，则认为所以帐号都为激活帐号
			return true;
		}
	}

	public void setActivity(boolean activity) {
		this.activity = activity;
	}
	
	public long getCreateSessionTime() {
		return createSessionTime;
	}

//	/**
//	 * 获取qq数据管理器
//	 * @return
//	 */
//	public QQDataManager getQqDataManager() {
//		return qqDataManager;
//	}
	
	/**
	 * 心跳消息
	 */
	public void checkGCPing() {
//		if (!Globals.isQQPlatform()) {
//			return;
//		}
		long now = Globals.getTimeService().now();
		if (lastGCPingTime < now - Globals.getGameConstants().getGcPingInterval()) {
			lastGCPingTime = now;
			sendMessage(new GCPing(now));
		}
	}

	public void setDeviceID(String deviceID) {
		this.deviceID = deviceID;
	}

	public void setDeviceType(String deviceType) {
		this.deviceType = deviceType;
	}

	public void setDeviceVersion(String deviceVersion) {
		this.deviceVersion = deviceVersion;
	}

	public void setClientVersion(String clientVersion) {
		this.clientVersion = clientVersion;
	}

	public void setClientLanguage(String clientLanguage) {
		this.clientLanguage = clientLanguage;
	}

	public void setAppid(String appid) {
		this.appid = appid;
	}

	public void setfValue(String fValue) {
		this.fValue = fValue;
	}
	
	
}
