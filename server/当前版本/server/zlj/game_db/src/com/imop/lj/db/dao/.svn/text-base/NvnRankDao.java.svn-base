package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.NvnRankEntity;

/**
 * nvn排名Dao
 */
public class NvnRankDao extends BaseDao<NvnRankEntity>  {
	/** 查询语句名称 ：查询玩家的任务 */
	public static final String QUERY_ALL_NVN_RANK = "queryAllNvnRank";

	public NvnRankDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<NvnRankEntity> getEntityClass() {
		return NvnRankEntity.class;
	}
	
	public void saveOrUpdate(NvnRankEntity entity) {
		dbService.saveOrUpdate(entity);
	}

	/**
	 * 加载所有军团站排名
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<NvnRankEntity> loadAllEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_ALL_NVN_RANK, null, null);
		List<NvnRankEntity> lst = new ArrayList<NvnRankEntity>();
		for (Object obj : _queryList) {
			NvnRankEntity member = (NvnRankEntity) obj;
			lst.add(member);
		}
		return lst;
	}
	
}
