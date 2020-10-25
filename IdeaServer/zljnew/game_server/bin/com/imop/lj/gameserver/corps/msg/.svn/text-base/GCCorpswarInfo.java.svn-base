package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 帮派竞赛信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpswarInfo extends GCMessage{
	
	/** 本帮派积分 */
	private int corpsScore;
	/** 帮派名字 */
	private String corpsName;
	/** 剩余时间，毫秒 */
	private long leftTime;
	/** 活动当前状态，1准备中，2已开始 */
	private int state;

	public GCCorpswarInfo (){
	}
	
	public GCCorpswarInfo (
			int corpsScore,
			String corpsName,
			long leftTime,
			int state ){
			this.corpsScore = corpsScore;
			this.corpsName = corpsName;
			this.leftTime = leftTime;
			this.state = state;
	}

	@Override
	protected boolean readImpl() {

	// 本帮派积分
	int _corpsScore = readInteger();
	//end


	// 帮派名字
	String _corpsName = readString();
	//end


	// 剩余时间，毫秒
	long _leftTime = readLong();
	//end


	// 活动当前状态，1准备中，2已开始
	int _state = readInteger();
	//end



		this.corpsScore = _corpsScore;
		this.corpsName = _corpsName;
		this.leftTime = _leftTime;
		this.state = _state;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 本帮派积分
	writeInteger(corpsScore);


	// 帮派名字
	writeString(corpsName);


	// 剩余时间，毫秒
	writeLong(leftTime);


	// 活动当前状态，1准备中，2已开始
	writeInteger(state);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CORPSWAR_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CORPSWAR_INFO";
	}

	public int getCorpsScore(){
		return corpsScore;
	}
		
	public void setCorpsScore(int corpsScore){
		this.corpsScore = corpsScore;
	}

	public String getCorpsName(){
		return corpsName;
	}
		
	public void setCorpsName(String corpsName){
		this.corpsName = corpsName;
	}

	public long getLeftTime(){
		return leftTime;
	}
		
	public void setLeftTime(long leftTime){
		this.leftTime = leftTime;
	}

	public int getState(){
		return state;
	}
		
	public void setState(int state){
		this.state = state;
	}
}