
package com.imop.lj.gameserver.goodactivity.handler;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.goodactivity.msg.CGGoodActivityGetBonus;
import com.imop.lj.gameserver.goodactivity.msg.CGGoodActivityList;
import com.imop.lj.gameserver.player.Player;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class GoodactivityMessageHandler {	
	
	public GoodactivityMessageHandler() {	
	}	
		/**
 	* 打开精彩活动面板
 	* 
 	* CodeGenerator
 	*/
	public void handleGoodActivityList(Player player, CGGoodActivityList cgGoodActivityList) {
		if (!checkCond(player)) {
			return;
		}
		
		int funcId = cgGoodActivityList.getFuncId();
		if (funcId != FuncTypeEnum.GOOD_ACTIVITY.getIndex()
				&& funcId != FuncTypeEnum.GOOD_ACTIVITY2.getIndex()) {
			return;
		}
		
		Globals.getGoodActivityService().openGoodActivityPanel(player.getHuman(), FuncTypeEnum.valueOf(funcId));
	}
		/**
 	* 领取活动奖励
 	* 
 	* CodeGenerator
 	*/
	public void handleGoodActivityGetBonus(Player player, CGGoodActivityGetBonus cgGoodActivityGetBonus) {
		if (!checkCond(player)) {
			return;
		}
		
		long activityId = cgGoodActivityGetBonus.getActivityId();
		int bonusIndex = cgGoodActivityGetBonus.getBonusId();
		if (activityId <= 0 || bonusIndex < 0) {
			return;
		}
		
		Globals.getGoodActivityService().giveBonus(player.getHuman(), activityId, bonusIndex);
	}
	
	protected boolean checkCond(Player player) {
		if (player == null || player.getHuman() == null) {
			return false;
		}
		// 功能是否开启
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.GOOD_ACTIVITY)) {
			return false;
		}
		return true;
	}
	
	}
