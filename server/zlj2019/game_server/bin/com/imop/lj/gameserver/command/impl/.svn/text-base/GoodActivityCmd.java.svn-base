package com.imop.lj.gameserver.command.impl;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.core.util.TimeUtils;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.func.FuncDef.FuncTypeEnum;
import com.imop.lj.gameserver.goodactivity.activity.AbstractGoodActivity;
import com.imop.lj.gameserver.goodactivity.template.GoodActivityBaseTemplate;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

import java.util.HashSet;
import java.util.Set;

/**
 * 精彩活动命令
 * 
 * 
 */

public class GoodActivityCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		try {
			// 创建测试活动
			if (commands[0].equalsIgnoreCase("create")) {
				int goodActivityTplId = Integer.parseInt(commands[1]);
				GoodActivityBaseTemplate activityTpl = Globals.getTemplateCacheService().get(goodActivityTplId, GoodActivityBaseTemplate.class);
				
				long startTime = Globals.getTimeService().now();
				long endTime = startTime + 2 * TimeUtils.DAY;
				// 获取当前服务器的serverIds
				Set<Integer> serverIdSet = Globals.getServerIdSet();
				AbstractGoodActivity activity = Globals.getGoodActivityService().createActivity(goodActivityTplId, startTime, endTime, true, 
						activityTpl.getName(), activityTpl.getDesc(), 0, 0, serverIdSet);
				if (null == activity) {
					player.sendErrorMessage("fail!");
				} else {
					player.sendErrorMessage("ok!");
				}
			} else if (commands[0].equalsIgnoreCase("close")) {
				long activityId = Long.parseLong(commands[1]);
				boolean flag = Globals.getGoodActivityService().gmClose(activityId);
				if (flag) {
					player.sendErrorMessage("ok!");
				} else {
					player.sendErrorMessage("fail!");
				}
			} else if (commands[0].equalsIgnoreCase("refresh")) {
				Globals.getGoodActivityService().gmRefreshAllPeriodActivity();
			} else if (commands[0].equalsIgnoreCase("cq")) {
				if (commands.length < 4) {
					player.sendErrorMessage("invalid param!");
					return;
				}
				int goodActivityTplId = Integer.parseInt(commands[1]);
				int dayNum = Integer.parseInt(commands[2]);
				String serverIds = commands[3];
				Set<Integer> serverIdSet = new HashSet<Integer>();
				if (serverIds != null) {
					String[] sArr = serverIds.split(",");
					for (int i = 0; i < sArr.length; i++) {
						serverIdSet.add(Integer.parseInt(sArr[i]));
					}
				}
				
				GoodActivityBaseTemplate activityTpl = Globals.getTemplateCacheService().get(goodActivityTplId, GoodActivityBaseTemplate.class);
				long startTime = Globals.getTimeService().now();
				long endTime = startTime + dayNum * TimeUtils.DAY;
				AbstractGoodActivity activity = Globals.getGoodActivityService().createActivity(goodActivityTplId, startTime, endTime, true, 
						activityTpl.getName(), activityTpl.getDesc(), 0, 0, serverIdSet);
				if (null == activity) {
					player.sendErrorMessage("fail!");
				} else {
					player.sendErrorMessage("ok!");
				}
			} else if(commands[0].equalsIgnoreCase("get")){
				Globals.getGoodActivityService().openGoodActivityPanel(player.getHuman(), FuncTypeEnum.GOOD_ACTIVITY);
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_CMD_GOOD_ACTIVITY;
	}

}
