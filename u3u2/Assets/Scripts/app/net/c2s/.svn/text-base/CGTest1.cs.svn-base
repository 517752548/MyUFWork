using System;
using System.IO;
namespace app.net
{

/**
 * 更新单个道具信息，客户端受到此消息就替换原来此位置的道具
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTest1 :BaseMessage
{
	
	/** 测试Long型 */
	private long testLong;
	/** 测试Integer型 */
	private int testInteger;
	/** 测试Short型 */
	private short testShort;
	/** 测试Byte型 */
	private byte testByte;
	/** 测试Boolean型 */
	private bool testBoolean;
	/** 测试String型 */
	private string testString;
	/** 测试Long型 */
	private long[] testLongs;
	/** 测试Integer型 */
	private int[] testIntegers;
	/** 测试Short型 */
	private short[] testShorts;
	/** 测试Byte型 */
	private byte[] testBytes;
	/** 测试Boolean型 */
	private bool[] testBooleans;
	/** 测试String型 */
	private string[] testStrings;
	/** 单个测试信息 */
	private Test1Model test1Model;
	
	public CGTest1 ()
	{
	}
	
	public CGTest1 (
			long testLong,
			int testInteger,
			short testShort,
			byte testByte,
			bool testBoolean,
			string testString,
			long[] testLongs,
			int[] testIntegers,
			short[] testShorts,
			byte[] testBytes,
			bool[] testBooleans,
			string[] testStrings,
			Test1Model test1Model )
	{
			this.testLong = testLong;
			this.testInteger = testInteger;
			this.testShort = testShort;
			this.testByte = testByte;
			this.testBoolean = testBoolean;
			this.testString = testString;
			this.testLongs = testLongs;
			this.testIntegers = testIntegers;
			this.testShorts = testShorts;
			this.testBytes = testBytes;
			this.testBooleans = testBooleans;
			this.testStrings = testStrings;
			this.test1Model = test1Model;
	}
	
	protected override void ReadImpl() 
	{
		return;
	}
	
	protected override void WriteImpl() 
	{
	// 测试Long型
	WriteLong(testLong);
	// 测试Integer型
	WriteInt(testInteger);
	// 测试Short型
	WriteShort(testShort);
	// 测试Byte型
	WriteByte(testByte);
	// 测试Boolean型
	WriteBool(testBoolean);
	// 测试String型
	WriteString(testString);
	// 测试Long型
	WriteShort((short)testLongs.Length);
	int testLongsSize = testLongs.Length;
	int testLongsIndex = 0;
	for(testLongsIndex=0; testLongsIndex<testLongsSize; testLongsIndex++){
		WriteLong(testLongs [ testLongsIndex ]);
	}//end
	
	// 测试Integer型
	WriteShort((short)testIntegers.Length);
	int testIntegersSize = testIntegers.Length;
	int testIntegersIndex = 0;
	for(testIntegersIndex=0; testIntegersIndex<testIntegersSize; testIntegersIndex++){
		WriteInt(testIntegers [ testIntegersIndex ]);
	}//end
	
	// 测试Short型
	WriteShort((short)testShorts.Length);
	int testShortsSize = testShorts.Length;
	int testShortsIndex = 0;
	for(testShortsIndex=0; testShortsIndex<testShortsSize; testShortsIndex++){
		WriteShort(testShorts [ testShortsIndex ]);
	}//end
	
	// 测试Byte型
	WriteShort((short)testBytes.Length);
	int testBytesSize = testBytes.Length;
	int testBytesIndex = 0;
	for(testBytesIndex=0; testBytesIndex<testBytesSize; testBytesIndex++){
		WriteByte(testBytes [ testBytesIndex ]);
	}//end
	
	// 测试Boolean型
	WriteShort((short)testBooleans.Length);
	int testBooleansSize = testBooleans.Length;
	int testBooleansIndex = 0;
	for(testBooleansIndex=0; testBooleansIndex<testBooleansSize; testBooleansIndex++){
		WriteBool(testBooleans [ testBooleansIndex ]);
	}//end
	
	// 测试String型
	WriteShort((short)testStrings.Length);
	int testStringsSize = testStrings.Length;
	int testStringsIndex = 0;
	for(testStringsIndex=0; testStringsIndex<testStringsSize; testStringsIndex++){
		WriteString(testStrings [ testStringsIndex ]);
	}//end
	

	long test1Model_testLong = test1Model.testLong;
	// 测试Long型
	WriteLong(test1Model_testLong);
	int test1Model_testInteger = test1Model.testInteger;
	// 测试Integer型
	WriteInt(test1Model_testInteger);
	short test1Model_testShort = test1Model.testShort;
	// 测试Short型
	WriteShort(test1Model_testShort);
	byte test1Model_testByte = test1Model.testByte;
	// 测试Byte型
	WriteByte(test1Model_testByte);
	bool test1Model_testBoolean = test1Model.testBoolean;
	// 测试Boolean型
	WriteBool(test1Model_testBoolean);
	string test1Model_testString = test1Model.testString;
	// 测试String型
	WriteString(test1Model_testString);
	long[] test1Model_testLongs = test1Model.testLongs;
	// 测试Long型
	WriteShort((short)test1Model_testLongs.Length);
	int test1Model_testLongsSize = test1Model_testLongs.Length;
	int test1Model_testLongsIndex = 0;
	for(test1Model_testLongsIndex=0; test1Model_testLongsIndex<test1Model_testLongsSize; test1Model_testLongsIndex++){
		WriteLong(test1Model_testLongs [ test1Model_testLongsIndex ]);
	}//end
	
	int[] test1Model_testIntegers = test1Model.testIntegers;
	// 测试Integer型
	WriteShort((short)test1Model_testIntegers.Length);
	int test1Model_testIntegersSize = test1Model_testIntegers.Length;
	int test1Model_testIntegersIndex = 0;
	for(test1Model_testIntegersIndex=0; test1Model_testIntegersIndex<test1Model_testIntegersSize; test1Model_testIntegersIndex++){
		WriteInt(test1Model_testIntegers [ test1Model_testIntegersIndex ]);
	}//end
	
	short[] test1Model_testShorts = test1Model.testShorts;
	// 测试Short型
	WriteShort((short)test1Model_testShorts.Length);
	int test1Model_testShortsSize = test1Model_testShorts.Length;
	int test1Model_testShortsIndex = 0;
	for(test1Model_testShortsIndex=0; test1Model_testShortsIndex<test1Model_testShortsSize; test1Model_testShortsIndex++){
		WriteShort(test1Model_testShorts [ test1Model_testShortsIndex ]);
	}//end
	
	byte[] test1Model_testBytes = test1Model.testBytes;
	// 测试Byte型
	WriteShort((short)test1Model_testBytes.Length);
	int test1Model_testBytesSize = test1Model_testBytes.Length;
	int test1Model_testBytesIndex = 0;
	for(test1Model_testBytesIndex=0; test1Model_testBytesIndex<test1Model_testBytesSize; test1Model_testBytesIndex++){
		WriteByte(test1Model_testBytes [ test1Model_testBytesIndex ]);
	}//end
	
	bool[] test1Model_testBooleans = test1Model.testBooleans;
	// 测试Boolean型
	WriteShort((short)test1Model_testBooleans.Length);
	int test1Model_testBooleansSize = test1Model_testBooleans.Length;
	int test1Model_testBooleansIndex = 0;
	for(test1Model_testBooleansIndex=0; test1Model_testBooleansIndex<test1Model_testBooleansSize; test1Model_testBooleansIndex++){
		WriteBool(test1Model_testBooleans [ test1Model_testBooleansIndex ]);
	}//end
	
	string[] test1Model_testStrings = test1Model.testStrings;
	// 测试String型
	WriteShort((short)test1Model_testStrings.Length);
	int test1Model_testStringsSize = test1Model_testStrings.Length;
	int test1Model_testStringsIndex = 0;
	for(test1Model_testStringsIndex=0; test1Model_testStringsIndex<test1Model_testStringsSize; test1Model_testStringsIndex++){
		WriteString(test1Model_testStrings [ test1Model_testStringsIndex ]);
	}//end
	

	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEST1;
	}
	
	public override string getEventType()
	{
		return "";
	}
	

	public long[] getTestLongs()
	{
		return testLongs;
	}

	public void setTestLongs(long[] testLongs)
	{
		this.testLongs = testLongs;
	}

	public int[] getTestIntegers()
	{
		return testIntegers;
	}

	public void setTestIntegers(int[] testIntegers)
	{
		this.testIntegers = testIntegers;
	}

	public short[] getTestShorts()
	{
		return testShorts;
	}

	public void setTestShorts(short[] testShorts)
	{
		this.testShorts = testShorts;
	}

	public byte[] getTestBytes()
	{
		return testBytes;
	}

	public void setTestBytes(byte[] testBytes)
	{
		this.testBytes = testBytes;
	}

	public bool[] getTestBooleans()
	{
		return testBooleans;
	}

	public void setTestBooleans(bool[] testBooleans)
	{
		this.testBooleans = testBooleans;
	}

	public string[] getTestStrings()
	{
		return testStrings;
	}

	public void setTestStrings(string[] testStrings)
	{
		this.testStrings = testStrings;
	}
	}
}