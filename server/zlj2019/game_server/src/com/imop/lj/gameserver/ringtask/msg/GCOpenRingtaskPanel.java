package com.imop.lj.gameserver.ringtask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 打开跑环任务面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenRingtaskPanel extends GCMessage{
	
	/** 今日已完成任务数 */
	private int finishTimes;
	/** 总任务数 */
	private int totalTimes;
	/** 今日已放弃次数 */
	private int giveUpTimes;
	/** 总放弃次数 */
	private int giveUpTotalTimes;

	public GCOpenRingtaskPanel (){
	}
	
	public GCOpenRingtaskPanel (
			int finishTimes,
			int totalTimes,
			int giveUpTimes,
			int giveUpTotalTimes ){
			this.finishTimes = finishTimes;
			this.totalTimes = totalTimes;
			this.giveUpTimes = giveUpTimes;
			this.giveUpTotalTimes = giveUpTotalTimes;
	}

	@Override
	protected boolean readImpl() {

	// 今日已完成任务数
	int _finishTimes = readInteger();
	//end


	// 总任务数
	int _totalTimes = readInteger();
	//end


	// 今日已放弃次数
	int _giveUpTimes = readInteger();
	//end


	// 总放弃次数
	int _giveUpTotalTimes = readInteger();
	//end



		this.finishTimes = _finishTimes;
		this.totalTimes = _totalTimes;
		this.giveUpTimes = _giveUpTimes;
		this.giveUpTotalTimes = _giveUpTotalTimes;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 今日已完成任务数
	writeInteger(finishTimes);


	// 总任务数
	writeInteger(totalTimes);


	// 今日已放弃次数
	writeInteger(giveUpTimes);


	// 总放弃次数
	writeInteger(giveUpTotalTimes);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OPEN_RINGTASK_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_RINGTASK_PANEL";
	}

	public int getFinishTimes(){
		return finishTimes;
	}
		
	public void setFinishTimes(int finishTimes){
		this.finishTimes = finishTimes;
	}

	public int getTotalTimes(){
		return totalTimes;
	}
		
	public void setTotalTimes(int totalTimes){
		this.totalTimes = totalTimes;
	}

	public int getGiveUpTimes(){
		return giveUpTimes;
	}
		
	public void setGiveUpTimes(int giveUpTimes){
		this.giveUpTimes = giveUpTimes;
	}

	public int getGiveUpTotalTimes(){
		return giveUpTotalTimes;
	}
		
	public void setGiveUpTotalTimes(int giveUpTotalTimes){
		this.giveUpTotalTimes = giveUpTotalTimes;
	}
}