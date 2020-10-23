package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pet.handler.PetHandlerFactory;

/**
 * 打开伙伴面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPetOpenFriendPanel extends CGMessage{
	
	
	public CGPetOpenFriendPanel (){
	}
	
	
	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PET_OPEN_FRIEND_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PET_OPEN_FRIEND_PANEL";
	}


	@Override
	public void execute() {
		PetHandlerFactory.getHandler().handlePetOpenFriendPanel(this.getSession().getPlayer(), this);
	}
}