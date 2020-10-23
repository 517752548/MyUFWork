
using System;
namespace app.net
{
/**
 * 更新单个道具信息，客户端受到此消息就替换原来此位置的道具
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTest1 :BaseMessage
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

	public GCTest1 ()
	{
	}

	protected override void ReadImpl()
	{
	// 测试Long型
	long _testLong = ReadLong();
	// 测试Integer型
	int _testInteger = ReadInt();
	// 测试Short型
	short _testShort = ReadShort();
	// 测试Byte型
	byte _testByte = ReadByte();
	// 测试Boolean型
	bool _testBoolean = ReadBool();
	// 测试String型
	string _testString = ReadString();
	// 测试Long型
	int testLongsSize = ReadShort();
	long[] _testLongs = new long[testLongsSize];
	int testLongsIndex = 0;
	for(testLongsIndex=0; testLongsIndex<testLongsSize; testLongsIndex++){
		_testLongs[testLongsIndex] = ReadLong();
	}//end
	
	// 测试Integer型
	int testIntegersSize = ReadShort();
	int[] _testIntegers = new int[testIntegersSize];
	int testIntegersIndex = 0;
	for(testIntegersIndex=0; testIntegersIndex<testIntegersSize; testIntegersIndex++){
		_testIntegers[testIntegersIndex] = ReadInt();
	}//end
	
	// 测试Short型
	int testShortsSize = ReadShort();
	short[] _testShorts = new short[testShortsSize];
	int testShortsIndex = 0;
	for(testShortsIndex=0; testShortsIndex<testShortsSize; testShortsIndex++){
		_testShorts[testShortsIndex] = ReadShort();
	}//end
	
	// 测试Byte型
	int testBytesSize = ReadShort();
	byte[] _testBytes = new byte[testBytesSize];
	int testBytesIndex = 0;
	for(testBytesIndex=0; testBytesIndex<testBytesSize; testBytesIndex++){
		_testBytes[testBytesIndex] = ReadByte();
	}//end
	
	// 测试Boolean型
	int testBooleansSize = ReadShort();
	bool[] _testBooleans = new bool[testBooleansSize];
	int testBooleansIndex = 0;
	for(testBooleansIndex=0; testBooleansIndex<testBooleansSize; testBooleansIndex++){
		_testBooleans[testBooleansIndex] = ReadBool();
	}//end
	
	// 测试String型
	int testStringsSize = ReadShort();
	string[] _testStrings = new string[testStringsSize];
	int testStringsIndex = 0;
	for(testStringsIndex=0; testStringsIndex<testStringsSize; testStringsIndex++){
		_testStrings[testStringsIndex] = ReadString();
	}//end
	
	// 单个测试信息
	Test1Model _test1Model = new Test1Model();
	// 测试Long型
	long _test1Model_testLong = ReadLong();	_test1Model.testLong = _test1Model_testLong;
	// 测试Integer型
	int _test1Model_testInteger = ReadInt();	_test1Model.testInteger = _test1Model_testInteger;
	// 测试Short型
	short _test1Model_testShort = ReadShort();	_test1Model.testShort = _test1Model_testShort;
	// 测试Byte型
	byte _test1Model_testByte = ReadByte();	_test1Model.testByte = _test1Model_testByte;
	// 测试Boolean型
	bool _test1Model_testBoolean = ReadBool();	_test1Model.testBoolean = _test1Model_testBoolean;
	// 测试String型
	string _test1Model_testString = ReadString();	_test1Model.testString = _test1Model_testString;
	// 测试Long型
	int test1Model_testLongsSize = ReadShort();
	long[] _test1Model_testLongs = new long[test1Model_testLongsSize];
	int test1Model_testLongsIndex = 0;
	for(test1Model_testLongsIndex=0; test1Model_testLongsIndex<test1Model_testLongsSize; test1Model_testLongsIndex++){
		_test1Model_testLongs[test1Model_testLongsIndex] = ReadLong();
	}//end
		_test1Model.testLongs = _test1Model_testLongs;
	// 测试Integer型
	int test1Model_testIntegersSize = ReadShort();
	int[] _test1Model_testIntegers = new int[test1Model_testIntegersSize];
	int test1Model_testIntegersIndex = 0;
	for(test1Model_testIntegersIndex=0; test1Model_testIntegersIndex<test1Model_testIntegersSize; test1Model_testIntegersIndex++){
		_test1Model_testIntegers[test1Model_testIntegersIndex] = ReadInt();
	}//end
		_test1Model.testIntegers = _test1Model_testIntegers;
	// 测试Short型
	int test1Model_testShortsSize = ReadShort();
	short[] _test1Model_testShorts = new short[test1Model_testShortsSize];
	int test1Model_testShortsIndex = 0;
	for(test1Model_testShortsIndex=0; test1Model_testShortsIndex<test1Model_testShortsSize; test1Model_testShortsIndex++){
		_test1Model_testShorts[test1Model_testShortsIndex] = ReadShort();
	}//end
		_test1Model.testShorts = _test1Model_testShorts;
	// 测试Byte型
	int test1Model_testBytesSize = ReadShort();
	byte[] _test1Model_testBytes = new byte[test1Model_testBytesSize];
	int test1Model_testBytesIndex = 0;
	for(test1Model_testBytesIndex=0; test1Model_testBytesIndex<test1Model_testBytesSize; test1Model_testBytesIndex++){
		_test1Model_testBytes[test1Model_testBytesIndex] = ReadByte();
	}//end
		_test1Model.testBytes = _test1Model_testBytes;
	// 测试Boolean型
	int test1Model_testBooleansSize = ReadShort();
	bool[] _test1Model_testBooleans = new bool[test1Model_testBooleansSize];
	int test1Model_testBooleansIndex = 0;
	for(test1Model_testBooleansIndex=0; test1Model_testBooleansIndex<test1Model_testBooleansSize; test1Model_testBooleansIndex++){
		_test1Model_testBooleans[test1Model_testBooleansIndex] = ReadBool();
	}//end
		_test1Model.testBooleans = _test1Model_testBooleans;
	// 测试String型
	int test1Model_testStringsSize = ReadShort();
	string[] _test1Model_testStrings = new string[test1Model_testStringsSize];
	int test1Model_testStringsIndex = 0;
	for(test1Model_testStringsIndex=0; test1Model_testStringsIndex<test1Model_testStringsSize; test1Model_testStringsIndex++){
		_test1Model_testStrings[test1Model_testStringsIndex] = ReadString();
	}//end
		_test1Model.testStrings = _test1Model_testStrings;



		this.testLong = _testLong;
		this.testInteger = _testInteger;
		this.testShort = _testShort;
		this.testByte = _testByte;
		this.testBoolean = _testBoolean;
		this.testString = _testString;
		this.testLongs = _testLongs;
		this.testIntegers = _testIntegers;
		this.testShorts = _testShorts;
		this.testBytes = _testBytes;
		this.testBooleans = _testBooleans;
		this.testStrings = _testStrings;
		this.test1Model = _test1Model;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TEST1;
	}
	
	public override string getEventType()
	{
		return TestGCHandler.GCTest1Event;
	}
	

	public long getTestLong(){
		return testLong;
	}
		

	public int getTestInteger(){
		return testInteger;
	}
		

	public short getTestShort(){
		return testShort;
	}
		

	public byte getTestByte(){
		return testByte;
	}
		

	public bool getTestBoolean(){
		return testBoolean;
	}
		

	public string getTestString(){
		return testString;
	}
		

	public long[] getTestLongs(){
		return testLongs;
	}


	public int[] getTestIntegers(){
		return testIntegers;
	}


	public short[] getTestShorts(){
		return testShorts;
	}


	public byte[] getTestBytes(){
		return testBytes;
	}


	public bool[] getTestBooleans(){
		return testBooleans;
	}


	public string[] getTestStrings(){
		return testStrings;
	}


	public Test1Model getTest1Model(){
		return test1Model;
	}
		

}
}