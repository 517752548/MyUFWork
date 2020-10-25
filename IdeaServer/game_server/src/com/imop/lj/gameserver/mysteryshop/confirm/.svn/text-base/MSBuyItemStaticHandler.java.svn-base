package com.imop.lj.gameserver.mysteryshop.confirm;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 购买东西
 * 
 * @author xiaowei.liu
 * 
 */
public class MSBuyItemStaticHandler extends IStaticHandler {
	private int msItemId;
	
	public MSBuyItemStaticHandler(int msItemId){
		this.msItemId = msItemId;
	}
	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			Globals.getMysteryShopService().handleBuyMsItem(human, msItemId, false);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.NULL;//FIXME
	}

}
