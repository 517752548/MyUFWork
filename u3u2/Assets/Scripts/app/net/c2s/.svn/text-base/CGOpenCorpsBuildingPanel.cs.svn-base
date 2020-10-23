using System;
using System.IO;
namespace app.net
{

/**
 * 打开帮派建筑面板
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGOpenCorpsBuildingPanel :BaseMessage
{
	
	/** 建筑类型,1朱雀,2青龙,3白虎,4朱雀,5玄武,6养生,7侍剑 */
	private int buildType;
	
	public CGOpenCorpsBuildingPanel ()
	{
	}
	
	public CGOpenCorpsBuildingPanel (
			int buildType )
	{
			this.buildType = buildType;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 建筑类型,1朱雀,2青龙,3白虎,4朱雀,5玄武,6养生,7侍剑
	WriteInt(buildType);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_OPEN_CORPS_BUILDING_PANEL;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}