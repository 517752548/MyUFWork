package com.imop.lj.gameserver.humanskill.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.humanskill.handler.HumanskillHandlerFactory;

/**
 * 心法升级
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGHsMainSkillUpgrade extends CGMessage{
	
	/** 心法ID */
	private int mindId;
	/** 修炼方式是否批量,0-否,1-是 */
	private int isBatch;
	
	public CGHsMainSkillUpgrade (){
	}
	
	public CGHsMainSkillUpgrade (
			int mindId,
			int isBatch ){
			this.mindId = mindId;
			this.isBatch = isBatch;
	}
	
	@Override
	protected boolean readImpl() {

	// 心法ID
	int _mindId = readInteger();
	//end


	// 修炼方式是否批量,0-否,1-是
	int _isBatch = readInteger();
	//end



			this.mindId = _mindId;
			this.isBatch = _isBatch;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 心法ID
	writeInteger(mindId);


	// 修炼方式是否批量,0-否,1-是
	writeInteger(isBatch);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_HS_MAIN_SKILL_UPGRADE;
	}
	
	@Override
	public String getTypeName() {
		return "CG_HS_MAIN_SKILL_UPGRADE";
	}

	public int getMindId(){
		return mindId;
	}
		
	public void setMindId(int mindId){
		this.mindId = mindId;
	}

	public int getIsBatch(){
		return isBatch;
	}
		
	public void setIsBatch(int isBatch){
		this.isBatch = isBatch;
	}


	@Override
	public void execute() {
		HumanskillHandlerFactory.getHandler().handleHsMainSkillUpgrade(this.getSession().getPlayer(), this);
	}
}