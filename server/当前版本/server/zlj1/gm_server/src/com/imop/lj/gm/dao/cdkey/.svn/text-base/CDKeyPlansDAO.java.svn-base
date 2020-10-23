package com.imop.lj.gm.dao.cdkey;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.db.model.CDKeyPlansEntity;
import com.imop.lj.gm.dao.GenericDAO;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月27日 下午6:34:35
 * @version 1.0
 */

public class CDKeyPlansDAO extends GenericDAO {

	/**
	 * 根据giftId查询worldGift
	 *
	 * @param giftId
	 *            礼包ID
	 * @return Prize 实体
	 */
	public CDKeyPlansEntity getCDKeyPlansByPlansId(final String plansId) {
		return (CDKeyPlansEntity) getTemplate().doCall(new HibernateCallback<CDKeyPlansEntity>() {
			@Override
			public CDKeyPlansEntity doCall(Session session) {
				Query query = session.getNamedQuery("queryCDKeyPlansByPlansId");
				query.setInteger("plansId", Integer.parseInt(plansId));
				return (CDKeyPlansEntity) query.uniqueResult();
			}
		});
	}
	
	public List<CDKeyPlansEntity> getAllCDKeyPlans() {
		return (List<CDKeyPlansEntity>) getTemplate().doCall(new HibernateCallback<List<CDKeyPlansEntity>>() {
			@SuppressWarnings("unchecked")
			public List<CDKeyPlansEntity> doCall(Session session) {
				Query query = session.getNamedQuery("getCDKeyPlans");
				getPagerUtil().process(session, query);
				return query.list();
			}
		});
	}
	
	public List<CDKeyPlansEntity> getByPlansNameOrDate(final String plansName, final long createDateStart, final long createTimeEnd) {
		return (List<CDKeyPlansEntity>) getTemplate().doCall(new HibernateCallback<List<CDKeyPlansEntity>>() {
			@SuppressWarnings("unchecked")
			public List<CDKeyPlansEntity> doCall(Session session) {
				Query query = session.getNamedQuery("getByPlansNameOrCreateTime");
				query.setString("plansName", plansName);
				query.setLong("createTimeStart", createDateStart);
				query.setLong("createTimeEnd", createTimeEnd);
				return query.list();
			}
		});
	}
	
	public List<CDKeyPlansEntity> getByPlansName(final String plansName) {
		return (List<CDKeyPlansEntity>) getTemplate().doCall(new HibernateCallback<List<CDKeyPlansEntity>>() {
			@SuppressWarnings("unchecked")
			public List<CDKeyPlansEntity> doCall(Session session) {
				Query query = session.getNamedQuery("getByPlansName");
				query.setString("plansName", plansName);
				return query.list();
			}
		});
	}
}
