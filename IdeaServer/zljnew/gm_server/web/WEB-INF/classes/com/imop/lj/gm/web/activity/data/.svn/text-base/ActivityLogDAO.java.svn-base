package com.imop.lj.gm.web.activity.data;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.constants.GMLogConstants;
import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.ParamGenericDAO;
import com.imop.lj.gm.dao.log.LogTypeUtils;
import com.imop.lj.gm.model.log.ChargeLog;
import com.imop.lj.gm.model.log.CommerceLog;
import com.imop.lj.gm.model.log.CompanyUpgradeLog;
import com.imop.lj.gm.model.log.EmployeeLog;
import com.imop.lj.gm.model.log.MoneyLog;
import com.imop.lj.gm.model.log.PlayerLoginLog;
import com.imop.lj.gm.model.log.SecretaryLog;
import com.imop.lj.gm.model.log.WashDiamondLog;

public class ActivityLogDAO extends ParamGenericDAO {
	/**
	 * 根据以下条件查询LOG记录
	 * @param roleID
	 * 			角色ID
	 * @param date
	 * 			该日志的时间后缀
	 * @param begin_time
	 * 			开始时间
	 * @param end_time
	 * 			结束时间
	 * @param reason
	 * 			原因
	 * @param logType
	 * 			日志类型
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List getLogList(final String roleID, final String date,
			final long begin_time, final long end_time, final String reason,
			final String logType) {
		return getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List doCall(Session session) {
				StringBuffer sql = new StringBuffer();
				sql.append("select * from " + logType + "_" + date
						+ " where 1=1");
				sql.append(StringUtils.isBlank(roleID) ? ""
						: " and char_id = :charId");
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					sql.append(" and reason = :reason");
				}
				if (begin_time != -1) {
					sql.append(" and  log_time >= :startTime");
				}
				if (end_time != -1) {
					sql.append(" and  log_time <= :endTime");
				}
				SQLQuery query = session.createSQLQuery(sql.toString());
				if (StringUtils.isNotBlank(roleID)) {
					query.setString("charId", roleID.trim());
				}
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					query.setString("reason", reason.trim());
				}
				if (begin_time != -1) {
					query.setLong("startTime", begin_time);
				}
				if (end_time != -1) {
					query.setLong("endTime", end_time);
				}
				LogTypeUtils.addLogQueryScalar(query, GMLogConstants
						.getClassByLogName(logType));
				query
						.setResultTransformer(GMTransformers
								.aliasToBean(GMLogConstants
										.getClassByLogName(logType)));
				return query.list();
			}
		});
	}
	
	/**
	 * 根据以下条件查询LOG记录
	 * @param roleID
	 * 			角色ID
	 * @param date
	 * 			该日志的时间后缀
	 * @param begin_time
	 * 			开始时间
	 * @param end_time
	 * 			结束时间
	 * @param reason
	 * 			原因
	 * @param logType
	 * 			日志类型
	 * 充值活动
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<ChargeLog> getLogListCharge(final String roleID, final String date,
			final long begin_time, final long end_time, final String reason,
			final String logType) {
		return getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List<ChargeLog> doCall(Session session) {
				
				StringBuffer sql = new StringBuffer();
				sql.append("select * from " + logType + "_" + date
						+ " where 1=1");
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					sql.append(" and reason = :reason");
				}
				if (begin_time != -1) {
					sql.append(" and  log_time >= :startTime");
				}
				if (end_time != -1) {
					sql.append(" and  log_time <= :endTime");
				}
				SQLQuery query = session.createSQLQuery(sql.toString());
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					query.setString("reason", reason.trim());
				}
				if (begin_time != -1) {
					query.setLong("startTime", begin_time);
				}
				if (end_time != -1) {
					query.setLong("endTime", end_time);
				}
				
				LogTypeUtils.addLogQueryScalar(query, GMLogConstants
						.getClassByLogName(logType));
				query
						.setResultTransformer(GMTransformers
								.aliasToBean(GMLogConstants
										.getClassByLogName(logType)));
				return query.list();
			}
		});
	}
	 
	/***
	 * 登陆活动
	 * @param roleID
	 * @param date
	 * @param begin_time
	 * @param end_time
	 * @param reason
	 * @param logType
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<PlayerLoginLog> getLogListLogin(final String date,
			final long begin_time, final long end_time, final String reason,
			final String logType) {
		return getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List<PlayerLoginLog> doCall(Session session) {
				
				StringBuffer sql = new StringBuffer();
				sql.append("select * from " + logType + "_" + date
						+ " where 1=1");
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					sql.append(" and reason = :reason");
				}
				if (begin_time != -1) {
					sql.append(" and  log_time >= :startTime");
				}
				if (end_time != -1) {
					sql.append(" and  log_time <= :endTime");
				}
				//根据char_id 排重
				sql.append(" group by char_id having count(char_id) >= 1");
				//select * from player_login_log_2013_06_28 where 1=1 and log_time >= 1372409220373  and  log_time <= 1372509220373 group by char_id having count(char_id) >= 1;
				SQLQuery query = session.createSQLQuery(sql.toString());
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					query.setString("reason", reason.trim());
				}
				if (begin_time != -1) {
					query.setLong("startTime", begin_time);
				}
				if (end_time != -1) {
					query.setLong("endTime", end_time);
				}
				
				LogTypeUtils.addLogQueryScalar(query, GMLogConstants
						.getClassByLogName(logType));
				query
						.setResultTransformer(GMTransformers
								.aliasToBean(GMLogConstants
										.getClassByLogName(logType)));
				return query.list();
			}
		});
	}
	
	/***
	 * 商会是我家活动
	 * @param roleID
	 * @param date
	 * @param begin_time
	 * @param end_time
	 * @param reason
	 * @param logType
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<CommerceLog> getLogCommerceLog(final String date,
			final long begin_time, final long end_time, final String reason,
			final String logType,final int level) {
		return getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List<CommerceLog> doCall(Session session) {
				
				StringBuffer sql = new StringBuffer();
				sql.append("select * from " + logType + "_" + date
						+ " where 1=1");
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					sql.append(" and reason = :reason");
				}
				if (begin_time != -1) {
					sql.append(" and  log_time >= :startTime");
				}
				if (end_time != -1) {
					sql.append(" and  log_time <= :endTime");
				}
				//商会等级等于发奖阶段
				sql.append(" and commerce_level="+level);
				SQLQuery query = session.createSQLQuery(sql.toString());
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					query.setString("reason", reason.trim());
				}
				if (begin_time != -1) {
					query.setLong("startTime", begin_time);
				}
				if (end_time != -1) {
					query.setLong("endTime", end_time);
				}
				
				LogTypeUtils.addLogQueryScalar(query, GMLogConstants
						.getClassByLogName(logType));
				query
						.setResultTransformer(GMTransformers
								.aliasToBean(GMLogConstants
										.getClassByLogName(logType)));
				return query.list();
			}
		});
	}
	
	/***
	 * 商会是我家活动
	 * @param roleID
	 * @param date
	 * @param begin_time
	 * @param end_time
	 * @param reason
	 * @param logType
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<CompanyUpgradeLog> getLogCompanyUpdateLog(final String date,
			final long begin_time, final long end_time, final String reason,
			final String logType,final String level) {
		return getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List<CompanyUpgradeLog> doCall(Session session) {
				
				StringBuffer sql = new StringBuffer();
				sql.append("select * from " + logType + "_" + date
						+ " where 1=1");
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					sql.append(" and reason = :reason");
				}
				if (begin_time != -1) {
					sql.append(" and  log_time >= :startTime");
				}
				if (end_time != -1) {
					sql.append(" and  log_time <= :endTime");
				}
				//商会等级等于发奖阶段
				sql.append(" and to_level in("+level+")");
				SQLQuery query = session.createSQLQuery(sql.toString());
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					query.setString("reason", reason.trim());
				}
				if (begin_time != -1) {
					query.setLong("startTime", begin_time);
				}
				if (end_time != -1) {
					query.setLong("endTime", end_time);
				}
				
				LogTypeUtils.addLogQueryScalar(query, GMLogConstants
						.getClassByLogName(logType));
				query
						.setResultTransformer(GMTransformers
								.aliasToBean(GMLogConstants
										.getClassByLogName(logType)));
				return query.list();
			}
		});
	}
	
	/**
	 * 双倍送商会任务活动
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<MoneyLog> getLogListGiveDoubleCommerceQuest(final String roleID, final String date,
			final long begin_time, final long end_time, final String reason,
			final String logType) {
		return getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List<MoneyLog> doCall(Session session) {
				
				StringBuffer sql = new StringBuffer();
				sql.append("select * from " + logType + "_" + date
						+ " where 1=1");
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					sql.append(" and reason = :reason");
				}
				if (begin_time != -1) {
					sql.append(" and  log_time >= :startTime");
				}
				if (end_time != -1) {
					sql.append(" and  log_time <= :endTime");
				}
				SQLQuery query = session.createSQLQuery(sql.toString());
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					query.setString("reason", reason.trim());
				}
				if (begin_time != -1) {
					query.setLong("startTime", begin_time);
				}
				if (end_time != -1) {
					query.setLong("endTime", end_time);
				}
				
				LogTypeUtils.addLogQueryScalar(query, GMLogConstants
						.getClassByLogName(logType));
				query
						.setResultTransformer(GMTransformers
								.aliasToBean(GMLogConstants
										.getClassByLogName(logType)));
				return query.list();
			}
		});
	}
	
	/***
	 * 招募员工
	 * @param roleID
	 * @param date
	 * @param begin_time
	 * @param end_time
	 * @param reason
	 * @param logType
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<EmployeeLog> getLogEmployeeLog(final String date,
			final long begin_time, final long end_time, final String reason,
			final String logType) {
		return getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List<EmployeeLog> doCall(Session session) {
				
				StringBuffer sql = new StringBuffer();
				sql.append("select * from " + logType + "_" + date
						+ " where 1=1");
				if (begin_time != -1) {
					sql.append(" and  log_time >= :startTime");
				}
				if (end_time != -1) {
					sql.append(" and  log_time <= :endTime");
				}
				//商会等级等于发奖阶段
				sql.append(" and reason in("+reason+")");
				SQLQuery query = session.createSQLQuery(sql.toString());
				if (begin_time != -1) {
					query.setLong("startTime", begin_time);
				}
				if (end_time != -1) {
					query.setLong("endTime", end_time);
				}
				
				LogTypeUtils.addLogQueryScalar(query, GMLogConstants
						.getClassByLogName(logType));
				query
						.setResultTransformer(GMTransformers
								.aliasToBean(GMLogConstants
										.getClassByLogName(logType)));
				return query.list();
			}
		});
	}
	
	/***
	 * 招募员工
	 * @param roleID
	 * @param date
	 * @param begin_time
	 * @param end_time
	 * @param reason
	 * @param logType
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<SecretaryLog> getLogSecteryLog(final String date,
			final long begin_time, final long end_time, final String reason,
			final String logType) {
		return getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List<SecretaryLog> doCall(Session session) {
				
				StringBuffer sql = new StringBuffer();
				sql.append("select * from " + logType + "_" + date
						+ " where 1=1");
				if (begin_time != -1) {
					sql.append(" and  log_time >= :startTime");
				}
				if (end_time != -1) {
					sql.append(" and  log_time <= :endTime");
				}
				//商会等级等于发奖阶段
				sql.append(" and reason in("+reason+")");				
				SQLQuery query = session.createSQLQuery(sql.toString());
				if (begin_time != -1) {
					query.setLong("startTime", begin_time);
				}
				if (end_time != -1) {
					query.setLong("endTime", end_time);
				}
				
				LogTypeUtils.addLogQueryScalar(query, GMLogConstants
						.getClassByLogName(logType));
				query
						.setResultTransformer(GMTransformers
								.aliasToBean(GMLogConstants
										.getClassByLogName(logType)));
				return query.list();
			}
		});
	}
	
//	/**
//	 * 珠宝洗练  洗一送一
//	 * @return
//	 */
//	@SuppressWarnings("unchecked")
//	public List<MoneyLog> getLogWashDiamond(final String date,
//			final long begin_time, final long end_time, final String reason,
//			final String logType) {
//		return getTemplate().doCall(new HibernateCallback<List>() {
//			@Override
//			public List<MoneyLog> doCall(Session session) {
//				
//				StringBuffer sql = new StringBuffer();
//				sql.append("select * from " + logType + "_" + date
//						+ " where 1=1");
//				if (begin_time != -1) {
//					sql.append(" and  log_time >= :startTime");
//				}
//				if (end_time != -1) {
//					sql.append(" and  log_time <= :endTime");
//				}
//				
//				sql.append(" and reason in("+reason+")");
//				sql.append(" and main_currency in("+1+","+8+")");
//				SQLQuery query = session.createSQLQuery(sql.toString());
//	
//				if (begin_time != -1) {
//					query.setLong("startTime", begin_time);
//				}
//				if (end_time != -1) {
//					query.setLong("endTime", end_time);
//				}
//				
//				LogTypeUtils.addLogQueryScalar(query, GMLogConstants
//						.getClassByLogName(logType));
//				query
//						.setResultTransformer(GMTransformers
//								.aliasToBean(GMLogConstants
//										.getClassByLogName(logType)));
//				return query.list();
//			}
//		});
//	}
	
	/**
	 * 珠宝洗练  洗一送一
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<WashDiamondLog> getLogWashDiamond(final String date,
			final long begin_time, final long end_time, final String reason,
			final String logType) {
		return getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List<WashDiamondLog> doCall(Session session) {
				
				StringBuffer sql = new StringBuffer();
				sql.append("select * from " + logType + "_" + date
						+ " where 1=1");
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					sql.append(" and reason = :reason");
				}
				if (begin_time != -1) {
					sql.append(" and  log_time >= :startTime");
				}
				if (end_time != -1) {
					sql.append(" and  log_time <= :endTime");
				}
				
				SQLQuery query = session.createSQLQuery(sql.toString());
				if (StringUtils.isNotBlank(reason) && !"-1".equals(reason)) {
					query.setString("reason", reason.trim());
				}
				if (begin_time != -1) {
					query.setLong("startTime", begin_time);
				}
				if (end_time != -1) {
					query.setLong("endTime", end_time);
				}
				
				LogTypeUtils.addLogQueryScalar(query, GMLogConstants
						.getClassByLogName(logType));
				query
						.setResultTransformer(GMTransformers
								.aliasToBean(GMLogConstants
										.getClassByLogName(logType)));
				return query.list();
			}
		});
	}
	
	/**
	 * 座驾改装季 改装一送一
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<MoneyLog> getLogMycarModify(final String date,
			final long begin_time, final long end_time, final String reason,
			final String logType) {
		return getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List<MoneyLog> doCall(Session session) {
				
				StringBuffer sql = new StringBuffer();
				sql.append("select * from " + logType + "_" + date
						+ " where 1=1");
				if (begin_time != -1) {
					sql.append(" and  log_time >= :startTime");
				}
				if (end_time != -1) {
					sql.append(" and  log_time <= :endTime");
				}
				
				sql.append(" and reason in("+reason+")");
				SQLQuery query = session.createSQLQuery(sql.toString());
	
				if (begin_time != -1) {
					query.setLong("startTime", begin_time);
				}
				if (end_time != -1) {
					query.setLong("endTime", end_time);
				}
				
				LogTypeUtils.addLogQueryScalar(query, GMLogConstants
						.getClassByLogName(logType));
				query
						.setResultTransformer(GMTransformers
								.aliasToBean(GMLogConstants
										.getClassByLogName(logType)));
				return query.list();
			}
		});
	}
}
