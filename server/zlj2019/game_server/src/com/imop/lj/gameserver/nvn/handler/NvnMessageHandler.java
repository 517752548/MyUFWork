package com.imop.lj.gameserver.nvn.handler;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.nvn.msg.CGNvnCancleMatch;
import com.imop.lj.gameserver.nvn.msg.CGNvnEnter;
import com.imop.lj.gameserver.nvn.msg.CGNvnLeave;
import com.imop.lj.gameserver.nvn.msg.CGNvnOpenPanel;
import com.imop.lj.gameserver.nvn.msg.CGNvnRule;
import com.imop.lj.gameserver.nvn.msg.CGNvnStartMatch;
import com.imop.lj.gameserver.nvn.msg.CGNvnTopRankList;
import com.imop.lj.gameserver.player.Player;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class NvnMessageHandler {	
	
	public NvnMessageHandler() {	
	}	
		/**
 	* 请求进入nvn联赛
 	* 
 	* CodeGenerator
 	*/
	public void handleNvnEnter(Player player, CGNvnEnter cgNvnEnter) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getNvnService().enterNvn(player.getHuman());
	}
	
	public void handleNvnOpenPanel(Player player, CGNvnOpenPanel cgNvnOpenPanel) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getNvnService().openNvnPanel(player.getHuman());
	}
		/**
 	* nvn取消匹配
 	* 
 	* CodeGenerator
 	*/
	public void handleNvnCancleMatch(Player player, CGNvnCancleMatch cgNvnCancleMatch) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getNvnService().cancelMatch(player.getHuman());
	}
		/**
 	* nvn开始匹配
 	* 
 	* CodeGenerator
 	*/
	public void handleNvnStartMatch(Player player, CGNvnStartMatch cgNvnStartMatch) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getNvnService().startMatch(player.getHuman());
	}
		/**
 	* 退出nvn联赛
 	* 
 	* CodeGenerator
 	*/
	public void handleNvnLeave(Player player, CGNvnLeave cgNvnLeave) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getNvnService().leaveNvn(player.getHuman());
	}
	
	/**
	 * nvn联赛规则
	 * @param player
	 * @param cgNvnRule
	 */
	public void handleNvnRule(Player player, CGNvnRule cgNvnRule) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getNvnService().sendNvnRule(player.getHuman());
	}
	
	/**
	 * 请求nvn联赛排行榜
	 * @param player
	 * @param cgNvnTopRankList
	 */
	public void handleNvnTopRankList(Player player, CGNvnTopRankList cgNvnTopRankList) {
		if (player == null || player.getHuman() == null) {
			return;
		}
		
		Globals.getNvnService().sendNvnRankList(player.getHuman());
	}
	
	}
