package com.imop.lj.core.orm;

import java.io.Serializable;


/**
 *
 *
 */
public interface IdGenerator {
	@SuppressWarnings("unchecked")
	public Serializable generateId(BaseEntity entity);
}