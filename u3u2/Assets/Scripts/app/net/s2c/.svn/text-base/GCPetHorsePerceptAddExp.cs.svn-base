
using System;
namespace app.net
{
/**
 * 骑宠悟性提升结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetHorsePerceptAddExp :BaseMessage
{
	/** 骑宠唯一Id */
	private long petId;
	/** 小暴击触发次数 */
	private int smallCritNum;
	/** 小暴击触发共获得经验和 */
	private long smallCritSumExp;
	/** 大暴击触发次数 */
	private int bigCritNum;
	/** 普通获得经验和 */
	private long normalSumExp;
	/** 1成功,2失败 */
	private int result;

	public GCPetHorsePerceptAddExp ()
	{
	}

	protected override void ReadImpl()
	{
	// 骑宠唯一Id
	long _petId = ReadLong();
	// 小暴击触发次数
	int _smallCritNum = ReadInt();
	// 小暴击触发共获得经验和
	long _smallCritSumExp = ReadLong();
	// 大暴击触发次数
	int _bigCritNum = ReadInt();
	// 普通获得经验和
	long _normalSumExp = ReadLong();
	// 1成功,2失败
	int _result = ReadInt();


		this.petId = _petId;
		this.smallCritNum = _smallCritNum;
		this.smallCritSumExp = _smallCritSumExp;
		this.bigCritNum = _bigCritNum;
		this.normalSumExp = _normalSumExp;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_PET_HORSE_PERCEPT_ADD_EXP;
	}
	
	public override string getEventType()
	{
		return PetGCHandler.GCPetHorsePerceptAddExpEvent;
	}
	

	public long getPetId(){
		return petId;
	}
		

	public int getSmallCritNum(){
		return smallCritNum;
	}
		

	public long getSmallCritSumExp(){
		return smallCritSumExp;
	}
		

	public int getBigCritNum(){
		return bigCritNum;
	}
		

	public long getNormalSumExp(){
		return normalSumExp;
	}
		

	public int getResult(){
		return result;
	}
		

}
}