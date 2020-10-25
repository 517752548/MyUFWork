package com.imop.lj.core.server;

import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.util.CommonUtil;

/**
 * 可自执行的消息处理器
 *
 *
 */
public class ExecutableMessageHandler implements IMessageHandler<IMessage> {
	@Override
	public void execute(IMessage message) {
		try {
			message.execute();
		} catch (Exception e) {
			e.printStackTrace();
			Loggers.msgLogger.error(CommonErrorLogInfo.MSG_PRO_ERR_EXP,message == null ? "" : message.toString());
			Loggers.msgLogger.error(CommonErrorLogInfo.MSG_PRO_ERR_EXP, CommonUtil.exceptionToString(e));
		}
	}

	@Override
	public short[] getTypes() {
		return null;
	}
}
