package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 角色模板数据
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRoleTemplate extends GCMessage{
	
	/** 主将信息列表 */
	private com.imop.lj.gameserver.player.model.CreatePetInfo[] createPetInfoList;
	/** 1：已激活，0:未激活 */
	private int activity;

	public GCRoleTemplate (){
	}
	
	public GCRoleTemplate (
			com.imop.lj.gameserver.player.model.CreatePetInfo[] createPetInfoList,
			int activity ){
			this.createPetInfoList = createPetInfoList;
			this.activity = activity;
	}

	@Override
	protected boolean readImpl() {

	// 主将信息列表
	int createPetInfoListSize = readUnsignedShort();
	com.imop.lj.gameserver.player.model.CreatePetInfo[] _createPetInfoList = new com.imop.lj.gameserver.player.model.CreatePetInfo[createPetInfoListSize];
	int createPetInfoListIndex = 0;
	for(createPetInfoListIndex=0; createPetInfoListIndex<createPetInfoListSize; createPetInfoListIndex++){
		_createPetInfoList[createPetInfoListIndex] = new com.imop.lj.gameserver.player.model.CreatePetInfo();
	// 主将模板id
	int _createPetInfoList_petTemplateId = readInteger();
	//end
	_createPetInfoList[createPetInfoListIndex].setPetTemplateId (_createPetInfoList_petTemplateId);

	// 主将头像id
	int _createPetInfoList_petPhotoId = readInteger();
	//end
	_createPetInfoList[createPetInfoListIndex].setPetPhotoId (_createPetInfoList_petPhotoId);

	// 主将职业类型
	int _createPetInfoList_petJobType = readInteger();
	//end
	_createPetInfoList[createPetInfoListIndex].setPetJobType (_createPetInfoList_petJobType);

	// 主将职业名称
	String _createPetInfoList_petJobName = readString();
	//end
	_createPetInfoList[createPetInfoListIndex].setPetJobName (_createPetInfoList_petJobName);

	// 主将描述
	String _createPetInfoList_petDesc = readString();
	//end
	_createPetInfoList[createPetInfoListIndex].setPetDesc (_createPetInfoList_petDesc);
	}
	//end


	// 1：已激活，0:未激活
	int _activity = readInteger();
	//end



		this.createPetInfoList = _createPetInfoList;
		this.activity = _activity;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 主将信息列表
	writeShort(createPetInfoList.length);
	int createPetInfoListIndex = 0;
	int createPetInfoListSize = createPetInfoList.length;
	for(createPetInfoListIndex=0; createPetInfoListIndex<createPetInfoListSize; createPetInfoListIndex++){

	int createPetInfoList_petTemplateId = createPetInfoList[createPetInfoListIndex].getPetTemplateId();

	// 主将模板id
	writeInteger(createPetInfoList_petTemplateId);

	int createPetInfoList_petPhotoId = createPetInfoList[createPetInfoListIndex].getPetPhotoId();

	// 主将头像id
	writeInteger(createPetInfoList_petPhotoId);

	int createPetInfoList_petJobType = createPetInfoList[createPetInfoListIndex].getPetJobType();

	// 主将职业类型
	writeInteger(createPetInfoList_petJobType);

	String createPetInfoList_petJobName = createPetInfoList[createPetInfoListIndex].getPetJobName();

	// 主将职业名称
	writeString(createPetInfoList_petJobName);

	String createPetInfoList_petDesc = createPetInfoList[createPetInfoListIndex].getPetDesc();

	// 主将描述
	writeString(createPetInfoList_petDesc);
	}
	//end


	// 1：已激活，0:未激活
	writeInteger(activity);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ROLE_TEMPLATE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ROLE_TEMPLATE";
	}

	public com.imop.lj.gameserver.player.model.CreatePetInfo[] getCreatePetInfoList(){
		return createPetInfoList;
	}

	public void setCreatePetInfoList(com.imop.lj.gameserver.player.model.CreatePetInfo[] createPetInfoList){
		this.createPetInfoList = createPetInfoList;
	}	

	public int getActivity(){
		return activity;
	}
		
	public void setActivity(int activity){
		this.activity = activity;
	}
}