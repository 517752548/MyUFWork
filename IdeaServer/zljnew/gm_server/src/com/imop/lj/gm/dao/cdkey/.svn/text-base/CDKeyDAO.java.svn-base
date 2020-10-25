package com.imop.lj.gm.dao.cdkey;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.db.model.CDKeyEntity;
import com.imop.lj.gm.dao.GenericDAO;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月17日 下午3:21:07
 * @version 1.0
 */

public class CDKeyDAO extends GenericDAO {
	
	@SuppressWarnings("unchecked")
	public List<CDKeyEntity> getAllCDKeyEntity() {
		return (List<CDKeyEntity>) getTemplate().doCall(
				new HibernateCallback<List<CDKeyEntity>>() {
					@Override
					public List<CDKeyEntity> doCall(Session session) {
						Query query = session.getNamedQuery("getAllCDKeyList");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
	/**
	 * 活动名称查询cdkey
	 */
	@SuppressWarnings("unchecked")
	public List<CDKeyEntity> getCDKeyEntityListByActivityName(final String cdkeyId) {
		return (List<CDKeyEntity>) getTemplate().doCall(
				new HibernateCallback<List<CDKeyEntity>>() {
					@Override
					public List<CDKeyEntity> doCall(Session session) {
						Query query = session
								.getNamedQuery("getCDKeyListByCDKeyId");
						query.setString("id", cdkeyId);
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
	/**
	 * 活动名称查询cdkey
	 */
	@SuppressWarnings("unchecked")
	public List<CDKeyEntity> getCDKeyEntitiesByCDKeyIdOrCreateTime(final String cdkeyId, final long createTime) {
		return (List<CDKeyEntity>) getTemplate().doCall(
				new HibernateCallback<List<CDKeyEntity>>() {
					@Override
					public List<CDKeyEntity> doCall(Session session) {
						Query query = session
								.getNamedQuery("getCDKeyListByCDKeyIdOrCreateTime");
						query.setString("id", cdkeyId);
						query.setLong("createTime", createTime);
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
	
	/**
	 * openId 查询
	 */
	@SuppressWarnings("unchecked")
	public List<CDKeyEntity> getCDKeyEntityListByOpenId(final String openId) {
		return (List<CDKeyEntity>) getTemplate().doCall(
				new HibernateCallback<List<?>>() {
					@Override
					public List<?> doCall(Session session) {
						Query query = session
								.getNamedQuery("getCDKeyEntityListByOpenId");
						query.setString("openId", openId);
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
	
	/**
	 * plansId giftId gropuId 查询
	 */
	@SuppressWarnings("unchecked")
	public List<CDKeyEntity> getListByPlansIdGiftIdAndGroupId(final int plansId, final int giftId, final int groupId) {
		return (List<CDKeyEntity>) getTemplate().doCall(
				new HibernateCallback<List<?>>() {
					@Override
					public List<?> doCall(Session session) {
						Query query = session
								.getNamedQuery("getCDKeyEntityListByGroupId");
						query.setInteger("groupId", groupId);
						query.setInteger("plansId", plansId);
						query.setInteger("giftId", giftId);
						return query.list();
					}
				});
	}
	
	/**
	 * 查询最大groupId
	 */
	public int getMaxGroupId(final int plansId, final int giftId) {
		return (int) getTemplate().doCall(
				new HibernateCallback<Integer>() {
					@Override
					public Integer doCall(Session session) {
						Query query = session.getNamedQuery("getMaxGroupId");
						query.setInteger("plansId", plansId);
						query.setInteger("giftId", giftId);
						if(null != query.list() && null != query.list().get(0)){
							return (Integer)query.list().get(0);
						}
						return 0;
					}
				});
	}
	/**
	 * 查询显示无重复的记录
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<CDKeyEntity> getAllCDKeyEntityNoEcho() {
		return (List<CDKeyEntity>) getTemplate().doCall(
				new HibernateCallback<List<CDKeyEntity>>() {
					@Override
					public List<CDKeyEntity> doCall(Session session) {
						Query query = session.getNamedQuery("getAllCDKeyListNoEcho");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
	
	public Integer delCDKey(final int plansId, final int giftId, final int groupId) {
		return (Integer) getTemplate().doCall(new HibernateCallback<Integer>() {
			@Override
			public Integer doCall(Session session) {
				Query query = session.getNamedQuery("delCDKey");
				query.setInteger("plansId", plansId);
				query.setInteger("giftId", giftId);
				query.setInteger("groupId", groupId);
				return query.executeUpdate();
			}
		});
	}
}
