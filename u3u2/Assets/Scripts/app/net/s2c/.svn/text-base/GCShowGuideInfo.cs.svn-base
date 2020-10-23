
using System;
namespace app.net
{
/**
 * 显示新手引导
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCShowGuideInfo :BaseMessage
{
	/** 引导类型id */
	private int guideTypeId;
	/** 引导步骤json串 */
	private string guideStepStr;

	public GCShowGuideInfo ()
	{
	}

	protected override void ReadImpl()
	{
	// 引导类型id
	int _guideTypeId = ReadInt();
	// 引导步骤json串
	string _guideStepStr = ReadString();


		this.guideTypeId = _guideTypeId;
		this.guideStepStr = _guideStepStr;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_SHOW_GUIDE_INFO;
	}
	
	public override string getEventType()
	{
		return GuideGCHandler.GCShowGuideInfoEvent;
	}
	

	public int getGuideTypeId(){
		return guideTypeId;
	}
		

	public string getGuideStepStr(){
		return guideStepStr;
	}
		

}
}