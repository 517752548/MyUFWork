package com.imop.lj.gameserver.command.impl;

import com.imop.lj.common.constants.LangConstants;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 人物技能相关命令
 * 
 * 
 */

public class UpgradeHumanSkillCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		String type = String.valueOf(commands[0]);
		try {
			switch(type){
			case "main":
				if(commands.length!=3){
					human.sendErrorMessage("参数数量不正确!");
					return;
				}
				int id = Integer.parseInt(commands[1]);
				int level = Integer.parseInt(commands[2]);
				if(level <= 0 || level > human.getLevel()){
					human.sendErrorMessage(LangConstants.MAINSKILL_LEVEL_LIMIT_BY_HUMAN_LEVEL);
					return;
				}
				Globals.getHumanSkillService().upgradeMainSkillForGM(human, id, level);
				break;
			case "sub":
				if(commands.length!=4){
					human.sendErrorMessage("参数数量不正确!");
					return;
				}
				int id1 = Integer.parseInt(commands[1]);
				int level1 = Integer.parseInt(commands[2]);
				int layer = Integer.parseInt(commands[3]);
				if(level1 <= 0 || level1 > Globals.getGameConstants().getSubSkillMaxLevel()
					|| level1 > human.getLevel()
					|| layer <= 0 || layer> Globals.getGameConstants().getSubSkillMaxLayer()){
					human.sendErrorMessage(LangConstants.UPGRADE_SKILL_NOT_OK_FOR_GM);
					return;
				}
				Globals.getHumanSkillService().upgradeSubSkillForGM(human, id1, level1, layer);
				break;
			case "life":
				if(commands.length!=4){
					human.sendErrorMessage("参数数量不正确!");
					return;
				}
				int id2 = Integer.parseInt(commands[1]);
				int level2 = Integer.parseInt(commands[2]);
				int layer2 = Integer.parseInt(commands[3]);
				if(level2 <= 0 || level2 > Globals.getGameConstants().getLifeSkillMaxLevel() 
						|| level2 > human.getLevel()
						|| layer2 <= 0 || layer2> Globals.getGameConstants().getLifeSkillMaxLayer()){
					human.sendErrorMessage(LangConstants.UPGRADE_SKILL_NOT_OK_FOR_GM);
					return;
				}
				Globals.getLifeSkillService().upgradeLifeSkillForGM(human, id2, level2, layer2);
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
		return CommandConstants.GM_CMD_SKILL;
	}

}
