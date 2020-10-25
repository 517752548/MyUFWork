package com.imop.lj.gameserver.mysteryshop.confirm;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 有推荐物品
 * 
 * @author xiaowei.liu
 * 
 */
public class HasRecommendItemStaticHandler extends IStaticHandler {
	private int flushType;
	
	public HasRecommendItemStaticHandler(int flushType){
		this.flushType = flushType;
	}
	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			Globals.getMysteryShopService().handleFlushMystery(human, flushType, false);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.NULL;//FIXME
	}

}
