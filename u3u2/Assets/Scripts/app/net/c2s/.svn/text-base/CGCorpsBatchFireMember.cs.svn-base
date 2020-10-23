using System;
using System.IO;
namespace app.net
{

/**
 * 批量踢出成员
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCorpsBatchFireMember :BaseMessage
{
	
	/** 成员IDLIST */
	private long[] targetIds;
	
	public CGCorpsBatchFireMember ()
	{
	}
	
	public CGCorpsBatchFireMember (
			long[] targetIds )
	{
			this.targetIds = targetIds;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 成员IDLIST
	WriteShort((short)targetIds.Length);
	int targetIdsSize = targetIds.Length;
	int targetIdsIndex = 0;
	for(targetIdsIndex=0; targetIdsIndex<targetIdsSize; targetIdsIndex++){
		WriteLong(targetIds [ targetIdsIndex ]);
	}//end
	

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CORPS_BATCH_FIRE_MEMBER;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public long[] getTargetIds()
	{
		return targetIds;
	}

	public void setTargetIds(long[] targetIds)
	{
		this.targetIds = targetIds;
	}
	}
}