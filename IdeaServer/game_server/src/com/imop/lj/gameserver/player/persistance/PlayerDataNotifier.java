package com.imop.lj.gameserver.player.persistance;

import java.io.Serializable;
import java.util.LinkedHashMap;
import java.util.Map;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.annotation.NotThreadSafe;
import com.imop.lj.core.object.LifeCycle;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.gameserver.common.event.HumanDataChangedEvent;
import com.imop.lj.gameserver.common.log.GameErrorLogInfo;
import com.imop.lj.gameserver.human.event.EventService;

/**
 * 数据变更通知接口的实现
 *
  *
 *
 */
@NotThreadSafe
public class PlayerDataNotifier {
	private final static Logger logger = Loggers.updateLogger;
	/** 保存需要被更新的,Key:实体的ID,Value:将要被更新的实体 */
	private final Map<Serializable, HumanDataChangedEvent> changedObjects = new LinkedHashMap<Serializable, HumanDataChangedEvent>();

	/** 事件管理器 */
	private final EventService eventManager;

	/**
	 *
	 * @param eventManager
	 */
	public PlayerDataNotifier(EventService eventManager) {
		this.eventManager = eventManager;
	}

	/**
	 * 增加要被更新对象
	 *
	 * @param instance
	 * @return
	 */
	public boolean addChanged(final LifeCycle instance) {
		if (instance == null) {
			throw new IllegalArgumentException("The value must not be null.");
		}
		if (!instance.isActive()) {
			return false;
		}
		try {
			final Serializable _key = instance.getKey();
			if (!this.changedObjects.containsKey(_key)) {
				this.changedObjects.put(_key,
						new HumanDataChangedEvent(instance));
				return true;
			}
		} catch (Exception e) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(GameErrorLogInfo.INVALID_STATE,
						"#GS.DataNotifier.addUpdate", ""), e);
			}
		}
		return false;
	}

	/**
	 * 触发玩家数据更新的事件,只触发处于活动状态的对象,即{@link ICharObject#isLive()}为true的对象
	 */
	public void onChange() {
		if (this.changedObjects.isEmpty()) {
			return;
		}
		try {
			for (final HumanDataChangedEvent _charObj : this.changedObjects
					.values()) {
				if (!_charObj.getInfo().isActive()) {
					return;
				}
				try {
					this.eventManager.fireEvent(_charObj);
				} catch (Exception e) {
					if (logger.isErrorEnabled()) {
						logger.error(ErrorsUtil.error(
								GameErrorLogInfo.INVALID_STATE,
								"#GS.DataNotifier.onChange", ""), e);
					}
				}
			}
		} catch (Exception e) {
			if (logger.isErrorEnabled()) {
				logger.error(ErrorsUtil.error(GameErrorLogInfo.INVALID_STATE,
						"#GS.DataNotifier.onChange", ""), e);
			}
		} finally {
			this.changedObjects.clear();
		}
	}
}
