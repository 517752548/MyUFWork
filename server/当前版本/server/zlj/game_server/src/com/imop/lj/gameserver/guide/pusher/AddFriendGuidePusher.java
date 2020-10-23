package com.imop.lj.gameserver.guide.pusher;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.guide.AbstractGuidePusher;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.human.Human;

public class AddFriendGuidePusher extends AbstractGuidePusher {
	
	public AddFriendGuidePusher() {
		super(GuideType.ADD_FRIEND);
	}

	@Override
	public boolean checkCond(Human human) {
		if (isFinishedGuide(human)) {
			return false;
		}
		
		//是否达到了指定的等级
		return human.getLevel() >= Globals.getGameConstants().getAddFriendLevel();
	}

}
