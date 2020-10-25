package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.log.GmCommandLog;

/**
 * 使用GM命令日志DAO
 *
 * @author linfan
 *
 */
public class GmCommandLogDAO extends GenericDAO {

	/**
	 * 得到GM命令日志列表
	 * @param roleID 角色ID
	 * @param date   日期
	 * @param reason  原因
	 * @param sortType 排序字段
	 * @param order	  顺序
	 * @param startTimel  开始日期
	 * @param endTimel	  结束日期
	 * @param accountType
	 * @return GM命令日志列表
	 */
	@SuppressWarnings("unchecked")
	public List<GmCommandLog> getGmCommandLogList(final String roleID,final String date,final String reason, final String sortType, final String order, final long startTimel, final long endTimel, final String operatorName) {
		return (List<GmCommandLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from gm_command_log_" + date +" where 1=1");
						sql.append(StringUtils.isBlank(roleID) ? "" :" and char_id = :charId");
						if(StringUtils.isNotBlank(reason)&&!"-1".equals(reason)){
							sql.append(" and reason = :reason");
						}

						if (startTimel!=-1) {
							sql.append(" and  log_time >= :startTime");
						}
						if (endTimel!=-1) {
							sql.append(" and  log_time <= :endTime");
						}
						if (!"-1".equals(operatorName)&&(StringUtils.isNotBlank(operatorName))) {
							sql.append(" and operator_name = :operatorName");
						}
						if(StringUtils.isNotBlank(sortType)){
							sql.append(" order by "+sortType+" "+order);
						}
						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(roleID)) {
	                    	query.setString("charId",roleID.trim());
	                    }
	                    if (StringUtils.isNotBlank(reason)&&!"-1".equals(reason)) {
	                    	query.setString("reason",reason.trim());
	                    }
	                    if (startTimel!=-1) {
							query.setLong("startTime", startTimel);
						}
						if (endTimel!=-1) {
							query.setLong("endTime", endTimel);
						}
						if (!"-1".equals(operatorName)&&(StringUtils.isNotBlank(operatorName))) {
							query.setString("operatorName", operatorName);
						}
						LogTypeUtils.addLogQueryScalar(query, GmCommandLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(GmCommandLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

}
