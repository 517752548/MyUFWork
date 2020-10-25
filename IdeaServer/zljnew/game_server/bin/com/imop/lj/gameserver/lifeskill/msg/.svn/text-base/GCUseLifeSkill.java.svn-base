package com.imop.lj.gameserver.lifeskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 使用生活技能结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCUseLifeSkill extends GCMessage{
	
	/** 采集状态,0未在采集,1-伐木,2-采药,3-采矿,4-狩猎 */
	private int result;

	public GCUseLifeSkill (){
	}
	
	public GCUseLifeSkill (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 采集状态,0未在采集,1-伐木,2-采药,3-采矿,4-狩猎
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 采集状态,0未在采集,1-伐木,2-采药,3-采矿,4-狩猎
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_USE_LIFE_SKILL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_USE_LIFE_SKILL";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}