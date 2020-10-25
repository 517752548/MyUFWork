package com.imop.lj.gameserver.team.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.team.handler.TeamHandlerFactory;

/**
 * 选择队伍的目标
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGTeamChooseTarget extends CGMessage{
	
	/** 目标Id */
	private int targetId;
	/** 等级下限 */
	private int levelMin;
	/** 等级上限 */
	private int levelMax;
	/** 是否自动匹配，0否1是 */
	private int isAutoMatch;
	
	public CGTeamChooseTarget (){
	}
	
	public CGTeamChooseTarget (
			int targetId,
			int levelMin,
			int levelMax,
			int isAutoMatch ){
			this.targetId = targetId;
			this.levelMin = levelMin;
			this.levelMax = levelMax;
			this.isAutoMatch = isAutoMatch;
	}
	
	@Override
	protected boolean readImpl() {

	// 目标Id
	int _targetId = readInteger();
	//end


	// 等级下限
	int _levelMin = readInteger();
	//end


	// 等级上限
	int _levelMax = readInteger();
	//end


	// 是否自动匹配，0否1是
	int _isAutoMatch = readInteger();
	//end



			this.targetId = _targetId;
			this.levelMin = _levelMin;
			this.levelMax = _levelMax;
			this.isAutoMatch = _isAutoMatch;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 目标Id
	writeInteger(targetId);


	// 等级下限
	writeInteger(levelMin);


	// 等级上限
	writeInteger(levelMax);


	// 是否自动匹配，0否1是
	writeInteger(isAutoMatch);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_TEAM_CHOOSE_TARGET;
	}
	
	@Override
	public String getTypeName() {
		return "CG_TEAM_CHOOSE_TARGET";
	}

	public int getTargetId(){
		return targetId;
	}
		
	public void setTargetId(int targetId){
		this.targetId = targetId;
	}

	public int getLevelMin(){
		return levelMin;
	}
		
	public void setLevelMin(int levelMin){
		this.levelMin = levelMin;
	}

	public int getLevelMax(){
		return levelMax;
	}
		
	public void setLevelMax(int levelMax){
		this.levelMax = levelMax;
	}

	public int getIsAutoMatch(){
		return isAutoMatch;
	}
		
	public void setIsAutoMatch(int isAutoMatch){
		this.isAutoMatch = isAutoMatch;
	}


	@Override
	public void execute() {
		TeamHandlerFactory.getHandler().handleTeamChooseTarget(this.getSession().getPlayer(), this);
	}
}