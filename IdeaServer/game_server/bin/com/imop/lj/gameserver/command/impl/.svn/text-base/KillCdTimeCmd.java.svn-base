package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.cd.CdTypeEnum;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

/**
 * 清除冷却队列等待时间, 将等待时间归 0. 用法:
 * <br> 
 * <font color='#990000'><b>!killcd   冷却类型  索引位置</b></font>
 * 
 * @author haijiang.jin
 *
 */
public class KillCdTimeCmd implements IAdminCommand<ISession> {
	@Override
	public void execute(ISession session, String[] cmds) {
		if (!(session instanceof GameClientSession)) {
			return;
		}

		CdTypeEnum cdType = CdTypeEnum.valueOf(Integer.parseInt(cmds[0]));
		if (null == cdType) {
			return;
		}
		int index = 0;

		if (cmds.length > 1) {
			index = Integer.parseInt(cmds[1]);
		}

		// 获取玩家对象
		Player player = ((GameClientSession) session).getPlayer();

		if (player == null) {
			return;
		}

		// 获取玩家角色
		Human human = player.getHuman();
		// 清除冷却队列, 将冷却队列等待时间减少为 0
		human.getCdManager().subTime(cdType, index, Integer.MAX_VALUE);
		human.getCdManager().snapChangedCdQueues(true);
	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_KILL_CD;
	}
}
