package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.item.msg.CGUseItem;
import com.imop.lj.gameserver.pet.msg.CGPetAddPoint;
import com.imop.lj.gameserver.pet.msg.CGPetChangeFightState;
import com.imop.lj.gameserver.pet.msg.CGPetChangeName;
import com.imop.lj.gameserver.pet.msg.CGPetFire;
import com.imop.lj.gameserver.pet.msg.CGPetHorseArtifice;
import com.imop.lj.gameserver.pet.msg.CGPetHorseChangeName;
import com.imop.lj.gameserver.pet.msg.CGPetHorseFire;
import com.imop.lj.gameserver.pet.msg.CGPetHorseRejuven;
import com.imop.lj.gameserver.pet.msg.CGPetHorseRide;
import com.imop.lj.gameserver.pet.msg.CGPetHorseTrain;
import com.imop.lj.gameserver.pet.msg.CGPetHorseTrainUpdate;
import com.imop.lj.gameserver.pet.msg.CGPetRefreshTalentSkill;
import com.imop.lj.gameserver.pet.msg.CGPetStudyNormalSkill;
import com.imop.lj.gameserver.pet.msg.CGPetTrain;
import com.imop.lj.gameserver.pet.msg.CGPetTrainUpdate;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class PetHorseTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public PetHorseTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		
//		chatmsg.setContent("!updatepet 288516249174934505 exp 20");
//		chatmsg.setContent("!givemoney 2 999999");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40007 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40008 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40009 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40010 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40011 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40012 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40013 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40014 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40015 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40016 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40017 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40018 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40019 5");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!giveitem 40020 5");
//		this.getRobot().sendMessage(chatmsg);
		
		
		long petId = 288516249175126640L;

		//发骑宠卡
//		CGChatMsg chatmsg2 = new CGChatMsg();
//		chatmsg2.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg2.setContent("!giveitem 20050 1");
//		this.sendMessage(chatmsg2);
		
		//使用骑宠卡
//		CGUseItem cgUseItem1 = new CGUseItem(1,4, 1, 1, 0);
//		this.sendMessage(cgUseItem1);
		//骑乘
		CGPetHorseRide rideMsg = new CGPetHorseRide(petId,0);
		this.getRobot().sendMessage(rideMsg);
		//改名
//		CGPetHorseChangeName msg = new CGPetHorseChangeName(petId, "小明");
//		this.getRobot().sendMessage(msg);
		//升级,看评分是否变化
//		chatmsg.setContent("!giveexp horse 217984");
//		this.getRobot().sendMessage(chatmsg);
		//洗资质
//		chatmsg.setContent("!giveitem 10029 1");
//		this.getRobot().sendMessage(chatmsg);
//		CGPetHorseRejuven rejMsg = new CGPetHorseRejuven(petId);
//		this.sendMessage(rejMsg);
		//洗成长
//		chatmsg.setContent("!giveitem 10030 1");
//		this.getRobot().sendMessage(chatmsg);
//		CGPetHorseArtifice artMsg = new CGPetHorseArtifice(petId);
//		this.sendMessage(artMsg);
		//培养
//		chatmsg.setContent("!giveitem 10032 1");
//		this.getRobot().sendMessage(chatmsg);
//		CGPetHorseTrain msg = new CGPetHorseTrain(petId, 1);
//		this.getRobot().sendMessage(msg);
		
//		chatmsg.setContent("!giveitem 10032 1");
//		this.getRobot().sendMessage(chatmsg);
//		CGPetHorseTrainUpdate msg = new CGPetHorseTrainUpdate(petId);
//		this.getRobot().sendMessage(msg);
		
		//休息
//		CGPetHorseRide rideMsg = new CGPetHorseRide(petId, 0);
//		this.getRobot().sendMessage(rideMsg);
////		//放生
//		CGPetHorseFire msg = new CGPetHorseFire(petId);
//		this.getRobot().sendMessage(msg);
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
