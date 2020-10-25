package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回月卡信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCMonthCardInfo extends GCMessage{
	
	/** 是否已购买月卡 */
	private boolean monthFlag;
	/** 是否已领取返利 */
	private boolean giftFlag;
	/** 剩余天数 */
	private int leftDay;

	public GCMonthCardInfo (){
	}
	
	public GCMonthCardInfo (
			boolean monthFlag,
			boolean giftFlag,
			int leftDay ){
			this.monthFlag = monthFlag;
			this.giftFlag = giftFlag;
			this.leftDay = leftDay;
	}

	@Override
	protected boolean readImpl() {

	// 是否已购买月卡
	boolean _monthFlag = readBoolean();
	//end


	// 是否已领取返利
	boolean _giftFlag = readBoolean();
	//end


	// 剩余天数
	int _leftDay = readInteger();
	//end



		this.monthFlag = _monthFlag;
		this.giftFlag = _giftFlag;
		this.leftDay = _leftDay;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否已购买月卡
	writeBoolean(monthFlag);


	// 是否已领取返利
	writeBoolean(giftFlag);


	// 剩余天数
	writeInteger(leftDay);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_MONTH_CARD_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_MONTH_CARD_INFO";
	}

	public boolean getMonthFlag(){
		return monthFlag;
	}
		
	public void setMonthFlag(boolean monthFlag){
		this.monthFlag = monthFlag;
	}

	public boolean getGiftFlag(){
		return giftFlag;
	}
		
	public void setGiftFlag(boolean giftFlag){
		this.giftFlag = giftFlag;
	}

	public int getLeftDay(){
		return leftDay;
	}
		
	public void setLeftDay(int leftDay){
		this.leftDay = leftDay;
	}
}