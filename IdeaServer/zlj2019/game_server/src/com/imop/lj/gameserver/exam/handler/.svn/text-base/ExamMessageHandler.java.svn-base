
package com.imop.lj.gameserver.exam.handler;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.exam.ExamDef.ExamType;
import com.imop.lj.gameserver.exam.msg.CGExamApply;
import com.imop.lj.gameserver.exam.msg.CGExamChose;
import com.imop.lj.gameserver.exam.msg.CGExamUseItem;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.player.Player;
/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class ExamMessageHandler {	
	
	public ExamMessageHandler() {	
	}	
	
	private boolean checkRoleAndFunc(Player player, boolean isTimeLimit){
		if(player == null){
			return false;
		}
		if(player.getHuman() == null){
			return false;
		}
		if(!isTimeLimit){
			if (!Globals.getFuncService().hasOpenedFunc(player.getHuman(), FuncTypeEnum.EXAM)) {
				Loggers.humanLogger.warn("player not open func " + FuncTypeEnum.EXAM);
				return false;
			}
		}
		return true;
	}
	
		/**
 	* 申请答题
 	* 
 	* CodeGenerator
 	*/
	public void handleExamApply(Player player, CGExamApply cgExamApply) {
		if (cgExamApply.getExamType() <= 0) {
			return;
		}
		boolean isTimeLimit = false;
		if(cgExamApply.getExamType() == ExamType.TIMELIMIT.index){
			isTimeLimit = true;
		}
		if (!checkRoleAndFunc(player, isTimeLimit)) {
			return;
		}
		Globals.getExamService().examApply(player.getHuman(), cgExamApply.getExamType());
		
	}
	
	/**
 	* 使用物品
 	* 
 	* CodeGenerator
 	*/
	public void handleExamUseItem(Player player, CGExamUseItem cgExamUseItem) {
		if (cgExamUseItem.getExamType() <= 0) {
			return;
		}
		boolean isTimeLimit = false;
		if(cgExamUseItem.getExamType() == ExamType.TIMELIMIT.index){
			isTimeLimit = true;
		}
		if (!checkRoleAndFunc(player, isTimeLimit)) {
			return;
		}
		Globals.getExamService().examUseItem(player.getHuman(), cgExamUseItem.getExamType(),cgExamUseItem.getItemId());
	}
		/**
 	* 选择选项
 	* 
 	* CodeGenerator
 	*/
	public void handleExamChose(Player player, CGExamChose cgExamChose) {
		if (cgExamChose.getExamType() <= 0) {
			return;
		}
		boolean isTimeLimit = false;
		if(cgExamChose.getExamType() == ExamType.TIMELIMIT.index){
			isTimeLimit = true;
		}
		
		if (!checkRoleAndFunc(player, isTimeLimit)) {
			return;
		}
		if (cgExamChose.getChoseAnswer() <= 0) {
			return;
		}
		Globals.getExamService().examChoseAnswer(player.getHuman(), cgExamChose.getExamType(),cgExamChose.getChoseAnswer());
	}
	
}
