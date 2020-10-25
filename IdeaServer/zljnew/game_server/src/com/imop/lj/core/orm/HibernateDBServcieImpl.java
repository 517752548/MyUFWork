package com.imop.lj.core.orm;

import java.io.Serializable;
import java.net.URL;
import java.util.Collection;
import java.util.List;

import org.hibernate.Query;
import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.hibernate.Transaction;
import org.hibernate.cfg.AnnotationConfiguration;
import org.hibernate.cfg.Configuration;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.probe.PIProbeCollector;
import com.imop.lj.probe.PIProbeConstants.ProbeName;
import com.opi.gibp.probe.category.ProcessResult;

/**
 * 基于Hibernate实现的DBService
 * 
 * 
 */
@SuppressWarnings("unchecked")
public class HibernateDBServcieImpl implements DBService {
	private static final Logger logger = LoggerFactory.getLogger("zlj.db.hibernate");
	private final SessionFactory sessionFactory;
	private final HibernamteTemplate transTemplate = new TranHibernateTemplate();
	/** 事件监听器 */
	private final IEventListener eventListener;
	/** 检查数据库连接是否正常的SQL */
	private final static String DB_CHECK_SQL = "select 1 ";
	
	private final String mainDatabaseName;
	
	private final String logDatabaseName;
	
	/**
	 * 构建一个无事件监听器的HibernateDBServiceImpl
	 * 
	 * @param hibernateCfgXmlUrl
	 *            hibernate.cfg.xml的URL
	 * @param resourceNames
	 *            额外的Hibernate
	 *            Mapping配置文件(如定义查询的配置,以及单独的mapping文件等),这些资源需要在classpath中可以找到
	 */
	public HibernateDBServcieImpl(URL hibernateCfgXmlUrl, String... resourceNames) {
		this(null, hibernateCfgXmlUrl, resourceNames);
	}

	/**
	 * 构建一个HibernateDBServiceImpl
	 * 
	 * @param eventListener
	 *            事件监听器,可以为空
	 * @param hibernateCfgXmlUrl
	 *            hibernate.cfg.xml的URL
	 * @param resourceNames
	 *            额外的Hibernate
	 *            Mapping配置文件(如定义查询的配置,以及单独的mapping文件等),这些资源需要在classpath中可以找到
	 */
	public HibernateDBServcieImpl(IEventListener eventListener, URL hibernateCfgXmlUrl, String... resourceNames) {
		Configuration cfg = new AnnotationConfiguration().configure(hibernateCfgXmlUrl);
		if (resourceNames != null) {
			for (String _resourceName : resourceNames) {
				cfg.addResource(_resourceName);
			}
		}
		sessionFactory = cfg.buildSessionFactory();
		this.eventListener = eventListener;
		
		this.mainDatabaseName = this.getDatabaseName(cfg);
		this.logDatabaseName = this.mainDatabaseName + "_log";
		logger.info("+++++++++++DataBase : " + mainDatabaseName + ";" + "LogDataBase: " + logDatabaseName + "+++++++++++");
	}

	@Override
	public <T extends BaseEntity> T get(final Class<T> entityClass, final Serializable id) throws DataAccessException {
		return transTemplate.doCall(new HibernateCallback<T>() {
			@Override
			public T doCall(Session session) {
				return (T) session.get(entityClass, id);
			}
		});
	}

	@Override
	public Serializable save(final BaseEntity entity) throws DataAccessException {
		return transTemplate.doCall(new HibernateCallback<Serializable>() {
			@Override
			public Serializable doCall(Session session) {
				return session.save(entity);
			}
		});
	}

	@Override
	public void update(final BaseEntity entity) throws DataAccessException {
		transTemplate.doCall(new HibernateCallback<Object>() {
			@Override
			public Object doCall(Session session) {
				session.update(entity);
				return null;
			}
		});

	}

	@Override
	public void delete(final BaseEntity entity) throws DataAccessException {
		transTemplate.doCall(new HibernateCallback<Void>() {
			@Override
			public Void doCall(Session session) {
				session.delete(entity);
				return null;
			}
		});
	}

	@Override
	public void deleteById(Class<? extends BaseEntity> entityClass, final Serializable id) {
		final String _className = entityClass.getSimpleName();
		final String _sql = String.format("delete from %s where id=?", _className);
		transTemplate.doCall(new HibernateCallback<Void>() {
			@Override
			public Void doCall(Session session) {
				Query _query = session.createQuery(_sql);
				_query.setParameter(0, id);
				_query.executeUpdate();
				return null;
			}
		});

	}

	@Override
	public void softDelete(final SoftDeleteEntity entity) throws DataAccessException {
		final String _className = entity.getClass().getSimpleName();
		final String _sql = String.format("update %s e set e.deleted =?, e.deleteDate = NOW() where e.id=?", _className);
		transTemplate.doCall(new HibernateCallback<Void>() {
			@Override
			public Void doCall(Session session) {
				Query _query = session.createQuery(_sql);
				_query.setParameter(0, SoftDeleteEntity.DELETED);
				_query.setParameter(1, entity.getId());
				_query.executeUpdate();
				return null;
			}
		});
	}

	@Override
	public void softDeleteById(final Class<? extends SoftDeleteEntity> entityClass, final Serializable id) throws DataAccessException {
		final String _className = entityClass.getSimpleName();
		final String _sql = String.format("update %s e set e.deleted =?, e.deleteDate = NOW() where e.id=?", _className);
		transTemplate.doCall(new HibernateCallback<Void>() {
			@Override
			public Void doCall(Session session) {
				Query _query = session.createQuery(_sql);
				_query.setParameter(0, SoftDeleteEntity.DELETED);
				_query.setParameter(1, id);
				_query.executeUpdate();
				return null;
			}
		});
	}

	@Override
	public List findByNamedQuery(final String queryName) throws DataAccessException {
		return findByNamedQueryAndNamedParam(queryName, null, null);
	}

	@Override
	public List findByNamedQueryAndNamedParam(final String queryName, final String[] paramNames, final Object[] values) throws DataAccessException {
		return findByNamedQueryAndNamedParam(queryName, paramNames, values, -1, -1);
	}

	@Override
	public List findByNamedQueryAndNamedParam(final String queryName, final String[] paramNames, final Object[] values, final int maxResult,
			final int start) throws DataAccessException {
		if (arrayLength(paramNames) != arrayLength(values)) {
			throw new IllegalArgumentException("The paramNames length != values length");
		}
		return transTemplate.doCall(new HibernateCallback<List>() {
			@Override
			public List doCall(Session session) {
				Query _query = session.getNamedQuery(queryName);
				if (maxResult > -1) {
					_query.setMaxResults(maxResult);
				}
				if (start > -1) {
					_query.setFirstResult(start);
				}
				prepareQuery(paramNames, values, _query);
				return _query.list();
			}
		});
	}

	@Override
	public int queryForUpdate(final String queryName, final String[] paramNames, final Object[] values) throws DataAccessException {
		if (arrayLength(paramNames) != arrayLength(values)) {
			throw new IllegalArgumentException("The paramNames length != values length");
		}
		return transTemplate.doCall(new HibernateCallback<Integer>() {
			@Override
			public Integer doCall(Session session) {
				Query _query = session.getNamedQuery(queryName);
				prepareQuery(paramNames, values, _query);
				return _query.executeUpdate();
			}
		});
	}

	/**
	 * 直接执行指定的callback方法
	 * 
	 * @param callback
	 * @throws DataAccessException
	 */
	public <T> T call(final HibernateCallback<T> callback) throws DataAccessException {
		return transTemplate.doCall(callback);
	}

	@Override
	public void saveOrUpdate(final BaseEntity entity) throws DataAccessException {
		this.transTemplate.doCall(new HibernateCallback<Void>() {
			@Override
			public Void doCall(Session session) {
				session.saveOrUpdate(entity);
				return null;
			}
		});
	}

	/**
	 * 取得数组的长度
	 * 
	 * @param arrays
	 * @return
	 */
	private int arrayLength(Object[] arrays) {
		return arrays == null ? -1 : arrays.length;
	}

	private void prepareQuery(final String[] paramNames, final Object[] values, Query query) {
		for (int i = 0; paramNames != null && i < paramNames.length; i++) {
			if (values[i] instanceof Collection) {
				query.setParameterList(paramNames[i], (Collection) values[i]);
			} else {
				query.setParameter(paramNames[i], values[i]);
			}
		}
	}

	public interface HibernateCallback<T> {
		public T doCall(Session session);
	}

	private interface HibernamteTemplate {
		public <T> T doCall(HibernateCallback<T> callback);
	}

	private final class TranHibernateTemplate implements HibernamteTemplate {
		@Override
		public <T> T doCall(HibernateCallback<T> callback) {
			Session _session = null;
			Transaction _tr = null;
			T _result = null;
			Exception _e = null;
			final long _begin = System.nanoTime();
			try {
				_session = sessionFactory.openSession();
				_tr = _session.beginTransaction();
				_result = callback.doCall(_session);
				_tr.commit();
			} catch (Exception e) {
				_e = e;
				if (_tr != null) {
					_tr.rollback();
				}
				throw new DataAccessException(e);
			} finally {
				try {
					if (_session != null) {
						_session.close();
					}
				} finally {
					// 在这里触发事件通知,避免影响连接的释放
					if (_e != null) {
						// DB处理失败采集
						PIProbeCollector.collect(ProbeName.DB, ProcessResult.FAIL, (System.nanoTime() - _begin) / 1000000);
						try {
							if (eventListener != null) {
								eventListener.fireEvent(new DBAccessEvent(DBAccessEvent.Type.ERROR, _e.getMessage()));
							}
						} catch (Exception le) {
							if (logger.isErrorEnabled()) {
								logger.error("Trigger event fail", le);
							}
						}
					} else {
						// DB处理成功采集
						PIProbeCollector.collect(ProbeName.DB, ProcessResult.SUCCESS, (System.nanoTime() - _begin) / 1000000);
					}
				}
			}
			return _result;
		}
	}

	@Override
	public void check() {
		transTemplate.doCall(new HibernateCallback<List>() {
			@Override
			public List doCall(Session session) {
				Query _query = session.createSQLQuery(DB_CHECK_SQL);
				return _query.list();
			}
		});
	}

	@Override
	public void saveAll(List<BaseEntity> entityList) throws DataAccessException {
		throw new UnsupportedOperationException();
	}
	
	
	private String getDatabaseName(Configuration cfg){
		String url = cfg.getProperty("hibernate.connection.url");
		int index = url.lastIndexOf("/");
		int lastIndex = url.lastIndexOf("?");
		String databaseName = "";
		if(lastIndex != -1){
			databaseName = url.substring(index + 1, lastIndex);
		}else{
			databaseName = url.substring(index + 1);
		}
		return databaseName;
	}

	public String getMainDatabaseName() {
		return mainDatabaseName;
	}

	public String getLogDatabaseName() {
		return logDatabaseName;
	}
}