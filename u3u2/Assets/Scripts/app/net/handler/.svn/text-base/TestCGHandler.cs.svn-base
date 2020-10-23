
namespace app.net 
{
	public class TestCGHandler
	{
	public static void sendCGTest(
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
			Test3ModelList[] test3Models)
	{
		CGTest msg = new CGTest(
			testLong,
			testInteger,
			testShort,
			testByte,
			testBoolean,
			testString,
			testLongs,
			testIntegers,
			testShorts,
			testBytes,
			testBooleans,
			testStrings,
			test1Model,
			test3Models);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGTestLong(
			long testLong,
			string testString)
	{
		CGTestLong msg = new CGTestLong(
			testLong,
			testString);
		GameConnection.Instance.sendMessage(msg);
	}
	
	public static void sendCGTest1(
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
			Test1Model test1Model)
	{
		CGTest1 msg = new CGTest1(
			testLong,
			testInteger,
			testShort,
			testByte,
			testBoolean,
			testString,
			testLongs,
			testIntegers,
			testShorts,
			testBytes,
			testBooleans,
			testStrings,
			test1Model);
		GameConnection.Instance.sendMessage(msg);
	}
	
	}
}