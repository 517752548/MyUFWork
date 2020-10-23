package com.imop.lj.gm.dao;


public class CommerceMemberDAO extends GenericDAO {
//	/**
//	 * 商会会员
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<CommerceMemberEntity> getCommerceMemeberList(final String type,
//			final String searchValue, final String startLevel, final String endLevel,final String startIndexSort, final String endIndexSort) throws Exception {
//		return (List<CommerceMemberEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from t_guild_member where 1=1");
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userId".equals(type)) {
//							sql.append(" and guildId = :accountId");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							sql.append(" and roleId = :roleId");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userName".equals(type)) {
//							sql.append(" and name like :name");
//						}
////						if (StringUtils.isNotBlank(searchValue)
////								&& "indexSort".equals(type)) {
////							sql.append(" and indexSort = :indexSort");
////						}
//
//						if (StringUtils.isNotBlank(startLevel)) {
//							sql.append(" and level >= :startLevel");
//						}
//						if (StringUtils.isNotBlank(endLevel)) {
//							sql.append(" and level <= :endLevel");
//						}
//						if (StringUtils.isNotBlank(startIndexSort)) {
//							sql.append(" and curContrib >= :startIndexSort");
//						}
//						if (StringUtils.isNotBlank(endIndexSort)) {
//							sql.append(" and curContrib <= :endIndexSort");
//						}
////						if (StringUtils.isNotBlank(startContrib)) {
////							sql.append(" and curContrib >= :startContrib");
////						}
////						if (StringUtils.isNotBlank(endcontrib)) {
////							sql.append(" and curContrib <= :endcontrib");
////						}
//
//						SQLQuery query = session.createSQLQuery(sql.toString());
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userId".equals(type)) {
//							query.setLong("accountId",  StringUtil.parseStringTOLong(searchValue));
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							query.setLong("roleId", StringUtil.parseStringTOLong(searchValue));
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userName".equals(type)) {
//							query.setString("name", "%" + searchValue + "%");
//						}
////						if (StringUtils.isNotBlank(searchValue)
////								&& "indexSort".equals(type)) {
////							query.setLong("indexSort",  StringUtil.parseStringTOLong(searchValue));
////						}
//
//						if (StringUtils.isNotBlank(startLevel)) {
//							query.setInteger("startLevel", StringUtil.parseStringTOInt(startLevel));
//						}
//						if (StringUtils.isNotBlank(endLevel)) {
//							query.setInteger("endLevel",  StringUtil.parseStringTOInt(endLevel));
//						}
//						if (StringUtils.isNotBlank(startIndexSort)) {
//							query.setInteger("startIndexSort", StringUtil.parseStringTOInt(startIndexSort));
//						}
//						if (StringUtils.isNotBlank(endIndexSort)) {
//							query.setInteger("endIndexSort",  StringUtil.parseStringTOInt(endIndexSort));
//						}
////						if (StringUtils.isNotBlank(startContrib)) {
////							query.setInteger("startContrib", StringUtil.parseStringTOInt(startContrib));
////						}
////						if (StringUtils.isNotBlank(endcontrib)) {
////							query.setInteger("endcontrib",  StringUtil.parseStringTOInt(endcontrib));
////						}
//
//
//						LogTypeUtils.addQueryScalar(query, CommerceMemberEntity.class);
//						query.setResultTransformer(Transformers
//								.aliasToBean(CommerceMemberEntity.class));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
}
