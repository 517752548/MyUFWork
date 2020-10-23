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
public class SessionClosedMessage<T extends ISession> extends
		SysInternalMessage implements SessionMessage<T> {

	protected T session;

	public SessionClosedMessage(T sender) {
		super.setType(MessageType.SYS_SESSION_CLOSE);
		super.setTypeName("SYS_SESSION_CLOSE");
		this.session = sender;
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
		session.close(false);
	}

	@Override
	public String toString() {
		if(this.session == null){
			return "SessionClosedMessage " + session;
		}
		return "SessionClosedMessage " + session + " the session connected:" + this.session.isConnected();
	}
}
