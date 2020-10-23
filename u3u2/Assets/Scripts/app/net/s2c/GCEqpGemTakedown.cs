
using System;
namespace app.net
{
/**
 * 摘除宝石结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpGemTakedown :BaseMessage
{
	/** 装备UUID */
	private string equipUuid;
	/** 要摘除的宝石模板Id */
	private int gemItemId;
	/** 摘除的宝石模板Id，为0表示失败扣除 */
	private int finalGemItemId;

	public GCEqpGemTakedown ()
	{
	}

	protected override void ReadImpl()
	{
	// 装备UUID
	string _equipUuid = ReadString();
	// 要摘除的宝石模板Id
	int _gemItemId = ReadInt();
	// 摘除的宝石模板Id，为0表示失败扣除
	int _finalGemItemId = ReadInt();


		this.equipUuid = _equipUuid;
		this.gemItemId = _gemItemId;
		this.finalGemItemId = _finalGemItemId;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_EQP_GEM_TAKEDOWN;
	}
	
	public override string getEventType()
	{
		return EquipGCHandler.GCEqpGemTakedownEvent;
	}
	

	public string getEquipUuid(){
		return equipUuid;
	}
		

	public int getGemItemId(){
		return gemItemId;
	}
		

	public int getFinalGemItemId(){
		return finalGemItemId;
	}
		

}
}