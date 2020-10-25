package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 创建角色
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCreateRole extends CGMessage{
	
	/** 角色名字 */
	private String name;
	/** 选择的主将模板Id */
	private int templateId;
	
	public CGCreateRole (){
	}
	
	public CGCreateRole (
			String name,
			int templateId ){
			this.name = name;
			this.templateId = templateId;
	}
	
	@Override
	protected boolean readImpl() {

	// 角色名字
	String _name = readString();
	//end


	// 选择的主将模板Id
	int _templateId = readInteger();
	//end



			this.name = _name;
			this.templateId = _templateId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 角色名字
	writeString(name);


	// 选择的主将模板Id
	writeInteger(templateId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CREATE_ROLE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CREATE_ROLE";
	}

	public String getName(){
		return name;
	}
		
	public void setName(String name){
		this.name = name;
	}

	public int getTemplateId(){
		return templateId;
	}
		
	public void setTemplateId(int templateId){
		this.templateId = templateId;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleCreateRole(this.getSession().getPlayer(), this);
	}
}