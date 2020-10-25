package com.imop.lj.gm.dao.maintenance;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.transform.Transformers;

import com.imop.lj.db.model.UserInfo;
import com.imop.lj.db.model.UserPrize;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.dao.log.LogTypeUtils;

/**
 * GM补偿DAO
 *
 *
 */
public class UserPrizeDAO extends GenericDAO {


	public boolean getPassport(final String passportId,final String uname) {
		return getTemplate().doCall(new HibernateCallback<Boolean>() {

			@Override
			public Boolean doCall(Session session) {
				StringBuffer sql = new StringBuffer();
				sql.append("select * from t_user_info where 1=1");
				sql.append(StringUtils.isBlank(passportId) ? ""
						: " and id = :passportId");
				SQLQuery query = session.createSQLQuery(sql.toString());
				if (StringUtils.isNotBlank(passportId)) {
					query.setString("passportId", passportId.trim());
				}
				query.setResultSetMapping("queryUserInfo");
				query.setResultTransformer(Transformers
						.aliasToBean(UserInfo.class));
				getPagerUtil().process(session, query);
				List temp = query.list();
				System.out.println(((UserInfo)temp.get(0)).getName()+":"+uname);
				if ( temp== null ||temp.size() == 0 || StringUtils.isBlank(uname)) {
					return new Boolean(false);
				} else if (((UserInfo)temp.get(0)).getName().equals(uname)){
					return new Boolean(true);
				} else{
					return false;
				}
			}
		});
	}

	/**
	 * 得到GM补偿实体
	 *
	 * @param passportId
	 * @param type
	 *            补偿类型
	 * @return @return GM补偿实体列表
	 */
	@SuppressWarnings("unchecked")
	public List<UserPrize> getUserPrizeList(final String passportId,
			final String type, final String id,final String begintime,final String endtime) {
		return (List<UserPrize>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from t_user_prize where 1=1");
						sql.append(StringUtils.isBlank(passportId) ? ""
								: " and passportId = :passportId");
						sql.append(StringUtils.isBlank(id) ? ""
								: " and id = :id");
						if (StringUtils.isNotBlank(type) && !"-1".equals(type)) {
							sql.append(" and type = :type");
						}
						if (StringUtils.isNotBlank(begintime)) {
							sql.append(" and  createTime >= :startTime");
						}
						if (StringUtils.isNotBlank(endtime)) {
							sql.append(" and  createTime <= :endTime");
						}
						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(passportId)) {
							query.setString("passportId", passportId.trim());
						}
						if (StringUtils.isNotBlank(id)) {
							query.setString("id", id.trim());
						}
						if (StringUtils.isNotBlank(begintime)) {
							query.setString("startTime", begintime);
						}
						if (StringUtils.isNotBlank(endtime)) {
							query.setString("endTime", endtime);
						}
						if (StringUtils.isNotBlank(type) && !"-1".equals(type)) {
							query.setString("type", type.trim());
						}
						LogTypeUtils.addQueryScalar(query, UserPrize.class);
						query.setResultTransformer(Transformers
								.aliasToBean(UserPrize.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
