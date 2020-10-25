package com.imop.lj.gameserver.human.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 仙葫面板消息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCXianhuPanel extends GCMessage{
	
	/** 祝福已开启次数 */
	private int zhufuNum;
	/** 祈福已开启次数 */
	private int qifuNum;
	/** 富贵仙葫可领取次数 */
	private int fuguiNum;
	/** 至尊仙葫可领取次数 */
	private int zhizunNum;
	/** 祝福祈福显示奖励id */
	private int rewardId;
	/** 富贵仙葫显示奖励id */
	private int fuguiRewardId;
	/** 至尊仙葫显示奖励id */
	private int zhizunRewardId;

	public GCXianhuPanel (){
	}
	
	public GCXianhuPanel (
			int zhufuNum,
			int qifuNum,
			int fuguiNum,
			int zhizunNum,
			int rewardId,
			int fuguiRewardId,
			int zhizunRewardId ){
			this.zhufuNum = zhufuNum;
			this.qifuNum = qifuNum;
			this.fuguiNum = fuguiNum;
			this.zhizunNum = zhizunNum;
			this.rewardId = rewardId;
			this.fuguiRewardId = fuguiRewardId;
			this.zhizunRewardId = zhizunRewardId;
	}

	@Override
	protected boolean readImpl() {

	// 祝福已开启次数
	int _zhufuNum = readInteger();
	//end


	// 祈福已开启次数
	int _qifuNum = readInteger();
	//end


	// 富贵仙葫可领取次数
	int _fuguiNum = readInteger();
	//end


	// 至尊仙葫可领取次数
	int _zhizunNum = readInteger();
	//end


	// 祝福祈福显示奖励id
	int _rewardId = readInteger();
	//end


	// 富贵仙葫显示奖励id
	int _fuguiRewardId = readInteger();
	//end


	// 至尊仙葫显示奖励id
	int _zhizunRewardId = readInteger();
	//end



		this.zhufuNum = _zhufuNum;
		this.qifuNum = _qifuNum;
		this.fuguiNum = _fuguiNum;
		this.zhizunNum = _zhizunNum;
		this.rewardId = _rewardId;
		this.fuguiRewardId = _fuguiRewardId;
		this.zhizunRewardId = _zhizunRewardId;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 祝福已开启次数
	writeInteger(zhufuNum);


	// 祈福已开启次数
	writeInteger(qifuNum);


	// 富贵仙葫可领取次数
	writeInteger(fuguiNum);


	// 至尊仙葫可领取次数
	writeInteger(zhizunNum);


	// 祝福祈福显示奖励id
	writeInteger(rewardId);


	// 富贵仙葫显示奖励id
	writeInteger(fuguiRewardId);


	// 至尊仙葫显示奖励id
	writeInteger(zhizunRewardId);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_XIANHU_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_XIANHU_PANEL";
	}

	public int getZhufuNum(){
		return zhufuNum;
	}
		
	public void setZhufuNum(int zhufuNum){
		this.zhufuNum = zhufuNum;
	}

	public int getQifuNum(){
		return qifuNum;
	}
		
	public void setQifuNum(int qifuNum){
		this.qifuNum = qifuNum;
	}

	public int getFuguiNum(){
		return fuguiNum;
	}
		
	public void setFuguiNum(int fuguiNum){
		this.fuguiNum = fuguiNum;
	}

	public int getZhizunNum(){
		return zhizunNum;
	}
		
	public void setZhizunNum(int zhizunNum){
		this.zhizunNum = zhizunNum;
	}

	public int getRewardId(){
		return rewardId;
	}
		
	public void setRewardId(int rewardId){
		this.rewardId = rewardId;
	}

	public int getFuguiRewardId(){
		return fuguiRewardId;
	}
		
	public void setFuguiRewardId(int fuguiRewardId){
		this.fuguiRewardId = fuguiRewardId;
	}

	public int getZhizunRewardId(){
		return zhizunRewardId;
	}
		
	public void setZhizunRewardId(int zhizunRewardId){
		this.zhizunRewardId = zhizunRewardId;
	}
}