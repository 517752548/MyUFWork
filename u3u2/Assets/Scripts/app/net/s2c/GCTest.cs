
using System;
namespace app.net
{
/**
 * 更新单个道具信息，客户端受到此消息就替换原来此位置的道具
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTest :BaseMessage
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
	/** 测试Test3Model信息 */
	private Test3ModelList[] test3Models;

	public GCTest ()
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


	// 测试Test3Model信息
	int test3ModelsSize = ReadShort();
	Test3ModelList[] _test3Models = new Test3ModelList[test3ModelsSize];
	int test3ModelsIndex = 0;
	Test3ModelList _test3ModelsTmp = null;
	for(test3ModelsIndex=0; test3ModelsIndex<test3ModelsSize; test3ModelsIndex++){
		_test3ModelsTmp = new Test3ModelList();
		_test3Models[test3ModelsIndex] = _test3ModelsTmp;
	// 测试Long型
	long _test3Models_testLong = ReadLong();	_test3ModelsTmp.testLong = _test3Models_testLong;
		// 测试Integer型
	int _test3Models_testInteger = ReadInt();	_test3ModelsTmp.testInteger = _test3Models_testInteger;
		// 测试Short型
	short _test3Models_testShort = ReadShort();	_test3ModelsTmp.testShort = _test3Models_testShort;
		// 测试Byte型
	byte _test3Models_testByte = ReadByte();	_test3ModelsTmp.testByte = _test3Models_testByte;
		// 测试Boolean型
	bool _test3Models_testBoolean = ReadBool();	_test3ModelsTmp.testBoolean = _test3Models_testBoolean;
		// 测试String型
	string _test3Models_testString = ReadString();	_test3ModelsTmp.testString = _test3Models_testString;
		// 测试Long型
	int test3Models_testLongsSize = ReadShort();
	long[] _test3Models_testLongs = new long[test3Models_testLongsSize];
	int test3Models_testLongsIndex = 0;
	for(test3Models_testLongsIndex=0; test3Models_testLongsIndex<test3Models_testLongsSize; test3Models_testLongsIndex++){
		_test3Models_testLongs[test3Models_testLongsIndex] = ReadLong();
	}//end
		_test3ModelsTmp.testLongs = _test3Models_testLongs;
		// 测试Integer型
	int test3Models_testIntegersSize = ReadShort();
	int[] _test3Models_testIntegers = new int[test3Models_testIntegersSize];
	int test3Models_testIntegersIndex = 0;
	for(test3Models_testIntegersIndex=0; test3Models_testIntegersIndex<test3Models_testIntegersSize; test3Models_testIntegersIndex++){
		_test3Models_testIntegers[test3Models_testIntegersIndex] = ReadInt();
	}//end
		_test3ModelsTmp.testIntegers = _test3Models_testIntegers;
		// 测试Short型
	int test3Models_testShortsSize = ReadShort();
	short[] _test3Models_testShorts = new short[test3Models_testShortsSize];
	int test3Models_testShortsIndex = 0;
	for(test3Models_testShortsIndex=0; test3Models_testShortsIndex<test3Models_testShortsSize; test3Models_testShortsIndex++){
		_test3Models_testShorts[test3Models_testShortsIndex] = ReadShort();
	}//end
		_test3ModelsTmp.testShorts = _test3Models_testShorts;
		// 测试Byte型
	int test3Models_testBytesSize = ReadShort();
	byte[] _test3Models_testBytes = new byte[test3Models_testBytesSize];
	int test3Models_testBytesIndex = 0;
	for(test3Models_testBytesIndex=0; test3Models_testBytesIndex<test3Models_testBytesSize; test3Models_testBytesIndex++){
		_test3Models_testBytes[test3Models_testBytesIndex] = ReadByte();
	}//end
		_test3ModelsTmp.testBytes = _test3Models_testBytes;
		// 测试Boolean型
	int test3Models_testBooleansSize = ReadShort();
	bool[] _test3Models_testBooleans = new bool[test3Models_testBooleansSize];
	int test3Models_testBooleansIndex = 0;
	for(test3Models_testBooleansIndex=0; test3Models_testBooleansIndex<test3Models_testBooleansSize; test3Models_testBooleansIndex++){
		_test3Models_testBooleans[test3Models_testBooleansIndex] = ReadBool();
	}//end
		_test3ModelsTmp.testBooleans = _test3Models_testBooleans;
		// 测试String型
	int test3Models_testStringsSize = ReadShort();
	string[] _test3Models_testStrings = new string[test3Models_testStringsSize];
	int test3Models_testStringsIndex = 0;
	for(test3Models_testStringsIndex=0; test3Models_testStringsIndex<test3Models_testStringsSize; test3Models_testStringsIndex++){
		_test3Models_testStrings[test3Models_testStringsIndex] = ReadString();
	}//end
		_test3ModelsTmp.testStrings = _test3Models_testStrings;
	
	// 测试Test2Model信息
	int test3Models_test2ModelsSize = ReadShort();
	Test2Model[] _test3Models_test2Models = new Test2Model[test3Models_test2ModelsSize];
	int test3Models_test2ModelsIndex = 0;
	Test2Model _test3Models_test2ModelsTmp = null;
	for(test3Models_test2ModelsIndex=0; test3Models_test2ModelsIndex<test3Models_test2ModelsSize; test3Models_test2ModelsIndex++){
		_test3Models_test2ModelsTmp = new Test2Model();
		_test3Models_test2Models[test3Models_test2ModelsIndex] = _test3Models_test2ModelsTmp;
	// 测试Long型
	long _test3Models_test2Models_testLong = ReadLong();	_test3Models_test2ModelsTmp.testLong = _test3Models_test2Models_testLong;
		// 测试Integer型
	int _test3Models_test2Models_testInteger = ReadInt();	_test3Models_test2ModelsTmp.testInteger = _test3Models_test2Models_testInteger;
		// 测试Short型
	short _test3Models_test2Models_testShort = ReadShort();	_test3Models_test2ModelsTmp.testShort = _test3Models_test2Models_testShort;
		// 测试Byte型
	byte _test3Models_test2Models_testByte = ReadByte();	_test3Models_test2ModelsTmp.testByte = _test3Models_test2Models_testByte;
		// 测试Boolean型
	bool _test3Models_test2Models_testBoolean = ReadBool();	_test3Models_test2ModelsTmp.testBoolean = _test3Models_test2Models_testBoolean;
		// 测试String型
	string _test3Models_test2Models_testString = ReadString();	_test3Models_test2ModelsTmp.testString = _test3Models_test2Models_testString;
		// 测试Long型
	int test3Models_test2Models_testLongsSize = ReadShort();
	long[] _test3Models_test2Models_testLongs = new long[test3Models_test2Models_testLongsSize];
	int test3Models_test2Models_testLongsIndex = 0;
	for(test3Models_test2Models_testLongsIndex=0; test3Models_test2Models_testLongsIndex<test3Models_test2Models_testLongsSize; test3Models_test2Models_testLongsIndex++){
		_test3Models_test2Models_testLongs[test3Models_test2Models_testLongsIndex] = ReadLong();
	}//end
		_test3Models_test2ModelsTmp.testLongs = _test3Models_test2Models_testLongs;
		// 测试Integer型
	int test3Models_test2Models_testIntegersSize = ReadShort();
	int[] _test3Models_test2Models_testIntegers = new int[test3Models_test2Models_testIntegersSize];
	int test3Models_test2Models_testIntegersIndex = 0;
	for(test3Models_test2Models_testIntegersIndex=0; test3Models_test2Models_testIntegersIndex<test3Models_test2Models_testIntegersSize; test3Models_test2Models_testIntegersIndex++){
		_test3Models_test2Models_testIntegers[test3Models_test2Models_testIntegersIndex] = ReadInt();
	}//end
		_test3Models_test2ModelsTmp.testIntegers = _test3Models_test2Models_testIntegers;
		// 测试Short型
	int test3Models_test2Models_testShortsSize = ReadShort();
	short[] _test3Models_test2Models_testShorts = new short[test3Models_test2Models_testShortsSize];
	int test3Models_test2Models_testShortsIndex = 0;
	for(test3Models_test2Models_testShortsIndex=0; test3Models_test2Models_testShortsIndex<test3Models_test2Models_testShortsSize; test3Models_test2Models_testShortsIndex++){
		_test3Models_test2Models_testShorts[test3Models_test2Models_testShortsIndex] = ReadShort();
	}//end
		_test3Models_test2ModelsTmp.testShorts = _test3Models_test2Models_testShorts;
		// 测试Byte型
	int test3Models_test2Models_testBytesSize = ReadShort();
	byte[] _test3Models_test2Models_testBytes = new byte[test3Models_test2Models_testBytesSize];
	int test3Models_test2Models_testBytesIndex = 0;
	for(test3Models_test2Models_testBytesIndex=0; test3Models_test2Models_testBytesIndex<test3Models_test2Models_testBytesSize; test3Models_test2Models_testBytesIndex++){
		_test3Models_test2Models_testBytes[test3Models_test2Models_testBytesIndex] = ReadByte();
	}//end
		_test3Models_test2ModelsTmp.testBytes = _test3Models_test2Models_testBytes;
		// 测试Boolean型
	int test3Models_test2Models_testBooleansSize = ReadShort();
	bool[] _test3Models_test2Models_testBooleans = new bool[test3Models_test2Models_testBooleansSize];
	int test3Models_test2Models_testBooleansIndex = 0;
	for(test3Models_test2Models_testBooleansIndex=0; test3Models_test2Models_testBooleansIndex<test3Models_test2Models_testBooleansSize; test3Models_test2Models_testBooleansIndex++){
		_test3Models_test2Models_testBooleans[test3Models_test2Models_testBooleansIndex] = ReadBool();
	}//end
		_test3Models_test2ModelsTmp.testBooleans = _test3Models_test2Models_testBooleans;
		// 测试String型
	int test3Models_test2Models_testStringsSize = ReadShort();
	string[] _test3Models_test2Models_testStrings = new string[test3Models_test2Models_testStringsSize];
	int test3Models_test2Models_testStringsIndex = 0;
	for(test3Models_test2Models_testStringsIndex=0; test3Models_test2Models_testStringsIndex<test3Models_test2Models_testStringsSize; test3Models_test2Models_testStringsIndex++){
		_test3Models_test2Models_testStrings[test3Models_test2Models_testStringsIndex] = ReadString();
	}//end
		_test3Models_test2ModelsTmp.testStrings = _test3Models_test2Models_testStrings;
	
	// 测试test1Model信息
	int test3Models_test2Models_test1ModelSize = ReadShort();
	Test1Model[] _test3Models_test2Models_test1Model = new Test1Model[test3Models_test2Models_test1ModelSize];
	int test3Models_test2Models_test1ModelIndex = 0;
	Test1Model _test3Models_test2Models_test1ModelTmp = null;
	for(test3Models_test2Models_test1ModelIndex=0; test3Models_test2Models_test1ModelIndex<test3Models_test2Models_test1ModelSize; test3Models_test2Models_test1ModelIndex++){
		_test3Models_test2Models_test1ModelTmp = new Test1Model();
		_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex] = _test3Models_test2Models_test1ModelTmp;
	// 测试Long型
	long _test3Models_test2Models_test1Model_testLong = ReadLong();	_test3Models_test2Models_test1ModelTmp.testLong = _test3Models_test2Models_test1Model_testLong;
		// 测试Integer型
	int _test3Models_test2Models_test1Model_testInteger = ReadInt();	_test3Models_test2Models_test1ModelTmp.testInteger = _test3Models_test2Models_test1Model_testInteger;
		// 测试Short型
	short _test3Models_test2Models_test1Model_testShort = ReadShort();	_test3Models_test2Models_test1ModelTmp.testShort = _test3Models_test2Models_test1Model_testShort;
		// 测试Byte型
	byte _test3Models_test2Models_test1Model_testByte = ReadByte();	_test3Models_test2Models_test1ModelTmp.testByte = _test3Models_test2Models_test1Model_testByte;
		// 测试Boolean型
	bool _test3Models_test2Models_test1Model_testBoolean = ReadBool();	_test3Models_test2Models_test1ModelTmp.testBoolean = _test3Models_test2Models_test1Model_testBoolean;
		// 测试String型
	string _test3Models_test2Models_test1Model_testString = ReadString();	_test3Models_test2Models_test1ModelTmp.testString = _test3Models_test2Models_test1Model_testString;
		// 测试Long型
	int test3Models_test2Models_test1Model_testLongsSize = ReadShort();
	long[] _test3Models_test2Models_test1Model_testLongs = new long[test3Models_test2Models_test1Model_testLongsSize];
	int test3Models_test2Models_test1Model_testLongsIndex = 0;
	for(test3Models_test2Models_test1Model_testLongsIndex=0; test3Models_test2Models_test1Model_testLongsIndex<test3Models_test2Models_test1Model_testLongsSize; test3Models_test2Models_test1Model_testLongsIndex++){
		_test3Models_test2Models_test1Model_testLongs[test3Models_test2Models_test1Model_testLongsIndex] = ReadLong();
	}//end
		_test3Models_test2Models_test1ModelTmp.testLongs = _test3Models_test2Models_test1Model_testLongs;
		// 测试Integer型
	int test3Models_test2Models_test1Model_testIntegersSize = ReadShort();
	int[] _test3Models_test2Models_test1Model_testIntegers = new int[test3Models_test2Models_test1Model_testIntegersSize];
	int test3Models_test2Models_test1Model_testIntegersIndex = 0;
	for(test3Models_test2Models_test1Model_testIntegersIndex=0; test3Models_test2Models_test1Model_testIntegersIndex<test3Models_test2Models_test1Model_testIntegersSize; test3Models_test2Models_test1Model_testIntegersIndex++){
		_test3Models_test2Models_test1Model_testIntegers[test3Models_test2Models_test1Model_testIntegersIndex] = ReadInt();
	}//end
		_test3Models_test2Models_test1ModelTmp.testIntegers = _test3Models_test2Models_test1Model_testIntegers;
		// 测试Short型
	int test3Models_test2Models_test1Model_testShortsSize = ReadShort();
	short[] _test3Models_test2Models_test1Model_testShorts = new short[test3Models_test2Models_test1Model_testShortsSize];
	int test3Models_test2Models_test1Model_testShortsIndex = 0;
	for(test3Models_test2Models_test1Model_testShortsIndex=0; test3Models_test2Models_test1Model_testShortsIndex<test3Models_test2Models_test1Model_testShortsSize; test3Models_test2Models_test1Model_testShortsIndex++){
		_test3Models_test2Models_test1Model_testShorts[test3Models_test2Models_test1Model_testShortsIndex] = ReadShort();
	}//end
		_test3Models_test2Models_test1ModelTmp.testShorts = _test3Models_test2Models_test1Model_testShorts;
		// 测试Byte型
	int test3Models_test2Models_test1Model_testBytesSize = ReadShort();
	byte[] _test3Models_test2Models_test1Model_testBytes = new byte[test3Models_test2Models_test1Model_testBytesSize];
	int test3Models_test2Models_test1Model_testBytesIndex = 0;
	for(test3Models_test2Models_test1Model_testBytesIndex=0; test3Models_test2Models_test1Model_testBytesIndex<test3Models_test2Models_test1Model_testBytesSize; test3Models_test2Models_test1Model_testBytesIndex++){
		_test3Models_test2Models_test1Model_testBytes[test3Models_test2Models_test1Model_testBytesIndex] = ReadByte();
	}//end
		_test3Models_test2Models_test1ModelTmp.testBytes = _test3Models_test2Models_test1Model_testBytes;
		// 测试Boolean型
	int test3Models_test2Models_test1Model_testBooleansSize = ReadShort();
	bool[] _test3Models_test2Models_test1Model_testBooleans = new bool[test3Models_test2Models_test1Model_testBooleansSize];
	int test3Models_test2Models_test1Model_testBooleansIndex = 0;
	for(test3Models_test2Models_test1Model_testBooleansIndex=0; test3Models_test2Models_test1Model_testBooleansIndex<test3Models_test2Models_test1Model_testBooleansSize; test3Models_test2Models_test1Model_testBooleansIndex++){
		_test3Models_test2Models_test1Model_testBooleans[test3Models_test2Models_test1Model_testBooleansIndex] = ReadBool();
	}//end
		_test3Models_test2Models_test1ModelTmp.testBooleans = _test3Models_test2Models_test1Model_testBooleans;
		// 测试String型
	int test3Models_test2Models_test1Model_testStringsSize = ReadShort();
	string[] _test3Models_test2Models_test1Model_testStrings = new string[test3Models_test2Models_test1Model_testStringsSize];
	int test3Models_test2Models_test1Model_testStringsIndex = 0;
	for(test3Models_test2Models_test1Model_testStringsIndex=0; test3Models_test2Models_test1Model_testStringsIndex<test3Models_test2Models_test1Model_testStringsSize; test3Models_test2Models_test1Model_testStringsIndex++){
		_test3Models_test2Models_test1Model_testStrings[test3Models_test2Models_test1Model_testStringsIndex] = ReadString();
	}//end
		_test3Models_test2Models_test1ModelTmp.testStrings = _test3Models_test2Models_test1Model_testStrings;
		}
	//end
	_test3Models_test2ModelsTmp.test1Model = _test3Models_test2Models_test1Model;
		}
	//end
	_test3ModelsTmp.test2Models = _test3Models_test2Models;
		// 单个测试信息
	Test2Model _test3Models_test2Model = new Test2Model();
	// 测试Long型
	long _test3Models_test2Model_testLong = ReadLong();	_test3Models_test2Model.testLong = _test3Models_test2Model_testLong;
	// 测试Integer型
	int _test3Models_test2Model_testInteger = ReadInt();	_test3Models_test2Model.testInteger = _test3Models_test2Model_testInteger;
	// 测试Short型
	short _test3Models_test2Model_testShort = ReadShort();	_test3Models_test2Model.testShort = _test3Models_test2Model_testShort;
	// 测试Byte型
	byte _test3Models_test2Model_testByte = ReadByte();	_test3Models_test2Model.testByte = _test3Models_test2Model_testByte;
	// 测试Boolean型
	bool _test3Models_test2Model_testBoolean = ReadBool();	_test3Models_test2Model.testBoolean = _test3Models_test2Model_testBoolean;
	// 测试String型
	string _test3Models_test2Model_testString = ReadString();	_test3Models_test2Model.testString = _test3Models_test2Model_testString;
	// 测试Long型
	int test3Models_test2Model_testLongsSize = ReadShort();
	long[] _test3Models_test2Model_testLongs = new long[test3Models_test2Model_testLongsSize];
	int test3Models_test2Model_testLongsIndex = 0;
	for(test3Models_test2Model_testLongsIndex=0; test3Models_test2Model_testLongsIndex<test3Models_test2Model_testLongsSize; test3Models_test2Model_testLongsIndex++){
		_test3Models_test2Model_testLongs[test3Models_test2Model_testLongsIndex] = ReadLong();
	}//end
		_test3Models_test2Model.testLongs = _test3Models_test2Model_testLongs;
	// 测试Integer型
	int test3Models_test2Model_testIntegersSize = ReadShort();
	int[] _test3Models_test2Model_testIntegers = new int[test3Models_test2Model_testIntegersSize];
	int test3Models_test2Model_testIntegersIndex = 0;
	for(test3Models_test2Model_testIntegersIndex=0; test3Models_test2Model_testIntegersIndex<test3Models_test2Model_testIntegersSize; test3Models_test2Model_testIntegersIndex++){
		_test3Models_test2Model_testIntegers[test3Models_test2Model_testIntegersIndex] = ReadInt();
	}//end
		_test3Models_test2Model.testIntegers = _test3Models_test2Model_testIntegers;
	// 测试Short型
	int test3Models_test2Model_testShortsSize = ReadShort();
	short[] _test3Models_test2Model_testShorts = new short[test3Models_test2Model_testShortsSize];
	int test3Models_test2Model_testShortsIndex = 0;
	for(test3Models_test2Model_testShortsIndex=0; test3Models_test2Model_testShortsIndex<test3Models_test2Model_testShortsSize; test3Models_test2Model_testShortsIndex++){
		_test3Models_test2Model_testShorts[test3Models_test2Model_testShortsIndex] = ReadShort();
	}//end
		_test3Models_test2Model.testShorts = _test3Models_test2Model_testShorts;
	// 测试Byte型
	int test3Models_test2Model_testBytesSize = ReadShort();
	byte[] _test3Models_test2Model_testBytes = new byte[test3Models_test2Model_testBytesSize];
	int test3Models_test2Model_testBytesIndex = 0;
	for(test3Models_test2Model_testBytesIndex=0; test3Models_test2Model_testBytesIndex<test3Models_test2Model_testBytesSize; test3Models_test2Model_testBytesIndex++){
		_test3Models_test2Model_testBytes[test3Models_test2Model_testBytesIndex] = ReadByte();
	}//end
		_test3Models_test2Model.testBytes = _test3Models_test2Model_testBytes;
	// 测试Boolean型
	int test3Models_test2Model_testBooleansSize = ReadShort();
	bool[] _test3Models_test2Model_testBooleans = new bool[test3Models_test2Model_testBooleansSize];
	int test3Models_test2Model_testBooleansIndex = 0;
	for(test3Models_test2Model_testBooleansIndex=0; test3Models_test2Model_testBooleansIndex<test3Models_test2Model_testBooleansSize; test3Models_test2Model_testBooleansIndex++){
		_test3Models_test2Model_testBooleans[test3Models_test2Model_testBooleansIndex] = ReadBool();
	}//end
		_test3Models_test2Model.testBooleans = _test3Models_test2Model_testBooleans;
	// 测试String型
	int test3Models_test2Model_testStringsSize = ReadShort();
	string[] _test3Models_test2Model_testStrings = new string[test3Models_test2Model_testStringsSize];
	int test3Models_test2Model_testStringsIndex = 0;
	for(test3Models_test2Model_testStringsIndex=0; test3Models_test2Model_testStringsIndex<test3Models_test2Model_testStringsSize; test3Models_test2Model_testStringsIndex++){
		_test3Models_test2Model_testStrings[test3Models_test2Model_testStringsIndex] = ReadString();
	}//end
		_test3Models_test2Model.testStrings = _test3Models_test2Model_testStrings;

	// 测试test1Model信息
	int test3Models_test2Model_test1ModelSize = ReadShort();
	Test1Model[] _test3Models_test2Model_test1Model = new Test1Model[test3Models_test2Model_test1ModelSize];
	int test3Models_test2Model_test1ModelIndex = 0;
	Test1Model _test3Models_test2Model_test1ModelTmp = null;
	for(test3Models_test2Model_test1ModelIndex=0; test3Models_test2Model_test1ModelIndex<test3Models_test2Model_test1ModelSize; test3Models_test2Model_test1ModelIndex++){
		_test3Models_test2Model_test1ModelTmp = new Test1Model();
		_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex] = _test3Models_test2Model_test1ModelTmp;
	// 测试Long型
	long _test3Models_test2Model_test1Model_testLong = ReadLong();	_test3Models_test2Model_test1ModelTmp.testLong = _test3Models_test2Model_test1Model_testLong;
		// 测试Integer型
	int _test3Models_test2Model_test1Model_testInteger = ReadInt();	_test3Models_test2Model_test1ModelTmp.testInteger = _test3Models_test2Model_test1Model_testInteger;
		// 测试Short型
	short _test3Models_test2Model_test1Model_testShort = ReadShort();	_test3Models_test2Model_test1ModelTmp.testShort = _test3Models_test2Model_test1Model_testShort;
		// 测试Byte型
	byte _test3Models_test2Model_test1Model_testByte = ReadByte();	_test3Models_test2Model_test1ModelTmp.testByte = _test3Models_test2Model_test1Model_testByte;
		// 测试Boolean型
	bool _test3Models_test2Model_test1Model_testBoolean = ReadBool();	_test3Models_test2Model_test1ModelTmp.testBoolean = _test3Models_test2Model_test1Model_testBoolean;
		// 测试String型
	string _test3Models_test2Model_test1Model_testString = ReadString();	_test3Models_test2Model_test1ModelTmp.testString = _test3Models_test2Model_test1Model_testString;
		// 测试Long型
	int test3Models_test2Model_test1Model_testLongsSize = ReadShort();
	long[] _test3Models_test2Model_test1Model_testLongs = new long[test3Models_test2Model_test1Model_testLongsSize];
	int test3Models_test2Model_test1Model_testLongsIndex = 0;
	for(test3Models_test2Model_test1Model_testLongsIndex=0; test3Models_test2Model_test1Model_testLongsIndex<test3Models_test2Model_test1Model_testLongsSize; test3Models_test2Model_test1Model_testLongsIndex++){
		_test3Models_test2Model_test1Model_testLongs[test3Models_test2Model_test1Model_testLongsIndex] = ReadLong();
	}//end
		_test3Models_test2Model_test1ModelTmp.testLongs = _test3Models_test2Model_test1Model_testLongs;
		// 测试Integer型
	int test3Models_test2Model_test1Model_testIntegersSize = ReadShort();
	int[] _test3Models_test2Model_test1Model_testIntegers = new int[test3Models_test2Model_test1Model_testIntegersSize];
	int test3Models_test2Model_test1Model_testIntegersIndex = 0;
	for(test3Models_test2Model_test1Model_testIntegersIndex=0; test3Models_test2Model_test1Model_testIntegersIndex<test3Models_test2Model_test1Model_testIntegersSize; test3Models_test2Model_test1Model_testIntegersIndex++){
		_test3Models_test2Model_test1Model_testIntegers[test3Models_test2Model_test1Model_testIntegersIndex] = ReadInt();
	}//end
		_test3Models_test2Model_test1ModelTmp.testIntegers = _test3Models_test2Model_test1Model_testIntegers;
		// 测试Short型
	int test3Models_test2Model_test1Model_testShortsSize = ReadShort();
	short[] _test3Models_test2Model_test1Model_testShorts = new short[test3Models_test2Model_test1Model_testShortsSize];
	int test3Models_test2Model_test1Model_testShortsIndex = 0;
	for(test3Models_test2Model_test1Model_testShortsIndex=0; test3Models_test2Model_test1Model_testShortsIndex<test3Models_test2Model_test1Model_testShortsSize; test3Models_test2Model_test1Model_testShortsIndex++){
		_test3Models_test2Model_test1Model_testShorts[test3Models_test2Model_test1Model_testShortsIndex] = ReadShort();
	}//end
		_test3Models_test2Model_test1ModelTmp.testShorts = _test3Models_test2Model_test1Model_testShorts;
		// 测试Byte型
	int test3Models_test2Model_test1Model_testBytesSize = ReadShort();
	byte[] _test3Models_test2Model_test1Model_testBytes = new byte[test3Models_test2Model_test1Model_testBytesSize];
	int test3Models_test2Model_test1Model_testBytesIndex = 0;
	for(test3Models_test2Model_test1Model_testBytesIndex=0; test3Models_test2Model_test1Model_testBytesIndex<test3Models_test2Model_test1Model_testBytesSize; test3Models_test2Model_test1Model_testBytesIndex++){
		_test3Models_test2Model_test1Model_testBytes[test3Models_test2Model_test1Model_testBytesIndex] = ReadByte();
	}//end
		_test3Models_test2Model_test1ModelTmp.testBytes = _test3Models_test2Model_test1Model_testBytes;
		// 测试Boolean型
	int test3Models_test2Model_test1Model_testBooleansSize = ReadShort();
	bool[] _test3Models_test2Model_test1Model_testBooleans = new bool[test3Models_test2Model_test1Model_testBooleansSize];
	int test3Models_test2Model_test1Model_testBooleansIndex = 0;
	for(test3Models_test2Model_test1Model_testBooleansIndex=0; test3Models_test2Model_test1Model_testBooleansIndex<test3Models_test2Model_test1Model_testBooleansSize; test3Models_test2Model_test1Model_testBooleansIndex++){
		_test3Models_test2Model_test1Model_testBooleans[test3Models_test2Model_test1Model_testBooleansIndex] = ReadBool();
	}//end
		_test3Models_test2Model_test1ModelTmp.testBooleans = _test3Models_test2Model_test1Model_testBooleans;
		// 测试String型
	int test3Models_test2Model_test1Model_testStringsSize = ReadShort();
	string[] _test3Models_test2Model_test1Model_testStrings = new string[test3Models_test2Model_test1Model_testStringsSize];
	int test3Models_test2Model_test1Model_testStringsIndex = 0;
	for(test3Models_test2Model_test1Model_testStringsIndex=0; test3Models_test2Model_test1Model_testStringsIndex<test3Models_test2Model_test1Model_testStringsSize; test3Models_test2Model_test1Model_testStringsIndex++){
		_test3Models_test2Model_test1Model_testStrings[test3Models_test2Model_test1Model_testStringsIndex] = ReadString();
	}//end
		_test3Models_test2Model_test1ModelTmp.testStrings = _test3Models_test2Model_test1Model_testStrings;
		}
	//end
	_test3Models_test2Model.test1Model = _test3Models_test2Model_test1Model;
	_test3ModelsTmp.test2Model = _test3Models_test2Model;
		}
	//end



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
		this.test3Models = _test3Models;
	}
	
	protected override void WriteImpl()
    {
        return;
    }
	
	public override short GetMessageType() 
	{
		return (short)MessageType.GC_TEST;
	}
	
	public override string getEventType()
	{
		return TestGCHandler.GCTestEvent;
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
		

	public Test3ModelList[] getTest3Models(){
		return test3Models;
	}


}
}