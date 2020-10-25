package com.imop.lj.gameserver.item.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 战斗外嗑药结果消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUsePoolAddResult extends GCMessage{
	
	/** 道具模板Id */
	private int itemTplId;
	/** 操作结果，1成功，2失败 */
	private int result;

	public GCUsePoolAddResult (){
	}
	
	public GCUsePoolAddResult (
			int itemTplId,
			int result ){
			this.itemTplId = itemTplId;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 道具模板Id
	int _itemTplId = readInteger();
	//end


	// 操作结果，1成功，2失败
	int _result = readInteger();
	//end



		this.itemTplId = _itemTplId;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 道具模板Id
	writeInteger(itemTplId);


	// 操作结果，1成功，2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_USE_POOL_ADD_RESULT;
	}
	
	@Override
	public String getTypeName() {
		return "GC_USE_POOL_ADD_RESULT";
	}

	public int getItemTplId(){
		return itemTplId;
	}
		
	public void setItemTplId(int itemTplId){
		this.itemTplId = itemTplId;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}