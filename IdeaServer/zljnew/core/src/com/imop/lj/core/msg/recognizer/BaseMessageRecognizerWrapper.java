/**
 *
 */
package com.imop.lj.core.msg.recognizer;

import java.util.List;

import com.imop.lj.common.constants.CommonErrorLogInfo;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.MessageParseException;

public final class BaseMessageRecognizerWrapper extends BaseMessageRecognizer {
	private final BaseMessageRecognizer[] subMessageRecognizers;

	public BaseMessageRecognizerWrapper(List<BaseMessageRecognizer> subMessageRecognizers) {
		this.subMessageRecognizers = new BaseMessageRecognizer[subMessageRecognizers.size()];
		subMessageRecognizers.toArray(this.subMessageRecognizers);
	}

	@Override
	public IMessage createMessage(short type) throws MessageParseException {
		for (int i = 0; i < this.subMessageRecognizers.length; i++) {
			BaseMessageRecognizer _recog = this.subMessageRecognizers[i];
			IMessage _msg = _recog.createMessage(type);
			if (_msg != null) {
				return _msg;
			}
		}
		throw new MessageParseException(CommonErrorLogInfo.MSG_UNKNOWN+type);
	}

	@Override
	public IMessage createMessageImpl(short type) throws MessageParseException {
		// TODO Auto-generated method stub
		return null;
	}
}