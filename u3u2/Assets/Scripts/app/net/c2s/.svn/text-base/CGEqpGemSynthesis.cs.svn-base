using System;
using System.IO;
namespace app.net
{

/**
 * 合成宝石
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpGemSynthesis :BaseMessage
{
	
	/** 宝石模板Id */
	private int gemTplId;
	/** 合成基数 3 三合一 4 四合一 5 五合一 */
	private int synthesisBase;
	/** 合成方式 0单个1全部 */
	private int synthesisType;
	
	public CGEqpGemSynthesis ()
	{
	}
	
	public CGEqpGemSynthesis (
			int gemTplId,
			int synthesisBase,
			int synthesisType )
	{
			this.gemTplId = gemTplId;
			this.synthesisBase = synthesisBase;
			this.synthesisType = synthesisType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 宝石模板Id
	WriteInt(gemTplId);
	// 合成基数 3 三合一 4 四合一 5 五合一
	WriteInt(synthesisBase);
	// 合成方式 0单个1全部
	WriteInt(synthesisType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_EQP_GEM_SYNTHESIS;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}