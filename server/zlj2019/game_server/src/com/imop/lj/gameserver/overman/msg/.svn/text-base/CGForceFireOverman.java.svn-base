package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.overman.handler.OvermanHandlerFactory;

/**
 * 强制出师
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGForceFireOverman extends CGMessage{
	
	/** 师傅或者徒弟的charid */
	private long charId;
	
	public CGForceFireOverman (){
	}
	
	public CGForceFireOverman (
			long charId ){
			this.charId = charId;
	}
	
	@Override
	protected boolean readImpl() {

	// 师傅或者徒弟的charid
	long _charId = readLong();
	//end



			this.charId = _charId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 师傅或者徒弟的charid
	writeLong(charId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_FORCE_FIRE_OVERMAN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_FORCE_FIRE_OVERMAN";
	}

	public long getCharId(){
		return charId;
	}
		
	public void setCharId(long charId){
		this.charId = charId;
	}


	@Override
	public void execute() {
		OvermanHandlerFactory.getHandler().handleForceFireOverman(this.getSession().getPlayer(), this);
	}
}