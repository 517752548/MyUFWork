
using System;
namespace app.net
{
/**
 * 角色模板数据
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCRoleTemplate :BaseMessage
{
	/** 主将信息列表 */
	private CreatePetInfoData[] createPetInfoList;
	/** 1：已激活，0:未激活 */
	private int activity;

	public GCRoleTemplate ()
	{
	}

	protected override void ReadImpl()
	{

	// 主将信息列表
	int createPetInfoListSize = ReadShort();
	CreatePetInfoData[] _createPetInfoList = new CreatePetInfoData[createPetInfoListSize];
	int createPetInfoListIndex = 0;
	CreatePetInfoData _createPetInfoListTmp = null;
	for(createPetInfoListIndex=0; createPetInfoListIndex<createPetInfoListSize; createPetInfoListIndex++){
		_createPetInfoListTmp = new CreatePetInfoData();
		_createPetInfoList[createPetInfoListIndex] = _createPetInfoListTmp;
	// 主将模板id
	int _createPetInfoList_petTemplateId = ReadInt();	_createPetInfoListTmp.petTemplateId = _createPetInfoList_petTemplateId;
		// 主将头像id
	int _createPetInfoList_petPhotoId = ReadInt();	_createPetInfoListTmp.petPhotoId = _createPetInfoList_petPhotoId;
		// 主将职业类型
	int _createPetInfoList_petJobType = ReadInt();	_createPetInfoListTmp.petJobType = _createPetInfoList_petJobType;
		// 主将职业名称
	string _createPetInfoList_petJobName = ReadString();	_createPetInfoListTmp.petJobName = _createPetInfoList_petJobName;
		// 主将描述
	string _createPetInfoList_petDesc = ReadString();	_createPetInfoListTmp.petDesc = _createPetInfoList_petDesc;
		}
	//end

	// 1：已激活，0:未激活
	int _activity = ReadInt();


		this.createPetInfoList = _createPetInfoList;
		this.activity = _activity;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_ROLE_TEMPLATE;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCRoleTemplateEvent;
	}
	

	public CreatePetInfoData[] getCreatePetInfoList(){
		return createPetInfoList;
	}


	public int getActivity(){
		return activity;
	}
		

}
}