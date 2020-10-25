package com.imop.lj.gameserver.command.impl;

import com.imop.lj.common.LogReasons.PetLogReason;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.pet.PetDef.PetType;
import com.imop.lj.gameserver.pet.template.PetTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

public class GivePetCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		try {
			Integer petTplId = Integer.parseInt(commands[0]);
			PetTemplate petTpl = Globals.getTemplateCacheService().get(petTplId, PetTemplate.class);
			if (petTpl == null || petTpl.getPetType() == PetType.LEADER) {
				return;
			}
			//gm命令给非绑定的
			if (petTpl.getPetType() == PetType.PET) {
				Globals.getPetService().onCatchPet(human, petTpl.getId(), PetLogReason.GM_PET_CATCH_PET, false);
				player.sendErrorMessage("add pet ok!tplId=" + petTplId);
			} else if (petTpl.getPetType() == PetType.HORSE) {
				Globals.getPetService().onGetPetHorse(human, petTpl.getId(), PetLogReason.GM_PET_HORSE_HIRE, false);
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}
	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_GIVE_PET;
	}

}
