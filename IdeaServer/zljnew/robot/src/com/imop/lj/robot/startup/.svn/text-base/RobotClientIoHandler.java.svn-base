package com.imop.lj.robot.startup;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.core.constants.SessionAttrKey;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.server.AbstractIoHandler;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.msg.RobotClientSessionClosedMsg;
import com.imop.lj.robot.msg.RobotClientSessionOpenedMsg;

public class RobotClientIoHandler extends AbstractIoHandler<RobotClientSession>{


	@Override
	public void sessionOpened(IoSession session) {
		if (Robot.robotLogger.isDebugEnabled()) {
			Robot.robotLogger.debug("Session opened");
		}
		curSessionCount++;
		RobotClientSession s = this.createSession(session);
		session.setAttribute(SessionAttrKey.ISESSION, s);
		IMessage msg = new RobotClientSessionOpenedMsg(s);
		msgProcessor.put(msg);
	}

	@Override
	public void sessionClosed(IoSession session) {
		if (Robot.robotLogger.isDebugEnabled()) {
			Robot.robotLogger.debug("Session closed");
		}
		curSessionCount--;
		RobotClientSession ms = (RobotClientSession) session.getAttribute(SessionAttrKey.ISESSION);
		if (ms == null) {
			return;
		}
		session.setAttribute(SessionAttrKey.ISESSION, null);
		IMessage msg = new RobotClientSessionClosedMsg(ms);
		msgProcessor.put(msg);
	}


	@Override
	protected RobotClientSession createSession(IoSession session) {
		return new RobotClientSession(session);
	}


}
