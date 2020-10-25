package com.imop.lj.gameserver.human.event;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import org.slf4j.Logger;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.event.IEvent;
import com.imop.lj.core.event.IEventListener;
import com.imop.lj.core.util.CollectionUtil;
import com.imop.lj.gameserver.common.listener.ArenaRefreshListener;
import com.imop.lj.gameserver.common.listener.BattleEscapeListener;
import com.imop.lj.gameserver.common.listener.CostMoneyListener;
import com.imop.lj.gameserver.common.listener.FightPowerChangeListener;
import com.imop.lj.gameserver.common.listener.GiveMoneyListener;
import com.imop.lj.gameserver.common.listener.GoodActivityFinishTargetListener;
import com.imop.lj.gameserver.common.listener.LeaderLevelUpListener;
import com.imop.lj.gameserver.common.listener.LoginDaysAddListener;
import com.imop.lj.gameserver.common.listener.MainBagGetItemListener;
import com.imop.lj.gameserver.common.listener.MainBagRemoveItemListener;
import com.imop.lj.gameserver.common.listener.MallBuyItemListener;
import com.imop.lj.gameserver.common.listener.OpenFuncListener;
import com.imop.lj.gameserver.common.listener.PlayerChargeDiamondListener;
import com.imop.lj.gameserver.common.listener.PlayerCorpsChangedListener;
import com.imop.lj.gameserver.common.listener.PlayerFinishQuestListener;
import com.imop.lj.gameserver.common.listener.PlayerSceneDataChangeListener;
import com.imop.lj.gameserver.common.listener.TeamMemberChangeListener;
import com.imop.lj.gameserver.common.listener.VipStateChangeListener;

/**
 * 事件管理器,负责事件监听器的注册,以及各系统之间事件的转发
 * 
 * 
 * 
 */
@SuppressWarnings({ "unchecked", "rawtypes" })
public class EventService implements IEventListener {
	private static final Logger logger = Loggers.eventLogger;
	private final Map<EventType, List<IEventListener>> typeEventListeners = CollectionUtil.buildHashMap();

	public EventService() {
		
	}
	
	/**
	 * 初始化，添加所有的监听事件
	 */
	public void init() {
		addListener(EventType.PlayerChargeDiamondEvent,	new PlayerChargeDiamondListener());
		addListener(EventType.PlayerFinishQuest, new PlayerFinishQuestListener());
		addListener(EventType.GiveMoney, new GiveMoneyListener());
		addListener(EventType.MainBagGetItem, new MainBagGetItemListener());
		addListener(EventType.MainBagRemoveItem, new MainBagRemoveItemListener());
		addListener(EventType.LeaderLevelUp, new LeaderLevelUpListener());
		addListener(EventType.OpenFunc, new OpenFuncListener());
		addListener(EventType.LoginDaysAdd, new LoginDaysAddListener());
		addListener(EventType.PlayerSceneDataChange, new PlayerSceneDataChangeListener());
		addListener(EventType.FightPowerChange, new FightPowerChangeListener());
		addListener(EventType.MallBuyItem, new MallBuyItemListener());
		addListener(EventType.BattleEscape, new BattleEscapeListener());
		addListener(EventType.TeamMemberChange, new TeamMemberChangeListener());
		addListener(EventType.PlayerCorpsChanged, new PlayerCorpsChangedListener());
		addListener(EventType.ArenaRefresh, new ArenaRefreshListener());
		addListener(EventType.CostMoney, new CostMoneyListener());
		addListener(EventType.VipStateChange, new VipStateChangeListener());
		addListener(EventType.GoodActivityFinishTarget, new GoodActivityFinishTargetListener());
		
	}
	

	/**
	 * 添加事件监听器
	 * 
	 * @param type
	 * @param listener
	 */
	public void addListener(EventType type, IEventListener listener) {
		List<IEventListener> _list = typeEventListeners.get(type);
		if (_list == null) {
			_list = new ArrayList<IEventListener>();
			this.typeEventListeners.put(type, _list);
		}
		for (IEventListener _listener : _list) {
			if (_listener.getClass() == listener.getClass()) {
				throw new IllegalArgumentException("The dup class listener [" + listener.getClass() + "]");
			}
		}
		if (logger.isInfoEnabled()) {
			logger.info("[#GS.HumanEventService.addListener] [Register event listener (event:" + type + " listener:" + listener.getClass().getName()
					+ "]");
		}
		_list.add(listener);
	}

	@Override
	public void fireEvent(IEvent event) {
		if (event instanceof Event) {
			EventType type = ((Event) event).getType();
			List<IEventListener> _eventListeners = this.typeEventListeners.get(type);
			if (_eventListeners == null || _eventListeners.isEmpty()) {
				return;
			}
			for (IEventListener _listener : _eventListeners) {
				_listener.fireEvent(event);
			}
		}
	}
}
