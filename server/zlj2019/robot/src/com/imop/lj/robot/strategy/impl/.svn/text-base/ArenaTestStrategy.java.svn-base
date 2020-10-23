package com.imop.lj.robot.strategy.impl;

import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.arena.msg.CGArenaRankRewardList;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class ArenaTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public ArenaTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
//		CGChatMsg chatmsg = new CGChatMsg();
//		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
//		chatmsg.setContent("!givemoney 1 11111");
//		this.sendMessage(chatmsg);
		
//		CGShowArenaPanel tmsg = new CGShowArenaPanel();
//		this.sendMessage(tmsg);
		
//		CGArenaBuyChallengeTime msg = new CGArenaBuyChallengeTime();
//		this.sendMessage(msg);
		
//		CGArenaTopRankList msg = new CGArenaTopRankList();
//		this.sendMessage(msg);
		
//		CGArenaAttackOpponent msg = new CGArenaAttackOpponent(2);
//		this.sendMessage(msg);
		
//		CGArenaRefreshOpponent msg = new CGArenaRefreshOpponent();
//		this.sendMessage(msg);
		
//		CGArenaKillCd msg = new CGArenaKillCd();
//		this.sendMessage(msg);
		
		CGArenaRankRewardList msg = new CGArenaRankRewardList();
		this.sendMessage(msg);
		
	}

	@Override
	public void onResponse(IMessage message) {
		System.out.println("Robot onResponse");
	}
}
