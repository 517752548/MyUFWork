package com.imop.lj.gm.dao;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.db.model.PrizeInfo;

public class PrizeInfoDAO extends GenericDAO {
	/**
	 * 奖励
	 *
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public List<PrizeInfo> getPrizeInfoList() throws Exception {
		return (List<PrizeInfo>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session.getNamedQuery("getPrizeList");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
