package com.renren.games.api.db;

import com.renren.games.api.db.model.BaseEntity;


/**
 * 可持久化的业务对象实现此接口
 *
 * @param <IdType>
 *            主键类型
 * @param <T>
 *            对应的实体类型
 *
 */
public interface PersistanceObject<IdType extends java.io.Serializable, T extends BaseEntity<IdType>> {

	/**
	 * 将业务对象转为实体对象
	 *
	 * @return
	 */
	T toEntity();

	/**
	 * 从实体对象转换到业务对象
	 */
	void fromEntity(T entity);

}
