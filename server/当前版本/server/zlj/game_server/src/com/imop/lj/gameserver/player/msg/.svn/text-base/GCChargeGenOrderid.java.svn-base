package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 生成充值订单Id
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCChargeGenOrderid extends GCMessage{
	
	/** 充值订单Id */
	private String orderId;

	public GCChargeGenOrderid (){
	}
	
	public GCChargeGenOrderid (
			String orderId ){
			this.orderId = orderId;
	}

	@Override
	protected boolean readImpl() {

	// 充值订单Id
	String _orderId = readString();
	//end



		this.orderId = _orderId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 充值订单Id
	writeString(orderId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CHARGE_GEN_ORDERID;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CHARGE_GEN_ORDERID";
	}

	public String getOrderId(){
		return orderId;
	}
		
	public void setOrderId(String orderId){
		this.orderId = orderId;
	}
}