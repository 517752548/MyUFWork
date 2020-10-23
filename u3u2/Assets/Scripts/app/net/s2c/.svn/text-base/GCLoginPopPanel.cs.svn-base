
using System;
namespace app.net
{
/**
 * 登录弹出面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLoginPopPanel :BaseMessage
{
	/** 面板功能Id */
	private int funcId;
	/** 其他参数 */
	private string popParam;

	public GCLoginPopPanel ()
	{
	}

	protected override void ReadImpl()
	{
	// 面板功能Id
	int _funcId = ReadInt();
	// 其他参数
	string _popParam = ReadString();


		this.funcId = _funcId;
		this.popParam = _popParam;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_LOGIN_POP_PANEL;
	}
	
	public override string getEventType()
	{
		return PlayerGCHandler.GCLoginPopPanelEvent;
	}
	

	public int getFuncId(){
		return funcId;
	}
		

	public string getPopParam(){
		return popParam;
	}
		

}
}