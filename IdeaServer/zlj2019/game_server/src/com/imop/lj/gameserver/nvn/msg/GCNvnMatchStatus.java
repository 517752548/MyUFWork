package com.imop.lj.gameserver.nvn.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * nvn队伍状态变化
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCNvnMatchStatus extends GCMessage{
	
	/** 队伍状态 */
	private int teamStatus;

	public GCNvnMatchStatus (){
	}
	
	public GCNvnMatchStatus (
			int teamStatus ){
			this.teamStatus = teamStatus;
	}

	@Override
	protected boolean readImpl() {

	// 队伍状态
	int _teamStatus = readInteger();
	//end



		this.teamStatus = _teamStatus;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 队伍状态
	writeInteger(teamStatus);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_NVN_MATCH_STATUS;
	}
	
	@Override
	public String getTypeName() {
		return "GC_NVN_MATCH_STATUS";
	}

	public int getTeamStatus(){
		return teamStatus;
	}
		
	public void setTeamStatus(int teamStatus){
		this.teamStatus = teamStatus;
	}
}