package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 创建军团
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCreateCorps extends CGMessage{
	
	/** 军团名称 */
	private String name;
	/** 军团公告 */
	private String notice;
	
	public CGCreateCorps (){
	}
	
	public CGCreateCorps (
			String name,
			String notice ){
			this.name = name;
			this.notice = notice;
	}
	
	@Override
	protected boolean readImpl() {

	// 军团名称
	String _name = readString();
	//end


	// 军团公告
	String _notice = readString();
	//end



			this.name = _name;
			this.notice = _notice;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 军团名称
	writeString(name);


	// 军团公告
	writeString(notice);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CREATE_CORPS;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CREATE_CORPS";
	}

	public String getName(){
		return name;
	}
		
	public void setName(String name){
		this.name = name;
	}

	public String getNotice(){
		return notice;
	}
		
	public void setNotice(String notice){
		this.notice = notice;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleCreateCorps(this.getSession().getPlayer(), this);
	}
}