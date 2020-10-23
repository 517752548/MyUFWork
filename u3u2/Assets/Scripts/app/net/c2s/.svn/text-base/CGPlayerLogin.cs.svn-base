using System;
using System.IO;
namespace app.net
{

/**
 * 用户登录
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerLogin :BaseMessage
{
	
	/** 玩家的账户 */
	private string account;
	/** 玩家的密码  */
	private string password;
	/** 玩家的来源，web登陆，ipad，iphone */
	private string source;
	
	public CGPlayerLogin ()
	{
	}
	
	public CGPlayerLogin (
			string account,
			string password,
			string source )
	{
			this.account = account;
			this.password = password;
			this.source = source;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 玩家的账户
	WriteString(account);
	// 玩家的密码 
	WriteString(password);
	// 玩家的来源，web登陆，ipad，iphone
	WriteString(source);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PLAYER_LOGIN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}