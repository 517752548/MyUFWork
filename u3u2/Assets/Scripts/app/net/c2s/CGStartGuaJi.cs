using System;
using System.IO;
namespace app.net
{

/**
 * 开始挂机
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGStartGuaJi :BaseMessage
{
	
	/** 遇敌间隔 */
	private int encounterSecond;
	/** 增加人物经验(1-1倍经验,2-2倍经验) */
	private int humanExpTimes;
	/** 增加宠物经验(当前出战宠物会加上,(1-1倍经验,2-2倍经验) */
	private int petExpTimes;
	/** 1开启，0关闭 */
	private int fullEnemy;
	/** 1开启，0关闭 */
	private int switchScene;
	/** 挂机分钟数 */
	private int guaJiMinute;
	/** 所需挂机点数 */
	private int needGuaJiPoint;
	
	public CGStartGuaJi ()
	{
	}
	
	public CGStartGuaJi (
			int encounterSecond,
			int humanExpTimes,
			int petExpTimes,
			int fullEnemy,
			int switchScene,
			int guaJiMinute,
			int needGuaJiPoint )
	{
			this.encounterSecond = encounterSecond;
			this.humanExpTimes = humanExpTimes;
			this.petExpTimes = petExpTimes;
			this.fullEnemy = fullEnemy;
			this.switchScene = switchScene;
			this.guaJiMinute = guaJiMinute;
			this.needGuaJiPoint = needGuaJiPoint;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 遇敌间隔
	WriteInt(encounterSecond);
	// 增加人物经验(1-1倍经验,2-2倍经验)
	WriteInt(humanExpTimes);
	// 增加宠物经验(当前出战宠物会加上,(1-1倍经验,2-2倍经验)
	WriteInt(petExpTimes);
	// 1开启，0关闭
	WriteInt(fullEnemy);
	// 1开启，0关闭
	WriteInt(switchScene);
	// 挂机分钟数
	WriteInt(guaJiMinute);
	// 所需挂机点数
	WriteInt(needGuaJiPoint);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_START_GUA_JI;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}