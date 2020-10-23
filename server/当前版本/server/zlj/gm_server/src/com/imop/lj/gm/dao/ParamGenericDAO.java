package com.imop.lj.gm.dao;

import java.io.Serializable;
import java.sql.Timestamp;
import java.util.List;

import org.hibernate.Query;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.transform.Transformers;

import com.imop.lj.db.model.HumanEntity;
import com.imop.lj.db.model.PrizeInfo;
import com.imop.lj.gm.dao.GenericDAO.HibernateCallback;
import com.imop.lj.gm.model.SysUser;
import com.imop.lj.gm.model.notice.GameNotice;
import com.imop.lj.gm.model.notice.TimeNotice;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.maintenance.UserPrizeAllService;

/**
 *
 * 需要传递regionId和serverId参数DAO
 *
 *
 */
public class ParamGenericDAO extends GenericDAO {

	/** 大区ID */
	private String rId;

	/** 服务器ID */
	private String sId;


	public String getRId() {
		return rId;
	}
	public void setRId(String id) {
		rId = id;
	}
	public String getSId() {
		return sId;
	}
	public void setSId(String id) {
		sId = id;
	}

	private  final SessionConfigFactory s = new SessionConfigFactory() {
		@Override
		public String getRegionId() {
			return getRId();
		}

		@Override
		public String getServerId() {
			return getSId();
		}
	};

	public ParamGenericDAO() {
		template = new TranHibernateTemplate(s);
	}
	/**
	 * 根据大区ID,服务器ID
	 *
	 * @param o
	 *            待持久化的对象
	 * @return 对象持久化后的id
	 */
	public Serializable saveObject(final Object o) {
		return (Serializable) getTemplate().doCall(
				new HibernateCallback<Serializable>() {
					@Override
					public Serializable doCall(Session session) {
						return session.save(o);
					}
				});
	}
	/**
	 * 根据大区ID,服务器ID
	 *
	 * @param o
	 *            待持久化的对象
	 * @return 对象持久化后的id
	 */
	public Serializable updateObject(final Object o) {
		return (Serializable) getTemplate().doCall(
				new HibernateCallback<Serializable>() {
					@Override
					public Serializable doCall(Session session) {
						session.update(o);
						return null;
					}
				});
	}
	/**
	 * 查询所有有效的游戏公告
	 *
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<GameNotice> getValidGameNoticeList() {
		return (List) getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List doCall(Session session) {
				Query query = session.getNamedQuery("getGameNoticeList");
				return query.list();
			}
		});
	}

	/**
	 * 得到S1服数据库版本号
	 *
	 * @return S1服数据库版本号
	 */
	public String getDBVersion() {
		return (String) getTemplate().doCall(new HibernateCallback<String>() {
			@Override
			public String doCall(Session session) {
				Query query = session.getNamedQuery("getDBVersion");
				return (String) query.uniqueResult();
			}
		});
	}

	/**
	 * 得到S1服定时公告数量
	 *
	 * @return 定时公告数量
	 */
	public long getS1TimeNoticeNum() {
		return (Long) getTemplate().doCall(new HibernateCallback<Long>() {
			@Override
			public Long doCall(Session session) {
				Query query = session.getNamedQuery("getTimeNoticeNum");
				return (Long) query.uniqueResult();
			}
		});
	}

	/**
	 * 得到S1服游戏公告数量
	 *
	 * @return 游戏公告数量
	 */
	public long getS1GameNoticeNum() {
		return (Long) getTemplate().doCall(new HibernateCallback<Long>() {
			@Override
			public Long doCall(Session session) {
				Query query = session.getNamedQuery("getGameNoticeNum");
				return (Long) query.uniqueResult();
			}
		});
	}

	/**
	 * 根据大区ID,服务器ID 删除所有的游戏公告
	 *
	 * @return
	 */
	public int delALLGameNotices() {
		return (Integer) getTemplate().doCall(new HibernateCallback<Integer>() {
			@Override
			public Integer doCall(Session session) {
				Query query = session.getNamedQuery("delALLGameNotices");
				return query.executeUpdate();
			}
		});
	}

//	/**
//	 * 根据用户名称查询用户对象
//	 *
//	 * @param u
//	 *            用户名称
//	 * @return SysUser
//	 * @throws Exception
//	 */
//	public SysUser getSysUser(final String u, final String regionId) {
//
//		return (SysUser) getTemplate().doCall(new HibernateCallback<SysUser>() {
//			@Override
//			public SysUser doCall(Session session) {
//				Query query = session.getNamedQuery("getSysUser");
//				query.setString("username", u);
//				query.setString("regionId", regionId);
//				return (SysUser) query.uniqueResult();
//			}
//		});
//	}
	
	@SuppressWarnings("unchecked")
	public List<SysUser> getSysUserNoRegion(final String u) {

		return (List) getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List doCall(Session session) {
				Query query = session.getNamedQuery("searchSysUserByName");
				query.setString("username", u);
				return query.list();
			}
		});
	}

	/**
	 * 根据大区ID,服务器ID 删除所有的定时公告
	 *
	 * @return
	 *
	 * @return
	 */
	public Integer delALLTimeNotices() {
		return (Integer) getTemplate().doCall(new HibernateCallback<Integer>() {
			@Override
			public Integer doCall(Session session) {
				Query query = session.getNamedQuery("delALLTimeNotice");
				return query.executeUpdate();
			}
		});
	}

	/**
	 * 根据大区ID,服务器ID 查询所有的定时公告
	 *
	 * @return 定时公告列表
	 */
	@SuppressWarnings("unchecked")
	public List<TimeNotice> getTimeNotices() {
		return (List) getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List doCall(Session session) {
				Query query = session.getNamedQuery("getAllTimeNoticeList");
				return query.list();
			}
		});
	}

	/**
	 * 查询所有有效的定时公告
	 *
	 * @return
	 */
	@SuppressWarnings("unchecked")
	public List<TimeNotice> getValidTimeNoticeList() {
		return (List) getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List doCall(Session session) {
				Query query = session.getNamedQuery("getValidTimeNoticeList");
				return query.list();
			}
		});
	}

	/**
	 * 根据大区ID,服务器ID 删除所有的礼包
	 *
	 * @return
	 */
	public Integer delALLPrizes() {
		return (Integer) getTemplate().doCall(new HibernateCallback<Integer>() {
			@Override
			public Integer doCall(Session session) {
				Query query = session.getNamedQuery("delALLPrizes");
				return query.executeUpdate();
			}
		});
	}
	/**
	 * 根据大区ID,服务器ID 删除所有brosorul列表
	 *
	 * @return
	 */
	public Integer delALLBrosorUrl() {
		return (Integer) getTemplate().doCall(new HibernateCallback<Integer>() {
			@Override
			public Integer doCall(Session session) {
				Query query = session.getNamedQuery("delALLBroserList");
				return query.executeUpdate();
			}
		});
	}

	/**
	 * 根据大区ID,服务器ID 查询所有的礼包
	 *
	 * @return 礼包列表
	 */
	@SuppressWarnings("unchecked")
	public List<PrizeInfo> getPrizes() {
		return (List) getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List doCall(Session session) {
				Query query = session.getNamedQuery("getPrizeList");
				return query.list();
			}
		});
	}
//	/**
//	 * 根据大区ID,服务器ID 所有brosorurl
//	 *
//	 * @return brosorurl列表
//	 */
//	@SuppressWarnings("unchecked")
//	public List<BroserEntity> getAllBroserList() {
//		return (List) getTemplate().doCall(new HibernateCallback<List>() {
//			@Override
//			public List doCall(Session session) {
//				Query query = session.getNamedQuery("getAllBroserList");
//				return query.list();
//			}
//		});
//	}

	/**
	 * 返回 logTypeList
	 *
	 * @return List
	 */
	@SuppressWarnings("unchecked")
	public List getLogNameList() {
		return (List) getTemplate().doCall(new HibernateCallback<List>() {
			@Override
			public List doCall(Session session) {
				String sql = "select distinct log_table,log_desc,log_type from reason_list";
				SQLQuery query = session.createSQLQuery(sql);
				return query.list();
			}
		});
	}

	/**
	 * 得到发奖礼包数量
	 *
	 * @return 得到发奖礼包数量
	 */
	public long getPrizeNum() {
		return (long) getTemplate().doCall(new HibernateCallback<Long>() {
			@Override
			public Long doCall(Session session) {
				Query query = session.getNamedQuery("getPrizeNum");
				return (Long) query.uniqueResult();
			}
		});
	}

	/**
	 * 得到活动数量
	 *
	 * @return 得到活动数量
	 */
	public long getActNum() {
		return (long) getTemplate().doCall(new HibernateCallback<Long>() {
			@Override
			public Long doCall(Session session) {
				Query query = session.getNamedQuery("getActNum");
				return (Long) query.uniqueResult();
			}
		});
	}

	/**
	 * 是否存在该账号
	 *
	 * @param passID
	 * @return
	 */
	public boolean isExistPassportId(final String passID) {
		return (Boolean) getTemplate().doCall(new HibernateCallback<Boolean>() {
			@Override
			public Boolean doCall(Session session) {
				Query query = session.getNamedQuery("searchUserInfoById");
				query.setLong("id", Long.valueOf(passID));
				return query.uniqueResult() != null;
			}
		});
	}
	/**
	 * 是否存在该角色名
	 *
	 * @param roleName
	 * @return
	 */
	public boolean isExistRoleName(final String roleName) {
		return (Boolean) getTemplate().doCall(new HibernateCallback<Boolean>() {
			@Override
			public Boolean doCall(Session session) {
				Query query = session.getNamedQuery("getRoleByUserName");
				query.setString("name", roleName);
				return query.uniqueResult() != null;
			}
		});
	}
	/**
	 * 设置GM数据库中的模板ID
	 *
	 * @return
	 */
	public int changeTemplateServer(final String serverID) {
		return (Integer) getTemplate().doCall(new HibernateCallback<Integer>() {
			@Override
			public Integer doCall(Session session) {
				StringBuffer sql = new StringBuffer();
				sql.append("update t_server_template set serverId =" + serverID + " where regionId=1");
				SQLQuery query = session.createSQLQuery(sql.toString());
				return (Integer) query.executeUpdate();
			}
		});
	}
	/**
	 * 从GM数据库中获取同步的模板库ID
	 *
	 * @return
	 */
	public Integer getTemplateDBID() {
		return (Integer) getTemplate().doCall(new HibernateCallback<Integer>() {
			//TODO 根据不同的region获取相应的模板template id
			@Override
			public Integer doCall(Session session) {
				StringBuffer sql = new StringBuffer();
				sql.append("select serverId from t_server_template where regionId=1");
				SQLQuery query = session.createSQLQuery(sql.toString());
				return (Integer) query.uniqueResult();
			}
		});
	}
	
	public List<HumanEntity> getAllTineyHumanEntity(final Timestamp timestamp) {
		return (List<HumanEntity>) getTemplate().doCall(
				new HibernateCallback<List<HumanEntity>>() {
					@Override
					public List<HumanEntity> doCall(Session session) {

						StringBuffer sql = new StringBuffer();
						sql.append("select * from t_character_info where lastLoginTime > :sevenDay or level >= " + UserPrizeAllService.AllPrizeLevelMin);
						
						SQLQuery query = session.createSQLQuery(sql.toString());
						query.setDate("sevenDay", timestamp);
						query.setResultSetMapping("queryHumanEntity");
						
						query.setResultTransformer(Transformers
								.aliasToBean(HumanEntity.class));
						return query.list();
					}
				});
	}
}
