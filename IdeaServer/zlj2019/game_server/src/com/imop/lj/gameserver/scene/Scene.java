package com.imop.lj.gameserver.scene;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;

import org.slf4j.Logger;

import com.imop.lj.common.DestroyRequired;
import com.imop.lj.common.HeartBeatAble;
import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.Tickable;
import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.common.constants.Loggers;
import java.awt.Point;
import com.imop.lj.common.model.ScenePlayerInfoData;
import com.imop.lj.common.model.ScenePlayerPosition;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.MessageQueue;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.object.LifeCycleImpl;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.core.persistance.AbstractSceneDataUpdater;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.db.model.SceneEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutor;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTaskExecutorImpl;
import com.imop.lj.gameserver.common.listener.Listenable;
import com.imop.lj.gameserver.common.listener.Listener;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerState;
import com.imop.lj.gameserver.player.msg.GCEnterScene;
import com.imop.lj.gameserver.scene.manager.ScenePlayerManager;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerForceToCityScene;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerList;
import com.imop.lj.gameserver.scene.persistance.SceneDataUpdater;
import com.imop.lj.gameserver.scene.template.SceneTemplate;

public abstract class Scene implements Tickable, HeartBeatAble, Listenable<SceneListener>, InitializeRequired, DestroyRequired, PersistanceObject<Long, SceneEntity> {
	/** UUID */
	protected long UUID;
	/** 场景模版 */
	protected SceneTemplate sceneTemplate;
//	/** 场景最多人数 */
//	public static final int MAX_PLAYER_COUNT = 3500;
	private static final Logger dbLogger = Loggers.dbLogger;

	/** 场景的消息队列 */
	protected MessageQueue msgQueue;

	/** 场景玩家管理 */
	protected ScenePlayerManager playerManager;

	/** 心跳任务处理器 */
	protected HeartbeatTaskExecutor hbTaskExecutor;

	/** 注册到该场景上的监听器 */
	protected List<SceneListener> listeners;
	/** 场景数据更新器 */
	protected SceneDataUpdater dataUpdater;
	/** 生命周期 */
	protected LifeCycle lifeCycle;
	/** 此实例是否在db中 */
	protected boolean isInDb;
	
	protected static final Logger log = Loggers.msgLogger;

	public Scene(
		SceneTemplate template,
		OnlinePlayerService onlinePlayerService) {
		if (template == null) {
			throw new IllegalArgumentException("template is null");
		}

		if (onlinePlayerService == null) {
			throw new IllegalArgumentException("onlinePlayerService is null");
		}

		this.sceneTemplate = template;

		msgQueue = new MessageQueue();
		playerManager = new ScenePlayerManager(this, onlinePlayerService, Globals.getServerConfig().getMaxOnlineUsers());
		listeners = new ArrayList<SceneListener>(
				SceneListener.DEFAULT_LISTENER_CONTAINER_CAPACITY);
		hbTaskExecutor = new HeartbeatTaskExecutorImpl();
		// 增加定时更新场景玩家的任务
//		hbTaskExecutor.submit(new ScenePlayerRefresh(this));
		hbTaskExecutor.submit(new SceneCheckTickTask(this));

		this.dataUpdater = new SceneDataUpdater();

		// 设置生命周期并激活
		this.lifeCycle = new LifeCycleImpl(this);
		this.lifeCycle.activate();
	}

	@Override
	public void init() {
		
	}

	/**
	 * @warning 在主处理线程中被调用
	 */
	@Override
	public void deleteListener(SceneListener listener) {
		if (!listeners.contains(listener)) {
			return;
		}
		listeners.remove(listener);
		listener.onDeleted(this);
	}

	/**
	 * @warning 在主处理线程中被调用
	 */
	@Override
	public void registerListener(SceneListener listener) {
		if (listeners.contains(listener)) {
			// 不可重入
			return;
		}
		listeners.add(listener);
		listener.onRegisted(this);
		Collections.sort(listeners, Listener.comparator);
	}

	/**
	 * 获取场景ID
	 *
	 * @return
	 */
	public int getId() {
		return this.sceneTemplate.getId();
	}
	
	/**
	 * 玩家进入场景
	 *
	 * @param player
	 */
	public boolean onPlayerEnter(Player player) {
		this.playerManager.add(player.getId());
		Human human = player.getHuman();
		
		Human humanCache = Globals.getHumanCacheService().getHuman(human.getUUID());
		//有缓存，且当前player身上的human不是缓存的human则替换
		if (humanCache != null && humanCache != human) {
			player.setHuman(humanCache);
			humanCache.setPlayer(player);
			humanCache.setScene(this);
			//记录日志
			Loggers.loginLogger.warn("#Scene#onPlayerEnter#119humanCache replace human!pid=" + player.getPassportId() + 
					";roleId=" + humanCache.getUUID() + ";rid=" + human.getUUID() + ";state=" + player.getState());
		}
		
		//玩家进出场景，缓存中的处理
		Globals.getHumanCacheService().onHumanEnterScene(human.getUUID());
		
		if (Loggers.msgLogger.isDebugEnabled()) {
			Loggers.msgLogger.debug("player[" + human.getUUID()
					+ "] player tempid [" + player.getId() + "] enter scene[" + this.getId() + "] sceneId=" + this.getTemplateId());
		}

		if (Loggers.humanLogger.isDebugEnabled()) {
			Loggers.msgLogger.debug("#Scene#onPlayerEnter#sceneId=" + this.getTemplateId() + ";humanId=" + human.getUUID());
		}
		// 修改玩家所在场景和区域 Id
		human.setSceneId(this.getTemplateId());
		// 保存玩家角色修改
		human.setModified();
		
		// 玩家进入该场景
//		playerManager.onPlayerEnterScene(human.getUUID());
		
		//发送进入场景后的相关信息
		GCEnterScene gcEnter = new GCEnterScene(getId(), getName());
		human.sendMessage(gcEnter);
		
		//玩家进入地图
		Globals.getMapService().onPlayerLogin(human);
		
//		// 发场景玩家列表消息
//		sendScenePlayerInfoListMsg(human);
//		// 发送场景演武离线列表
//		Globals.getPracticeService().sendOfflineUserListMsg(human, human.getSceneId());
		
		// 处理体力，扫荡扣体力，玩家体力恢复。在GCEnterScene之后处理，因为如果提前发的话前台处理不了。
		// 2014-01-06 bing.dong 移到SceneMessageHandler.handleEnterScene, 中处理登陆检查挂机体力是否够 
//		human.checkPowerRelated();

		// 监听器监听
		for (SceneListener listener : listeners) {
			listener.afterHumanEnter(this, human);
		}

		return true;
	}
	
	protected void sendScenePlayerInfoListMsg(Human human) {
		List<ScenePlayerInfoData> playerList = playerManager.getScenePlayerInfoDataList(human.getUUID());
		GCScenePlayerList gcScenePlayerList = new GCScenePlayerList(getId(), playerList.toArray(new ScenePlayerInfoData[0]));
		human.sendMessage(gcScenePlayerList);
	}
	
	/**
	 * 玩家离开场景，此方法在场景线程中执行
	 *
	 * @param player
	 */
	public void onPlayerLeave(Player player) {
		int playerId = player.getId();
		Human human = player.getHuman();
		if (human == null) {
			// 玩家信息还未加载
			return;
		}
		try {
			if (!playerManager.containPlayer(playerId)) {
				Loggers.mapLogger.warn("player[" + human.getUUID()
						+ "] not in scene[" + this.getId() + "]");
				return;
			}
			if (Loggers.msgLogger.isDebugEnabled()) {
				Loggers.msgLogger.debug("player[" + human.getUUID()
						+ "] leave scene[" + this.getId() + "]");
			}
			
			//XXX 离开场景存储player对象
			if(Globals.getConfig().isUpgradeDbStrategy()){
				player.updateData();
				long now = Globals.getTimeService().now();
				//XXX log采样
				if(Globals.getConfig().isCollectStrategy()){
					if(player.getCharId() % Globals.getConfig().getCollectSimpling() == 0){
						dbLogger.debug(String.format("UPDATE_DATA[pid=%s,charid=%s,time=%s,sceneid=%s] is successed onPlayerLeave with UpgradeDbStrategy", player.getPassportId() + "",player.getCharId() + "",now + "",this.getId()));
					}
				}else{
					dbLogger.debug(String.format("UPDATE_DATA[pid=%s,charid=%s,time=%s,sceneid=%s] is successed onPlayerLeave with UpgradeDbStrategy", player.getPassportId() + "",player.getCharId() + "",now + "",this.getId()));
				}
			}
			
			// 监听器监听,在玩家被置为离开之前
			if (PlayerState.logouting == human.getPlayer().getState()) {
				// 通知军团玩家退出游戏,在场景线程处理
//				human.getGuildManager().onPlayerExit();
				// 通知竞技场系统玩家退出游戏,在场景线程处理
//				human.getArenaManager().onPlayerExit();
				for (SceneListener listener : listeners) {
					listener.leaveOnLogoutSaving(this, human);
				}
			} else {
				for (SceneListener listener : listeners) {
					listener.beforeHumanLeave(this, human);
				}
			}

			// something to cancel
			
//			// 玩家离开该场景
//			playerManager.onPlayerLeaveScene(human.getUUID());
			
			//玩家离开地图
			Globals.getMapService().onPlayerLogout(human);

			//玩家进出场景，缓存中的处理
			Globals.getHumanCacheService().onHumanLeaveScene(human);
		} catch (Exception e) {
			Loggers.gameLogger
					.error("Error occurs when player leave scene", e);
		} finally {
		}
	}
	
	/**
	 * 玩家从地图中返回原场景
	 * @param player
	 */
	public void onPlayerReturn(Player player) {
//		Human human = player.getHuman();
//		
//		// 玩家进入该场景
//		playerManager.onPlayerEnterScene(human.getUUID());
//		
//		// 发场景玩家列表消息
//		sendScenePlayerInfoListMsg(human);
	}
	
	/**
	 * 玩家移动
	 * @param player
	 * @param position
	 */
	public void onPlayerMove(Player player, ScenePlayerPosition position) {
		if (position == null || position.getPoint() == null) {
			// 非法数据
			return;
		}
		// TODO 对targetPoint做临界值判断，如果越界，则直接返回
		if (!checkScenePoint(position.getPoint())) {
			return;
		}
		
		// 玩家不在线，或不在此场景，则不做处理
		if (player == null || player.getHuman() == null || player.getSceneId() != getId()) {
			return;
		}
//		// 设置玩家当前坐标
//		player.getHuman().setCurPoint(position.getPoint());
		// 场景玩家数据更新
		long uuid = player.getRoleUUID();
		playerManager.onPlayerMove(uuid, position);
	}
	
	/**
	 * 玩家的场景信息发送变化
	 * @param player
	 */
	public void onPlayerInfoChanged(Player player) {
		// 玩家不在线，或不在此场景，则不做处理
		if (player == null || player.getHuman() == null || player.getSceneId() != getId()) {
			return;
		}
		playerManager.onPlayerInfoChanged(player.getRoleUUID());
	}

	/**
	 * @param message
	 * @return
	 */
	public boolean putMessage(IMessage message) {
		msgQueue.put(message);
		if (log.isDebugEnabled()) {
			log.debug(this.getClass().getSimpleName() + "【Receive】" + message);
		}
		return true;
	}

	@Override
	public void tick() {
		playerManager.tick();
		// 处理场景消息
//		while (!msgQueue.isEmpty()) {
//			IMessage msg = msgQueue.get();
//			msg.execute();
//		}
		this.processMsg();
		this.heartBeat();
	}
	
	protected void processMsg(){
		while (!msgQueue.isEmpty()) {
			long begin = 0;
			if (log.isInfoEnabled()) {
				begin = System.nanoTime();
			}
			IMessage msg = msgQueue.get();
			try {
				if (log.isDebugEnabled()) {
					log.debug(this.getClass().getSimpleName() + "【execute】" + msg);
				}
				msg.execute();
			} catch (Exception e) {
				log.error(ErrorsUtil.error(CommonErrorLogInfo.MSG_PRO_ERR_DIS_SENDER_FAIL, "#CORE.Scene.process", null), e);
			} finally {
				if (log.isInfoEnabled()) {
					// 特例，统计时间跨度
					long time = (System.nanoTime() - begin) / (1000 * 1000);
					if (time > 1) {
						int type = msg.getType();
						log.warn("Scene Message process is too long:" + msg.getTypeName() + " Type:" + type + " Time:" + time + "ms");
					}
				}
			}
		}
	}

	@Override
	public void heartBeat() {
		playerManager.heartBeat();//存库操作,要在其他manager调用后做
		this.updateData();
		hbTaskExecutor.onHeartBeat();
	}


	@Override
	public void destroy() {
		msgQueue = null;
		playerManager = null;
	}


	public ScenePlayerManager getPlayerManager() {
		return playerManager;
	}

	/**
	 * 获取场景模版
	 *
	 * @return
	 */
	public SceneTemplate getSceneTemplate() {
		return this.sceneTemplate;
	}

	/**
	 * 获取模版 Id
	 *
	 * @return
	 */
	public int getTemplateId() {
		return this.getSceneTemplate().getId();
	}

	/**
	 * 获取场景类型 Id
	 *
	 * @return
	 */
	public int getTypeId() {
		return this.sceneTemplate.getDistTypeId();
	}

	/**
	 * 获取场景名称
	 *
	 * @return
	 */
	public String getName() {
		return this.sceneTemplate.getDistName();
	}

	/**
	 * 获取描述信息
	 *
	 * @return
	 */
	public String getDesc() {
		return this.sceneTemplate.getDesc();
	}

	/**
	 * 获取进入等级,
	 * 该值是世界系统与关卡系统的接口值
	 * <br>
	 * 玩家在通过某个关卡后, 会点亮世界地图中的城市图标.
	 * 为了降低世界系统与关卡系统的耦合度, 所以使用该值来标记玩家所能点亮的场景.
	 *
	 * @return
	 */
	public int getMoveLevel() {
		return this.sceneTemplate.getRequireLevel();
	}

	/**
	 * 获取场景数据更新器
	 *
	 * @return
	 */
	public SceneDataUpdater getDataUpdater() {
		return this.dataUpdater;
	}

	@Override
	public long getCharId() {
		throw new UnsupportedOperationException();
	}

	@Override
	public Long getDbId() {
		return this.UUID;
	}

	@Override
	public String getGUID() {
		return "scene#" + getDbId();
	}

	@Override
	public LifeCycle getLifeCycle() {
		return this.lifeCycle;
	}

	@Override
	public boolean isInDb() {
		return this.isInDb;
	}

	@Override
	public void setDbId(Long id) {
		this.UUID = id;
	}

	@Override
	public void setInDb(boolean inDb) {
		this.isInDb = inDb;
	}

	@Override
	public void setModified() {
		if (this.lifeCycle.isActive()) {
			this.getDataUpdater().addUpdate(lifeCycle);
		}
	}

	@Override
	public SceneEntity toEntity() {
		// 创建场景实体
		SceneEntity entity = new SceneEntity();

		// 设置数据库 Id
		entity.setId(this.getDbId());
		// 设置模版 Id
		entity.setTemplateId(this.getId());
		// 设置属性字符串
		entity.setProperties(this.toEntityProperties());

		return entity;
	}

	/**
	 * 获取实体属性字符串
	 *
	 * @return
	 */
	protected abstract String toEntityProperties();

	@Override
	public void fromEntity(SceneEntity entity) {
		if (entity == null) {
			return;
		}

		// 设置数据库 Id
		this.setDbId(entity.getId());

		String entityProps = entity.getProperties();

		if ((entityProps != null) &&
		   !(entityProps.equals(""))) {
			this.fromEntityProperties(entityProps);
		}
	}

	/**
	 * 从场景实体属性读入数据
	 *
	 * @param props
	 */
	protected abstract void fromEntityProperties(String props);

	/**
	 * 更新数据
	 */
	private void updateData() {
		try {
			this.dataUpdater.update();
		} catch (Exception e) {
			if (Loggers.updateLogger.isErrorEnabled()) {
				Loggers.updateLogger.error(ErrorsUtil.error(
						CommonErrorLogInfo.INVALID_STATE,
						"#GS.ServiceBuilder.buildGameMessageHandler", ""), e);
			}
		}
	}

	@Override
	public boolean equals(Object obj) {
		if (!(obj instanceof Scene)) {
			return false;
		}

		return ((Scene)obj).getTemplateId() == this.getTemplateId();
	}
	
	/**
	 * 检查玩家移动的坐标是否在边界值内
	 * @param targetPoint
	 * @return
	 */
	public boolean checkScenePoint(Point targetPoint) {
		boolean flag = true;
		//  TODO 查看x、y坐标是否在边界值范围内
		
		return flag;
	}
	
	/**
	 * 将所有玩家踢出当前场景，回到玩家最近一次的城市场景
	 * 一般在某场景中的活动结束时调用
	 */
	public void allPlayerLeaveToLastCityScene() {
		// 先加个try看一下报什么错误，避免影响活动在调用这句话后的处理
		try {
			List<Integer> playerIds = playerManager.getPlayerIds();
			final int fromSceneId = getId();
			for (Iterator<Integer> iterator = playerIds.iterator(); iterator.hasNext(); ) {
				Integer playerId = iterator.next();
				Player player = Globals.getOnlinePlayerService().getPlayerByTempId(playerId);
				
				// 如果玩家已不在在线列表中,或已经不属于当前场景，则跳过
				if (player == null || player.getHuman() == null || player.getSceneId() != getId()) {
					continue;
				}
				
				Human human = player.getHuman();
				// 成功进入场景后的回调
				PlayerEnterSceneCallback callBack = new PlayerEnterSceneCallback() {
					/**
					 * 主线程中调用
					 */
					@Override
					public void afterEnterScene(final Player player) {
						player.putMessage(new SysInternalMessage() {
							
							@Override
							public void execute() {
								player.sendMessage(new GCScenePlayerForceToCityScene(fromSceneId));
							}
						});
						
						// 记录日志
						Loggers.gameLogger.info("#Scene#putAllPlayerToLastCityScene#afterEnterScene.player passportId="+ 
								player.getPassportId() + " player state=" + player.getState().name());
					}
				};
				Globals.getSceneService().changeScene(human, human.getLastCitySceneId(), callBack, "scene.putAllPlayerToLastCityScene,sceneId=" + getId());
			}
		} catch (Exception e) {
			e.printStackTrace();
			// 记录日志
			Loggers.gameLogger.error("#Scene#putAllPlayerToLastCityScene#Exception!", e);
		}
	}
	
	/**
	 * 给场景中的所有玩家发消息
	 * @param msg
	 */
	public void sendScenePlayerMsg(IMessage msg) {
		List<Integer> playerIds = playerManager.getPlayerIds();
		for (Iterator<Integer> iterator = playerIds.iterator(); iterator.hasNext(); ) {
			Integer playerId = iterator.next();
			Player player = Globals.getOnlinePlayerService().getPlayerByTempId(playerId);
			
			// 如果玩家已不在在线列表中,或已经不属于当前场景，则跳过
			if (player == null || player.getHuman() == null || player.getSceneId() != getId()) {
				continue;
			}
			
			player.sendMessage(msg);
		}
	}
	
	public abstract AbstractSceneDataUpdater getSceneDataUpdater();
}
