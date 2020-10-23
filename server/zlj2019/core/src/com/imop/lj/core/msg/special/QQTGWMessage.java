package com.imop.lj.core.msg.special;

import java.io.UnsupportedEncodingException;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.BaseMinaMessage;
import com.imop.lj.core.msg.MessageParseException;
import com.imop.lj.core.msg.MessageType;

/**
 * Flash Policy请求
 *
 *
 */
@SuppressWarnings("unchecked")
public class QQTGWMessage extends BaseMinaMessage {
	private String tgw;

	protected boolean readImpl() {
		int i = 0 ;
		while(buf.remaining() > 0){
			byte b = buf.get();
			// 找到第三个'\n'标志
			if(b == 0x0a){
				i ++ ;
			}
			if(i == 3){
				break;
			}
		}
		return true;
	}

	public boolean write() throws MessageParseException {
		return writeImpl();
	}

	protected boolean writeImpl() {
//		try {
//			byte[] bytes = tgw.getBytes(SharedConstants.DEFAULT_CHARSET);
//			writeBytes(bytes);
//			writeByte(0);
//			return true;
//		} catch (UnsupportedEncodingException e) {
//			e.printStackTrace();
//			return false;
//		}
		return false;
	}

	public short getType() {
		return MessageType.TGW_POLICY;
	}

	public String getTypeName() {
		return "TGW_POLICY";
	}

	public String getPolicy() {
		return tgw;
	}

	public void setPolicy(String policy) {
		this.tgw = policy;
	}

	@Override
	public void execute() {
	}

}