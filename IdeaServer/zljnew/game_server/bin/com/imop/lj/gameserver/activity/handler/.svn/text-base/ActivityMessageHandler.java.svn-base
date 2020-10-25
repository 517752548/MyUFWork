package com.imop.lj.gameserver.activity.handler;

import com.imop.lj.gameserver.activity.msg.CGActivityList;
import com.imop.lj.gameserver.activity.msg.CGClickAcitvity;
import com.imop.lj.gameserver.activity.template.ActivityTemplate;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;

/**
 * 点击活动
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class ActivityMessageHandler {

	public ActivityMessageHandler() {
	}

	/**
	 * 打开活动面板
	 * 
	 * CodeGenerator
	 */
	public void handleActivityList(Player player, CGActivityList cgActivityList) {
		if(player == null){
			return;
		}
		
		Globals.getActivityService().noticeActivity(player.getHuman());
	}

	/**
	 * 点击活动
	 * 
	 * CodeGenerator
	 */
	public void handleClickAcitvity(Player player, CGClickAcitvity cgClickAcitvity) {
		if(player == null){
			return ;
		}
		int activityType = cgClickAcitvity.getActivityId();
		ActivityTemplate tmpl = Globals.getTemplateCacheService().get(activityType, ActivityTemplate.class);
		tmpl.getActivityFunction().onClick(player.getHuman());
	}
	
}
