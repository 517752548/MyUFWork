package com.imop.lj.gameserver.quest.handler;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.quest.msg.CGAcceptQuest;
import com.imop.lj.gameserver.quest.msg.CGCommonQuestList;
import com.imop.lj.gameserver.quest.msg.CGFinishQuest;
import com.imop.lj.gameserver.quest.msg.CGGiveUpQuest;

/**
 * $message.comment
 * 
 * @author CodeGenerator, don't modify this file please.
 */

public class QuestMessageHandler {

	public QuestMessageHandler() {
	}

	/**
	 * 请求任务列表
	 * 
	 * CodeGenerator
	 */
	public void handleCommonQuestList(Player player, CGCommonQuestList cgCommonQuestList) {
		if (player == null) {
			return;
		}
		Human human = player.getHuman();
		if (human == null) {
			return;
		}
		
		Globals.getCommonTaskService().sendCommonTaskList(human);
	}

	/**
	 * 接受任务
	 * 
	 * CodeGenerator
	 */
	public void handleAcceptQuest(Player player, CGAcceptQuest cgAcceptQuest) {
		if (player == null) {
			return;
		}
		Human human = player.getHuman();
		if (human == null) {
			return;
		}
		
		int questId = cgAcceptQuest.getQuestId();
		if (questId <= 0) {
			return;
		}
		
		Globals.getCommonTaskService().acceptTask(human, cgAcceptQuest.getQuestId());
	}

	/**
	 * 放弃已接任务
	 * 
	 * CodeGenerator
	 */
	public void handleGiveUpQuest(Player player, CGGiveUpQuest cgGiveUpQuest) {
		if (player == null) {
			return;
		}
		Human human = player.getHuman();
		if (human == null) {
			return;
		}
		
		//TODO 放弃任务先不做
		
	}

	/**
	 * 完成任务
	 * 
	 * CodeGenerator
	 */
	public void handleFinishQuest(Player player, CGFinishQuest cgFinishQuest) {
		if (player == null) {
			return;
		}
		Human human = player.getHuman();
		if (human == null) {
			return;
		}
		
		int questId = cgFinishQuest.getQuestId();
		if (questId <= 0) {
			return;
		}
		
		Globals.getCommonTaskService().finishTask(human, questId);
		
	}
}
