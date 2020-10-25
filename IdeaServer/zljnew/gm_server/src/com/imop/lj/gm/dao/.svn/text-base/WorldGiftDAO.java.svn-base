package com.imop.lj.gm.dao;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.db.model.WorldGiftEntity;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午12:14:18
 * @version 1.0
 */

public class WorldGiftDAO extends GenericDAO {

	/**
	 * 根据giftId查询worldGift
	 *
	 * @param giftId
	 *            礼包ID
	 * @return Prize 实体
	 */
	public WorldGiftEntity getWorldGiftById(final String giftId) {
		return (WorldGiftEntity) getTemplate().doCall(new HibernateCallback<WorldGiftEntity>() {
			@Override
			public WorldGiftEntity doCall(Session session) {
				Query query = session.getNamedQuery("queryWorldGiftByGiftId");
				query.setInteger("giftId", Integer.parseInt(giftId));
				return (WorldGiftEntity) query.uniqueResult();
			}
		});
	}
	
	public List<WorldGiftEntity> getAllWorldGift() {
		return (List<WorldGiftEntity>) getTemplate().doCall(new HibernateCallback<List<WorldGiftEntity>>() {
			@SuppressWarnings("unchecked")
			public List<WorldGiftEntity> doCall(Session session) {
				Query query = session.getNamedQuery("getWorldGift");
				getPagerUtil().process(session, query);
				return query.list();
			}
		});
	}
}
