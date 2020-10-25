package com.imop.lj.gameserver.wizardraid.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 绿野仙踪剩余免费进入次数
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWizardraidLeftTimes extends GCMessage{
	
	/** 剩余免费进入次数 */
	private int leftFreeTimes;

	public GCWizardraidLeftTimes (){
	}
	
	public GCWizardraidLeftTimes (
			int leftFreeTimes ){
			this.leftFreeTimes = leftFreeTimes;
	}

	@Override
	protected boolean readImpl() {

	// 剩余免费进入次数
	int _leftFreeTimes = readInteger();
	//end



		this.leftFreeTimes = _leftFreeTimes;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 剩余免费进入次数
	writeInteger(leftFreeTimes);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_WIZARDRAID_LEFT_TIMES;
	}
	
	@Override
	public String getTypeName() {
		return "GC_WIZARDRAID_LEFT_TIMES";
	}

	public int getLeftFreeTimes(){
		return leftFreeTimes;
	}
		
	public void setLeftFreeTimes(int leftFreeTimes){
		this.leftFreeTimes = leftFreeTimes;
	}
}