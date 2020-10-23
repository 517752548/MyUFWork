package com.imop.lj.gameserver.common.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 音乐常量配置列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMusicConfigList extends GCMessage{
	
	/** 音乐配置列表 */
	private com.imop.lj.common.model.constant.MusicConfigInfo[] musicConfigInfoList;
	/** 音乐与功能对应列表 */
	private com.imop.lj.common.model.constant.MusicInfo[] musicInfoList;

	public GCMusicConfigList (){
	}
	
	public GCMusicConfigList (
			com.imop.lj.common.model.constant.MusicConfigInfo[] musicConfigInfoList,
			com.imop.lj.common.model.constant.MusicInfo[] musicInfoList ){
			this.musicConfigInfoList = musicConfigInfoList;
			this.musicInfoList = musicInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 音乐配置列表
	int musicConfigInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.constant.MusicConfigInfo[] _musicConfigInfoList = new com.imop.lj.common.model.constant.MusicConfigInfo[musicConfigInfoListSize];
	int musicConfigInfoListIndex = 0;
	for(musicConfigInfoListIndex=0; musicConfigInfoListIndex<musicConfigInfoListSize; musicConfigInfoListIndex++){
		_musicConfigInfoList[musicConfigInfoListIndex] = new com.imop.lj.common.model.constant.MusicConfigInfo();
	// ID
	int _musicConfigInfoList_id = readInteger();
	//end
	_musicConfigInfoList[musicConfigInfoListIndex].setId (_musicConfigInfoList_id);

	// 资源ID
	int _musicConfigInfoList_resId = readInteger();
	//end
	_musicConfigInfoList[musicConfigInfoListIndex].setResId (_musicConfigInfoList_resId);

	// 是否循环
	int _musicConfigInfoList_loop = readInteger();
	//end
	_musicConfigInfoList[musicConfigInfoListIndex].setLoop (_musicConfigInfoList_loop);
	}
	//end


	// 音乐与功能对应列表
	int musicInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.constant.MusicInfo[] _musicInfoList = new com.imop.lj.common.model.constant.MusicInfo[musicInfoListSize];
	int musicInfoListIndex = 0;
	for(musicInfoListIndex=0; musicInfoListIndex<musicInfoListSize; musicInfoListIndex++){
		_musicInfoList[musicInfoListIndex] = new com.imop.lj.common.model.constant.MusicInfo();
	// 模块ID,1:公共场景，2：功能面板，3：战斗类型
	int _musicInfoList_moduleId = readInteger();
	//end
	_musicInfoList[musicInfoListIndex].setModuleId (_musicInfoList_moduleId);

	// 键值对
	int musicInfoList_keyValueListSize = readUnsignedShort();
	com.imop.lj.common.model.KeyValueInfo[] _musicInfoList_keyValueList = new com.imop.lj.common.model.KeyValueInfo[musicInfoList_keyValueListSize];
	int musicInfoList_keyValueListIndex = 0;
	for(musicInfoList_keyValueListIndex=0; musicInfoList_keyValueListIndex<musicInfoList_keyValueListSize; musicInfoList_keyValueListIndex++){
		_musicInfoList_keyValueList[musicInfoList_keyValueListIndex] = new com.imop.lj.common.model.KeyValueInfo();
	// 属性Key
	int _musicInfoList_keyValueList_key = readInteger();
	//end
	_musicInfoList_keyValueList[musicInfoList_keyValueListIndex].setKey (_musicInfoList_keyValueList_key);

	// 属性值
	int _musicInfoList_keyValueList_value = readInteger();
	//end
	_musicInfoList_keyValueList[musicInfoList_keyValueListIndex].setValue (_musicInfoList_keyValueList_value);
	}
	//end
	_musicInfoList[musicInfoListIndex].setKeyValueList (_musicInfoList_keyValueList);
	}
	//end



		this.musicConfigInfoList = _musicConfigInfoList;
		this.musicInfoList = _musicInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 音乐配置列表
	writeShort(musicConfigInfoList.length);
	int musicConfigInfoListIndex = 0;
	int musicConfigInfoListSize = musicConfigInfoList.length;
	for(musicConfigInfoListIndex=0; musicConfigInfoListIndex<musicConfigInfoListSize; musicConfigInfoListIndex++){

	int musicConfigInfoList_id = musicConfigInfoList[musicConfigInfoListIndex].getId();

	// ID
	writeInteger(musicConfigInfoList_id);

	int musicConfigInfoList_resId = musicConfigInfoList[musicConfigInfoListIndex].getResId();

	// 资源ID
	writeInteger(musicConfigInfoList_resId);

	int musicConfigInfoList_loop = musicConfigInfoList[musicConfigInfoListIndex].getLoop();

	// 是否循环
	writeInteger(musicConfigInfoList_loop);
	}
	//end


	// 音乐与功能对应列表
	writeShort(musicInfoList.length);
	int musicInfoListIndex = 0;
	int musicInfoListSize = musicInfoList.length;
	for(musicInfoListIndex=0; musicInfoListIndex<musicInfoListSize; musicInfoListIndex++){

	int musicInfoList_moduleId = musicInfoList[musicInfoListIndex].getModuleId();

	// 模块ID,1:公共场景，2：功能面板，3：战斗类型
	writeInteger(musicInfoList_moduleId);

	com.imop.lj.common.model.KeyValueInfo[] musicInfoList_keyValueList = musicInfoList[musicInfoListIndex].getKeyValueList();

	// 键值对
	writeShort(musicInfoList_keyValueList.length);
	int musicInfoList_keyValueListIndex = 0;
	int musicInfoList_keyValueListSize = musicInfoList_keyValueList.length;
	for(musicInfoList_keyValueListIndex=0; musicInfoList_keyValueListIndex<musicInfoList_keyValueListSize; musicInfoList_keyValueListIndex++){

	int musicInfoList_keyValueList_key = musicInfoList_keyValueList[musicInfoList_keyValueListIndex].getKey();

	// 属性Key
	writeInteger(musicInfoList_keyValueList_key);

	int musicInfoList_keyValueList_value = musicInfoList_keyValueList[musicInfoList_keyValueListIndex].getValue();

	// 属性值
	writeInteger(musicInfoList_keyValueList_value);
	}
	//end
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MUSIC_CONFIG_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MUSIC_CONFIG_LIST";
	}

	public com.imop.lj.common.model.constant.MusicConfigInfo[] getMusicConfigInfoList(){
		return musicConfigInfoList;
	}

	public void setMusicConfigInfoList(com.imop.lj.common.model.constant.MusicConfigInfo[] musicConfigInfoList){
		this.musicConfigInfoList = musicConfigInfoList;
	}	

	public com.imop.lj.common.model.constant.MusicInfo[] getMusicInfoList(){
		return musicInfoList;
	}

	public void setMusicInfoList(com.imop.lj.common.model.constant.MusicInfo[] musicInfoList){
		this.musicInfoList = musicInfoList;
	}	
}