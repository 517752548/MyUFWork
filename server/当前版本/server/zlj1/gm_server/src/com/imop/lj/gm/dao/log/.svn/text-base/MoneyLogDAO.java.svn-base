package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.log.MoneyLog;

/**
 * 金钱日志DAO
 *
 * @author linfan
 *
 */
public class MoneyLogDAO extends GenericDAO {

	/**
	 * @param order
	 * @param sortType
	 * @param moneyType
	 * @param endTimel
	 * @param startTimel
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<MoneyLog> getMoneyLogList(final String roleID,
			final String date, final String reason, final String moneyType,
			 final String sortType, final String order,
			final long startTimel, final long endTimel,final String main_delta) {
		return (List<MoneyLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql
								.append("select * from money_log_" + date
										+ " where 1=1");
						sql.append(StringUtils.isBlank(roleID) ? ""
								: " and char_id = :charId");
						if (StringUtils.isNotBlank(reason)
								&& !"-1".equals(reason)) {
							sql.append(" and reason = :reason");
						}
						if (StringUtils.isNotBlank(moneyType)
								&& !"-1".equals(moneyType)) {
							sql.append(" and main_currency = :moneyType");
						}
						if (StringUtils.isNotBlank(main_delta)
								&& !"-1".equals(main_delta)) {

							sql.append(" and abs(main_delta) >= :main_delta");
						}
						if (startTimel != -1) {
							sql.append(" and  log_time >= :startTime");
						}
						if (endTimel != -1) {
							sql.append(" and  log_time <= :endTime");
						}
						if (StringUtils.isNotBlank(sortType)) {
							sql.append(" order by " + sortType + " " + order);
						}
						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(roleID)) {
							query.setString("charId", roleID.trim());
						}
						if (StringUtils.isNotBlank(reason)
								&& !"-1".equals(reason)) {
							query.setString("reason", reason.trim());
						}
						if (StringUtils.isNotBlank(moneyType)
								&& !"-1".equals(moneyType)) {
							query.setString("moneyType", moneyType.trim());
						}
						if (StringUtils.isNotBlank(main_delta)
								&& !"-1".equals(main_delta)) {
							query.setString("main_delta", main_delta.trim());
						}
						if (startTimel != -1) {
							query.setLong("startTime", startTimel);
						}
						if (endTimel != -1) {
							query.setLong("endTime", endTimel);
						}

						LogTypeUtils.addLogQueryScalar(query, MoneyLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(MoneyLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

}
