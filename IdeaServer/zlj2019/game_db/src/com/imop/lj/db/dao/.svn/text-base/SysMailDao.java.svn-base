package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.SysMailEntity;

/**
 * 全服邮件的DAO
 *
 */
public class SysMailDao extends BaseDao<SysMailEntity>  {
	/** 查询语句名称 ：查询所有数据 */
	public static final String QUERY_ALL_SYS_MAIL = "queryAllSysMail";

	public SysMailDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<SysMailEntity> getEntityClass() {
		return SysMailEntity.class;
	}
	
	public void saveOrUpdate(SysMailEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 查询所有全服邮件
	 * 
	 * @return
	 */
	@SuppressWarnings({ "unchecked", "rawtypes" })
	public List<SysMailEntity> loadAllSysMailEntity() {
		List _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_SYS_MAIL, null, null, -1, -1);
		return _queryList;
	}
	
}
