package com.imop.lj.gameserver.command.impl;

import java.util.HashSet;
import java.util.Set;

import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.activity.function.ActivityDef.ActivityState;
import com.imop.lj.gameserver.activity.template.ActivityTemplate;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.common.Globals;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.map.activity.PetIslandEndMessage;
import com.imop.lj.gameserver.map.activity.PetIslandReadyMessage;
import com.imop.lj.gameserver.map.activity.PetIslandStartMessage;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;
import com.imop.lj.gameserver.telnet.command.GenLogCommand;

public class MapCmd implements IAdminCommand<ISession> {

	@Override
	public void execute(ISession playerSession, String[] commands) {
		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		Human human = player.getHuman();
		try {
			String ss = commands[0];
			//进入指定地图
			if (ss.equalsIgnoreCase("go")) {
				int mapId = Integer.parseInt(commands[1]);
				Globals.getMapService().enterMap(human, mapId);
			}
			
			//宠物岛活动命令
			if (ss.equalsIgnoreCase("pi")) {
				// 活动开关
				int activityId = Integer.parseInt(commands[1]);
				ActivityState state = ActivityState.valueOf(Integer.parseInt(commands[2]));
				ActivityTemplate activityTtpl = Globals.getTemplateCacheService().get(activityId, ActivityTemplate.class);
				if(activityTtpl == null) {
					player.sendErrorMessage("activityId is wrong!");
					return;
				}
				PetIslandReadyMessage readyMsg = new PetIslandReadyMessage(activityTtpl);
				PetIslandStartMessage startMsg = new PetIslandStartMessage(activityTtpl);
				PetIslandEndMessage endMsg = new PetIslandEndMessage(activityTtpl);
				switch (state) {
				case READY:
					readyMsg.execute();
					human.sendErrorMessage("activity("+activityId+") is ready!");
					break;
				case OPENING:
	//				readyMsg.execute();
					startMsg.execute();
					human.sendErrorMessage("activity("+activityId+") is opening!");
					break;
				case FINISHED:
	//				readyMsg.execute();
	//				startMsg.execute();
					endMsg.execute();
					human.sendErrorMessage("activity("+activityId+") is end!");
					break;
	
				default:
					break;
				}
			}
			
			if (ss.equalsIgnoreCase("test")) {
				//288516249174956591
				GenLogCommand cc = new GenLogCommand();
				Set<Long> roleIdSet = new HashSet<Long>();
				roleIdSet.add(288516249174956591L);
				roleIdSet.add(human.getRoleUUID());
				
				cc.genLog(roleIdSet, 3000);
				
//				IMessage msg = new SysInternalMessage() {
//					@Override
//					public void execute() {
//						Globals.getHumanCacheService().gmTest();
//					}
//				};
//				Globals.getSceneService().getCommonScene().putMessage(msg);
			
			}
			
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}

	}

	@Override
	public String getCommandName() {
		return CommandConstants.GM_MAP;
	}

}
