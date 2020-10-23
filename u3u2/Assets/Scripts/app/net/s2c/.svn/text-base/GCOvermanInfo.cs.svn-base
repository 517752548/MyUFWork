
using System;
namespace app.net
{
/**
 * 师徒相关信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOvermanInfo :BaseMessage
{
	/** 师傅charId */
	private long overman;
	/** 师傅charId */
	private string overmanName;
	/** 师傅的模版id */
	private int overmanTemplateId;
	/** 师傅是否在线,1是,0否 */
	private bool isOnline;
	/** 徒弟信息 */
	private LowermanInfo[] lowerList;

	public GCOvermanInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 师傅charId
	long _overman = ReadLong();
	// 师傅charId
	string _overmanName = ReadString();
	// 师傅的模版id
	int _overmanTemplateId = ReadInt();
	// 师傅是否在线,1是,0否
	bool _isOnline = ReadBool();

	// 徒弟信息
	int lowerListSize = ReadShort();
	LowermanInfo[] _lowerList = new LowermanInfo[lowerListSize];
	int lowerListIndex = 0;
	LowermanInfo _lowerListTmp = null;
	for(lowerListIndex=0; lowerListIndex<lowerListSize; lowerListIndex++){
		_lowerListTmp = new LowermanInfo();
		_lowerList[lowerListIndex] = _lowerListTmp;
	// 玩家id
	long _lowerList_uuid = ReadLong();	_lowerListTmp.uuid = _lowerList_uuid;
		// 拜师时间
	long _lowerList_createTime = ReadLong();	_lowerListTmp.createTime = _lowerList_createTime;
		// 玩家名称
	string _lowerList_humanName = ReadString();	_lowerListTmp.humanName = _lowerList_humanName;
		// 等级
	int _lowerList_level = ReadInt();	_lowerListTmp.level = _lowerList_level;
		// 战力
	int _lowerList_fightPower = ReadInt();	_lowerListTmp.fightPower = _lowerList_fightPower;
		// 模版id
	int _lowerList_templateId = ReadInt();	_lowerListTmp.templateId = _lowerList_templateId;
		// 是否在线,1是,0否
	bool _lowerList_isOnline = ReadBool();	_lowerListTmp.isOnline = _lowerList_isOnline;
		}
	//end



		this.overman = _overman;
		this.overmanName = _overmanName;
		this.overmanTemplateId = _overmanTemplateId;
		this.isOnline = _isOnline;
		this.lowerList = _lowerList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OVERMAN_INFO;
	}
	
	public override string getEventType()
	{
		return OvermanGCHandler.GCOvermanInfoEvent;
	}
	

	public long getOverman(){
		return overman;
	}
		

	public string getOvermanName(){
		return overmanName;
	}
		

	public int getOvermanTemplateId(){
		return overmanTemplateId;
	}
		

	public bool getIsOnline(){
		return isOnline;
	}
		

	public LowermanInfo[] getLowerList(){
		return lowerList;
	}


}
}