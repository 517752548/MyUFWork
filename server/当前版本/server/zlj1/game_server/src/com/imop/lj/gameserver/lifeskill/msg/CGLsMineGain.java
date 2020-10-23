package com.imop.lj.gameserver.lifeskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.lifeskill.handler.LifeskillHandlerFactory;

/**
 * 申请取得矿石
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGLsMineGain extends CGMessage{
	
	/** 矿点ID */
	private int pitId;
	
	public CGLsMineGain (){
	}
	
	public CGLsMineGain (
			int pitId ){
			this.pitId = pitId;
	}
	
	@Override
	protected boolean readImpl() {

	// 矿点ID
	int _pitId = readInteger();
	//end



			this.pitId = _pitId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 矿点ID
	writeInteger(pitId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_LS_MINE_GAIN;
	}
	
	@Override
	public String getTypeName() {
		return "CG_LS_MINE_GAIN";
	}

	public int getPitId(){
		return pitId;
	}
		
	public void setPitId(int pitId){
		this.pitId = pitId;
	}


	@Override
	public void execute() {
		LifeskillHandlerFactory.getHandler().handleLsMineGain(this.getSession().getPlayer(), this);
	}
}