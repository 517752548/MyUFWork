package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 一键申请
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsQuickApply extends CGMessage{
	
	/** 请求的页数 */
	private int page;
	
	public CGCorpsQuickApply (){
	}
	
	public CGCorpsQuickApply (
			int page ){
			this.page = page;
	}
	
	@Override
	protected boolean readImpl() {

	// 请求的页数
	int _page = readInteger();
	//end



			this.page = _page;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 请求的页数
	writeInteger(page);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CORPS_QUICK_APPLY;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPS_QUICK_APPLY";
	}

	public int getPage(){
		return page;
	}
		
	public void setPage(int page){
		this.page = page;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleCorpsQuickApply(this.getSession().getPlayer(), this);
	}
}