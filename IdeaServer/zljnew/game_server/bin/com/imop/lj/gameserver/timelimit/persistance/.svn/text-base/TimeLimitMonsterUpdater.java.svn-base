package com.imop.lj.gameserver.timelimit.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.timelimit.monster.TimeLimitMonster;

public class TimeLimitMonsterUpdater implements POUpdater {
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final TimeLimitMonster task = (TimeLimitMonster)obj;
		TimeLimitMonsterDbManager.getInstance().delTaskEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final TimeLimitMonster task = (TimeLimitMonster)obj;
		TimeLimitMonsterDbManager.getInstance().saveTaskEntity(task, true);
	}
}
