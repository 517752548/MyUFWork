
using System;
namespace app.net
{
/**
 * 场景移除的玩家
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCScenePlayerRemoveList :BaseMessage
{
	/** 场景id */
	private int sceneId;
	/** 角色id */
	private long[] uuid;

	public GCScenePlayerRemoveList ()
	{
	}

	protected override void ReadImpl()
	{
	// 场景id
	int _sceneId = ReadInt();
	// 角色id
	int uuidSize = ReadShort();
	long[] _uuid = new long[uuidSize];
	int uuidIndex = 0;
	for(uuidIndex=0; uuidIndex<uuidSize; uuidIndex++){
		_uuid[uuidIndex] = ReadLong();
	}//end
	


		this.sceneId = _sceneId;
		this.uuid = _uuid;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SCENE_PLAYER_REMOVE_LIST;
	}
	
	public override string getEventType()
	{
		return SceneGCHandler.GCScenePlayerRemoveListEvent;
	}
	

	public int getSceneId(){
		return sceneId;
	}
		

	public long[] getUuid(){
		return uuid;
	}


}
}