
using System;
namespace app.net
{
/**
 * nvn联赛我的信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNvnMyInfo :BaseMessage
{
	/** 排名 */
	private int rank;
	/** 连胜数 */
	private int conWinNum;
	/** 积分 */
	private int score;
	/** 队伍积分 */
	private int teamScore;
	/** 队伍状态 */
	private int teamStatus;
	/** 积分日志列表 */
	private string[] myLog;

	public GCNvnMyInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 排名
	int _rank = ReadInt();
	// 连胜数
	int _conWinNum = ReadInt();
	// 积分
	int _score = ReadInt();
	// 队伍积分
	int _teamScore = ReadInt();
	// 队伍状态
	int _teamStatus = ReadInt();
	// 积分日志列表
	int myLogSize = ReadShort();
	string[] _myLog = new string[myLogSize];
	int myLogIndex = 0;
	for(myLogIndex=0; myLogIndex<myLogSize; myLogIndex++){
		_myLog[myLogIndex] = ReadString();
	}//end
	


		this.rank = _rank;
		this.conWinNum = _conWinNum;
		this.score = _score;
		this.teamScore = _teamScore;
		this.teamStatus = _teamStatus;
		this.myLog = _myLog;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_NVN_MY_INFO;
	}
	
	public override string getEventType()
	{
		return NvnGCHandler.GCNvnMyInfoEvent;
	}
	

	public int getRank(){
		return rank;
	}
		

	public int getConWinNum(){
		return conWinNum;
	}
		

	public int getScore(){
		return score;
	}
		

	public int getTeamScore(){
		return teamScore;
	}
		

	public int getTeamStatus(){
		return teamStatus;
	}
		

	public string[] getMyLog(){
		return myLog;
	}


}
}