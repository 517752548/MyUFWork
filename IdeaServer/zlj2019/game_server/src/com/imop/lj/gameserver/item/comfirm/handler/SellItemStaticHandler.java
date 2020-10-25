package com.imop.lj.gameserver.item.comfirm.handler;

import com.imop.lj.common.model.item.SellItemInfo;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

public class SellItemStaticHandler extends IStaticHandler {

	private int bagId;
	private SellItemInfo[] sellItemInfos;

	public SellItemStaticHandler(int bagId, SellItemInfo[] sellItemInfos) {
		this.bagId = bagId;
		this.sellItemInfos = sellItemInfos;
	}

	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			Globals.getItemService().sellItem(human, bagId, sellItemInfos);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.SELL_ITEM;
	}
}
