package com.imop.lj.gameserver.cdkeygift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.cdkeygift.handler.CdkeygiftHandlerFactory;

/**
 * 通过cdkey领礼包
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCdkeyGetGiftMsg extends CGMessage{
	
	/** cdkey激活码 */
	private String cdKeyStr;
	
	public CGCdkeyGetGiftMsg (){
	}
	
	public CGCdkeyGetGiftMsg (
			String cdKeyStr ){
			this.cdKeyStr = cdKeyStr;
	}
	
	@Override
	protected boolean readImpl() {

	// cdkey激活码
	String _cdKeyStr = readString();
	//end



			this.cdKeyStr = _cdKeyStr;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// cdkey激活码
	writeString(cdKeyStr);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CDKEY_GET_GIFT_MSG;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CDKEY_GET_GIFT_MSG";
	}

	public String getCdKeyStr(){
		return cdKeyStr;
	}
		
	public void setCdKeyStr(String cdKeyStr){
		this.cdKeyStr = cdKeyStr;
	}


	@Override
	public void execute() {
		CdkeygiftHandlerFactory.getHandler().handleCdkeyGetGiftMsg(this.getSession().getPlayer(), this);
	}
}