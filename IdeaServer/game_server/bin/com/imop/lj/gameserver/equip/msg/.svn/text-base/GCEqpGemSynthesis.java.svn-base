package com.imop.lj.gameserver.equip.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 合成结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCEqpGemSynthesis extends GCMessage{
	
	/** 合成成功数量 */
	private int sucNum;
	/** 合成失败数量 */
	private int failNum;
	/** 合成失败返回道具数量 */
	private int rewardNum;

	public GCEqpGemSynthesis (){
	}
	
	public GCEqpGemSynthesis (
			int sucNum,
			int failNum,
			int rewardNum ){
			this.sucNum = sucNum;
			this.failNum = failNum;
			this.rewardNum = rewardNum;
	}

	@Override
	protected boolean readImpl() {

	// 合成成功数量
	int _sucNum = readInteger();
	//end


	// 合成失败数量
	int _failNum = readInteger();
	//end


	// 合成失败返回道具数量
	int _rewardNum = readInteger();
	//end



		this.sucNum = _sucNum;
		this.failNum = _failNum;
		this.rewardNum = _rewardNum;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 合成成功数量
	writeInteger(sucNum);


	// 合成失败数量
	writeInteger(failNum);


	// 合成失败返回道具数量
	writeInteger(rewardNum);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_EQP_GEM_SYNTHESIS;
	}
	
	@Override
	public String getTypeName() {
		return "GC_EQP_GEM_SYNTHESIS";
	}

	public int getSucNum(){
		return sucNum;
	}
		
	public void setSucNum(int sucNum){
		this.sucNum = sucNum;
	}

	public int getFailNum(){
		return failNum;
	}
		
	public void setFailNum(int failNum){
		this.failNum = failNum;
	}

	public int getRewardNum(){
		return rewardNum;
	}
		
	public void setRewardNum(int rewardNum){
		this.rewardNum = rewardNum;
	}
}