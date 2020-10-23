package com.imop.lj.core.session;

import com.imop.lj.core.msg.IMessage;

/**
 * 封装会话的业务逻辑
 *
 *
 */
public interface ISession {

	/**
	 * 判断当前会话是否处于连接状态
	 *
	 * @return
	 */
	public boolean isConnected();

	/**
	 * @param msg
	 */
	public void write(IMessage msg);

	/**
	 *
	 */
	public void close(boolean immediately);

	/**
	 * 出现异常时是否关闭连接
	 *
	 * @return
	 */
	public boolean closeOnException();
}
