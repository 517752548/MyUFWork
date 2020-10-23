package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.event.PlayerSceneInfoChangeEvent;
import com.imop.lj.gameserver.human.Human;

public class PlayerSceneDataChangeListener implements IEventListener<PlayerSceneInfoChangeEvent> {

	@Override
	public void fireEvent(PlayerSceneInfoChangeEvent event) {
		Human human = event.getInfo();
		if (human == null || human.getPlayer() == null || human.getScene() == null) {
			return;
		}
		human.getScene().onPlayerInfoChanged(human.getPlayer());
	}
}
