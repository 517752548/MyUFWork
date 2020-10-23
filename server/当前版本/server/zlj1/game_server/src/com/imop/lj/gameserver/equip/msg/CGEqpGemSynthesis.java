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
	
	/** 目标宝石类别 */
	private int gemType;
	/** 目标宝石等级 */
	private int gemLevel;
	/** 合成基数 3 三合一 4 四合一 5 五合一 */
	private int synthesisBase;
	/** 合成方式 1单个2全部 */
	private int synthesisType;
	
	public CGEqpGemSynthesis (){
	}
	
	public CGEqpGemSynthesis (
			int gemType,
			int gemLevel,
			int synthesisBase,
			int synthesisType ){
			this.gemType = gemType;
			this.gemLevel = gemLevel;
			this.synthesisBase = synthesisBase;
			this.synthesisType = synthesisType;
	}
	
	@Override
	protected boolean readImpl() {

	// 目标宝石类别
	int _gemType = readInteger();
	//end


	// 目标宝石等级
	int _gemLevel = readInteger();
	//end


	// 合成基数 3 三合一 4 四合一 5 五合一
	int _synthesisBase = readInteger();
	//end


	// 合成方式 1单个2全部
	int _synthesisType = readInteger();
	//end



			this.gemType = _gemType;
			this.gemLevel = _gemLevel;
			this.synthesisBase = _synthesisBase;
			this.synthesisType = _synthesisType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 目标宝石类别
	writeInteger(gemType);


	// 目标宝石等级
	writeInteger(gemLevel);


	// 合成基数 3 三合一 4 四合一 5 五合一
	writeInteger(synthesisBase);


	// 合成方式 1单个2全部
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

	public int getGemType(){
		return gemType;
	}
		
	public void setGemType(int gemType){
		this.gemType = gemType;
	}

	public int getGemLevel(){
		return gemLevel;
	}
		
	public void setGemLevel(int gemLevel){
		this.gemLevel = gemLevel;
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