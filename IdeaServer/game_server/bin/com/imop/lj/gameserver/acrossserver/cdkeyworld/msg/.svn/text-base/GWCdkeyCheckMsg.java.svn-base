package com.imop.lj.gameserver.acrossserver.cdkeyworld.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.acrossserver.msg.GWMessage;
import com.imop.lj.gameserver.acrossserver.cdkeyworld.handler.CdkeyworldAcrossServerHandlerFactory;

/**
 * 向worldserver请求验证激活码是否可用
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class GWCdkeyCheckMsg extends GWMessage{
	
	/** 玩家的passportId */
	private String openId;
	/** 角色UUId */
	private long charUUId;
	/** 激活码 */
	private String cdKeyStr;
	/** 所在服务器 */
	private String onServerId;
	
	public GWCdkeyCheckMsg (){
	}
	
	public GWCdkeyCheckMsg (
			String openId,
			long charUUId,
			String cdKeyStr,
			String onServerId ){
			this.openId = openId;
			this.charUUId = charUUId;
			this.cdKeyStr = cdKeyStr;
			this.onServerId = onServerId;
	}
	
	@Override
	protected boolean readImpl() {

	// 玩家的passportId
	String _openId = readString();
	//end


	// 角色UUId
	long _charUUId = readLong();
	//end


	// 激活码
	String _cdKeyStr = readString();
	//end


	// 所在服务器
	String _onServerId = readString();
	//end



		this.openId = _openId;
		this.charUUId = _charUUId;
		this.cdKeyStr = _cdKeyStr;
		this.onServerId = _onServerId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {
		writeString(openId);
		writeLong(charUUId);
		writeString(cdKeyStr);
		writeString(onServerId);
		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GW_CDKEY_CHECK_MSG;
	}
	
	@Override
	public String getTypeName() {
		return "GW_CDKEY_CHECK_MSG";
	}

	public String getOpenId(){
		return openId;
	}
		
	public void setOpenId(String openId){
		this.openId = openId;
	}

	public long getCharUUId(){
		return charUUId;
	}
		
	public void setCharUUId(long charUUId){
		this.charUUId = charUUId;
	}

	public String getCdKeyStr(){
		return cdKeyStr;
	}
		
	public void setCdKeyStr(String cdKeyStr){
		this.cdKeyStr = cdKeyStr;
	}

	public String getOnServerId(){
		return onServerId;
	}
		
	public void setOnServerId(String onServerId){
		this.onServerId = onServerId;
	}

	@Override
	public void execute() {
		CdkeyworldAcrossServerHandlerFactory.getHandler().handleCdkeyCheckMsg(this.getSession().getServerClient(), this);
	}
}