package com.imop.lj.gameserver.overman.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 可以领取奖励,没有可以领奖就空
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOvermanHongdian extends GCMessage{
	
	/** 奖励信息 */
	private long[] rewardInfo;

	public GCOvermanHongdian (){
	}
	
	public GCOvermanHongdian (
			long[] rewardInfo ){
			this.rewardInfo = rewardInfo;
	}

	@Override
	protected boolean readImpl() {

	// 奖励信息
	int rewardInfoSize = readUnsignedShort();
	long[] _rewardInfo = new long[rewardInfoSize];
	int rewardInfoIndex = 0;
	for(rewardInfoIndex=0; rewardInfoIndex<rewardInfoSize; rewardInfoIndex++){
		_rewardInfo[rewardInfoIndex] = readLong();
	}//end



		this.rewardInfo = _rewardInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 奖励信息
	writeShort(rewardInfo.length);
	int rewardInfoSize = rewardInfo.length;
	int rewardInfoIndex = 0;
	for(rewardInfoIndex=0; rewardInfoIndex<rewardInfoSize; rewardInfoIndex++){
		writeLong(rewardInfo [ rewardInfoIndex ]);
	}//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OVERMAN_HONGDIAN;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OVERMAN_HONGDIAN";
	}

	public long[] getRewardInfo(){
		return rewardInfo;
	}

	public void setRewardInfo(long[] rewardInfo){
		this.rewardInfo = rewardInfo;
	}	
}