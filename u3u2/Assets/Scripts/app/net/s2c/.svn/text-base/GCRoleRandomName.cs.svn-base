
using System;
namespace app.net
{
/**
 * 随机角色名
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRoleRandomName :BaseMessage
{
	/** 角色名字 */
	private string name;

	public GCRoleRandomName ()
	{
	}

	protected override void ReadImpl()
	{
	// 角色名字
	string _name = ReadString();


		this.name = _name;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ROLE_RANDOM_NAME;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCRoleRandomNameEvent;
	}
	

	public string getName(){
		return name;
	}
		

}
}