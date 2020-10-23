package com.imop.lj.gm.dao.maintenance;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.Query;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.transform.Transformers;

import com.imop.lj.db.model.PrizeInfo;
import com.imop.lj.gm.dao.GenericDAO;
import com.imop.lj.gm.dao.log.LogTypeUtils;

/**
 * 发奖礼包DAO
 *
 *
 */
public class PrizeDAO extends GenericDAO {

	/**
	 * 得到发奖礼包
	 *
	 * @param passportId
	 * @param type
	 *            补偿类型
	 * @return @return 发奖礼包列表
	 */
	@SuppressWarnings("unchecked")
	public List<PrizeInfo> getPrizeList(final String prizeId) {
		return (List<PrizeInfo>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from t_prize where 1=1");
						sql.append(StringUtils.isBlank(prizeId) ? ""
								: " and prizeId = :prizeId");
						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(prizeId)) {
							query.setString("prizeId", prizeId.trim());
						}
						LogTypeUtils.addQueryScalar(query, PrizeInfo.class);
						query.setResultTransformer(Transformers
								.aliasToBean(PrizeInfo.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

	/**
	 * 根据prizeId查询Prize
	 *
	 * @param prizeId
	 *            礼包ID
	 * @return Prize 实体
	 */
	public PrizeInfo queryPrize(final String prizeId) {
		return (PrizeInfo) getTemplate().doCall(new HibernateCallback<PrizeInfo>() {
			@Override
			public PrizeInfo doCall(Session session) {
				Query query = session.getNamedQuery("queryPrize");
				query.setString("prizeId", prizeId);
				return (PrizeInfo) query.uniqueResult();
			}
		});
	}


}
