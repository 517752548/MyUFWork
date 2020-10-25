package com.imop.lj.gameserver.scene;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.scene.async.UpdateSceneOperation;

/**
 * 场景更新器
 *
 * @author haijiang.jin
 *
 */
public class SceneUpdater implements POUpdater {

	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		// 场景数据不能删除
		throw new UnsupportedOperationException();
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		// 创建异步操作, 更新场景信息
		Globals.getAsyncService().createOperationAndExecuteAtOnce(
			new UpdateSceneOperation((Scene)obj));
	}
}
