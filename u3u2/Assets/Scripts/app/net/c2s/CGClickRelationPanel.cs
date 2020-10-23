using System;
using System.IO;
namespace app.net
{

/**
 * 打开好友面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGClickRelationPanel :BaseMessage
{
	
	/** 1好友，2黑名单 */
	private int relationType;
	/** 页码 */
	private int page;
	
	public CGClickRelationPanel ()
	{
	}
	
	public CGClickRelationPanel (
			int relationType,
			int page )
	{
			this.relationType = relationType;
			this.page = page;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 1好友，2黑名单
	WriteInt(relationType);
	// 页码
	WriteInt(page);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CLICK_RELATION_PANEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}