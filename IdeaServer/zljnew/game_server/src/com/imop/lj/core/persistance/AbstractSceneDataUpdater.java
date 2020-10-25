package com.imop.lj.core.persistance;

import java.io.Serializable;
import java.util.Collections;
import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Iterator;
import org.slf4j.Logger;

import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.util.ErrorsUtil;


/**
 *
 * 数据更新接口的默认实现,用于更新或者被删除的{@link LifeCycle}类型的对象
 * @author jiliang.lu
 *
 */
public abstract class AbstractSceneDataUpdater implements DataUpdater{

	protected final static Logger logger = Loggers.updateLogger;
	
	/** 保存需要被更新的,Key:实体的ID,Value:将要被更新的实体 */
	private Map<Object, UpdateEntry> changedObjects = new LinkedHashMap<Object, UpdateEntry>();

	/** 是否正在执行Update操作 */
	private volatile boolean isUpdating = false;

	/** 一次存库的数量 */
	protected int batchNum = 5;

	public AbstractSceneDataUpdater() {
		
	}

	/**
	 * 增加要被更新对象
	 *
	 * @param lifeCycle
	 * @return
	 */
	@Override
	public boolean addUpdate(LifeCycle lifeCycle) {
		if (lifeCycle == null) {
			throw new IllegalArgumentException("The value must not be null.");
		}
		if (isUpdating) {
			throw new IllegalStateException(
					"The update operation is running,can't add new update");
		}
		final Serializable _key = lifeCycle.getKey();
		UpdateEntry _pre = changedObjects.get(_key);
		if (_pre != null) {
			if (_pre.obj != lifeCycle) {
				if (logger.isWarnEnabled()) {
					logger
							.warn("[#GS.UpdateService.addUpdate] [The object to be updated not the same instance,is this a bug?]");
				}
				return false;
			} else {
				return true;
			}
		}
		UpdateEntry _now = new UpdateEntry(UpdateEntry.OPER_UPDATE, lifeCycle);
		changedObjects.put(_key, _now);
		return true;
	}


	/**
	 * 增加要被删除的对象
	 *
	 * @param lifeCycle
	 * @return
	 */
	@Override
	public boolean addDelete(LifeCycle lifeCycle) {
		if (lifeCycle == null) {
			throw new IllegalArgumentException("The value must not be null.");
		}
		if (isUpdating) {
			throw new IllegalStateException(
					"The delete operation is running,can't add new update");
		}
		final Serializable _key = lifeCycle.getKey();
		UpdateEntry _now = new UpdateEntry(UpdateEntry.OPER_DEL, lifeCycle);
		changedObjects.put(_key, _now);
		return true;
	}


	/**
	 * 执行update操作
	 *
	 */
	@Override
	public void update() {
		try {
			this.isUpdating = true;
			long _s = System.nanoTime();
			final int _beginSize = this.changedObjects.size();
			if (_beginSize > 0) {
				if (logger.isDebugEnabled()) {
					logger
							.debug("[#GS.UpdateService.update] [Begin to sync objects size:"
									+ this.changedObjects.size() + "]");
				}
			}
			
			int count = 0;
			Iterator<UpdateEntry> it = this.changedObjects.values().iterator();
			for (;it.hasNext();) {
				UpdateEntry _entry = it.next();
				LifeCycle _obj = _entry.obj;
				try {
					if (_entry.operation == UpdateEntry.OPER_UPDATE) {
						// 执行更新操作
						this.doUpdate(_obj);
					} else if (_entry.operation == UpdateEntry.OPER_DEL) {
						// 执行删除操作
						this.doDel(_obj);
					}
				} catch (Exception e) {
					logger.error(
							ErrorsUtil.error(
									CommonErrorLogInfo.DB_OPERATE_FAIL,
									"#GS.UpdateService.update", "key:"
											+ _obj.getKey()), e);
				} finally {
					// 无论成功失败，都移除掉
					it.remove();
					
					count++;
					// 每次只处理指定条数
					if (count >= batchNum) {
						break;
					}
				}
			}
			
			final int _leftSize = this.changedObjects.size();
			if (_leftSize > 0) {
				if (logger.isDebugEnabled()) {
					logger
							.debug("[#GS.UpdateService.update] [sync objects left size:"
									+ this.changedObjects.size() + "]");
				}
			}
			if (_beginSize != _leftSize + count) {
				logger.error(ErrorsUtil.error(CommonErrorLogInfo.INVALID_STATE,
						"#GS.DataUpdater.update", "The begin size is ["
								+ _beginSize + "] but the left size is ["
								+ _leftSize + "] and the count is ["
								+ count + "]"),
						new IllegalStateException());
			}
			long _time = (System.nanoTime() - _s) / (1000 * 1000);
			if (_time > 0 && logger.isDebugEnabled()) {
				logger.debug("[#GS.DataUpdater.update] [Update Time:" + (_time)
						+ "ms]");
			}
		} finally {
			this.isUpdating = false;
		}
	}

	/**
	 * 返回改变的对象
	 *
	 * @return
	 */
	public Map<Object, UpdateEntry> getChangedObjects() {
		return Collections.unmodifiableMap(changedObjects);
	}
	
	abstract protected void doUpdate(LifeCycle lc);

	abstract protected void doDel(LifeCycle lc);

}
