package com.imop.lj.gm.dao;


public class AddressBookDAO extends GenericDAO {
//	/**
//	 * vip通讯录
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<AddressBookEntity> getAddressBookList() throws Exception {
//		return (List<AddressBookEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						Query query = session.getNamedQuery("getAllAddressBookList");
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
//	/**
//	 *秘书
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<AddressBookEntity> getAddressBookListSearch(final String type,final String searchValue, final Date startDate,
//			final Date endDate) throws Exception {
//		return (List<AddressBookEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from t_address_book where 1=1");
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							sql.append(" and id = :roleId");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleName".equals(type)) {
//							sql.append(" and name = :roleName");
//						}
//
//						if (null != startDate) {
//							sql.append(" and createTime >= :startDate");
//						}
//						if (null != endDate) {
//							sql.append(" and createTime <= :endDate");
//						}
//
//						SQLQuery query = session.createSQLQuery(sql.toString());
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							query.setLong("roleId", StringUtil.parseStringTOLong(searchValue));
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleName".equals(type)) {
//							query.setString("roleName",  searchValue);
//						}
//
//						if (null != startDate) {
//							query.setTimestamp("startDate", startDate);
//						}
//						if (null != endDate) {
//							Calendar c = Calendar.getInstance();
//							c.setTime(endDate);
//							c.add(Calendar.DAY_OF_YEAR, 1);
//							query.setTimestamp("endDate", c.getTime());
//						}
//
//						LogTypeUtils.addQueryScalar(query, AddressBookEntity.class);
//						query.setResultTransformer(Transformers
//								.aliasToBean(AddressBookEntity.class));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
}
