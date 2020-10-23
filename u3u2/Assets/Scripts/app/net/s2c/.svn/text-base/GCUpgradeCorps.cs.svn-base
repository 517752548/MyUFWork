
using System;
namespace app.net
{
/**
 * 返回升级帮派建筑结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUpgradeCorps :BaseMessage
{
	/** 建筑类型,1朱雀,2青龙,3白虎,4朱雀,5玄武,6养生,7侍剑 */
	private int buildType;
	/** 升级结果,1成功,2失败 */
	private int result;

	public GCUpgradeCorps ()
	{
	}

	protected override void ReadImpl()
	{
	// 建筑类型,1朱雀,2青龙,3白虎,4朱雀,5玄武,6养生,7侍剑
	int _buildType = ReadInt();
	// 升级结果,1成功,2失败
	int _result = ReadInt();


		this.buildType = _buildType;
		this.result = _result;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_UPGRADE_CORPS;
	}
	
	public override string getEventType()
	{
		return CorpsGCHandler.GCUpgradeCorpsEvent;
	}
	

	public int getBuildType(){
		return buildType;
	}
		

	public int getResult(){
		return result;
	}
		

}
}