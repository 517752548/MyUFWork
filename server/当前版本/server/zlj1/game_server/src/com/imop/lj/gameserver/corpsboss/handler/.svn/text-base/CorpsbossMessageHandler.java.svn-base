package com.imop.lj.gameserver.corpsboss.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsBossInfo;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsbossAskEnterTeam;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsbossAnswerEnterTeam;
import com.imop.lj.gameserver.corpsboss.msg.CGWatchCorpsBoss ;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsbossRankList;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsbossRankReplay;
import com.imop.lj.gameserver.corpsboss.msg.CGCorpsbossCountRankList;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class CorpsbossMessageHandler {	
	
	public CorpsbossMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player, boolean isLowerLevel){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if(!isLowerLevel){
			if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.CORPS_BOSS)) {
				Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.CORPS_BOSS);
				return false;
			}
		}
		if(!Globals.getCorpsBossService().isOpening()){
			return false;
		}
		return true;
	}
	
		/**
 	* 查看当前队长或个人的boss情况
 	* 
 	* CodeGenerator
 	*/
	public void handleCorpsBossInfo(Player player, CGCorpsBossInfo cgCorpsBossInfo) {
		if(!checkRoleAndFunc(player, false)){
			return;
		}
		
		Globals.getCorpsBossService().sendCorpsBossInfo(player.getHuman());
		
	}
		/**
 	* 队长请求挑战帮派boss
 	* 
 	* CodeGenerator
 	*/
	public void handleCorpsbossAskEnterTeam(Player player, CGCorpsbossAskEnterTeam cgCorpsbossAskEnterTeam) {
		if(!checkRoleAndFunc(player, false)){
			return;
		}
		
		int level = cgCorpsbossAskEnterTeam.getBossLevel();
		if(!Globals.getTemplateCacheService().getCorpsTemplateCache().isValidBossLevel(level)){
			return;
		}
		Globals.getCorpsBossService().askEnterCorpsBoss(player.getHuman(), level);
	}
		/**
 	* 应答挑战帮派boss的请求
 	* 
 	* CodeGenerator
 	*/
	public void handleCorpsbossAnswerEnterTeam(Player player, CGCorpsbossAnswerEnterTeam cgCorpsbossAnswerEnterTeam) {
		if(!checkRoleAndFunc(player, false)){
			return;
		}
		
		boolean isAgree = cgCorpsbossAnswerEnterTeam.getAgree() == 1 ? true : false;;
		Globals.getCorpsBossService().answerEnterCorpsBoss(player.getHuman(), isAgree);
	}
		/**
 	* 查看本帮最高纪录
 	* 
 	* CodeGenerator
 	*/
	public void handleWatchCorpsBoss (Player player, CGWatchCorpsBoss cgWatchCorpsBoss ) {
		if(!checkRoleAndFunc(player, true)){
			return;
		}
		
		Globals.getCorpsBossService().watchCorpsBossReplay(player.getHuman());
	}
		/**
 	* 请求帮派boss排行榜
 	* 
 	* CodeGenerator
 	*/
	public void handleCorpsbossRankList(Player player, CGCorpsbossRankList cgCorpsbossRankList) {
		if(!checkRoleAndFunc(player, true)){
			return;
		}
		
		Globals.getCorpsBossService().showRankList(player.getHuman());
	}
		/**
 	* 请求帮派boss挑战次数排行榜
 	* 
 	* CodeGenerator
 	*/
	public void handleCorpsbossCountRankList(Player player, CGCorpsbossCountRankList cgCorpsbossCountRankList) {
		if(!checkRoleAndFunc(player, true)){
			return;
		}
		Globals.getCorpsBossService().showCountRankList(player.getHuman());
	}

	/**
	 * 查看单个排行榜的录像
	 * @param player
	 * @param cgCorpsbossRankReplay
	 */
		public void handleCorpsbossRankReplay(Player player, CGCorpsbossRankReplay cgCorpsbossRankReplay) {
//			if(!checkRoleAndFunc(player, true)){
//				return;
//			}
//			if(cgCorpsbossRankReplay.getRank() > Globals.getGameConstants().getShowBossRankSize()){
//				return;
//			}
//			
//			Globals.getCorpsBossService().watchCorpsBossRankReplay(player.getHuman(), cgCorpsbossRankReplay.getRank());
		}
	}
