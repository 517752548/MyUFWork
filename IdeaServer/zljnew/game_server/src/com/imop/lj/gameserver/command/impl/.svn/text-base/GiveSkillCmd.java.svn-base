package com.imop.lj.gameserver.command.impl;

import java.util.Arrays;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.pet.Pet;
import com.imop.lj.gameserver.pet.PetLeader;
import com.imop.lj.gameserver.pet.PetMessageBuilder;
import com.imop.lj.gameserver.pet.PetSkillInfo;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.skill.template.SkillTemplate;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 添加技能到宠物或主将gm命令
 * [技能ID，技能等级,(petUUID)] 如果没有petId,默认添加到当前主将身上
 * @author yuanbo.gao
 *
 */
public class GiveSkillCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		System.out.println(Arrays.toString(commands));
		try {
			if (commands.length != 2 && commands.length != 3) {
				return;
			}
			int skillId = Integer.parseInt(commands[0]);
			int skillLevel = Integer.parseInt(commands[1]);
			Pet targetPet ;
			if(commands.length == 3){
				targetPet = human.getPetManager().getPetByUuid(Long.parseLong(commands[2]));
			}else{
				targetPet = human.getPetManager().getLeader();
			}
			
			SkillTemplate tpl = Globals.getTemplateCacheService().get(skillId, SkillTemplate.class);
			if (tpl == null) {
				human.sendSystemMessage("该技能不存在！");
				return;
			}
			if(targetPet.isLeader()){
				PetLeader pet = (PetLeader)targetPet;
//				pet.addRunningSkill(new PetSkillInfo(skillId, skillLevel, Globals.getTimeService().now()));
				human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human, pet));
			}else{
				targetPet.addSkill(new PetSkillInfo(skillId, skillLevel, Globals.getTimeService().now()));
				human.sendMessage(PetMessageBuilder.buildGCPetInfoMsg(human, targetPet));
			}
			player.sendErrorMessage("技能添加成功!");
		} catch (Exception e) {
			human.sendSystemMessage("错误的命令！");
			e.printStackTrace();
		}
	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_GIVE_SKILL;
	}

}
