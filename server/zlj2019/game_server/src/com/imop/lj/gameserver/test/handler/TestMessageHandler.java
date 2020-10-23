package com.imop.lj.gameserver.test.handler;
import java.util.Random;

import com.imop.lj.core.util.MathUtils;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.test.model.Test1Model;
import com.imop.lj.gameserver.test.model.Test3Model;
import com.imop.lj.gameserver.test.msg.CGTest;
import com.imop.lj.gameserver.test.msg.CGTest1;
import com.imop.lj.gameserver.test.msg.CGTestLong;
import com.imop.lj.gameserver.test.msg.GCTest;
import com.imop.lj.gameserver.test.msg.GCTest1;
import com.imop.lj.gameserver.test.msg.GCTestLong;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class TestMessageHandler {

	public TestMessageHandler() {

	}

	/**
	 * 测试
	 * 
	 * CodeGenerator
	 */
	public void handleTest(Player player, CGTest cgTest) {
		GCTest msg = new GCTest();
		msg.setTestLong(cgTest.getTestLong());
		msg.setTestInteger(cgTest.getTestInteger());
		msg.setTestBoolean(cgTest.getTestBoolean());
		msg.setTestByte(cgTest.getTestByte());
		msg.setTestShort(cgTest.getTestShort());
		msg.setTestString(cgTest.getTestString());
		
		msg.setTestLongs(cgTest.getTestLongs());
		msg.setTestIntegers(cgTest.getTestIntegers());
		msg.setTestShorts(cgTest.getTestShorts());
		msg.setTestBytes(cgTest.getTestBytes());
		msg.setTestBooleans(cgTest.getTestBooleans());
		msg.setTestStrings(cgTest.getTestStrings());
		
		Test1Model test1Model = new Test1Model();
		test1Model.setTestLong(cgTest.getTestLong());
		test1Model.setTestInteger(cgTest.getTestInteger());
		test1Model.setTestBoolean(cgTest.getTestBoolean());
		test1Model.setTestByte(cgTest.getTestByte());
		test1Model.setTestShort(cgTest.getTestShort());
		test1Model.setTestString(cgTest.getTestString());
		test1Model.setTestLongs(cgTest.getTestLongs());
		test1Model.setTestIntegers(cgTest.getTestIntegers());
		test1Model.setTestShorts(cgTest.getTestShorts());
		test1Model.setTestBytes(cgTest.getTestBytes());
		test1Model.setTestBooleans(cgTest.getTestBooleans());
		test1Model.setTestStrings(cgTest.getTestStrings());
		msg.setTest1Model(test1Model);
		
		Test3Model[] test3Models = new Test3Model[cgTest.getTest3Models().length];
		for (int i = 0; i < cgTest.getTest3Models().length; i++) {
			test3Models[i] = new Test3Model();
			test3Models[i].setTestLong(cgTest.getTest3Models()[i].getTestLong());
			test3Models[i].setTestInteger(cgTest.getTest3Models()[i].getTestInteger());
			test3Models[i].setTestBoolean(cgTest.getTest3Models()[i].getTestBoolean());
			test3Models[i].setTestByte(cgTest.getTest3Models()[i].getTestByte());
			test3Models[i].setTestShort(cgTest.getTest3Models()[i].getTestShort());
			test3Models[i].setTestString(cgTest.getTest3Models()[i].getTestString());
			test3Models[i].setTestLongs(cgTest.getTest3Models()[i].getTestLongs());
			test3Models[i].setTestIntegers(cgTest.getTest3Models()[i].getTestIntegers());
			test3Models[i].setTestShorts(cgTest.getTest3Models()[i].getTestShorts());
			test3Models[i].setTestBytes(cgTest.getTest3Models()[i].getTestBytes());
			test3Models[i].setTestBooleans(cgTest.getTest3Models()[i].getTestBooleans());
			test3Models[i].setTestStrings(cgTest.getTest3Models()[i].getTestStrings());
			
			test3Models[i].setTest2Model(cgTest.getTest3Models()[i].getTest2Model());
			
			test3Models[i].setTest2Models(cgTest.getTest3Models()[i].getTest2Models());
		}
		msg.setTest3Models(test3Models);
		
		player.sendMessage(msg);
//		player.sendMessage(msg);
//		
//		try {
//			Thread.currentThread().sleep(3000L);
//		} catch (InterruptedException e) {
//			// TODO Auto-generated catch block
//			e.printStackTrace();
//		}
//		player.sendMessage(msg);
		
		
		GCTest1 msgTest1 = new GCTest1();
		msgTest1.setTestBoolean(cgTest.getTestBoolean());
		msgTest1.setTestByte(cgTest.getTestByte());
		msgTest1.setTestInteger(cgTest.getTestInteger());
		msgTest1.setTestLong(cgTest.getTestLong());
		msgTest1.setTestString(cgTest.getTestString());
		msgTest1.setTestShort(cgTest.getTestShort());
		msgTest1.setTestLongs(cgTest.getTestLongs());
		msgTest1.setTestIntegers(cgTest.getTestIntegers());
		msgTest1.setTestShorts(cgTest.getTestShorts());
		msgTest1.setTestBytes(cgTest.getTestBytes());
		msgTest1.setTestBooleans(cgTest.getTestBooleans());
		msgTest1.setTestStrings(cgTest.getTestStrings());
		msgTest1.setTest1Model(test1Model);
		player.sendMessage(msgTest1);
//		player.sendMessage(msgTest1);
//		player.sendMessage(msgTest1);
		
//		// XXX test
//		for (int i = 0; i < 1000; i++) {
//			player.sendMessage(msg);
//			player.sendMessage(msgTest1);
//			System.out.println("i="+i);
//			try {
//				Thread.currentThread().sleep(MathUtils.random(50, 100));
//			} catch (InterruptedException e) {
//				// TODO Auto-generated catch block
//				e.printStackTrace();
//			}
//		}
	}
	
	/**
 	* 测试
 	* 
 	* CodeGenerator
 	*/
	public void handleTestLong(Player player, CGTestLong cgTestLong) {
		GCTestLong test = new GCTestLong();
		System.out.println(cgTestLong.getTestLong());
		System.out.println(cgTestLong.getTestString());
		
		Random ran = new Random();
		Long value = Math.abs(ran.nextLong());
		
		System.err.println(value);
		test.setTestLong(value);
		test.setTestString(value.toString());
		player.sendMessage(test);
	}
	
	public void handleTest1(Player player, CGTest1 cgTest) {
		GCTest1 msg = new GCTest1();
		
		msg.setTestBoolean(cgTest.getTestBoolean());
		msg.setTestByte(cgTest.getTestByte());
		msg.setTestInteger(cgTest.getTestInteger());
		msg.setTestLong(cgTest.getTestLong());
		msg.setTestString(cgTest.getTestString());
		msg.setTestShort(cgTest.getTestShort());
		
		msg.setTestLongs(cgTest.getTestLongs());
		msg.setTestIntegers(cgTest.getTestIntegers());
		msg.setTestShorts(cgTest.getTestShorts());
		msg.setTestBytes(cgTest.getTestBytes());
		msg.setTestBooleans(cgTest.getTestBooleans());
		msg.setTestStrings(cgTest.getTestStrings());
		
		player.sendMessage(msg);
	}
	
//	/**
// 	* 测试MODEL
// 	* 
// 	* CodeGenerator
// 	*/
//	public void handleTestModel(Player player, CGTestModel cgTestModel) {
//		GCTestModel msg = new GCTestModel();
//		msg.setTestList(cgTestModel.getTestList());
//		player.sendMessage(msg);
//	}
//		/**
// 	* 测试MODEL
// 	* 
// 	* CodeGenerator
// 	*/
//	public void handleTestModelList(Player player, CGTestModelList cgTestModelList) {
//		GCTestModelList msg = new GCTestModelList();
//		msg.setTestList(cgTestModelList.getTestList());
//		player.sendMessage(msg);
//	}
//		/**
// 	* 更新单个道具信息，客户端受到此消息就替换原来此位置的道具
// 	* 
// 	* CodeGenerator
// 	*/
//	public void handleTestMutiList(Player player, CGTestMutiList cgTestMutiList) {
//		GCTestMutiList msg = new GCTestMutiList();
//		msg.setTestBoolean(cgTestMutiList.getTestBoolean());
//		msg.setTestByte(cgTestMutiList.getTestByte());
//		msg.setTestInteger(cgTestMutiList.getTestInteger());
//		msg.setTestLong(cgTestMutiList.getTestLong());
//		msg.setTestShort(cgTestMutiList.getTestShort());
//		msg.setTestString(cgTestMutiList.getTestString());
//		msg.setTestMutiList(cgTestMutiList.getTestMutiList());
//		player.sendMessage(msg);
//	}
}
