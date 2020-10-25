package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 请求随机角色名
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGRoleRandomName extends CGMessage{
	
	/** 发送选择主将男女性别0女1男 */
	private int sex;
	
	public CGRoleRandomName (){
	}
	
	public CGRoleRandomName (
			int sex ){
			this.sex = sex;
	}
	
	@Override
	protected boolean readImpl() {

	// 发送选择主将男女性别0女1男
	int _sex = readInteger();
	//end



			this.sex = _sex;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 发送选择主将男女性别0女1男
	writeInteger(sex);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_ROLE_RANDOM_NAME;
	}
	
	@Override
	public String getTypeName() {
		return "CG_ROLE_RANDOM_NAME";
	}

	public int getSex(){
		return sex;
	}
		
	public void setSex(int sex){
		this.sex = sex;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleRoleRandomName(this.getSession().getPlayer(), this);
	}
}