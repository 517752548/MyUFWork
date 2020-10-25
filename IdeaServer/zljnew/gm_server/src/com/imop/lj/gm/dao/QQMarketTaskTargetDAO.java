package com.imop.lj.gm.dao;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.db.model.QQMarketTaskTargetEntity;
import com.imop.lj.gm.dao.GenericDAO;

public class QQMarketTaskTargetDAO extends GenericDAO {
	/**
	 * 查询跨服赛数据
	 * 
	 * @return 定时公告列表
	 */
	@SuppressWarnings("unchecked")
	public List<QQMarketTaskTargetEntity> getCardActivityEntityList() {
		return (List<QQMarketTaskTargetEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session
								.getNamedQuery("getQQMarketTaskTargetEntity");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
