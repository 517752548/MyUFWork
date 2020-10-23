package com.imop.lj.gameserver.lifeskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回申请采矿结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLsMineStart extends GCMessage{
	
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCLsMineStart (){
	}
	
	public GCLsMineStart (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 操作结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_LS_MINE_START;
	}
	
	@Override
	public String getTypeName() {
		return "GC_LS_MINE_START";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}