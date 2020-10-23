package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.ModuleDataEntity;

/**
 * 功能数据DAO
 * 
 * @author xiaowei.liu
 * 
 */
public class ModuleDataDao extends BaseDao<ModuleDataEntity> {

	public static final String QUERY_ALL_MODULE_DATA = "queryALlModuleData";
	public ModuleDataDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<ModuleDataEntity> getEntityClass() {
		return ModuleDataEntity.class;
	}

	@SuppressWarnings("unchecked")
	public List<ModuleDataEntity> loadAllModuleDataEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_MODULE_DATA, null, null);
		List<ModuleDataEntity> dataList = new ArrayList<ModuleDataEntity>();
		for (Object obj : _queryList) {
			ModuleDataEntity member = (ModuleDataEntity) obj;
			dataList.add(member);
		}
		return dataList;
	}
}
