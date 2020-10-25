package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求领取帮派红包
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGotCorpsRedEnvelope extends CGMessage{
	
	/** 红包类型,1-帮派红包 */
	private int redEnvelopeType;
	/** 要领取红包的uuid */
	private String uuid;
	
	public CGGotCorpsRedEnvelope (){
	}
	
	public CGGotCorpsRedEnvelope (
			int redEnvelopeType,
			String uuid ){
			this.redEnvelopeType = redEnvelopeType;
			this.uuid = uuid;
	}
	
	@Override
	protected boolean readImpl() {

	// 红包类型,1-帮派红包
	int _redEnvelopeType = readInteger();
	//end


	// 要领取红包的uuid
	String _uuid = readString();
	//end



			this.redEnvelopeType = _redEnvelopeType;
			this.uuid = _uuid;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 红包类型,1-帮派红包
	writeInteger(redEnvelopeType);


	// 要领取红包的uuid
	writeString(uuid);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_GOT_CORPS_RED_ENVELOPE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GOT_CORPS_RED_ENVELOPE";
	}

	public int getRedEnvelopeType(){
		return redEnvelopeType;
	}
		
	public void setRedEnvelopeType(int redEnvelopeType){
		this.redEnvelopeType = redEnvelopeType;
	}

	public String getUuid(){
		return uuid;
	}
		
	public void setUuid(String uuid){
		this.uuid = uuid;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleGotCorpsRedEnvelope(this.getSession().getPlayer(), this);
	}
}