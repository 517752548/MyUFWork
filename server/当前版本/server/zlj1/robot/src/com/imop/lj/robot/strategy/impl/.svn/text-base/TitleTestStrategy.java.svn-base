package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.corps.msg.CGCorpsBatchAddApplyMember;
import com.imop.lj.gameserver.corps.msg.CGCorpsBatchFireMember;
import com.imop.lj.gameserver.corps.msg.CGCorpsQuickApply;
import com.imop.lj.gameserver.corps.msg.CGCreateCorps;
import com.imop.lj.gameserver.overman.msg.CGOverman;
import com.imop.lj.gameserver.team.msg.CGTeamApply;
import com.imop.lj.gameserver.team.msg.CGTeamCreate;
import com.imop.lj.gameserver.title.msg.CGTitlePanel;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class TitleTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public TitleTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		/**
		 * 不符合条件
		 */

		
		/**
		 * 符合条件
		 */
		
//		CGChatMsg chatmsg2 = new CGChatMsg();
//		chatmsg2.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg2.setContent("!givemoney 2 10000000");
//		this.sendMessage(chatmsg2);
		
		
		//帮会称号
		long[] targetIds ={288516249174941512L};
		
		//test4创建帮会
//		testCreateCorps();
		//test5申请帮会
//		testQuickApply();
		//test4同意加入
//		testApplyMember(targetIds);
		//查看称号
//		testShowTitle();
		//test4剔除成员
//		testFireMember(targetIds);
		
		
		
		
		//师徒称号
		
		//组队，test4是队长，test5是组员
		CGTeamCreate cTeamMsg = new CGTeamCreate();
		this.sendMessage(cTeamMsg);
		int teamId = 0;
		CGTeamApply aTeamMsg = new CGTeamApply(teamId);
		this.sendMessage(aTeamMsg);
		
		
		//test5申请拜test4为师
		CGOverman baiMsg = new CGOverman(1);
		this.sendMessage(baiMsg);
		
		
		
		
		
		
		
	}

	private void testFireMember(long[] targetIds) {
		CGCorpsBatchFireMember fireMsg = new CGCorpsBatchFireMember(targetIds);
		this.sendMessage(fireMsg);
	}

	private void testApplyMember(long[] targetIds) {
		CGCorpsBatchAddApplyMember addMsg = new CGCorpsBatchAddApplyMember(targetIds);
		this.sendMessage(addMsg);
	}

	private void testQuickApply() {
		CGCorpsQuickApply applyMsg = new CGCorpsQuickApply();
		this.sendMessage(applyMsg);
	}

	private void testCreateCorps() {
		CGCreateCorps createMsg = new CGCreateCorps("测试称号专用", "测试称号专用帮会");
		this.sendMessage(createMsg);
	}

	private void testShowTitle() {
		CGTitlePanel titlePanelMsg = new CGTitlePanel();
		this.sendMessage(titlePanelMsg);
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
