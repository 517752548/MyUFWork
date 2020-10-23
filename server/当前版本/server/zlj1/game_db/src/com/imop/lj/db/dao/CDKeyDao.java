package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CDKeyEntity;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月4日 下午5:22:00
 * @version 1.0
 */

public class CDKeyDao extends BaseDao<CDKeyEntity> {
	
	/** 查询语句名称 ：根据cdkeyid查询*/
	public static final String QUERY_CDKEY_BY_ID = "queryCDKeyById";
	
//	public static final String QUERY_CDKEY_ALL = "QUERY_CDKEY_ALL";
	
//	public static final String QUERY_CDKEY_BY_GROUP_ID = "QUERY_CDKEY_BY_GROUP_ID";
	
//	public static final String QUERY_CDKEY_BY_CDKEY = "queryCDKeyByCDKey";
	/** 查询语句名称 ：查询角色是否领取同一批的cdkey*/
	public static final String QUERY_CDKEY_CHAR_IS_TAKEN_THE_SAME_PLANS_AND_GIFT = "queryCDKeyIsTakeTheSame";
	
	public CDKeyDao(DBService dbService) {
		super(dbService);
	}
	
	@Override
	protected Class<CDKeyEntity> getEntityClass() {
		return CDKeyEntity.class;
	}
	
	public void saveOrUpdate(CDKeyEntity entity) {
		dbService.saveOrUpdate(entity);
	}
	
	/**
	 * 查询玩家的所有环任务
	 * 
	 * @return
	 */
//	@SuppressWarnings("unchecked")
//	public CDKeyEntity loadCDKeyEntityByUUID(String id) {
//		List<CDKeyEntity> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_CDKEY_BY_ID, 
//				new String[]{ "id" } , new Object[]{ id });
//
//		if (_queryList.size() > 0) {
//			return (CDKeyEntity) _queryList.get(0);
//		}
//		return null;
//	}
	
	@SuppressWarnings("unchecked")
	public CDKeyEntity getCDKey(final String cdkey) {
		List<CDKeyEntity> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_CDKEY_BY_ID, 
				new String[]{ "id" } , new Object[]{ cdkey });
		if (_queryList.size() > 0) {
			return (CDKeyEntity) _queryList.get(0);
		}
		return null;
	}
	/**
	 * 检查角色是否领取过同套餐同礼包的cdkey
	 * @param charId
	 * @param cdkeyPlansId
	 * @param giftId
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public boolean isTakenTheSamePlansAndGift(final long charId, final int cdkeyPlansId, final int giftId) {
		List<CDKeyEntity> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_CDKEY_CHAR_IS_TAKEN_THE_SAME_PLANS_AND_GIFT, 
				new String[]{ "charId", "plansId", "giftId" } , new Object[]{ charId, cdkeyPlansId, giftId });
		if (_queryList.size() > 0) {
			return true;
		}
		return false;
	}
//	@SuppressWarnings("unchecked")
//	public List<CDKeyEntity> loadAllCDKeyEntity() {
//		return (List<CDKeyEntity>)dbService.findByNamedQuery(QUERY_CDKEY_ALL);
//	}

//	@SuppressWarnings("unchecked")
//	public List<CDKeyEntity> loadCDKeyEntityByGroupId(int groupId) {
//		List<CDKeyEntity> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_CDKEY_BY_GROUP_ID, 
//				new String[]{ "groupId" } , new Object[]{ groupId });
//
//		return  _queryList;
//	}
}
