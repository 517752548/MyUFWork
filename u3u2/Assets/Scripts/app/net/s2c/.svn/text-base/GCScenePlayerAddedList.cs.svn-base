
using System;
namespace app.net
{
/**
 * 场景新增的玩家
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCScenePlayerAddedList :BaseMessage
{
	/** 场景id */
	private int sceneId;
	/** 场景玩家信息 */
	private ScenePlayerInfoData[] scenePlayerInfoDataList;

	public GCScenePlayerAddedList ()
	{
	}

	protected override void ReadImpl()
	{
	// 场景id
	int _sceneId = ReadInt();

	// 场景玩家信息
	int scenePlayerInfoDataListSize = ReadShort();
	ScenePlayerInfoData[] _scenePlayerInfoDataList = new ScenePlayerInfoData[scenePlayerInfoDataListSize];
	int scenePlayerInfoDataListIndex = 0;
	ScenePlayerInfoData _scenePlayerInfoDataListTmp = null;
	for(scenePlayerInfoDataListIndex=0; scenePlayerInfoDataListIndex<scenePlayerInfoDataListSize; scenePlayerInfoDataListIndex++){
		_scenePlayerInfoDataListTmp = new ScenePlayerInfoData();
		_scenePlayerInfoDataList[scenePlayerInfoDataListIndex] = _scenePlayerInfoDataListTmp;
	// 角色id
	long _scenePlayerInfoDataList_uuid = ReadLong();	_scenePlayerInfoDataListTmp.uuid = _scenePlayerInfoDataList_uuid;
		// 玩家信息json串
	string _scenePlayerInfoDataList_playerDataJson = ReadString();	_scenePlayerInfoDataListTmp.playerDataJson = _scenePlayerInfoDataList_playerDataJson;
		}
	//end



		this.sceneId = _sceneId;
		this.scenePlayerInfoDataList = _scenePlayerInfoDataList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SCENE_PLAYER_ADDED_LIST;
	}
	
	public override string getEventType()
	{
		return SceneGCHandler.GCScenePlayerAddedListEvent;
	}
	

	public int getSceneId(){
		return sceneId;
	}
		

	public ScenePlayerInfoData[] getScenePlayerInfoDataList(){
		return scenePlayerInfoDataList;
	}


	public override bool isCompress() {
		return true;
	}
}
}