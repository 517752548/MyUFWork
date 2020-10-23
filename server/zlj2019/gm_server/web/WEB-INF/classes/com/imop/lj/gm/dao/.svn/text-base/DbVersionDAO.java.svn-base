package com.imop.lj.gm.dao;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.db.model.DbVersion;

public class DbVersionDAO extends GenericDAO {
	/**
	 * 服务器版本
	 *
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public List<DbVersion> getDbVersionList() throws Exception {
		return (List<DbVersion>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session.getNamedQuery("getAllDbVersionList");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
