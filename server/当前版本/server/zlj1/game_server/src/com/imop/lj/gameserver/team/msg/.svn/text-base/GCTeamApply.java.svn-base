package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 申请加入队伍成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCTeamApply extends GCMessage{
	
	/** 队伍Id */
	private int teamId;

	public GCTeamApply (){
	}
	
	public GCTeamApply (
			int teamId ){
			this.teamId = teamId;
	}

	@Override
	protected boolean readImpl() {

	// 队伍Id
	int _teamId = readInteger();
	//end



		this.teamId = _teamId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 队伍Id
	writeInteger(teamId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_TEAM_APPLY;
	}
	
	@Override
	public String getTypeName() {
		return "GC_TEAM_APPLY";
	}

	public int getTeamId(){
		return teamId;
	}
		
	public void setTeamId(int teamId){
		this.teamId = teamId;
	}
}