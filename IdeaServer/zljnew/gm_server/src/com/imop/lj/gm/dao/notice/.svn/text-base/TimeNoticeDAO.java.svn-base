/**
 *
 */
package com.imop.lj.gm.dao.notice;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.notice.TimeNotice;

/**
 * 定时公告 DAO
 *
 * @author linfan
 *
 */
public class TimeNoticeDAO extends GenericDAO {

	/**
	 * 查询所有的定时公告
	 *
	 * @return 定时公告列表
	 */
	@SuppressWarnings("unchecked")
	public List<TimeNotice> getTimeNoticeList(final String type) {
		return (List<TimeNotice>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session
								.getNamedQuery("getTimeNoticeList");
						query.setString("type", type);
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
