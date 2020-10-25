package com.imop.lj.gameserver.guide.pusher;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.guide.AbstractGuidePusher;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.human.Human;

public class MindLevelupGuidePusher extends AbstractGuidePusher {
	
	public MindLevelupGuidePusher() {
		super(GuideType.MIND_LEVELUP);
	}

	@Override
	public boolean checkCond(Human human) {
		if (isFinishedGuide(human)) {
			return false;
		}
		
		//是否完成了指定的任务
		return human.getCommonTaskManager().isFinished(Globals.getGameConstants().getGuideMindLevelupQuestId());
	}

}
