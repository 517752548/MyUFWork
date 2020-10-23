package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.log.PetLevelLog;

/**
 * 宠物级别变化日志DAO
 *
 * @author linfan
 *
 */
public class PetLevelLogDAO extends GenericDAO {

	/**
	 * @param order
	 * @param sortType
	 * @param petID
	 * @param endTimel
	 * @param startTimel
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<PetLevelLog> getPetLevelLogList(final String roleID,final String date,final String reason, final String sortType, final String order, final String petId, final long startTimel, final long endTimel) {
		return (List<PetLevelLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from pet_level_log_" + date +" where 1=1");
						sql.append(StringUtils.isBlank(roleID) ? "" :" and char_id = :charId");
						sql.append(StringUtils.isBlank(petId) ? "" :" and pet_id = :petId");
						if(StringUtils.isNotBlank(reason)&&!"-1".equals(reason)){
							sql.append(" and reason = :reason");
						}
						if (startTimel != -1) {
							sql.append(" and  log_time >= :startTime");
						}
						if (endTimel != -1) {
							sql.append(" and  log_time <= :endTime");
						}
						if(StringUtils.isNotBlank(sortType)){
							sql.append(" order by "+sortType+" "+order);
						}
						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(petId)) {
	                    	query.setString("petId",petId.trim());
	                    }
						if (StringUtils.isNotBlank(roleID)) {
	                    	query.setString("charId",roleID.trim());
	                    }
	                    if (StringUtils.isNotBlank(reason)&&!"-1".equals(reason)) {
	                    	query.setString("reason",reason.trim());
	                    }
	                    if (startTimel != -1) {
							query.setLong("startTime", startTimel);
						}
						if (endTimel != -1) {
							query.setLong("endTime", endTimel);
						}
						LogTypeUtils.addLogQueryScalar(query, PetLevelLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(PetLevelLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

}
