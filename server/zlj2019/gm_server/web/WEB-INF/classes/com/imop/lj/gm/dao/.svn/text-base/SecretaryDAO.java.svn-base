package com.imop.lj.gm.dao;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.transform.Transformers;

import com.imop.lj.db.model.PetEntity;
import com.imop.lj.gm.dao.log.LogTypeUtils;
import com.imop.lj.gm.utils.StringUtil;


public class SecretaryDAO extends GenericDAO {
//	/**
//	 *秘书
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<PetEntity> getSecretaryList() throws Exception {
//		return (List<PetEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						Query query = session.getNamedQuery("getAllSecretaryList");
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
	/**
	 *秘书
	 *
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public List<PetEntity> getSecretaryListSerch(final String type,final String searchValue, final String startLevel,
			final String endLevel,final String startIndexSort, final String endIndexSort, final String state) throws Exception {
		return (List<PetEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from t_pet_info where 1=1");
						if (StringUtils.isNotBlank(searchValue)	&& "roleId".equals(type)) {
							sql.append(" and charId = :roleId");
						}
						if (StringUtils.isNotBlank(searchValue)	&& "tempId".equals(type)) {
							sql.append(" and templateId = :tempId");
						}

						if (StringUtils.isNotBlank(startLevel)) {
							sql.append(" and level >= :startLevel");
						}
						if (StringUtils.isNotBlank(endLevel)) {
							sql.append(" and level <= :endLevel");
						}
						if (StringUtils.isNotBlank(startIndexSort)) {
							sql.append(" and exp >= :startIndexSort");
						}
						if (StringUtils.isNotBlank(endIndexSort)) {
							sql.append(" and exp <= :endIndexSort");
						}
						
						if("1".equals(state) || "2".equals(state)){
							sql.append(" and petState = :petState");
						}
//						if (StringUtils.isNotBlank(huntBag)) {
//							sql.append(" and openHuntBag = :huntBag");
//						}
//						if (StringUtils.isNotBlank(trainType)) {
//							sql.append(" and trainingType = :trainType");
//						}

						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(searchValue)
								&& "roleId".equals(type)) {
							query.setLong("roleId", StringUtil.parseStringTOLong(searchValue));
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "tempId".equals(type)) {
							query.setLong("tempId",  StringUtil.parseStringTOLong(searchValue));
						}

						if (StringUtils.isNotBlank(startLevel)) {
							query.setInteger("startLevel", StringUtil.parseStringTOInt(startLevel));
						}
						if (StringUtils.isNotBlank(endLevel)) {
							query.setInteger("endLevel",  StringUtil.parseStringTOInt(endLevel));
						}
						if (StringUtils.isNotBlank(startIndexSort)) {
							query.setInteger("startIndexSort", StringUtil.parseStringTOInt(startIndexSort));
						}
						if (StringUtils.isNotBlank(endIndexSort)) {
							query.setInteger("endIndexSort",  StringUtil.parseStringTOInt(endIndexSort));
						}
						
						if("1".equals(state) || "2".equals(state)){
							query.setInteger("petState", StringUtil.parseStringTOInt(state));
						}
						
//						if (StringUtils.isNotBlank(huntBag)) {
//							query.setInteger("huntBag", StringUtil.parseStringTOInt(huntBag));
//						}
//						if (StringUtils.isNotBlank(trainType)) {
//							query.setInteger("trainType",  StringUtil.parseStringTOInt(trainType));
//						}

						LogTypeUtils.addQueryScalar(query, PetEntity.class);
						query.setResultTransformer(Transformers.aliasToBean(PetEntity.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
