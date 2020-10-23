package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 请求发送帮派红包
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCreateCorpsRedEnvelope extends CGMessage{
	
	/** 红包类型,1-帮派红包 */
	private int redEnvelopeType;
	/** 红包内容 */
	private String content;
	/** 红包总金额 */
	private int bonusAmount;
	
	public CGCreateCorpsRedEnvelope (){
	}
	
	public CGCreateCorpsRedEnvelope (
			int redEnvelopeType,
			String content,
			int bonusAmount ){
			this.redEnvelopeType = redEnvelopeType;
			this.content = content;
			this.bonusAmount = bonusAmount;
	}
	
	@Override
	protected boolean readImpl() {

	// 红包类型,1-帮派红包
	int _redEnvelopeType = readInteger();
	//end


	// 红包内容
	String _content = readString();
	//end


	// 红包总金额
	int _bonusAmount = readInteger();
	//end



			this.redEnvelopeType = _redEnvelopeType;
			this.content = _content;
			this.bonusAmount = _bonusAmount;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 红包类型,1-帮派红包
	writeInteger(redEnvelopeType);


	// 红包内容
	writeString(content);


	// 红包总金额
	writeInteger(bonusAmount);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CREATE_CORPS_RED_ENVELOPE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CREATE_CORPS_RED_ENVELOPE";
	}

	public int getRedEnvelopeType(){
		return redEnvelopeType;
	}
		
	public void setRedEnvelopeType(int redEnvelopeType){
		this.redEnvelopeType = redEnvelopeType;
	}

	public String getContent(){
		return content;
	}
		
	public void setContent(String content){
		this.content = content;
	}

	public int getBonusAmount(){
		return bonusAmount;
	}
		
	public void setBonusAmount(int bonusAmount){
		this.bonusAmount = bonusAmount;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleCreateCorpsRedEnvelope(this.getSession().getPlayer(), this);
	}
}