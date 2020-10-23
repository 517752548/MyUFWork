using System;
using System.IO;
namespace app.net
{

/**
 * 测试
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTestLong :BaseMessage
{
	
	/** 测试Long型 */
	private long testLong;
	/** 测试String型 */
	private string testString;
	
	public CGTestLong ()
	{
	}
	
	public CGTestLong (
			long testLong,
			string testString )
	{
			this.testLong = testLong;
			this.testString = testString;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 测试Long型
	WriteLong(testLong);
	// 测试String型
	WriteString(testString);

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEST_LONG;
	}
	
	public override string getEventType()
	{
		return "";
	}
	
	}
}