package com.imop.lj.gameserver.scene.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.scene.Scene;
import com.imop.lj.gameserver.scene.SceneService;
import com.imop.lj.gameserver.scene.msg.CGScenePlayerEnter;
import com.imop.lj.gameserver.scene.msg.CGScenePlayerMove;

/**
 * 场景消息处理，主要处理玩家进入、退出场景，玩家移动等消息
 * 
 * 
 */
public class SceneMessageHandler {

	private SceneService sceneService;
	private OnlinePlayerService onlinePlayerService;

	protected SceneMessageHandler(SceneService sceneManager,
			OnlinePlayerService onlinePlayerManager) {
		this.sceneService = sceneManager;
		this.onlinePlayerService = onlinePlayerManager;
	}

	public SceneMessageHandler() {
	}

	/**
	 * <pre>
	 * 玩家进入场景，应只在场景所在的线程中调用，先将玩家从当前场景中移
	 * 除
	 * </pre>
	 * 
	 * @param playerId
	 * @param sceneId
	 * @param location
	 *            TODO
	 */
	public boolean handleEnterScene(int playerId, int sceneId) {
		Scene scene = sceneService.getScene(sceneId);
		Player player = onlinePlayerService.getPlayerByTempId(playerId);
		if (player == null) {
			Loggers.gameLogger.error(String.format(
					"handleEnterScene player == null. id=%d, sceneId=%d",
					playerId, sceneId));
			return false;
		}
		return scene.onPlayerEnter(player);
	}

	/**
	 * <pre>
	 * 玩家离开场景，应只在场景所在的线程中调用，先将玩家从当前场景中移
	 * 除，然后再发送消息给主线程
	 * </pre>
	 * 
	 * @param playerId
	 * @param sceneId
	 */
	public void handleLeaveScene(int playerId, int sceneId) {
		Scene scene = sceneService.getScene(sceneId);
		Player p = onlinePlayerService.getPlayerByTempId(playerId);
		if (p != null) {
			scene.onPlayerLeave(p);
		} else {
			Loggers.gameLogger
					.error(String
							.format("leave scene fail. cannot find player in onlinePlayerService. id=%d, sceneId=%d",
									playerId, sceneId));
		}
	}

	public void handleScenePlayerEnter(Player player,
			CGScenePlayerEnter cgScenePlayerEnter) {
		// TODO 玩家进入一个新的场景，离开原场景，进入新场景

	}

	public void handleScenePlayerMove(Player player,
			CGScenePlayerMove cgScenePlayerMove) {
		//目前没这个功能，先干掉
		return;
//		if (player == null || player.getHuman() == null
//				|| player.getHuman().getScene() == null) {
//			return;
//		}
//
//		// 玩家移动
//		Point targetPoint = new Point(cgScenePlayerMove.getX(),
//				cgScenePlayerMove.getY());
//		ScenePlayerPosition position = new ScenePlayerPosition(targetPoint);
//		player.getHuman().getScene().onPlayerMove(player, position);
	}

}
