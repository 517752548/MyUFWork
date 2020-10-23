using System;
using System.IO;
namespace app.net
{

/**
 * 玩家进入场景
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGScenePlayerEnter :BaseMessage
{
	
	/** 场景id */
	private int sceneId;
	
	public CGScenePlayerEnter ()
	{
	}
	
	public CGScenePlayerEnter (
			int sceneId )
	{
			this.sceneId = sceneId;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 场景id
	WriteInt(sceneId);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_SCENE_PLAYER_ENTER;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}