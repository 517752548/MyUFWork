package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.log.TaskLog;

/**
 * 任务日志DAO
 *
 * @author linfan
 *
 */
public class TaskLogDAO extends GenericDAO {

	/**
	 * 得到任务日志列表
	 * @param endTimel
	 * @param startTimel
	 *
	 * @return 得到任务日志D列表
	 */
	@SuppressWarnings("unchecked")
	public List<TaskLog> getTaskLogList(final String roleID,
			final String date, final String reason,final String taskID,final String sortType,final String order, final long startTimel, final long endTimel) {
		return (List<TaskLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql
								.append("select * from task_log_" + date
										+ " where 1=1");
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
						sql.append(StringUtils.isBlank(taskID) ? "" :" and task_id = :taskID");
						if(StringUtils.isNotBlank(sortType)){
							sql.append(" order by "+sortType+" "+order);
						}

						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(roleID)) {
							query.setString("charId", roleID.trim());
						}
						if (StringUtils.isNotBlank(reason)
								&& !"-1".equals(reason)) {
							query.setString("reason", reason.trim());
						}
						if (StringUtils.isNotBlank(taskID)) {
		                    	query.setString("taskID",taskID.trim());
		                    }
						if (startTimel != -1) {
							query.setLong("startTime", startTimel);
						}
						if (endTimel != -1) {
							query.setLong("endTime", endTimel);
						}
						LogTypeUtils.addLogQueryScalar(query, TaskLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(TaskLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

}
