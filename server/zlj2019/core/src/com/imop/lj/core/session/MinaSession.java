package com.imop.lj.core.session;

import org.apache.mina.core.session.IoSession;

import com.imop.lj.common.StatisticsLoggerHelper;
import com.imop.lj.core.msg.BaseMinaMessage;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.ISliceMessage;

/**
 * mina会话，封装了mina原生的<code>IoSession</code>，以及其他一些 应用程序自定义的业务逻辑
 *
 */
public abstract class MinaSession implements ISession {
	protected volatile IoSession session;

	public MinaSession(IoSession s) {
		session = s;
	}

	@Override
	public boolean isConnected() {
		if (session != null) {
			return session.isConnected();
		}
		return false;
	}

	@SuppressWarnings({ "unchecked", "rawtypes" })
	@Override
	public void write(IMessage msg) {
		if (session != null) {
			if(msg instanceof ISliceMessage){
				final ISliceMessage<BaseMinaMessage> _slices = (ISliceMessage<BaseMinaMessage>) msg;
				for(final BaseMinaMessage _msg:_slices.getSliceMessages()){
					// 统计消息数据
					StatisticsLoggerHelper.logMessageSent(msg);
					session.write(_msg);
				}
			}else{
				StatisticsLoggerHelper.logMessageSent(msg);
				session.write(msg);
			}
		}
	}

	@Override
	public void close(boolean immediately) {
		if (session != null) {
			session.close(immediately);
		}
	}

	public IoSession getIoSession(){
		return session;
	}

	public boolean closeOnException() {
		// TODO Auto-generated method stub
		return true;
	}

}
