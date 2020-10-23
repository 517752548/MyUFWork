package com.imop.lj.mergedb.db.dao;

import java.io.Serializable;

import com.imop.lj.core.orm.BaseEntity;
import com.imop.lj.core.orm.DBService;
import com.imop.lj.core.orm.DataAccessException;
import com.imop.lj.mergedb.db.MergeDbType;

/**
 * 合服MergeDao
 *
 */
public class MergeExtraDao {

//	private static final String[] charId_params = new String[] { "charId" };
//	private static final String[] id_params = new String[] { "id" };
//	private static final String[] roleId_params = new String[] { "roleId" };
//	private static final String[] targetCharId_params = new String[] { "targetCharId" };
	

	private DBService dbService;
	/**
	 * 合服数据库类型
	 */
	private MergeDbType type;

	public MergeExtraDao(DBService dbService,MergeDbType type) {
		this.dbService = dbService;
		this.type = type;
	}

	/**
	 * 根据指定类型的指定ID查询实体
	 * @param entityClass
	 * @param id
	 * @return
	 */
	public Object get(Class<? extends BaseEntity<?>> entityClass,Serializable id){
		return this.dbService.get(entityClass, id);
	}

	/**
	 * 更新一个实体
	 *
	 * @param obj
	 * @exception DataAccessException
	 */
	public void update(BaseEntity<?> obj) {
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.update(obj);
	}

	/**
	 * 删除一个实体
	 *
	 * @param obj
	 * @exception DataAccessException
	 */
	public void delete(BaseEntity<?> obj) {
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.delete(obj);
	}

	/**
	 * 保存一个实体
	 *
	 * @param obj
	 * @exception DataAccessException
	 */
	public void save(BaseEntity<?> obj) {
		if(type == MergeDbType.FROM || type == MergeDbType.TO){
			throw new IllegalArgumentException("不能更新此类型数据库");
		}
		this.dbService.save(obj);
	}

//	public int deleteArenaSnapEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteArenaSnapEntityByCharId",
//				id_params, new Object[] { charId });
//	}
//	
//	public int deleteCorpsMemberEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteCorpsMemberEntityByCharId",
//				roleId_params, new Object[] { charId });
//	}
//
//	/** 按照charId删除正在做的任务信息 */
//	public int deleteDoingQuestEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteCorpsMemberEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	
//	public int deleteFinishedQuestEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteFinishedQuestEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	public int deleteHorseEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteHorseEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	public int deleteHumanEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteHumanEntityByCharId",
//				id_params, new Object[] { charId });
//	}
//	public int deleteItemEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteItemEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	public int deleteLandEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteLandEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	public int deleteLandlordEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteLandlordEntityByCharId",
//				id_params, new Object[] { charId });
//	}
//	public int deleteLoopTaskEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteLoopTaskEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	public int deleteMailEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteMailEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	
//	public int deleteMoneyTreeEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteMoneyTreeEntityByCharId",
//				id_params, new Object[] { charId });
//	}
//	
//	public int deleteOfflineRewardEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteOfflineRewardEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	
//	public int deletePassTaskEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deletePassTaskEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	
//	public int deletePetEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deletePetEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	
//	public int deleteRelationEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteCorpsMemberEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	
//	public int deleteRelationEntityByTargetCharId(long targetCharId) {
//		return this.dbService.queryForUpdate("deleteRelationEntityByTargetCharId",
//				targetCharId_params, new Object[] { targetCharId });
//	}
//	
//	public int deleteStepTaskEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteStepTaskEntityByCharId",
//				charId_params, new Object[] { charId });
//	}
//	
//	public int deleteUserPrizeByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteUserPrizeByCharId",
//				charId_params, new Object[] { charId });
//	}
//	
//	public int deleteUserSnapEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteUserSnapEntityByCharId",
//				id_params, new Object[] { charId });
//	}
//	
//	public int deleteVipEntityByCharId(long charId) {
//		return this.dbService.queryForUpdate("deleteVipEntityByCharId",
//				id_params, new Object[] { charId });
//	}
	
}
