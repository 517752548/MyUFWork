package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.humanskill.msg.CGHsMainSkillUpgrade;
import com.imop.lj.gameserver.humanskill.msg.CGHsSubSkillUpgrade;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class HumanSkillTestStrategy extends OnceExecuteStrategy {
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
	
	public HumanSkillTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		chatmsg.setContent("!giveitem 71001 1");
		this.sendMessage(chatmsg);
		//术士错误数据
		int wrongMindId = 1;
		int wrongSkillId = 1;
		int wrongPos = -1;
		int wrongItemId = 1;
		
		//术士正确数据
		int rightMindId = 7;
		int rightSkillId = 814001;
		int rightPos = 0;
		int rightItemId = 71001;
		
		//查看心法信息 
		
		//心法升级
		CGHsMainSkillUpgrade upgrade = new CGHsMainSkillUpgrade(wrongMindId, 1);
		this.sendMessage(upgrade);
		
		//技能升级
//		CGHsSubSkillUpgrade subUpgrade = new CGHsSubSkillUpgrade(rightItemId);
//		this.sendMessage(subUpgrade);
		
		//设置快捷栏
//		CGHsSubSkillPutonShortcut putOn = new CGHsSubSkillPutonShortcut(rightSkillId, rightPos);
//		this.sendMessage(putOn);
		//取消快捷栏
//		CGHsSubSkillOffShortcut off = new CGHsSubSkillOffShortcut(rightPos);
//		this.sendMessage(off);
		//调整位置
//		CGHsSubSkillShortcutChangePosition change = new CGHsSubSkillShortcutChangePosition(rightSkillId, rightPos);
//		this.sendMessage(change);
		//打开心法技能面板
//		CGHsOpenPanel panel = new CGHsOpenPanel();
//		this.sendMessage(panel);
		
		//使用道具增加熟练度
//		CGHsSubSkillAddProficiency add = new CGHsSubSkillAddProficiency(rightSkillId);
//		this.sendMessage(add);
		
	}

	@Override
	public void onResponse(IMessage message) {
		
	}
	
}
