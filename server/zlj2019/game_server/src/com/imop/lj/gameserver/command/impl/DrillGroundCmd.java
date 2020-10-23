package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 校场相关
 * 
 * @author xiaowei.liu
 * 
 */
public class DrillGroundCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		
		String cmd = commands[0];
		if("open".equals(cmd)){
//			Globals.getDrillGroundService().handleOpenDrillGroundPanel(human);
		}else if("openPage".equals(cmd)){
//			int pageId = Integer.valueOf(commands[1]);
//			//Globals.getDrillGroundService().handleReqDrillGroundPage(human, pageId);
		}else if("reqChallenge".equals(cmd)){
//			int pageId = Integer.valueOf(commands[1]);
//			int type = Integer.valueOf(commands[2]);
//			Globals.getDrillGroundService().handleReqChallenge(human, pageId, type);
		}
//		else if("vip".equals(cmd)){
//			int vip = Integer.valueOf(commands[1]);
//			human.setVipLevel(vip);
//		}
		else if("upgrade".equals(cmd)){
//			int level = Integer.valueOf(commands[1]);
//			if (level > Globals.getGameConstants().getLevelMax()) {
//				level = Globals.getGameConstants().getLevelMax();
//			}
//			human.setLevel(level);
//			human.getPetManager().getleader().setLevel(level);
		}else if("startGame".equals(cmd)){
//			int tactics = Integer.valueOf(commands[1]);
//			Globals.getDrillGroundService().handleStartGame(human, tactics);
		}else if("hire".equals(cmd)){
//			int tempId = Integer.valueOf(commands[1]);
//			Globals.getDrillGroundService().handleHirePet(human, tempId);
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_DRILL_GROUND;
	}

}
