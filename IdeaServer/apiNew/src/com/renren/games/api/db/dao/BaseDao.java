package com.renren.games.api.db.dao;

import java.io.Serializable;

import com.renren.games.api.db.DBService;
import com.renren.games.api.db.DataAccessException;
import com.renren.games.api.db.SoftDeleteEntity;
import com.renren.games.api.db.model.BaseEntity;

/**
 * 基础的
 * 
 * @param <E>
 *            实体的类型
 */
@SuppressWarnings({ "rawtypes", "deprecation" })
public abstract class BaseDao<E extends BaseEntity<?>> {

	/** 数据库服务 */
	protected final DBService dbService;

	public BaseDao(DBService dbService) {
		this.dbService = dbService;
	}

	/**
	 * 保存一个实体
	 * 
	 * @param obj
	 * @exception DataAccessException
	 */
	public Serializable save(E obj) {
		return this.dbService.save(obj);
	}

	public DBService getDbService() {
		return dbService;
	}
	
	public void saveOrUpdate(E obj) {
		this.dbService.saveOrUpdate(obj);
	}

	/**
	 * 更新一个实体
	 * 
	 * @param obj
	 * @exception DataAccessException
	 */
	public void update(E obj) {
		this.dbService.update(obj);
	}
	
	/**
	 * 检查数据库
	 */
	public void check(){
		this.dbService.check();
	}

	/**
	 * 删除一个实体
	 * 
	 * @param obj
	 * @exception DataAccessException
	 */
	public void delete(E obj) {
		if (obj instanceof SoftDeleteEntity) {
			this.dbService.softDelete((SoftDeleteEntity) obj);
		} else {
			this.dbService.delete(obj);
		}
	}

	/**
	 * 根据指定类型的指定ID的实体
	 * 
	 * @param entityClass
	 * @param id
	 */

	public void delete(Class<? extends BaseEntity> entityClass, java.io.Serializable id) {
		this.dbService.deleteById(entityClass, id);
	}

	/**
	 * 根据主键获取一个实体
	 * 
	 * @param id
	 * @exception DataAccessException
	 * @return
	 */
	public E get(java.io.Serializable id) {
		return this.dbService.get(this.getEntityClass(), id);
	}

	/**
	 * 根据指定类型的指定ID查询实体
	 * 
	 * @param entityClass
	 * @param id
	 * @return
	 */
	public Object get(Class<? extends BaseEntity<Serializable>> entityClass, Serializable id) {
		return this.dbService.get(entityClass, id);
	}

	/**
	 * 取得该Dao所操作的对象类型
	 * 
	 * @return
	 */
	protected abstract Class<E> getEntityClass();
}