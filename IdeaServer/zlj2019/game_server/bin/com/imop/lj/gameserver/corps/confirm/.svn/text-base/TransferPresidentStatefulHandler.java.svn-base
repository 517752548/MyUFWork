package com.imop.lj.gameserver.corps.confirm;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * 转让团长二次提示
 * 
 * @author xiaowei.liu
 * 
 */
public class TransferPresidentStatefulHandler extends IStaticHandler{
	private long memId;
	
	public TransferPresidentStatefulHandler(long memId){
		this.memId = memId;
	}
	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			Globals.getCorpsService().transferPresident(human, memId, false);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.FIRE_CORPS_MEMBER;
	}
	
}
