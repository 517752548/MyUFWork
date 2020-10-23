package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.lifeskill.msg.CGCancelLifeSkill;
import com.imop.lj.gameserver.lifeskill.msg.CGLifeSkillUpgrade;
import com.imop.lj.gameserver.lifeskill.msg.CGUseLifeSkill;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class LifeSkillTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	int siegeType = 1;//普通
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public int level = 1;
	
	public LifeSkillTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
//		CGChatMsg chatmsg = new CGChatMsg();
//		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg.setContent("!givemoney 11 1000");
//		this.sendMessage(chatmsg);
		
		int itemId = 100001;
		int skillId = 110001;
		int resourceId = 5001;
		
		//升级
//		CGLifeSkillUpgrade upgrade = new CGLifeSkillUpgrade(itemId);
//		this.sendMessage(upgrade);
//		
		//使用
		CGUseLifeSkill use = new CGUseLifeSkill(skillId, resourceId);
		this.sendMessage(use);
//		
//		
//		//取消
//		CGCancelLifeSkill cancel = new CGCancelLifeSkill();
//		this.sendMessage(cancel);
		
		
		
	}

	@Override
	public void onResponse(IMessage message) {
		
	}
	
}
