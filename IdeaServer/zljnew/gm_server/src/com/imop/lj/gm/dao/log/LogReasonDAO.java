/**
 *
 */
package com.imop.lj.gm.dao.log;

import java.util.List;

import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GenericDAO;

/**
 * @author linfan
 *
 */
public class LogReasonDAO extends GenericDAO {

	/**
	 * 根据logType 得到日志名称
	 * @param logType
	 * @return 日志名称
	 */
	@SuppressWarnings("unchecked")
	public List getLogReason(final String logTable) {
		return (List) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						String sql="select reason,reason_name from reason_list where log_table='"+logTable+"'";
						SQLQuery query = session.createSQLQuery(sql);
						return  query.list();
					}
				});
	}
	/**
	 * 返回 logTypeList
	 * @return List
	 */
	@SuppressWarnings("unchecked")
	public  List getLogTypeList() {
		return (List) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						String sql="select distinct log_type,log_desc from reason_list";
						SQLQuery query = session.createSQLQuery(sql);
						return query.list();
					}
				});

	}

}
