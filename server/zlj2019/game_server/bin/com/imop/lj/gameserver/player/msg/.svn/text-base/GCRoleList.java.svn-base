package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 角色列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRoleList extends GCMessage{
	
	/** 多角色信息 */
	private com.imop.lj.gameserver.player.model.RoleInfo[] roleList;
	/** 默认选中的角色索引 */
	private int selectedIndex;
	/** 账户Id */
	private String passportId;

	public GCRoleList (){
	}
	
	public GCRoleList (
			com.imop.lj.gameserver.player.model.RoleInfo[] roleList,
			int selectedIndex,
			String passportId ){
			this.roleList = roleList;
			this.selectedIndex = selectedIndex;
			this.passportId = passportId;
	}

	@Override
	protected boolean readImpl() {

	// 多角色信息
	int roleListSize = readUnsignedShort();
	com.imop.lj.gameserver.player.model.RoleInfo[] _roleList = new com.imop.lj.gameserver.player.model.RoleInfo[roleListSize];
	int roleListIndex = 0;
	for(roleListIndex=0; roleListIndex<roleListSize; roleListIndex++){
		_roleList[roleListIndex] = new com.imop.lj.gameserver.player.model.RoleInfo();
	// 角色id
	long _roleList_roleUUID = readLong();
	//end
	_roleList[roleListIndex].setRoleUUID (_roleList_roleUUID);

	// 名字
	String _roleList_name = readString();
	//end
	_roleList[roleListIndex].setName (_roleList_name);

	// 角色等级
	int _roleList_level = readInteger();
	//end
	_roleList[roleListIndex].setLevel (_roleList_level);

	// 主将模板id
	int _roleList_petTemplateId = readInteger();
	//end
	_roleList[roleListIndex].setPetTemplateId (_roleList_petTemplateId);

	// 主将图片
	int _roleList_petPhotoId = readInteger();
	//end
	_roleList[roleListIndex].setPetPhotoId (_roleList_petPhotoId);

	// 主将资质
	int _roleList_petRarity = readInteger();
	//end
	_roleList[roleListIndex].setPetRarity (_roleList_petRarity);

	// 是否首次登陆0首次登陆1非首次登陆
	int _roleList_firstLogin = readInteger();
	//end
	_roleList[roleListIndex].setFirstLogin (_roleList_firstLogin);
	}
	//end


	// 默认选中的角色索引
	int _selectedIndex = readInteger();
	//end


	// 账户Id
	String _passportId = readString();
	//end



		this.roleList = _roleList;
		this.selectedIndex = _selectedIndex;
		this.passportId = _passportId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 多角色信息
	writeShort(roleList.length);
	int roleListIndex = 0;
	int roleListSize = roleList.length;
	for(roleListIndex=0; roleListIndex<roleListSize; roleListIndex++){

	long roleList_roleUUID = roleList[roleListIndex].getRoleUUID();

	// 角色id
	writeLong(roleList_roleUUID);

	String roleList_name = roleList[roleListIndex].getName();

	// 名字
	writeString(roleList_name);

	int roleList_level = roleList[roleListIndex].getLevel();

	// 角色等级
	writeInteger(roleList_level);

	int roleList_petTemplateId = roleList[roleListIndex].getPetTemplateId();

	// 主将模板id
	writeInteger(roleList_petTemplateId);

	int roleList_petPhotoId = roleList[roleListIndex].getPetPhotoId();

	// 主将图片
	writeInteger(roleList_petPhotoId);

	int roleList_petRarity = roleList[roleListIndex].getPetRarity();

	// 主将资质
	writeInteger(roleList_petRarity);

	int roleList_firstLogin = roleList[roleListIndex].getFirstLogin();

	// 是否首次登陆0首次登陆1非首次登陆
	writeInteger(roleList_firstLogin);
	}
	//end


	// 默认选中的角色索引
	writeInteger(selectedIndex);


	// 账户Id
	writeString(passportId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ROLE_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ROLE_LIST";
	}

	public com.imop.lj.gameserver.player.model.RoleInfo[] getRoleList(){
		return roleList;
	}

	public void setRoleList(com.imop.lj.gameserver.player.model.RoleInfo[] roleList){
		this.roleList = roleList;
	}	

	public int getSelectedIndex(){
		return selectedIndex;
	}
		
	public void setSelectedIndex(int selectedIndex){
		this.selectedIndex = selectedIndex;
	}

	public String getPassportId(){
		return passportId;
	}
		
	public void setPassportId(String passportId){
		this.passportId = passportId;
	}
}