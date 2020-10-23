using System;
using System.IO;
namespace app.net
{

/**
 * 查询邮件列表
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMailList :BaseMessage
{
	
	/** 查询的页面索引 */
	private int queryIndex;
	/** 邮箱类型1-inbox,2-sended,3-savebox */
	private int boxType;
	
	public CGMailList ()
	{
	}
	
	public CGMailList (
			int queryIndex,
			int boxType )
	{
			this.queryIndex = queryIndex;
			this.boxType = boxType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 查询的页面索引
	WriteInt(queryIndex);
	// 邮箱类型1-inbox,2-sended,3-savebox
	WriteInt(boxType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_MAIL_LIST;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}