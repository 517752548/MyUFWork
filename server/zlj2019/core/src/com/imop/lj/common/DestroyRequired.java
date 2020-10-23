package com.imop.lj.common;

/**
 *  用完之后需要销毁的对象接口
 *
 */
public interface DestroyRequired {
	/**
	 * 销毁对象内容
	 */
	void destroy();

}
