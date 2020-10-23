package com.imop.lj.gm.dao;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.Query;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.transform.Transformers;

import com.imop.lj.db.model.UserInfo;

/**
 * 游戏玩家信息DAO
 *
 * @author linfan
 *
 */
public class UserInfoDAO extends GenericDAO {
	/**
	 * 得到游戏玩家List
	 *
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public List<UserInfo> getUserInfoList() throws Exception {
		return (List<UserInfo>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session.getNamedQuery("getUserInfoList");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

	/**
	 * 根据条件查询UserInfo
	 *
	 * @param type
	 *            条件类型
	 * @param searchValue
	 * @param userStatus
	 * @param accountType
	 * @return 条件值
	 */
	@SuppressWarnings("unchecked")
	public List<UserInfo> searchUserInfo(final String type,
			final String searchValue, final String userStatus, final String accountType) {
		return (List<UserInfo>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from t_user_info where 1=1");
						if (StringUtils.isNotBlank(searchValue)
								&& "userId".equals(type)) {
							sql.append(" and id = :id");
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "username".equals(type)) {
							sql.append(" and name = :name");
						}
						if (!"-1".equals(userStatus)&&(StringUtils.isNotBlank(userStatus))) {
							sql.append(" and lockStatus = :state");
						}
						if (!"-1".equals(accountType)&&(StringUtils.isNotBlank(accountType))) {
							sql.append(" and role = :role");
						}
						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(searchValue)
								&& "userId".equals(type)) {

							query.setString("id", searchValue);
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "username".equals(type)) {
							query.setString("name", searchValue);
						}
						if (!"-1".equals(userStatus)&&(StringUtils.isNotBlank(userStatus))) {
							query.setInteger("state", Integer.valueOf(userStatus));
						}
						if (!"-1".equals(accountType)&&(StringUtils.isNotBlank(accountType))) {
							query.setInteger("role", Integer.valueOf(accountType));
						}
						query.setResultSetMapping("queryUserInfo");
						query.setResultTransformer(Transformers.aliasToBean(UserInfo.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

	/**
	 * 得到游戏玩家
	 *
	 * @return
	 * @throws Exception
	 */
	public UserInfo getUserInfo(final long id) throws Exception {
		return (UserInfo) getTemplate().doCall(
				new HibernateCallback<UserInfo>() {
					@Override
					public UserInfo doCall(Session session) {
						Query query = session.getNamedQuery("searchUserInfoById");
						query.setLong("id", id);
						return (UserInfo)query.uniqueResult();
					}
				});
	}
}
