package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mail.handler.MailHandlerFactory;

/**
 * 发送军团邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSendGuildMail extends CGMessage{
	
	/** 邮件标题 */
	private String title;
	/** 邮件内容 */
	private String content;
	
	public CGSendGuildMail (){
	}
	
	public CGSendGuildMail (
			String title,
			String content ){
			this.title = title;
			this.content = content;
	}
	
	@Override
	protected boolean readImpl() {

	// 邮件标题
	String _title = readString();
	//end


	// 邮件内容
	String _content = readString();
	//end



			this.title = _title;
			this.content = _content;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 邮件标题
	writeString(title);


	// 邮件内容
	writeString(content);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SEND_GUILD_MAIL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SEND_GUILD_MAIL";
	}

	public String getTitle(){
		return title;
	}
		
	public void setTitle(String title){
		this.title = title;
	}

	public String getContent(){
		return content;
	}
		
	public void setContent(String content){
		this.content = content;
	}


	@Override
	public void execute() {
		MailHandlerFactory.getHandler().handleSendGuildMail(this.getSession().getPlayer(), this);
	}
}