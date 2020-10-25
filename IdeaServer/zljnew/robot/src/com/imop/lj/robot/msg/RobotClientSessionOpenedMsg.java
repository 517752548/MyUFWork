package com.imop.lj.robot.msg;

import com.imop.lj.core.msg.sys.SessionOpenedMessage;
import com.imop.lj.robot.startup.IRobotClientSession;

public class RobotClientSessionOpenedMsg extends SessionOpenedMessage<IRobotClientSession>{

	public RobotClientSessionOpenedMsg(IRobotClientSession session) {
		super(session);
	}

	@Override
	public void execute() {

	}
}
