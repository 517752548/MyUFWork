package com.imop.lj.gm.dao.check;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GenericDAO;

/**
 * 自检报告DAO
 *
 * @author lin fan
 *
 */
public class NewSvrCheckDAO extends GenericDAO {

	/**
	 * 得到玩家角色总数
	 *
	 * @return 角色总数
	 */
	public String getAutoIncrement() {
		return (String) getTemplate().doCall(new HibernateCallback<String>() {
			@Override
			public String doCall(Session session) {
				String sql = "select count(*) from t_character_info";
				Query query = session.createSQLQuery(sql);
				Object r = query.uniqueResult();
				if (r != null) {
					return r.toString();
				}
				return "0";
			}
		});
	}

	/**
	 * 得到数据库版本号
	 *
	 * @return 数据库版本号
	 */
	public String getDBVersion() {
		return (String) getTemplate().doCall(new HibernateCallback<String>() {
			@Override
			public String doCall(Session session) {
				Query query = session.getNamedQuery("getDBVersion");
				return (String) query.uniqueResult();
			}
		});
	}

	/**
	 * 得到定时公告数量
	 *
	 * @param id
	 * @return 定时公告数量
	 */
	public long getTimeNoticeNum() {
		return (long) getTemplate().doCall(new HibernateCallback<Long>() {
			@Override
			public Long doCall(Session session) {
				Query query = session.getNamedQuery("getTimeNoticeNum");
				return (Long) query.uniqueResult();
			}
		});
	}

	/**
	 * 得到游戏公告数量
	 *
	 * @param id
	 * @return 游戏公告数量
	 */
	public long getGameNoticeNum() {
		return (long) getTemplate().doCall(new HibernateCallback<Long>() {
			@Override
			public Long doCall(Session session) {
				Query query = session.getNamedQuery("getGameNoticeNum");
				return (Long) query.uniqueResult();
			}
		});
	}

	/**
	 * 得到发奖礼包数量
	 *
	 * @param id
	 * @return 得到发奖礼包数量
	 */
	public long getPrizeNum() {
		return (long) getTemplate().doCall(new HibernateCallback<Long>() {
			@Override
			public Long doCall(Session session) {
				Query query = session.getNamedQuery("getPrizeNum");
				return (Long) query.uniqueResult();
			}
		});
	}

	/**
	 * 得到活动数量
	 *
	 * @param id
	 * @return 得到活动数量
	 */
	public long getActNum() {
		return (long) getTemplate().doCall(new HibernateCallback<Long>() {
			@Override
			public Long doCall(Session session) {
				Query query = session.getNamedQuery("getActNum");
				return (Long) query.uniqueResult();
			}
		});
	}

}
