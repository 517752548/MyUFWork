
using System;
namespace app.net
{
/**
 * nvn联赛规则
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNvnRule :BaseMessage
{
	/** 等级 */
	private int level;
	/** 人数最低 */
	private int memberNum;
	/** 奖励名称 */
	private string[] showRewardNameList;
	/** 奖励内容 */
	private string[] showRewardList;

	public GCNvnRule ()
	{
	}

	protected override void ReadImpl()
	{
	// 等级
	int _level = ReadInt();
	// 人数最低
	int _memberNum = ReadInt();
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
	


		this.level = _level;
		this.memberNum = _memberNum;
		this.showRewardNameList = _showRewardNameList;
		this.showRewardList = _showRewardList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_NVN_RULE;
	}
	
	public override string getEventType()
	{
		return NvnGCHandler.GCNvnRuleEvent;
	}
	

	public int getLevel(){
		return level;
	}
		

	public int getMemberNum(){
		return memberNum;
	}
		

	public string[] getShowRewardNameList(){
		return showRewardNameList;
	}


	public string[] getShowRewardList(){
		return showRewardList;
	}


}
}