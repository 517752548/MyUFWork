package com.imop.lj.gameserver.test.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.test.handler.TestHandlerFactory;

/**
 * 更新单个道具信息，客户端受到此消息就替换原来此位置的道具
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTest extends CGMessage{
	
	/** 测试Long型 */
	private long testLong;
	/** 测试Integer型 */
	private int testInteger;
	/** 测试Short型 */
	private short testShort;
	/** 测试Byte型 */
	private byte testByte;
	/** 测试Boolean型 */
	private boolean testBoolean;
	/** 测试String型 */
	private String testString;
	/** 测试Long型 */
	private long[] testLongs;
	/** 测试Integer型 */
	private int[] testIntegers;
	/** 测试Short型 */
	private short[] testShorts;
	/** 测试Byte型 */
	private byte[] testBytes;
	/** 测试Boolean型 */
	private boolean[] testBooleans;
	/** 测试String型 */
	private String[] testStrings;
	/** 单个测试信息 */
	private com.imop.lj.gameserver.test.model.Test1Model test1Model;
	/** 单个测试信息 */
	private com.imop.lj.gameserver.test.model.Test3Model[] test3Models;
	
	public CGTest (){
	}
	
	public CGTest (
			long testLong,
			int testInteger,
			short testShort,
			byte testByte,
			boolean testBoolean,
			String testString,
			long[] testLongs,
			int[] testIntegers,
			short[] testShorts,
			byte[] testBytes,
			boolean[] testBooleans,
			String[] testStrings,
			com.imop.lj.gameserver.test.model.Test1Model test1Model,
			com.imop.lj.gameserver.test.model.Test3Model[] test3Models ){
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
	
	@Override
	protected boolean readImpl() {

	// 测试Long型
	long _testLong = readLong();
	//end


	// 测试Integer型
	int _testInteger = readInteger();
	//end


	// 测试Short型
	short _testShort = readShort();
	//end


	// 测试Byte型
	byte _testByte = readByte();
	//end


	// 测试Boolean型
	boolean _testBoolean = readBoolean();
	//end


	// 测试String型
	String _testString = readString();
	//end


	// 测试Long型
	int testLongsSize = readUnsignedShort();
	long[] _testLongs = new long[testLongsSize];
	int testLongsIndex = 0;
	for(testLongsIndex=0; testLongsIndex<testLongsSize; testLongsIndex++){
		_testLongs[testLongsIndex] = readLong();
	}//end


	// 测试Integer型
	int testIntegersSize = readUnsignedShort();
	int[] _testIntegers = new int[testIntegersSize];
	int testIntegersIndex = 0;
	for(testIntegersIndex=0; testIntegersIndex<testIntegersSize; testIntegersIndex++){
		_testIntegers[testIntegersIndex] = readInteger();
	}//end


	// 测试Short型
	int testShortsSize = readUnsignedShort();
	short[] _testShorts = new short[testShortsSize];
	int testShortsIndex = 0;
	for(testShortsIndex=0; testShortsIndex<testShortsSize; testShortsIndex++){
		_testShorts[testShortsIndex] = readShort();
	}//end


	// 测试Byte型
	int testBytesSize = readUnsignedShort();
	byte[] _testBytes = new byte[testBytesSize];
	int testBytesIndex = 0;
	for(testBytesIndex=0; testBytesIndex<testBytesSize; testBytesIndex++){
		_testBytes[testBytesIndex] = readByte();
	}//end


	// 测试Boolean型
	int testBooleansSize = readUnsignedShort();
	boolean[] _testBooleans = new boolean[testBooleansSize];
	int testBooleansIndex = 0;
	for(testBooleansIndex=0; testBooleansIndex<testBooleansSize; testBooleansIndex++){
		_testBooleans[testBooleansIndex] = readBoolean();
	}//end


	// 测试String型
	int testStringsSize = readUnsignedShort();
	String[] _testStrings = new String[testStringsSize];
	int testStringsIndex = 0;
	for(testStringsIndex=0; testStringsIndex<testStringsSize; testStringsIndex++){
		_testStrings[testStringsIndex] = readString();
	}//end

	// 单个测试信息
	com.imop.lj.gameserver.test.model.Test1Model _test1Model = new com.imop.lj.gameserver.test.model.Test1Model();

	// 测试Long型
	long _test1Model_testLong = readLong();
	//end
	_test1Model.setTestLong (_test1Model_testLong);

	// 测试Integer型
	int _test1Model_testInteger = readInteger();
	//end
	_test1Model.setTestInteger (_test1Model_testInteger);

	// 测试Short型
	short _test1Model_testShort = readShort();
	//end
	_test1Model.setTestShort (_test1Model_testShort);

	// 测试Byte型
	byte _test1Model_testByte = readByte();
	//end
	_test1Model.setTestByte (_test1Model_testByte);

	// 测试Boolean型
	boolean _test1Model_testBoolean = readBoolean();
	//end
	_test1Model.setTestBoolean (_test1Model_testBoolean);

	// 测试String型
	String _test1Model_testString = readString();
	//end
	_test1Model.setTestString (_test1Model_testString);

	// 测试Long型
	int test1Model_testLongsSize = readUnsignedShort();
	long[] _test1Model_testLongs = new long[test1Model_testLongsSize];
	int test1Model_testLongsIndex = 0;
	for(test1Model_testLongsIndex=0; test1Model_testLongsIndex<test1Model_testLongsSize; test1Model_testLongsIndex++){
		_test1Model_testLongs[test1Model_testLongsIndex] = readLong();
	}//end
	_test1Model.setTestLongs (_test1Model_testLongs);

	// 测试Integer型
	int test1Model_testIntegersSize = readUnsignedShort();
	int[] _test1Model_testIntegers = new int[test1Model_testIntegersSize];
	int test1Model_testIntegersIndex = 0;
	for(test1Model_testIntegersIndex=0; test1Model_testIntegersIndex<test1Model_testIntegersSize; test1Model_testIntegersIndex++){
		_test1Model_testIntegers[test1Model_testIntegersIndex] = readInteger();
	}//end
	_test1Model.setTestIntegers (_test1Model_testIntegers);

	// 测试Short型
	int test1Model_testShortsSize = readUnsignedShort();
	short[] _test1Model_testShorts = new short[test1Model_testShortsSize];
	int test1Model_testShortsIndex = 0;
	for(test1Model_testShortsIndex=0; test1Model_testShortsIndex<test1Model_testShortsSize; test1Model_testShortsIndex++){
		_test1Model_testShorts[test1Model_testShortsIndex] = readShort();
	}//end
	_test1Model.setTestShorts (_test1Model_testShorts);

	// 测试Byte型
	int test1Model_testBytesSize = readUnsignedShort();
	byte[] _test1Model_testBytes = new byte[test1Model_testBytesSize];
	int test1Model_testBytesIndex = 0;
	for(test1Model_testBytesIndex=0; test1Model_testBytesIndex<test1Model_testBytesSize; test1Model_testBytesIndex++){
		_test1Model_testBytes[test1Model_testBytesIndex] = readByte();
	}//end
	_test1Model.setTestBytes (_test1Model_testBytes);

	// 测试Boolean型
	int test1Model_testBooleansSize = readUnsignedShort();
	boolean[] _test1Model_testBooleans = new boolean[test1Model_testBooleansSize];
	int test1Model_testBooleansIndex = 0;
	for(test1Model_testBooleansIndex=0; test1Model_testBooleansIndex<test1Model_testBooleansSize; test1Model_testBooleansIndex++){
		_test1Model_testBooleans[test1Model_testBooleansIndex] = readBoolean();
	}//end
	_test1Model.setTestBooleans (_test1Model_testBooleans);

	// 测试String型
	int test1Model_testStringsSize = readUnsignedShort();
	String[] _test1Model_testStrings = new String[test1Model_testStringsSize];
	int test1Model_testStringsIndex = 0;
	for(test1Model_testStringsIndex=0; test1Model_testStringsIndex<test1Model_testStringsSize; test1Model_testStringsIndex++){
		_test1Model_testStrings[test1Model_testStringsIndex] = readString();
	}//end
	_test1Model.setTestStrings (_test1Model_testStrings);


	// 单个测试信息
	int test3ModelsSize = readUnsignedShort();
	com.imop.lj.gameserver.test.model.Test3Model[] _test3Models = new com.imop.lj.gameserver.test.model.Test3Model[test3ModelsSize];
	int test3ModelsIndex = 0;
	for(test3ModelsIndex=0; test3ModelsIndex<test3ModelsSize; test3ModelsIndex++){
		_test3Models[test3ModelsIndex] = new com.imop.lj.gameserver.test.model.Test3Model();
	// 测试Long型
	long _test3Models_testLong = readLong();
	//end
	_test3Models[test3ModelsIndex].setTestLong (_test3Models_testLong);

	// 测试Integer型
	int _test3Models_testInteger = readInteger();
	//end
	_test3Models[test3ModelsIndex].setTestInteger (_test3Models_testInteger);

	// 测试Short型
	short _test3Models_testShort = readShort();
	//end
	_test3Models[test3ModelsIndex].setTestShort (_test3Models_testShort);

	// 测试Byte型
	byte _test3Models_testByte = readByte();
	//end
	_test3Models[test3ModelsIndex].setTestByte (_test3Models_testByte);

	// 测试Boolean型
	boolean _test3Models_testBoolean = readBoolean();
	//end
	_test3Models[test3ModelsIndex].setTestBoolean (_test3Models_testBoolean);

	// 测试String型
	String _test3Models_testString = readString();
	//end
	_test3Models[test3ModelsIndex].setTestString (_test3Models_testString);

	// 测试Long型
	int test3Models_testLongsSize = readUnsignedShort();
	long[] _test3Models_testLongs = new long[test3Models_testLongsSize];
	int test3Models_testLongsIndex = 0;
	for(test3Models_testLongsIndex=0; test3Models_testLongsIndex<test3Models_testLongsSize; test3Models_testLongsIndex++){
		_test3Models_testLongs[test3Models_testLongsIndex] = readLong();
	}//end
	_test3Models[test3ModelsIndex].setTestLongs (_test3Models_testLongs);

	// 测试Integer型
	int test3Models_testIntegersSize = readUnsignedShort();
	int[] _test3Models_testIntegers = new int[test3Models_testIntegersSize];
	int test3Models_testIntegersIndex = 0;
	for(test3Models_testIntegersIndex=0; test3Models_testIntegersIndex<test3Models_testIntegersSize; test3Models_testIntegersIndex++){
		_test3Models_testIntegers[test3Models_testIntegersIndex] = readInteger();
	}//end
	_test3Models[test3ModelsIndex].setTestIntegers (_test3Models_testIntegers);

	// 测试Short型
	int test3Models_testShortsSize = readUnsignedShort();
	short[] _test3Models_testShorts = new short[test3Models_testShortsSize];
	int test3Models_testShortsIndex = 0;
	for(test3Models_testShortsIndex=0; test3Models_testShortsIndex<test3Models_testShortsSize; test3Models_testShortsIndex++){
		_test3Models_testShorts[test3Models_testShortsIndex] = readShort();
	}//end
	_test3Models[test3ModelsIndex].setTestShorts (_test3Models_testShorts);

	// 测试Byte型
	int test3Models_testBytesSize = readUnsignedShort();
	byte[] _test3Models_testBytes = new byte[test3Models_testBytesSize];
	int test3Models_testBytesIndex = 0;
	for(test3Models_testBytesIndex=0; test3Models_testBytesIndex<test3Models_testBytesSize; test3Models_testBytesIndex++){
		_test3Models_testBytes[test3Models_testBytesIndex] = readByte();
	}//end
	_test3Models[test3ModelsIndex].setTestBytes (_test3Models_testBytes);

	// 测试Boolean型
	int test3Models_testBooleansSize = readUnsignedShort();
	boolean[] _test3Models_testBooleans = new boolean[test3Models_testBooleansSize];
	int test3Models_testBooleansIndex = 0;
	for(test3Models_testBooleansIndex=0; test3Models_testBooleansIndex<test3Models_testBooleansSize; test3Models_testBooleansIndex++){
		_test3Models_testBooleans[test3Models_testBooleansIndex] = readBoolean();
	}//end
	_test3Models[test3ModelsIndex].setTestBooleans (_test3Models_testBooleans);

	// 测试String型
	int test3Models_testStringsSize = readUnsignedShort();
	String[] _test3Models_testStrings = new String[test3Models_testStringsSize];
	int test3Models_testStringsIndex = 0;
	for(test3Models_testStringsIndex=0; test3Models_testStringsIndex<test3Models_testStringsSize; test3Models_testStringsIndex++){
		_test3Models_testStrings[test3Models_testStringsIndex] = readString();
	}//end
	_test3Models[test3ModelsIndex].setTestStrings (_test3Models_testStrings);

	// 测试test2Models信息
	int test3Models_test2ModelsSize = readUnsignedShort();
	com.imop.lj.gameserver.test.model.Test2Model[] _test3Models_test2Models = new com.imop.lj.gameserver.test.model.Test2Model[test3Models_test2ModelsSize];
	int test3Models_test2ModelsIndex = 0;
	for(test3Models_test2ModelsIndex=0; test3Models_test2ModelsIndex<test3Models_test2ModelsSize; test3Models_test2ModelsIndex++){
		_test3Models_test2Models[test3Models_test2ModelsIndex] = new com.imop.lj.gameserver.test.model.Test2Model();
	// 测试Long型
	long _test3Models_test2Models_testLong = readLong();
	//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestLong (_test3Models_test2Models_testLong);

	// 测试Integer型
	int _test3Models_test2Models_testInteger = readInteger();
	//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestInteger (_test3Models_test2Models_testInteger);

	// 测试Short型
	short _test3Models_test2Models_testShort = readShort();
	//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestShort (_test3Models_test2Models_testShort);

	// 测试Byte型
	byte _test3Models_test2Models_testByte = readByte();
	//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestByte (_test3Models_test2Models_testByte);

	// 测试Boolean型
	boolean _test3Models_test2Models_testBoolean = readBoolean();
	//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestBoolean (_test3Models_test2Models_testBoolean);

	// 测试String型
	String _test3Models_test2Models_testString = readString();
	//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestString (_test3Models_test2Models_testString);

	// 测试Long型
	int test3Models_test2Models_testLongsSize = readUnsignedShort();
	long[] _test3Models_test2Models_testLongs = new long[test3Models_test2Models_testLongsSize];
	int test3Models_test2Models_testLongsIndex = 0;
	for(test3Models_test2Models_testLongsIndex=0; test3Models_test2Models_testLongsIndex<test3Models_test2Models_testLongsSize; test3Models_test2Models_testLongsIndex++){
		_test3Models_test2Models_testLongs[test3Models_test2Models_testLongsIndex] = readLong();
	}//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestLongs (_test3Models_test2Models_testLongs);

	// 测试Integer型
	int test3Models_test2Models_testIntegersSize = readUnsignedShort();
	int[] _test3Models_test2Models_testIntegers = new int[test3Models_test2Models_testIntegersSize];
	int test3Models_test2Models_testIntegersIndex = 0;
	for(test3Models_test2Models_testIntegersIndex=0; test3Models_test2Models_testIntegersIndex<test3Models_test2Models_testIntegersSize; test3Models_test2Models_testIntegersIndex++){
		_test3Models_test2Models_testIntegers[test3Models_test2Models_testIntegersIndex] = readInteger();
	}//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestIntegers (_test3Models_test2Models_testIntegers);

	// 测试Short型
	int test3Models_test2Models_testShortsSize = readUnsignedShort();
	short[] _test3Models_test2Models_testShorts = new short[test3Models_test2Models_testShortsSize];
	int test3Models_test2Models_testShortsIndex = 0;
	for(test3Models_test2Models_testShortsIndex=0; test3Models_test2Models_testShortsIndex<test3Models_test2Models_testShortsSize; test3Models_test2Models_testShortsIndex++){
		_test3Models_test2Models_testShorts[test3Models_test2Models_testShortsIndex] = readShort();
	}//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestShorts (_test3Models_test2Models_testShorts);

	// 测试Byte型
	int test3Models_test2Models_testBytesSize = readUnsignedShort();
	byte[] _test3Models_test2Models_testBytes = new byte[test3Models_test2Models_testBytesSize];
	int test3Models_test2Models_testBytesIndex = 0;
	for(test3Models_test2Models_testBytesIndex=0; test3Models_test2Models_testBytesIndex<test3Models_test2Models_testBytesSize; test3Models_test2Models_testBytesIndex++){
		_test3Models_test2Models_testBytes[test3Models_test2Models_testBytesIndex] = readByte();
	}//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestBytes (_test3Models_test2Models_testBytes);

	// 测试Boolean型
	int test3Models_test2Models_testBooleansSize = readUnsignedShort();
	boolean[] _test3Models_test2Models_testBooleans = new boolean[test3Models_test2Models_testBooleansSize];
	int test3Models_test2Models_testBooleansIndex = 0;
	for(test3Models_test2Models_testBooleansIndex=0; test3Models_test2Models_testBooleansIndex<test3Models_test2Models_testBooleansSize; test3Models_test2Models_testBooleansIndex++){
		_test3Models_test2Models_testBooleans[test3Models_test2Models_testBooleansIndex] = readBoolean();
	}//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestBooleans (_test3Models_test2Models_testBooleans);

	// 测试String型
	int test3Models_test2Models_testStringsSize = readUnsignedShort();
	String[] _test3Models_test2Models_testStrings = new String[test3Models_test2Models_testStringsSize];
	int test3Models_test2Models_testStringsIndex = 0;
	for(test3Models_test2Models_testStringsIndex=0; test3Models_test2Models_testStringsIndex<test3Models_test2Models_testStringsSize; test3Models_test2Models_testStringsIndex++){
		_test3Models_test2Models_testStrings[test3Models_test2Models_testStringsIndex] = readString();
	}//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTestStrings (_test3Models_test2Models_testStrings);

	// 测试test1Model信息
	int test3Models_test2Models_test1ModelSize = readUnsignedShort();
	com.imop.lj.gameserver.test.model.Test1Model[] _test3Models_test2Models_test1Model = new com.imop.lj.gameserver.test.model.Test1Model[test3Models_test2Models_test1ModelSize];
	int test3Models_test2Models_test1ModelIndex = 0;
	for(test3Models_test2Models_test1ModelIndex=0; test3Models_test2Models_test1ModelIndex<test3Models_test2Models_test1ModelSize; test3Models_test2Models_test1ModelIndex++){
		_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex] = new com.imop.lj.gameserver.test.model.Test1Model();
	// 测试Long型
	long _test3Models_test2Models_test1Model_testLong = readLong();
	//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestLong (_test3Models_test2Models_test1Model_testLong);

	// 测试Integer型
	int _test3Models_test2Models_test1Model_testInteger = readInteger();
	//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestInteger (_test3Models_test2Models_test1Model_testInteger);

	// 测试Short型
	short _test3Models_test2Models_test1Model_testShort = readShort();
	//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestShort (_test3Models_test2Models_test1Model_testShort);

	// 测试Byte型
	byte _test3Models_test2Models_test1Model_testByte = readByte();
	//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestByte (_test3Models_test2Models_test1Model_testByte);

	// 测试Boolean型
	boolean _test3Models_test2Models_test1Model_testBoolean = readBoolean();
	//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestBoolean (_test3Models_test2Models_test1Model_testBoolean);

	// 测试String型
	String _test3Models_test2Models_test1Model_testString = readString();
	//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestString (_test3Models_test2Models_test1Model_testString);

	// 测试Long型
	int test3Models_test2Models_test1Model_testLongsSize = readUnsignedShort();
	long[] _test3Models_test2Models_test1Model_testLongs = new long[test3Models_test2Models_test1Model_testLongsSize];
	int test3Models_test2Models_test1Model_testLongsIndex = 0;
	for(test3Models_test2Models_test1Model_testLongsIndex=0; test3Models_test2Models_test1Model_testLongsIndex<test3Models_test2Models_test1Model_testLongsSize; test3Models_test2Models_test1Model_testLongsIndex++){
		_test3Models_test2Models_test1Model_testLongs[test3Models_test2Models_test1Model_testLongsIndex] = readLong();
	}//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestLongs (_test3Models_test2Models_test1Model_testLongs);

	// 测试Integer型
	int test3Models_test2Models_test1Model_testIntegersSize = readUnsignedShort();
	int[] _test3Models_test2Models_test1Model_testIntegers = new int[test3Models_test2Models_test1Model_testIntegersSize];
	int test3Models_test2Models_test1Model_testIntegersIndex = 0;
	for(test3Models_test2Models_test1Model_testIntegersIndex=0; test3Models_test2Models_test1Model_testIntegersIndex<test3Models_test2Models_test1Model_testIntegersSize; test3Models_test2Models_test1Model_testIntegersIndex++){
		_test3Models_test2Models_test1Model_testIntegers[test3Models_test2Models_test1Model_testIntegersIndex] = readInteger();
	}//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestIntegers (_test3Models_test2Models_test1Model_testIntegers);

	// 测试Short型
	int test3Models_test2Models_test1Model_testShortsSize = readUnsignedShort();
	short[] _test3Models_test2Models_test1Model_testShorts = new short[test3Models_test2Models_test1Model_testShortsSize];
	int test3Models_test2Models_test1Model_testShortsIndex = 0;
	for(test3Models_test2Models_test1Model_testShortsIndex=0; test3Models_test2Models_test1Model_testShortsIndex<test3Models_test2Models_test1Model_testShortsSize; test3Models_test2Models_test1Model_testShortsIndex++){
		_test3Models_test2Models_test1Model_testShorts[test3Models_test2Models_test1Model_testShortsIndex] = readShort();
	}//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestShorts (_test3Models_test2Models_test1Model_testShorts);

	// 测试Byte型
	int test3Models_test2Models_test1Model_testBytesSize = readUnsignedShort();
	byte[] _test3Models_test2Models_test1Model_testBytes = new byte[test3Models_test2Models_test1Model_testBytesSize];
	int test3Models_test2Models_test1Model_testBytesIndex = 0;
	for(test3Models_test2Models_test1Model_testBytesIndex=0; test3Models_test2Models_test1Model_testBytesIndex<test3Models_test2Models_test1Model_testBytesSize; test3Models_test2Models_test1Model_testBytesIndex++){
		_test3Models_test2Models_test1Model_testBytes[test3Models_test2Models_test1Model_testBytesIndex] = readByte();
	}//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestBytes (_test3Models_test2Models_test1Model_testBytes);

	// 测试Boolean型
	int test3Models_test2Models_test1Model_testBooleansSize = readUnsignedShort();
	boolean[] _test3Models_test2Models_test1Model_testBooleans = new boolean[test3Models_test2Models_test1Model_testBooleansSize];
	int test3Models_test2Models_test1Model_testBooleansIndex = 0;
	for(test3Models_test2Models_test1Model_testBooleansIndex=0; test3Models_test2Models_test1Model_testBooleansIndex<test3Models_test2Models_test1Model_testBooleansSize; test3Models_test2Models_test1Model_testBooleansIndex++){
		_test3Models_test2Models_test1Model_testBooleans[test3Models_test2Models_test1Model_testBooleansIndex] = readBoolean();
	}//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestBooleans (_test3Models_test2Models_test1Model_testBooleans);

	// 测试String型
	int test3Models_test2Models_test1Model_testStringsSize = readUnsignedShort();
	String[] _test3Models_test2Models_test1Model_testStrings = new String[test3Models_test2Models_test1Model_testStringsSize];
	int test3Models_test2Models_test1Model_testStringsIndex = 0;
	for(test3Models_test2Models_test1Model_testStringsIndex=0; test3Models_test2Models_test1Model_testStringsIndex<test3Models_test2Models_test1Model_testStringsSize; test3Models_test2Models_test1Model_testStringsIndex++){
		_test3Models_test2Models_test1Model_testStrings[test3Models_test2Models_test1Model_testStringsIndex] = readString();
	}//end
	_test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].setTestStrings (_test3Models_test2Models_test1Model_testStrings);
	}
	//end
	_test3Models_test2Models[test3Models_test2ModelsIndex].setTest1Model (_test3Models_test2Models_test1Model);
	}
	//end
	_test3Models[test3ModelsIndex].setTest2Models (_test3Models_test2Models);
	// 测试test2Model信息
	com.imop.lj.gameserver.test.model.Test2Model _test3Models_test2Model = new com.imop.lj.gameserver.test.model.Test2Model();

	// 测试Long型
	long _test3Models_test2Model_testLong = readLong();
	//end
	_test3Models_test2Model.setTestLong (_test3Models_test2Model_testLong);

	// 测试Integer型
	int _test3Models_test2Model_testInteger = readInteger();
	//end
	_test3Models_test2Model.setTestInteger (_test3Models_test2Model_testInteger);

	// 测试Short型
	short _test3Models_test2Model_testShort = readShort();
	//end
	_test3Models_test2Model.setTestShort (_test3Models_test2Model_testShort);

	// 测试Byte型
	byte _test3Models_test2Model_testByte = readByte();
	//end
	_test3Models_test2Model.setTestByte (_test3Models_test2Model_testByte);

	// 测试Boolean型
	boolean _test3Models_test2Model_testBoolean = readBoolean();
	//end
	_test3Models_test2Model.setTestBoolean (_test3Models_test2Model_testBoolean);

	// 测试String型
	String _test3Models_test2Model_testString = readString();
	//end
	_test3Models_test2Model.setTestString (_test3Models_test2Model_testString);

	// 测试Long型
	int test3Models_test2Model_testLongsSize = readUnsignedShort();
	long[] _test3Models_test2Model_testLongs = new long[test3Models_test2Model_testLongsSize];
	int test3Models_test2Model_testLongsIndex = 0;
	for(test3Models_test2Model_testLongsIndex=0; test3Models_test2Model_testLongsIndex<test3Models_test2Model_testLongsSize; test3Models_test2Model_testLongsIndex++){
		_test3Models_test2Model_testLongs[test3Models_test2Model_testLongsIndex] = readLong();
	}//end
	_test3Models_test2Model.setTestLongs (_test3Models_test2Model_testLongs);

	// 测试Integer型
	int test3Models_test2Model_testIntegersSize = readUnsignedShort();
	int[] _test3Models_test2Model_testIntegers = new int[test3Models_test2Model_testIntegersSize];
	int test3Models_test2Model_testIntegersIndex = 0;
	for(test3Models_test2Model_testIntegersIndex=0; test3Models_test2Model_testIntegersIndex<test3Models_test2Model_testIntegersSize; test3Models_test2Model_testIntegersIndex++){
		_test3Models_test2Model_testIntegers[test3Models_test2Model_testIntegersIndex] = readInteger();
	}//end
	_test3Models_test2Model.setTestIntegers (_test3Models_test2Model_testIntegers);

	// 测试Short型
	int test3Models_test2Model_testShortsSize = readUnsignedShort();
	short[] _test3Models_test2Model_testShorts = new short[test3Models_test2Model_testShortsSize];
	int test3Models_test2Model_testShortsIndex = 0;
	for(test3Models_test2Model_testShortsIndex=0; test3Models_test2Model_testShortsIndex<test3Models_test2Model_testShortsSize; test3Models_test2Model_testShortsIndex++){
		_test3Models_test2Model_testShorts[test3Models_test2Model_testShortsIndex] = readShort();
	}//end
	_test3Models_test2Model.setTestShorts (_test3Models_test2Model_testShorts);

	// 测试Byte型
	int test3Models_test2Model_testBytesSize = readUnsignedShort();
	byte[] _test3Models_test2Model_testBytes = new byte[test3Models_test2Model_testBytesSize];
	int test3Models_test2Model_testBytesIndex = 0;
	for(test3Models_test2Model_testBytesIndex=0; test3Models_test2Model_testBytesIndex<test3Models_test2Model_testBytesSize; test3Models_test2Model_testBytesIndex++){
		_test3Models_test2Model_testBytes[test3Models_test2Model_testBytesIndex] = readByte();
	}//end
	_test3Models_test2Model.setTestBytes (_test3Models_test2Model_testBytes);

	// 测试Boolean型
	int test3Models_test2Model_testBooleansSize = readUnsignedShort();
	boolean[] _test3Models_test2Model_testBooleans = new boolean[test3Models_test2Model_testBooleansSize];
	int test3Models_test2Model_testBooleansIndex = 0;
	for(test3Models_test2Model_testBooleansIndex=0; test3Models_test2Model_testBooleansIndex<test3Models_test2Model_testBooleansSize; test3Models_test2Model_testBooleansIndex++){
		_test3Models_test2Model_testBooleans[test3Models_test2Model_testBooleansIndex] = readBoolean();
	}//end
	_test3Models_test2Model.setTestBooleans (_test3Models_test2Model_testBooleans);

	// 测试String型
	int test3Models_test2Model_testStringsSize = readUnsignedShort();
	String[] _test3Models_test2Model_testStrings = new String[test3Models_test2Model_testStringsSize];
	int test3Models_test2Model_testStringsIndex = 0;
	for(test3Models_test2Model_testStringsIndex=0; test3Models_test2Model_testStringsIndex<test3Models_test2Model_testStringsSize; test3Models_test2Model_testStringsIndex++){
		_test3Models_test2Model_testStrings[test3Models_test2Model_testStringsIndex] = readString();
	}//end
	_test3Models_test2Model.setTestStrings (_test3Models_test2Model_testStrings);

	// 测试test1Model信息
	int test3Models_test2Model_test1ModelSize = readUnsignedShort();
	com.imop.lj.gameserver.test.model.Test1Model[] _test3Models_test2Model_test1Model = new com.imop.lj.gameserver.test.model.Test1Model[test3Models_test2Model_test1ModelSize];
	int test3Models_test2Model_test1ModelIndex = 0;
	for(test3Models_test2Model_test1ModelIndex=0; test3Models_test2Model_test1ModelIndex<test3Models_test2Model_test1ModelSize; test3Models_test2Model_test1ModelIndex++){
		_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex] = new com.imop.lj.gameserver.test.model.Test1Model();
	// 测试Long型
	long _test3Models_test2Model_test1Model_testLong = readLong();
	//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestLong (_test3Models_test2Model_test1Model_testLong);

	// 测试Integer型
	int _test3Models_test2Model_test1Model_testInteger = readInteger();
	//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestInteger (_test3Models_test2Model_test1Model_testInteger);

	// 测试Short型
	short _test3Models_test2Model_test1Model_testShort = readShort();
	//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestShort (_test3Models_test2Model_test1Model_testShort);

	// 测试Byte型
	byte _test3Models_test2Model_test1Model_testByte = readByte();
	//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestByte (_test3Models_test2Model_test1Model_testByte);

	// 测试Boolean型
	boolean _test3Models_test2Model_test1Model_testBoolean = readBoolean();
	//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestBoolean (_test3Models_test2Model_test1Model_testBoolean);

	// 测试String型
	String _test3Models_test2Model_test1Model_testString = readString();
	//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestString (_test3Models_test2Model_test1Model_testString);

	// 测试Long型
	int test3Models_test2Model_test1Model_testLongsSize = readUnsignedShort();
	long[] _test3Models_test2Model_test1Model_testLongs = new long[test3Models_test2Model_test1Model_testLongsSize];
	int test3Models_test2Model_test1Model_testLongsIndex = 0;
	for(test3Models_test2Model_test1Model_testLongsIndex=0; test3Models_test2Model_test1Model_testLongsIndex<test3Models_test2Model_test1Model_testLongsSize; test3Models_test2Model_test1Model_testLongsIndex++){
		_test3Models_test2Model_test1Model_testLongs[test3Models_test2Model_test1Model_testLongsIndex] = readLong();
	}//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestLongs (_test3Models_test2Model_test1Model_testLongs);

	// 测试Integer型
	int test3Models_test2Model_test1Model_testIntegersSize = readUnsignedShort();
	int[] _test3Models_test2Model_test1Model_testIntegers = new int[test3Models_test2Model_test1Model_testIntegersSize];
	int test3Models_test2Model_test1Model_testIntegersIndex = 0;
	for(test3Models_test2Model_test1Model_testIntegersIndex=0; test3Models_test2Model_test1Model_testIntegersIndex<test3Models_test2Model_test1Model_testIntegersSize; test3Models_test2Model_test1Model_testIntegersIndex++){
		_test3Models_test2Model_test1Model_testIntegers[test3Models_test2Model_test1Model_testIntegersIndex] = readInteger();
	}//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestIntegers (_test3Models_test2Model_test1Model_testIntegers);

	// 测试Short型
	int test3Models_test2Model_test1Model_testShortsSize = readUnsignedShort();
	short[] _test3Models_test2Model_test1Model_testShorts = new short[test3Models_test2Model_test1Model_testShortsSize];
	int test3Models_test2Model_test1Model_testShortsIndex = 0;
	for(test3Models_test2Model_test1Model_testShortsIndex=0; test3Models_test2Model_test1Model_testShortsIndex<test3Models_test2Model_test1Model_testShortsSize; test3Models_test2Model_test1Model_testShortsIndex++){
		_test3Models_test2Model_test1Model_testShorts[test3Models_test2Model_test1Model_testShortsIndex] = readShort();
	}//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestShorts (_test3Models_test2Model_test1Model_testShorts);

	// 测试Byte型
	int test3Models_test2Model_test1Model_testBytesSize = readUnsignedShort();
	byte[] _test3Models_test2Model_test1Model_testBytes = new byte[test3Models_test2Model_test1Model_testBytesSize];
	int test3Models_test2Model_test1Model_testBytesIndex = 0;
	for(test3Models_test2Model_test1Model_testBytesIndex=0; test3Models_test2Model_test1Model_testBytesIndex<test3Models_test2Model_test1Model_testBytesSize; test3Models_test2Model_test1Model_testBytesIndex++){
		_test3Models_test2Model_test1Model_testBytes[test3Models_test2Model_test1Model_testBytesIndex] = readByte();
	}//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestBytes (_test3Models_test2Model_test1Model_testBytes);

	// 测试Boolean型
	int test3Models_test2Model_test1Model_testBooleansSize = readUnsignedShort();
	boolean[] _test3Models_test2Model_test1Model_testBooleans = new boolean[test3Models_test2Model_test1Model_testBooleansSize];
	int test3Models_test2Model_test1Model_testBooleansIndex = 0;
	for(test3Models_test2Model_test1Model_testBooleansIndex=0; test3Models_test2Model_test1Model_testBooleansIndex<test3Models_test2Model_test1Model_testBooleansSize; test3Models_test2Model_test1Model_testBooleansIndex++){
		_test3Models_test2Model_test1Model_testBooleans[test3Models_test2Model_test1Model_testBooleansIndex] = readBoolean();
	}//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestBooleans (_test3Models_test2Model_test1Model_testBooleans);

	// 测试String型
	int test3Models_test2Model_test1Model_testStringsSize = readUnsignedShort();
	String[] _test3Models_test2Model_test1Model_testStrings = new String[test3Models_test2Model_test1Model_testStringsSize];
	int test3Models_test2Model_test1Model_testStringsIndex = 0;
	for(test3Models_test2Model_test1Model_testStringsIndex=0; test3Models_test2Model_test1Model_testStringsIndex<test3Models_test2Model_test1Model_testStringsSize; test3Models_test2Model_test1Model_testStringsIndex++){
		_test3Models_test2Model_test1Model_testStrings[test3Models_test2Model_test1Model_testStringsIndex] = readString();
	}//end
	_test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].setTestStrings (_test3Models_test2Model_test1Model_testStrings);
	}
	//end
	_test3Models_test2Model.setTest1Model (_test3Models_test2Model_test1Model);
	_test3Models[test3ModelsIndex].setTest2Model (_test3Models_test2Model);
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
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 测试Long型
	writeLong(testLong);


	// 测试Integer型
	writeInteger(testInteger);


	// 测试Short型
	writeShort(testShort);


	// 测试Byte型
	writeByte(testByte);


	// 测试Boolean型
	writeBoolean(testBoolean);


	// 测试String型
	writeString(testString);


	// 测试Long型
	writeShort(testLongs.length);
	int testLongsSize = testLongs.length;
	int testLongsIndex = 0;
	for(testLongsIndex=0; testLongsIndex<testLongsSize; testLongsIndex++){
		writeLong(testLongs [ testLongsIndex ]);
	}//end


	// 测试Integer型
	writeShort(testIntegers.length);
	int testIntegersSize = testIntegers.length;
	int testIntegersIndex = 0;
	for(testIntegersIndex=0; testIntegersIndex<testIntegersSize; testIntegersIndex++){
		writeInteger(testIntegers [ testIntegersIndex ]);
	}//end


	// 测试Short型
	writeShort(testShorts.length);
	int testShortsSize = testShorts.length;
	int testShortsIndex = 0;
	for(testShortsIndex=0; testShortsIndex<testShortsSize; testShortsIndex++){
		writeShort(testShorts [ testShortsIndex ]);
	}//end


	// 测试Byte型
	writeShort(testBytes.length);
	int testBytesSize = testBytes.length;
	int testBytesIndex = 0;
	for(testBytesIndex=0; testBytesIndex<testBytesSize; testBytesIndex++){
		writeByte(testBytes [ testBytesIndex ]);
	}//end


	// 测试Boolean型
	writeShort(testBooleans.length);
	int testBooleansSize = testBooleans.length;
	int testBooleansIndex = 0;
	for(testBooleansIndex=0; testBooleansIndex<testBooleansSize; testBooleansIndex++){
		writeBoolean(testBooleans [ testBooleansIndex ]);
	}//end


	// 测试String型
	writeShort(testStrings.length);
	int testStringsSize = testStrings.length;
	int testStringsIndex = 0;
	for(testStringsIndex=0; testStringsIndex<testStringsSize; testStringsIndex++){
		writeString(testStrings [ testStringsIndex ]);
	}//end


	long test1Model_testLong = test1Model.getTestLong ();

	// 测试Long型
	writeLong(test1Model_testLong);

	int test1Model_testInteger = test1Model.getTestInteger ();

	// 测试Integer型
	writeInteger(test1Model_testInteger);

	short test1Model_testShort = test1Model.getTestShort ();

	// 测试Short型
	writeShort(test1Model_testShort);

	byte test1Model_testByte = test1Model.getTestByte ();

	// 测试Byte型
	writeByte(test1Model_testByte);

	boolean test1Model_testBoolean = test1Model.getTestBoolean ();

	// 测试Boolean型
	writeBoolean(test1Model_testBoolean);

	String test1Model_testString = test1Model.getTestString ();

	// 测试String型
	writeString(test1Model_testString);

	long[] test1Model_testLongs = test1Model.getTestLongs ();

	// 测试Long型
	writeShort(test1Model_testLongs.length);
	int test1Model_testLongsSize = test1Model_testLongs.length;
	int test1Model_testLongsIndex = 0;
	for(test1Model_testLongsIndex=0; test1Model_testLongsIndex<test1Model_testLongsSize; test1Model_testLongsIndex++){
		writeLong(test1Model_testLongs [ test1Model_testLongsIndex ]);
	}//end

	int[] test1Model_testIntegers = test1Model.getTestIntegers ();

	// 测试Integer型
	writeShort(test1Model_testIntegers.length);
	int test1Model_testIntegersSize = test1Model_testIntegers.length;
	int test1Model_testIntegersIndex = 0;
	for(test1Model_testIntegersIndex=0; test1Model_testIntegersIndex<test1Model_testIntegersSize; test1Model_testIntegersIndex++){
		writeInteger(test1Model_testIntegers [ test1Model_testIntegersIndex ]);
	}//end

	short[] test1Model_testShorts = test1Model.getTestShorts ();

	// 测试Short型
	writeShort(test1Model_testShorts.length);
	int test1Model_testShortsSize = test1Model_testShorts.length;
	int test1Model_testShortsIndex = 0;
	for(test1Model_testShortsIndex=0; test1Model_testShortsIndex<test1Model_testShortsSize; test1Model_testShortsIndex++){
		writeShort(test1Model_testShorts [ test1Model_testShortsIndex ]);
	}//end

	byte[] test1Model_testBytes = test1Model.getTestBytes ();

	// 测试Byte型
	writeShort(test1Model_testBytes.length);
	int test1Model_testBytesSize = test1Model_testBytes.length;
	int test1Model_testBytesIndex = 0;
	for(test1Model_testBytesIndex=0; test1Model_testBytesIndex<test1Model_testBytesSize; test1Model_testBytesIndex++){
		writeByte(test1Model_testBytes [ test1Model_testBytesIndex ]);
	}//end

	boolean[] test1Model_testBooleans = test1Model.getTestBooleans ();

	// 测试Boolean型
	writeShort(test1Model_testBooleans.length);
	int test1Model_testBooleansSize = test1Model_testBooleans.length;
	int test1Model_testBooleansIndex = 0;
	for(test1Model_testBooleansIndex=0; test1Model_testBooleansIndex<test1Model_testBooleansSize; test1Model_testBooleansIndex++){
		writeBoolean(test1Model_testBooleans [ test1Model_testBooleansIndex ]);
	}//end

	String[] test1Model_testStrings = test1Model.getTestStrings ();

	// 测试String型
	writeShort(test1Model_testStrings.length);
	int test1Model_testStringsSize = test1Model_testStrings.length;
	int test1Model_testStringsIndex = 0;
	for(test1Model_testStringsIndex=0; test1Model_testStringsIndex<test1Model_testStringsSize; test1Model_testStringsIndex++){
		writeString(test1Model_testStrings [ test1Model_testStringsIndex ]);
	}//end


	// 单个测试信息
	writeShort(test3Models.length);
	int test3ModelsIndex = 0;
	int test3ModelsSize = test3Models.length;
	for(test3ModelsIndex=0; test3ModelsIndex<test3ModelsSize; test3ModelsIndex++){

	long test3Models_testLong = test3Models[test3ModelsIndex].getTestLong();

	// 测试Long型
	writeLong(test3Models_testLong);

	int test3Models_testInteger = test3Models[test3ModelsIndex].getTestInteger();

	// 测试Integer型
	writeInteger(test3Models_testInteger);

	short test3Models_testShort = test3Models[test3ModelsIndex].getTestShort();

	// 测试Short型
	writeShort(test3Models_testShort);

	byte test3Models_testByte = test3Models[test3ModelsIndex].getTestByte();

	// 测试Byte型
	writeByte(test3Models_testByte);

	boolean test3Models_testBoolean = test3Models[test3ModelsIndex].getTestBoolean();

	// 测试Boolean型
	writeBoolean(test3Models_testBoolean);

	String test3Models_testString = test3Models[test3ModelsIndex].getTestString();

	// 测试String型
	writeString(test3Models_testString);

	long[] test3Models_testLongs = test3Models[test3ModelsIndex].getTestLongs();

	// 测试Long型
	writeShort(test3Models_testLongs.length);
	int test3Models_testLongsSize = test3Models_testLongs.length;
	int test3Models_testLongsIndex = 0;
	for(test3Models_testLongsIndex=0; test3Models_testLongsIndex<test3Models_testLongsSize; test3Models_testLongsIndex++){
		writeLong(test3Models_testLongs [ test3Models_testLongsIndex ]);
	}//end

	int[] test3Models_testIntegers = test3Models[test3ModelsIndex].getTestIntegers();

	// 测试Integer型
	writeShort(test3Models_testIntegers.length);
	int test3Models_testIntegersSize = test3Models_testIntegers.length;
	int test3Models_testIntegersIndex = 0;
	for(test3Models_testIntegersIndex=0; test3Models_testIntegersIndex<test3Models_testIntegersSize; test3Models_testIntegersIndex++){
		writeInteger(test3Models_testIntegers [ test3Models_testIntegersIndex ]);
	}//end

	short[] test3Models_testShorts = test3Models[test3ModelsIndex].getTestShorts();

	// 测试Short型
	writeShort(test3Models_testShorts.length);
	int test3Models_testShortsSize = test3Models_testShorts.length;
	int test3Models_testShortsIndex = 0;
	for(test3Models_testShortsIndex=0; test3Models_testShortsIndex<test3Models_testShortsSize; test3Models_testShortsIndex++){
		writeShort(test3Models_testShorts [ test3Models_testShortsIndex ]);
	}//end

	byte[] test3Models_testBytes = test3Models[test3ModelsIndex].getTestBytes();

	// 测试Byte型
	writeShort(test3Models_testBytes.length);
	int test3Models_testBytesSize = test3Models_testBytes.length;
	int test3Models_testBytesIndex = 0;
	for(test3Models_testBytesIndex=0; test3Models_testBytesIndex<test3Models_testBytesSize; test3Models_testBytesIndex++){
		writeByte(test3Models_testBytes [ test3Models_testBytesIndex ]);
	}//end

	boolean[] test3Models_testBooleans = test3Models[test3ModelsIndex].getTestBooleans();

	// 测试Boolean型
	writeShort(test3Models_testBooleans.length);
	int test3Models_testBooleansSize = test3Models_testBooleans.length;
	int test3Models_testBooleansIndex = 0;
	for(test3Models_testBooleansIndex=0; test3Models_testBooleansIndex<test3Models_testBooleansSize; test3Models_testBooleansIndex++){
		writeBoolean(test3Models_testBooleans [ test3Models_testBooleansIndex ]);
	}//end

	String[] test3Models_testStrings = test3Models[test3ModelsIndex].getTestStrings();

	// 测试String型
	writeShort(test3Models_testStrings.length);
	int test3Models_testStringsSize = test3Models_testStrings.length;
	int test3Models_testStringsIndex = 0;
	for(test3Models_testStringsIndex=0; test3Models_testStringsIndex<test3Models_testStringsSize; test3Models_testStringsIndex++){
		writeString(test3Models_testStrings [ test3Models_testStringsIndex ]);
	}//end

	com.imop.lj.gameserver.test.model.Test2Model[] test3Models_test2Models = test3Models[test3ModelsIndex].getTest2Models();

	// 测试test2Models信息
	writeShort(test3Models_test2Models.length);
	int test3Models_test2ModelsIndex = 0;
	int test3Models_test2ModelsSize = test3Models_test2Models.length;
	for(test3Models_test2ModelsIndex=0; test3Models_test2ModelsIndex<test3Models_test2ModelsSize; test3Models_test2ModelsIndex++){

	long test3Models_test2Models_testLong = test3Models_test2Models[test3Models_test2ModelsIndex].getTestLong();

	// 测试Long型
	writeLong(test3Models_test2Models_testLong);

	int test3Models_test2Models_testInteger = test3Models_test2Models[test3Models_test2ModelsIndex].getTestInteger();

	// 测试Integer型
	writeInteger(test3Models_test2Models_testInteger);

	short test3Models_test2Models_testShort = test3Models_test2Models[test3Models_test2ModelsIndex].getTestShort();

	// 测试Short型
	writeShort(test3Models_test2Models_testShort);

	byte test3Models_test2Models_testByte = test3Models_test2Models[test3Models_test2ModelsIndex].getTestByte();

	// 测试Byte型
	writeByte(test3Models_test2Models_testByte);

	boolean test3Models_test2Models_testBoolean = test3Models_test2Models[test3Models_test2ModelsIndex].getTestBoolean();

	// 测试Boolean型
	writeBoolean(test3Models_test2Models_testBoolean);

	String test3Models_test2Models_testString = test3Models_test2Models[test3Models_test2ModelsIndex].getTestString();

	// 测试String型
	writeString(test3Models_test2Models_testString);

	long[] test3Models_test2Models_testLongs = test3Models_test2Models[test3Models_test2ModelsIndex].getTestLongs();

	// 测试Long型
	writeShort(test3Models_test2Models_testLongs.length);
	int test3Models_test2Models_testLongsSize = test3Models_test2Models_testLongs.length;
	int test3Models_test2Models_testLongsIndex = 0;
	for(test3Models_test2Models_testLongsIndex=0; test3Models_test2Models_testLongsIndex<test3Models_test2Models_testLongsSize; test3Models_test2Models_testLongsIndex++){
		writeLong(test3Models_test2Models_testLongs [ test3Models_test2Models_testLongsIndex ]);
	}//end

	int[] test3Models_test2Models_testIntegers = test3Models_test2Models[test3Models_test2ModelsIndex].getTestIntegers();

	// 测试Integer型
	writeShort(test3Models_test2Models_testIntegers.length);
	int test3Models_test2Models_testIntegersSize = test3Models_test2Models_testIntegers.length;
	int test3Models_test2Models_testIntegersIndex = 0;
	for(test3Models_test2Models_testIntegersIndex=0; test3Models_test2Models_testIntegersIndex<test3Models_test2Models_testIntegersSize; test3Models_test2Models_testIntegersIndex++){
		writeInteger(test3Models_test2Models_testIntegers [ test3Models_test2Models_testIntegersIndex ]);
	}//end

	short[] test3Models_test2Models_testShorts = test3Models_test2Models[test3Models_test2ModelsIndex].getTestShorts();

	// 测试Short型
	writeShort(test3Models_test2Models_testShorts.length);
	int test3Models_test2Models_testShortsSize = test3Models_test2Models_testShorts.length;
	int test3Models_test2Models_testShortsIndex = 0;
	for(test3Models_test2Models_testShortsIndex=0; test3Models_test2Models_testShortsIndex<test3Models_test2Models_testShortsSize; test3Models_test2Models_testShortsIndex++){
		writeShort(test3Models_test2Models_testShorts [ test3Models_test2Models_testShortsIndex ]);
	}//end

	byte[] test3Models_test2Models_testBytes = test3Models_test2Models[test3Models_test2ModelsIndex].getTestBytes();

	// 测试Byte型
	writeShort(test3Models_test2Models_testBytes.length);
	int test3Models_test2Models_testBytesSize = test3Models_test2Models_testBytes.length;
	int test3Models_test2Models_testBytesIndex = 0;
	for(test3Models_test2Models_testBytesIndex=0; test3Models_test2Models_testBytesIndex<test3Models_test2Models_testBytesSize; test3Models_test2Models_testBytesIndex++){
		writeByte(test3Models_test2Models_testBytes [ test3Models_test2Models_testBytesIndex ]);
	}//end

	boolean[] test3Models_test2Models_testBooleans = test3Models_test2Models[test3Models_test2ModelsIndex].getTestBooleans();

	// 测试Boolean型
	writeShort(test3Models_test2Models_testBooleans.length);
	int test3Models_test2Models_testBooleansSize = test3Models_test2Models_testBooleans.length;
	int test3Models_test2Models_testBooleansIndex = 0;
	for(test3Models_test2Models_testBooleansIndex=0; test3Models_test2Models_testBooleansIndex<test3Models_test2Models_testBooleansSize; test3Models_test2Models_testBooleansIndex++){
		writeBoolean(test3Models_test2Models_testBooleans [ test3Models_test2Models_testBooleansIndex ]);
	}//end

	String[] test3Models_test2Models_testStrings = test3Models_test2Models[test3Models_test2ModelsIndex].getTestStrings();

	// 测试String型
	writeShort(test3Models_test2Models_testStrings.length);
	int test3Models_test2Models_testStringsSize = test3Models_test2Models_testStrings.length;
	int test3Models_test2Models_testStringsIndex = 0;
	for(test3Models_test2Models_testStringsIndex=0; test3Models_test2Models_testStringsIndex<test3Models_test2Models_testStringsSize; test3Models_test2Models_testStringsIndex++){
		writeString(test3Models_test2Models_testStrings [ test3Models_test2Models_testStringsIndex ]);
	}//end

	com.imop.lj.gameserver.test.model.Test1Model[] test3Models_test2Models_test1Model = test3Models_test2Models[test3Models_test2ModelsIndex].getTest1Model();

	// 测试test1Model信息
	writeShort(test3Models_test2Models_test1Model.length);
	int test3Models_test2Models_test1ModelIndex = 0;
	int test3Models_test2Models_test1ModelSize = test3Models_test2Models_test1Model.length;
	for(test3Models_test2Models_test1ModelIndex=0; test3Models_test2Models_test1ModelIndex<test3Models_test2Models_test1ModelSize; test3Models_test2Models_test1ModelIndex++){

	long test3Models_test2Models_test1Model_testLong = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestLong();

	// 测试Long型
	writeLong(test3Models_test2Models_test1Model_testLong);

	int test3Models_test2Models_test1Model_testInteger = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestInteger();

	// 测试Integer型
	writeInteger(test3Models_test2Models_test1Model_testInteger);

	short test3Models_test2Models_test1Model_testShort = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestShort();

	// 测试Short型
	writeShort(test3Models_test2Models_test1Model_testShort);

	byte test3Models_test2Models_test1Model_testByte = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestByte();

	// 测试Byte型
	writeByte(test3Models_test2Models_test1Model_testByte);

	boolean test3Models_test2Models_test1Model_testBoolean = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestBoolean();

	// 测试Boolean型
	writeBoolean(test3Models_test2Models_test1Model_testBoolean);

	String test3Models_test2Models_test1Model_testString = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestString();

	// 测试String型
	writeString(test3Models_test2Models_test1Model_testString);

	long[] test3Models_test2Models_test1Model_testLongs = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestLongs();

	// 测试Long型
	writeShort(test3Models_test2Models_test1Model_testLongs.length);
	int test3Models_test2Models_test1Model_testLongsSize = test3Models_test2Models_test1Model_testLongs.length;
	int test3Models_test2Models_test1Model_testLongsIndex = 0;
	for(test3Models_test2Models_test1Model_testLongsIndex=0; test3Models_test2Models_test1Model_testLongsIndex<test3Models_test2Models_test1Model_testLongsSize; test3Models_test2Models_test1Model_testLongsIndex++){
		writeLong(test3Models_test2Models_test1Model_testLongs [ test3Models_test2Models_test1Model_testLongsIndex ]);
	}//end

	int[] test3Models_test2Models_test1Model_testIntegers = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestIntegers();

	// 测试Integer型
	writeShort(test3Models_test2Models_test1Model_testIntegers.length);
	int test3Models_test2Models_test1Model_testIntegersSize = test3Models_test2Models_test1Model_testIntegers.length;
	int test3Models_test2Models_test1Model_testIntegersIndex = 0;
	for(test3Models_test2Models_test1Model_testIntegersIndex=0; test3Models_test2Models_test1Model_testIntegersIndex<test3Models_test2Models_test1Model_testIntegersSize; test3Models_test2Models_test1Model_testIntegersIndex++){
		writeInteger(test3Models_test2Models_test1Model_testIntegers [ test3Models_test2Models_test1Model_testIntegersIndex ]);
	}//end

	short[] test3Models_test2Models_test1Model_testShorts = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestShorts();

	// 测试Short型
	writeShort(test3Models_test2Models_test1Model_testShorts.length);
	int test3Models_test2Models_test1Model_testShortsSize = test3Models_test2Models_test1Model_testShorts.length;
	int test3Models_test2Models_test1Model_testShortsIndex = 0;
	for(test3Models_test2Models_test1Model_testShortsIndex=0; test3Models_test2Models_test1Model_testShortsIndex<test3Models_test2Models_test1Model_testShortsSize; test3Models_test2Models_test1Model_testShortsIndex++){
		writeShort(test3Models_test2Models_test1Model_testShorts [ test3Models_test2Models_test1Model_testShortsIndex ]);
	}//end

	byte[] test3Models_test2Models_test1Model_testBytes = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestBytes();

	// 测试Byte型
	writeShort(test3Models_test2Models_test1Model_testBytes.length);
	int test3Models_test2Models_test1Model_testBytesSize = test3Models_test2Models_test1Model_testBytes.length;
	int test3Models_test2Models_test1Model_testBytesIndex = 0;
	for(test3Models_test2Models_test1Model_testBytesIndex=0; test3Models_test2Models_test1Model_testBytesIndex<test3Models_test2Models_test1Model_testBytesSize; test3Models_test2Models_test1Model_testBytesIndex++){
		writeByte(test3Models_test2Models_test1Model_testBytes [ test3Models_test2Models_test1Model_testBytesIndex ]);
	}//end

	boolean[] test3Models_test2Models_test1Model_testBooleans = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestBooleans();

	// 测试Boolean型
	writeShort(test3Models_test2Models_test1Model_testBooleans.length);
	int test3Models_test2Models_test1Model_testBooleansSize = test3Models_test2Models_test1Model_testBooleans.length;
	int test3Models_test2Models_test1Model_testBooleansIndex = 0;
	for(test3Models_test2Models_test1Model_testBooleansIndex=0; test3Models_test2Models_test1Model_testBooleansIndex<test3Models_test2Models_test1Model_testBooleansSize; test3Models_test2Models_test1Model_testBooleansIndex++){
		writeBoolean(test3Models_test2Models_test1Model_testBooleans [ test3Models_test2Models_test1Model_testBooleansIndex ]);
	}//end

	String[] test3Models_test2Models_test1Model_testStrings = test3Models_test2Models_test1Model[test3Models_test2Models_test1ModelIndex].getTestStrings();

	// 测试String型
	writeShort(test3Models_test2Models_test1Model_testStrings.length);
	int test3Models_test2Models_test1Model_testStringsSize = test3Models_test2Models_test1Model_testStrings.length;
	int test3Models_test2Models_test1Model_testStringsIndex = 0;
	for(test3Models_test2Models_test1Model_testStringsIndex=0; test3Models_test2Models_test1Model_testStringsIndex<test3Models_test2Models_test1Model_testStringsSize; test3Models_test2Models_test1Model_testStringsIndex++){
		writeString(test3Models_test2Models_test1Model_testStrings [ test3Models_test2Models_test1Model_testStringsIndex ]);
	}//end
	}
	//end
	}
	//end

	com.imop.lj.gameserver.test.model.Test2Model test3Models_test2Model = test3Models[test3ModelsIndex].getTest2Model();

	long test3Models_test2Model_testLong = test3Models_test2Model.getTestLong ();

	// 测试Long型
	writeLong(test3Models_test2Model_testLong);

	int test3Models_test2Model_testInteger = test3Models_test2Model.getTestInteger ();

	// 测试Integer型
	writeInteger(test3Models_test2Model_testInteger);

	short test3Models_test2Model_testShort = test3Models_test2Model.getTestShort ();

	// 测试Short型
	writeShort(test3Models_test2Model_testShort);

	byte test3Models_test2Model_testByte = test3Models_test2Model.getTestByte ();

	// 测试Byte型
	writeByte(test3Models_test2Model_testByte);

	boolean test3Models_test2Model_testBoolean = test3Models_test2Model.getTestBoolean ();

	// 测试Boolean型
	writeBoolean(test3Models_test2Model_testBoolean);

	String test3Models_test2Model_testString = test3Models_test2Model.getTestString ();

	// 测试String型
	writeString(test3Models_test2Model_testString);

	long[] test3Models_test2Model_testLongs = test3Models_test2Model.getTestLongs ();

	// 测试Long型
	writeShort(test3Models_test2Model_testLongs.length);
	int test3Models_test2Model_testLongsSize = test3Models_test2Model_testLongs.length;
	int test3Models_test2Model_testLongsIndex = 0;
	for(test3Models_test2Model_testLongsIndex=0; test3Models_test2Model_testLongsIndex<test3Models_test2Model_testLongsSize; test3Models_test2Model_testLongsIndex++){
		writeLong(test3Models_test2Model_testLongs [ test3Models_test2Model_testLongsIndex ]);
	}//end

	int[] test3Models_test2Model_testIntegers = test3Models_test2Model.getTestIntegers ();

	// 测试Integer型
	writeShort(test3Models_test2Model_testIntegers.length);
	int test3Models_test2Model_testIntegersSize = test3Models_test2Model_testIntegers.length;
	int test3Models_test2Model_testIntegersIndex = 0;
	for(test3Models_test2Model_testIntegersIndex=0; test3Models_test2Model_testIntegersIndex<test3Models_test2Model_testIntegersSize; test3Models_test2Model_testIntegersIndex++){
		writeInteger(test3Models_test2Model_testIntegers [ test3Models_test2Model_testIntegersIndex ]);
	}//end

	short[] test3Models_test2Model_testShorts = test3Models_test2Model.getTestShorts ();

	// 测试Short型
	writeShort(test3Models_test2Model_testShorts.length);
	int test3Models_test2Model_testShortsSize = test3Models_test2Model_testShorts.length;
	int test3Models_test2Model_testShortsIndex = 0;
	for(test3Models_test2Model_testShortsIndex=0; test3Models_test2Model_testShortsIndex<test3Models_test2Model_testShortsSize; test3Models_test2Model_testShortsIndex++){
		writeShort(test3Models_test2Model_testShorts [ test3Models_test2Model_testShortsIndex ]);
	}//end

	byte[] test3Models_test2Model_testBytes = test3Models_test2Model.getTestBytes ();

	// 测试Byte型
	writeShort(test3Models_test2Model_testBytes.length);
	int test3Models_test2Model_testBytesSize = test3Models_test2Model_testBytes.length;
	int test3Models_test2Model_testBytesIndex = 0;
	for(test3Models_test2Model_testBytesIndex=0; test3Models_test2Model_testBytesIndex<test3Models_test2Model_testBytesSize; test3Models_test2Model_testBytesIndex++){
		writeByte(test3Models_test2Model_testBytes [ test3Models_test2Model_testBytesIndex ]);
	}//end

	boolean[] test3Models_test2Model_testBooleans = test3Models_test2Model.getTestBooleans ();

	// 测试Boolean型
	writeShort(test3Models_test2Model_testBooleans.length);
	int test3Models_test2Model_testBooleansSize = test3Models_test2Model_testBooleans.length;
	int test3Models_test2Model_testBooleansIndex = 0;
	for(test3Models_test2Model_testBooleansIndex=0; test3Models_test2Model_testBooleansIndex<test3Models_test2Model_testBooleansSize; test3Models_test2Model_testBooleansIndex++){
		writeBoolean(test3Models_test2Model_testBooleans [ test3Models_test2Model_testBooleansIndex ]);
	}//end

	String[] test3Models_test2Model_testStrings = test3Models_test2Model.getTestStrings ();

	// 测试String型
	writeShort(test3Models_test2Model_testStrings.length);
	int test3Models_test2Model_testStringsSize = test3Models_test2Model_testStrings.length;
	int test3Models_test2Model_testStringsIndex = 0;
	for(test3Models_test2Model_testStringsIndex=0; test3Models_test2Model_testStringsIndex<test3Models_test2Model_testStringsSize; test3Models_test2Model_testStringsIndex++){
		writeString(test3Models_test2Model_testStrings [ test3Models_test2Model_testStringsIndex ]);
	}//end

	com.imop.lj.gameserver.test.model.Test1Model[] test3Models_test2Model_test1Model = test3Models_test2Model.getTest1Model ();

	// 测试test1Model信息
	writeShort(test3Models_test2Model_test1Model.length);
	int test3Models_test2Model_test1ModelIndex = 0;
	int test3Models_test2Model_test1ModelSize = test3Models_test2Model_test1Model.length;
	for(test3Models_test2Model_test1ModelIndex=0; test3Models_test2Model_test1ModelIndex<test3Models_test2Model_test1ModelSize; test3Models_test2Model_test1ModelIndex++){

	long test3Models_test2Model_test1Model_testLong = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestLong();

	// 测试Long型
	writeLong(test3Models_test2Model_test1Model_testLong);

	int test3Models_test2Model_test1Model_testInteger = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestInteger();

	// 测试Integer型
	writeInteger(test3Models_test2Model_test1Model_testInteger);

	short test3Models_test2Model_test1Model_testShort = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestShort();

	// 测试Short型
	writeShort(test3Models_test2Model_test1Model_testShort);

	byte test3Models_test2Model_test1Model_testByte = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestByte();

	// 测试Byte型
	writeByte(test3Models_test2Model_test1Model_testByte);

	boolean test3Models_test2Model_test1Model_testBoolean = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestBoolean();

	// 测试Boolean型
	writeBoolean(test3Models_test2Model_test1Model_testBoolean);

	String test3Models_test2Model_test1Model_testString = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestString();

	// 测试String型
	writeString(test3Models_test2Model_test1Model_testString);

	long[] test3Models_test2Model_test1Model_testLongs = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestLongs();

	// 测试Long型
	writeShort(test3Models_test2Model_test1Model_testLongs.length);
	int test3Models_test2Model_test1Model_testLongsSize = test3Models_test2Model_test1Model_testLongs.length;
	int test3Models_test2Model_test1Model_testLongsIndex = 0;
	for(test3Models_test2Model_test1Model_testLongsIndex=0; test3Models_test2Model_test1Model_testLongsIndex<test3Models_test2Model_test1Model_testLongsSize; test3Models_test2Model_test1Model_testLongsIndex++){
		writeLong(test3Models_test2Model_test1Model_testLongs [ test3Models_test2Model_test1Model_testLongsIndex ]);
	}//end

	int[] test3Models_test2Model_test1Model_testIntegers = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestIntegers();

	// 测试Integer型
	writeShort(test3Models_test2Model_test1Model_testIntegers.length);
	int test3Models_test2Model_test1Model_testIntegersSize = test3Models_test2Model_test1Model_testIntegers.length;
	int test3Models_test2Model_test1Model_testIntegersIndex = 0;
	for(test3Models_test2Model_test1Model_testIntegersIndex=0; test3Models_test2Model_test1Model_testIntegersIndex<test3Models_test2Model_test1Model_testIntegersSize; test3Models_test2Model_test1Model_testIntegersIndex++){
		writeInteger(test3Models_test2Model_test1Model_testIntegers [ test3Models_test2Model_test1Model_testIntegersIndex ]);
	}//end

	short[] test3Models_test2Model_test1Model_testShorts = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestShorts();

	// 测试Short型
	writeShort(test3Models_test2Model_test1Model_testShorts.length);
	int test3Models_test2Model_test1Model_testShortsSize = test3Models_test2Model_test1Model_testShorts.length;
	int test3Models_test2Model_test1Model_testShortsIndex = 0;
	for(test3Models_test2Model_test1Model_testShortsIndex=0; test3Models_test2Model_test1Model_testShortsIndex<test3Models_test2Model_test1Model_testShortsSize; test3Models_test2Model_test1Model_testShortsIndex++){
		writeShort(test3Models_test2Model_test1Model_testShorts [ test3Models_test2Model_test1Model_testShortsIndex ]);
	}//end

	byte[] test3Models_test2Model_test1Model_testBytes = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestBytes();

	// 测试Byte型
	writeShort(test3Models_test2Model_test1Model_testBytes.length);
	int test3Models_test2Model_test1Model_testBytesSize = test3Models_test2Model_test1Model_testBytes.length;
	int test3Models_test2Model_test1Model_testBytesIndex = 0;
	for(test3Models_test2Model_test1Model_testBytesIndex=0; test3Models_test2Model_test1Model_testBytesIndex<test3Models_test2Model_test1Model_testBytesSize; test3Models_test2Model_test1Model_testBytesIndex++){
		writeByte(test3Models_test2Model_test1Model_testBytes [ test3Models_test2Model_test1Model_testBytesIndex ]);
	}//end

	boolean[] test3Models_test2Model_test1Model_testBooleans = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestBooleans();

	// 测试Boolean型
	writeShort(test3Models_test2Model_test1Model_testBooleans.length);
	int test3Models_test2Model_test1Model_testBooleansSize = test3Models_test2Model_test1Model_testBooleans.length;
	int test3Models_test2Model_test1Model_testBooleansIndex = 0;
	for(test3Models_test2Model_test1Model_testBooleansIndex=0; test3Models_test2Model_test1Model_testBooleansIndex<test3Models_test2Model_test1Model_testBooleansSize; test3Models_test2Model_test1Model_testBooleansIndex++){
		writeBoolean(test3Models_test2Model_test1Model_testBooleans [ test3Models_test2Model_test1Model_testBooleansIndex ]);
	}//end

	String[] test3Models_test2Model_test1Model_testStrings = test3Models_test2Model_test1Model[test3Models_test2Model_test1ModelIndex].getTestStrings();

	// 测试String型
	writeShort(test3Models_test2Model_test1Model_testStrings.length);
	int test3Models_test2Model_test1Model_testStringsSize = test3Models_test2Model_test1Model_testStrings.length;
	int test3Models_test2Model_test1Model_testStringsIndex = 0;
	for(test3Models_test2Model_test1Model_testStringsIndex=0; test3Models_test2Model_test1Model_testStringsIndex<test3Models_test2Model_test1Model_testStringsSize; test3Models_test2Model_test1Model_testStringsIndex++){
		writeString(test3Models_test2Model_test1Model_testStrings [ test3Models_test2Model_test1Model_testStringsIndex ]);
	}//end
	}
	//end
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TEST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEST";
	}

	public long getTestLong(){
		return testLong;
	}
		
	public void setTestLong(long testLong){
		this.testLong = testLong;
	}

	public int getTestInteger(){
		return testInteger;
	}
		
	public void setTestInteger(int testInteger){
		this.testInteger = testInteger;
	}

	public short getTestShort(){
		return testShort;
	}
		
	public void setTestShort(short testShort){
		this.testShort = testShort;
	}

	public byte getTestByte(){
		return testByte;
	}
		
	public void setTestByte(byte testByte){
		this.testByte = testByte;
	}

	public boolean getTestBoolean(){
		return testBoolean;
	}
		
	public void setTestBoolean(boolean testBoolean){
		this.testBoolean = testBoolean;
	}

	public String getTestString(){
		return testString;
	}
		
	public void setTestString(String testString){
		this.testString = testString;
	}

	public long[] getTestLongs(){
		return testLongs;
	}

	public void setTestLongs(long[] testLongs){
		this.testLongs = testLongs;
	}	

	public int[] getTestIntegers(){
		return testIntegers;
	}

	public void setTestIntegers(int[] testIntegers){
		this.testIntegers = testIntegers;
	}	

	public short[] getTestShorts(){
		return testShorts;
	}

	public void setTestShorts(short[] testShorts){
		this.testShorts = testShorts;
	}	

	public byte[] getTestBytes(){
		return testBytes;
	}

	public void setTestBytes(byte[] testBytes){
		this.testBytes = testBytes;
	}	

	public boolean[] getTestBooleans(){
		return testBooleans;
	}

	public void setTestBooleans(boolean[] testBooleans){
		this.testBooleans = testBooleans;
	}	

	public String[] getTestStrings(){
		return testStrings;
	}

	public void setTestStrings(String[] testStrings){
		this.testStrings = testStrings;
	}	

	public com.imop.lj.gameserver.test.model.Test1Model getTest1Model(){
		return test1Model;
	}
		
	public void setTest1Model(com.imop.lj.gameserver.test.model.Test1Model test1Model){
		this.test1Model = test1Model;
	}

	public com.imop.lj.gameserver.test.model.Test3Model[] getTest3Models(){
		return test3Models;
	}

	public void setTest3Models(com.imop.lj.gameserver.test.model.Test3Model[] test3Models){
		this.test3Models = test3Models;
	}	


	@Override
	public void execute() {
		TestHandlerFactory.getHandler().handleTest(this.getSession().getPlayer(), this);
	}
}