package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求查看红包详情
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLookCorpsRedEnvelope extends CGMessage{
	
	/** 要查看红包的uuid */
	private String uuid;
	
	public CGLookCorpsRedEnvelope (){
	}
	
	public CGLookCorpsRedEnvelope (
			String uuid ){
			this.uuid = uuid;
	}
	
	@Override
	protected boolean readImpl() {

	// 要查看红包的uuid
	String _uuid = readString();
	//end



			this.uuid = _uuid;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 要查看红包的uuid
	writeString(uuid);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_LOOK_CORPS_RED_ENVELOPE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_LOOK_CORPS_RED_ENVELOPE";
	}

	public String getUuid(){
		return uuid;
	}
		
	public void setUuid(String uuid){
		this.uuid = uuid;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleLookCorpsRedEnvelope(this.getSession().getPlayer(), this);
	}
}