package com.imop.lj.gm.dao;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.Query;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.transform.Transformers;

import com.imop.lj.db.model.DoingQuestEntity;
import com.imop.lj.db.model.FinishedQuestEntity;
import com.imop.lj.gm.dao.log.LogTypeUtils;
import com.imop.lj.gm.utils.StringUtil;

public class FinishedQuestDAO extends GenericDAO {
	/**
	 * 完成任务
	 *
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public List<FinishedQuestEntity> getFinishedQuestList() throws Exception {
		return (List<FinishedQuestEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session.getNamedQuery("getAllFinishedQuestList");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
	/**
	 * 完成任务
	 *
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public List<FinishedQuestEntity> getFinishedQuestListSerch(final String type,
			final String searchValue, final String startLevel, final String endLevel) throws Exception {
		return (List<FinishedQuestEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from t_finished_quest where 1=1");
						if (StringUtils.isNotBlank(searchValue)
								&& "roleId".equals(type)) {
							sql.append(" and charId = :roleId");
						}

						if (StringUtils.isNotBlank(startLevel)) {
							sql.append(" and questId >= :startLevel");
						}
						if (StringUtils.isNotBlank(endLevel)) {
							sql.append(" and questId <= :endLevel");
						}

						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(searchValue)
								&& "roleId".equals(type)) {
							query.setLong("roleId", StringUtil.parseStringTOLong(searchValue));
						}


						if (StringUtils.isNotBlank(startLevel)) {
							query.setInteger("startLevel", StringUtil.parseStringTOInt(startLevel));
						}
						if (StringUtils.isNotBlank(endLevel)) {
							query.setInteger("endLevel",  StringUtil.parseStringTOInt(endLevel));
						}

						LogTypeUtils.addQueryScalar(query, FinishedQuestEntity.class);
						query.setResultTransformer(Transformers
								.aliasToBean(FinishedQuestEntity.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
