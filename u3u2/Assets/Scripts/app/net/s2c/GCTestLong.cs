
using System;
namespace app.net
{
/**
 * 测试
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTestLong :BaseMessage
{
	/** 测试Long型 */
	private long testLong;
	/** 测试String型 */
	private string testString;

	public GCTestLong ()
	{
	}

	protected override void ReadImpl()
	{
	// 测试Long型
	long _testLong = ReadLong();
	// 测试String型
	string _testString = ReadString();


		this.testLong = _testLong;
		this.testString = _testString;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TEST_LONG;
	}
	
	public override string getEventType()
	{
		return TestGCHandler.GCTestLongEvent;
	}
	

	public long getTestLong(){
		return testLong;
	}
		

	public string getTestString(){
		return testString;
	}
		

}
}