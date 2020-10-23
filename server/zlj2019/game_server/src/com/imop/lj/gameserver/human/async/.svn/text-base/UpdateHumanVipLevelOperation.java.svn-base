package com.imop.lj.gameserver.human.async;

import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.db.dao.HumanDao;
import com.imop.lj.gameserver.common.db.operation.BindUUIDIoOperation;
import com.imop.lj.gameserver.common.db.operation.OfflineDataOperation;

/**
 * 更新玩家角色的vip等级量操作, 主要用于离线玩家数据更新
 *
 * @author fanghua.cui
 *
 */
public class UpdateHumanVipLevelOperation implements BindUUIDIoOperation, OfflineDataOperation {
	/** 玩家角色 Id */
	private long humanUUId;
	/** vip等级 */
	private int vipLevel;
	/** 玩家角色数据访问层对象 */
	private HumanDao humanDao;
	/** 操作完成回调 */
	private IOperationCompleteCallback callback;

	/**
	 * 类构造器
	 *
	 * @param humanUUId
	 * @param vipLevel
	 * @param humanDao
	 */
	public UpdateHumanVipLevelOperation(long humanUUId, int vipLevel, HumanDao humanDao) {
		if (humanDao == null) {
			throw new IllegalArgumentException("humanDao == null");
		}

		this.humanUUId = humanUUId;
		this.vipLevel = vipLevel;
		this.humanDao = humanDao;
	}

	/**
	 * 获取回调对象
	 *
	 * @return
	 */
	public IOperationCompleteCallback getOperationCallback() {
		return this.callback;
	}

	/**
	 * 设置回调对象
	 *
	 * @param value
	 */
	public void setOperationCallback(IOperationCompleteCallback value) {
		this.callback = value;
	}

	@Override
	public long getBindUUID() {
		return this.humanUUId;
	}

	@Override
	public int doIo() {
		try {
			this.humanDao.updateHumanVipLevel(this.humanUUId, this.vipLevel);
		} catch (Exception ex) {
			logError(ex);
		}

		return STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		if (this.callback != null) {
			this.callback.doCallback();
		}

		return STAGE_STOP_DONE;
	}

	/**
	 * 记录异常信息
	 *
	 * @param ex
	 */
	public static void logError(Exception ex) {
		if (ex == null) {
			return;
		}

		String msg;

		msg = "#GS.UpdateHumanVipLevelOperation.doIo";
		msg = ErrorsUtil.error(CommonErrorLogInfo.DB_OPERATE_FAIL, msg, null);

	}

	/**
	 * 操作完成回调接口
	 *
	 * @author haijiang.jin
	 *
	 */
	public static interface IOperationCompleteCallback {
		/**
		 * 执行回调
		 *
		 */
		void doCallback();
	}
}
