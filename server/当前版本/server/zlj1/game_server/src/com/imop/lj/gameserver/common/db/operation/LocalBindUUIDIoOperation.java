package com.imop.lj.gameserver.common.db.operation;

import com.imop.lj.core.async.IIoOperation;

/**
 * 专门用于local的与UUID绑定的异步操作接口
 */
public interface LocalBindUUIDIoOperation extends IIoOperation {

	/**
	 * 取得该操作绑定的uuid
	 *
	 * @return
	 */
	public long getBindUUID();
}
