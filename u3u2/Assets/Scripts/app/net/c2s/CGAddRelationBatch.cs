using System;
using System.IO;
namespace app.net
{

/**
 * 批量添加关系
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGAddRelationBatch :BaseMessage
{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 目标玩家Id列表 */
	private long[] targetCharIdArr;
	
	public CGAddRelationBatch ()
	{
	}
	
	public CGAddRelationBatch (
			int relationType,
			long[] targetCharIdArr )
	{
			this.relationType = relationType;
			this.targetCharIdArr = targetCharIdArr;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 1好友，2黑名单
	WriteInt(relationType);
	// 目标玩家Id列表
	WriteShort((short)targetCharIdArr.Length);
	int targetCharIdArrSize = targetCharIdArr.Length;
	int targetCharIdArrIndex = 0;
	for(targetCharIdArrIndex=0; targetCharIdArrIndex<targetCharIdArrSize; targetCharIdArrIndex++){
		WriteLong(targetCharIdArr [ targetCharIdArrIndex ]);
	}//end
	

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ADD_RELATION_BATCH;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public long[] getTargetCharIdArr()
	{
		return targetCharIdArr;
	}

	public void setTargetCharIdArr(long[] targetCharIdArr)
	{
		this.targetCharIdArr = targetCharIdArr;
	}
	}
}