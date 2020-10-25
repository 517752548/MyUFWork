package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 随机角色名
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRoleRandomName extends GCMessage{
	
	/** 角色名字 */
	private String name;

	public GCRoleRandomName (){
	}
	
	public GCRoleRandomName (
			String name ){
			this.name = name;
	}

	@Override
	protected boolean readImpl() {

	// 角色名字
	String _name = readString();
	//end



		this.name = _name;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 角色名字
	writeString(name);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ROLE_RANDOM_NAME;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ROLE_RANDOM_NAME";
	}

	public String getName(){
		return name;
	}
		
	public void setName(String name){
		this.name = name;
	}
}