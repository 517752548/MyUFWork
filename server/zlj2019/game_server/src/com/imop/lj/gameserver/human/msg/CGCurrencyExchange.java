package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.human.handler.HumanHandlerFactory;

/**
 * 货币兑换
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCurrencyExchange extends CGMessage{
	
	/** 花费的货币类型 */
	private int costId;
	/** 要兑换的货币数量 */
	private int exchangeNum;
	/** 要兑换的货币类型，金子兑银子1，金票兑银票5 */
	private int exchangeId;
	
	public CGCurrencyExchange (){
	}
	
	public CGCurrencyExchange (
			int costId,
			int exchangeNum,
			int exchangeId ){
			this.costId = costId;
			this.exchangeNum = exchangeNum;
			this.exchangeId = exchangeId;
	}
	
	@Override
	protected boolean readImpl() {

	// 花费的货币类型
	int _costId = readInteger();
	//end


	// 要兑换的货币数量
	int _exchangeNum = readInteger();
	//end


	// 要兑换的货币类型，金子兑银子1，金票兑银票5
	int _exchangeId = readInteger();
	//end



			this.costId = _costId;
			this.exchangeNum = _exchangeNum;
			this.exchangeId = _exchangeId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 花费的货币类型
	writeInteger(costId);


	// 要兑换的货币数量
	writeInteger(exchangeNum);


	// 要兑换的货币类型，金子兑银子1，金票兑银票5
	writeInteger(exchangeId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CURRENCY_EXCHANGE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CURRENCY_EXCHANGE";
	}

	public int getCostId(){
		return costId;
	}
		
	public void setCostId(int costId){
		this.costId = costId;
	}

	public int getExchangeNum(){
		return exchangeNum;
	}
		
	public void setExchangeNum(int exchangeNum){
		this.exchangeNum = exchangeNum;
	}

	public int getExchangeId(){
		return exchangeId;
	}
		
	public void setExchangeId(int exchangeId){
		this.exchangeId = exchangeId;
	}


	@Override
	public void execute() {
		HumanHandlerFactory.getHandler().handleCurrencyExchange(this.getSession().getPlayer(), this);
	}
}