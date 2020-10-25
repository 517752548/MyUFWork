package com.imop.lj.gameserver.relation;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.async.IIoOperation;
import com.imop.lj.core.orm.DataAccessException;
import com.imop.lj.core.util.ErrorsUtil;
import com.imop.lj.db.dao.RelationDao;
import com.imop.lj.db.model.RelationEntity;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.db.operation.SaveObjectOperation;
import com.imop.lj.gameserver.human.Human;



public class RelationDbManager {
	/** 关系系统数据库操作管理 */
	private static RelationDbManager relationDbManager = new RelationDbManager();

	private RelationDbManager() {

	}
	
	/**
	 * 获取关系系统数据库操作管理类
	 * 
	 * @return
	 */
	public static RelationDbManager getInstance() {
		return relationDbManager;
	}
	
	/**
	 * 从数据库中读取关系系统数据
	 * @param charId
	 */
	public List<Relation> loadAllRelationFromDB(Human owner) {
		List<Relation> relationList = new ArrayList<Relation>();
		try {
			List<RelationEntity> relationEntityList = getRelationDao().loadRelationsByRoleId(owner.getCharId());
			for (RelationEntity _relationInfo : relationEntityList) {
				RelationTypeEnum typeEnum = RelationTypeEnum.valueOf(_relationInfo.getRelationType());
				//如果对应的关系类型没有定义，跳过
				if (typeEnum == null || typeEnum == RelationTypeEnum.NONE) {
					continue;
				}
				
				Relation _relation = new Relation(owner);
				_relation.fromEntity(_relationInfo);
				_relation.setOwner(owner);
				//TODO::可能需要进行初始化
				_relation.init();

				// 添加到关系列表
				relationList.add(_relation);
			}
		} catch (DataAccessException e) {
			String msg = ErrorsUtil.error(
					CommonErrorLogInfo.DB_OPERATE_FAIL,
					"#GS.RelationDbManager.loadAllRelationFromDB", null);
			if (Loggers.relationLogger.isDebugEnabled()) {
				Loggers.relationLogger.error(msg, e);
			}
		}
		
		return relationList;
	}
	
	/**
	 * 保存关系
	 * @param relation
	 * @param async 为true则异步保存，为false则同步保存
	 */
	public void saveRelation(Relation relation, boolean async) {
		IIoOperation _oper = new SaveObjectOperation<RelationEntity, Relation>(relation,
				getRelationDao());
		if (async) {
			Globals.getAsyncService().createOperationAndExecuteAtOnce(_oper);
		} else {
			Globals.getAsyncService()
					.createSyncOperationAndExecuteAtOnce(_oper);
		}
	}
	
	/**
	 * 取得关系系统的Dao实例
	 * 
	 * @return
	 */
	private RelationDao getRelationDao() {
		return Globals.getDaoService().getRelationDao();
	}
}
