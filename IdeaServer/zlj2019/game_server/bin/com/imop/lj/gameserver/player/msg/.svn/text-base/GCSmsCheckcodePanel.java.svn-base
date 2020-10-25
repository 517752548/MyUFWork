package com.imop.lj.gameserver.player.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 手机验证面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCSmsCheckcodePanel extends GCMessage{
	
	/** 是否已经通过验证，1已通过验证，2未通过验证 */
	private int result;
	/** QQ号，已通过验证时有效 */
	private String qqNum;
	/** 手机号，已通过验证时有效 */
	private String phoneNum;
	/** 手机验证奖励信息 */
	private com.imop.lj.common.model.reward.RewardInfo rewardInfos;

	public GCSmsCheckcodePanel (){
	}
	
	public GCSmsCheckcodePanel (
			int result,
			String qqNum,
			String phoneNum,
			com.imop.lj.common.model.reward.RewardInfo rewardInfos ){
			this.result = result;
			this.qqNum = qqNum;
			this.phoneNum = phoneNum;
			this.rewardInfos = rewardInfos;
	}

	@Override
	protected boolean readImpl() {

	// 是否已经通过验证，1已通过验证，2未通过验证
	int _result = readInteger();
	//end


	// QQ号，已通过验证时有效
	String _qqNum = readString();
	//end


	// 手机号，已通过验证时有效
	String _phoneNum = readString();
	//end

	// 手机验证奖励信息
	com.imop.lj.common.model.reward.RewardInfo _rewardInfos = new com.imop.lj.common.model.reward.RewardInfo();

	// 奖励信息
	String _rewardInfos_rewardStr = readString();
	//end
	_rewardInfos.setRewardStr (_rewardInfos_rewardStr);



		this.result = _result;
		this.qqNum = _qqNum;
		this.phoneNum = _phoneNum;
		this.rewardInfos = _rewardInfos;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 是否已经通过验证，1已通过验证，2未通过验证
	writeInteger(result);


	// QQ号，已通过验证时有效
	writeString(qqNum);


	// 手机号，已通过验证时有效
	writeString(phoneNum);


	String rewardInfos_rewardStr = rewardInfos.getRewardStr ();

	// 奖励信息
	writeString(rewardInfos_rewardStr);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_SMS_CHECKCODE_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_SMS_CHECKCODE_PANEL";
	}

	public int getResult(){
		return result;
	}
		
	public void setResult(int result){
		this.result = result;
	}

	public String getQqNum(){
		return qqNum;
	}
		
	public void setQqNum(String qqNum){
		this.qqNum = qqNum;
	}

	public String getPhoneNum(){
		return phoneNum;
	}
		
	public void setPhoneNum(String phoneNum){
		this.phoneNum = phoneNum;
	}

	public com.imop.lj.common.model.reward.RewardInfo getRewardInfos(){
		return rewardInfos;
	}
		
	public void setRewardInfos(com.imop.lj.common.model.reward.RewardInfo rewardInfos){
		this.rewardInfos = rewardInfos;
	}
}