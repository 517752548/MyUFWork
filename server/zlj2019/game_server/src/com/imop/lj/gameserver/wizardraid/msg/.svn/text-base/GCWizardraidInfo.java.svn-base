package com.imop.lj.gameserver.wizardraid.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 副本信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWizardraidInfo extends GCMessage{
	
	/** 当前波数 */
	private int wave;
	/** 击杀怪物数量 */
	private int winNum;
	/** 剩余时间，毫秒 */
	private long leftTime;

	public GCWizardraidInfo (){
	}
	
	public GCWizardraidInfo (
			int wave,
			int winNum,
			long leftTime ){
			this.wave = wave;
			this.winNum = winNum;
			this.leftTime = leftTime;
	}

	@Override
	protected boolean readImpl() {

	// 当前波数
	int _wave = readInteger();
	//end


	// 击杀怪物数量
	int _winNum = readInteger();
	//end


	// 剩余时间，毫秒
	long _leftTime = readLong();
	//end



		this.wave = _wave;
		this.winNum = _winNum;
		this.leftTime = _leftTime;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 当前波数
	writeInteger(wave);


	// 击杀怪物数量
	writeInteger(winNum);


	// 剩余时间，毫秒
	writeLong(leftTime);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_WIZARDRAID_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_WIZARDRAID_INFO";
	}

	public int getWave(){
		return wave;
	}
		
	public void setWave(int wave){
		this.wave = wave;
	}

	public int getWinNum(){
		return winNum;
	}
		
	public void setWinNum(int winNum){
		this.winNum = winNum;
	}

	public long getLeftTime(){
		return leftTime;
	}
		
	public void setLeftTime(long leftTime){
		this.leftTime = leftTime;
	}
}