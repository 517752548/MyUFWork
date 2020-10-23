package com.imop.lj.gameserver.redenvelope.persistance;

import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.redenvelope.RedEnvelope;

public class RedEnvelopeUpdater implements POUpdater  {
	
	@Override
	public void delete(PersistanceObject<?, ?> obj) {
		final RedEnvelope task = (RedEnvelope)obj;
		RedEnvelopeDbManager.getInstance().delEntity(task, true);
	}

	@Override
	public void save(PersistanceObject<?, ?> obj) {
		final RedEnvelope task = (RedEnvelope)obj;
		RedEnvelopeDbManager.getInstance().saveEntity(task, true);
	}

}
