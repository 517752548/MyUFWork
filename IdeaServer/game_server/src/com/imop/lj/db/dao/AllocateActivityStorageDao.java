package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.AllocateActivityStorageEntity;

public class AllocateActivityStorageDao extends BaseDao<AllocateActivityStorageEntity>{
	
	public static final String QUERY_All_ALLOCATE_ACTIVITY_STORAGE= "queryAllocateActivityStorage";
	
	
	public AllocateActivityStorageDao(DBService dbService) {
		super(dbService);
	}
	
	@Override
	protected Class<AllocateActivityStorageEntity> getEntityClass() {
		return AllocateActivityStorageEntity.class;
	}
	
	/**
	 * 加载所有实例
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<AllocateActivityStorageEntity> loadAllocateActivityStorageEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_All_ALLOCATE_ACTIVITY_STORAGE, null, null);
		List<AllocateActivityStorageEntity> AllocateActivityStorageList = new ArrayList<AllocateActivityStorageEntity>();
		for (Object obj : _queryList) {
			AllocateActivityStorageEntity member = (AllocateActivityStorageEntity) obj;
			AllocateActivityStorageList.add(member);
		}
		return AllocateActivityStorageList;
	}
}
