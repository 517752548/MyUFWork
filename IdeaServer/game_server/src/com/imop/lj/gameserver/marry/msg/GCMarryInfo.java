package com.imop.lj.gameserver.marry.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 结婚相关信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMarryInfo extends GCMessage{
	
	/** 丈夫 */
	private long husband;
	/** 丈夫 */
	private String husbandName;
	/** 妻子 */
	private long wife;
	/** 妻子 */
	private String wifeName;

	public GCMarryInfo (){
	}
	
	public GCMarryInfo (
			long husband,
			String husbandName,
			long wife,
			String wifeName ){
			this.husband = husband;
			this.husbandName = husbandName;
			this.wife = wife;
			this.wifeName = wifeName;
	}

	@Override
	protected boolean readImpl() {

	// 丈夫
	long _husband = readLong();
	//end


	// 丈夫
	String _husbandName = readString();
	//end


	// 妻子
	long _wife = readLong();
	//end


	// 妻子
	String _wifeName = readString();
	//end



		this.husband = _husband;
		this.husbandName = _husbandName;
		this.wife = _wife;
		this.wifeName = _wifeName;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 丈夫
	writeLong(husband);


	// 丈夫
	writeString(husbandName);


	// 妻子
	writeLong(wife);


	// 妻子
	writeString(wifeName);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MARRY_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MARRY_INFO";
	}

	public long getHusband(){
		return husband;
	}
		
	public void setHusband(long husband){
		this.husband = husband;
	}

	public String getHusbandName(){
		return husbandName;
	}
		
	public void setHusbandName(String husbandName){
		this.husbandName = husbandName;
	}

	public long getWife(){
		return wife;
	}
		
	public void setWife(long wife){
		this.wife = wife;
	}

	public String getWifeName(){
		return wifeName;
	}
		
	public void setWifeName(String wifeName){
		this.wifeName = wifeName;
	}
}