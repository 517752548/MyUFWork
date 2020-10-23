package com.imop.lj.gm.dao;


public class BattleDAO extends GenericDAO {
//	/**
//	 * 得到游戏玩家List
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<BattleSnapEntity> getBattleList() throws Exception {
//		return (List<BattleSnapEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						Query query = session.getNamedQuery("getAllBattleSnapList");
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
//	/**
//	 * 得到游戏玩家List
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<BattleSnapEntity> getBattleListSearch(final String type,
//			final String searchValue, final String startLevel, final String endLevel) throws Exception {
//		return (List<BattleSnapEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from t_battle_info_snap where 1=1");
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userName".equals(type)) {
//							sql.append(" and name like :name");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userId".equals(type)) {
//							sql.append(" and arrayId = :arrayId");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							sql.append(" and id = :id");
//						}else{
//							if (StringUtils.isNotBlank(startLevel)) {
//								sql.append(" and level >= :startLevel");
//							}
//							if (StringUtils.isNotBlank(endLevel)) {
//								sql.append(" and level <= :endLevel");
//							}
//						}
//
//						SQLQuery query = session.createSQLQuery(sql.toString());
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userName".equals(type)) {
//							query.setString("name", "%" + searchValue + "%");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userId".equals(type)) {
//							query.setLong("arrayId",  StringUtil.parseStringTOLong(searchValue));
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							query.setLong("id", StringUtil.parseStringTOLong(searchValue));
//						}else{
//							if (StringUtils.isNotBlank(startLevel)) {
//								query.setInteger("startLevel", StringUtil.parseStringTOInt(startLevel));
//							}
//							if (StringUtils.isNotBlank(endLevel)) {
//								query.setInteger("endLevel",  StringUtil.parseStringTOInt(endLevel));
//							}
//						}
//
//						LogTypeUtils.addQueryScalar(query, BattleSnapEntity.class);
//						query.setResultTransformer(Transformers
//								.aliasToBean(BattleSnapEntity.class));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
}
