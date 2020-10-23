package com.imop.lj.gm.dao;



/**
 * 游戏玩家信息DAO
 *
 * @author linfan
 *
 */
public class EmployeeDAO extends GenericDAO {
//	/**
//	 * 得到游戏玩家List
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<EmployeeEntity> getEmployeeList() throws Exception {
//		return (List<EmployeeEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						Query query = session.getNamedQuery("getEmployeeList");
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
//	/**
//	 * 竞技场排名
//	 *
//	 * @return
//	 * @throws Exception
//	 */
//	@SuppressWarnings("unchecked")
//	public List<EmployeeEntity> searchEmployee(final String type,
//			final String searchValue, final String startLevel, final String endLevel,final String startIndexSort, final String endIndexSort) {
//		return (List<EmployeeEntity>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session) {
//						StringBuffer sql = new StringBuffer();
//						sql.append("select * from t_employee_info where 1=1");
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							sql.append(" and charId = :charId");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userName".equals(type)) {
//							sql.append(" and name like :name");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userId".equals(type)) {
//							sql.append(" and templateId = :templateId");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "id".equals(type)) {
//							sql.append(" and id = :id");
//						}else{
//							if (StringUtils.isNotBlank(startLevel)) {
//								sql.append(" and level >= :startLevel");
//							}
//							if (StringUtils.isNotBlank(endLevel)) {
//								sql.append(" and level <= :endLevel");
//							}
//							if (StringUtils.isNotBlank(startIndexSort)) {
//								sql.append(" and exp >= :startIndexSort");
//							}
//							if (StringUtils.isNotBlank(endIndexSort)) {
//								sql.append(" and exp <= :endIndexSort");
//							}
//						}
//
//						SQLQuery query = session.createSQLQuery(sql.toString());
//						if (StringUtils.isNotBlank(searchValue)
//								&& "roleId".equals(type)) {
//							query.setLong("charId", StringUtil.parseStringTOLong(searchValue));
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userName".equals(type)) {
//							query.setString("name", "%" + searchValue + "%");
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "userId".equals(type)) {
//							query.setLong("templateId",  StringUtil.parseStringTOLong(searchValue));
//						}
//						if (StringUtils.isNotBlank(searchValue)
//								&& "id".equals(type)) {
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
//						LogTypeUtils.addQueryScalar(query, EmployeeEntity.class);
//						query.setResultTransformer(Transformers
//								.aliasToBean(EmployeeEntity.class));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}
//	public static void main(String[] args){
//		EmployeeDAO ee = new EmployeeDAO();
//		List<EmployeeDaoModel> ll=ee.searchEmployees(null,null,null,null,null,null);
//		System.out.println(ll.size());
//	}

}
