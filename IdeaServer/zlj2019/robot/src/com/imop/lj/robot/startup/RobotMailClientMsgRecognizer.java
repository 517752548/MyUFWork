package com.imop.lj.robot.startup;

import java.util.HashMap;
import java.util.Map;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.common.MessageMappingProvider;
import com.imop.lj.gameserver.mail.msg.GCMailList;
import com.imop.lj.gameserver.mail.msg.GCMailUpdate;
import com.imop.lj.gameserver.mail.msg.GCSendMail;
import com.imop.lj.gameserver.mail.msg.GCDelMail;
import com.imop.lj.gameserver.mail.msg.GCGetMailAttachment;

public class RobotMailClientMsgRecognizer implements MessageMappingProvider {
	
	private Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
	
	@Override
	public Map<Short, Class<?>> getMessageMapping() {
		Map<Short, Class<?>> msgs = new HashMap<Short, Class<?>>();
		msgs.put(MessageType.GC_MAIL_LIST, GCMailList.class);
		msgs.put(MessageType.GC_MAIL_UPDATE, GCMailUpdate.class);
		msgs.put(MessageType.GC_SEND_MAIL, GCSendMail.class);
		msgs.put(MessageType.GC_DEL_MAIL, GCDelMail.class);
		msgs.put(MessageType.GC_GET_MAIL_ATTACHMENT, GCGetMailAttachment.class);
		return msgs;
	}
}
