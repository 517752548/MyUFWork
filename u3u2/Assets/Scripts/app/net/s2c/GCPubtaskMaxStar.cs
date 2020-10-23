
using System;
namespace app.net
{
/**
 * 玩家酒馆任务最大星数
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPubtaskMaxStar :BaseMessage
{
	/** 玩家酒馆任务最大星数 */
	private int star;

	public GCPubtaskMaxStar ()
	{
	}

	protected override void ReadImpl()
	{
	// 玩家酒馆任务最大星数
	int _star = ReadInt();


		this.star = _star;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PUBTASK_MAX_STAR;
	}
	
	public override string getEventType()
	{
		return PubtaskGCHandler.GCPubtaskMaxStarEvent;
	}
	

	public int getStar(){
		return star;
	}
		

}
}