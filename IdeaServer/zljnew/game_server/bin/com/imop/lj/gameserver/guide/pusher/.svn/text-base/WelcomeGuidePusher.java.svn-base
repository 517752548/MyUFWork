package com.imop.lj.gameserver.guide.pusher;

import com.imop.lj.gameserver.guide.AbstractGuidePusher;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.human.Human;

public class WelcomeGuidePusher extends AbstractGuidePusher {

	public WelcomeGuidePusher() {
		super(GuideType.WELCOME);
	}

	@Override
	public boolean checkCond(Human human) {
		if (isFinishedGuide(human)) {
			return false;
		}
		
		return true;
	}

	@Override
	public void sendGuideInfo(Human human) {
		if (!checkCond(human)) {
			return;
		}
		
		// 该步骤的完成，需要玩家点击面板中的开始后才能完成
		
		// 发欢迎页面的新手引导给玩家
//		GCGuideWelcome gcGuideWelcome = new GCGuideWelcome();
//		gcGuideWelcome.setGuideTypeId(getGuideType().getIndex());
//		gcGuideWelcome.setNpcId(Globals.getGameConstants().getGuideWelcomePanelNpcId());
		
		human.sendMessage(getGuideInfoMsg(human));
	}

}
