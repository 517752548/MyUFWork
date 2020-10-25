package com.imop.lj.gm.dao;


public class HunterDAO extends GenericDAO {
//	/**
//	 * 猎命师
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<HunterEntity> getHunterList() throws Exception {
//		return (List<HunterEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						Query query = session.getNamedQuery("getAllHunterEntityList");
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
//	/**
//	 * 猎命师
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<HunterEntity> getHunterList(final String type,
//			final String searchValue, final String startLevel, final String endLevel) throws Exception {
//		return (List<HunterEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from t_hunter_info where 1=1");
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							sql.append(" and charId = :roleId");
//						}
//
//						if (StringUtils.isNotBlank(startLevel)) {
//							sql.append(" and hunterIndex >= :startLevel");
//						}
//						if (StringUtils.isNotBlank(endLevel)) {
//							sql.append(" and hunterIndex <= :endLevel");
//						}
//
//						SQLQuery query = session.createSQLQuery(sql.toString());
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							query.setLong("roleId", StringUtil.parseStringTOLong(searchValue));
//						}
//
//
//						if (StringUtils.isNotBlank(startLevel)) {
//							query.setInteger("startLevel", StringUtil.parseStringTOInt(startLevel));
//						}
//						if (StringUtils.isNotBlank(endLevel)) {
//							query.setInteger("endLevel",  StringUtil.parseStringTOInt(endLevel));
//						}
//
//						LogTypeUtils.addQueryScalar(query, HunterEntity.class);
//						query.setResultTransformer(Transformers
//								.aliasToBean(HunterEntity.class));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
}
