package com.imop.lj.gameserver.pubtask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.pubtask.handler.PubtaskHandlerFactory;

/**
 * 酒馆任务手动刷新
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPubtaskRefreshNew extends CGMessage{
	
	/** 0-普通刷新,1-金子刷新 */
	private int refreshType;
	
	public CGPubtaskRefreshNew (){
	}
	
	public CGPubtaskRefreshNew (
			int refreshType ){
			this.refreshType = refreshType;
	}
	
	@Override
	protected boolean readImpl() {

	// 0-普通刷新,1-金子刷新
	int _refreshType = readInteger();
	//end



			this.refreshType = _refreshType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 0-普通刷新,1-金子刷新
	writeInteger(refreshType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PUBTASK_REFRESH_NEW;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PUBTASK_REFRESH_NEW";
	}

	public int getRefreshType(){
		return refreshType;
	}
		
	public void setRefreshType(int refreshType){
		this.refreshType = refreshType;
	}


	@Override
	public void execute() {
		PubtaskHandlerFactory.getHandler().handlePubtaskRefreshNew(this.getSession().getPlayer(), this);
	}
}