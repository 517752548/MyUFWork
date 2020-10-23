
using System;
namespace app.net
{
/**
 * 返回提升列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPromotePanel :BaseMessage
{
	/** 提升列表 */
	private PromoteInfo[] promoteInfo;

	public GCPromotePanel ()
	{
	}

	protected override void ReadImpl()
	{

	// 提升列表
	int promoteInfoSize = ReadShort();
	PromoteInfo[] _promoteInfo = new PromoteInfo[promoteInfoSize];
	int promoteInfoIndex = 0;
	PromoteInfo _promoteInfoTmp = null;
	for(promoteInfoIndex=0; promoteInfoIndex<promoteInfoSize; promoteInfoIndex++){
		_promoteInfoTmp = new PromoteInfo();
		_promoteInfo[promoteInfoIndex] = _promoteInfoTmp;
	// 提升Id
	int _promoteInfo_protmoteId = ReadInt();	_promoteInfoTmp.protmoteId = _promoteInfo_protmoteId;
		// 是否可以提升
	bool _promoteInfo_canPromote = ReadBool();	_promoteInfoTmp.canPromote = _promoteInfo_canPromote;
		}
	//end



		this.promoteInfo = _promoteInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PROMOTE_PANEL;
	}
	
	public override string getEventType()
	{
		return PromoteGCHandler.GCPromotePanelEvent;
	}
	

	public PromoteInfo[] getPromoteInfo(){
		return promoteInfo;
	}


}
}