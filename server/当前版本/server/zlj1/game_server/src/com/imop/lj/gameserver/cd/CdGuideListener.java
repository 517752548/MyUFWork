package com.imop.lj.gameserver.cd;

import com.imop.lj.gameserver.human.Human;

/**
 * 冷却引导事件监听
 *
 * @author haijiang.jin
 *
 */
public class CdGuideListener extends CdListenerAdapter {
	@Override
	public void afterAddCdQueueMax(Human human, CdQueue addedCdQueue) {
//		if ((addedCdQueue.getCdType() == CdTypeEnum.building) &&
//			(addedCdQueue.getIndex() == 2) &&
//			(human.getVipLevel() == 0)) {
//			 human.getGuideManager().showGuide(Guide.BUY_BUILDING_CD_3);
//		}
	}
}
