package com.imop.lj.gameserver.scene.async;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.db.model.SceneEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.scene.Scene;

/**
 * 更新场景操作
 *
 * @author haijiang.jin
 *
 */
public class UpdateSceneOperation implements IIoOperation {
	/** 场景对象 */
	private Scene _sceneObj = null;
	/** 场景实体 */
	private SceneEntity _sceneEntity = null;

	/**
	 * 类参数构造器
	 *
	 * @param sceneObj
	 */
	public UpdateSceneOperation(Scene sceneObj) {
		this._sceneObj = sceneObj;
	}

	@Override
	public int doIo() {
		do {
			try {
				if (this._sceneEntity == null) {
					return IIoOperation.STAGE_IO_DONE;
				}

				// 保存场景到数据库
				Globals.getDaoService().getSceneDao().update(this._sceneEntity);
			} catch (Exception ex) {
				// 记录错误日志
				Loggers.playerLogger.error("scene update error", ex);
			}
		} while (false);

		return IIoOperation.STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		this._sceneEntity = this._sceneObj.toEntity();
		return IIoOperation.STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		return IIoOperation.STAGE_STOP_DONE;
	}
}
