
using System;
namespace app.net
{
/**
 * 场景移动的玩家
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCScenePlayerMovedList :BaseMessage
{
	/** 场景id */
	private int sceneId;
	/** 场景玩家信息 */
	private ScenePlayerMoveInfo[] scenePlayerMoveList;

	public GCScenePlayerMovedList ()
	{
	}

	protected override void ReadImpl()
	{
	// 场景id
	int _sceneId = ReadInt();

	// 场景玩家信息
	int scenePlayerMoveListSize = ReadShort();
	ScenePlayerMoveInfo[] _scenePlayerMoveList = new ScenePlayerMoveInfo[scenePlayerMoveListSize];
	int scenePlayerMoveListIndex = 0;
	ScenePlayerMoveInfo _scenePlayerMoveListTmp = null;
	for(scenePlayerMoveListIndex=0; scenePlayerMoveListIndex<scenePlayerMoveListSize; scenePlayerMoveListIndex++){
		_scenePlayerMoveListTmp = new ScenePlayerMoveInfo();
		_scenePlayerMoveList[scenePlayerMoveListIndex] = _scenePlayerMoveListTmp;
	// 角色id
	long _scenePlayerMoveList_uuid = ReadLong();	_scenePlayerMoveListTmp.uuid = _scenePlayerMoveList_uuid;
		// x坐标
	int _scenePlayerMoveList_x = ReadInt();	_scenePlayerMoveListTmp.x = _scenePlayerMoveList_x;
		// y坐标
	int _scenePlayerMoveList_y = ReadInt();	_scenePlayerMoveListTmp.y = _scenePlayerMoveList_y;
		// 是否瞬移，0否，1是
	int _scenePlayerMoveList_instantFlag = ReadInt();	_scenePlayerMoveListTmp.instantFlag = _scenePlayerMoveList_instantFlag;
		}
	//end



		this.sceneId = _sceneId;
		this.scenePlayerMoveList = _scenePlayerMoveList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SCENE_PLAYER_MOVED_LIST;
	}
	
	public override string getEventType()
	{
		return SceneGCHandler.GCScenePlayerMovedListEvent;
	}
	

	public int getSceneId(){
		return sceneId;
	}
		

	public ScenePlayerMoveInfo[] getScenePlayerMoveList(){
		return scenePlayerMoveList;
	}


	public override bool isCompress() {
		return true;
	}
}
}