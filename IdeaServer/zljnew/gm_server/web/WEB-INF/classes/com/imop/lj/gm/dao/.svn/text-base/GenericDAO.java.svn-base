package com.imop.lj.gm.dao;

import java.io.Serializable;

import org.hibernate.HibernateException;
import org.hibernate.SQLQuery;
import org.hibernate.Session;
import org.hibernate.Transaction;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.gm.page.IPaginationHelper;
import com.imop.lj.gm.service.LoginUserService;
import com.imop.lj.gm.service.db.DBFactoryService;
/**
 * GM游戏后台系统<br>
 * 基本 DAO，作为其他DAO的父类来提供通用的方法
 *
 * @author lin fan 2009-10-09
 */
public class GenericDAO {

	private static final  SessionConfigFactory DEFAULT = new SessionConfigFactory(){
		@Override
		public String getRegionId() {
			return LoginUserService.getLoginRegionId();
		}

		@Override
		public String getServerId() {
			return LoginUserService.getLoginServerId();
		}
	};

	/**dbFactoryService */
	private DBFactoryService dbFactoryService;

	/** TranHibernateTemplate */
	protected TranHibernateTemplate template;

	/** GenericDAO log*/
	private static final Logger logger = LoggerFactory.getLogger(GenericDAO.class);

	/** 分页工具 */
	private IPaginationHelper pagerUtil;

	public GenericDAO(){
		template = new TranHibernateTemplate(DEFAULT);
	}

	/**
	 *
	 * @param sessionConfigFactory
	 */
	public GenericDAO(SessionConfigFactory sessionConfigFactory){
		template = new TranHibernateTemplate(sessionConfigFactory);
	}


	public IPaginationHelper getPagerUtil() {
		return pagerUtil;
	}

	public void setPagerUtil(IPaginationHelper pagerUtil) {
		this.pagerUtil = pagerUtil;
	}

	public TranHibernateTemplate getTemplate() {
		return template;
	}

	public interface HibernateCallback<T> {
		public T doCall(Session session);
	}

	public DBFactoryService getDbFactoryService() {
		return dbFactoryService;
	}

	public void setDbFactoryService(DBFactoryService dbFactoryService) {
		this.dbFactoryService = dbFactoryService;
	}

	protected Session getSession(String regionId,String svrId) {
		return this.dbFactoryService.selectSessionFactory(regionId,svrId).openSession();
	}

	 /**
	 * 持久化一个对象到数据库中
	 *
	 * @param o
	 *            待持久化的对象
	 * @return 持久化后的id
	 */
	public Serializable save(final Object o) {
		return (Serializable) getTemplate().doCall(
				new HibernateCallback<Serializable>() {
					@Override
					public Serializable doCall(Session session) {
						return session.save(o);
					}
				});

	}

	 /**
	 * 持久化一个对象到数据库中
	 *
	 * @param o
	 *            待持久化的对象
	 * @return
	 * @return 持久化后的id
	 */
	public  Object saveOrUpdate(final Object o) {
		return (Object) getTemplate().doCall(
				new HibernateCallback <Object> () {
					@Override
					public Object doCall(Session session) {
					 session.saveOrUpdate(o);
					return null;
					}
				});

	}

	 /**
	 * 持久化一个对象到数据库中
	 *
	 * @param o
	 *            待持久化的对象
	 * @return 持久化后的id
	 */
	public Serializable merge(final Object o) {
		return (Serializable) getTemplate().doCall(
				new HibernateCallback<Serializable>() {
					@Override
					public Serializable doCall(Session session) {
						return (Serializable) session.merge(o);
					}
				});

	}
	 /**
	 * 持久化一个对象到数据库中
	 *
	 * @param o
	 *            待持久化的对象
	 * @return 持久化后的id
	 */
	public Serializable updateByHQL(final String hqlSql) {
		return (Serializable) getTemplate().doCall(
				new HibernateCallback<Serializable>() {
					@Override
					public Integer doCall(Session session) {
						int ret = session.createQuery(hqlSql).executeUpdate();
						return 	ret;
					}
				});

	}

	/**
	 * 得到表的记录
	 * @param hql 执行hql
	 * @return z
	 * @throws Exception
	 */
	public Object getRecordNum(final String sql) throws Exception{
		return (Object) getTemplate().doCall(
				new HibernateCallback<Object>() {
					@Override
					public Object doCall(Session session) {
					    SQLQuery sqlQuery = session.createSQLQuery(sql);
						return 	sqlQuery.uniqueResult();
					}
		});
	}

	/**
	 * 执行hql
	 * @param hql
	 * @return z
	 * @throws Exception
	 */
	public Integer delete(final String hql) throws Exception{
		return (Integer) getTemplate().doCall(
				new HibernateCallback<Integer>() {
					@Override
					public Integer doCall(Session session) {
						int ret = session.createQuery(hql).executeUpdate();
						return 	ret;
					}
		});
	}
	  /**
     * 根据ID从数据库中取出记录并映射成对象
     *
     * @param <T> 对应的泛型
     * @param class1 class类型
     * @param id 指定的ID
     * @return 对应的对象，如果未能发现符合条件的记录，方法会抛出一个ObejctNotFoundException
     */
    @SuppressWarnings("unchecked")
    public <T> T loadById(final Class<T> clazz , final int id) {
    	return (T) getTemplate().doCall(
				new HibernateCallback<T>() {
					@Override
					public T doCall(Session session) {
						return(T) session.load(clazz, id);
					}
				});

    }

    /**
     * 根据ID从数据库中取出记录并映射成对象
     *
     * @param <T> 对应的泛型
     * @param class1 class类型
     * @param id 指定的ID
     * @return 对应的对象，如果未能发现符合条件的记录，方法会抛出一个ObejctNotFoundException
     */
    @SuppressWarnings("unchecked")
    public <T, ID extends Serializable> T getById(final Class<T> clazz , final ID id) {
    	return (T) getTemplate().doCall(
				new HibernateCallback<T>() {
					@Override
					public T doCall(Session session) {
						return(T) session.get(clazz, id);
					}
				});

    }


    /**
     * 根据ID从数据库中取出记录并映射成对象
     *
     * @param <T> 对应的泛型
     * @param class1 class类型
     * @param id 指定的ID
     * @return 对应的对象，如果未能发现符合条件的记录，方法会抛出一个ObejctNotFoundException
     */
    @SuppressWarnings("unchecked")
    public <T> T getById(final Class<T> clazz , final int id) {
    	return (T) getTemplate().doCall(
				new HibernateCallback<T>() {
					@Override
					public T doCall(Session session) {
						return(T) session.get(clazz, id);
					}
				});

    }

    /**
     * 删除一个对象
     *
     * @param o 待删除的对象
     */
    public boolean delete(final Object o) {
    	return (boolean) getTemplate().doCall(
				new HibernateCallback <Boolean>() {
					@Override
					public Boolean doCall(Session session){
						 session.delete(o);
						 return true;
					}
				});
    }

    public static interface SessionConfigFactory{
    	public String getRegionId();
    	public String getServerId();
    }

    /**
     * 重写HibernamteTemplate模板,提供通用的获取session以及事物处理方法
     * @author linfan
     *
     */
	public final class TranHibernateTemplate implements HibernateTemplate {
		private final SessionConfigFactory sessionConfigFactory;
		/**
		 * @param sessionConfigFactory
		 */
		public TranHibernateTemplate(SessionConfigFactory sessionConfigFactory) {
			this.sessionConfigFactory = sessionConfigFactory;
		}

		@Override
		public <T> T doCall(HibernateCallback<T> callback) {
			Session _session = null;
			Transaction _tr = null;
			T _result = null;
			try {
				_session = getSession(sessionConfigFactory.getRegionId(),sessionConfigFactory.getServerId());
				_tr = _session.beginTransaction();
				_result = (T) callback.doCall(_session);
				_tr.commit();
			}catch(HibernateException e){
				if (_tr != null) {
					_tr.rollback();
				}
				logger.error("session",e);
				System.out.println(e.getMessage());
				e.printStackTrace();

			}catch (Exception e) {
				e.printStackTrace();
				if (_tr != null) {
					_tr.rollback();
				}
				logger.error("session",e);
				throw new RuntimeException(e);
			} finally {
				if (_session != null) {
					_session.close();
				}
			}
			return _result;
		}
	}

}
