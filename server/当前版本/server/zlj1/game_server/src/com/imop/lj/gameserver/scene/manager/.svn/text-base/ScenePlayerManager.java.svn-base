package com.imop.lj.gameserver.scene.manager;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.imop.lj.common.HeartBeatAble;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.ScenePlayerInfoData;
import com.imop.lj.common.model.ScenePlayerPosition;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.scene.Scene;
import com.imop.lj.gameserver.scene.ScenePlayerRefresh;
import com.imop.lj.gameserver.scene.ScenePlayerShowChecker;

/**
 * 管理场景内玩家列表
 *
 */
public class ScenePlayerManager implements HeartBeatAble {
	private static final int INIT_GOURP_KEY = 1;
	
	/** 当前场景对象 **/
	private Scene scene;
	/** 所有在线玩家的管理器,根据此对象取得玩家的实例 **/
	private OnlinePlayerService onlinePlayerManager;
	/** 玩家ID的列表.此处不引用玩家的实例,获取玩家实例需调用onlinePlayerManager **/
	private List<Integer> playerIds;
	/** 镜像人数,仅用于非实时性的一些需求,且可能在多线程中调用 */
	private volatile int mirrorPlayerNum;
	
	private int maxGroupKey;
	private int normalMaxGroupKey;
	/** Map<分组Id，对应的分组玩家管理器> */
	private Map<Integer, SceneGroupPlayerManager> groupPlayerManagerMap;
	/** Map<玩家Id，玩家所在分组Id> */
	private Map<Long, Integer> playerGroupIdMap;

	public ScenePlayerManager(Scene scene,
			OnlinePlayerService onlinePlayerManager, int maxPlayerCount) {
		this.scene = scene;
		this.onlinePlayerManager = onlinePlayerManager;
		playerIds = new ArrayList<Integer>(maxPlayerCount);
		
		groupPlayerManagerMap = new HashMap<Integer, SceneGroupPlayerManager>();
		playerGroupIdMap = new HashMap<Long, Integer>();
		// 初始化分组管理器
		initGroupManager(maxPlayerCount);
	}
	
	private void initGroupManager(int maxPlayerCount) {
		// 正常情况的组数
		normalMaxGroupKey = maxPlayerCount / getScenePlayerMaxNum() + 1;
		// 冗余10个分组
		maxGroupKey = normalMaxGroupKey + 10;
		// 直接在初始化的时候构建好所有的分组管理器
		for (int key = INIT_GOURP_KEY; key <= maxGroupKey; key++) {
			groupPlayerManagerMap.put(key, new SceneGroupPlayerManager(this, key));
		}
	}
	
	public int getMaxGroupKey() {
		return maxGroupKey;
	}

	public void add(Integer playerId) {
		playerIds.add(playerId);
	}

	/**
	 * 当前场景中是否包含某个玩家
	 *
	 * @param playerId
	 * @return
	 */
	public boolean containPlayer(Integer playerId) {
		return this.playerIds.contains(playerId);
	}

	/**
	 * 处理场景内玩家的输入输出消息
	 */
	public void tick() {
		// 可能在迭代中删除元素,故不能用for-each形式
		for (Iterator<Integer> iterator = playerIds.iterator(); iterator
				.hasNext();) {
			Integer playerId = iterator.next();
			Player player = onlinePlayerManager.getPlayerByTempId(playerId);
			// 如果玩家已不在在线列表中,或已经不属于当前场景，则从ID列表中删除
			if (player == null  || player.getSceneId() != scene.getId()) {
				iterator.remove();
				continue;
			}
			player.processMessage();
		}
	}

	@Override
	public void heartBeat() {
		// 可能在迭代中删除元素,故不能用for-each形式
		for (Iterator<Integer> iterator = playerIds.iterator(); iterator
				.hasNext();) {
			Integer playerId = iterator.next();
			Player player = onlinePlayerManager.getPlayerByTempId(playerId);
			// 如果玩家已不在在线列表中,或已经不属于当前场景，则从ID列表中删除
			if (player == null || player.getSceneId() != scene.getId()) {
				iterator.remove();
				continue;
			}
			player.heartBeat();
		}
		mirrorPlayerNum = playerIds.size();
	}

	public List<Integer> getPlayerIds() {
		return this.playerIds;
	}
	
	/**
	 * 获取场景玩家数量
	 * @return
	 */
	public int getPlayerNum() {
		return playerIds.size();
	}

	/**
	 * 当前场景一个非实时的人数
	 * @see #mirrorPlayerNum
	 *
	 * @return
	 */
	public int getMirrorPlayerNum() {
		return mirrorPlayerNum;
	}
	
	public Scene getScene() {
		return scene;
	}
	
	public SceneGroupPlayerManager getGroupPlayerManager(int key) {
		return groupPlayerManagerMap.get(key);
	}
	
	public SceneGroupPlayerManager getSceneGroupPlayerManager(int key) {
		return groupPlayerManagerMap.get(key);
	}
	
	/**
	 * 找有空位的分组管理器，优先从前面的分组中找
	 * @return 如果所有的分组都
	 */
	private SceneGroupPlayerManager getCheckedGroupManager() {
		SceneGroupPlayerManager curGroupManager = null;
		// 从第一个分组开始找有空位的分组管理器
		for (int key = INIT_GOURP_KEY; key <= maxGroupKey; key++) {
			if (!isGroupReachMaxNum(getSceneGroupPlayerManager(key))) {
				curGroupManager = getSceneGroupPlayerManager(key);
				break;
			}
		}
		if (curGroupManager == null) {
			// 记录错误日志，找不到空的坑位，正常情况不应该走到这里
			Loggers.sceneLogger.error("#ScenePlayerManager#getCheckedGroupManager#ERROR!All group is full!");
			return null;
		}
		if (curGroupManager.getGroupId() > normalMaxGroupKey) {
			// 记录警告日志，分组Id已经超过正常值
			Loggers.sceneLogger.warn("#ScenePlayerManager#getCheckedGroupManager#Warning!curGroupId is bigger than normalMaxGroupKey!curGroupId=" + 
					curGroupManager.getGroupId() + ";normalMaxGroupKey=" + normalMaxGroupKey + ";maxGroupKey=" + maxGroupKey);
		}
		return curGroupManager;
	}
	
	/**
	 * 分组中的人数是否已满
	 * @param groupManager
	 * @return
	 */
	private boolean isGroupReachMaxNum(SceneGroupPlayerManager groupManager) {
		if (null == groupManager) {
			return true;
		}
		int groupPlayerNum = groupManager.getGroupPlayerNum();
		int groupMaxNum = getScenePlayerMaxNum();
		if (groupPlayerNum >= groupMaxNum) {
			return true;
		}
		return false;
	}
	
	public int getScenePlayerMaxNum() {
		return ScenePlayerRefresh.SCENE_PLAYER_LIST_MAX_NUM;
	}
	
	public void onPlayerEnterScene(long uuid) {
		// 获取当前分组，如果分组人数超过指定人数，会新建分组
		SceneGroupPlayerManager curGroupManager = getCheckedGroupManager();
		if (null == curGroupManager) {
			// 记录错误日志，找不到空的分组，该玩家没法处理
			Loggers.sceneLogger.error("#ScenePlayerManager#onPlayerEnterScene#ERROR!cant find empty group,so player cant in!HumanId=" + uuid);
			return;
		}
		int groupId = curGroupManager.getGroupId();
		// 获取玩家当前分组
		Integer playerGroupId = playerGroupIdMap.get(uuid);
		
		// 如果玩家当前在另一个分组中，则先将玩家从旧分组中移除
		if (playerGroupId != null && 
				playerGroupId != groupId && 
				getSceneGroupPlayerManager(playerGroupId) != null) {
			// 移除玩家
			getSceneGroupPlayerManager(playerGroupId).onPlayerLeaveScene(uuid);
			// 记录错误日志，不应该走到这里
			Loggers.humanLogger.warn("#ScenePlayerManager#onPlayerEnterScene#player is in another group!HumanId=" 
					+ uuid + ";oldGroupId=" + playerGroupId + ";newGroupId=" + groupId);
		}
		
		// 将玩家放入新的分组管理器中，这里不考虑玩家已经在该分组中的情况，因为玩家可能出去又进来了，这时候需要通知场景中的其他玩家新增了一个人
		playerGroupIdMap.put(uuid, groupId);
		curGroupManager.onPlayerEnterScene(uuid);
	}
	
	public void onPlayerLeaveScene(long uuid) {
		// 获取玩家当前的分组
		Integer playerGroupId = playerGroupIdMap.get(uuid);
		if (playerGroupId != null && 
				getSceneGroupPlayerManager(playerGroupId) != null) {
			// 移除玩家
			getSceneGroupPlayerManager(playerGroupId).onPlayerLeaveScene(uuid);
			// 玩家所在分组map中移除
			playerGroupIdMap.remove(uuid);
		} else {
			// 记录错误日志，找不到玩家的分组，或对应的分组管理器为null
			Loggers.sceneLogger.error("#ScenePlayerManager#onPlayerLeaveScene#ERROR!Cant find player!playerGroupId is null or getSceneGroupPlayerManager is null!HumanId=" + 
					uuid + ";playerGroupId=" + playerGroupId);
		}
	}
	
	public void onPlayerMove(long uuid, ScenePlayerPosition targetPosition) {
		// 获取玩家所在分组
		Integer playerGroupId = playerGroupIdMap.get(uuid);
		if (playerGroupId != null && getSceneGroupPlayerManager(playerGroupId) != null) {
			// 玩家是否在线
			Player player = Globals.getOnlinePlayerService().getPlayer(uuid);
			// 玩家是否在此场景中
			if (player != null && player.getHuman() != null && player.getSceneId() == scene.getId()) {
				// 玩家位置移动
				getSceneGroupPlayerManager(playerGroupId).onPlayerMove(uuid, targetPosition);
			}
		} else {
			// 记录错误日志，找不到玩家的分组，或对应的分组管理器为null
			Loggers.sceneLogger.error("#ScenePlayerManager#onPlayerMove#ERROR!Cant find player!playerGroupId is null or getSceneGroupPlayerManager is null!HumanId=" + 
					uuid + ";playerGroupId=" + playerGroupId);
		}
	}
	
	public void onPlayerInfoChanged(long uuid) {
		// 获取玩家所在分组
		Integer playerGroupId = playerGroupIdMap.get(uuid);
		if (playerGroupId != null && getSceneGroupPlayerManager(playerGroupId) != null) {
			// 玩家是否在线
			Player player = Globals.getOnlinePlayerService().getPlayer(uuid);
			// 玩家是否在此场景中
			if (player != null && player.getHuman() != null && player.getSceneId() == scene.getId()) {
				// 玩家信息发送变化
				getSceneGroupPlayerManager(playerGroupId).onPlayerInfoChanged(uuid);
			}
		} else {
			// 记录错误日志，找不到玩家的分组，或对应的分组管理器为null
			Loggers.sceneLogger.error("#ScenePlayerManager#onPlayerInfoChanged#ERROR!Cant find player!playerGroupId is null or getSceneGroupPlayerManager is null!HumanId=" + 
					uuid + ";playerGroupId=" + playerGroupId);
		}
	}
	
	/**
	 * 获取玩家所在分组，如果获取不到，返回0
	 * @param uuid
	 * @return
	 */
	public int getPlayerGroupId(long uuid) {
		Integer playerGroupId = playerGroupIdMap.get(uuid);
		if (null == playerGroupId) {
			return 0;
		}
		return playerGroupId;
	}
	
	public Set<Long> getPlayerSet(){
		return this.playerGroupIdMap.keySet();
	}
	
	/**
	 * 获取场景玩家列表，发消息用
	 * @return
	 */
	public List<ScenePlayerInfoData> getScenePlayerInfoDataList(long selfUUID) {
		List<ScenePlayerInfoData> playerStrList = new ArrayList<ScenePlayerInfoData>();
		int count = 0;
		Integer playerGroupId = playerGroupIdMap.get(selfUUID);
		if (playerGroupId != null && getSceneGroupPlayerManager(playerGroupId) != null) {
			// 获取玩家当前所在分组对应的管理器，给玩家发该分组中的其他玩家信息列表 
			SceneGroupPlayerManager playerGroupManager = getSceneGroupPlayerManager(playerGroupId);
			for (Iterator<Long> iterator = playerGroupManager.getGroupPlayerIdSet().iterator(); iterator.hasNext(); ) {
				if (count >= getScenePlayerMaxNum()) {
					// 最多给前台发100人的信息
					break;
				}
				Long playerId = iterator.next();
				Player player = onlinePlayerManager.getPlayer(playerId);
				if (player != null && player.getHuman() != null && player.getSceneId() == scene.getId()) {
					if (ScenePlayerShowChecker.checkUserNeedShow(scene, selfUUID, player.getRoleUUID())) {
						String playerInfoStr = player.getHuman().buildScenePlayerJsonStr();
						if (playerInfoStr != null && !playerInfoStr.equals("")) {
							playerStrList.add(new ScenePlayerInfoData(player.getRoleUUID(), playerInfoStr));
							count++;
						}
					}
				}
			}
		}
		return playerStrList;
	}

}
