package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 充值记录
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCChargeRecord extends GCMessage{
	
	/** 已充值模板id */
	private int[] tplId;

	public GCChargeRecord (){
	}
	
	public GCChargeRecord (
			int[] tplId ){
			this.tplId = tplId;
	}

	@Override
	protected boolean readImpl() {

	// 已充值模板id
	int tplIdSize = readUnsignedShort();
	int[] _tplId = new int[tplIdSize];
	int tplIdIndex = 0;
	for(tplIdIndex=0; tplIdIndex<tplIdSize; tplIdIndex++){
		_tplId[tplIdIndex] = readInteger();
	}//end



		this.tplId = _tplId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 已充值模板id
	writeShort(tplId.length);
	int tplIdSize = tplId.length;
	int tplIdIndex = 0;
	for(tplIdIndex=0; tplIdIndex<tplIdSize; tplIdIndex++){
		writeInteger(tplId [ tplIdIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CHARGE_RECORD;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CHARGE_RECORD";
	}

	public int[] getTplId(){
		return tplId;
	}

	public void setTplId(int[] tplId){
		this.tplId = tplId;
	}	
}