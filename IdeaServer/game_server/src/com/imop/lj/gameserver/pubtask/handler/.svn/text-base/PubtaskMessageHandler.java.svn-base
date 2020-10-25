
package com.imop.lj.gameserver.pubtask.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.pubtask.PubTaskDef.RefreshType;
import com.imop.lj.gameserver.pubtask.msg.CGFinishPubtask;
import com.imop.lj.gameserver.pubtask.msg.CGGiveUpPubtask;
import com.imop.lj.gameserver.pubtask.msg.CGOpenPubtaskPanel;
import com.imop.lj.gameserver.pubtask.msg.CGPubtaskAccept;
import com.imop.lj.gameserver.pubtask.msg.CGPubtaskRefresh;
import com.imop.lj.gameserver.pubtask.msg.CGPubtaskRefreshNew;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class PubtaskMessageHandler {	
	
	public PubtaskMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.PUB)) {
			Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.PUB);
			return false;
		}
		return true;
	}
		/**
 	* 打开酒馆任务面板
 	* 
 	* CodeGenerator
 	*/
	public void handleOpenPubtaskPanel(Player player, CGOpenPubtaskPanel cgOpenPubtaskPanel) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getPubTaskService().openPubTaskPanel(player.getHuman());
	}
		/**
 	* 接受任务
 	* 
 	* CodeGenerator
 	*/
	public void handlePubtaskAccept(Player player, CGPubtaskAccept cgPubtaskAccept) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		if (cgPubtaskAccept.getQuestId() <= 0) {
			return;
		}
		
		Globals.getPubTaskService().acceptTask(player.getHuman(), cgPubtaskAccept.getQuestId());
	}
		/**
 	* 放弃已接任务
 	* 
 	* CodeGenerator
 	*/
	public void handleGiveUpPubtask(Player player, CGGiveUpPubtask cgGiveUpPubtask) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getPubTaskService().giveupTask(player.getHuman());
	}
		/**
 	* 完成任务
 	* 
 	* CodeGenerator
 	*/
	public void handleFinishPubtask(Player player, CGFinishPubtask cgFinishPubtask) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
		Globals.getPubTaskService().finishTask(player.getHuman());
	}
	
	/**
	 * 手动刷新任务
	 * @param player
	 * @param cgPubtaskRefresh
	 */
	@Deprecated
	public void handlePubtaskRefresh(Player player, CGPubtaskRefresh cgPubtaskRefresh) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		
//		Globals.getPubTaskService().refreshTaskManual(player.getHuman());
	}

	/**
	 * 手动刷新任务
	 * @param player
	 * @param cgPubtaskRefresh
	 */
	public void handlePubtaskRefreshNew(Player player, CGPubtaskRefreshNew cgPubtaskRefreshNew) {
		if (!checkRoleAndFunc(player)) {
			return;
		}
		//刷新类型
		if(RefreshType.valueOf(cgPubtaskRefreshNew.getRefreshType()) == null){
			return;
		}
		
		Globals.getPubTaskService().refreshTaskManual(player.getHuman(), cgPubtaskRefreshNew.getRefreshType());
	}
	}
