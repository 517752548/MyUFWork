
using System;
namespace app.net
{
/**
 * 接受任务客户端动画
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCAcceptQuest :BaseMessage
{
	/** 任务Id */
	private int questId;

	public GCAcceptQuest ()
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
		return (short)MessageType.GC_ACCEPT_QUEST;
	}
	
	public override string getEventType()
	{
		return QuestGCHandler.GCAcceptQuestEvent;
	}
	

	public int getQuestId(){
		return questId;
	}
		

}
}