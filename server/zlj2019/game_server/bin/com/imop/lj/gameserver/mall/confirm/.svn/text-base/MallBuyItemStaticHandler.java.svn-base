package com.imop.lj.gameserver.mall.confirm;

import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 购买商城物品
 * 
 * @author xiaowei.liu
 * 
 */
public class MallBuyItemStaticHandler extends IStaticHandler {
	private boolean timeLimit;
	private String queueUUID;
	private int mallItemId;

	public MallBuyItemStaticHandler(boolean timeLimit, String queueUUID, int mallItemId) {
		this.timeLimit = timeLimit;
		this.queueUUID = queueUUID;
		this.mallItemId = mallItemId;
	}

	@Override
	public void exec(Human human, boolean isOk) {
		if(!isOk){
			return;
		}
		
		if (timeLimit) {
			//Globals.getMallService().handleBuyTimeLimitItem(human, queueUUID, mallItemId, false);
		} else {
			//Globals.getMallService().handleBuyNormalItem(human, mallItemId, false);
		}

	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.MALL_BUY_ITEM;
	}

}
