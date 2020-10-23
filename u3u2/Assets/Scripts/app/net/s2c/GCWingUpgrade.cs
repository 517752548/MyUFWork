
using System;
namespace app.net
{
/**
 * 升阶翅膀结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCWingUpgrade :BaseMessage
{
	/** 翅膀 */
	private WingInfo wing;
	/** 升阶翅膀结果 1成功 2失败 */
	private int result;

	public GCWingUpgrade ()
	{
	}

	protected override void ReadImpl()
	{
	// 翅膀
	WingInfo _wing = new WingInfo();
	// 翅膀类型id
	int _wing_templateId = ReadInt();	_wing.templateId = _wing_templateId;
	// 是否已装备
	int _wing_isEquip = ReadInt();	_wing.isEquip = _wing_isEquip;
	// 翅膀阶数
	int _wing_wingLevel = ReadInt();	_wing.wingLevel = _wing_wingLevel;
	// 翅膀祝福值
	int _wing_wingBless = ReadInt();	_wing.wingBless = _wing_wingBless;
	// 翅膀战斗力
	int _wing_wingPower = ReadInt();	_wing.wingPower = _wing_wingPower;

	// 升阶翅膀结果 1成功 2失败
	int _result = ReadInt();


		this.wing = _wing;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_WING_UPGRADE;
	}
	
	public override string getEventType()
	{
		return WingGCHandler.GCWingUpgradeEvent;
	}
	

	public WingInfo getWing(){
		return wing;
	}
		

	public int getResult(){
		return result;
	}
		

}
}