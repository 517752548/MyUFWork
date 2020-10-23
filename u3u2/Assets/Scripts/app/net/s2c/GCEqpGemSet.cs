
using System;
namespace app.net
{
/**
 * 镶嵌宝石结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpGemSet :BaseMessage
{
	/** 装备UUID */
	private string equipUuid;
	/** 要镶嵌的宝石模板Id */
	private int gemItemId;
	/** 镶嵌上的宝石模板Id，为0表示失败扣除 */
	private int finalGemItemId;

	public GCEqpGemSet ()
	{
	}

	protected override void ReadImpl()
	{
	// 装备UUID
	string _equipUuid = ReadString();
	// 要镶嵌的宝石模板Id
	int _gemItemId = ReadInt();
	// 镶嵌上的宝石模板Id，为0表示失败扣除
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
		return (short)MessageType.GC_EQP_GEM_SET;
	}
	
	public override string getEventType()
	{
		return EquipGCHandler.GCEqpGemSetEvent;
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