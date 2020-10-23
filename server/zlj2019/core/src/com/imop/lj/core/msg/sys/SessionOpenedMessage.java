package com.imop.lj.core.msg.sys;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.core.msg.SessionMessage;
import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.core.session.ISession;

/**
 *
 * @param <T>
 *
 */
public class SessionOpenedMessage<T extends ISession> extends
		SysInternalMessage implements SessionMessage<T> {

	protected T session;

	public SessionOpenedMessage(T session) {
		super.setType(MessageType.SYS_SESSION_OPEN);
		super.setTypeName("SYS_SESSION_OPEN");
		this.session = session;
	}

	@Override
	public T getSession() {
		return this.session;
	}

	public void setSession(T session) {
		this.session = session;
	}

	@Override
	public void execute() {
	}

	@Override
	public String toString() {
		return "SessionOpenedMessage";
	}
}
