package com.imop.lj.core.codec;

import org.apache.mina.core.session.IoSession;
import org.apache.mina.filter.codec.ProtocolCodecFactory;
import org.apache.mina.filter.codec.ProtocolDecoder;
import org.apache.mina.filter.codec.ProtocolEncoder;

import com.imop.lj.core.constants.SessionAttrKey;
import com.imop.lj.core.msg.recognizer.IMessageRecognizer;

/**
 * 实现Mina的编码/解码器工厂接口,源自天书mmo_core的同名类
 *
 *
 *
 */
public class GameCodecFactory implements ProtocolCodecFactory {

	/** 编码器 * */
	private static final GameEncoder ENCODER = new GameEncoder();

	/** 消息识别器 * */
	private final IMessageRecognizer recognizer;

	public GameCodecFactory(IMessageRecognizer recog) {
		recognizer = recog;
	}

	@Override
	public ProtocolDecoder getDecoder(IoSession session) throws Exception {
		ProtocolDecoder decoder = (ProtocolDecoder) session
				.getAttribute(SessionAttrKey.DECODER);
		if (decoder == null) {
			decoder = new GameDecoder(recognizer);
			session.setAttribute(SessionAttrKey.DECODER, decoder);
		}
		return decoder;
	}

	@Override
	public ProtocolEncoder getEncoder(IoSession session) throws Exception {
		return ENCODER;
	}

	public IMessageRecognizer getRecognizer() {
		return recognizer;
	}

}
