package com.imop.lj.gameserver.scene;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.common.model.ScenePlayerInfoData;
import com.imop.lj.common.model.ScenePlayerMoveInfo;
import com.imop.lj.common.model.ScenePlayerPosition;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.scene.manager.SceneGroupPlayerManager;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerAddedList;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerChangedList;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerMovedList;
import com.imop.lj.gameserver.scene.msg.GCScenePlayerRemoveList;

/**
 * 场景玩家更新器
 * @author yu.zhao
 *
 */
public class ScenePlayerRefresh implements HeartbeatTask {
	
	/** 给玩家发送列表最大值 */
	public static int SCENE_PLAYER_LIST_MAX_NUM = 100;
	
	/** 场景玩家更新频率 */
	private long refreshInterval = 3 * TimeUtils.SECOND;
	
	private boolean isCanceled;
	
	private Scene scene;
	
	private int curGroupId;
	
	public ScenePlayerRefresh(Scene scene) {
		this.scene = scene;
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		boolean hasChanged = false;
		// 找到下一个有变化的场景管理器
		SceneGroupPlayerManager playerGroupManager = null;
		int maxLoop = scene.getPlayerManager().getMaxGroupKey();
		for (int i = 0; i < maxLoop; i++) {
			curGroupId = curGroupId % scene.getPlayerManager().getMaxGroupKey() + 1;
			playerGroupManager = scene.getPlayerManager().getGroupPlayerManager(curGroupId);
			if (playerGroupManager != null && 
					playerGroupManager.isChanged()) {
				// 找到第一个合法的分组管理器
				hasChanged = true;
				break;
			}
		}
		
		if (!hasChanged) {
			// 记录警告日志，周期内该场景没有发生变化的玩家
			Loggers.sceneLogger.warn("#ScenePlayerRefresh#run#No changed SceneGroupPlayerManager.sceneId=" + 
					scene.getId() + ";scenePlayerNum=" + scene.getPlayerManager().getPlayerNum());
			return;
		}
		
		// 非法玩家Id集合
		Set<Long> invalidPlayerIdSet = new HashSet<Long>();
		
		Set<Long> groupPlayerIdSet = playerGroupManager.getGroupPlayerIdSet();
		for (Iterator<Long> it = groupPlayerIdSet.iterator(); it.hasNext(); ) {
			long uuid = it.next();
			Player player = Globals.getOnlinePlayerService().getPlayer(uuid);
			
			// 如果玩家已不在在线列表中或已经不属于当前场景，则删除该玩家
			if (player == null || player.getHuman() == null || player.getSceneId() != scene.getId()) {
				invalidPlayerIdSet.add(uuid);
				continue;
			}
			// 给前台发消息，告知这个周期内变化的玩家，包括removed、added、moved、changed
			
			// 删除
			processRemovedPlayer(player, playerGroupManager);
			
			// 新增
			processAddedPlayer(player, playerGroupManager);
			
			// 变化
			processChangedPlayer(player, playerGroupManager);
			
			// 移动
			processMovedPlayer(player, playerGroupManager);
		}
		// 清除临时列表
		playerGroupManager.onPeriodEnd();
		
		// 非法玩家的处理，从场景玩家管理器中移除其数据
		if (!invalidPlayerIdSet.isEmpty()) {
			for (Long invalidPlayerId : invalidPlayerIdSet) {
				// 移除非法玩家
				scene.getPlayerManager().onPlayerLeaveScene(invalidPlayerId);
				// 记录警告日志
				Loggers.sceneLogger.warn("#ScenePlayerRefresh#run#There is invalid player.invalidPlayerId=" + 
						invalidPlayerId + ".sceneId=" +	scene.getId() + ";scenePlayerNum=" + scene.getPlayerManager().getPlayerNum());
			}
		}
	}

	@Override
	public long getRunTimeSpan() {
		return refreshInterval;
	}

	@Override
	public void cancel() {
		isCanceled = true;
	}

	public long getRefreshInterval() {
		return refreshInterval;
	}

	public void setRefreshInterval(long refreshInterval) {
		this.refreshInterval = refreshInterval;
	}
	
	/**
	 * 删除的玩家
	 * @param player
	 */
	protected void processRemovedPlayer(Player player, SceneGroupPlayerManager playerGroupManager) {
		long uuid = player.getRoleUUID();
		// 删除
		Set<Long> rawRemovedSet = playerGroupManager.getRemovedPlayerId();
		Set<Long> removedSet = new HashSet<Long>();
		// 按照removedSet发给玩家 GC_SCENE_PLAYER_REMOVE_LIST消息
		int num = 0;
		for (Long removedUUID : rawRemovedSet) {
			// 根据一些条件进行筛选，符合条件的发给玩家
			if (checkShowUser(uuid, removedUUID)) {
				num++;
				if (num > SCENE_PLAYER_LIST_MAX_NUM) {
					break;
				}
				
				removedSet.add(removedUUID);
			}
		}
		
		if (!removedSet.isEmpty()) {
			// 给玩家发消息
			long[] removedArr = new long[removedSet.size()];
			int i = 0;
			for (Long rid : removedSet) {
				removedArr[i++] = rid;
			}
			GCScenePlayerRemoveList gcScenePlayerRemoveList = new GCScenePlayerRemoveList(scene.getId(), removedArr);
			player.sendMessage(gcScenePlayerRemoveList);
		}
	}
	
	/**
	 * 新增的玩家
	 * @param player
	 */
	protected void processAddedPlayer(Player player, SceneGroupPlayerManager playerGroupManager) {
		long uuid = player.getRoleUUID();
		// 新增
		Set<Long> rawAddedSet = playerGroupManager.getAddedPlayerId();
		List<ScenePlayerInfoData> addedList = new ArrayList<ScenePlayerInfoData>(); 
		int num = 0;
		for (Long addedUUID : rawAddedSet) {
			// 目标玩家是否在线
			Player targetlayer = Globals.getOnlinePlayerService().getPlayer(addedUUID);
			if (targetlayer == null || targetlayer.getHuman() == null) {
				continue;
			}
			// 根据一些条件进行筛选，符合条件的发给玩家
			if (checkShowUser(uuid, addedUUID)) {
				num++;
				if (num > SCENE_PLAYER_LIST_MAX_NUM) {
					break;
				}
				// 将目标玩家加入列表
				addedList.add(new ScenePlayerInfoData(addedUUID, targetlayer.getHuman().buildScenePlayerJsonStr()));
			}
			
		}
		
		if (!addedList.isEmpty()) {
			// 按照addedList发给玩家 GC_SCENE_PLAYER_ADDED_LIST消息
			GCScenePlayerAddedList gcScenePlayerAddedList = new GCScenePlayerAddedList(scene.getId(), addedList.toArray(new ScenePlayerInfoData[0]));
			player.sendMessage(gcScenePlayerAddedList);
		}
	}
	
	/**
	 * 变化的玩家
	 * @param player
	 */
	protected void processChangedPlayer(Player player, SceneGroupPlayerManager playerGroupManager) {
		long uuid = player.getRoleUUID();
		// 变化
		Set<Long> rawChangedSet = playerGroupManager.getChangedPlayer();
		List<ScenePlayerInfoData> changedList = new ArrayList<ScenePlayerInfoData>();
		int num = 0;
		for (Long changedUUID : rawChangedSet) {
			// 目标玩家是否在线
			Player targetlayer = Globals.getOnlinePlayerService().getPlayer(changedUUID);
			if (targetlayer == null || targetlayer.getHuman() == null) {
				continue;
			}
			// 检查玩家是否符合显示条件
			if (checkShowUser(uuid, changedUUID)) {
				num++;
				if (num > SCENE_PLAYER_LIST_MAX_NUM) {
					break;
				}
				// 将目标玩家加入列表
				changedList.add(new ScenePlayerInfoData(changedUUID, targetlayer.getHuman().buildScenePlayerJsonStr()));
			}
		}
		
		if (!changedList.isEmpty()) {
			// 按照changedList发给玩家 GC_SCENE_PLAYER_CHANGED_LIST消息
			GCScenePlayerChangedList gcScenePlayerChangedList = new GCScenePlayerChangedList(scene.getId(), changedList.toArray(new ScenePlayerInfoData[0]));
			player.sendMessage(gcScenePlayerChangedList);
		}
	}
	
	/**
	 * 移动的玩家
	 * @param player
	 */
	protected void processMovedPlayer(Player player, SceneGroupPlayerManager playerGroupManager) {
		long uuid = player.getRoleUUID();
		// 移动
		Map<Long, ScenePlayerPosition> rawMovedMap = playerGroupManager.getMovedPlayerPos();
		List<ScenePlayerMoveInfo> movedList = new ArrayList<ScenePlayerMoveInfo>();
		int num = 0;
		for (Long movedUUID : rawMovedMap.keySet()) {
			// 检查玩家是否符合显示条件
			if (checkShowUser(uuid, movedUUID)) {
				num++;
				if (num > SCENE_PLAYER_LIST_MAX_NUM) {
					break;
				}
				ScenePlayerPosition position = rawMovedMap.get(movedUUID);
				// instantFlag表示是否瞬移到目标位置，0正常移动，1瞬移
				movedList.add(new ScenePlayerMoveInfo(movedUUID, 
						(int)position.getPoint().getX(), (int)position.getPoint().getY(), position.isInstantFlag() ? 1 : 0));
			}
		}
		
		if (!movedList.isEmpty()) {
			// 按照movedList发给玩家 GC_SCENE_PLAYER_MOVED_LIST消息
			GCScenePlayerMovedList gcScenePlayerMovedList = new GCScenePlayerMovedList(scene.getId(), movedList.toArray(new ScenePlayerMoveInfo[0]));
			player.sendMessage(gcScenePlayerMovedList);
		}
	}
	
	/**
	 * 检查目标玩家是否需要在该玩家的场景中显示出来
	 * @param playerId
	 * @param targetPlayerId
	 * @return
	 */
	public boolean checkShowUser(long playerId, long targetPlayerId) {
		return ScenePlayerShowChecker.checkUserNeedShow(scene, playerId, targetPlayerId);
	}
	
//	protected long getIntervalByOnlineNum() {
//		int onlineNum = Globals.getOnlinePlayerService().getOnlinePlayerCount();
//		if (onlineNum <= 500) {
//			// 3~15秒
//			return 3 * TimeUtils.SECOND;
//		}
//		if (onlineNum > 500 && onlineNum <= 1000) {
//			// 18~30秒
//			return 3 * TimeUtils.SECOND;
//		}
//		if (onlineNum > 1000 && onlineNum <= 1500) {
//			// 33~45秒
//			return 3 * TimeUtils.SECOND;
//		}
//		if (onlineNum > 1500 && onlineNum <= 2000) {
//			// 48~60秒
//			return 3 * TimeUtils.SECOND;
//		}
//		if (onlineNum > 2000) {
//			// 63~105秒
//			return 3 * TimeUtils.SECOND;
//		}
//		return 3 * TimeUtils.SECOND;
//	}
//	
//	/**
//	 * 修正更新场景玩家的频率
//	 */
//	public void updaterIntervalTime() {
//		// 根据在线玩家数量，修正频率
//		long interval = getIntervalByOnlineNum();
//		setRefreshInterval(interval);
//	}

}
