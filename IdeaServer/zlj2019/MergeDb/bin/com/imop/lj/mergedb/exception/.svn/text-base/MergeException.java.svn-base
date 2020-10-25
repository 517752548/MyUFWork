package com.imop.lj.mergedb.exception;

import java.io.Serializable;

/**
 * 合服错误
 *
 */
public class MergeException extends RuntimeException {

	/** */
	private static final long serialVersionUID = 1L;

	/**
	 *
	 * @param tableName 表名
	 * @param id 对应ID
	 * @param errorInfo 错误信息
	 */
	public MergeException(String tableName, Serializable id,
			String errorInfo) {
		super(String.format("[%s][id=%d]%s", tableName, id, errorInfo));
	}
	
	public MergeException(Serializable id,
			String errorInfo) {
		super(String.format("[id=%s]%s", id.toString(), errorInfo));
	}
}
