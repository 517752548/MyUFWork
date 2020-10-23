
package com.imop.lj.gameserver.activityui.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.activityui.msg.CGAcitvityUiReward;
import com.imop.lj.gameserver.activityui.msg.CGAcitvityUiRewardInfo;
import com.imop.lj.gameserver.activityui.msg.CGActivityUi;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class ActivityuiMessageHandler {	
	
	public ActivityuiMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.ACTIVITY_UI)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.ACTIVITY_UI);
			return false;
		}
		return true;
	}
	
		/**
 	* 打开活动UI面板
 	* 
 	* CodeGenerator
 	*/
	public void handleActivityUi(Player player, CGActivityUi cgActivityUi) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		Globals.getActivityUIService().freshActivityUI(player.getHuman());
	}
		/**
 	* 获得活跃度奖励
 	* 
 	* CodeGenerator
 	*/
	public void handleAcitvityUiReward(Player player, CGAcitvityUiReward cgAcitvityReward) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		Globals.getActivityUIService().getRewardByVitality(player.getHuman(),cgAcitvityReward.getVitalityNum());
	}
	/**
 	* 申请获得rewardInfoList
 	* 
 	* CodeGenerator
 	*/
	public void handleAcitvityUiRewardInfo(Player player, CGAcitvityUiRewardInfo cgAcitvityUiRewardInfo) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		Globals.getActivityUIService().getRewardInfoList(player.getHuman());
	}
	
	}
