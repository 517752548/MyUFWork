package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.WorldGiftEntity;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年7月8日 下午4:01:55
 * @version 1.0
 */

public class WorldGiftDao extends BaseDao<WorldGiftEntity> {
	
	/** 查询语句名称 ：根据giftid查询*/
	public static final String QUERY_WORLD_GIFT_BY_GIFT_ID = "queryWorldGiftByGiftId";
	
	public WorldGiftDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<WorldGiftEntity> getEntityClass() {
		return WorldGiftEntity.class;
	}

	public void saveOrUpdate(WorldGiftEntity entity) {
		dbService.saveOrUpdate(entity);
	}
	
	
	@SuppressWarnings("unchecked")
	public WorldGiftEntity getWorldGift(final int giftId) {
		List<WorldGiftEntity> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_WORLD_GIFT_BY_GIFT_ID, 
				new String[]{ "giftId" } , new Object[]{ giftId });
		if (_queryList.size() > 0) {
			return (WorldGiftEntity) _queryList.get(0);
		}
		return null;
	}
}
