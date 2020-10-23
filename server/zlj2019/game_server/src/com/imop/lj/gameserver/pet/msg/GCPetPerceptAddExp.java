package com.imop.lj.gameserver.pet.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 宠物悟性提升结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPetPerceptAddExp extends GCMessage{
	
	/** 武将唯一Id */
	private long petId;
	/** 小暴击触发次数 */
	private int smallCritNum;
	/** 小暴击触发共获得经验和 */
	private long smallCritSumExp;
	/** 大暴击触发次数 */
	private int bigCritNum;
	/** 普通获得经验和 */
	private long normalSumExp;
	/** 1成功,2失败 */
	private int result;

	public GCPetPerceptAddExp (){
	}
	
	public GCPetPerceptAddExp (
			long petId,
			int smallCritNum,
			long smallCritSumExp,
			int bigCritNum,
			long normalSumExp,
			int result ){
			this.petId = petId;
			this.smallCritNum = smallCritNum;
			this.smallCritSumExp = smallCritSumExp;
			this.bigCritNum = bigCritNum;
			this.normalSumExp = normalSumExp;
			this.result = result;
	}

	@Override
	protected boolean readImpl() {

	// 武将唯一Id
	long _petId = readLong();
	//end


	// 小暴击触发次数
	int _smallCritNum = readInteger();
	//end


	// 小暴击触发共获得经验和
	long _smallCritSumExp = readLong();
	//end


	// 大暴击触发次数
	int _bigCritNum = readInteger();
	//end


	// 普通获得经验和
	long _normalSumExp = readLong();
	//end


	// 1成功,2失败
	int _result = readInteger();
	//end



		this.petId = _petId;
		this.smallCritNum = _smallCritNum;
		this.smallCritSumExp = _smallCritSumExp;
		this.bigCritNum = _bigCritNum;
		this.normalSumExp = _normalSumExp;
		this.result = _result;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 武将唯一Id
	writeLong(petId);


	// 小暴击触发次数
	writeInteger(smallCritNum);


	// 小暴击触发共获得经验和
	writeLong(smallCritSumExp);


	// 大暴击触发次数
	writeInteger(bigCritNum);


	// 普通获得经验和
	writeLong(normalSumExp);


	// 1成功,2失败
	writeInteger(result);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PET_PERCEPT_ADD_EXP;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PET_PERCEPT_ADD_EXP";
	}

	public long getPetId(){
		return petId;
	}
		
	public void setPetId(long petId){
		this.petId = petId;
	}

	public int getSmallCritNum(){
		return smallCritNum;
	}
		
	public void setSmallCritNum(int smallCritNum){
		this.smallCritNum = smallCritNum;
	}

	public long getSmallCritSumExp(){
		return smallCritSumExp;
	}
		
	public void setSmallCritSumExp(long smallCritSumExp){
		this.smallCritSumExp = smallCritSumExp;
	}

	public int getBigCritNum(){
		return bigCritNum;
	}
		
	public void setBigCritNum(int bigCritNum){
		this.bigCritNum = bigCritNum;
	}

	public long getNormalSumExp(){
		return normalSumExp;
	}
		
	public void setNormalSumExp(long normalSumExp){
		this.normalSumExp = normalSumExp;
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}
}