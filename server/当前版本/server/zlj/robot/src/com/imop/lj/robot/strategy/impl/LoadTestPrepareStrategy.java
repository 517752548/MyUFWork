package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.item.msg.CGUseItem;
import com.imop.lj.gameserver.map.msg.CGMapPlayerEnter;
import com.imop.lj.gameserver.pet.msg.CGPetChangeFightState;
import com.imop.lj.gameserver.pet.msg.CGPetHorseRide;
import com.imop.lj.gameserver.pet.msg.GCAddPet;
import com.imop.lj.gameserver.pet.msg.GCPetHorseCurPropUpdate;
import com.imop.lj.gameserver.wing.msg.CGWingSet;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 * 压力测试前期准备工作
 *
 * @author haijiang.jin
 *
 */
public class LoadTestPrepareStrategy extends OnceExecuteStrategy {

	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 */
	public LoadTestPrepareStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		
		//开启功能
		chatmsg.setContent("!func openall");
		this.sendMessage(chatmsg);
		
		int exp = MathUtils.random(1111111, 111111111);
		//给经验
		chatmsg.setContent("!giveexp leader " + exp);
		this.sendMessage(chatmsg);
		
		//给钱
		chatmsg.setContent("!givemoney 2 22222222");
		this.sendMessage(chatmsg);
		chatmsg.setContent("!givemoney 7 22222222");
		this.sendMessage(chatmsg);
		
		//给宠物
		chatmsg.setContent("!givepet 210001");
		this.sendMessage(chatmsg);
		
		//给翅膀
		chatmsg.setContent("!giveitem 20034 1");
		this.sendMessage(chatmsg);
		//给骑宠
		chatmsg.setContent("!giveitem 20059 1");
		this.sendMessage(chatmsg);

		//使用道具
		this.sendMessage(new CGUseItem(1, 0, 1, 1, 0));
		this.sendMessage(new CGUseItem(1, 1, 1, 1, 0));
		
		//升级宝石
		chatmsg.setContent("!giveitem 10004 999");
		this.sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 10005 999");
		this.sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 10006 999");
		this.sendMessage(chatmsg);
		
		//进地图
		int a = getRobot().getPid() % 2;
		int mapId = a == 0 ? 15 : 16;
		
		this.sendMessage(new CGMapPlayerEnter(mapId));
		
	}

	@Override
	public void onResponse(IMessage msg) {
		//宠物上阵
		if (msg instanceof GCAddPet) {
			GCAddPet msg1 = (GCAddPet)msg;
			if (msg1.getPetInfo().getTplId() == 210001) {
				this.sendMessage(new CGPetChangeFightState(msg1.getPetInfo().getPetId(), 1));
			}
		}
		
		//骑宠上阵
		if (msg instanceof GCPetHorseCurPropUpdate) {
//			if (getRobot().getPid() % 3 == 0) {
				GCPetHorseCurPropUpdate msg1 = (GCPetHorseCurPropUpdate)msg;
				this.sendMessage(new CGPetHorseRide(msg1.getPetId(), 1));
				
				//使用翅膀
				this.sendMessage(new CGWingSet(1001));
//			}
		}

	}
}
