package com.imop.lj.gameserver.siegedemon.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.siegedemon.handler.SiegedemonHandlerFactory;

/**
 * 应答进入组队副本的请求
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSiegedemonAnswerEnterTeam extends CGMessage{
	
	/** 是否同意进入，0不同意，1同意 */
	private int agree;
	/** 副本类型,12-正常,13-困难 */
	private int siegeType;
	
	public CGSiegedemonAnswerEnterTeam (){
	}
	
	public CGSiegedemonAnswerEnterTeam (
			int agree,
			int siegeType ){
			this.agree = agree;
			this.siegeType = siegeType;
	}
	
	@Override
	protected boolean readImpl() {

	// 是否同意进入，0不同意，1同意
	int _agree = readInteger();
	//end


	// 副本类型,12-正常,13-困难
	int _siegeType = readInteger();
	//end



			this.agree = _agree;
			this.siegeType = _siegeType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否同意进入，0不同意，1同意
	writeInteger(agree);


	// 副本类型,12-正常,13-困难
	writeInteger(siegeType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SIEGEDEMON_ANSWER_ENTER_TEAM;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SIEGEDEMON_ANSWER_ENTER_TEAM";
	}

	public int getAgree(){
		return agree;
	}
		
	public void setAgree(int agree){
		this.agree = agree;
	}

	public int getSiegeType(){
		return siegeType;
	}
		
	public void setSiegeType(int siegeType){
		this.siegeType = siegeType;
	}


	@Override
	public void execute() {
		SiegedemonHandlerFactory.getHandler().handleSiegedemonAnswerEnterTeam(this.getSession().getPlayer(), this);
	}
}