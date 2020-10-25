package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;
import com.imop.lj.gameserver.team.model.Team;
import com.imop.lj.gameserver.team.model.TeamApplyer;

/**
 * 功能按钮命令
 * 
 */
public class TeamCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		try {
			long roleId = human.getCharId();
			String cmd = commands[0];
			switch (cmd) {
			case "create":
				Globals.getTeamService().playerCreateTeam(human);
				
				Globals.getTeamService().chooseTarget(human, 1, 1, 100, true);
				
				Team cteam = Globals.getTeamService().getHumanTeam(roleId);
				System.out.println("teamId=" + cteam.getId());
				human.sendChatMessage("teamId=" + cteam.getId());
				break;

			case "agree":
				Team team = Globals.getTeamService().getHumanTeam(roleId);
				for (TeamApplyer teamApplyer : team.getApplySet()) {
					long targetRoleId = teamApplyer.getRoleId();
					Globals.getTeamService().agreeApplyer(human, targetRoleId);
				}
				break;
				
			case "join":
				int teamId = Integer.parseInt(commands[1]);
				Globals.getTeamService().applyJoinTeam(human, teamId);
				break;
				
			case "escape":
//				Globals.getTeamService().chooseSkillRound(human, false, 4, 0, 0, 1, 0, 0, 0);
				break;
				
			case "aq":
				int questId = Integer.parseInt(commands[1]);
				Globals.getTeamService().acceptTask(human, questId);
				break;
			case "fq":
				int questId1 = Integer.parseInt(commands[1]);
				Globals.getTeamService().finishTask(human, questId1);
				break;
				
			default:
				break;
			}


		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_TEAM;
	}

}
