package com.imop.lj.gameserver.corps.confirm;

import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.ConsumeConfirm;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.IStaticHandler;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月12日 下午2:27:51
 * @version 1.0
 */

public class CorpsMem2FriendsStateHandler extends IStaticHandler {

	@Override
	public void exec(Human human, boolean isOk) {
		if(isOk){
			Globals.getCorpsService().addCorpsMem2FriendsConfirmOK(human);
		}
	}

	@Override
	public ConsumeConfirm getConsumeConfirm() {
		return ConsumeConfirm.CORPS_ADD_MEM_TO_FRIENDS;
	}

}
