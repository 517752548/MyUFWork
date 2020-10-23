
using System;
namespace app.net
{
/**
 * 返回采矿界面结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLsMineGetPannel :BaseMessage
{
	/** 矿点信息 */
	private MinePitInfo[] pitList;
	/** 服务器时间 */
	private long serverTime;

	public GCLsMineGetPannel ()
	{
	}

	protected override void ReadImpl()
	{

	// 矿点信息
	int pitListSize = ReadShort();
	MinePitInfo[] _pitList = new MinePitInfo[pitListSize];
	int pitListIndex = 0;
	MinePitInfo _pitListTmp = null;
	for(pitListIndex=0; pitListIndex<pitListSize; pitListIndex++){
		_pitListTmp = new MinePitInfo();
		_pitList[pitListIndex] = _pitListTmp;
	// 矿坑ID
	int _pitList_id = ReadInt();	_pitListTmp.id = _pitList_id;
		// 矿石种类
	int _pitList_mineTypeId = ReadInt();	_pitListTmp.mineTypeId = _pitList_mineTypeId;
		// 开采方式Id
	int _pitList_miningTypeId = ReadInt();	_pitListTmp.miningTypeId = _pitList_miningTypeId;
		// 矿工名字
	string _pitList_minerName = ReadString();	_pitListTmp.minerName = _pitList_minerName;
		// 矿工Id
	long _pitList_minerId = ReadLong();	_pitListTmp.minerId = _pitList_minerId;
		// 矿工模型Id
	int _pitList_minerTplId = ReadInt();	_pitListTmp.minerTplId = _pitList_minerTplId;
		// 结束时间 
	long _pitList_endTime = ReadLong();	_pitListTmp.endTime = _pitList_endTime;
		}
	//end

	// 服务器时间
	long _serverTime = ReadLong();


		this.pitList = _pitList;
		this.serverTime = _serverTime;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
        return (short)0;// MessageType.GC_LS_MINE_GET_PANNEL;
	}
	
	public override string getEventType()
	{
        return "";// LifeskillGCHandler.GCLsMineGetPannelEvent;
	}
	

	public MinePitInfo[] getPitList(){
		return pitList;
	}


	public long getServerTime(){
		return serverTime;
	}
		

}
}