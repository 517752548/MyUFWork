package com.imop.lj.gameserver.rank.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.rank.msg.CGRankApply;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class RankMessageHandler {	
	
	public RankMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.RANK)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.RANK);
			return false;
		}
		return true;
	}
	
		/**
 	* 申请排行榜信息
 	* 
 	* CodeGenerator
 	*/
	public void handleRankApply(Player player, CGRankApply cgRankApply) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		if (cgRankApply == null) {
			return;
		}
		if(cgRankApply.getRankType() <= 0){
			return;
		}
		Globals.getRankService().applyRank(player.getHuman(), cgRankApply.getRankType(), cgRankApply.getTimeId());
	}
	}
