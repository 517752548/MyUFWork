using System;
using System.IO;
namespace app.net
{

/**
 * 填写防沉迷认证信息
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGWallowAddInfo :BaseMessage
{
	
	/** 真实姓名 */
	private string name;
	/** 身份证号 */
	private string idCard;
	
	public CGWallowAddInfo ()
	{
	}
	
	public CGWallowAddInfo (
			string name,
			string idCard )
	{
			this.name = name;
			this.idCard = idCard;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 真实姓名
	WriteString(name);
	// 身份证号
	WriteString(idCard);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_WALLOW_ADD_INFO;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}