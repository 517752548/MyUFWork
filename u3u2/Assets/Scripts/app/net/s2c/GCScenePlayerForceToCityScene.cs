
using System;
namespace app.net
{
/**
 * 玩家被强制踢回主城
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCScenePlayerForceToCityScene :BaseMessage
{
	/** 从哪个场景被踢的 */
	private int fromSceneId;

	public GCScenePlayerForceToCityScene ()
	{
	}

	protected override void ReadImpl()
	{
	// 从哪个场景被踢的
	int _fromSceneId = ReadInt();


		this.fromSceneId = _fromSceneId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SCENE_PLAYER_FORCE_TO_CITY_SCENE;
	}
	
	public override string getEventType()
	{
		return SceneGCHandler.GCScenePlayerForceToCitySceneEvent;
	}
	

	public int getFromSceneId(){
		return fromSceneId;
	}
		

}
}