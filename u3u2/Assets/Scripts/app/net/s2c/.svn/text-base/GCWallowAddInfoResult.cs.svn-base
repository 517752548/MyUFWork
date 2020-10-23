
using System;
namespace app.net
{
/**
 * 防沉迷认证结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWallowAddInfoResult :BaseMessage
{
	/** 认证结果 */
	private string result;

	public GCWallowAddInfoResult ()
	{
	}

	protected override void ReadImpl()
	{
	// 认证结果
	string _result = ReadString();


		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_WALLOW_ADD_INFO_RESULT;
	}
	
	public override string getEventType()
	{
		return WallowGCHandler.GCWallowAddInfoResultEvent;
	}
	

	public string getResult(){
		return result;
	}
		

}
}