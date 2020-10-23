
using System;
namespace app.net
{
/**
 * 打开心法技能面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCHsOpenPanel :BaseMessage
{
	/** 心法页签红点，0没有，1有 */
	private int mindFlag;
	/** 技能页签红点，0没有，1有 */
	private int skillFlag;
	/** 心法技能提升列表 */
	private MainSkillTipsInfo mainSkillTipsInfo;
	/** 修炼页签红点，0没有，1有 */
	private int cultivateFlag;
	/** 辅助页签红点，0没有，1有 */
	private int assistFlag;
	/** 生活技能页签红点，0没有，1有 */
	private int lifeSkillFlag;

	public GCHsOpenPanel ()
	{
	}

	protected override void ReadImpl()
	{
	// 心法页签红点，0没有，1有
	int _mindFlag = ReadInt();
	// 技能页签红点，0没有，1有
	int _skillFlag = ReadInt();
	// 心法技能提升列表
	MainSkillTipsInfo _mainSkillTipsInfo = new MainSkillTipsInfo();
	// 心法Id
	int _mainSkillTipsInfo_mindId = ReadInt();	_mainSkillTipsInfo.mindId = _mainSkillTipsInfo_mindId;
	// 技能Id
	int _mainSkillTipsInfo_skillId = ReadInt();	_mainSkillTipsInfo.skillId = _mainSkillTipsInfo_skillId;

	// 修炼页签红点，0没有，1有
	int _cultivateFlag = ReadInt();
	// 辅助页签红点，0没有，1有
	int _assistFlag = ReadInt();
	// 生活技能页签红点，0没有，1有
	int _lifeSkillFlag = ReadInt();


		this.mindFlag = _mindFlag;
		this.skillFlag = _skillFlag;
		this.mainSkillTipsInfo = _mainSkillTipsInfo;
		this.cultivateFlag = _cultivateFlag;
		this.assistFlag = _assistFlag;
		this.lifeSkillFlag = _lifeSkillFlag;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_HS_OPEN_PANEL;
	}
	
	public override string getEventType()
	{
		return HumanskillGCHandler.GCHsOpenPanelEvent;
	}
	

	public int getMindFlag(){
		return mindFlag;
	}
		

	public int getSkillFlag(){
		return skillFlag;
	}
		

	public MainSkillTipsInfo getMainSkillTipsInfo(){
		return mainSkillTipsInfo;
	}
		

	public int getCultivateFlag(){
		return cultivateFlag;
	}
		

	public int getAssistFlag(){
		return assistFlag;
	}
		

	public int getLifeSkillFlag(){
		return lifeSkillFlag;
	}
		

}
}