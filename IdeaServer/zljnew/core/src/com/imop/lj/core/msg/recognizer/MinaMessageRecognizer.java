package com.imop.lj.core.msg.recognizer;

import org.apache.mina.core.buffer.IoBuffer;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.MessageParseException;
import com.imop.lj.core.msg.MessageType;
import com.imop.lj.core.msg.special.PolicyMessage;
import com.imop.lj.core.msg.special.QQTGWMessage;
import com.imop.lj.core.msg.sys.UnknownMessage;

public abstract  class MinaMessageRecognizer implements IMessageRecognizer {

	@Override
	public IMessage recognize(IoBuffer buf) throws MessageParseException {
		// 长度尚不足，确保可读长度超过4字节
		if(buf.remaining() < IMessage.MIN_MESSAGE_LENGTH){
			return null;
		}

		// 读取前4字节
		int len = buf.getShort();	//预期长度
		short type = buf.getShort();
		if(type == MessageType.FLASH_POLICY){
			// Policy请求
			boolean finished = false;
			// 找到结束的'\0'标志
			while(buf.remaining() > 0){
				byte b = buf.get();
				if(b == 0){
					finished = true;
					break;
				}
			}
			if(finished){
				// Policy请求全部接收完毕
			}
			else{
				// 不足，下次继续
				return null;
			}
		}else if(type == MessageType.TGW_POLICY){
			boolean finished = false;
			
			int i = 0 ;
			while(buf.remaining() > 0){
				byte b = buf.get();
				// 找到第三个'\n'标志
				if(b == 0x0a){
					i ++ ;
				}
				if(i == 3){
					finished = true;
					break;
				}
			}
			if(finished){
				// TGW请求全部接收完毕
			}
			else{
				// 不足，下次继续
				return null;
			}
		}
		else{
			// 普通消息，检查长度是否满足
			if(buf.remaining() < len-IMessage.HEADER_SIZE){
				return null;
			}
		}
		return createMessage(type);
	}

	private IMessage createMessage(int type) throws MessageParseException{
		// TODO::优先考虑Flash 的Policy消息
		switch(type){
		case MessageType.MSG_UNKNOWN:{
			return new UnknownMessage();
		}
		case MessageType.FLASH_POLICY:{
			return new PolicyMessage();
		}
		case MessageType.TGW_POLICY:{
			return new QQTGWMessage();
		}
		default:{
			return createMessageImpl(type);
		}
		}
	}

	abstract protected IMessage createMessageImpl(int type) throws MessageParseException;

}
