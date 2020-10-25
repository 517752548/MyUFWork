package com.imop.lj.gameserver.guide.pusher;

import com.imop.lj.gameserver.guide.AbstractGuidePusher;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.human.Human;

public class FirstBattleGuidePusher extends AbstractGuidePusher {
	
	public FirstBattleGuidePusher() {
		super(GuideType.FIRST_BATTLE);
	}

	@Override
	public boolean checkCond(Human human) {
		if (isFinishedGuide(human)) {
			return false;
		}
		
		return true;
	}

}
