package com.imop.lj.gameserver.guide.pusher;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.guide.AbstractGuidePusher;
import com.imop.lj.gameserver.guide.GuideDef.GuideType;
import com.imop.lj.gameserver.human.Human;

/**
 * 宝石镶嵌引导
 * @author yu.zhao
 *
 */
public class GemGuidePusher extends AbstractGuidePusher {
	
	public GemGuidePusher() {
		super(GuideType.GEM_EQUIP);
	}

	@Override
	public boolean checkCond(Human human) {
		if (isFinishedGuide(human)) {
			return false;
		}
		
		// 当前是否开启了对应的功能按钮
		return Globals.getFuncService().hasOpenedFunc(human, getGuideType().getFuncType());
	}

}
