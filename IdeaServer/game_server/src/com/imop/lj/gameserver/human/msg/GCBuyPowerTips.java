package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 购买体力tips信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBuyPowerTips extends GCMessage{
	
	/** 购买体力tips信息 */
	private String tips;

	public GCBuyPowerTips (){
	}
	
	public GCBuyPowerTips (
			String tips ){
			this.tips = tips;
	}

	@Override
	protected boolean readImpl() {

	// 购买体力tips信息
	String _tips = readString();
	//end



		this.tips = _tips;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 购买体力tips信息
	writeString(tips);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_BUY_POWER_TIPS;
	}
	
	@Override
	public String getTypeName() {
		return "GC_BUY_POWER_TIPS";
	}

	public String getTips(){
		return tips;
	}
		
	public void setTips(String tips){
		this.tips = tips;
	}
}