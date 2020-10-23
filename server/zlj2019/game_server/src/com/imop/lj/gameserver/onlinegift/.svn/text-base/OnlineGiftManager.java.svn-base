package com.imop.lj.gameserver.onlinegift;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.onlinegift.template.OnlineGiftTemplate;

/**
 * 在线礼包管理器
 * 
 * @author xiaowei.liu
 * 
 */
public class OnlineGiftManager extends AbstractOnlineGiftManager<OnlineGiftTemplate> {
	public OnlineGiftManager(Human human) {
		super(human);
	}

	@Override
	public long getCd() {
		OnlineGiftTemplate tmpl = this.getCurrReceiveOnlineGiftTemplate();
		if (tmpl == null) {
			Loggers.humanLogger.error("OnlineGiftManager.getCd onlineGiftTemplateId = "	+ this.currReceiveId + " does not exist!!!");
			return Long.MAX_VALUE;
		}

		long cd = this.startTime + tmpl.getCd()	- Globals.getTimeService().now();
		return cd <= 0 ? 0 : cd;
	}

	@Override
	public OnlineGiftTemplate getCurrReceiveOnlineGiftTemplate() {
		return Globals.getTemplateCacheService().get(this.currReceiveId, OnlineGiftTemplate.class);
	}
}
