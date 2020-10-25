package com.imop.lj.gameserver.corpsboss.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回队长请求挑战帮派boss
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCCorpsbossAskEnterTeam extends GCMessage{
	
	/** boss进度 */
	private int bossLevel;

	public GCCorpsbossAskEnterTeam (){
	}
	
	public GCCorpsbossAskEnterTeam (
			int bossLevel ){
			this.bossLevel = bossLevel;
	}

	@Override
	protected boolean readImpl() {

	// boss进度
	int _bossLevel = readInteger();
	//end



		this.bossLevel = _bossLevel;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// boss进度
	writeInteger(bossLevel);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_CORPSBOSS_ASK_ENTER_TEAM;
	}
	
	@Override
	public String getTypeName() {
		return "GC_CORPSBOSS_ASK_ENTER_TEAM";
	}

	public int getBossLevel(){
		return bossLevel;
	}
		
	public void setBossLevel(int bossLevel){
		this.bossLevel = bossLevel;
	}
}