package com.imop.lj.gameserver.mail.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 发送邮件结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSendMail extends GCMessage{
	
	/** 发送结果，1成功，2失败 */
	private int result;
	/** 错误结果 */
	private String errorMsg;
	/** 邮件标题 */
	private String title;
	/** 邮件内容 */
	private String content;

	public GCSendMail (){
	}
	
	public GCSendMail (
			int result,
			String errorMsg,
			String title,
			String content ){
			this.result = result;
			this.errorMsg = errorMsg;
			this.title = title;
			this.content = content;
	}

	@Override
	protected boolean readImpl() {

	// 发送结果，1成功，2失败
	int _result = readInteger();
	//end


	// 错误结果
	String _errorMsg = readString();
	//end


	// 邮件标题
	String _title = readString();
	//end


	// 邮件内容
	String _content = readString();
	//end



		this.result = _result;
		this.errorMsg = _errorMsg;
		this.title = _title;
		this.content = _content;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 发送结果，1成功，2失败
	writeInteger(result);


	// 错误结果
	writeString(errorMsg);


	// 邮件标题
	writeString(title);


	// 邮件内容
	writeString(content);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SEND_MAIL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SEND_MAIL";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}

	public String getErrorMsg(){
		return errorMsg;
	}
		
	public void setErrorMsg(String errorMsg){
		this.errorMsg = errorMsg;
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
}