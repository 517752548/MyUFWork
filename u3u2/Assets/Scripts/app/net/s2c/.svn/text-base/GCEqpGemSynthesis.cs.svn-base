
using System;
namespace app.net
{
/**
 * 合成结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpGemSynthesis :BaseMessage
{
	/** 合成成功数量 */
	private int sucNum;
	/** 合成失败数量 */
	private int failNum;
	/** 合成失败返回道具数量 */
	private int rewardNum;

	public GCEqpGemSynthesis ()
	{
	}

	protected override void ReadImpl()
	{
	// 合成成功数量
	int _sucNum = ReadInt();
	// 合成失败数量
	int _failNum = ReadInt();
	// 合成失败返回道具数量
	int _rewardNum = ReadInt();


		this.sucNum = _sucNum;
		this.failNum = _failNum;
		this.rewardNum = _rewardNum;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_EQP_GEM_SYNTHESIS;
	}
	
	public override string getEventType()
	{
		return EquipGCHandler.GCEqpGemSynthesisEvent;
	}
	

	public int getSucNum(){
		return sucNum;
	}
		

	public int getFailNum(){
		return failNum;
	}
		

	public int getRewardNum(){
		return rewardNum;
	}
		

}
}