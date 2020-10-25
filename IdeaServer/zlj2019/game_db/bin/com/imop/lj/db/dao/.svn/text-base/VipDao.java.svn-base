package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.VipEntity;

/**
 * Vip Dao
 * 
 * @author xiaowei.liu
 * 
 */
public class VipDao extends BaseDao<VipEntity> {
	/** 加载军团查询语句名称 */
	public static final String QUERY_All_VIP = "queryAllVip";
	public VipDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<VipEntity> getEntityClass() {
		return VipEntity.class;
	}
	
	/**
	 * 加载所有VIP信息
	 * 
	 * @param corpsId
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<VipEntity> loadAllEntity() {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_All_VIP, null, null);
		List<VipEntity> corpsList = new ArrayList<VipEntity>();
		for (Object obj : _queryList) {
			VipEntity member = (VipEntity) obj;
			corpsList.add(member);
		}
		return corpsList;
	}

}
