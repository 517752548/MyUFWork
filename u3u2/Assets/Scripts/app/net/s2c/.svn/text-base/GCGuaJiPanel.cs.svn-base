
using System;
namespace app.net
{
/**
 * 返回挂机信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGuaJiPanel :BaseMessage
{
	/** 挂机信息 */
	private GuaJiInfo guaJiInfo;

	public GCGuaJiPanel ()
	{
	}

	protected override void ReadImpl()
	{
	// 挂机信息
	GuaJiInfo _guaJiInfo = new GuaJiInfo();
	// 遇敌间隔
	int _guaJiInfo_encounterSecond = ReadInt();	_guaJiInfo.encounterSecond = _guaJiInfo_encounterSecond;
	// 增加人物经验(1-1倍经验,2-2倍经验)
	int _guaJiInfo_humanExpTimes = ReadInt();	_guaJiInfo.humanExpTimes = _guaJiInfo_humanExpTimes;
	// 增加宠物经验(当前出战宠物会加上,(1-1倍经验,2-2倍经验)
	int _guaJiInfo_petExpTimes = ReadInt();	_guaJiInfo.petExpTimes = _guaJiInfo_petExpTimes;
	// 是否开启满怪
	bool _guaJiInfo_fullEnemy = ReadBool();	_guaJiInfo.fullEnemy = _guaJiInfo_fullEnemy;
	// 切换场景暂停
	bool _guaJiInfo_switchScene = ReadBool();	_guaJiInfo.switchScene = _guaJiInfo_switchScene;
	// 挂机分钟数
	int _guaJiInfo_guaJiMinute = ReadInt();	_guaJiInfo.guaJiMinute = _guaJiInfo_guaJiMinute;
	// 剩余挂机时间,毫秒
	long _guaJiInfo_leftTime = ReadLong();	_guaJiInfo.leftTime = _guaJiInfo_leftTime;
	// 所需挂机点数
	int _guaJiInfo_needGuaJiPoint = ReadInt();	_guaJiInfo.needGuaJiPoint = _guaJiInfo_needGuaJiPoint;
	// 是否挂机
	bool _guaJiInfo_guaJi = ReadBool();	_guaJiInfo.guaJi = _guaJiInfo_guaJi;



		this.guaJiInfo = _guaJiInfo;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_GUA_JI_PANEL;
	}
	
	public override string getEventType()
	{
		return GuajiGCHandler.GCGuaJiPanelEvent;
	}
	

	public GuaJiInfo getGuaJiInfo(){
		return guaJiInfo;
	}
		

}
}