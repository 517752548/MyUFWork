package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.player.handler.PlayerHandlerFactory;

/**
 * 生成充值订单Id
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGChargeGenOrderid extends CGMessage{
	
	/** 渠道号 */
	private String channelCode;
	/** 渠道附加值 */
	private String channelExt;
	
	public CGChargeGenOrderid (){
	}
	
	public CGChargeGenOrderid (
			String channelCode,
			String channelExt ){
			this.channelCode = channelCode;
			this.channelExt = channelExt;
	}
	
	@Override
	protected boolean readImpl() {

	// 渠道号
	String _channelCode = readString();
	//end


	// 渠道附加值
	String _channelExt = readString();
	//end



			this.channelCode = _channelCode;
			this.channelExt = _channelExt;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 渠道号
	writeString(channelCode);


	// 渠道附加值
	writeString(channelExt);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CHARGE_GEN_ORDERID;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CHARGE_GEN_ORDERID";
	}

	public String getChannelCode(){
		return channelCode;
	}
		
	public void setChannelCode(String channelCode){
		this.channelCode = channelCode;
	}

	public String getChannelExt(){
		return channelExt;
	}
		
	public void setChannelExt(String channelExt){
		this.channelExt = channelExt;
	}


	@Override
	public void execute() {
		PlayerHandlerFactory.getHandler().handleChargeGenOrderid(this.getSession().getPlayer(), this);
	}
}