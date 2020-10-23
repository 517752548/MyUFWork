
using System;
namespace app.net
{
/**
 * 删除关系成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDelRelation :BaseMessage
{
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家Id */
	private long targetCharId;

	public GCDelRelation ()
	{
	}

	protected override void ReadImpl()
	{
	// 1好友，2黑名单
	int _relationType = ReadInt();
	// 目标玩家Id
	long _targetCharId = ReadLong();


		this.relationType = _relationType;
		this.targetCharId = _targetCharId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_DEL_RELATION;
	}
	
	public override string getEventType()
	{
		return RelationGCHandler.GCDelRelationEvent;
	}
	

	public int getRelationType(){
		return relationType;
	}
		

	public long getTargetCharId(){
		return targetCharId;
	}
		

}
}