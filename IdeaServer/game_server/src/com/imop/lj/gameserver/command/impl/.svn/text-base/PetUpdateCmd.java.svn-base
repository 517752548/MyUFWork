package com.imop.lj.gameserver.command.impl;

import com.imop.lj.common.LogReasons.PetExpLogReason;
import com.imop.lj.common.LogReasons.PetLogReason;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetLeader;
import com.imop.lj.gameserver.pet.PetPet;
import com.imop.lj.gameserver.pet.prop.PetAProperty;
import com.imop.lj.gameserver.pet.prop.PetBProperty;
import com.imop.lj.gameserver.pet.prop.effector.PetAPropFromType;
import com.imop.lj.gameserver.pet.prop.effector.PetBPropFromType;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

public class PetUpdateCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		try {
			long id = Long.parseLong(commands[0]);
			String type = commands[1].toLowerCase();
			int target = Integer.parseInt(commands[2]);
			
			Pet pet = human.getPetManager().getPetByUuid(id);
			if (null == pet) {
				human.sendErrorMessage("petId not exist!petId=" + id);
				
				if (id == 0) {
					PetLeader leader = human.getPetManager().getLeader();
					for (PetBPropFromType fromType : PetBPropFromType.values()) {
						PetBProperty t = leader.getPropertyManager().getBattleProperty().getBPropSegment(fromType.index);
						System.out.println(fromType + "=" + t);
					}
				} else {
					PetPet pp = Globals.getPetService().getFightPet(human);
					if (pp != null) {
						System.out.println("=========aaaaaaaaaaa==========");
						for (PetAPropFromType fromType : PetAPropFromType.values()) {
							PetAProperty t = pp.getPropertyManager().getBattleProperty().getAPropSegment(fromType.index);
							System.out.println(fromType + "=" + t);
						}
						System.out.println("=========bbbbbbbb==========");
						for (PetBPropFromType fromType : PetBPropFromType.values()) {
							PetBProperty t = pp.getPropertyManager().getBattleProperty().getBPropSegment(fromType.index);
							System.out.println(fromType + "=" + t);
						}
					}
				}
				
				return;
			}
			
			switch (type) {
			case "point":
				pet.setLeftPoint(target);
				Globals.getLogService().sendPetLog(human, PetLogReason.GM_CMD_GIVE, "leftpoint=" + target, 
						pet.getTemplateId(), pet.getUUID(), "false");
				break;
			case "exp":
				Globals.getPetService().addExp(human, id, target, PetExpLogReason.GM_CMD, "", true);
				break;
			case "percept":
//				Globals.getPetService().OpenPerceptByPet(human, id, target);
				player.sendErrorMessage("error!not used cmd!");
				break;
			case "life":
				if (pet.isPet()) {
					((PetPet)pet).setLife(target);
					Globals.getLogService().sendPetLog(human, PetLogReason.GM_CMD_GIVE, "life=" + target, 
							pet.getTemplateId(), pet.getUUID(), "false");
				}
				break;
			default:
				human.sendErrorMessage("update type is invalid!type=" + type);
				return;
			}
			//给客户端发消息，通知变化
			pet.snapChangedProperty(true);
			
			human.sendErrorMessage("update pet success!");
			
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_UPDATE_PET;
	}

}
