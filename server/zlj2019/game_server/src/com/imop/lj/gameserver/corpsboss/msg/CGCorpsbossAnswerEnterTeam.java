package com.imop.lj.gameserver.corpsboss.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corpsboss.handler.CorpsbossHandlerFactory;

/**
 * 应答挑战帮派boss的请求
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsbossAnswerEnterTeam extends CGMessage{
	
	/** 是否同意进入，0不同意，1同意 */
	private int agree;
	
	public CGCorpsbossAnswerEnterTeam (){
	}
	
	public CGCorpsbossAnswerEnterTeam (
			int agree ){
			this.agree = agree;
	}
	
	@Override
	protected boolean readImpl() {

	// 是否同意进入，0不同意，1同意
	int _agree = readInteger();
	//end



			this.agree = _agree;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否同意进入，0不同意，1同意
	writeInteger(agree);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CORPSBOSS_ANSWER_ENTER_TEAM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPSBOSS_ANSWER_ENTER_TEAM";
	}

	public int getAgree(){
		return agree;
	}
		
	public void setAgree(int agree){
		this.agree = agree;
	}


	@Override
	public void execute() {
		CorpsbossHandlerFactory.getHandler().handleCorpsbossAnswerEnterTeam(this.getSession().getPlayer(), this);
	}
}