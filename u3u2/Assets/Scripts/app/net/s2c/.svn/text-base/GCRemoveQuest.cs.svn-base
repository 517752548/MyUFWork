
using System;
namespace app.net
{
/**
 * 删除一个任务
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRemoveQuest :BaseMessage
{
	/** 任务Id */
	private int questId;

	public GCRemoveQuest ()
	{
	}

	protected override void ReadImpl()
	{
	// 任务Id
	int _questId = ReadInt();


		this.questId = _questId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_REMOVE_QUEST;
	}
	
	public override string getEventType()
	{
		return QuestGCHandler.GCRemoveQuestEvent;
	}
	

	public int getQuestId(){
		return questId;
	}
		

}
}