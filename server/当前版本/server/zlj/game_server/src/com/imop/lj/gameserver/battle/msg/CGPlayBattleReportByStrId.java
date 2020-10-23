package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.battle.handler.BattleHandlerFactory;

/**
 * 客户端请求播放战报
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlayBattleReportByStrId extends CGMessage{
	
	/** 战报id字符串类型 */
	private String idStr;
	/** 战报读取完毕以后，前端返回场景id */
	private int toBackType;
	
	public CGPlayBattleReportByStrId (){
	}
	
	public CGPlayBattleReportByStrId (
			String idStr,
			int toBackType ){
			this.idStr = idStr;
			this.toBackType = toBackType;
	}
	
	@Override
	protected boolean readImpl() {

	// 战报id字符串类型
	String _idStr = readString();
	//end


	// 战报读取完毕以后，前端返回场景id
	int _toBackType = readInteger();
	//end



			this.idStr = _idStr;
			this.toBackType = _toBackType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 战报id字符串类型
	writeString(idStr);


	// 战报读取完毕以后，前端返回场景id
	writeInteger(toBackType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PLAY_BATTLE_REPORT_BY_STR_ID;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PLAY_BATTLE_REPORT_BY_STR_ID";
	}

	public String getIdStr(){
		return idStr;
	}
		
	public void setIdStr(String idStr){
		this.idStr = idStr;
	}

	public int getToBackType(){
		return toBackType;
	}
		
	public void setToBackType(int toBackType){
		this.toBackType = toBackType;
	}


	@Override
	public void execute() {
		BattleHandlerFactory.getHandler().handlePlayBattleReportByStrId(this.getSession().getPlayer(), this);
	}
}