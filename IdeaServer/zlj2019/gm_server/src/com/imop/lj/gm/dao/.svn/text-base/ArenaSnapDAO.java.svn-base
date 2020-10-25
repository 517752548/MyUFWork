package com.imop.lj.gm.dao;


public class ArenaSnapDAO extends GenericDAO {
//	/**
//	 * 竞技场
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<ArenaSnapEntity> getArenaSnapList() throws Exception {
//		return (List<ArenaSnapEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						Query query = session.getNamedQuery("getAllArenaSnapList");
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
//	/**
//	 * 竞技场
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<ArenaSnapEntity> getArenaSnapListSerch(final String type,final String searchValue, final String startLevel, final String endLevel,
//			final String startIndexSort, final String endIndexSort,final String startRank, final String endRank) throws Exception {
//		return (List<ArenaSnapEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from t_arena_snap where 1=1");
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userId".equals(type)) {
//							sql.append(" and arrayId = :accountId");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							sql.append(" and id = :roleId");
//						}else{
//							if (StringUtils.isNotBlank(startLevel)) {
//								sql.append(" and cwinTimes >= :startLevel");
//							}
//							if (StringUtils.isNotBlank(endLevel)) {
//								sql.append(" and cwinTimes <= :endLevel");
//							}
//							if (StringUtils.isNotBlank(startIndexSort)) {
//								sql.append(" and totalTimes >= :startIndexSort");
//							}
//							if (StringUtils.isNotBlank(endIndexSort)) {
//								sql.append(" and totalTimes <= :endIndexSort");
//							}
//							if (StringUtils.isNotBlank(startRank)) {
//								sql.append(" and arenaRank >= :startRank");
//							}
//							if (StringUtils.isNotBlank(endRank)) {
//								sql.append(" and arenaRank <= :endRank");
//							}
//						}
//
//						SQLQuery query = session.createSQLQuery(sql.toString());
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userId".equals(type)) {
//							query.setLong("accountId",  StringUtil.parseStringTOLong(searchValue));
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							query.setLong("roleId", StringUtil.parseStringTOLong(searchValue));
//						}else{
//							if (StringUtils.isNotBlank(startLevel)) {
//								query.setInteger("startLevel", StringUtil.parseStringTOInt(startLevel));
//							}
//							if (StringUtils.isNotBlank(endLevel)) {
//								query.setInteger("endLevel",  StringUtil.parseStringTOInt(endLevel));
//							}
//							if (StringUtils.isNotBlank(startIndexSort)) {
//								query.setInteger("startIndexSort", StringUtil.parseStringTOInt(startIndexSort));
//							}
//							if (StringUtils.isNotBlank(endIndexSort)) {
//								query.setInteger("endIndexSort",  StringUtil.parseStringTOInt(endIndexSort));
//							}
//							if (StringUtils.isNotBlank(startRank)) {
//								query.setInteger("startRank", StringUtil.parseStringTOInt(startRank));
//							}
//							if (StringUtils.isNotBlank(endRank)) {
//								query.setInteger("endRank",  StringUtil.parseStringTOInt(endRank));
//							}
//						}
//
//						LogTypeUtils.addQueryScalar(query, ArenaSnapEntity.class);
//						query.setResultTransformer(Transformers
//								.aliasToBean(ArenaSnapEntity.class));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
}
