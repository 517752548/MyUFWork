package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 调整队员位置
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamChangePosition extends CGMessage{
	
	/** 目标玩家id */
	private long targetPlayerId;
	/** 目标玩家位置，从1开始计数 */
	private int targetPosition;
	
	public CGTeamChangePosition (){
	}
	
	public CGTeamChangePosition (
			long targetPlayerId,
			int targetPosition ){
			this.targetPlayerId = targetPlayerId;
			this.targetPosition = targetPosition;
	}
	
	@Override
	protected boolean readImpl() {

	// 目标玩家id
	long _targetPlayerId = readLong();
	//end


	// 目标玩家位置，从1开始计数
	int _targetPosition = readInteger();
	//end



			this.targetPlayerId = _targetPlayerId;
			this.targetPosition = _targetPosition;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 目标玩家id
	writeLong(targetPlayerId);


	// 目标玩家位置，从1开始计数
	writeInteger(targetPosition);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TEAM_CHANGE_POSITION;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_CHANGE_POSITION";
	}

	public long getTargetPlayerId(){
		return targetPlayerId;
	}
		
	public void setTargetPlayerId(long targetPlayerId){
		this.targetPlayerId = targetPlayerId;
	}

	public int getTargetPosition(){
		return targetPosition;
	}
		
	public void setTargetPosition(int targetPosition){
		this.targetPosition = targetPosition;
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamChangePosition(this.getSession().getPlayer(), this);
	}
}