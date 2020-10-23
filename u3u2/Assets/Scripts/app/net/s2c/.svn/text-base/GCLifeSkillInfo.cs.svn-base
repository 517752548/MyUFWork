
using System;
namespace app.net
{
/**
 * 生活技能列表
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLifeSkillInfo :BaseMessage
{
	/** 生活技能列表 */
	private LifeSkillInfo[] lifeSkillInfos;

	public GCLifeSkillInfo ()
	{
	}

	protected override void ReadImpl()
	{

	// 生活技能列表
	int lifeSkillInfosSize = ReadShort();
	LifeSkillInfo[] _lifeSkillInfos = new LifeSkillInfo[lifeSkillInfosSize];
	int lifeSkillInfosIndex = 0;
	LifeSkillInfo _lifeSkillInfosTmp = null;
	for(lifeSkillInfosIndex=0; lifeSkillInfosIndex<lifeSkillInfosSize; lifeSkillInfosIndex++){
		_lifeSkillInfosTmp = new LifeSkillInfo();
		_lifeSkillInfos[lifeSkillInfosIndex] = _lifeSkillInfosTmp;
	// 技能Id
	int _lifeSkillInfos_skillId = ReadInt();	_lifeSkillInfosTmp.skillId = _lifeSkillInfos_skillId;
		// 技能等级
	int _lifeSkillInfos_level = ReadInt();	_lifeSkillInfosTmp.level = _lifeSkillInfos_level;
		// 层数
	int _lifeSkillInfos_layer = ReadInt();	_lifeSkillInfosTmp.layer = _lifeSkillInfos_layer;
		// 熟练度
	long _lifeSkillInfos_proficiency = ReadLong();	_lifeSkillInfosTmp.proficiency = _lifeSkillInfos_proficiency;
		}
	//end



		this.lifeSkillInfos = _lifeSkillInfos;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_LIFE_SKILL_INFO;
	}
	
	public override string getEventType()
	{
		return LifeskillGCHandler.GCLifeSkillInfoEvent;
	}
	

	public LifeSkillInfo[] getLifeSkillInfos(){
		return lifeSkillInfos;
	}


}
}