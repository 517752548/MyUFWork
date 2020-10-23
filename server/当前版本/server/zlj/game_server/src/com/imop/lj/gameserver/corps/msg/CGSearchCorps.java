package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.corps.handler.CorpsHandlerFactory;

/**
 * 军团列表搜索
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGSearchCorps extends CGMessage{
	
	/** 国家0:全部，1：蜀，2：魏，3：吴 */
	private int country;
	/** 军团名称 */
	private String name;
	
	public CGSearchCorps (){
	}
	
	public CGSearchCorps (
			int country,
			String name ){
			this.country = country;
			this.name = name;
	}
	
	@Override
	protected boolean readImpl() {

	// 国家0:全部，1：蜀，2：魏，3：吴
	int _country = readInteger();
	//end


	// 军团名称
	String _name = readString();
	//end



			this.country = _country;
			this.name = _name;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 国家0:全部，1：蜀，2：魏，3：吴
	writeInteger(country);


	// 军团名称
	writeString(name);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_SEARCH_CORPS;
	}
	
	@Override
	public String getTypeName() {
		return "CG_SEARCH_CORPS";
	}

	public int getCountry(){
		return country;
	}
		
	public void setCountry(int country){
		this.country = country;
	}

	public String getName(){
		return name;
	}
		
	public void setName(String name){
		this.name = name;
	}


	@Override
	public void execute() {
		CorpsHandlerFactory.getHandler().handleSearchCorps(this.getSession().getPlayer(), this);
	}
}