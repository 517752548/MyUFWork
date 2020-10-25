package com.imop.lj.gm.dao.notice;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.db.model.GoodActivityEntity;
import com.imop.lj.gm.dao.GenericDAO;

public class MobileActivityDAO extends GenericDAO {
	/**
	 * 查询跨服赛数据
	 * 
	 * @return 定时公告列表
	 */
	@SuppressWarnings("unchecked")
	public List<GoodActivityEntity> getMobileActivityEntityList() {
		return (List<GoodActivityEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session
								.getNamedQuery("getMobileActivityEntityList");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
