package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 行为信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBehaviorInfo extends GCMessage{
	
	/** 行为信息列表 */
	private com.imop.lj.common.model.BehaviorInfo[] behaviorInfos;

	public GCBehaviorInfo (){
	}
	
	public GCBehaviorInfo (
			com.imop.lj.common.model.BehaviorInfo[] behaviorInfos ){
			this.behaviorInfos = behaviorInfos;
	}

	@Override
	protected boolean readImpl() {

	// 行为信息列表
	int behaviorInfosSize = readUnsignedShort();
	com.imop.lj.common.model.BehaviorInfo[] _behaviorInfos = new com.imop.lj.common.model.BehaviorInfo[behaviorInfosSize];
	int behaviorInfosIndex = 0;
	for(behaviorInfosIndex=0; behaviorInfosIndex<behaviorInfosSize; behaviorInfosIndex++){
		_behaviorInfos[behaviorInfosIndex] = new com.imop.lj.common.model.BehaviorInfo();
	// 行为类型，默认0
	int _behaviorInfos_bType = readInteger();
	//end
	_behaviorInfos[behaviorInfosIndex].setBType (_behaviorInfos_bType);

	// 行为id
	int _behaviorInfos_bIndex = readInteger();
	//end
	_behaviorInfos[behaviorInfosIndex].setBIndex (_behaviorInfos_bIndex);

	// 行为次数上限
	int _behaviorInfos_max = readInteger();
	//end
	_behaviorInfos[behaviorInfosIndex].setMax (_behaviorInfos_max);
	}
	//end



		this.behaviorInfos = _behaviorInfos;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 行为信息列表
	writeShort(behaviorInfos.length);
	int behaviorInfosIndex = 0;
	int behaviorInfosSize = behaviorInfos.length;
	for(behaviorInfosIndex=0; behaviorInfosIndex<behaviorInfosSize; behaviorInfosIndex++){

	int behaviorInfos_bType = behaviorInfos[behaviorInfosIndex].getBType();

	// 行为类型，默认0
	writeInteger(behaviorInfos_bType);

	int behaviorInfos_bIndex = behaviorInfos[behaviorInfosIndex].getBIndex();

	// 行为id
	writeInteger(behaviorInfos_bIndex);

	int behaviorInfos_max = behaviorInfos[behaviorInfosIndex].getMax();

	// 行为次数上限
	writeInteger(behaviorInfos_max);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_BEHAVIOR_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_BEHAVIOR_INFO";
	}

	public com.imop.lj.common.model.BehaviorInfo[] getBehaviorInfos(){
		return behaviorInfos;
	}

	public void setBehaviorInfos(com.imop.lj.common.model.BehaviorInfo[] behaviorInfos){
		this.behaviorInfos = behaviorInfos;
	}	
}