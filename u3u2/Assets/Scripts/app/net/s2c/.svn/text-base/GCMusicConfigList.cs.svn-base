
using System;
namespace app.net
{
/**
 * 音乐常量配置列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMusicConfigList :BaseMessage
{
	/** 音乐配置列表 */
	private MusicConfigInfoData[] musicConfigInfoList;
	/** 音乐与功能对应列表 */
	private MusicInfoData[] musicInfoList;

	public GCMusicConfigList ()
	{
	}

	protected override void ReadImpl()
	{

	// 音乐配置列表
	int musicConfigInfoListSize = ReadShort();
	MusicConfigInfoData[] _musicConfigInfoList = new MusicConfigInfoData[musicConfigInfoListSize];
	int musicConfigInfoListIndex = 0;
	MusicConfigInfoData _musicConfigInfoListTmp = null;
	for(musicConfigInfoListIndex=0; musicConfigInfoListIndex<musicConfigInfoListSize; musicConfigInfoListIndex++){
		_musicConfigInfoListTmp = new MusicConfigInfoData();
		_musicConfigInfoList[musicConfigInfoListIndex] = _musicConfigInfoListTmp;
	// ID
	int _musicConfigInfoList_id = ReadInt();	_musicConfigInfoListTmp.id = _musicConfigInfoList_id;
		// 资源ID
	int _musicConfigInfoList_resId = ReadInt();	_musicConfigInfoListTmp.resId = _musicConfigInfoList_resId;
		// 是否循环
	int _musicConfigInfoList_loop = ReadInt();	_musicConfigInfoListTmp.loop = _musicConfigInfoList_loop;
		}
	//end


	// 音乐与功能对应列表
	int musicInfoListSize = ReadShort();
	MusicInfoData[] _musicInfoList = new MusicInfoData[musicInfoListSize];
	int musicInfoListIndex = 0;
	MusicInfoData _musicInfoListTmp = null;
	for(musicInfoListIndex=0; musicInfoListIndex<musicInfoListSize; musicInfoListIndex++){
		_musicInfoListTmp = new MusicInfoData();
		_musicInfoList[musicInfoListIndex] = _musicInfoListTmp;
	// 模块ID,1:公共场景，2：功能面板，3：战斗类型
	int _musicInfoList_moduleId = ReadInt();	_musicInfoListTmp.moduleId = _musicInfoList_moduleId;
	
	// 键值对
	int musicInfoList_keyValueListSize = ReadShort();
	KeyValueData[] _musicInfoList_keyValueList = new KeyValueData[musicInfoList_keyValueListSize];
	int musicInfoList_keyValueListIndex = 0;
	KeyValueData _musicInfoList_keyValueListTmp = null;
	for(musicInfoList_keyValueListIndex=0; musicInfoList_keyValueListIndex<musicInfoList_keyValueListSize; musicInfoList_keyValueListIndex++){
		_musicInfoList_keyValueListTmp = new KeyValueData();
		_musicInfoList_keyValueList[musicInfoList_keyValueListIndex] = _musicInfoList_keyValueListTmp;
	// 属性Key
	int _musicInfoList_keyValueList_key = ReadInt();	_musicInfoList_keyValueListTmp.key = _musicInfoList_keyValueList_key;
		// 属性值
	int _musicInfoList_keyValueList_value = ReadInt();	_musicInfoList_keyValueListTmp.value = _musicInfoList_keyValueList_value;
		}
	//end
	_musicInfoListTmp.keyValueList = _musicInfoList_keyValueList;
		}
	//end



		this.musicConfigInfoList = _musicConfigInfoList;
		this.musicInfoList = _musicInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_MUSIC_CONFIG_LIST;
	}
	
	public override string getEventType()
	{
		return CommonGCHandler.GCMusicConfigListEvent;
	}
	

	public MusicConfigInfoData[] getMusicConfigInfoList(){
		return musicConfigInfoList;
	}


	public MusicInfoData[] getMusicInfoList(){
		return musicInfoList;
	}


}
}