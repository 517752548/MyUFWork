using System;
using System.IO;
namespace app.net
{

/**
 * 更新单个道具信息，客户端受到此消息就替换原来此位置的道具
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTest :BaseMessage
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
	/** 单个测试信息 */
	private Test3ModelList[] test3Models;
	
	public CGTest ()
	{
	}
	
	public CGTest (
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
			Test1Model test1Model,
			Test3ModelList[] test3Models )
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
			this.test3Models = test3Models;
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
	

	// 单个测试信息
	WriteShort((short)test3Models.Length);
	int test3ModelsIndex = 0;
	int test3ModelsSize = test3Models.Length;
	for(test3ModelsIndex=0; test3ModelsIndex<test3ModelsSize; test3ModelsIndex++){

	long test3Models_testLong = test3Models[test3ModelsIndex].testLong;
	// 测试Long型
	WriteLong(test3Models_testLong);
	int test3Models_testInteger = test3Models[test3ModelsIndex].testInteger;
	// 测试Integer型
	WriteInt(test3Models_testInteger);
	short test3Models_testShort = test3Models[test3ModelsIndex].testShort;
	// 测试Short型
	WriteShort(test3Models_testShort);
	byte test3Models_testByte = test3Models[test3ModelsIndex].testByte;
	// 测试Byte型
	WriteByte(test3Models_testByte);
	bool test3Models_testBoolean = test3Models[test3ModelsIndex].testBoolean;
	// 测试Boolean型
	WriteBool(test3Models_testBoolean);
	string test3Models_testString = test3Models[test3ModelsIndex].testString;
	// 测试String型
	WriteString(test3Models_testString);
	long[] test3Models_testLongs = test3Models[test3ModelsIndex].testLongs;
	// 测试Long型
	WriteShort((short)test3Models_testLongs.Length);
	int test3Models_testLongsSize = test3Models_testLongs.Length;
	int test3Models_testLongsIndex = 0;
	for(test3Models_testLongsIndex=0; test3Models_testLongsIndex<test3Models_testLongsSize; test3Models_testLongsIndex++){
		WriteLong(test3Models_testLongs [ test3Models_testLongsIndex ]);
	}//end
	
	int[] test3Models_testIntegers = test3Models[test3ModelsIndex].testIntegers;
	// 测试Integer型
	WriteShort((short)test3Models_testIntegers.Length);
	int test3Models_testIntegersSize = test3Models_testIntegers.Length;
	int test3Models_testIntegersIndex = 0;
	for(test3Models_testIntegersIndex=0; test3Models_testIntegersIndex<test3Models_testIntegersSize; test3Models_testIntegersIndex++){
		WriteInt(test3Models_testIntegers [ test3Models_testIntegersIndex ]);
	}//end
	
	short[] test3Models_testShorts = test3Models[test3ModelsIndex].testShorts;
	// 测试Short型
	WriteShort((short)test3Models_testShorts.Length);
	int test3Models_testShortsSize = test3Models_testShorts.Length;
	int test3Models_testShortsIndex = 0;
	for(test3Models_testShortsIndex=0; test3Models_testShortsIndex<test3Models_testShortsSize; test3Models_testShortsIndex++){
		WriteShort(test3Models_testShorts [ test3Models_testShortsIndex ]);
	}//end
	
	byte[] test3Models_testBytes = test3Models[test3ModelsIndex].testBytes;
	// 测试Byte型
	WriteShort((short)test3Models_testBytes.Length);
	int test3Models_testBytesSize = test3Models_testBytes.Length;
	int test3Models_testBytesIndex = 0;
	for(test3Models_testBytesIndex=0; test3Models_testBytesIndex<test3Models_testBytesSize; test3Models_testBytesIndex++){
		WriteByte(test3Models_testBytes [ test3Models_testBytesIndex ]);
	}//end
	
	bool[] test3Models_testBooleans = test3Models[test3ModelsIndex].testBooleans;
	// 测试Boolean型
	WriteShort((short)test3Models_testBooleans.Length);
	int test3Models_testBooleansSize = test3Models_testBooleans.Length;
	int test3Models_testBooleansIndex = 0;
	for(test3Models_testBooleansIndex=0; test3Models_testBooleansIndex<test3Models_testBooleansSize; test3Models_testBooleansIndex++){
		WriteBool(test3Models_testBooleans [ test3Models_testBooleansIndex ]);
	}//end
	
	string[] test3Models_testStrings = test3Models[test3ModelsIndex].testStrings;
	// 测试String型
	WriteShort((short)test3Models_testStrings.Length);
	int test3Models_testStringsSize = test3Models_testStrings.Length;
	int test3Models_testStringsIndex = 0;
	for(test3Models_testStringsIndex=0; test3Models_testStringsIndex<test3Models_testStringsSize; test3Models_testStringsIndex++){
		WriteString(test3Models_testStrings [ test3Models_testStringsIndex ]);
	}//end
	
	Test2Model[] test3Models_test2Models = test3Models[test3ModelsIndex].test2Models;

	// 测试test2Models信息
	WriteShort((short)test3Models_test2Models.Length);
	int test3Models_test2ModelsIndex = 0;
	int test3Models_test2ModelsSize = test3Models_test2Models.Length;
	for(test3Models_test2ModelsIndex=0; test3Models_test2ModelsIndex<test3Models_test2ModelsSize; test3Models_test2ModelsIndex++){

	long test3Models_test2Models_testLong = test3Models_test2Models[test3Models_test2ModelsIndex].testLong;
	// 测试Long型
	WriteLong(test3Models_test2Models_testLong);
	int test3Models_test2Models_testInteger = test3Models_test2Models[test3Models_test2ModelsIndex].testInteger;
	// 测试Integer型
	WriteInt(test3Models_test2Models_testInteger);
	short test3Models_test2Models_testShort = test3Models_test2Models[test3Models_test2ModelsIndex].testShort;
	// 测试Short型
	WriteShort(test3Models_test2Models_testShort);
	byte test3Models_test2Models_testByte = test3Models_test2Models[test3Models_test2ModelsIndex].testByte;
	// 测试Byte型
	WriteByte(test3Models_test2Models_testByte);
	bool test3Models_test2Models_testBoolean = test3Models_test2Models[test3Models_test2ModelsIndex].testBoolean;
	// 测试Boolean型
	WriteBool(test3Models_test2Models_testBoolean);
	string test3Models_test2Models_testString = test3Models_test2Models[test3Models_test2ModelsIndex].testString;
	// 测试String型
	WriteString(test3Models_test2Models_testString);
	long[] test3Models_test2Models_testLongs = test3Models_test2Models[test3Models_test2ModelsIndex].testLongs;
	// 测试Long型
	WriteShort((short)test3Models_test2Models_testLongs.Length);
	int test3Models_test2Models_testLongsSize = test3Models_test2Models_testLongs.Length;
	int test3Models_test2Models_testLongsIndex = 0;
	for(test3Models_test2Models_testLongsIndex=0; test3Models_test2Models_testLongsIndex<test3Models_test2Models_testLongsSize; test3Models_test2Models_testLongsIndex++){
		WriteLong(test3Models_test2Models_testLongs [ test3Models_test2Models_testLongsIndex ]);
	}//end
	
	int[] test3Models_test2Models_testIntegers = test3Models_test2Models[test3Models_test2ModelsIndex].testIntegers;
	// 测试Integer型
	WriteShort((short)test3Models_test2Models_testIntegers.Length);
	int test3Models_test2Models_testIntegersSize = test3Models_test2Models_testIntegers.Length;
	int test3Models_test2Models_testIntegersIndex = 0;
	for(test3Models_test2Models_testIntegersIndex=0; test3Models_test2Models_testIntegersIndex<test3Models_test2Models_testIntegersSize; test3Models_test2Models_testIntegersIndex++){
		WriteInt(test3Models_test2Models_testIntegers [ test3Models_test2Models_testIntegersIndex ]);
	}//end
	
	short[] test3Models_test2Models_testShorts = test3Models_test2Models[test3Models_test2ModelsIndex].testShorts;
	// 测试Short型
	WriteShort((short)test3Models_test2Models_testShorts.Length);
	int test3Models_test2Models_testShortsSize = test3Models_test2Models_testShorts.Length;
	int test3Models_test2Models_testShortsIndex = 0;
	for(test3Models_test2Models_testShortsIndex=0; test3Models_test2Models_testShortsIndex<test3Models_test2Models_testShortsSize; test3Models_test2Models_testShortsIndex++){
		WriteShort(test3Models_test2Models_testShorts [ test3Models_test2Models_testShortsIndex ]);
	}//end
	
	byte[] test3Models_test2Models_testBytes = test3Models_test2Models[test3Models_test2ModelsIndex].testBytes;
	// 测试Byte型
	WriteShort((short)test3Models_test2Models_testBytes.Length);
	int test3Models_test2Models_testBytesSize = test3Models_test2Models_testBytes.Length;
	int test3Models_test2Models_testBytesIndex = 0;
	for(test3Models_test2Models_testBytesIndex=0; test3Models_test2Models_testBytesIndex<test3Models_test2Models_testBytesSize; test3Models_test2Models_testBytesIndex++){
		WriteByte(test3Models_test2Models_testBytes [ test3Models_test2Models_testBytesIndex ]);
	}//end
	
	bool[] test3Models_test2Models_testBooleans = test3Models_test2Models[test3Models_test2ModelsIndex].testBooleans;
	// 测试Boolean型
	WriteShort((short)test3Models_test2Models_testBooleans.Length);
	int test3Models_test2Models_testBooleansSize = test3Models_test2Models_testBooleans.Length;
	int test3Models_test2Models_testBooleansIndex = 0;
	for(test3Models_test2Models_testBooleansIndex=0; test3Models_test2Models_testBooleansIndex<test3Models_test2Models_testBooleansSize; test3Models_test2Models_testBooleansIndex++){
		WriteBool(test3Models_test2Models_testBooleans [ test3Models_test2Models_testBooleansIndex ]);
	}//end
	
	string[] test3Models_test2Models_testStrings = test3Models_test2Models[test3Models_test2ModelsIndex].testStrings;
	// 测试String型
	WriteShort((short)test3Models_test2Models_testStrings.Length);
	int test3Models_test2Models_testStringsSize = test3Models_test2Models_testStrings.Length;
	int test3Models_test2Models_testStringsIndex = 0;
	for(test3Models_test2Models_testStringsIndex=0; test3Models_test2Models_testStringsIndex<test3Models_test2Models_testStringsSize; test3Models_test2Models_testStringsIndex++){
		WriteString(test3Models_test2Models_testStrings [ test3Models_test2Models_testStringsIndex ]);
	}//end
	
	Test1Model[] test3Models_test2Models_test1Model = test3Models_test2Models[test3Models_test2ModelsIndex].test1Model;

	// 测试test1Model信息
	WriteShort((short)test3Models_test2Models_test1Model.Length);
	int test3Models_test2Models_test1ModelIndex = 0;
	int test3Models_test2Models_test1ModelSize = test3Models_test2Models_test1Model.Length;
	for(test3Models_test2Models_test1ModelIndex=0; test3Models_test2Models_test1ModelIndex<test3Models_test2Models_test1ModelSize; test3Models_test2Models_test1ModelIndex++){

	long test3Models_test2Models_test1Model_testLong = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testLong;
	// 测试Long型
	WriteLong(test3Models_test2Models_test1Model_testLong);
	int test3Models_test2Models_test1Model_testInteger = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testInteger;
	// 测试Integer型
	WriteInt(test3Models_test2Models_test1Model_testInteger);
	short test3Models_test2Models_test1Model_testShort = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testShort;
	// 测试Short型
	WriteShort(test3Models_test2Models_test1Model_testShort);
	byte test3Models_test2Models_test1Model_testByte = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testByte;
	// 测试Byte型
	WriteByte(test3Models_test2Models_test1Model_testByte);
	bool test3Models_test2Models_test1Model_testBoolean = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testBoolean;
	// 测试Boolean型
	WriteBool(test3Models_test2Models_test1Model_testBoolean);
	string test3Models_test2Models_test1Model_testString = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testString;
	// 测试String型
	WriteString(test3Models_test2Models_test1Model_testString);
	long[] test3Models_test2Models_test1Model_testLongs = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testLongs;
	// 测试Long型
	WriteShort((short)test3Models_test2Models_test1Model_testLongs.Length);
	int test3Models_test2Models_test1Model_testLongsSize = test3Models_test2Models_test1Model_testLongs.Length;
	int test3Models_test2Models_test1Model_testLongsIndex = 0;
	for(test3Models_test2Models_test1Model_testLongsIndex=0; test3Models_test2Models_test1Model_testLongsIndex<test3Models_test2Models_test1Model_testLongsSize; test3Models_test2Models_test1Model_testLongsIndex++){
		WriteLong(test3Models_test2Models_test1Model_testLongs [ test3Models_test2Models_test1Model_testLongsIndex ]);
	}//end
	
	int[] test3Models_test2Models_test1Model_testIntegers = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testIntegers;
	// 测试Integer型
	WriteShort((short)test3Models_test2Models_test1Model_testIntegers.Length);
	int test3Models_test2Models_test1Model_testIntegersSize = test3Models_test2Models_test1Model_testIntegers.Length;
	int test3Models_test2Models_test1Model_testIntegersIndex = 0;
	for(test3Models_test2Models_test1Model_testIntegersIndex=0; test3Models_test2Models_test1Model_testIntegersIndex<test3Models_test2Models_test1Model_testIntegersSize; test3Models_test2Models_test1Model_testIntegersIndex++){
		WriteInt(test3Models_test2Models_test1Model_testIntegers [ test3Models_test2Models_test1Model_testIntegersIndex ]);
	}//end
	
	short[] test3Models_test2Models_test1Model_testShorts = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testShorts;
	// 测试Short型
	WriteShort((short)test3Models_test2Models_test1Model_testShorts.Length);
	int test3Models_test2Models_test1Model_testShortsSize = test3Models_test2Models_test1Model_testShorts.Length;
	int test3Models_test2Models_test1Model_testShortsIndex = 0;
	for(test3Models_test2Models_test1Model_testShortsIndex=0; test3Models_test2Models_test1Model_testShortsIndex<test3Models_test2Models_test1Model_testShortsSize; test3Models_test2Models_test1Model_testShortsIndex++){
		WriteShort(test3Models_test2Models_test1Model_testShorts [ test3Models_test2Models_test1Model_testShortsIndex ]);
	}//end
	
	byte[] test3Models_test2Models_test1Model_testBytes = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testBytes;
	// 测试Byte型
	WriteShort((short)test3Models_test2Models_test1Model_testBytes.Length);
	int test3Models_test2Models_test1Model_testBytesSize = test3Models_test2Models_test1Model_testBytes.Length;
	int test3Models_test2Models_test1Model_testBytesIndex = 0;
	for(test3Models_test2Models_test1Model_testBytesIndex=0; test3Models_test2Models_test1Model_testBytesIndex<test3Models_test2Models_test1Model_testBytesSize; test3Models_test2Models_test1Model_testBytesIndex++){
		WriteByte(test3Models_test2Models_test1Model_testBytes [ test3Models_test2Models_test1Model_testBytesIndex ]);
	}//end
	
	bool[] test3Models_test2Models_test1Model_testBooleans = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testBooleans;
	// 测试Boolean型
	WriteShort((short)test3Models_test2Models_test1Model_testBooleans.Length);
	int test3Models_test2Models_test1Model_testBooleansSize = test3Models_test2Models_test1Model_testBooleans.Length;
	int test3Models_test2Models_test1Model_testBooleansIndex = 0;
	for(test3Models_test2Models_test1Model_testBooleansIndex=0; test3Models_test2Models_test1Model_testBooleansIndex<test3Models_test2Models_test1Model_testBooleansSize; test3Models_test2Models_test1Model_testBooleansIndex++){
		WriteBool(test3Models_test2Models_test1Model_testBooleans [ test3Models_test2Models_test1Model_testBooleansIndex ]);
	}//end
	
	string[] test3Models_test2Models_test1Model_testStrings = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].testStrings;
	// 测试String型
	WriteShort((short)test3Models_test2Models_test1Model_testStrings.Length);
	int test3Models_test2Models_test1Model_testStringsSize = test3Models_test2Models_test1Model_testStrings.Length;
	int test3Models_test2Models_test1Model_testStringsIndex = 0;
	for(test3Models_test2Models_test1Model_testStringsIndex=0; test3Models_test2Models_test1Model_testStringsIndex<test3Models_test2Models_test1Model_testStringsSize; test3Models_test2Models_test1Model_testStringsIndex++){
		WriteString(test3Models_test2Models_test1Model_testStrings [ test3Models_test2Models_test1Model_testStringsIndex ]);
	}//end
		}
	//end
	}
	//end

	Test2Model test3Models_test2Model = test3Models[test3ModelsIndex].test2Model;

	long test3Models_test2Model_testLong = test3Models_test2Model.testLong;
	// 测试Long型
	WriteLong(test3Models_test2Model_testLong);
	int test3Models_test2Model_testInteger = test3Models_test2Model.testInteger;
	// 测试Integer型
	WriteInt(test3Models_test2Model_testInteger);
	short test3Models_test2Model_testShort = test3Models_test2Model.testShort;
	// 测试Short型
	WriteShort(test3Models_test2Model_testShort);
	byte test3Models_test2Model_testByte = test3Models_test2Model.testByte;
	// 测试Byte型
	WriteByte(test3Models_test2Model_testByte);
	bool test3Models_test2Model_testBoolean = test3Models_test2Model.testBoolean;
	// 测试Boolean型
	WriteBool(test3Models_test2Model_testBoolean);
	string test3Models_test2Model_testString = test3Models_test2Model.testString;
	// 测试String型
	WriteString(test3Models_test2Model_testString);
	long[] test3Models_test2Model_testLongs = test3Models_test2Model.testLongs;
	// 测试Long型
	WriteShort((short)test3Models_test2Model_testLongs.Length);
	int test3Models_test2Model_testLongsSize = test3Models_test2Model_testLongs.Length;
	int test3Models_test2Model_testLongsIndex = 0;
	for(test3Models_test2Model_testLongsIndex=0; test3Models_test2Model_testLongsIndex<test3Models_test2Model_testLongsSize; test3Models_test2Model_testLongsIndex++){
		WriteLong(test3Models_test2Model_testLongs [ test3Models_test2Model_testLongsIndex ]);
	}//end
	
	int[] test3Models_test2Model_testIntegers = test3Models_test2Model.testIntegers;
	// 测试Integer型
	WriteShort((short)test3Models_test2Model_testIntegers.Length);
	int test3Models_test2Model_testIntegersSize = test3Models_test2Model_testIntegers.Length;
	int test3Models_test2Model_testIntegersIndex = 0;
	for(test3Models_test2Model_testIntegersIndex=0; test3Models_test2Model_testIntegersIndex<test3Models_test2Model_testIntegersSize; test3Models_test2Model_testIntegersIndex++){
		WriteInt(test3Models_test2Model_testIntegers [ test3Models_test2Model_testIntegersIndex ]);
	}//end
	
	short[] test3Models_test2Model_testShorts = test3Models_test2Model.testShorts;
	// 测试Short型
	WriteShort((short)test3Models_test2Model_testShorts.Length);
	int test3Models_test2Model_testShortsSize = test3Models_test2Model_testShorts.Length;
	int test3Models_test2Model_testShortsIndex = 0;
	for(test3Models_test2Model_testShortsIndex=0; test3Models_test2Model_testShortsIndex<test3Models_test2Model_testShortsSize; test3Models_test2Model_testShortsIndex++){
		WriteShort(test3Models_test2Model_testShorts [ test3Models_test2Model_testShortsIndex ]);
	}//end
	
	byte[] test3Models_test2Model_testBytes = test3Models_test2Model.testBytes;
	// 测试Byte型
	WriteShort((short)test3Models_test2Model_testBytes.Length);
	int test3Models_test2Model_testBytesSize = test3Models_test2Model_testBytes.Length;
	int test3Models_test2Model_testBytesIndex = 0;
	for(test3Models_test2Model_testBytesIndex=0; test3Models_test2Model_testBytesIndex<test3Models_test2Model_testBytesSize; test3Models_test2Model_testBytesIndex++){
		WriteByte(test3Models_test2Model_testBytes [ test3Models_test2Model_testBytesIndex ]);
	}//end
	
	bool[] test3Models_test2Model_testBooleans = test3Models_test2Model.testBooleans;
	// 测试Boolean型
	WriteShort((short)test3Models_test2Model_testBooleans.Length);
	int test3Models_test2Model_testBooleansSize = test3Models_test2Model_testBooleans.Length;
	int test3Models_test2Model_testBooleansIndex = 0;
	for(test3Models_test2Model_testBooleansIndex=0; test3Models_test2Model_testBooleansIndex<test3Models_test2Model_testBooleansSize; test3Models_test2Model_testBooleansIndex++){
		WriteBool(test3Models_test2Model_testBooleans [ test3Models_test2Model_testBooleansIndex ]);
	}//end
	
	string[] test3Models_test2Model_testStrings = test3Models_test2Model.testStrings;
	// 测试String型
	WriteShort((short)test3Models_test2Model_testStrings.Length);
	int test3Models_test2Model_testStringsSize = test3Models_test2Model_testStrings.Length;
	int test3Models_test2Model_testStringsIndex = 0;
	for(test3Models_test2Model_testStringsIndex=0; test3Models_test2Model_testStringsIndex<test3Models_test2Model_testStringsSize; test3Models_test2Model_testStringsIndex++){
		WriteString(test3Models_test2Model_testStrings [ test3Models_test2Model_testStringsIndex ]);
	}//end
	
	Test1Model[] test3Models_test2Model_test1Model = test3Models_test2Model.test1Model;

	// 测试test1Model信息
	WriteShort((short)test3Models_test2Model_test1Model.Length);
	int test3Models_test2Model_test1ModelIndex = 0;
	int test3Models_test2Model_test1ModelSize = test3Models_test2Model_test1Model.Length;
	for(test3Models_test2Model_test1ModelIndex=0; test3Models_test2Model_test1ModelIndex<test3Models_test2Model_test1ModelSize; test3Models_test2Model_test1ModelIndex++){

	long test3Models_test2Model_test1Model_testLong = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testLong;
	// 测试Long型
	WriteLong(test3Models_test2Model_test1Model_testLong);
	int test3Models_test2Model_test1Model_testInteger = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testInteger;
	// 测试Integer型
	WriteInt(test3Models_test2Model_test1Model_testInteger);
	short test3Models_test2Model_test1Model_testShort = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testShort;
	// 测试Short型
	WriteShort(test3Models_test2Model_test1Model_testShort);
	byte test3Models_test2Model_test1Model_testByte = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testByte;
	// 测试Byte型
	WriteByte(test3Models_test2Model_test1Model_testByte);
	bool test3Models_test2Model_test1Model_testBoolean = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testBoolean;
	// 测试Boolean型
	WriteBool(test3Models_test2Model_test1Model_testBoolean);
	string test3Models_test2Model_test1Model_testString = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testString;
	// 测试String型
	WriteString(test3Models_test2Model_test1Model_testString);
	long[] test3Models_test2Model_test1Model_testLongs = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testLongs;
	// 测试Long型
	WriteShort((short)test3Models_test2Model_test1Model_testLongs.Length);
	int test3Models_test2Model_test1Model_testLongsSize = test3Models_test2Model_test1Model_testLongs.Length;
	int test3Models_test2Model_test1Model_testLongsIndex = 0;
	for(test3Models_test2Model_test1Model_testLongsIndex=0; test3Models_test2Model_test1Model_testLongsIndex<test3Models_test2Model_test1Model_testLongsSize; test3Models_test2Model_test1Model_testLongsIndex++){
		WriteLong(test3Models_test2Model_test1Model_testLongs [ test3Models_test2Model_test1Model_testLongsIndex ]);
	}//end
	
	int[] test3Models_test2Model_test1Model_testIntegers = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testIntegers;
	// 测试Integer型
	WriteShort((short)test3Models_test2Model_test1Model_testIntegers.Length);
	int test3Models_test2Model_test1Model_testIntegersSize = test3Models_test2Model_test1Model_testIntegers.Length;
	int test3Models_test2Model_test1Model_testIntegersIndex = 0;
	for(test3Models_test2Model_test1Model_testIntegersIndex=0; test3Models_test2Model_test1Model_testIntegersIndex<test3Models_test2Model_test1Model_testIntegersSize; test3Models_test2Model_test1Model_testIntegersIndex++){
		WriteInt(test3Models_test2Model_test1Model_testIntegers [ test3Models_test2Model_test1Model_testIntegersIndex ]);
	}//end
	
	short[] test3Models_test2Model_test1Model_testShorts = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testShorts;
	// 测试Short型
	WriteShort((short)test3Models_test2Model_test1Model_testShorts.Length);
	int test3Models_test2Model_test1Model_testShortsSize = test3Models_test2Model_test1Model_testShorts.Length;
	int test3Models_test2Model_test1Model_testShortsIndex = 0;
	for(test3Models_test2Model_test1Model_testShortsIndex=0; test3Models_test2Model_test1Model_testShortsIndex<test3Models_test2Model_test1Model_testShortsSize; test3Models_test2Model_test1Model_testShortsIndex++){
		WriteShort(test3Models_test2Model_test1Model_testShorts [ test3Models_test2Model_test1Model_testShortsIndex ]);
	}//end
	
	byte[] test3Models_test2Model_test1Model_testBytes = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testBytes;
	// 测试Byte型
	WriteShort((short)test3Models_test2Model_test1Model_testBytes.Length);
	int test3Models_test2Model_test1Model_testBytesSize = test3Models_test2Model_test1Model_testBytes.Length;
	int test3Models_test2Model_test1Model_testBytesIndex = 0;
	for(test3Models_test2Model_test1Model_testBytesIndex=0; test3Models_test2Model_test1Model_testBytesIndex<test3Models_test2Model_test1Model_testBytesSize; test3Models_test2Model_test1Model_testBytesIndex++){
		WriteByte(test3Models_test2Model_test1Model_testBytes [ test3Models_test2Model_test1Model_testBytesIndex ]);
	}//end
	
	bool[] test3Models_test2Model_test1Model_testBooleans = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testBooleans;
	// 测试Boolean型
	WriteShort((short)test3Models_test2Model_test1Model_testBooleans.Length);
	int test3Models_test2Model_test1Model_testBooleansSize = test3Models_test2Model_test1Model_testBooleans.Length;
	int test3Models_test2Model_test1Model_testBooleansIndex = 0;
	for(test3Models_test2Model_test1Model_testBooleansIndex=0; test3Models_test2Model_test1Model_testBooleansIndex<test3Models_test2Model_test1Model_testBooleansSize; test3Models_test2Model_test1Model_testBooleansIndex++){
		WriteBool(test3Models_test2Model_test1Model_testBooleans [ test3Models_test2Model_test1Model_testBooleansIndex ]);
	}//end
	
	string[] test3Models_test2Model_test1Model_testStrings = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].testStrings;
	// 测试String型
	WriteShort((short)test3Models_test2Model_test1Model_testStrings.Length);
	int test3Models_test2Model_test1Model_testStringsSize = test3Models_test2Model_test1Model_testStrings.Length;
	int test3Models_test2Model_test1Model_testStringsIndex = 0;
	for(test3Models_test2Model_test1Model_testStringsIndex=0; test3Models_test2Model_test1Model_testStringsIndex<test3Models_test2Model_test1Model_testStringsSize; test3Models_test2Model_test1Model_testStringsIndex++){
		WriteString(test3Models_test2Model_test1Model_testStrings [ test3Models_test2Model_test1Model_testStringsIndex ]);
	}//end
		}
	//end
	}
	//end


	}
	
	public override short GetMessageType()
	{
		return (short)MessageType.CG_TEST;
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

	public Test3ModelList[] getTest3Models()
	{
		return test3Models;
	}

	public void setTest3Models(Test3ModelList[] test3Models)
	{
		this.test3Models = test3Models;
	}
	}
}