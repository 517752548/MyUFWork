package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.reward.Reward;
import com.imop.lj.gameserver.reward.template.RewardConfigTemplate;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * @author : bing.dong E-mail: dawson119@163.com
 * @createTime : 2014年3月10日 下午1:48:59
 * @version 1.0
 */

public class ItemCmd implements IAdminCommand<ISession> {

	public void gmCreateItem() {
		
	}

	/**
	 * commands 0：道具id， 1：道具数量, 2强化等级， 3附魔等级， 4装备打孔数量， 5技能id、6武器等级， 7属性A串，8属性B串：
	 * 
	 */
	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		int rewardId = Integer.parseInt(commands[0]);
		if (Globals.getTemplateCacheService().get(rewardId, RewardConfigTemplate.class) == null) {
			return;
		}
		
		Reward reward = Globals.getRewardService().createReward(human.getUUID(), rewardId, "gmCreate");
		boolean flag = Globals.getRewardService().giveReward(human, reward, false);
		if (flag) {
			human.sendErrorMessage("ok!");
		} else {
			human.sendErrorMessage("fail!");
		}
	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_CREATE_ITEM;
	}
	
}
