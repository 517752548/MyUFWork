package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.log.ChargeLog;

/**
 * 充值日志DAO
 *
 * @author linfan
 *
 */
public class ChargeLogDAO extends GenericDAO {

	/**
	 * 得到充值日志列表
	 *
	 * @param order
	 * @param sortType
	 * @param endTimel
	 * @param startTimel
	 * @return 得到充值日志D列表
	 */
	@SuppressWarnings("unchecked")
	public List<ChargeLog> getChargeLogList(final String roleID, final String date,
			final String reason, final String sortType, final String order, final long startTimel, final long endTimel,final String moneyType) {
		return (List<ChargeLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from charge_log_" + date + " where 1=1");
						sql.append(StringUtils.isBlank(roleID) ? ""
								: " and char_id = :charId");
						if (StringUtils.isNotBlank(reason)
								&& !"-1".equals(reason)) {
							sql.append(" and reason = :reason");
						}
						if (startTimel != -1) {
							sql.append(" and  log_time >= :startTime");
						}
						if (endTimel != -1) {
							sql.append(" and  log_time <= :endTime");
						}
						if (StringUtils.isNotBlank(moneyType)
								&& !"-1".equals(moneyType)) {
							sql.append(" and money_type = :moneyType");
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
						if (startTimel != -1) {
							query.setLong("startTime", startTimel);
						}
						if (endTimel != -1) {
							query.setLong("endTime", endTimel);
						}
						if (StringUtils.isNotBlank(moneyType)
								&& !"-1".equals(moneyType)) {
							query.setString("moneyType", moneyType.trim());
						}
						LogTypeUtils.addLogQueryScalar(query, ChargeLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(ChargeLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

}
