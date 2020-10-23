
using System;
namespace app.net
{
/**
 * 行为信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBehaviorInfo :BaseMessage
{
	/** 行为信息列表 */
	private BehaviorInfoData[] behaviorInfos;

	public GCBehaviorInfo ()
	{
	}

	protected override void ReadImpl()
	{

	// 行为信息列表
	int behaviorInfosSize = ReadShort();
	BehaviorInfoData[] _behaviorInfos = new BehaviorInfoData[behaviorInfosSize];
	int behaviorInfosIndex = 0;
	BehaviorInfoData _behaviorInfosTmp = null;
	for(behaviorInfosIndex=0; behaviorInfosIndex<behaviorInfosSize; behaviorInfosIndex++){
		_behaviorInfosTmp = new BehaviorInfoData();
		_behaviorInfos[behaviorInfosIndex] = _behaviorInfosTmp;
	// 行为类型，默认0
	int _behaviorInfos_bType = ReadInt();	_behaviorInfosTmp.bType = _behaviorInfos_bType;
		// 行为id
	int _behaviorInfos_bIndex = ReadInt();	_behaviorInfosTmp.bIndex = _behaviorInfos_bIndex;
		// 行为次数上限
	int _behaviorInfos_max = ReadInt();	_behaviorInfosTmp.max = _behaviorInfos_max;
		}
	//end



		this.behaviorInfos = _behaviorInfos;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_BEHAVIOR_INFO;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCBehaviorInfoEvent;
	}
	

	public BehaviorInfoData[] getBehaviorInfos(){
		return behaviorInfos;
	}


}
}