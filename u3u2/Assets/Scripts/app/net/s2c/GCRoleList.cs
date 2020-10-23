
using System;
namespace app.net
{
/**
 * 角色列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRoleList :BaseMessage
{
	/** 多角色信息 */
	private RoleInfoData[] roleList;
	/** 默认选中的角色索引 */
	private int selectedIndex;
	/** 账户Id */
	private string passportId;

	public GCRoleList ()
	{
	}

	protected override void ReadImpl()
	{

	// 多角色信息
	int roleListSize = ReadShort();
	RoleInfoData[] _roleList = new RoleInfoData[roleListSize];
	int roleListIndex = 0;
	RoleInfoData _roleListTmp = null;
	for(roleListIndex=0; roleListIndex<roleListSize; roleListIndex++){
		_roleListTmp = new RoleInfoData();
		_roleList[roleListIndex] = _roleListTmp;
	// 角色id
	long _roleList_roleUUID = ReadLong();	_roleListTmp.roleUUID = _roleList_roleUUID;
		// 名字
	string _roleList_name = ReadString();	_roleListTmp.name = _roleList_name;
		// 角色等级
	int _roleList_level = ReadInt();	_roleListTmp.level = _roleList_level;
		// 主将模板id
	int _roleList_petTemplateId = ReadInt();	_roleListTmp.petTemplateId = _roleList_petTemplateId;
		// 主将图片
	int _roleList_petPhotoId = ReadInt();	_roleListTmp.petPhotoId = _roleList_petPhotoId;
		// 主将资质
	int _roleList_petRarity = ReadInt();	_roleListTmp.petRarity = _roleList_petRarity;
		// 是否首次登陆0首次登陆1非首次登陆
	int _roleList_firstLogin = ReadInt();	_roleListTmp.firstLogin = _roleList_firstLogin;
		}
	//end

	// 默认选中的角色索引
	int _selectedIndex = ReadInt();
	// 账户Id
	string _passportId = ReadString();


		this.roleList = _roleList;
		this.selectedIndex = _selectedIndex;
		this.passportId = _passportId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ROLE_LIST;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCRoleListEvent;
	}
	

	public RoleInfoData[] getRoleList(){
		return roleList;
	}


	public int getSelectedIndex(){
		return selectedIndex;
	}
		

	public string getPassportId(){
		return passportId;
	}
		

}
}