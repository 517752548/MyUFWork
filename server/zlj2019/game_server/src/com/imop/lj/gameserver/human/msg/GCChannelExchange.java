package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 通过码兑换奖励结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCChannelExchange extends GCMessage{
	
	/** 兑换结果，1成功，2失败 */
	private int result;

	public GCChannelExchange (){
	}
	
	public GCChannelExchange (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 兑换结果，1成功，2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 兑换结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CHANNEL_EXCHANGE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CHANNEL_EXCHANGE";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}