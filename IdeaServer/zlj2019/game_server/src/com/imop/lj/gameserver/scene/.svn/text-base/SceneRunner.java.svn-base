package com.imop.lj.gameserver.scene;

import java.util.concurrent.Callable;

import com.imop.lj.common.constants.Loggers;

public class SceneRunner implements Callable<Integer> {

	/** 绑定的场景 */
	private final Scene scene;

	public SceneRunner(Scene scene) {
		this.scene = scene;
	}

	@Override
	public Integer call() throws Exception {
		try {
			scene.tick();
		} catch (Throwable e) {
			Loggers.gameLogger.error("", e);
		}
		return scene.getId();
	}

	public int getSceneId() {
		return scene.getId();
	}

}
