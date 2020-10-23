using System;
using System.IO;
namespace app.net
{

/**
 * 场景移除的玩家
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGScenePlayerMove :BaseMessage
{
	
	/** x坐标 */
	private int x;
	/** y坐标 */
	private int y;
	
	public CGScenePlayerMove ()
	{
	}
	
	public CGScenePlayerMove (
			int x,
			int y )
	{
			this.x = x;
			this.y = y;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// x坐标
	WriteInt(x);
	// y坐标
	WriteInt(y);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SCENE_PLAYER_MOVE;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}