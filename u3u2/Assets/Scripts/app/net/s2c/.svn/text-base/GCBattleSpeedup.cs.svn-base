
using System;
namespace app.net
{
/**
 * 战斗加速结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleSpeedup :BaseMessage
{
	/** 速度倍数 */
	private int speed;
	/** 能否使用加速，0否，1是 */
	private int canSpeedup;

	public GCBattleSpeedup ()
	{
	}

	protected override void ReadImpl()
	{
	// 速度倍数
	int _speed = ReadInt();
	// 能否使用加速，0否，1是
	int _canSpeedup = ReadInt();


		this.speed = _speed;
		this.canSpeedup = _canSpeedup;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_BATTLE_SPEEDUP;
	}
	
	public override string getEventType()
	{
		return BattleGCHandler.GCBattleSpeedupEvent;
	}
	

	public int getSpeed(){
		return speed;
	}
		

	public int getCanSpeedup(){
		return canSpeedup;
	}
		

}
}