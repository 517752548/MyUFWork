
using System;
namespace app.net
{
/**
 * 玩家已经进入场景
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEnterScene :BaseMessage
{
	/** 场景Id */
	private int sceneId;
	/** 场景名称 */
	private string sceneName;

	public GCEnterScene ()
	{
	}

	protected override void ReadImpl()
	{
	// 场景Id
	int _sceneId = ReadInt();
	// 场景名称
	string _sceneName = ReadString();


		this.sceneId = _sceneId;
		this.sceneName = _sceneName;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ENTER_SCENE;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCEnterSceneEvent;
	}
	

	public int getSceneId(){
		return sceneId;
	}
		

	public string getSceneName(){
		return sceneName;
	}
		

}
}