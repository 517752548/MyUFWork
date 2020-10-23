package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.SysInternalMessage;
import com.imop.lj.gameserver.common.Globals;

/**
 * 玩家下线处理
 * 
 */
public class OnPlayerOfflineMessage extends SysInternalMessage {
	private long humanId;
	
	public OnPlayerOfflineMessage(long humanId) {
		this.humanId = humanId;
	}
	
	@Override
	public void execute() {
		//组队下线的处理
		Globals.getTeamService().onPlayerOffline(humanId);
		// 通知军团
		Globals.getCorpsService().onPlayerOnOrOffline(humanId, false);
		//绿野仙踪下线处理
		Globals.getWizardRaidService().onPlayerLogout(humanId);
//		if(online){
//			// 当玩家上线时，通知VIP
//			Globals.getVipService().onPlayerOnline(humanId);
//			// 通知商城
//			Globals.getMallService().onPlayerLogin(humanId);
//		} else {
			
//			// 玩家下线---进入演武状态
//			Globals.getPracticeService().startPracticeOffline(humanId, lastCitySceneId);
//		}
//		
//		// 清除离线缓存
//		Globals.getSeeOtherService().removeUserInfoByUUID(humanId);
	}

}
