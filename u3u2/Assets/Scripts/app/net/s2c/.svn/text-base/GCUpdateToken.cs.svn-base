
using System;
namespace app.net
{
/**
 * 更新token
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUpdateToken :BaseMessage
{
	/** passportId */
	private string pid;
	/** 角色id */
	private long rid;
	/** token */
	private string token;

	public GCUpdateToken ()
	{
	}

	protected override void ReadImpl()
	{
	// passportId
	string _pid = ReadString();
	// 角色id
	long _rid = ReadLong();
	// token
	string _token = ReadString();


		this.pid = _pid;
		this.rid = _rid;
		this.token = _token;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_UPDATE_TOKEN;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCUpdateTokenEvent;
	}
	

	public string getPid(){
		return pid;
	}
		

	public long getRid(){
		return rid;
	}
		

	public string getToken(){
		return token;
	}
		

}
}