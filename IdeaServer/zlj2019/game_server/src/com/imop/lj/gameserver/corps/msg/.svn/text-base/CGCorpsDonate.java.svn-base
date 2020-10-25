package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 军团捐献
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsDonate extends CGMessage{
	
	/** 捐献数量 */
	private int num;
	
	public CGCorpsDonate (){
	}
	
	public CGCorpsDonate (
			int num ){
			this.num = num;
	}
	
	@Override
	protected boolean readImpl() {

	// 捐献数量
	int _num = readInteger();
	//end



			this.num = _num;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 捐献数量
	writeInteger(num);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CORPS_DONATE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPS_DONATE";
	}

	public int getNum(){
		return num;
	}
		
	public void setNum(int num){
		this.num = num;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleCorpsDonate(this.getSession().getPlayer(), this);
	}
}