package com.imop.lj.gameserver.scene;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.heartbeat.HeartbeatTask;

/**
 * 场景玩家更新器
 * @author yu.zhao
 *
 */
public class SceneCheckTickTask implements HeartbeatTask {
	
	protected static final Logger log = Loggers.sceneLogger;
	
	
	/** 场景玩家更新频率 */
	private long refreshInterval = 30 * TimeUtils.SECOND;
	
	private boolean isCanceled;
	
	private Scene scene;
	
	public SceneCheckTickTask(Scene scene) {
		this.scene = scene;
		this.isCanceled = false;
	}

	@Override
	public void run() {
		if (isCanceled) {
			return;
		}
		
		log.info("【CHECK SCENE】Time:" + TimeUtils.formatYMDHMTime(Globals.getTimeService().now()) + ";" 
				+ "Scene type:" + this.scene.getClass().getSimpleName() + ";"
				+ "Scene templateId:" + this.scene.getTemplateId() + ";");
	}

	@Override
	public long getRunTimeSpan() {
		return refreshInterval;
	}

	@Override
	public void cancel() {
		isCanceled = true;
	}
}
