package com.imop.lj.gameserver.map.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.map.handler.MapHandlerFactory;

/**
 * 玩家请求与npc战斗
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGMapFightNpc extends CGMessage{
	
	/** npcId */
	private int npcId;
	/** 唯一Id */
	private String uuid;
	
	public CGMapFightNpc (){
	}
	
	public CGMapFightNpc (
			int npcId,
			String uuid ){
			this.npcId = npcId;
			this.uuid = uuid;
	}
	
	@Override
	protected boolean readImpl() {

	// npcId
	int _npcId = readInteger();
	//end


	// 唯一Id
	String _uuid = readString();
	//end



			this.npcId = _npcId;
			this.uuid = _uuid;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// npcId
	writeInteger(npcId);


	// 唯一Id
	writeString(uuid);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_MAP_FIGHT_NPC;
	}
	
	@Override
	public String getTypeName() {
		return "CG_MAP_FIGHT_NPC";
	}

	public int getNpcId(){
		return npcId;
	}
		
	public void setNpcId(int npcId){
		this.npcId = npcId;
	}

	public String getUuid(){
		return uuid;
	}
		
	public void setUuid(String uuid){
		this.uuid = uuid;
	}


	@Override
	public void execute() {
		MapHandlerFactory.getHandler().handleMapFightNpc(this.getSession().getPlayer(), this);
	}
}