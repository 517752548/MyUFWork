package com.imop.lj.gameserver.arena.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 消除竞技场cd成功
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCArenaKillCd extends GCMessage{
	

	public GCArenaKillCd (){
	}
	

	@Override
	protected boolean readImpl() {


		return true;
	}
	
	@Override
	protected boolean writeImpl() {

		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_ARENA_KILL_CD;
	}
	
	@Override
	public String getTypeName() {
		return "GC_ARENA_KILL_CD";
	}
}