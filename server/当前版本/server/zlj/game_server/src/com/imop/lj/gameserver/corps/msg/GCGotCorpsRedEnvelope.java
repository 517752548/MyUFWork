package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回请求领取帮派红包
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGotCorpsRedEnvelope extends GCMessage{
	
	/** 要领取红包的uuid */
	private String uuid;
	/** 结果,1成功,2失败 */
	private int result;
	/** 领取的金额 */
	private int gotBonus;

	public GCGotCorpsRedEnvelope (){
	}
	
	public GCGotCorpsRedEnvelope (
			String uuid,
			int result,
			int gotBonus ){
			this.uuid = uuid;
			this.result = result;
			this.gotBonus = gotBonus;
	}

	@Override
	protected boolean readImpl() {

	// 要领取红包的uuid
	String _uuid = readString();
	//end


	// 结果,1成功,2失败
	int _result = readInteger();
	//end


	// 领取的金额
	int _gotBonus = readInteger();
	//end



		this.uuid = _uuid;
		this.result = _result;
		this.gotBonus = _gotBonus;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 要领取红包的uuid
	writeString(uuid);


	// 结果,1成功,2失败
	writeInteger(result);


	// 领取的金额
	writeInteger(gotBonus);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_GOT_CORPS_RED_ENVELOPE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_GOT_CORPS_RED_ENVELOPE";
	}

	public String getUuid(){
		return uuid;
	}
		
	public void setUuid(String uuid){
		this.uuid = uuid;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}

	public int getGotBonus(){
		return gotBonus;
	}
		
	public void setGotBonus(int gotBonus){
		this.gotBonus = gotBonus;
	}
}