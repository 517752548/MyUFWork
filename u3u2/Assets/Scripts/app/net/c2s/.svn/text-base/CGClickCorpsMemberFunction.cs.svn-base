using System;
using System.IO;
namespace app.net
{

/**
 * 点击军团成员相关功能
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGClickCorpsMemberFunction :BaseMessage
{
	
	/** 军团成员ID */
	private long corpsMemberId;
	/** 功能ID */
	private int funcId;
	
	public CGClickCorpsMemberFunction ()
	{
	}
	
	public CGClickCorpsMemberFunction (
			long corpsMemberId,
			int funcId )
	{
			this.corpsMemberId = corpsMemberId;
			this.funcId = funcId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 军团成员ID
	WriteLong(corpsMemberId);
	// 功能ID
	WriteInt(funcId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CLICK_CORPS_MEMBER_FUNCTION;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}