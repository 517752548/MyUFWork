package com.imop.lj.db.dao;

import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.UserPrize;

/**
 * GM补偿本地数据访问类
 * 
 */
public class UserPrizeDao extends BaseDao<UserPrize> {

	private static final String QUERY_USER_PRIZE_NAME_LIST_BY_CHARID = "queryUserPrizeNameListByCharId";
	
	private static final String GET_USER_PRIZE_BY_PRIZEID = "queryUserPrizeByPrizeId";
	
	private static final String[] GET_USER_PRIZE_NAMELIST_BY_CHARID_PARAM = new String[] { "charId" };
	
	private static final String[] GET_USER_PRIZE_BY_PRIZEID_PARAM = new String[] { "charId", "prizeId" };
	
	private static final String UPDATE_USER_PRIZE_STATUS = "updateUserPrizeStatus";
	
	private static final String[] UPDATE_USER_PRIZE_STATUS_PARAM = new String[] { "prizeId" };

	public UserPrizeDao(DBService dbServcie) {
		super(dbServcie);
	}

	/**
	 * 查询玩家的补偿奖励列表，只取prizeId,名称，奖励类型
	 * 
	 * @param passportId
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<UserPrize> getUserPrizeNameListByCharId(long charId) {
		List<UserPrize> _prizeList = this.dbService.findByNamedQueryAndNamedParam(QUERY_USER_PRIZE_NAME_LIST_BY_CHARID, GET_USER_PRIZE_NAMELIST_BY_CHARID_PARAM,
				new Object[] {charId });
		return _prizeList;
	}

	/**
	 * 查询玩家的补偿奖励列表
	 * 
	 * @param passportId
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public UserPrize getUserPrizeByPrizeId(long charId, int prizeId) {
				List<UserPrize> _ids = this.dbService.findByNamedQueryAndNamedParam(
				GET_USER_PRIZE_BY_PRIZEID, GET_USER_PRIZE_BY_PRIZEID_PARAM,
				new Object[] { charId, prizeId });
		if (_ids == null || _ids.size() == 0) {
			return null;
		}
		
		return _ids.get(0);
	}

	/**
	 * 
	 * 
	 * @param prizeId
	 * @return
	 */
	public boolean updateUserPrizeStatus(int prizeId) {
		return this.dbService.queryForUpdate(UPDATE_USER_PRIZE_STATUS, UPDATE_USER_PRIZE_STATUS_PARAM, new Object[] { prizeId }) == 1;
	}

	@Override
	protected Class<UserPrize> getEntityClass() {
		return UserPrize.class;
	}

}