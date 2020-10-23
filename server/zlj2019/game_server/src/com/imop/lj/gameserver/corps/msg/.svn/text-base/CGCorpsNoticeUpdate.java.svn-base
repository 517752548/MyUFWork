package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 修改公告
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsNoticeUpdate extends CGMessage{
	
	/** 军团QQ */
	private String qq;
	/** 公告内容 */
	private String notice;
	
	public CGCorpsNoticeUpdate (){
	}
	
	public CGCorpsNoticeUpdate (
			String qq,
			String notice ){
			this.qq = qq;
			this.notice = notice;
	}
	
	@Override
	protected boolean readImpl() {

	// 军团QQ
	String _qq = readString();
	//end


	// 公告内容
	String _notice = readString();
	//end



			this.qq = _qq;
			this.notice = _notice;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 军团QQ
	writeString(qq);


	// 公告内容
	writeString(notice);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CORPS_NOTICE_UPDATE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPS_NOTICE_UPDATE";
	}

	public String getQq(){
		return qq;
	}
		
	public void setQq(String qq){
		this.qq = qq;
	}

	public String getNotice(){
		return notice;
	}
		
	public void setNotice(String notice){
		this.notice = notice;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleCorpsNoticeUpdate(this.getSession().getPlayer(), this);
	}
}