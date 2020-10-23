package com.imop.lj.gameserver.humanskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 心法切换结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCHsMainChange extends GCMessage{
	
	/** 结果 1成功,2失败 */
	private int result;

	public GCHsMainChange (){
	}
	
	public GCHsMainChange (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 结果 1成功,2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 结果 1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_HS_MAIN_CHANGE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_HS_MAIN_CHANGE";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}