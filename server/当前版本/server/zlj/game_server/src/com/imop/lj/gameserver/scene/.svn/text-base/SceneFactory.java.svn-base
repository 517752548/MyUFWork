package com.imop.lj.gameserver.scene;

import com.imop.lj.gameserver.player.OnlinePlayerService;
import com.imop.lj.gameserver.scene.template.SceneTemplate;

/**
 * 场景工厂类
 *
 */
public final class SceneFactory {
	/** 类默认构造器 */
	private SceneFactory() {
	}

	/**
	 * 创建场景
	 *
	 * @param tpl
	 * @param serv
	 * @return
	 *
	 */
	public static Scene createScene(SceneTemplate tpl, OnlinePlayerService serv) {
		// 获取区域类型 ID
		int distTypeId = tpl.getDistTypeId();

		if (distTypeId == SceneTypeEnum.CITY.getIndex()) {
			// 返回城市场景
			return new CityScene(tpl, serv);
		}else if (distTypeId == SceneTypeEnum.COMMON.getIndex()) {
			// 返回公共场景
			return new CommonScene(tpl, serv);
		}
//		else if(distTypeId == SceneTypeEnum.CORPS.getIndex()){
//			//返回军团场景
//			return new CorpsScene(tpl, serv);
//		} else if (distTypeId == SceneTypeEnum.CORPS_WAR.getIndex()) {
//			// 军团战场景
//			return new CorpsWarScene(tpl, serv);
//		} else if (distTypeId == SceneTypeEnum.ARENA.getIndex()) {
//			// 竞技场场景
//			return new ArenaScene(tpl, serv);
//		} else if (distTypeId == SceneTypeEnum.BOSSWAR_SHU.getIndex()) {
//			// 蜀国boss战场景
//			return new BossWarShuScene(tpl, serv);
//		} else if (distTypeId == SceneTypeEnum.BOSSWAR_WEI.getIndex()) {
//			// 魏国boss战场景
//			return new BossWarWeiScene(tpl, serv);
//		} else if (distTypeId == SceneTypeEnum.BOSSWAR_WU.getIndex()) {
//			// 魏国boss战场景
//			return new BossWarWuScene(tpl, serv);
//		} else if (distTypeId == SceneTypeEnum.BOSSWAR_CORPS.getIndex()) {
//			// 军团Boss战场景
//			return new BossWarCorpsScene(tpl, serv);
//		} else if (distTypeId == SceneTypeEnum.MONSTER_WAR.getIndex()) {
//			// 南蛮入侵场景
//			return new MonsterWarScene(tpl, serv);
//		}
		// 如果区域类型不等于1，即为城市类型, 抛出参数异常
		throw new IllegalArgumentException("template error, unknown distTypeId" + distTypeId);
	}
}
