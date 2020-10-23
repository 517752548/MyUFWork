package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.log.PetLog;

/**
 * 宠物日志 DAO
 *
 * @author linfan
 *
 */
public class PetLogDAO extends GenericDAO {

	/**
	 * 得到宠物日志列表
	 *
	 * @param endTimel
	 * @param startTimel
	 * @return 得到宠物日志列表
	 */
	@SuppressWarnings("unchecked")
	public List<PetLog> getPetLogList(final String roleID, final String date,
			final String reason, final String templeteID,
			final String sortType, final String order, final long startTimel,
			final long endTimel) {
		return (List<PetLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from pet_log_" + date + " where 1=1");
						sql.append(StringUtils.isBlank(roleID) ? ""
								: " and char_id = :charId");
						if (StringUtils.isNotBlank(reason)
								&& !"-1".equals(reason)) {
							sql.append(" and reason = :reason");
						}
						sql.append(StringUtils.isBlank(templeteID) ? ""
								: " and pet_temp_id = :petTempId");
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
						if (StringUtils.isNotBlank(templeteID)) {
							query.setString("petTempId", templeteID.trim());
						}
						if (startTimel != -1) {
							query.setLong("startTime", startTimel);
						}
						if (endTimel != -1) {
							query.setLong("endTime", endTimel);
						}
						LogTypeUtils.addLogQueryScalar(query, PetLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(PetLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

//	/**
//	 * 得到宠物的所有的信息
//	 * @param id 日志ID
//	 * @param date 日期
//	 * @return 宠物的信息
//	 */
//	public byte[] getPetData(final String id, final String date) {
//		return (byte[]) getTemplate().doCall(
//				new HibernateCallback <byte[]>() {
//					@Override
//					public byte[] doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from pet_log_" + date + " where id = :id");
//						SQLQuery query = session.createSQLQuery(sql.toString());
//						query.setString("id", id.trim());
//						LogTypeUtils.addLogQueryScalar(query, PetLog.class);
//						query.setResultTransformer(GMTransformers
//								.aliasToBean(PetLog.class));
//						PetLog petLog = (PetLog) query.uniqueResult();
//						return  petLog.getPetData();
//					}
//				});
//
//	}

}
