package com.imop.lj.gm.dao.sys;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.model.SysUser;

/**
 * 系统用户DAO
 *
 * @author lin fan
 *
 */
public class SysUserDAO extends GenericDAO {


	public SysUserDAO() {
		super();
	}

//	/**
//	 * 根据用户名,登录ip称查询用户对象
//	 *
//	 * @param u
//	 *            用户名称
//	 * @return SysUser
//	 * @throws Exception
//	 */
//	public SysUser getSysUser(String u) {
//		Session _session = getSession(LoginUserService.getLoginRegionId(),"1");
//		try{
//			Query query = _session.getNamedQuery("getSysUser");
//			query.setString("username", u);
//			return (SysUser) query.uniqueResult();
//		}
//		catch(Exception e){
//			e.printStackTrace();
//		}
//		finally{
//			_session.close();
//		}
//		return null;
//
//	}

	/**
	 * 得到系统用户列表
	 *
	 * @param searchValue
	 * @param searchType
	 *
	 * @return 系统用户列表
	 */
	@SuppressWarnings("unchecked")
	public List<SysUser> getSysUserList(final String searchType,
			final String searchValue) {
		return (List<SysUser>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List<SysUser> doCall(Session session) {
						Query query = null;
						List<SysUser> sysUserList = null;
						if ("".equals(searchValue) || searchType == null
								|| searchValue == null) {
							query = session.getNamedQuery("getSysUserList");
						} else {
							if ("username".equalsIgnoreCase(searchType)) {
								query = session
										.getNamedQuery("searchSysUserByName");
								query.setString("username", searchValue);
							} else if ("role".equalsIgnoreCase(searchType)) {
								query = session
										.getNamedQuery("searchSysUserByRole");
								query.setString("role", searchValue);
							}
						}
						if(query!=null){
							getPagerUtil().process(session, query);
							sysUserList=query.list();
						}
						return sysUserList;
					}
				});
	}

}
