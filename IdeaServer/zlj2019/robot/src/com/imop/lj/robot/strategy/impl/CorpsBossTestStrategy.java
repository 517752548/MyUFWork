package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.msg.GCSystemMessage;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsBossInfo;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsbossAnswerEnterTeam;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsbossAskEnterTeam;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsbossCountRankList;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsbossRankList;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsbossRankReplay;
import com.imop.lj.gameserver.corpsboss.msg.CGWatchCorpsBoss;
import com.imop.lj.gameserver.corpsboss.msg.GCCorpsbossAskEnterTeam;
import com.imop.lj.gameserver.map.msg.CGMapFightNpc;
import com.imop.lj.gameserver.team.msg.CGTeamCreate;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class CorpsBossTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public int level = 1;
	
	public CorpsBossTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		
		//打开帮派boss信息
		CGCorpsBossInfo bossMsg = new CGCorpsBossInfo();
		this.sendMessage(bossMsg);
		//组队
//		CGTeamCreate teamMsg = new CGTeamCreate();
//		this.sendMessage(teamMsg);
		//挑战boss
//		CGCorpsbossAskEnterTeam askMsg = new CGCorpsbossAskEnterTeam(level);
//		this.sendMessage(askMsg);
		//查看最高纪录
//		CGWatchCorpsBoss replayMsg = new CGWatchCorpsBoss();
//		this.sendMessage(replayMsg);
		//查看boss进度榜
//		CGCorpsbossRankList rankMsg = new CGCorpsbossRankList();
//		this.sendMessage(rankMsg);
		//查看boss挑战次数进度榜
//		CGCorpsbossCountRankList countMSg = new CGCorpsbossCountRankList();
//		this.sendMessage(countMSg);
		//查看单一排行榜战报
		CGCorpsbossRankReplay playMsg = new CGCorpsbossRankReplay(1);
		this.sendMessage(playMsg);
		
		
	}

	@Override
	public void onResponse(IMessage message) {
		if (message instanceof GCSystemMessage) {
			GCSystemMessage msg = (GCSystemMessage) message;
			if(msg.getContent().contains("创建队伍成功")){
				//挑战boss
				CGCorpsbossAskEnterTeam askMsg = new CGCorpsbossAskEnterTeam(level);
				this.sendMessage(askMsg);
			}
		}
		
		//应答
		if (message instanceof GCCorpsbossAskEnterTeam) {
			CGCorpsbossAnswerEnterTeam anMsg = new CGCorpsbossAnswerEnterTeam(1);
			this.sendMessage(anMsg);
			
			
		}
	}
	
}
