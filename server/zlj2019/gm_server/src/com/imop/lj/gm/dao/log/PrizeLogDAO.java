package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.log.PrizeLog;

/**
 * 发奖礼包日志DAO
 *
 * @author linfan
 *
 */
public class PrizeLogDAO extends GenericDAO {

	/**
	 * 得到发奖礼包日志列表
	 *
	 * @param order
	 * @param sortType
	 * @param endTimel
	 * @param startTimel
	 * @return 得到发奖礼包日志D列表
	 */
	@SuppressWarnings("unchecked")
	public List<PrizeLog> getPrizeLogList(final String roleID, final String date,
			final String reason, final String sortType, final String order, final long startTimel, final long endTimel,final String prizeType) {
		return (List<PrizeLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from prize_log_" + date + " where 1=1");
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
						if (StringUtils.isNotBlank(prizeType)
								&& !"-1".equals(prizeType)) {
							sql.append(" and prize_type = :prizeType");
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
						if (StringUtils.isNotBlank(prizeType)
								&& !"-1".equals(prizeType)) {
							query.setString("prizeType", prizeType.trim());
						}
						LogTypeUtils.addLogQueryScalar(query, PrizeLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(PrizeLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

}
