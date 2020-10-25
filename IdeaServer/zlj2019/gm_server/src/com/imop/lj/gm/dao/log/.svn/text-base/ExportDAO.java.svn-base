package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.autolog.GMAutoLogConstants;
import com.imop.lj.gm.constants.GMLogConstants;
import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
/**
 * 导出DAO
 * @author sky
 *
 */
public class ExportDAO extends GenericDAO {

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
				LogTypeUtils.addLogQueryScalar(query, GMAutoLogConstants
						.getClassByLogName(logType));
				query
						.setResultTransformer(GMTransformers
								.aliasToBean(GMAutoLogConstants
										.getClassByLogName(logType)));
				return query.list();
			}
		});
	}
}
