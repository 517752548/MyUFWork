package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 进入玩家角色人数
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCGameEnterPlayerNum extends GCMessage{
	
	/** 进入玩家角色人数 */
	private int enterPlayerNum;

	public GCGameEnterPlayerNum (){
	}
	
	public GCGameEnterPlayerNum (
			int enterPlayerNum ){
			this.enterPlayerNum = enterPlayerNum;
	}

	@Override
	protected boolean readImpl() {

	// 进入玩家角色人数
	int _enterPlayerNum = readInteger();
	//end



		this.enterPlayerNum = _enterPlayerNum;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 进入玩家角色人数
	writeInteger(enterPlayerNum);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_GAME_ENTER_PLAYER_NUM;
	}
	
	@Override
	public String getTypeName() {
		return "GC_GAME_ENTER_PLAYER_NUM";
	}

	public int getEnterPlayerNum(){
		return enterPlayerNum;
	}
		
	public void setEnterPlayerNum(int enterPlayerNum){
		this.enterPlayerNum = enterPlayerNum;
	}
}