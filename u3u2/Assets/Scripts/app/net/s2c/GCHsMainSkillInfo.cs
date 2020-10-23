
using System;
namespace app.net
{
/**
 * 心法信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCHsMainSkillInfo :BaseMessage
{
	/** 心法信息列表 */
	private MainSkillInfo[] mainSkillInfos;

	public GCHsMainSkillInfo ()
	{
	}

	protected override void ReadImpl()
	{

	// 心法信息列表
	int mainSkillInfosSize = ReadShort();
	MainSkillInfo[] _mainSkillInfos = new MainSkillInfo[mainSkillInfosSize];
	int mainSkillInfosIndex = 0;
	MainSkillInfo _mainSkillInfosTmp = null;
	for(mainSkillInfosIndex=0; mainSkillInfosIndex<mainSkillInfosSize; mainSkillInfosIndex++){
		_mainSkillInfosTmp = new MainSkillInfo();
		_mainSkillInfos[mainSkillInfosIndex] = _mainSkillInfosTmp;
	// 心法Id
	int _mainSkillInfos_mindId = ReadInt();	_mainSkillInfosTmp.mindId = _mainSkillInfos_mindId;
		// 心法等级
	int _mainSkillInfos_mindLevel = ReadInt();	_mainSkillInfosTmp.mindLevel = _mainSkillInfos_mindLevel;
		}
	//end



		this.mainSkillInfos = _mainSkillInfos;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_HS_MAIN_SKILL_INFO;
	}
	
	public override string getEventType()
	{
		return HumanskillGCHandler.GCHsMainSkillInfoEvent;
	}
	

	public MainSkillInfo[] getMainSkillInfos(){
		return mainSkillInfos;
	}


}
}