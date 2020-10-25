package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;

/**
 * 登录时的更新操作，在玩家消息队列中进行
 * 
 * @author yu.zhao
 *
 */
public class UpdateOnPlayerLoginMsg extends SysInternalMessage {

	private Human human;
	
	public UpdateOnPlayerLoginMsg(Human human) {
		this.human = human;
	}
	
	@Override
	public void execute() {
		if (human == null || human.getPlayer() == null) {
			return;
		}
		
		//离线数据增加主将信息
		Globals.getOfflineDataService().addLeaderUserOfflineData(human);
		
		// 新手引导
		Globals.getGuideService().onPlayerLogin(human);
		// 精彩活动
		Globals.getGoodActivityService().onPlayerLogin(human);
		//玩家上线，通知军团
		Globals.getCorpsService().onPlayerOnOrOffline(human.getCharId(), true);
		//发送军团个人信息
		Globals.getCorpsService().sendCorpsMemberInfoByHuman(human);
		//发送定时奖励
		Globals.getOnlineGiftService().handleGetOnlinegiftInfo(human);
		//发送提升功能
		Globals.getPromoteService().noticePromoteInfo(human);
		//限时活动
		Globals.getTimeLimitService().onPlayerLogin(human);
		//加入帮派
		Globals.getCorpsService().onNumRecordDest(human);
		//骑宠亲密度更新
		Globals.getPetService().petHorseCloChecker(human, true);
		//停止开采
		Globals.getLifeSkillService().cancelLifeSkill(human, true);
	}
	
	

}
