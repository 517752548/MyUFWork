package com.imop.lj.gm.dao;


import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.db.model.PetEntity;


//import com.imop.lj.dbs.msg.base.DataType;


/**
 * 宠物对象DAO
 *
 * @author linfan
 *
 */
public class PetDAO extends GenericDAO {

	/**
	 * 根据角色id,得到宠物对象列表
	 *
	 * @param id
	 *            角色id
	 * @return 宠物对象列表
	 */
	@SuppressWarnings("unchecked")
	public List<PetEntity> getPets(final String id) {
		return (List<PetEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session.getNamedQuery("getPets");
						query.setLong("id", Long.valueOf(id));
						return query.list();
					}
				});
	}
}
