using System;
using System.IO;
namespace app.net
{

/**
 * 用户token登录
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayerTokenLogin :BaseMessage
{
	
	/** passportId */
	private string pid;
	/** 角色id */
	private long rid;
	/** token */
	private string token;
	/** 玩家的终端信息，web登陆，ipad，iphone */
	private string source;
	
	public CGPlayerTokenLogin ()
	{
	}
	
	public CGPlayerTokenLogin (
			string pid,
			long rid,
			string token,
			string source )
	{
			this.pid = pid;
			this.rid = rid;
			this.token = token;
			this.source = source;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// passportId
	WriteString(pid);
	// 角色id
	WriteLong(rid);
	// token
	WriteString(token);
	// 玩家的终端信息，web登陆，ipad，iphone
	WriteString(source);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_PLAYER_TOKEN_LOGIN;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}