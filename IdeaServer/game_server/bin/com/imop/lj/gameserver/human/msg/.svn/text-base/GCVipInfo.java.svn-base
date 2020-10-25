package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 玩家vip信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCVipInfo extends GCMessage{
	
	/** vip等级 */
	private int level;
	/** vip经验 */
	private int exp;
	/** 临时vip等级 */
	private int tmpLevel;
	/** 临时vip剩余有效时间 */
	private long leftTime;
	/** 类型，0普通，1临时 */
	private int vType;
	/** 是否充过钱，0否，1是 */
	private int isCharge;
	/** 今日奖励是否可领取，0否，1是 */
	private int canGetDayReward;

	public GCVipInfo (){
	}
	
	public GCVipInfo (
			int level,
			int exp,
			int tmpLevel,
			long leftTime,
			int vType,
			int isCharge,
			int canGetDayReward ){
			this.level = level;
			this.exp = exp;
			this.tmpLevel = tmpLevel;
			this.leftTime = leftTime;
			this.vType = vType;
			this.isCharge = isCharge;
			this.canGetDayReward = canGetDayReward;
	}

	@Override
	protected boolean readImpl() {

	// vip等级
	int _level = readInteger();
	//end


	// vip经验
	int _exp = readInteger();
	//end


	// 临时vip等级
	int _tmpLevel = readInteger();
	//end


	// 临时vip剩余有效时间
	long _leftTime = readLong();
	//end


	// 类型，0普通，1临时
	int _vType = readInteger();
	//end


	// 是否充过钱，0否，1是
	int _isCharge = readInteger();
	//end


	// 今日奖励是否可领取，0否，1是
	int _canGetDayReward = readInteger();
	//end



		this.level = _level;
		this.exp = _exp;
		this.tmpLevel = _tmpLevel;
		this.leftTime = _leftTime;
		this.vType = _vType;
		this.isCharge = _isCharge;
		this.canGetDayReward = _canGetDayReward;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// vip等级
	writeInteger(level);


	// vip经验
	writeInteger(exp);


	// 临时vip等级
	writeInteger(tmpLevel);


	// 临时vip剩余有效时间
	writeLong(leftTime);


	// 类型，0普通，1临时
	writeInteger(vType);


	// 是否充过钱，0否，1是
	writeInteger(isCharge);


	// 今日奖励是否可领取，0否，1是
	writeInteger(canGetDayReward);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_VIP_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_VIP_INFO";
	}

	public int getLevel(){
		return level;
	}
		
	public void setLevel(int level){
		this.level = level;
	}

	public int getExp(){
		return exp;
	}
		
	public void setExp(int exp){
		this.exp = exp;
	}

	public int getTmpLevel(){
		return tmpLevel;
	}
		
	public void setTmpLevel(int tmpLevel){
		this.tmpLevel = tmpLevel;
	}

	public long getLeftTime(){
		return leftTime;
	}
		
	public void setLeftTime(long leftTime){
		this.leftTime = leftTime;
	}

	public int getVType(){
		return vType;
	}
		
	public void setVType(int vType){
		this.vType = vType;
	}

	public int getIsCharge(){
		return isCharge;
	}
		
	public void setIsCharge(int isCharge){
		this.isCharge = isCharge;
	}

	public int getCanGetDayReward(){
		return canGetDayReward;
	}
		
	public void setCanGetDayReward(int canGetDayReward){
		this.canGetDayReward = canGetDayReward;
	}
}