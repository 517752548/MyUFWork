package com.imop.lj.gameserver.relation;

import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.object.PersistanceObject;
import com.imop.lj.db.model.RelationEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.POUpdater;
import com.imop.lj.gameserver.common.db.operation.DeleteEntityOperation;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;



/**
 * 关系系统数据库管理器
 * 
 */
public class RelationUpdater implements POUpdater {

	@Override
	public void save(PersistanceObject<?,?> obj) {
		Relation relation = (Relation) obj;		
		IIoOperation _oper = new SaveObjectOperation<RelationEntity, Relation>(relation, Globals.getDaoService().getRelationDao());
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
	}
	
	@Override
	public void delete(PersistanceObject<?,?> obj) {
		Relation relation = (Relation) obj;
		final long _charId = relation.getOwner().getCharId();
		final RelationEntity _relationEntity = new RelationEntity();
		_relationEntity.setId(relation.getDbId());
		_relationEntity.setCharId(relation.getCharId());
		IIoOperation _update = new DeleteEntityOperation<RelationEntity>(
				_relationEntity, _charId, Globals.getDaoService().getRelationDao());
		Globals.getAsyncService().createOperationAndExecuteAtOnce(_update);		
	}
}
