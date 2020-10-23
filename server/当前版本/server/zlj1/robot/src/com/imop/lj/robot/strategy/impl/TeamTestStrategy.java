package com.imop.lj.robot.strategy.impl;

import com.imop.lj.common.model.team.TeamInfo;
import com.imop.lj.core.msg.IMessage;
import com.imop.lj.core.util.MathUtils;
import com.imop.lj.core.util.RandomUtil;
import com.imop.lj.gameserver.team.msg.CGTeamApply;
import com.imop.lj.gameserver.team.msg.CGTeamApplyAuto;
import com.imop.lj.gameserver.team.msg.CGTeamShowList;
import com.imop.lj.gameserver.team.msg.GCTeamApply;
import com.imop.lj.gameserver.team.msg.GCTeamMyTeamInfo;
import com.imop.lj.gameserver.team.msg.GCTeamShowList;
import com.imop.lj.robot.Robot;
import com.imop.lj.robot.strategy.LoopExecuteStrategy;

/**
 *
 */
public class TeamTestStrategy extends LoopExecuteStrategy {
	
	private int teamId;
	
	public int getTeamId() {
		return teamId;
	}

	public void setTeamId(int teamId) {
		this.teamId = teamId;
	}

	/**
	 * 类参数构造器
	 *
	 * @param robot
	 * @param delay
	 *
	 */
	public TeamTestStrategy(Robot robot, int delay, int minInterval, int maxInterval) {
		// 操作周期为 最大最小间隔 秒之间的随机值
		super(robot, delay, MathUtils.random(minInterval, maxInterval));
	}

	

	@Override
	public void doAction() {
		//自动申请组队,玩家设置队伍目标的情况下
		//1-主线 2-绿野 3-nVn
		this.sendMessage((new CGTeamApplyAuto(1, RandomUtil.nextEntireInt(1, 3))));
		//手动申请组队,玩家没有设置队伍目标的情况下
		//全部
		this.sendMessage((new CGTeamShowList(0)));
	}

	@Override
	public void onResponse(IMessage message) {
		//自动申请队伍成功的标识
		if (message instanceof GCTeamMyTeamInfo) {
			GCTeamMyTeamInfo teamInfoMsg = (GCTeamMyTeamInfo) message;
			if(teamInfoMsg.getIsAutoMatch() == 1){
				//加成队伍成功
				System.out.println("apply team success!");
			}else{
				//加成队伍失败
				System.out.println("apply team fail!");
			}
		}
		
		//手动申请
		if (message instanceof GCTeamShowList) {
			GCTeamShowList showMsg = (GCTeamShowList) message;
			TeamInfo[] infos = showMsg.getTeamInfos();
			if(infos.length != 0){
				for (TeamInfo info : infos) {
					this.setTeamId(info.getTeamId());
					System.out.println("teamId= "+info.getTeamId()
							+"; applyStatus=" + info.getApplyStatus()
							+"; teamStatus=" + info.getTeamStatus());
				}
				
				int teamId = this.getTeamId();
				CGTeamApply apMsg = new CGTeamApply(teamId);
				this.sendMessage(apMsg);
			}
		}
		if (message instanceof GCTeamApply) {
			GCTeamApply appMsg = (GCTeamApply) message;
			if (appMsg.getTeamId() > 0) {
				//加成队伍成功
				System.out.println("apply team success!");
			}else{
				//加成队伍失败
				System.out.println("apply team fail!");
			}
		}
			
	}
}
