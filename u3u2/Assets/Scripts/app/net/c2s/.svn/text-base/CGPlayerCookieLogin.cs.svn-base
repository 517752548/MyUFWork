using System;
using System.IO;
namespace app.net
{

/**
 * 用户cookie登录
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerCookieLogin :BaseMessage
{
	
	/** cookie值 */
	private string cookieValue;
	/** 玩家的终端信息，web登陆，ipad，iphone */
	private string source;
	
	public CGPlayerCookieLogin ()
	{
	}
	
	public CGPlayerCookieLogin (
			string cookieValue,
			string source )
	{
			this.cookieValue = cookieValue;
			this.source = source;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// cookie值
	WriteString(cookieValue);
	// 玩家的终端信息，web登陆，ipad，iphone
	WriteString(source);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PLAYER_COOKIE_LOGIN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}