package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.DirtyWordsTypeEntity;

/**
 * 
 */
public class DirtyWordsTypeDao extends BaseDao<DirtyWordsTypeEntity> {
	public static final String QUERY_ALL_DIRTY_WORLDS_TYPE = "queryAllDirtyWords";
	public DirtyWordsTypeDao(DBService dbServcie) {
		super(dbServcie);
	}

	/**
	 * 取得数据库版本号
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public DirtyWordsTypeEntity getDirtyWorldsTypeEntity() {
		List<DirtyWordsTypeEntity> _dirtyWorldsTypeEntity = dbService.findByNamedQuery(QUERY_ALL_DIRTY_WORLDS_TYPE);
		if (_dirtyWorldsTypeEntity == null || _dirtyWorldsTypeEntity.isEmpty()) {
			return null;
		}
		return _dirtyWorldsTypeEntity.get(0);
	}

	@Override
	protected Class<DirtyWordsTypeEntity> getEntityClass() {
		return DirtyWordsTypeEntity.class;
	}

}
