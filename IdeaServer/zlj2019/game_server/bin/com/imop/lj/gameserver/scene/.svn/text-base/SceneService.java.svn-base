package com.imop.lj.gameserver.scene;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import java.util.ConcurrentModificationException;
import java.util.List;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.annotation.SyncIoOper;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.core.util.LogUtils;
import com.imop.lj.core.uuid.UUIDService;
import com.imop.lj.core.uuid.UUIDType;
import com.imop.lj.db.dao.SceneDao;
import com.imop.lj.db.model.SceneEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.GameDaoService;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatThread;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerState;
import com.imop.lj.gameserver.player.msg.SysEnterScene;
import com.imop.lj.gameserver.player.msg.SysLeaveScene;
import com.imop.lj.gameserver.scene.handler.SceneHandlerFactory;
import com.imop.lj.gameserver.scene.template.SceneTemplate;

/**
 * 场景服务
 *
 */
public class SceneService implements InitializeRequired {

	/** 非法的场景Id */
	public static final int INVALID_SCENEID = -1;
	
	/** 军团战场景id */
	public static final int CORPS_WAR_SCENE_ID = 30001;
	/** 世界boss战场Id */
	public static final int BOSSWAR_SHU_SCENE_ID = 60001;
	public static final int BOSSWAR_WEI_SCENE_ID = 70001;
	public static final int BOSSWAR_WU_SCENE_ID = 80001;
	/** 军团boss战场景Id */
	public static final int BOSSWAR_CORPS_SCENE_ID = 90001;
	/** 怪物攻城场景Id */
	public static final int MONSTER_WAR_SCENE_ID = 100001;

	/** 场景心跳 */
	private HeartbeatThread sceneTaskScheduler;

	private Map<Integer, Scene> sceneMap;
	private List<Scene> sceneList;
	/** 城市 Id 列表 */
	private List<Integer> cityTemplateIdList;
	private Map<Integer, SceneRunner> sceneRunners;
	private OnlinePlayerService onlinePlayerService;

	/** UUID 服务 */
	private UUIDService uuidService;
	/** 游戏数据访问层对象 */
	private GameDaoService daoService;

	/** 公共场景 */
	private CommonScene commonScene;
//	/**军团场景*/
//	private CorpsScene corpsScene;
//	
//	/** 军团战场景 */
//	private CorpsWarScene corpsWarScene;
//	
//	/** 竞技场场景 */
//	private ArenaScene arenaScene;
//	
//	/** 蜀国Boss战场景 */
//	private BossWarShuScene bossWarShuScene;
//	/** 魏国Boss战场景 */
//	private BossWarWeiScene bossWarWeiScene;
//	/** 吴国Boss战场景 */
//	private BossWarWuScene bossWarWuScene;
//	
//	/** 军团Boss战场景 */
//	private BossWarCorpsScene bossWarCorpsScene;
//	
//	/** 怪物攻城场景 */
//	private MonsterWarScene monsterWarScene;


	public SceneService(OnlinePlayerService onlinePlayerService, UUIDService uuidServ, GameDaoService daoService) {
		sceneMap = new ConcurrentHashMap<Integer, Scene>();
		sceneList = new ArrayList<Scene>();
		cityTemplateIdList = new ArrayList<Integer>();
		sceneRunners = new ConcurrentHashMap<Integer, SceneRunner>();
		this.onlinePlayerService = onlinePlayerService;
		this.uuidService = uuidServ;
		this.daoService = daoService;
	}

	@Override
	public void init() {
		// 获取场景模版字典
		Map<Integer, SceneTemplate> sceneTmplMap = Globals.getTemplateCacheService().getAll(SceneTemplate.class);

		// 迁徙等级列表
		List<Integer> moveLevelList = new ArrayList<Integer>();

		for (Integer id : sceneTmplMap.keySet()) {
			// 获取场景模版
			SceneTemplate sceneTmpl = sceneTmplMap.get(id);
			// 初始化场景
			this.initScene(sceneTmpl);
		}

		Collections.sort(this.sceneList, new Comparator<Scene>() {
			@Override
			public int compare(Scene s0, Scene s1) {
				if (s0.getTypeId() != s1.getTypeId()) {
					// 以城市类型排序
					return s1.getTypeId() - s1.getTypeId();
				} else {
					// 以模版 Id 排序
					return s0.getTemplateId() - s1.getTemplateId();
				}
			}
		});

		// 迁徙等级排序
		Collections.sort(moveLevelList);

		if (this.commonScene == null) {
			throw new IllegalArgumentException("the commonScene is not exist");
		}
		
//		if(this.corpsScene == null){
//			throw new IllegalArgumentException("the corpsScene is not exist");
//		}
//		
//		if (this.corpsWarScene == null) {
//			throw new IllegalArgumentException("the corpsWarScene is not exist");
//		}
//
//		if (this.arenaScene == null) {
//			throw new IllegalArgumentException("the arenaScene is not exist");
//		}
//		
//		if (this.bossWarShuScene == null) {
//			throw new IllegalArgumentException("the bossWarShuScene is not exist");
//		}
//		if (this.bossWarWeiScene == null) {
//			throw new IllegalArgumentException("the bossWarWeiScene is not exist");
//		}
//		if (this.bossWarWuScene == null) {
//			throw new IllegalArgumentException("the bossWarWuScene is not exist");
//		}
//		if (this.bossWarCorpsScene == null) {
//			throw new IllegalArgumentException("the bossWarCorpsScene is not exist");
//		}
//		if (this.monsterWarScene == null) {
//			throw new IllegalArgumentException("the monsterWarScene is not exist");
//		}
	}

	/**
	 * 根据模版初始化场景
	 *
	 * @param template
	 * @param listeners
	 *
	 */
	@SyncIoOper
	private void initScene(SceneTemplate template) {
		if (template == null) {
			return;
		}

		SceneDao sceneDao = this.daoService.getSceneDao();
		int sceneId = template.getId();

		// 创建场景对象
		Scene sceneObj = SceneFactory.createScene(template, onlinePlayerService);

		// 获取场景实体
		SceneEntity entity = sceneDao.getSceneByTemplateId(sceneId);

		if (entity == null) {
			entity = sceneObj.toEntity();
			entity.setId(this.uuidService.getNextUUID(UUIDType.SCENE));

			// 将场景实体保存到数据库
			sceneDao.save(entity);
		}

		// 反序列化 & 初始化场景
		sceneObj.fromEntity(entity);
		sceneObj.init();

		this.addScene(sceneObj);
	}

	/**
	 * 获取指定场景对象
	 *
	 * @param sceneId
	 *            场景ID
	 * @return 如果不存在该ID的场景,则返回null
	 * @exception ConcurrentModificationException
	 *                如果不是该场景的线程调用该方法
	 */
	public Scene getScene(Integer sceneId) {
		return sceneMap.get(sceneId);
	}

	/**
	 * @warning 如果有地方同时使用了scenes和sceneRunners，需要先获得锁， 再进行操作，因为存在只更新了scenes，而没更新sceneRunners的糟糕情况， 需要保证它们更新的原子性。目前绝大多数对scenes和sceneRunners的引用
	 *          都没有考虑该问题,这是因为他们没有同时使用这两个集合。
	 *
	 * @param scene
	 */
	private void addScene(Scene scene) {
		synchronized (sceneMap) {
			sceneMap.put(scene.getId(), scene);
			sceneRunners.put(scene.getId(), new SceneRunner(scene));

			// 获取场景模版 Id
			int tplId = scene.getTemplateId();

			if ((scene.getTypeId() == SceneTypeEnum.CITY.getIndex()) && !(this.cityTemplateIdList.contains(tplId))) {
				// 添加城市模版 Id
				this.cityTemplateIdList.add(tplId);
			}
			
			if (scene.getTypeId() == SceneTypeEnum.COMMON.getIndex()) {
				this.commonScene = (CommonScene) scene;
			}
			
//			if(scene.getTypeId() == SceneTypeEnum.CORPS.getIndex()){
//				this.corpsScene = (CorpsScene)scene;
//			}
//			if (scene.getTypeId() == SceneTypeEnum.CORPS_WAR.getIndex()) {
//				this.corpsWarScene = (CorpsWarScene) scene;
//			}
//			if (scene.getTypeId() == SceneTypeEnum.ARENA.getIndex()) {
//				this.arenaScene = (ArenaScene) scene;
//			}
//			
//			if (scene.getTypeId() == SceneTypeEnum.BOSSWAR_SHU.getIndex()) {
//				this.bossWarShuScene = (BossWarShuScene) scene;
//			}
//			if (scene.getTypeId() == SceneTypeEnum.BOSSWAR_WEI.getIndex()) {
//				this.bossWarWeiScene = (BossWarWeiScene) scene;
//			}
//			if (scene.getTypeId() == SceneTypeEnum.BOSSWAR_WU.getIndex()) {
//				this.bossWarWuScene = (BossWarWuScene) scene;
//			}
//			if (scene.getTypeId() == SceneTypeEnum.BOSSWAR_CORPS.getIndex()) {
//				this.bossWarCorpsScene = (BossWarCorpsScene) scene;
//			}
//			if (scene.getTypeId() == SceneTypeEnum.MONSTER_WAR.getIndex()) {
//				this.monsterWarScene = (MonsterWarScene) scene;
//			}
			
			this.sceneList.add(scene);
		}
	}

	/**
	 * @warning 与{@link SceneService#addScene(Scene)}类似，需要确保 在同时修改scenes和sceneRunners时加锁。
	 *
	 * @param sceneId
	 */
	public void removeScene(Integer sceneId) {
		synchronized (sceneMap) {
			Scene removedScene = sceneMap.remove(sceneId);
			sceneRunners.remove(sceneId);
			sceneList.remove(removedScene);
		}
	}

	/**
	 * @warning 非线程安全
	 * @return
	 */
	public List<Scene> getAllScenes() {
		return this.sceneList;
	}

	/**
	 * 玩家进入场景
	 *
	 * @param player
	 * @return
	 */
	public boolean onPlayerEnterScene(final Player player, PlayerEnterSceneCallback callback) {
		int sceneId = -1;
		sceneId = player.getTargetSceneId();
		if (sceneId == -1) {
			Loggers.mapLogger.error(LogUtils.buildLogInfoStr(player.getRoleUUID() + "", "目标场景id或坐标不正确"));
			return false;
		}
		Scene scene = sceneMap.get(sceneId);
		if (scene == null) {
			Loggers.mapLogger.error(LogUtils.buildLogInfoStr(player.getRoleUUID() + "", "场景id：" + sceneId + "不存在"));
			return false;
		}

		// 标记此玩家已进入场景，在场景线程将玩家加入场景中之前如果收到
		// 玩家下线的消息，则向场景发送移除此玩家的消息
		player.getHuman().setScene(scene);
		SysEnterScene esm = new SysEnterScene(player.getId(), sceneId, callback);
		scene.putMessage(esm);
		return true;
	}

	/**
	 * 玩家离开场景
	 *
	 * @param player
	 * @param afterPlayerLeave
	 */
	public boolean onPlayerLeaveScene(Player player, PlayerLeaveSceneCallback afterPlayerLeave) {
		Scene scene = sceneMap.get(player.getSceneId());
		if (scene == null) {
			Loggers.mapLogger.warn(LogUtils.buildLogInfoStr(player.getRoleUUID() + "", "sceneId:" + player.getSceneId() + " not exist"));
			return false;
		}
		player.setState(PlayerState.leaving);
		SysLeaveScene esm = new SysLeaveScene(player.getId(), player.getSceneId(), afterPlayerLeave);
		scene.putMessage(esm);
		return true;
	}

	/**
	 * 线程安全的
	 *
	 * @return
	 */
	public List<SceneRunner> getAllSceneRunners() {
		List<SceneRunner> runnerList = new ArrayList<SceneRunner>();
		for (SceneRunner runner : sceneRunners.values()) {
			runnerList.add(runner);
		}
		return runnerList;
	}

	/**
	 * 移除场景中所有的玩家，在服务器断线或停机时调用，此处在主线程中直接操作场景
	 */
	public void removeAllPlayers() {
		for (Scene scene : sceneMap.values()) {
			List<Integer> playerIds = scene.getPlayerManager().getPlayerIds();
			for (Integer playerId : playerIds) {
				SceneHandlerFactory.getHandler().handleLeaveScene(playerId, scene.getId());
			}
		}
	}

	public void start() {
		Loggers.gameLogger.info("begin start heartBeatThread");
		sceneTaskScheduler = new HeartbeatThread();
		sceneTaskScheduler.start();
		Loggers.gameLogger.info("end start heartBeatThread");
	}

	public void stop() {
		Loggers.gameLogger.info("begin stop heartBeatThread");
		sceneTaskScheduler.shutdown();
		Loggers.gameLogger.info("end stop heartBeatThread");

	}

	/**
	 * 获取第一次登陆时的城市 Id
	 *
	 * @param human
	 * @return
	 *
	 */
	public int getFirstCityId(Human human) {
		// 第一次登陆的城市
		Scene firstCity = null;

		for (int cityId : this.cityTemplateIdList) {
			// 获取城市场景
			Scene cityScene = this.getScene(cityId);

			if (cityScene == null) {
				continue;
			}

			if ((cityScene.getMoveLevel() <= 0)) {
				// 如果城市可迁徙等级小于 0,
				// 则说明该城市为新手区
				firstCity = cityScene;
			}
		}

		if (firstCity == null) {
			return 0;
		} else {
			return firstCity.getTemplateId();
		}
	}
	
	/**
	 * 是否城市Id
	 * @param sceneId
	 * @return
	 */
	public boolean isCityId(int sceneId) {
		if (cityTemplateIdList != null && cityTemplateIdList.contains(sceneId)) {
			return true;
		}
		return false;
	}
	
	public boolean canEnter(){
		return false;
	}
	
	/**
	 * 玩家从一个场景，进入另一个场景
	 * @param human
	 * @param targetSceneId 目标场景Id
	 * @param callBack 玩家成功进入场景后的回调，可为null
	 * @param source 来源，记录日志用
	 */
	public boolean changeScene(Human human, final int targetSceneId, final PlayerEnterSceneCallback callBack, final String source) {
		if (human == null || human.getPlayer() == null || targetSceneId <= 0) {
			// 记录错误日志
			Loggers.gameLogger.error("#SceneService#changeScene#human or player is null or targetSceneId<=0!source=" + source);
			return false;
		}
		Scene targetScene = Globals.getSceneService().getScene(targetSceneId);
		if (targetScene == null) {
			// 记录错误日志
			Loggers.gameLogger.error("#SceneService#changeScene#targetScener is null!targetSceneId=" + 
					targetSceneId + ";source=" + source);
			return false;
		}
		
		final Player player = human.getPlayer();
		int humanSceneId = human.getSceneId();
		
		if (humanSceneId == targetSceneId) {
			// 更换的场景是原场景，则不变
			return false;
		}
		
		if(isFull(targetSceneId)){
			// 场景内人数达到上限
			human.sendErrorMessage(LangConstants.SCENE_USER_REACH_UPPER);
			return false;
		}
		
		// 玩家离开原场景，往主线程put消息
		final IMessage leaveSceneMsg = new SysInternalMessage() {
			@Override
			public void execute() {
				// XXX 新增entering状态判断，如果当前玩家时entering则表示玩家正在进入某场景，所以直接返回
				if (player.getState() == PlayerState.leaving || player.getState() == PlayerState.entering) {
					// 记录日志
					Loggers.gameLogger.warn("#SceneService#changeScene#player state is leaving,return!" +
							" player passportId=" + player.getPassportId() + " player state=" + player.getState().name() + "source=" + source);
					return;
				}
				// 记录日志
				Loggers.gameLogger.info("#SceneService#changeScene#1 Player leave scene internal message." +
						" player passportId=" + player.getPassportId() + " player state=" + player.getState().name() + "source=" + source);
				Globals.getSceneService().onPlayerLeaveScene(player, new PlayerLeaveSceneCallback() {
					/**
					 * 主线程中调用
					 */
					@Override
					public void afterLeaveScene(final Player player) {
						// 记录日志
						Loggers.gameLogger.info("#SceneService#changeScene#2 Player leave scene callback," +
						" player passportId=" + player.getPassportId() + " player state=" + player.getState().name() + "source=" + source);
						
						if (player.setState(PlayerState.incoming) && player.setState(PlayerState.entering)) {
							// 记录日志
							Loggers.gameLogger.info("#SceneService#changeScene#3 call handleEnterScene.player passportId="+ 
									player.getPassportId() + " player state=" + player.getState().name() + "source=" + source);
							// 发送系统消息令玩家进入新的场景
							player.setTargetSceneId(targetSceneId);
							Globals.getSceneService().onPlayerEnterScene(player, callBack);
							//记录日志
							Loggers.gameLogger.info("#SceneService#changeScene#4 call handleEnterScene.player passportId="+ 
									player.getPassportId() + " player state=" + player.getState().name() + "source=" + source);
						} else {
							//记录日志
							Loggers.gameLogger.error("#SceneService#changeScene#7 player.setState return false!player passportId="+ 
									player.getPassportId() + " player state=" + player.getState().name() + "source=" + source);
						}
						
					}
				});
				// 记录日志
				Loggers.gameLogger.info("#SceneService#changeScene#6 Player leave scene,call onPlayerLeaveScene end." +
						" player passportId=" + player.getPassportId() + " player state=" + player.getState().name() + "source=" + source);
			}
		};
		// 放入主线程处理
		Globals.getMessageProcessor().put(leaveSceneMsg);
		
		return true;
	}

	/**
	 * 场景内人数已满
	 * 
	 * @param sceneId
	 * @return
	 */
	public boolean isFull(int sceneId){
		return false;
//		if(sceneId == Globals.getSceneService().getMonsterWarScene().getId()){
//			// 南蛮入侵人数控制
//			return Globals.getSceneService().getMonsterWarScene().getPlayerManager().getPlayerNum() >= Globals.getConfig().getMaxMonsterWarUsersNum();
//		}else if(sceneId == Globals.getSceneService().getBossWarShuScene().getId()){
//			// Boss战人数控制
//			return Globals.getSceneService().getBossWarShuScene().getPlayerManager().getPlayerNum() >= Globals.getConfig().getMaxBossWarUsersNum();
//		}else if(sceneId == Globals.getSceneService().getBossWarWuScene().getId()){
//			// Boss战人数控制
//			return Globals.getSceneService().getBossWarWuScene().getPlayerManager().getPlayerNum() >= Globals.getConfig().getMaxBossWarUsersNum();
//		}else if(sceneId == Globals.getSceneService().getBossWarWeiScene().getId()){
//			// Boss战人数控制
//			return Globals.getSceneService().getBossWarWeiScene().getPlayerManager().getPlayerNum() >= Globals.getConfig().getMaxBossWarUsersNum();
//		}else{
//			return false;
//		}
	}
	/**
	 * 获取公共场景
	 * @return
	 */
	public CommonScene getCommonScene() {
		return commonScene;
	}
	/**
	 * 演武--取主城
	 * @param cityId
	 * @return
	 */
	public Scene getSceneById(int cityId) {
		if(cityTemplateIdList.contains(cityId)) {
			return this.getScene(cityId);
		}
		return null;
	}
	
	
//	/**
//	 * 获取军团场景
//	 * 
//	 * @return
//	 */
//	public CorpsScene getCorpsScene(){
//		return corpsScene;
//	}
//	
//	/**
//	 * 获取军团战场景
//	 * @return
//	 */
//	public CorpsWarScene getCorpsWarScene() {
//		return corpsWarScene;
//	}
//
//	/**
//	 * 获取竞技场场景
//	 * @return
//	 */
//	public ArenaScene getArenaScene() {
//		return arenaScene;
//	}
//
//	/**
//	 * 获取蜀国Boss战场景
//	 * @return
//	 */
//	public BossWarShuScene getBossWarShuScene() {
//		return bossWarShuScene;
//	}
//	
//	/**
//	 * 获取魏国Boss战场景
//	 * @return
//	 */
//	public BossWarWeiScene getBossWarWeiScene() {
//		return bossWarWeiScene;
//	}
//	
//	/**
//	 * 获取吴国Boss战场景
//	 * @return
//	 */
//	public BossWarWuScene getBossWarWuScene() {
//		return bossWarWuScene;
//	}
//	
//	/**
//	 * 根据国家获取对应的场景
//	 * @param country
//	 * @return
//	 */
//	public BossWarWorldScene getBossWarSceneByCountry(Country country) {
//		BossWarWorldScene retScene = null;
//		switch (country) {
//		case SHU:
//			retScene = getBossWarShuScene();
//			break;
//		case WEI:
//			retScene = getBossWarWeiScene();
//			break;
//		case WU:
//			retScene = getBossWarWuScene();
//			break;
//
//		default:
//			break;
//		}
//		return retScene;
//	}
//	
//	/**
//	 * 获取怪物攻城场景
//	 * @return
//	 */
//	public MonsterWarScene getMonsterWarScene() {
//		return monsterWarScene;
//	}

}
