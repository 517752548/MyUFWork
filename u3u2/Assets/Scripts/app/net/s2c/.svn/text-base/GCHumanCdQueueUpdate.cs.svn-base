
using System;
namespace app.net
{
/**
 * 服务器下发新的冷却队列信息（部分改变）
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCHumanCdQueueUpdate :BaseMessage
{
	/** 冷却队列 */
	private CdQueueInfoData[] cdQueueInfo;

	public GCHumanCdQueueUpdate ()
	{
	}

	protected override void ReadImpl()
	{

	// 冷却队列
	int cdQueueInfoSize = ReadShort();
	CdQueueInfoData[] _cdQueueInfo = new CdQueueInfoData[cdQueueInfoSize];
	int cdQueueInfoIndex = 0;
	CdQueueInfoData _cdQueueInfoTmp = null;
	for(cdQueueInfoIndex=0; cdQueueInfoIndex<cdQueueInfoSize; cdQueueInfoIndex++){
		_cdQueueInfoTmp = new CdQueueInfoData();
		_cdQueueInfo[cdQueueInfoIndex] = _cdQueueInfoTmp;
	// cd队列的类型
	int _cdQueueInfo_cdTypeInt = ReadInt();	_cdQueueInfoTmp.cdTypeInt = _cdQueueInfo_cdTypeInt;
		// cd队列索引
	int _cdQueueInfo_index = ReadInt();	_cdQueueInfoTmp.index = _cdQueueInfo_index;
		// cd队列名称
	string _cdQueueInfo_name = ReadString();	_cdQueueInfoTmp.name = _cdQueueInfo_name;
		// 图标
	string _cdQueueInfo_icon = ReadString();	_cdQueueInfoTmp.icon = _cdQueueInfo_icon;
		// 服务器当前时间到结束时间的时间差
	int _cdQueueInfo_currTimeDiff = ReadInt();	_cdQueueInfoTmp.currTimeDiff = _cdQueueInfo_currTimeDiff;
		// 是否已开启
	bool _cdQueueInfo_opened = ReadBool();	_cdQueueInfoTmp.opened = _cdQueueInfo_opened;
		// 是否可以累计时间
	bool _cdQueueInfo_canAddTime = ReadBool();	_cdQueueInfoTmp.canAddTime = _cdQueueInfo_canAddTime;
		}
	//end



		this.cdQueueInfo = _cdQueueInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_HUMAN_CD_QUEUE_UPDATE;
	}
	
	public override string getEventType()
	{
		return HumanGCHandler.GCHumanCdQueueUpdateEvent;
	}
	

	public CdQueueInfoData[] getCdQueueInfo(){
		return cdQueueInfo;
	}


}
}