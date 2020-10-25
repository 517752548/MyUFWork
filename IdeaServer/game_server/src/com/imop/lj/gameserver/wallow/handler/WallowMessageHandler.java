package com.imop.lj.gameserver.wallow.handler;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.util.StringUtils;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.wallow.msg.CGWallowAddInfo;

public class WallowMessageHandler {

	public void handleWallowAddInfo(Player player,
			CGWallowAddInfo cgWallowAddInfo) {

		// 真实姓名
		String name = cgWallowAddInfo.getName();
		// 身份证号
		String idCard = cgWallowAddInfo.getIdCard();
		if (StringUtils.isEmpty(name) || StringUtils.isEmpty(idCard)) {
			return;
		}
		if (!Globals.getServerConfig().isTurnOnLocalInterface()) {
			player.sendSystemMessage(LangConstants.LOCAL_TURN_OFF);
			return;
		}
	}
}
