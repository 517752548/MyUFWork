package com.imop.lj.db.dao;

import java.util.ArrayList;
import java.util.List;

import com.imop.lj.core.orm.DBService;
import com.imop.lj.db.model.CorpsMemberEntity;

/**
 * 军团成员DAO
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsMemberDao extends BaseDao<CorpsMemberEntity> {
	/**加载成员查询语句名称*/
	public static final String QUERY_MEMBERS_BY_CORPS_ID = "queryMembersByCorpsId";
	/**查询参数*/
	public static final String[] CORPSID_PARAMS = new String[]{"corpsId"};
	
	public CorpsMemberDao(DBService dbService) {
		super(dbService);
	}

	@Override
	protected Class<CorpsMemberEntity> getEntityClass() {
		return CorpsMemberEntity.class;
	}

	/**
	 * 根据军团ID加载所有军团成员
	 * 
	 * @param corpsId
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<CorpsMemberEntity> loadAllCorpsMemberByCorpsId(long corpsId) {
		List<Object> _queryList = dbService.findByNamedQueryAndNamedParam(QUERY_MEMBERS_BY_CORPS_ID, CORPSID_PARAMS , new Object[]{ corpsId });
		List<CorpsMemberEntity> memberList = new ArrayList<CorpsMemberEntity>();
		for (Object obj : _queryList) {
			CorpsMemberEntity member = (CorpsMemberEntity) obj;
			memberList.add(member);
		}
		return memberList; 
	}

}
