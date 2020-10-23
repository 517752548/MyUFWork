package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.core.util.StringUtils;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年6月25日 下午3:12:45
 * @version 1.0
 */

public class CDKeyCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		
		String cdkey = "";
		if(!StringUtils.isEmpty(commands[0])) {
			cdkey = commands[0];
		} else {
			return;
		}
		
		Globals.getCDKeyService().takeCDKeyGiftRequestWS(player.getHuman(), cdkey);
	}

	@Override
	public String getCommandName() {
		return CommandConstants.CDKEY;
	}

}
