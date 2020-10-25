package com.imop.lj.gameserver.scene;

public class ScenePlayerShowChecker {
	
	public static boolean checkUserNeedShow(Scene scene, long uuid, long targetId) {
		if (scene == null || scene.getPlayerManager() == null) {
			return false;
		}
		// 排除自己
		if (uuid == targetId) {
			return false;
		}
		// 场景中的玩家少于指定人数，则都可以显示
		if (scene.getPlayerManager().getPlayerNum() < ScenePlayerRefresh.SCENE_PLAYER_LIST_MAX_NUM) {
			return true;
		}
		
		// TODO 其他策略
		
		return true;
	}
	
}
