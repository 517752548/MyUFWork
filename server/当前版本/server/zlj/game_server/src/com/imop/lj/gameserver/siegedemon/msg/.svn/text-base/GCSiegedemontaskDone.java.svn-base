package com.imop.lj.gameserver.siegedemon.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 已完成所有任务
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSiegedemontaskDone extends GCMessage{
	
	/** 任务类型 */
	private int questType;

	public GCSiegedemontaskDone (){
	}
	
	public GCSiegedemontaskDone (
			int questType ){
			this.questType = questType;
	}

	@Override
	protected boolean readImpl() {

	// 任务类型
	int _questType = readInteger();
	//end



		this.questType = _questType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 任务类型
	writeInteger(questType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SIEGEDEMONTASK_DONE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SIEGEDEMONTASK_DONE";
	}

	public int getQuestType(){
		return questType;
	}
		
	public void setQuestType(int questType){
		this.questType = questType;
	}
}