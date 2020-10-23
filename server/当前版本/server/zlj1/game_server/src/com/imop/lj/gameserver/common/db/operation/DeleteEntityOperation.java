package com.imop.lj.gameserver.common.db.operation;

import org.slf4j.Logger;

import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.core.orm.DataAccessException;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.db.dao.BaseDao;

/**
 * 直接操作实体对象,注意该实现在做IO操作前不会对原对象进行拷贝操作
 *
  *
 */
public class DeleteEntityOperation<T extends BaseEntity<?>> implements BindUUIDIoOperation {
	private static final Logger logger = Loggers.asyncLogger;
	private final T entity;
	private final long roleUUID;
	private final BaseDao<T> dao;

	/**
	 *
	 * @param entity
	 * @param operation
	 */
	public DeleteEntityOperation(T entity, long roleUUID, BaseDao<T> dao) {
		this.entity = entity;
		this.roleUUID = roleUUID;
		this.dao = dao;
	}

	@Override
	public int doIo() {
		try {
			this.dao.delete(entity);
		} catch (DataAccessException e) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(
						CommonErrorLogInfo.DB_OPERATE_FAIL,
						"#GS.UpdateOperation.doIo", null), e);
			}
			return STAGE_STOP_DONE;
		}
		return STAGE_IO_DONE;
	}

	@Override
	public int doStart() {
		return STAGE_START_DONE;
	}

	@Override
	public int doStop() {
		return STAGE_STOP_DONE;
	}

	@Override
	public long getBindUUID() {
		return this.roleUUID;
	}
}
