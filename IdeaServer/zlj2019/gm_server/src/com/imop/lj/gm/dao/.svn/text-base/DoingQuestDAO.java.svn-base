package com.imop.lj.gm.dao;


public class DoingQuestDAO extends GenericDAO {
//	/**
//	 * 在做任务
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<DoingQuestEntity> getDoingQuestList() throws Exception {
//		return (List<DoingQuestEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						Query query = session.getNamedQuery("getAllDoingQuestList");
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
//	/**
//	 * 在做任务
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<DoingQuestEntity> getDoingQuestListSerch(final String type,
//			final String searchValue, final String startLevel, final String endLevel) throws Exception {
//		return (List<DoingQuestEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from t_doing_task where 1=1");
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							sql.append(" and charId = :roleId");
//						}
//
//						if (StringUtils.isNotBlank(startLevel)) {
//							sql.append(" and questId >= :startLevel");
//						}
//						if (StringUtils.isNotBlank(endLevel)) {
//							sql.append(" and questId <= :endLevel");
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
//						LogTypeUtils.addQueryScalar(query, DoingQuestEntity.class);
//						query.setResultTransformer(Transformers
//								.aliasToBean(DoingQuestEntity.class));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
}
