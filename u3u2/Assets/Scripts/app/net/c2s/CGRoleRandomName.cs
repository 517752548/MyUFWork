using System;
using System.IO;
namespace app.net
{

/**
 * 请求随机角色名
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGRoleRandomName :BaseMessage
{
	
	/** 发送选择主将男女性别0女1男 */
	private int sex;
	
	public CGRoleRandomName ()
	{
	}
	
	public CGRoleRandomName (
			int sex )
	{
			this.sex = sex;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 发送选择主将男女性别0女1男
	WriteInt(sex);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_ROLE_RANDOM_NAME;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}