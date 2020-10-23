package com.imop.lj.gameserver.wallow.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 防沉迷认证结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWallowAddInfoResult extends GCMessage{
	
	/** 认证结果 */
	private String result;

	public GCWallowAddInfoResult (){
	}
	
	public GCWallowAddInfoResult (
			String result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 认证结果
	String _result = readString();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 认证结果
	writeString(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_WALLOW_ADD_INFO_RESULT;
	}
	
	@Override
	public String getTypeName() {
		return "GC_WALLOW_ADD_INFO_RESULT";
	}

	public String getResult(){
		return result;
	}
		
	public void setResult(String result){
		this.result = result;
	}
}