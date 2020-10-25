package com.imop.lj.gameserver.arena.handler;

import com.imop.lj.gameserver.arena.msg.CGArenaAttackOpponent;
import com.imop.lj.gameserver.arena.msg.CGArenaBattleRecord;
import com.imop.lj.gameserver.arena.msg.CGArenaBuyChallengeTime;
import com.imop.lj.gameserver.arena.msg.CGArenaKillCd;
import com.imop.lj.gameserver.arena.msg.CGArenaRankRewardList;
import com.imop.lj.gameserver.arena.msg.CGArenaRefreshOpponent;
import com.imop.lj.gameserver.arena.msg.CGArenaTopRankList;
import com.imop.lj.gameserver.arena.msg.CGShowArenaPanel;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class ArenaMessageHandler {	
	
	public ArenaMessageHandler() {	
	}	
		/**
 	* 请求显示竞技场面板
 	* 
 	* CodeGenerator
 	*/
	public void handleShowArenaPanel(Player player, CGShowArenaPanel cgShowArenaPanel) {
		if (!checkPlayer(player)) {
			return;
		}
		
		Globals.getArenaService().showArenaPanel(player.getHuman());
	}
		/**
 	* 购买挑战次数
 	* 
 	* CodeGenerator
 	*/
	public void handleArenaBuyChallengeTime(Player player, CGArenaBuyChallengeTime cgArenaBuyChallengeTime) {
		if (!checkPlayer(player)) {
			return;
		}
		
		Globals.getArenaService().buyChallengeTimes(player.getHuman());
	}
		/**
 	* 显示竞技场榜首信息
 	* 
 	* CodeGenerator
 	*/
	public void handleArenaTopRankList(Player player, CGArenaTopRankList cgArenaTopRankList) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getArenaService().showTopRankList(player.getHuman());
	}
		/**
 	* 攻击挑战列表对手
 	* 
 	* CodeGenerator
 	*/
	public void handleArenaAttackOpponent(Player player, CGArenaAttackOpponent cgArenaAttackOpponent) {
		if (!checkPlayer(player)) {
			return;
		}
		
		int targetNum = cgArenaAttackOpponent.getTargetNum();
		if (targetNum <= 0) {
			return;
		}
		
		Globals.getArenaService().attack(player.getHuman(), targetNum);
	}
	
	/**
	 * 请求刷新对手列表
	 * @param player
	 * @param cgArenaRefreshOpponent
	 */
	public void handleArenaRefreshOpponent(Player player, CGArenaRefreshOpponent cgArenaRefreshOpponent) {
		if (!checkPlayer(player)) {
			return;
		}
		
		Globals.getArenaService().refreshOpponent(player.getHuman());
	}
		/**
 	* 消除竞技场cd
 	* 
 	* CodeGenerator
 	*/
	public void handleArenaKillCd(Player player, CGArenaKillCd cgArenaKillCd) {
		if (!checkPlayer(player)) {
			return;
		}
		
		Globals.getArenaService().killCdTime(player.getHuman());
	}
		/**
 	* 请求竞技场战斗记录
 	* 
 	* CodeGenerator
 	*/
	public void handleArenaBattleRecord(Player player, CGArenaBattleRecord cgArenaBattleRecord) {
		if (!checkPlayer(player)) {
			return;
		}
		
		Globals.getArenaService().showBattleLogList(player.getHuman());
	}
		/**
 	* 竞技场排名奖励列表
 	* 
 	* CodeGenerator
 	*/
	public void handleArenaRankRewardList(Player player, CGArenaRankRewardList cgArenaRankRewardList) {
		if (!checkPlayer(player)) {
			return;
		}
		
		Globals.getArenaService().showRankRewardList(player.getHuman());
	}
	
	protected boolean checkPlayer(Player player) {
		if (player == null || player.getHuman() == null) {
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.ARENA)) {
			return false;
		}
		return true;
	}
	
	}
