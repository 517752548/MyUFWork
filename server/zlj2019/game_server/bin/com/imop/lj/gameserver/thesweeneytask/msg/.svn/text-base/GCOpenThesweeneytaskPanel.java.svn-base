package com.imop.lj.gameserver.thesweeneytask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 除暴安良推送
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenThesweeneytaskPanel extends GCMessage{
	
	/** 今日已完成任务数 */
	private int finishTimes;
	/** 总任务数 */
	private int totalTimes;

	public GCOpenThesweeneytaskPanel (){
	}
	
	public GCOpenThesweeneytaskPanel (
			int finishTimes,
			int totalTimes ){
			this.finishTimes = finishTimes;
			this.totalTimes = totalTimes;
	}

	@Override
	protected boolean readImpl() {

	// 今日已完成任务数
	int _finishTimes = readInteger();
	//end


	// 总任务数
	int _totalTimes = readInteger();
	//end



		this.finishTimes = _finishTimes;
		this.totalTimes = _totalTimes;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 今日已完成任务数
	writeInteger(finishTimes);


	// 总任务数
	writeInteger(totalTimes);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OPEN_THESWEENEYTASK_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_THESWEENEYTASK_PANEL";
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
}