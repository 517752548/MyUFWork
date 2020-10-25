package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回请求制作物品
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMakeItem extends GCMessage{
	
	/** 制作结果,1成功,2失败 */
	private int result;

	public GCMakeItem (){
	}
	
	public GCMakeItem (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 制作结果,1成功,2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 制作结果,1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MAKE_ITEM;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MAKE_ITEM";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}