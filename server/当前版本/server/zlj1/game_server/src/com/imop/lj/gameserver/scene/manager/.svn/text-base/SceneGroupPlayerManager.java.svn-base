package com.imop.lj.gameserver.scene.manager;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

import com.imop.lj.common.model.ScenePlayerPosition;

public class SceneGroupPlayerManager {
	private ScenePlayerManager scenePlayerManager;
	/** 分组Id */
	private int groupId;
	
	private boolean changed;
	
	/** 该分组内的所有玩家Id集合 */
	private Set<Long> groupPlayerIdSet;
	
	/** 一个周期中，移除的玩家 */
	private Set<Long> removedPlayerId;
	/** 一个周期中，新增的玩家 */
	private Set<Long> addedPlayerId;
	/** 一个周期中，发送变化的玩家 */
	private Set<Long> changedPlayerId;
	/** 一个周期中，移动的玩家 */
	private Map<Long, ScenePlayerPosition> movedPlayerPos;
	
	public SceneGroupPlayerManager(ScenePlayerManager scenePlayerManager, int groupId) {
		this.scenePlayerManager = scenePlayerManager;
		this.groupId = groupId;
		
		groupPlayerIdSet = new HashSet<Long>();
		removedPlayerId = new HashSet<Long>();
		addedPlayerId = new HashSet<Long>();
		changedPlayerId = new HashSet<Long>();
		movedPlayerPos = new HashMap<Long, ScenePlayerPosition>();
	}
	
	public ScenePlayerManager getScenePlayerManager() {
		return scenePlayerManager;
	}

	public int getGroupId() {
		return groupId;
	}

	public Set<Long> getGroupPlayerIdSet() {
		return groupPlayerIdSet;
	}
	
	public int getGroupPlayerNum() {
		return groupPlayerIdSet.size();
	}
	
	public void onPlayerEnterScene(long uuid) {
		addedPlayerId.add(uuid);
		
		removedPlayerId.remove(uuid);
		movedPlayerPos.remove(uuid);
		
		groupPlayerIdSet.add(uuid);
		changed = true;
	}
	
	public void onPlayerLeaveScene(long uuid) {
		removedPlayerId.add(uuid);
		
		addedPlayerId.remove(uuid);
		movedPlayerPos.remove(uuid);
		
		groupPlayerIdSet.remove(uuid);
		changed = true;
	}
	
	public void onPlayerMove(long uuid, ScenePlayerPosition targetPosition) {
		// 玩家位置移动，覆盖之前的位置
		movedPlayerPos.put(uuid, targetPosition);
		changed = true;
	}
	
	public void onPlayerInfoChanged(long uuid) {
		// 玩家信息发送变化
		changedPlayerId.add(uuid);
		changed = true;
	}
	
	/**
	 * 给前台发送消息后，清除本周期内的记录
	 */
	public void onPeriodEnd() {
		removedPlayerId.clear();
		addedPlayerId.clear();
		movedPlayerPos.clear();
		changedPlayerId.clear();
		changed = false;
	}

	public Set<Long> getRemovedPlayerId() {
		return removedPlayerId;
	}

	public Set<Long> getAddedPlayerId() {
		return addedPlayerId;
	}

	public Map<Long, ScenePlayerPosition> getMovedPlayerPos() {
		return movedPlayerPos;
	}

	public Set<Long> getChangedPlayer() {
		return changedPlayerId;
	}

	public boolean isChanged() {
		return changed;
	}
	
}
