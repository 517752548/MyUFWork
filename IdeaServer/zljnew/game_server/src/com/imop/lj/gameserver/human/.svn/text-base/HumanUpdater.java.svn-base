package com.imop.lj.gameserver.human;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.player.PlayerConstants;
import com.imop.lj.gameserver.player.async.SavePlayerRoleOperation;

/**
 * 玩家角色基本信息更新器
 *
 * @see Human#setModified()
 */
public class HumanUpdater implements POUpdater {
	@Override
	public void save(PersistanceObject<?,?>  obj) {
		final Human human = (Human) obj;
		if (human == null) {
			return;
		}
		Player player = human.getPlayer();
		if (player == null) {
			return;
		}
		SavePlayerRoleOperation saveTask = new SavePlayerRoleOperation(player,
				PlayerConstants.CHARACTER_INFO_MASK_BASE, false);
		Globals.getAsyncService().createOperationAndExecuteAtOnce(saveTask);

	}

	@Override
	public void delete(PersistanceObject<?,?>  obj) {
		throw new UnsupportedOperationException();
	}
}
