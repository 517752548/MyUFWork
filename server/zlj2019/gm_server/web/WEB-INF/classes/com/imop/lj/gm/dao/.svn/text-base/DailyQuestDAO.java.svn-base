package com.imop.lj.gm.dao;


public class DailyQuestDAO extends GenericDAO {
//	/**
//	 * 日常任务
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<DailyQuestEntity> getDailyquestList() throws Exception {
//		return (List<DailyQuestEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						Query query = session.getNamedQuery("getAllDailyQuestList");
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
//	/**
//	 * 日常任务
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<DailyQuestEntity> getDailyquestListSerch(final String type,
//			final String searchValue, final String startLevel, final String endLevel) throws Exception {
//		return (List<DailyQuestEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from t_daily_task where 1=1");
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
//						if (StringUtils.isNotBlank(startLevel)) {
//							query.setInteger("startLevel", StringUtil.parseStringTOInt(startLevel));
//						}
//						if (StringUtils.isNotBlank(endLevel)) {
//							query.setInteger("endLevel",  StringUtil.parseStringTOInt(endLevel));
//						}
//
//						LogTypeUtils.addQueryScalar(query, DailyQuestEntity.class);
//						query.setResultTransformer(Transformers
//								.aliasToBean(DailyQuestEntity.class));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
}
