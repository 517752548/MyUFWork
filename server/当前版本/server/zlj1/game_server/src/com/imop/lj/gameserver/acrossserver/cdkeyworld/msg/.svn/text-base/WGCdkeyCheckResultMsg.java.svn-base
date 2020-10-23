package com.imop.lj.gameserver.acrossserver.cdkeyworld.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.acrossserver.msg.WGMessage;
/**
 * 向gameserver请求验证结果
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class WGCdkeyCheckResultMsg extends WGMessage{
	
	/** 角色UUId */
	private long charUUId;
	/** 是否可用：1可以用，0不可用 */
	private int canUse;
	/** 奖励字符串 */
	private String rewardStr;
	/** 不可以领取原因：1输入码错误，2已经领取  */
	private int failReason;

	public WGCdkeyCheckResultMsg (){
	}
	
	public WGCdkeyCheckResultMsg (
			long charUUId,
			int canUse,
			String rewardStr,
			int failReason ){
			this.charUUId = charUUId;
			this.canUse = canUse;
			this.rewardStr = rewardStr;
			this.failReason = failReason;
	}

	@Override
	protected boolean readImpl() {

	// 角色UUId
	long _charUUId = readLong();
	//end


	// 是否可用：1可以用，0不可用
	int _canUse = readInteger();
	//end


	// 奖励字符串
	String _rewardStr = readString();
	//end


	// 不可以领取原因：1输入码错误，2已经领取 
	int _failReason = readInteger();
	//end



		this.charUUId = _charUUId;
		this.canUse = _canUse;
		this.rewardStr = _rewardStr;
		this.failReason = _failReason;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {
		writeLong(charUUId);
		writeInteger(canUse);
		writeString(rewardStr);
		writeInteger(failReason);
		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.WG_CDKEY_CHECK_RESULT_MSG;
	}
	
	@Override
	public String getTypeName() {
		return "WG_CDKEY_CHECK_RESULT_MSG";
	}

	public long getCharUUId(){
		return charUUId;
	}
		
	public void setCharUUId(long charUUId){
		this.charUUId = charUUId;
	}

	public int getCanUse(){
		return canUse;
	}
		
	public void setCanUse(int canUse){
		this.canUse = canUse;
	}

	public String getRewardStr(){
		return rewardStr;
	}
		
	public void setRewardStr(String rewardStr){
		this.rewardStr = rewardStr;
	}

	public int getFailReason(){
		return failReason;
	}
		
	public void setFailReason(int failReason){
		this.failReason = failReason;
	}
}