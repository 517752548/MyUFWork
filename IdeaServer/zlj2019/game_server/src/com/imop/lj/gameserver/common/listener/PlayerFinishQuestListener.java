package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.PlayerFinishQuestEvent;
import com.imop.lj.gameserver.human.Human;

public class PlayerFinishQuestListener implements IEventListener<PlayerFinishQuestEvent> {

	@Override
	public void fireEvent(PlayerFinishQuestEvent event) {
		Human human = event.getInfo();
		int questId = event.getQuestId();
//		// 玩家完成某一任务，触发npc变化
//		Globals.getNpcService().onFinishedQuest(human, questId);
//		// 完成任务后，判断是否需要开启新功能
//		Globals.getFuncService().onFinishQuest(human, questId);
//		// 新手引导
//		Globals.getGuideService().onFinishQuest(human, questId);
//		// 剧情
//		Globals.getStoryService().onFinishQuest(human, questId);
	}
}
