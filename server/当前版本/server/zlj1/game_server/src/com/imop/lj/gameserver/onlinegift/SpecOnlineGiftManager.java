package com.imop.lj.gameserver.onlinegift;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.onlinegift.template.SpecOnlineGiftTemplate;

public class SpecOnlineGiftManager extends AbstractOnlineGiftManager<SpecOnlineGiftTemplate> {

	public SpecOnlineGiftManager(Human human) {
		super(human);
	}

	@Override
	public long getCd() {
		SpecOnlineGiftTemplate tmpl = this.getCurrReceiveOnlineGiftTemplate();
		if(tmpl == null){
			Loggers.humanLogger.error("SpecOnlineGiftManager.getCd onlineGiftTemplateId = " + this.currReceiveId + " does not exist!!!");
			return Long.MAX_VALUE;
		}
		
		long cd = this.startTime + tmpl.getCd() - Globals.getTimeService().now();
		return cd <= 0 ? 0 : cd;
	}

	@Override
	public SpecOnlineGiftTemplate getCurrReceiveOnlineGiftTemplate() {
		return Globals.getTemplateCacheService().get(this.currReceiveId, SpecOnlineGiftTemplate.class);
	}

}
