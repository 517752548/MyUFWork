package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.constants.SharedConstants;
import com.imop.lj.common.model.NpcInfo;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.gameserver.chat.msg.CGChatMsg;
import com.imop.lj.gameserver.common.msg.GCSystemMessage;
import com.imop.lj.gameserver.item.msg.CGUseItem;
import com.imop.lj.gameserver.map.msg.CGMapFightNpc;
import com.imop.lj.gameserver.map.msg.CGMapPlayerEnter;
import com.imop.lj.gameserver.map.msg.GCMapAddNpcList;
import com.imop.lj.gameserver.team.msg.CGTeamApplyAuto;
import com.imop.lj.gameserver.team.msg.CGTeamCreate;
import com.imop.lj.gameserver.tower.msg.CGOpenDoubleStatus;
import com.imop.lj.gameserver.tower.msg.CGTowerInfo;
import com.imop.lj.gameserver.tower.msg.CGTowerReward;
import com.imop.lj.gameserver.tower.msg.CGWatchBestKillerReplay;
import com.imop.lj.gameserver.tower.msg.CGWatchFirstKillerReplay;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.OnceExecuteStrategy;

/**
 *
 */
public class TowerTestStrategy extends OnceExecuteStrategy {
	/** CG 消息 */
	
	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public TowerTestStrategy(Robot robot, int delay) {
		super(robot, delay);
	}

	@Override
	public void doAction() {
		
		CGChatMsg chatmsg = new CGChatMsg();
		chatmsg.setScope(SharedConstants.CHAT_SCOPE_PRIVATE);
		
		int npcId = 1095;
		int mapId = 24;
		int towerLevel = 1;
		//打开通天塔面板
//		CGTowerInfo reqMsg = new CGTowerInfo();
//		this.sendMessage(reqMsg);
		//更改双倍状态
//		CGOpenDoubleStatus openMsg = new CGOpenDoubleStatus(1);
//		this.sendMessage(openMsg);
		//玩家进入通天塔一层
//		CGMapPlayerEnter enterMsg = new CGMapPlayerEnter(mapId);
//		this.sendMessage(enterMsg);
		//组队
//		CGTeamCreate teamMsg = new CGTeamCreate();
//		this.sendMessage(teamMsg);
		//加入队伍
//		this.sendMessage((new CGTeamApplyAuto(1,1)));
		//自动寻路,遇怪,在LoadTestClickStrategy做了

		
		//查看最先击杀者
//		CGWatchFirstKillerReplay fMsg = new CGWatchFirstKillerReplay(towerLevel);
//		this.sendMessage(fMsg);
		//查看最优击杀者
//		CGWatchBestKillerReplay bMsg = new CGWatchBestKillerReplay(towerLevel);
//		this.sendMessage(bMsg);
		//查看奖励
//		CGTowerReward rewardMsg = new CGTowerReward();
//		this.sendMessage(rewardMsg);
		//发双倍经验丹
//		chatmsg.setContent("!giveitem 20114 2");
//		this.sendMessage(chatmsg);
		
		//使用双倍经验丹
		CGUseItem cgUseItem1 = new CGUseItem(1,44, 1, 1, 0);
		this.sendMessage(cgUseItem1);
	}

	@Override
	public void onResponse(IMessage message) {
		if (message instanceof GCSystemMessage) {
			GCSystemMessage new_name = (GCSystemMessage) message;
			if(new_name.getContent().contains("创建队伍成功")){
				//打固定的NPC,uuid传null
				CGMapFightNpc npcMsg = new CGMapFightNpc(1095,null);
				this.sendMessage(npcMsg);
			}
		}
	}
	
}
