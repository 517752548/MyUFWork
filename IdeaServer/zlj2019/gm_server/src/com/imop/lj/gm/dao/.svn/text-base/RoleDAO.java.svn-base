package com.imop.lj.gm.dao;

import java.util.List;

import org.apache.commons.lang.StringUtils;
import org.hibernate.Query;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.transform.Transformers;

import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.db.model.ItemEntity;
import com.imop.lj.gm.utils.StringUtil;

/**
 * 游戏玩家信息DAO
 *
 * @author linfan
 *
 */
public class RoleDAO extends GenericDAO {


	/**
	 * 根据条件查询UserInfo
	 *
	 * @param type
	 *            条件类型
	 * @param searchValue
	 * @param endLevel
	 * @param startLevel
	 * @return 条件值
	 */
	@SuppressWarnings("unchecked")
	public List<HumanEntity> searchRole(final String type,
			final String searchValue, final String startLevel, final String endLevel) {
		return (List<HumanEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						StringBuffer sql = new StringBuffer();
						sql.append("select * from t_character_info where 1=1");
						if (StringUtils.isNotBlank(searchValue)
								&& "roleId".equals(type)) {
							sql.append(" and id = :id");
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "userName".equals(type)) {
							sql.append(" and name like :name");
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "userId".equals(type)) {
							sql.append(" and passportId = :passportId");
						}

						if (StringUtils.isNotBlank(startLevel)) {
							sql.append(" and level >= :startLevel");
						}
						if (StringUtils.isNotBlank(endLevel)) {
							sql.append(" and level <= :endLevel");
						}
						SQLQuery query = session.createSQLQuery(sql.toString());
						if (StringUtils.isNotBlank(searchValue)
								&& "roleId".equals(type)) {
							query.setLong("id", StringUtil.parseStringTOLong(searchValue));
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "userName".equals(type)) {
							query.setString("name", "%" + searchValue + "%");
						}
						if (StringUtils.isNotBlank(searchValue)
								&& "userId".equals(type)) {
							query.setString("passportId",  searchValue);
						}
						if (StringUtils.isNotBlank(startLevel)) {
							query.setInteger("startLevel", StringUtil.parseStringTOInt(startLevel));
						}
						if (StringUtils.isNotBlank(endLevel)) {
							query.setInteger("endLevel",  StringUtil.parseStringTOInt(endLevel));
						}

						query.setResultSetMapping("queryHumanEntity");
						query.setResultTransformer(Transformers
								.aliasToBean(HumanEntity.class));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

	/**
	 * 根据角色id,得到角色对象
	 *
	 * @param id
	 *            角色id
	 * @return 角色对象
	 */
	public HumanEntity getCharacterInfo(final String id) {
		return (HumanEntity) getTemplate().doCall(
				new HibernateCallback<HumanEntity>() {
					@Override
					public HumanEntity doCall(Session session) {
						Query query = session.getNamedQuery("getCharacterInfo");
						query.setLong("id", Long.valueOf(id));
						return (HumanEntity)query.uniqueResult();
					}
				});
	}


	/**
	 * 根据角色id,得到物品对象列表
	 * @param id
	 * @return 物品对象列表
	 */
	public Object[] getItems(final String id) {
		return (Object []) getTemplate().doCall(
				new HibernateCallback<Object []>() {
					@Override
					public Object [] doCall(Session session) {
						Query query = session.getNamedQuery("getItems");
						query.setLong("id", Long.valueOf(id));
//						byte[] _info = (byte[]) query.uniqueResult();
//						return (Object[]) DataType.byte2obj(_info);
						return null;
					}
				});
	}

	/**
	 * 根据角色id,得到物品对象列表
	 * @param id
	 * @return 物品对象列表
	 */
	@SuppressWarnings("unchecked")
	public List<ItemEntity> getRoleItems(final String id) {
		return (List<ItemEntity>) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session.getNamedQuery("getStoreItems");
						query.setLong("id", Long.valueOf(id));
						return query.list();
					}
				});
	}

	/**
	 * 改变Item的状态
	 * @param id Item的id
	 * @return  改变成功,返回true;反之返回false;
	 */
	public int updateItem(final String id) {
		return (int) getTemplate().doCall(
				new HibernateCallback <Integer>() {
					@Override
					public Integer doCall(Session session) {
						Query query = session.getNamedQuery("updateItem");
						query.setLong("id", Long.valueOf(id));
						return query.executeUpdate();

					}
		});
	}

	/**
	 * 从大字段得到角色已完成的任务
	 * @param id 角色ID
	 * @return 角色已完成的任务
	 */
	public Object[] getFinishedTasks1(final String id) {
		return (Object []) getTemplate().doCall(
				new HibernateCallback<Object []>() {
					@Override
					public Object [] doCall(Session session) {
						Query query = session.getNamedQuery("getFinishedTasks1");
						query.setLong("id", Long.valueOf(id));
//						byte[] _info = (byte[]) query.uniqueResult();
//						return (Object[]) DataType.byte2obj(_info);
						return null;
					}
				});
	}

	/**
	 * 从t_finish_task得到角色已完成的任务
	 * @param id 角色ID
	 * @return 角色已完成的任务
	 */
	@SuppressWarnings("unchecked")
	public List getFinishedTasks2(final String charId) {
		return (List) getTemplate().doCall(
				new HibernateCallback<List>() {
					@Override
					public List doCall(Session session) {
						Query query = session.getNamedQuery("getFinishedTasks2");
						query.setLong("charId", Long.valueOf(charId));
						getPagerUtil().process(session, query);
						return query.list();
					}
				});
	}

	/**
	 * 得到角色进行的任务
	 * @param id 角色ID
	 * @return  角色进行的任务
	 */
	public Object[] getDoingTasks(final String id) {
		return (Object []) getTemplate().doCall(
				new HibernateCallback<Object []>() {
					@Override
					public Object [] doCall(Session session) {
						Query query = session.getNamedQuery("getDoingTasks");
						query.setLong("id", Long.valueOf(id));
//						byte[] _info = (byte[]) query.uniqueResult();
//						return (Object[]) DataType.byte2obj(_info);
						return null;
					}
				});
	}

//	/**
//	 * 得到角色的好友
//	 * @param id 角色ID
//	 * @return 角色的好友
//	 */
//	@SuppressWarnings("unchecked")
//	public List<FriendRelation> getFriends(final String id) {
//		return (List<FriendRelation>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session){
//						Query query = session.getNamedQuery("queryFriends");
//						query.setLong("roleUUID", Long.valueOf(id));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	}

//	/**
//	 * 得到角色的好友黑名单
//	 * @param id 角色ID
//	 * @return 角色的好友黑名单
//	 */
//	@SuppressWarnings("unchecked")
//	public List<FriendRelation> getBlacklists(final String id) {
//		return (List<FriendRelation>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session){
//						Query query = session.getNamedQuery("queryBlacklists");
//						query.setLong("roleUUID", Long.valueOf(id));
//						getPagerUtil().process(session, query);
//						return query.list();
//					}
//				});
//	 }

	/**
	 * 得到角色的Buff信息
	 * @param id 角色ID
	 * @return	角色的Buff信息
	 */
	public Object [] getBuffs(final String id) {
		return (Object []) getTemplate().doCall(
				new HibernateCallback<Object []>() {
					@Override
					public Object [] doCall(Session session) {
						Query query = session.getNamedQuery("getBuffs");
						query.setLong("id", Long.valueOf(id));
//						byte[] _info = (byte[]) query.uniqueResult();
//						return (Object[]) DataType.byte2obj(_info);
						return null;
					}
				});
	}

	/**
	 * 得到角色的副本信息
	 * @param id 角色ID
	 * @return	得到角色的副本信息
	 */
	public Object [] getRaids(final String id) {
		return (Object []) getTemplate().doCall(
				new HibernateCallback<Object []>() {
					@Override
					public Object [] doCall(Session session) {
						Query query = session.getNamedQuery("getRaids");
						query.setLong("id", Long.valueOf(id));
//						byte[] _info = (byte[]) query.uniqueResult();
//						return (Object[]) DataType.byte2obj(_info);
						return null;
					}
				});
	}

	/**
	 * 得到角色的师傅信息
	 * @param id 角色ID
	 * @return	得到角色的师傅信息
	 */
//	@SuppressWarnings("unchecked")
//	public List<RelationInfo> getMasterList(final String id) {
//		return (List<RelationInfo>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session){
//						Query query = session.getNamedQuery("queryMasters");
//						query.setLong("charId", Long.valueOf(id));
//						return query.list();
//					}
//				});
//	 }

	/**
	 * 得到角色的徒弟信息
	 * @param id 角色ID
	 * @return	得到角色的徒弟信息
	 */
//	@SuppressWarnings("unchecked")
//	public List<RelationInfo> getDiscipleList(final String id) {
//		return (List<RelationInfo>) getTemplate().doCall(
//				new HibernateCallback<List>() {
//					@Override
//					public List doCall(Session session){
//						Query query = session.getNamedQuery("queryDisciples");
//						query.setLong("charId", Long.valueOf(id));
//						return query.list();
//					}
//				});
//	 }

//	/**
//	 * 得到角色的交易平台账户
//	 * @param id
//	 * 		角色Id
//	 * @return
//	 * 		交易平台账户
//	 */
//	public ExchangeAccount getExchangeAccount(final String id) {
//		return (ExchangeAccount) getTemplate().doCall(
//				new HibernateCallback<ExchangeAccount>() {
//					@Override
//					public ExchangeAccount doCall(Session session){
//							Query query = session.getNamedQuery("searchExchangeAccount");
//							query.setLong("id", Long.valueOf(id));
//							return (ExchangeAccount)query.uniqueResult();
//					}
//				});
//	}

	/**
	 * 根据角色名获取角色信息
	 * @param name
	 * @return
	 */
	public HumanEntity getRoleByUserName(final String name) {
		return (HumanEntity) getTemplate().doCall(
				new HibernateCallback<HumanEntity>() {
					@Override
					public HumanEntity doCall(Session session){
						Query query = session.getNamedQuery("getRoleByUserName");
						query.setString("name", name);
						return (HumanEntity)query.uniqueResult();
					}
				});
	}

}
