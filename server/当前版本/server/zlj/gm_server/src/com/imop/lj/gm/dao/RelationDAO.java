package com.imop.lj.gm.dao;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.Query;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.transform.Transformers;

import com.imop.lj.db.model.RelationEntity;
import com.imop.lj.gm.dao.log.LogTypeUtils;
import com.imop.lj.gm.utils.StringUtil;

public class RelationDAO extends GenericDAO {
	/**
	 * 关系
	 *
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public List<RelationEntity> getRelationList() throws Exception {
		return (List<RelationEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session.getNamedQuery("getAllRelationEntityList");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
	/**
	 * 关系
	 *
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public List<RelationEntity> getRelationListSerch(final String type,
			final String searchValue, final String startLevel, final String endLevel) throws Exception {
		return (List<RelationEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from t_relation_info where 1=1");
						if (StringUtils.isNotBlank(searchValue)
								&& "roleId".equals(type)) {
							sql.append(" and charId = :roleId");
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "userName".equals(type)) {
							sql.append(" and targetCharName like :name");
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "userId".equals(type)) {
							sql.append(" and targetCharId = :accountId");
						}

						if (StringUtils.isNotBlank(startLevel)) {
							sql.append(" and friendship >= :startLevel");
						}
						if (StringUtils.isNotBlank(endLevel)) {
							sql.append(" and friendship <= :endLevel");
						}

						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(searchValue)
								&& "roleId".equals(type)) {
							query.setLong("roleId", StringUtil.parseStringTOLong(searchValue));
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "userName".equals(type)) {
							query.setString("name", "%" + searchValue + "%");
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "userId".equals(type)) {
							query.setLong("accountId",  StringUtil.parseStringTOLong(searchValue));
						}

						if (StringUtils.isNotBlank(startLevel)) {
							query.setInteger("startLevel", StringUtil.parseStringTOInt(startLevel));
						}
						if (StringUtils.isNotBlank(endLevel)) {
							query.setInteger("endLevel",  StringUtil.parseStringTOInt(endLevel));
						}

						LogTypeUtils.addQueryScalar(query, RelationEntity.class);
						query.setResultTransformer(Transformers
								.aliasToBean(RelationEntity.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
