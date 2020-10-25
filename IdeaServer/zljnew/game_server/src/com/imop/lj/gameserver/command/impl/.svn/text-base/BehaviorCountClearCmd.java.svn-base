package com.imop.lj.gameserver.command.impl;

import com.imop.lj.common.constants.Loggers;
import com.imop.lj.core.command.IAdminCommand;
import com.imop.lj.core.session.ISession;
import com.imop.lj.gameserver.behavior.BehaviorTypeEnum;
import com.imop.lj.gameserver.command.CommandConstants;
import com.imop.lj.gameserver.human.Human;
import com.imop.lj.gameserver.player.Player;
import com.imop.lj.gameserver.startup.GameClientSession;

public class BehaviorCountClearCmd implements IAdminCommand<ISession>{

	@Override
	public void execute(ISession playerSession, String[] commands) {

		if (!(playerSession instanceof GameClientSession)) {
			return;
		}
		Player player = ((GameClientSession) playerSession).getPlayer();
		try {
			int stageType = Integer.parseInt(commands[0]);
			
			Human human = player.getHuman();
			//空
			if(human == null){
				return ;
			}
			if(commands.length==1) 
			{
				BehaviorTypeEnum operateType = BehaviorTypeEnum.valueOf(stageType);
				//没有操作类型
				if(operateType == null){
					return ;
				}
				//清空记录
				behaviorCountClear(human,operateType);
			}
		} catch (Exception e) {
			e.printStackTrace();
			player.sendErrorMessage(e.getMessage());
		}
	}
	
	//清空记录
	private void behaviorCountClear(Human human,BehaviorTypeEnum operateType){
		//清空记录
		human.getBehaviorManager().gmClear(operateType);
		Loggers.gmcmdLogger.warn("BehaviorCountClearCmd.hehaviorCountClear owneruuid="+human.getUUID()+" operateType="+operateType.getIndex());
	}

	@Override
	public String getCommandName() {
		return CommandConstants.BEHAVIOR_COUNT_CLEAR;
	}

}
