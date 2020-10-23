package com.imop.lj.gm.dao;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.transform.Transformers;

import com.imop.lj.db.model.CorpsEntity;
import com.imop.lj.gm.dao.log.LogTypeUtils;

/**
 * 军团信息DAO
 * 
 * @author xiaowei.liu
 * 
 */
public class CorpsInfoDAO extends GenericDAO {
	@SuppressWarnings("unchecked")
	public List<CorpsEntity> searchCorpsInfo(final String type,	final String searchValue) {
		return (List<CorpsEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from t_corps where 1=1");
						if (StringUtils.isNotBlank(searchValue)	&& "corpsid".equals(type)) {
							sql.append(" and id = :id");
						}
						if (StringUtils.isNotBlank(searchValue)	&& "corpsname".equals(type)) {
							sql.append(" and name = :name");
						}
						
						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(searchValue)&& "corpsid".equals(type)) {
							query.setString("id", searchValue);
						}
						if (StringUtils.isNotBlank(searchValue)	&& "corpsname".equals(type)) {
							query.setString("name", searchValue);
						}
						LogTypeUtils.addQueryScalar(query, CorpsEntity.class);
						query.setResultTransformer(Transformers.aliasToBean(CorpsEntity.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
