package com.imop.lj.gameserver.trade.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 卖出商品结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTradeSellResult extends GCMessage{
	
	/** 1成功，2失败 */
	private int result;

	public GCTradeSellResult (){
	}
	
	public GCTradeSellResult (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 1成功，2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TRADE_SELL_RESULT;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TRADE_SELL_RESULT";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}