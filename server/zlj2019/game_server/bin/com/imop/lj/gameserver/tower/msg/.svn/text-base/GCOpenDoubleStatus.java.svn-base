package com.imop.lj.gameserver.tower.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenDoubleStatus extends GCMessage{
	
	/** 操作结果，1成功，2失败 */
	private int result;
	/** 剩余双倍点数 */
	private int curDoublePoint;

	public GCOpenDoubleStatus (){
	}
	
	public GCOpenDoubleStatus (
			int result,
			int curDoublePoint ){
			this.result = result;
			this.curDoublePoint = curDoublePoint;
	}

	@Override
	protected boolean readImpl() {

	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end


	// 剩余双倍点数
	int _curDoublePoint = readInteger();
	//end



		this.result = _result;
		this.curDoublePoint = _curDoublePoint;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 操作结果，1成功，2失败
	writeInteger(result);


	// 剩余双倍点数
	writeInteger(curDoublePoint);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OPEN_DOUBLE_STATUS;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_DOUBLE_STATUS";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}

	public int getCurDoublePoint(){
		return curDoublePoint;
	}
		
	public void setCurDoublePoint(int curDoublePoint){
		this.curDoublePoint = curDoublePoint;
	}
}