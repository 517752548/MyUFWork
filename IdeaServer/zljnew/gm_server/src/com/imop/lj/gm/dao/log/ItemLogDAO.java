package com.imop.lj.gm.dao.log;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GMTransformers;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.log.ItemLog;

/**
 * 游戏玩家信息DAO
 *
 * @author linfan
 *
 */
public class ItemLogDAO extends GenericDAO {

	/**
	 * @param order
	 * @param sortType
	 * @param endTimeTimel
	 * @param startTimel
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<ItemLog> getItemLogList(final String roleID,final String date,final String reason,final String templateId, final String sortType, final String order, final long startTimel, final long endTimel) {
		return (List<ItemLog>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from item_log_" + date +" where 1=1");
						sql.append(StringUtils.isBlank(roleID) ? "" :" and char_id = :charId");
						if(StringUtils.isNotBlank(reason)&&!"-1".equals(reason)){
							sql.append(" and reason = :reason");
						}
						sql.append(StringUtils.isBlank(templateId) ? "" :" and item_tmpl_id = :itemTmplId");
						if (startTimel!=-1) {
							sql.append(" and  log_time >= :startTime");
						}
						if (endTimel!=-1) {
							sql.append(" and  log_time <= :endTime");
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
	                    if (StringUtils.isNotBlank(templateId)) {
	                    	query.setString("templateId",templateId.trim());
	                    }
	                    if (startTimel!=-1) {
							query.setLong("startTime", startTimel);
						}
						if (endTimel!=-1) {
							query.setLong("endTime", endTimel);
						}
						LogTypeUtils.addLogQueryScalar(query, ItemLog.class);
						query.setResultTransformer(GMTransformers
								.aliasToBean(ItemLog.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

}
