package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.battle.msg.CGPlayBattleReport;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.humanskill.msg.CGHsSubSkillUpgrade;
import com.imop.lj.gameserver.pet.msg.CGAddPetSkillbarNum;
import com.imop.lj.gameserver.pet.msg.CGPetAddPoint;
import com.imop.lj.gameserver.pet.msg.CGPetAffination;
import com.imop.lj.gameserver.pet.msg.CGPetChangeFightState;
import com.imop.lj.gameserver.pet.msg.CGPetChangeName;
import com.imop.lj.gameserver.pet.msg.CGPetEmbedSkillEffect;
import com.imop.lj.gameserver.pet.msg.CGPetFire;
import com.imop.lj.gameserver.pet.msg.CGPetLeaderStudySkill;
import com.imop.lj.gameserver.pet.msg.CGPetRefreshTalentSkill;
import com.imop.lj.gameserver.pet.msg.CGPetSkillEffectOpenPosition;
import com.imop.lj.gameserver.pet.msg.CGPetSkillEffectUplevel;
import com.imop.lj.gameserver.pet.msg.CGPetStudyNormalSkill;
import com.imop.lj.gameserver.pet.msg.CGPetTrain;
import com.imop.lj.gameserver.pet.msg.CGPetTrainUpdate;
import com.imop.lj.gameserver.pet.msg.CGPutonPetPropItem;
import com.imop.lj.gameserver.player.msg.CGChargeGenOrderid;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class PetTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public PetTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		this.getRobot().sendMessage(new CGHsSubSkillUpgrade(11904));
		
//		CGPlayBattleReport msg = new CGPlayBattleReport();
//		this.getRobot().sendMessage(msg);
//		this.getRobot().sendMessage(msg);
//		this.getRobot().sendMessage(msg);
//		this.getRobot().sendMessage(msg);
//		this.getRobot().sendMessage(msg);
		
//		CGChatMsg chatmsg = new CGChatMsg();
//		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg.setContent("!giveitem 60003 5");
//		this.getRobot().sendMessage(chatmsg);
		
//		int itemTplId = 70001;
//		CGPetLeaderStudySkill msg1 = new CGPetLeaderStudySkill(itemTplId);
//		this.getRobot().sendMessage(msg1);
		
//		int skillId = 33333;
//		CGPetSkillEffectOpenPosition msg2 = new CGPetSkillEffectOpenPosition(skillId);
//		this.getRobot().sendMessage(msg2);
		
//		int posId = 2;
//		int itemIndex = 2;
//		CGPetEmbedSkillEffect msg3 = new CGPetEmbedSkillEffect(skillId, posId, itemIndex);
//		this.getRobot().sendMessage(msg3);
		
//		int[] itemIndexList = {9};
//		CGPetSkillEffectUplevel msg4 = new CGPetSkillEffectUplevel(skillId, posId, itemIndexList);
//		this.getRobot().sendMessage(msg4);
		
//		CGChatMsg chatmsg = new CGChatMsg();
//		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
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
		
//		int tplId = 104001;
//		CGSummonPet msg1 = new CGSummonPet(tplId);
//		this.getRobot().sendMessage(msg1);
		
//		long petId = 288516249174934505L;

//		int[] addArr = {1,2,1,0,0};
//		CGPetAddPoint msg = new CGPetAddPoint(petId, addArr);
//		
//		this.getRobot().sendMessage(msg);
		
//		CGPetChangeFightState msg = new CGPetChangeFightState(petId, 1);
//		this.getRobot().sendMessage(msg);
		
//		CGPetChangeName msg = new CGPetChangeName(petId, "小明");
//		this.getRobot().sendMessage(msg);
//		
//		CGPetFire msg = new CGPetFire(petId);
//		this.getRobot().sendMessage(msg);
		
//		CGPetRefreshTalentSkill msg = new CGPetRefreshTalentSkill(petId);
//		this.getRobot().sendMessage(msg);
		
//		for (int i = 40007; i <= 40020; i++) {
//			int itemTplId = i;
//			CGPetStudyNormalSkill msg = new CGPetStudyNormalSkill(petId, itemTplId);
//			this.getRobot().sendMessage(msg);
//		}
		
//		CGPetTrain msg = new CGPetTrain(petId, 1);
//		this.getRobot().sendMessage(msg);
		
//		CGPetTrainUpdate msg = new CGPetTrainUpdate(petId);
//		this.getRobot().sendMessage(msg);
		
		long petId = 288516249174934506L;
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		
//		chatmsg.setContent("!giveitem 10132 1");
//		chatmsg.setContent("!updatepet 288516249174934506 exp 20");
//		chatmsg.setContent("!givemoney 2 999999");
		
		chatmsg.setContent("!giveitem 20219 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20220 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20221 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20222 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20223 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20224 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20225 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20226 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20227 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20228 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20229 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20230 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20231 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20232 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20233 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20234 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20235 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20236 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20237 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20238 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20239 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20240 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20241 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20242 1");
		this.getRobot().sendMessage(chatmsg);
		chatmsg.setContent("!giveitem 20243 1");
		this.getRobot().sendMessage(chatmsg);

		
		this.getRobot().sendMessage(chatmsg);
		//给宠物
		
		//宠物洗炼
//		CGPetAffination aff = new CGPetAffination(petId);
//		this.sendMessage(aff);
		
		//扩充技能栏
//		CGAddPetSkillbarNum bar = new CGAddPetSkillbarNum(petId);
//		this.sendMessage(bar);
		//上资质丹
		int targetIndex = 6;
		int propItemIndex = 2;
		CGPutonPetPropItem putOn = new CGPutonPetPropItem(petId, targetIndex, propItemIndex);
		this.sendMessage(putOn);
		//升级宠物
//		chatmsg.setContent("!giveexp leader 10000");
//		this.getRobot().sendMessage(chatmsg);
//		chatmsg.setContent("!updatepet 288516249174934506 exp 5808");
//		this.getRobot().sendMessage(chatmsg);
		
		
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}