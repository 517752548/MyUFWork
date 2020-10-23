package com.imop.lj.gameserver.mysteryshop.confirm;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 元宝或珍宝票刷新
 * 
 * @author xiaowei.liu
 * 
 */
public class BondOrNoteFlushStaticHandler extends IStaticHandler {

	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			Globals.getMysteryShopService().handleNormalFlushMystery(human, false);
		}

	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
//		return ConsumeConfirm.MS_BOND_OR_NOTE_FLUSH;
		return ConsumeConfirm.NULL;//FIXME
	}

}
