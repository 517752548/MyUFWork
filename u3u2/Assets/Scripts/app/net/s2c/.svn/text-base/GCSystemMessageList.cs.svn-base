
using System;
namespace app.net
{
/**
 * 系统提示消息列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSystemMessageList :BaseMessage
{
	/** 系统提示消息列表 */
	private SysMsgInfoData[] sysMsgInfoList;

	public GCSystemMessageList ()
	{
	}

	protected override void ReadImpl()
	{

	// 系统提示消息列表
	int sysMsgInfoListSize = ReadShort();
	SysMsgInfoData[] _sysMsgInfoList = new SysMsgInfoData[sysMsgInfoListSize];
	int sysMsgInfoListIndex = 0;
	SysMsgInfoData _sysMsgInfoListTmp = null;
	for(sysMsgInfoListIndex=0; sysMsgInfoListIndex<sysMsgInfoListSize; sysMsgInfoListIndex++){
		_sysMsgInfoListTmp = new SysMsgInfoData();
		_sysMsgInfoList[sysMsgInfoListIndex] = _sysMsgInfoListTmp;
	// 消息内容
	string _sysMsgInfoList_content = ReadString();	_sysMsgInfoListTmp.content = _sysMsgInfoList_content;
		// 消息显示类型
	short _sysMsgInfoList_showType = ReadShort();	_sysMsgInfoListTmp.showType = _sysMsgInfoList_showType;
		}
	//end



		this.sysMsgInfoList = _sysMsgInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SYSTEM_MESSAGE_LIST;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCSystemMessageListEvent;
	}
	

	public SysMsgInfoData[] getSysMsgInfoList(){
		return sysMsgInfoList;
	}


	public override bool isCompress() {
		return true;
	}
}
}