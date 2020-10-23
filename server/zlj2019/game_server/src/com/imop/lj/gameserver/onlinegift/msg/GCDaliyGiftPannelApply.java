package com.imop.lj.gameserver.onlinegift.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 申请每日签到面板信息结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDaliyGiftPannelApply extends GCMessage{
	
	/** 本月累计签到天数 */
	private int signedNum;
	/** 剩余补签次数 */
	private int restRetroactiveNum;
	/** 是否可用补签(1是2否) */
	private int canUseRetroacte;
	/** 今天是否已经签到(1是2否) */
	private int isAlreadySign;
	/** 本月应该有多少天 */
	private int daysOfMonth;

	public GCDaliyGiftPannelApply (){
	}
	
	public GCDaliyGiftPannelApply (
			int signedNum,
			int restRetroactiveNum,
			int canUseRetroacte,
			int isAlreadySign,
			int daysOfMonth ){
			this.signedNum = signedNum;
			this.restRetroactiveNum = restRetroactiveNum;
			this.canUseRetroacte = canUseRetroacte;
			this.isAlreadySign = isAlreadySign;
			this.daysOfMonth = daysOfMonth;
	}

	@Override
	protected boolean readImpl() {

	// 本月累计签到天数
	int _signedNum = readInteger();
	//end


	// 剩余补签次数
	int _restRetroactiveNum = readInteger();
	//end


	// 是否可用补签(1是2否)
	int _canUseRetroacte = readInteger();
	//end


	// 今天是否已经签到(1是2否)
	int _isAlreadySign = readInteger();
	//end


	// 本月应该有多少天
	int _daysOfMonth = readInteger();
	//end



		this.signedNum = _signedNum;
		this.restRetroactiveNum = _restRetroactiveNum;
		this.canUseRetroacte = _canUseRetroacte;
		this.isAlreadySign = _isAlreadySign;
		this.daysOfMonth = _daysOfMonth;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 本月累计签到天数
	writeInteger(signedNum);


	// 剩余补签次数
	writeInteger(restRetroactiveNum);


	// 是否可用补签(1是2否)
	writeInteger(canUseRetroacte);


	// 今天是否已经签到(1是2否)
	writeInteger(isAlreadySign);


	// 本月应该有多少天
	writeInteger(daysOfMonth);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_DALIY_GIFT_PANNEL_APPLY;
	}
	
	@Override
	public String getTypeName() {
		return "GC_DALIY_GIFT_PANNEL_APPLY";
	}

	public int getSignedNum(){
		return signedNum;
	}
		
	public void setSignedNum(int signedNum){
		this.signedNum = signedNum;
	}

	public int getRestRetroactiveNum(){
		return restRetroactiveNum;
	}
		
	public void setRestRetroactiveNum(int restRetroactiveNum){
		this.restRetroactiveNum = restRetroactiveNum;
	}

	public int getCanUseRetroacte(){
		return canUseRetroacte;
	}
		
	public void setCanUseRetroacte(int canUseRetroacte){
		this.canUseRetroacte = canUseRetroacte;
	}

	public int getIsAlreadySign(){
		return isAlreadySign;
	}
		
	public void setIsAlreadySign(int isAlreadySign){
		this.isAlreadySign = isAlreadySign;
	}

	public int getDaysOfMonth(){
		return daysOfMonth;
	}
		
	public void setDaysOfMonth(int daysOfMonth){
		this.daysOfMonth = daysOfMonth;
	}
}