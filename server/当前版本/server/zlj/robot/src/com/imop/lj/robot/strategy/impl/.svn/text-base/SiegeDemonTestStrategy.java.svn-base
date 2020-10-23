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
import com.imop.lj.gameserver.map.msg.GCMapAddNpc;
import com.imop.lj.gameserver.siegedemon.msg.CGSiegedemonAnswerEnterTeam;
import com.imop.lj.gameserver.siegedemon.msg.CGSiegedemonAskEnterTeam;
import com.imop.lj.gameserver.siegedemon.msg.CGSiegedemonLeave;
import com.imop.lj.gameserver.siegedemon.msg.GCSiegedemonAskEnterTeam;
import com.imop.lj.gameserver.team.msg.CGTeamCreate;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class SiegeDemonTestStrategy extends OnceExecuteStrategy {
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
	
	public SiegeDemonTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		
		//组队
//		CGTeamCreate teamMsg = new CGTeamCreate();
//		this.sendMessage(teamMsg);
		
		//离开副本
//		CGSiegedemonLeave leave = new CGSiegedemonLeave(siegeType);
//		this.sendMessage(leave);
		
		
		
		
	}

	@Override
	public void onResponse(IMessage message) {
		//创建队伍
//		if (message instanceof GCSystemMessage) {
//			GCSystemMessage msg = (GCSystemMessage) message;
//			if(msg.getContent().contains("创建队伍成功")){
//				//进入副本
//				CGSiegedemonAskEnterTeam askMsg = new CGSiegedemonAskEnterTeam(siegeType);
//				this.sendMessage(askMsg);
//			}
//		}
		
		
		//应答
		if (message instanceof GCSiegedemonAskEnterTeam) {
			CGSiegedemonAnswerEnterTeam anMsg = new CGSiegedemonAnswerEnterTeam(1, siegeType);
			this.sendMessage(anMsg);
			
			
			
		}
		//挑战npc
//		if (message instanceof GCMapAddNpc) {
//			int npcId = ((GCMapAddNpc)message).getNpcInfoData().getNpcId();
//			String uuid = ((GCMapAddNpc)message).getNpcInfoData().getUuid();
//			CGMapFightNpc fight = new CGMapFightNpc(npcId, uuid);
//			this.sendMessage(fight);
//		}
	}
	
}
