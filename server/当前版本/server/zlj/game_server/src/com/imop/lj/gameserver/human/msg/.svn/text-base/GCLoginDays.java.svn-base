package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 玩家登录天数
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLoginDays extends GCMessage{
	
	/** 天数 */
	private int day;

	public GCLoginDays (){
	}
	
	public GCLoginDays (
			int day ){
			this.day = day;
	}

	@Override
	protected boolean readImpl() {

	// 天数
	int _day = readInteger();
	//end



		this.day = _day;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 天数
	writeInteger(day);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_LOGIN_DAYS;
	}
	
	@Override
	public String getTypeName() {
		return "GC_LOGIN_DAYS";
	}

	public int getDay(){
		return day;
	}
		
	public void setDay(int day){
		this.day = day;
	}
}