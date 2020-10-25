package com.imop.lj.gm.dao.maintenance;

import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;

import com.imop.lj.db.model.MallEntity;
import com.imop.lj.gm.dao.GenericDAO;

/**
 * 商城DAO
 * 
 * @author xiaowei.liu
 * 
 */
public class MallDao extends GenericDAO {
	
	public List<MallEntity> getMallEntityList(){
		return (List<MallEntity>)this.getTemplate().doCall(new HibernateCallback<List<MallEntity>>() {
					@SuppressWarnings("rawtypes")
					@Override
					public List doCall(Session session) {
						Query query = session.getNamedQuery("getAllMall");
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}
}
