package com.imop.lj.gameserver.acrossserver.msg;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.common.InitializeRequired;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.MessageParseException;
import com.imop.lj.core.msg.MessageType;
import com.imop.lj.core.msg.recognizer.BaseMessageRecognizer;
import com.imop.lj.gameserver.acrossserver.cdkeyworld.msg.AcrossServerCdkeyworldMsgMappingProvider;
import com.imop.lj.gameserver.acrossserver.test.msg.AcrossServerTestMsgMappingProvider;

/**
 * 来自客户端的消息识别器
 * 
 */
public class GWMessageRecognizer extends BaseMessageRecognizer implements
		InitializeRequired {
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();

	public GWMessageRecognizer() {
		this.init();
	}

	@Override
	public void init() {
		registerMsgMapping(new MessageMappingProvider(){
			@Override
			public Map<Short, Class<?>> getMessageMapping() {
				Map<Short, Class<?>> map = new HashMap<Short, Class<?>>();
				map.put(MessageType.GW_SERVER_REGISTER, GWServerRegister.class);
				return map;
			}			
		});
		registerMsgMapping(new AcrossServerTestMsgMappingProvider());
		registerMsgMapping(new AcrossServerCdkeyworldMsgMappingProvider() );
	}

	/**
	 * 注册消息号和消息类的映射
	 * 
	 * @param mappingProvider
	 */
	private void registerMsgMapping(MessageMappingProvider mappingProvider) {
		msgs.putAll(mappingProvider.getMessageMapping());
	}

	@Override
	public IMessage createMessageImpl(short type) throws MessageParseException {
		Class<?> clazz = msgs.get(type);
		if (clazz == null) {
			throw new MessageParseException("Unknow msgType:" + type);
		} else {
			try {
				IMessage msg = (IMessage) clazz.newInstance();
				return msg;
			} catch (Exception e) {
				throw new MessageParseException(
						"Message Newinstance Failed，msgType:" + type, e);
			}
		}
	}
}
