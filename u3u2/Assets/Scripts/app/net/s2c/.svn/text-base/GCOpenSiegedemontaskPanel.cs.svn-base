
using System;
namespace app.net
{
/**
 * 打开围剿魔族副本任务面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenSiegedemontaskPanel :BaseMessage
{
	/** 任务面板信息 */
	private QuestPanelInfo[] questPanelInfo;

	public GCOpenSiegedemontaskPanel ()
	{
	}

	protected override void ReadImpl()
	{

	// 任务面板信息
	int questPanelInfoSize = ReadShort();
	QuestPanelInfo[] _questPanelInfo = new QuestPanelInfo[questPanelInfoSize];
	int questPanelInfoIndex = 0;
	QuestPanelInfo _questPanelInfoTmp = null;
	for(questPanelInfoIndex=0; questPanelInfoIndex<questPanelInfoSize; questPanelInfoIndex++){
		_questPanelInfoTmp = new QuestPanelInfo();
		_questPanelInfo[questPanelInfoIndex] = _questPanelInfoTmp;
	// 任务类型
	int _questPanelInfo_questType = ReadInt();	_questPanelInfoTmp.questType = _questPanelInfo_questType;
		// 任务等级限制
	int _questPanelInfo_questMinLevel = ReadInt();	_questPanelInfoTmp.questMinLevel = _questPanelInfo_questMinLevel;
		// 今日已完成任务数
	int _questPanelInfo_finishTimes = ReadInt();	_questPanelInfoTmp.finishTimes = _questPanelInfo_finishTimes;
		// 总任务数
	int _questPanelInfo_totalTimes = ReadInt();	_questPanelInfoTmp.totalTimes = _questPanelInfo_totalTimes;
		}
	//end



		this.questPanelInfo = _questPanelInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_SIEGEDEMONTASK_PANEL;
	}
	
	public override string getEventType()
	{
		return SiegedemonGCHandler.GCOpenSiegedemontaskPanelEvent;
	}
	

	public QuestPanelInfo[] getQuestPanelInfo(){
		return questPanelInfo;
	}


}
}