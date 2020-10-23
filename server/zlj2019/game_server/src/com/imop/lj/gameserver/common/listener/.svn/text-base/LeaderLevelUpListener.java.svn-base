package com.imop.lj.gameserver.common.listener;

import com.imop.lj.core.event.IEventListener;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.common.event.LeaderLevelUpEvent;
import com.imop.lj.gameserver.human.Human;

public class LeaderLevelUpListener implements IEventListener<LeaderLevelUpEvent> {

	@Override
	public void fireEvent(LeaderLevelUpEvent event) {
		Human human = event.getInfo();
		int level = event.getLevel();
		// 任务监听
		human.getTaskListener().onUpdateLevel(human, level);
		
		//是否有任务从可见不可接状态，变为可接或已接
		Globals.getCommonTaskService().onUpdateLevel(human);
		
		// 功能开启
		Globals.getFuncService().onLevelUp(human);
		
		// 离线数据更新
		Globals.getOfflineDataService().onBaseInfoChange(human);
		
		// 精彩活动
		Globals.getGoodActivityService().onPlayerDoSth(human, event);
		
		//组队
		Globals.getTeamService().onTeamMemberInfoChanged(human);
		
		//装备相关
		Globals.getEquipService().onLevelUp(human);
		
		//心法相关
		Globals.getHumanSkillService().onLevelUp(human);

		Globals.getOvermanService().onLevelUp(human);
		
		//提升
		Globals.getPromoteService().noticePromoteInfo(human);
		
		//新手引导
		Globals.getGuideService().onLevelUp(human);
		
		//战斗加速数据可能变化
		Globals.getBattleService().noticeBattleSpeedup(human);
		
		//酒馆任务最大星数
		Globals.getPubTaskService().noticePubTaskMaxStar(human);
	}
}
