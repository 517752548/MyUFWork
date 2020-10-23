/**
 *
 */
package com.imop.lj.gm.dao.notice;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.notice.GameNotice;

/**
 * 游戏公告 DAO
 *
 * @author linfan
 *
 */
public class GameNoticeDAO extends GenericDAO {

	/**
	 * 查询所有的游戏公告
	 *
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<GameNotice> getGameNoticeList() {
		return (List<GameNotice>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session
								.getNamedQuery("getGameNoticeList");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}


}
