package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 页面跳转
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsPageSkip extends CGMessage{
	
	/** 国家0:全部，1：蜀，2：魏，3：吴 */
	private int country;
	/** 跳转页 */
	private int page;
	
	public CGCorpsPageSkip (){
	}
	
	public CGCorpsPageSkip (
			int country,
			int page ){
			this.country = country;
			this.page = page;
	}
	
	@Override
	protected boolean readImpl() {

	// 国家0:全部，1：蜀，2：魏，3：吴
	int _country = readInteger();
	//end


	// 跳转页
	int _page = readInteger();
	//end



			this.country = _country;
			this.page = _page;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 国家0:全部，1：蜀，2：魏，3：吴
	writeInteger(country);


	// 跳转页
	writeInteger(page);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_CORPS_PAGE_SKIP;
	}
	
	@Override
	public String getTypeName() {
		return "CG_CORPS_PAGE_SKIP";
	}

	public int getCountry(){
		return country;
	}
		
	public void setCountry(int country){
		this.country = country;
	}

	public int getPage(){
		return page;
	}
		
	public void setPage(int page){
		this.page = page;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleCorpsPageSkip(this.getSession().getPlayer(), this);
	}
}