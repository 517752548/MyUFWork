
using System;
namespace app.net
{
/**
 * 返回帮派修炼技能面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsCultivatePanel :BaseMessage
{
	/** 帮派修炼技能信息 */
	private CorpsSkillInfo[] corpsSkillInfoList;

	public GCOpenCorpsCultivatePanel ()
	{
	}

	protected override void ReadImpl()
	{

	// 帮派修炼技能信息
	int corpsSkillInfoListSize = ReadShort();
	CorpsSkillInfo[] _corpsSkillInfoList = new CorpsSkillInfo[corpsSkillInfoListSize];
	int corpsSkillInfoListIndex = 0;
	CorpsSkillInfo _corpsSkillInfoListTmp = null;
	for(corpsSkillInfoListIndex=0; corpsSkillInfoListIndex<corpsSkillInfoListSize; corpsSkillInfoListIndex++){
		_corpsSkillInfoListTmp = new CorpsSkillInfo();
		_corpsSkillInfoList[corpsSkillInfoListIndex] = _corpsSkillInfoListTmp;
	// 技能Id
	int _corpsSkillInfoList_skillId = ReadInt();	_corpsSkillInfoListTmp.skillId = _corpsSkillInfoList_skillId;
		// 技能等级
	int _corpsSkillInfoList_level = ReadInt();	_corpsSkillInfoListTmp.level = _corpsSkillInfoList_level;
		// 如果技能升级需要经验,就设置该值
	long _corpsSkillInfoList_exp = ReadLong();	_corpsSkillInfoListTmp.exp = _corpsSkillInfoList_exp;
		}
	//end



		this.corpsSkillInfoList = _corpsSkillInfoList;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_OPEN_CORPS_CULTIVATE_PANEL;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCOpenCorpsCultivatePanelEvent;
	}
	

	public CorpsSkillInfo[] getCorpsSkillInfoList(){
		return corpsSkillInfoList;
	}


}
}