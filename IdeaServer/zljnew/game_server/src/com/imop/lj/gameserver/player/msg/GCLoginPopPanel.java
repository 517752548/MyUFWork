package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 登录弹出面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLoginPopPanel extends GCMessage{
	
	/** 面板功能Id */
	private int funcId;
	/** 其他参数 */
	private String popParam;

	public GCLoginPopPanel (){
	}
	
	public GCLoginPopPanel (
			int funcId,
			String popParam ){
			this.funcId = funcId;
			this.popParam = popParam;
	}

	@Override
	protected boolean readImpl() {

	// 面板功能Id
	int _funcId = readInteger();
	//end


	// 其他参数
	String _popParam = readString();
	//end



		this.funcId = _funcId;
		this.popParam = _popParam;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 面板功能Id
	writeInteger(funcId);


	// 其他参数
	writeString(popParam);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_LOGIN_POP_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_LOGIN_POP_PANEL";
	}

	public int getFuncId(){
		return funcId;
	}
		
	public void setFuncId(int funcId){
		this.funcId = funcId;
	}

	public String getPopParam(){
		return popParam;
	}
		
	public void setPopParam(String popParam){
		this.popParam = popParam;
	}
}