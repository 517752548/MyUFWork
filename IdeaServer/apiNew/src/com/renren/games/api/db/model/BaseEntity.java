package com.renren.games.api.db.model;

import java.io.Serializable;

/**
 * 基础的实体接口
 *
 *
 * @param <ID>
 */
public interface BaseEntity<ID extends Serializable> extends Serializable {
	public abstract ID getId();

	public abstract void setId(ID id);
}