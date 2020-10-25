package com.imop.lj.gm.dao;


/**
 * 游戏玩家信息DAO
 *
 * @author linfan
 *
 */
public class BranchDAO extends GenericDAO {
//	/**
//	 * 得到游戏玩家List
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<BranchEntity> getBranchList() throws Exception {
//		return (List<BranchEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						Query query = session.getNamedQuery("getBranchList");
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
//	public List<BranchEntity> getBranchListSerch(final String type,
//			final String searchValue, final String startLevel, final String endLevel,final String startIndexSort, final String endIndexSort) throws Exception {
//		return (List<BranchEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from t_branch_info where 1=1");
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							sql.append(" and charId = :charId");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userId".equals(type)) {
//							sql.append(" and id = :id");
//						}else{
//							if (StringUtils.isNotBlank(startLevel)) {
//								sql.append(" and position >= :startLevel");
//							}
//							if (StringUtils.isNotBlank(endLevel)) {
//								sql.append(" and position <= :endLevel");
//							}
//							if (StringUtils.isNotBlank(startIndexSort)) {
//								sql.append(" and level >= :startIndexSort");
//							}
//							if (StringUtils.isNotBlank(endIndexSort)) {
//								sql.append(" and level <= :endIndexSort");
//							}
//						}
//
//						SQLQuery query = session.createSQLQuery(sql.toString());
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							query.setLong("charId", StringUtil.parseStringTOLong(searchValue));
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userId".equals(type)) {
//							query.setLong("id",  StringUtil.parseStringTOLong(searchValue));
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
//						}
//
//						LogTypeUtils.addQueryScalar(query, BranchEntity.class);
//						query.setResultTransformer(Transformers
//								.aliasToBean(BranchEntity.class));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}

}
