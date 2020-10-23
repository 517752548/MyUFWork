
using System;
namespace app.net
{
/**
 * 返回查看通天塔每层的奖励
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTowerReward :BaseMessage
{
	/** 奖励名称 */
	private string[] showRewardNameList;
	/** 奖励内容 */
	private string[] showRewardList;

	public GCTowerReward ()
	{
	}

	protected override void ReadImpl()
	{
	// 奖励名称
	int showRewardNameListSize = ReadShort();
	string[] _showRewardNameList = new string[showRewardNameListSize];
	int showRewardNameListIndex = 0;
	for(showRewardNameListIndex=0; showRewardNameListIndex<showRewardNameListSize; showRewardNameListIndex++){
		_showRewardNameList[showRewardNameListIndex] = ReadString();
	}//end
	
	// 奖励内容
	int showRewardListSize = ReadShort();
	string[] _showRewardList = new string[showRewardListSize];
	int showRewardListIndex = 0;
	for(showRewardListIndex=0; showRewardListIndex<showRewardListSize; showRewardListIndex++){
		_showRewardList[showRewardListIndex] = ReadString();
	}//end
	


		this.showRewardNameList = _showRewardNameList;
		this.showRewardList = _showRewardList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TOWER_REWARD;
	}
	
	public override string getEventType()
	{
		return TowerGCHandler.GCTowerRewardEvent;
	}
	

	public string[] getShowRewardNameList(){
		return showRewardNameList;
	}


	public string[] getShowRewardList(){
		return showRewardList;
	}


}
}