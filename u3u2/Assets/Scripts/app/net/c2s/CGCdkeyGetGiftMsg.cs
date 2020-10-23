using System;
using System.IO;
namespace app.net
{

/**
 * 通过cdkey领礼包
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGCdkeyGetGiftMsg :BaseMessage
{
	
	/** cdkey激活码 */
	private string cdKeyStr;
	
	public CGCdkeyGetGiftMsg ()
	{
	}
	
	public CGCdkeyGetGiftMsg (
			string cdKeyStr )
	{
			this.cdKeyStr = cdKeyStr;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// cdkey激活码
	WriteString(cdKeyStr);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_CDKEY_GET_GIFT_MSG;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}