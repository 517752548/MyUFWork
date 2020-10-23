package com.imop.lj.gameserver.pubtask.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 玩家酒馆任务最大星数
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPubtaskMaxStar extends GCMessage{
	
	/** 玩家酒馆任务最大星数 */
	private int star;

	public GCPubtaskMaxStar (){
	}
	
	public GCPubtaskMaxStar (
			int star ){
			this.star = star;
	}

	@Override
	protected boolean readImpl() {

	// 玩家酒馆任务最大星数
	int _star = readInteger();
	//end



		this.star = _star;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 玩家酒馆任务最大星数
	writeInteger(star);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PUBTASK_MAX_STAR;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PUBTASK_MAX_STAR";
	}

	public int getStar(){
		return star;
	}
		
	public void setStar(int star){
		this.star = star;
	}
}