package com.imop.lj.gameserver.lifeskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 生活技能升级结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCLifeSkillUpgrade extends GCMessage{
	
	/** 结果 1成功,2失败 */
	private int result;

	public GCLifeSkillUpgrade (){
	}
	
	public GCLifeSkillUpgrade (
			int result ){
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 结果 1成功,2失败
	int _result = readInteger();
	//end



		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 结果 1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_LIFE_SKILL_UPGRADE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_LIFE_SKILL_UPGRADE";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}