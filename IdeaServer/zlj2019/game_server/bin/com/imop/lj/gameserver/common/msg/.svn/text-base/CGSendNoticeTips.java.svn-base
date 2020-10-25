package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.common.handler.CommonHandlerFactory;

/**
 * 发送小信封
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSendNoticeTips extends CGMessage{
	
	/** 内容 */
	private String content;
	/** 发送目标 */
	private long roleId;
	
	public CGSendNoticeTips (){
	}
	
	public CGSendNoticeTips (
			String content,
			long roleId ){
			this.content = content;
			this.roleId = roleId;
	}
	
	@Override
	protected boolean readImpl() {

	// 内容
	String _content = readString();
	//end


	// 发送目标
	long _roleId = readLong();
	//end



			this.content = _content;
			this.roleId = _roleId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 内容
	writeString(content);


	// 发送目标
	writeLong(roleId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SEND_NOTICE_TIPS;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SEND_NOTICE_TIPS";
	}

	public String getContent(){
		return content;
	}
		
	public void setContent(String content){
		this.content = content;
	}

	public long getRoleId(){
		return roleId;
	}
		
	public void setRoleId(long roleId){
		this.roleId = roleId;
	}


	@Override
	public void execute() {
		CommonHandlerFactory.getHandler().handleSendNoticeTips(this.getSession().getPlayer(), this);
	}
}