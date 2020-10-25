package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 显示队伍列表界面
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamShowList extends CGMessage{
	
	/** 目标Id */
	private int targetId;
	
	public CGTeamShowList (){
	}
	
	public CGTeamShowList (
			int targetId ){
			this.targetId = targetId;
	}
	
	@Override
	protected boolean readImpl() {

	// 目标Id
	int _targetId = readInteger();
	//end



			this.targetId = _targetId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 目标Id
	writeInteger(targetId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TEAM_SHOW_LIST;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_SHOW_LIST";
	}

	public int getTargetId(){
		return targetId;
	}
		
	public void setTargetId(int targetId){
		this.targetId = targetId;
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamShowList(this.getSession().getPlayer(), this);
	}
}