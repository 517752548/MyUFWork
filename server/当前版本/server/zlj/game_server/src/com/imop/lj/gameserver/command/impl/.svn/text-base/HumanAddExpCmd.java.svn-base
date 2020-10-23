package com.imop.lj.gameserver.command.impl;

import com.imop.lj.common.LogReasons.PetExpLogReason;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 给领主经验的命令
 * 
 * 
 */

public class HumanAddExpCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		if(commands.length!=2){
			human.sendErrorMessage("参数数量不正确!");
			return;
		}
		try {
			String type = String.valueOf(commands[0]);
			int addExp = Integer.parseInt(commands[1]);
			switch(type){
				case "leader" : Globals.getPetService().addExpForLeader(human, addExp, PetExpLogReason.GM_CMD, PetExpLogReason.GM_CMD.getReasonText(), true); break;
				case "pet" : Globals.getPetService().addExpForPet(human, addExp, PetExpLogReason.GM_CMD, PetExpLogReason.GM_CMD.getReasonText(), true); break;
				case "horse" : Globals.getPetService().addExpForPetHorse(human, addExp, PetExpLogReason.GM_CMD, PetExpLogReason.GM_CMD.getReasonText(), true); break;
				default : Globals.getPetService().addExp(human, human.getPetManager().getLeader().getUUID(), 
						addExp, PetExpLogReason.GM_CMD, PetExpLogReason.GM_CMD.getReasonText(), true);
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_GIVE_EXP;
	}

}
