package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 离线奖励信息，一个奖励
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOfflinerewardInfo extends GCMessage{
	
	/** 离线奖励类型 */
	private int offlineRewardType;
	/** 创建时间 */
	private String createTime;
	/** 离线奖励描述信息 */
	private String props;
	/** 具体奖励信息 */
	private com.imop.lj.common.model.reward.RewardInfo rewardInfos;

	public GCOfflinerewardInfo (){
	}
	
	public GCOfflinerewardInfo (
			int offlineRewardType,
			String createTime,
			String props,
			com.imop.lj.common.model.reward.RewardInfo rewardInfos ){
			this.offlineRewardType = offlineRewardType;
			this.createTime = createTime;
			this.props = props;
			this.rewardInfos = rewardInfos;
	}

	@Override
	protected boolean readImpl() {

	// 离线奖励类型
	int _offlineRewardType = readInteger();
	//end


	// 创建时间
	String _createTime = readString();
	//end


	// 离线奖励描述信息
	String _props = readString();
	//end

	// 具体奖励信息
	com.imop.lj.common.model.reward.RewardInfo _rewardInfos = new com.imop.lj.common.model.reward.RewardInfo();

	// 奖励信息
	String _rewardInfos_rewardStr = readString();
	//end
	_rewardInfos.setRewardStr (_rewardInfos_rewardStr);



		this.offlineRewardType = _offlineRewardType;
		this.createTime = _createTime;
		this.props = _props;
		this.rewardInfos = _rewardInfos;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 离线奖励类型
	writeInteger(offlineRewardType);


	// 创建时间
	writeString(createTime);


	// 离线奖励描述信息
	writeString(props);


	String rewardInfos_rewardStr = rewardInfos.getRewardStr ();

	// 奖励信息
	writeString(rewardInfos_rewardStr);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OFFLINEREWARD_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OFFLINEREWARD_INFO";
	}

	public int getOfflineRewardType(){
		return offlineRewardType;
	}
		
	public void setOfflineRewardType(int offlineRewardType){
		this.offlineRewardType = offlineRewardType;
	}

	public String getCreateTime(){
		return createTime;
	}
		
	public void setCreateTime(String createTime){
		this.createTime = createTime;
	}

	public String getProps(){
		return props;
	}
		
	public void setProps(String props){
		this.props = props;
	}

	public com.imop.lj.common.model.reward.RewardInfo getRewardInfos(){
		return rewardInfos;
	}
		
	public void setRewardInfos(com.imop.lj.common.model.reward.RewardInfo rewardInfos){
		this.rewardInfos = rewardInfos;
	}
}