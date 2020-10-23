package com.imop.lj.gm.dao;

import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.List;

import org.hibernate.Session;

/**
 * 统计DAO
 * 
 * @author xiaowei.liu
 * 
 */
public class StatisticsDAO extends ParamGenericDAO {
	/**
	 * 获取帐号表数量
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<BigInteger> getCountFromUser() {
		return (List<BigInteger>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						String hql = "select count(1) from t_user_info";
						return (List)session.createSQLQuery(hql).list();
					}

				});
	}
	
	/**
	 * 获取角色表数量
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<BigInteger> getCountFromCharacter() {
		return (List<BigInteger>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						String hql = "select count(1) from t_character_info";
						return (List)session.createSQLQuery(hql).list();
					}

				});
	}
	
	/**
	 * 获取充值人数
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<BigInteger> getRoleNumForCharge() {
		return (List<BigInteger>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						String hql = "select count(1) from t_character_info where totalCharge > 0";
						return (List)session.createSQLQuery(hql).list();
					}

				});
	}
	
	/**
	 * 获取总充值
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<BigDecimal> getSumCharge() {
		return (List<BigDecimal>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						String hql = "select sum(totalCharge) from t_character_info where totalCharge > 0";
						return (List)session.createSQLQuery(hql).list();
					}

				});
	}
	
	/**
	 * 获取今日总充值
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<BigDecimal> getTodaySumCharge(final String todayTime) {
		return (List<BigDecimal>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						String hql = "select sum(todayCharge) from t_character_info where todayCharge > 0 and lastChargeTime >= '" + todayTime + "'";
						return (List)session.createSQLQuery(hql).list();
					}

				});
	}
	
	/**
	 * 获取本周总充值
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<BigDecimal> getWeekSumCharge(final String weekTime) {
		return (List<BigDecimal>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						String hql = "select sum(weekCharge) from t_character_info where weekCharge > 0 and lastChargeTime >= '" + weekTime + "'";
						return (List)session.createSQLQuery(hql).list();
					}

				});
	}
	
	/**
	 * 获取本月总充值
	 * 
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<BigDecimal> getMonthSumCharge(final String monthTime) {
		return (List<BigDecimal>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						String hql = "select sum(monthCharge) from t_character_info where monthCharge > 0 and lastChargeTime >= '" + monthTime + "'";
						return (List)session.createSQLQuery(hql).list();
					}

				});
	}
}