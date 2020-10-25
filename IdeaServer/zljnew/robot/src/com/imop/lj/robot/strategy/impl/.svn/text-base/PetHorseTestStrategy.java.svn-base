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
import com.imop.lj.gameserver.pet.msg.CGPetHorseRefreshTalentSkill;
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
		
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 10034 5");
		
		long petId = 288516249175097038L;

		//发骑宠卡
//		CGChatMsg chatmsg2 = new CGChatMsg();
//		chatmsg2.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg2.setContent("!giveitem 20050 1");
//		this.sendMessage(chatmsg2);
		
		//使用骑宠卡
//		CGUseItem cgUseItem1 = new CGUseItem(1,4, 1, 1, 0);
//		this.sendMessage(cgUseItem1);
		//骑乘
//		CGPetHorseRide rideMsg = new CGPetHorseRide(petId,0);
//		this.getRobot().sendMessage(rideMsg);
		
		//升级是否是否有剩余点
		
		//加点
		
		//还童
		
		//刷天赋
		CGPetHorseRefreshTalentSkill skill = new CGPetHorseRefreshTalentSkill(petId);
		this.sendMessage(skill);
		
		//设置资质丹
		
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
