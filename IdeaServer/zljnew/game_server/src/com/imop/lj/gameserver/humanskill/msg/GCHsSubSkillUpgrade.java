package com.imop.lj.gameserver.humanskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 人物技能升级结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCHsSubSkillUpgrade extends GCMessage{
	
	/** 结果 1成功,2失败 */
	private int result;

	public GCHsSubSkillUpgrade (){
	}
	
	public GCHsSubSkillUpgrade (
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
		return MessageType.GC_HS_SUB_SKILL_UPGRADE;
	}
	
	@Override
	public String getTypeName() {
		return "GC_HS_SUB_SKILL_UPGRADE";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}