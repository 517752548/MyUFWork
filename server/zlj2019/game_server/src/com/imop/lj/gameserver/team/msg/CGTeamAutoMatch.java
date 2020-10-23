package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 设置队伍自动匹配
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamAutoMatch extends CGMessage{
	
	/** 是否自动匹配，0否1是 */
	private int isAutoMatch;
	
	public CGTeamAutoMatch (){
	}
	
	public CGTeamAutoMatch (
			int isAutoMatch ){
			this.isAutoMatch = isAutoMatch;
	}
	
	@Override
	protected boolean readImpl() {

	// 是否自动匹配，0否1是
	int _isAutoMatch = readInteger();
	//end



			this.isAutoMatch = _isAutoMatch;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否自动匹配，0否1是
	writeInteger(isAutoMatch);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TEAM_AUTO_MATCH;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_AUTO_MATCH";
	}

	public int getIsAutoMatch(){
		return isAutoMatch;
	}
		
	public void setIsAutoMatch(int isAutoMatch){
		this.isAutoMatch = isAutoMatch;
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamAutoMatch(this.getSession().getPlayer(), this);
	}
}