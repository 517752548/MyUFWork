package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.mail.handler.MailHandlerFactory;

/**
 * 发送邮件
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSendMail extends CGMessage{
	
	/** 收件人名称 */
	private String recName;
	/** 邮件标题 */
	private String title;
	/** 邮件内容 */
	private String content;
	
	public CGSendMail (){
	}
	
	public CGSendMail (
			String recName,
			String title,
			String content ){
			this.recName = recName;
			this.title = title;
			this.content = content;
	}
	
	@Override
	protected boolean readImpl() {

	// 收件人名称
	String _recName = readString();
	//end


	// 邮件标题
	String _title = readString();
	//end


	// 邮件内容
	String _content = readString();
	//end



			this.recName = _recName;
			this.title = _title;
			this.content = _content;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 收件人名称
	writeString(recName);


	// 邮件标题
	writeString(title);


	// 邮件内容
	writeString(content);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SEND_MAIL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SEND_MAIL";
	}

	public String getRecName(){
		return recName;
	}
		
	public void setRecName(String recName){
		this.recName = recName;
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
		MailHandlerFactory.getHandler().handleSendMail(this.getSession().getPlayer(), this);
	}
}