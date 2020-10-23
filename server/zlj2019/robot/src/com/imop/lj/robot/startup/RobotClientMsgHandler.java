package com.imop.lj.robot.startup;

import java.lang.reflect.Field;
import java.lang.reflect.Modifier;
import java.util.HashSet;
import java.util.Set;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.msg.MessageType;
import com.imop.lj.core.server.IMessageHandler;
import com.imop.lj.core.session.MinaSession;
import com.imop.lj.gameserver.common.msg.GCHandshake;
import com.imop.lj.gameserver.common.msg.GCMessage;
import com.imop.lj.gameserver.item.msg.GCBagUpdate;
import com.imop.lj.gameserver.player.msg.GCEnterScene;
import com.imop.lj.gameserver.player.msg.GCRoleList;
import com.imop.lj.gameserver.player.msg.GCRoleTemplate;
import com.imop.lj.gameserver.player.msg.GCSceneInfo;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.RobotManager;
import com.imop.lj.robot.strategy.IRobotStrategy;

public class RobotClientMsgHandler implements IMessageHandler<IMessage> {

	private Robot getRobot(IMessage message)
	{
		MinaSession minaSession = (MinaSession)((GCMessage)message).getSession();
		return RobotManager.getInstance().getRobot(minaSession);
	}

	@Override
	public void execute(IMessage message) {
		Robot robot = getRobot(message);
		if(message instanceof GCHandshake)
		{
			robot.doLogin();
		}
		if(message instanceof GCEnterScene)
		{
			robot.doEnterScene();
		}
		else if(message instanceof GCRoleList)
		{
			GCRoleList gcRoleList = (GCRoleList)message;
			robot.handleGCRoleList(robot, gcRoleList.getRoleList(), gcRoleList.getSelectedIndex());
		}
		else if(message instanceof GCRoleTemplate)
		{
			//如果
			GCRoleTemplate gcRoleTemplate = (GCRoleTemplate)message;
			robot.handleGcRoleTemplate(robot,gcRoleTemplate.getCreatePetInfoList());
		}
		else if(message instanceof GCSceneInfo)
		{
			robot.handleGCSceneInfo(robot);
		}
		else if(message instanceof GCBagUpdate)
		{
			robot.getBagManager().init((GCBagUpdate)message);
		}
//		else if (message instanceof GCItemUpdate)
//		{
//			robot.getBagManager().updateItem(((GCItemUpdate)message).getItem());
//		}
//		else if (message instanceof GCSecretaryList)
//		{
//			robot.getPetManager().init((GCSecretaryList)message);
//		}//GC_BRANCH_INFO_LIST
//		else if (message instanceof GCBranchInfoList)
//		{
//			robot.getBranchManager().init((GCBranchInfoList)message);
//		}
//		else if (message instanceof GCBranchInfo)
//		{
//			robot.getBranchManager().updateBranchInfo((GCBranchInfo)message);
//		}

		else
		{
			for(IRobotStrategy strategy : robot.getStrategyList())
			{
				strategy.onResponse(message);
			}
		}
	}

	@Override
	public short[] getTypes() {
		Class<MessageType> mtClazz = MessageType.class;
		Field[] fields = mtClazz.getDeclaredFields();
		Field.setAccessible(fields, true);
		short[] types = new short[0];
		try {
			Set<Short> msgNumSet = new HashSet<Short>();
			for (int i = 0; i < fields.length; i++) {
				String fName = fields[i].getName();
				if (fName.length() <= 3)
					continue;
				String prefix = fName.substring(0, 3);
				if ((prefix.equals("CG_") || prefix.equals("GC_")) && ((fields[i].getModifiers() & Modifier.STATIC) != 0)
						& ((fields[i].getModifiers() & Modifier.FINAL) != 0)) {
					short messageNumber = fields[i].getShort(null);
					if (messageNumber <= 0) {
						throw new RuntimeException("消息号溢出！！");
					} else if (msgNumSet.contains(messageNumber)) {
						throw new RuntimeException(String.format("%s消息号与其他消息号冲突", fName));
					}
					msgNumSet.add(messageNumber);
				}
			}
			types = new short[msgNumSet.size()];
			int i = 0;
			for(short type : msgNumSet){
				types[i] = type;
				i++;
			}
			System.out.println(types);
		} catch (Exception e) {
			e.printStackTrace();
		}
		return types;
	}

	public static void main(String[] args){
		Class<MessageType> mtClazz = MessageType.class;
		Field[] fields = mtClazz.getDeclaredFields();
		Field.setAccessible(fields, true);
		short[] types = new short[0];
		try {
			Set<Short> msgNumSet = new HashSet<Short>();
			for (int i = 0; i < fields.length; i++) {
				String fName = fields[i].getName();
				if (fName.length() <= 3)
					continue;
				String prefix = fName.substring(0, 3);
				if ((prefix.equals("CG_") || prefix.equals("GC_")) && ((fields[i].getModifiers() & Modifier.STATIC) != 0)
						& ((fields[i].getModifiers() & Modifier.FINAL) != 0)) {
					short messageNumber = fields[i].getShort(null);
					if (messageNumber <= 0) {
						throw new RuntimeException("消息号溢出！！");
					} else if (msgNumSet.contains(messageNumber)) {
						throw new RuntimeException(String.format("%s消息号与其他消息号冲突", fName));
					}
					msgNumSet.add(messageNumber);
				}
			}
			types = new short[msgNumSet.size()];
			int i = 0;
			for(short type : msgNumSet){
				types[i] = type;
				i++;
			}
			System.out.println(types);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
