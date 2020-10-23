package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.battle.handler.BattleHandlerFactory;

/**
 * 客户端请求播放战报
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayBattleReport extends CGMessage{
	
	/** 战报id，Long格式，包含日期信息 */
	private long id;
	/** 战报读取完毕以后，前端返回场景id */
	private int toBackType;
	
	public CGPlayBattleReport (){
	}
	
	public CGPlayBattleReport (
			long id,
			int toBackType ){
			this.id = id;
			this.toBackType = toBackType;
	}
	
	@Override
	protected boolean readImpl() {

	// 战报id，Long格式，包含日期信息
	long _id = readLong();
	//end


	// 战报读取完毕以后，前端返回场景id
	int _toBackType = readInteger();
	//end



			this.id = _id;
			this.toBackType = _toBackType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 战报id，Long格式，包含日期信息
	writeLong(id);


	// 战报读取完毕以后，前端返回场景id
	writeInteger(toBackType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PLAY_BATTLE_REPORT;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PLAY_BATTLE_REPORT";
	}

	public long getId(){
		return id;
	}
		
	public void setId(long id){
		this.id = id;
	}

	public int getToBackType(){
		return toBackType;
	}
		
	public void setToBackType(int toBackType){
		this.toBackType = toBackType;
	}


	@Override
	public void execute() {
		BattleHandlerFactory.getHandler().handlePlayBattleReport(this.getSession().getPlayer(), this);
	}
}