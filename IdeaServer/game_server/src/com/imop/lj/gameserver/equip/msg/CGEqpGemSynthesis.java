package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.equip.handler.EquipHandlerFactory;

/**
 * 合成宝石
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGEqpGemSynthesis extends CGMessage{
	
	/** 宝石模板Id */
	private int gemTplId;
	/** 合成基数 3 三合一 4 四合一 5 五合一 */
	private int synthesisBase;
	/** 合成方式 0单个1全部 */
	private int synthesisType;
	
	public CGEqpGemSynthesis (){
	}
	
	public CGEqpGemSynthesis (
			int gemTplId,
			int synthesisBase,
			int synthesisType ){
			this.gemTplId = gemTplId;
			this.synthesisBase = synthesisBase;
			this.synthesisType = synthesisType;
	}
	
	@Override
	protected boolean readImpl() {

	// 宝石模板Id
	int _gemTplId = readInteger();
	//end


	// 合成基数 3 三合一 4 四合一 5 五合一
	int _synthesisBase = readInteger();
	//end


	// 合成方式 0单个1全部
	int _synthesisType = readInteger();
	//end



			this.gemTplId = _gemTplId;
			this.synthesisBase = _synthesisBase;
			this.synthesisType = _synthesisType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 宝石模板Id
	writeInteger(gemTplId);


	// 合成基数 3 三合一 4 四合一 5 五合一
	writeInteger(synthesisBase);


	// 合成方式 0单个1全部
	writeInteger(synthesisType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_EQP_GEM_SYNTHESIS;
	}
	
	@Override
	public String getTypeName() {
		return "CG_EQP_GEM_SYNTHESIS";
	}

	public int getGemTplId(){
		return gemTplId;
	}
		
	public void setGemTplId(int gemTplId){
		this.gemTplId = gemTplId;
	}

	public int getSynthesisBase(){
		return synthesisBase;
	}
		
	public void setSynthesisBase(int synthesisBase){
		this.synthesisBase = synthesisBase;
	}

	public int getSynthesisType(){
		return synthesisType;
	}
		
	public void setSynthesisType(int synthesisType){
		this.synthesisType = synthesisType;
	}


	@Override
	public void execute() {
		EquipHandlerFactory.getHandler().handleEqpGemSynthesis(this.getSession().getPlayer(), this);
	}
}