package com.imop.lj.gm.dao.notice;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.db.model.DirtyWordsTypeEntity;
import com.imop.lj.gm.dao.GenericDAO;

public class DirtyWorldsTypeDAO extends GenericDAO {
	/**
	 * 查询跨服赛数据
	 * 
	 * @return 定时公告列表
	 */
	@SuppressWarnings("unchecked")
	public List<DirtyWordsTypeEntity> getDirtyWorldsTypeEntityList() {
		return (List<DirtyWordsTypeEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session
								.getNamedQuery("getDirtyWorldsList");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
