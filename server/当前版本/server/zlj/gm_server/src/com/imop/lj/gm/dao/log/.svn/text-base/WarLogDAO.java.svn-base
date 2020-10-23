package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.log.ChatLog;
import com.imop.lj.gm.model.log.WarLog;

/**
 * 战斗日志DAO
 *
 * @author fanghua.cui
 *
 */
public class WarLogDAO extends GenericDAO {

	/**
	 * 得到战斗日志的列表
	 *
	 * @param order
	 * @param sortType
	 * @param endTimel
	 * @param startTimel
	 * @return 得到战斗日志的列表
	 */
	@SuppressWarnings("unchecked")
	public List<WarLog> getWarLogList(final String roleID, final String date, final String reason,
			final String sortType, final String order, final long startTimel, final long endTimel) {
		return (List<WarLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from war_log_" + date + " where 1=1");
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

						LogTypeUtils.addLogQueryScalar(query, WarLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(WarLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

}
