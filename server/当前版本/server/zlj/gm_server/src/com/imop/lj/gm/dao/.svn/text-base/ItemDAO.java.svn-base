package com.imop.lj.gm.dao;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.Query;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.transform.Transformers;

import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.gm.dao.log.LogTypeUtils;
import com.imop.lj.gm.utils.StringUtil;

public class ItemDAO extends GenericDAO {
	/**
	 * 道具
	 *
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public List<ItemEntity> getItemList() throws Exception {
		return (List<ItemEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session.getNamedQuery("getAllItemList");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
	/**
	 * 道具
	 *
	 * @return
	 * @throws Exception
	 */
	@SuppressWarnings("unchecked")
	public List<ItemEntity> getItemListSerch(final String type,
			final String searchValue, final String startLevel, final String endLevel,final String startIndexSort, final String delete) throws Exception {
		return (List<ItemEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from t_item_info where 1=1");
						if (StringUtils.isNotBlank(searchValue)
								&& "roleId".equals(type)) {
							sql.append(" and charId = :roleId");
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "userId".equals(type)) {
							sql.append(" and wearerId = :accountId");
						}

						if (StringUtils.isNotBlank(startLevel)) {
							sql.append(" and templateId >= :startLevel");
						}
						if (StringUtils.isNotBlank(endLevel)) {
							sql.append(" and templateId <= :endLevel");
						}
//						if (StringUtils.isNotBlank(startIndexSort)) {
//							sql.append(" and star >= :startIndexSort");
//						}
						
						if("0".equals(delete) || "1".equals(delete)){
							sql.append(" and deleted = :delete");
						}

						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(searchValue)
								&& "roleId".equals(type)) {
							query.setLong("roleId", StringUtil.parseStringTOLong(searchValue));
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "userId".equals(type)) {
							query.setLong("accountId",  StringUtil.parseStringTOLong(searchValue));
						}

						if (StringUtils.isNotBlank(startLevel)) {
							query.setInteger("startLevel", StringUtil.parseStringTOInt(startLevel));
						}
						if (StringUtils.isNotBlank(endLevel)) {
							query.setInteger("endLevel",  StringUtil.parseStringTOInt(endLevel));
						}
//						if (StringUtils.isNotBlank(startIndexSort)) {
//							query.setInteger("startIndexSort", StringUtil.parseStringTOInt(startIndexSort));
//						}

						if("0".equals(delete) || "1".equals(delete)){
							query.setInteger("delete", StringUtil.parseStringTOInt(delete));
						}
						
						LogTypeUtils.addQueryScalar(query, ItemEntity.class);
						query.setResultTransformer(Transformers
								.aliasToBean(ItemEntity.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
