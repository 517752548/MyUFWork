package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回请求打开帮派红包面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsRedEnvelopePanel extends GCMessage{
	
	/** 帮派发送红包的玩家信息 */
	private com.imop.lj.common.model.corps.CorpsRedEnvelopeInfo[] corpsRedEnvelopeInfoList;

	public GCOpenCorpsRedEnvelopePanel (){
	}
	
	public GCOpenCorpsRedEnvelopePanel (
			com.imop.lj.common.model.corps.CorpsRedEnvelopeInfo[] corpsRedEnvelopeInfoList ){
			this.corpsRedEnvelopeInfoList = corpsRedEnvelopeInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 帮派发送红包的玩家信息
	int corpsRedEnvelopeInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.CorpsRedEnvelopeInfo[] _corpsRedEnvelopeInfoList = new com.imop.lj.common.model.corps.CorpsRedEnvelopeInfo[corpsRedEnvelopeInfoListSize];
	int corpsRedEnvelopeInfoListIndex = 0;
	for(corpsRedEnvelopeInfoListIndex=0; corpsRedEnvelopeInfoListIndex<corpsRedEnvelopeInfoListSize; corpsRedEnvelopeInfoListIndex++){
		_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex] = new com.imop.lj.common.model.corps.CorpsRedEnvelopeInfo();
	// 要领取红包的uuid
	String _corpsRedEnvelopeInfoList_uuid = readString();
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setUuid (_corpsRedEnvelopeInfoList_uuid);

	// 所属帮派Id
	long _corpsRedEnvelopeInfoList_corpsId = readLong();
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setCorpsId (_corpsRedEnvelopeInfoList_corpsId);

	// 发红包玩家id
	long _corpsRedEnvelopeInfoList_sendId = readLong();
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setSendId (_corpsRedEnvelopeInfoList_sendId);

	// 发红包玩家名称
	String _corpsRedEnvelopeInfoList_sendName = readString();
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setSendName (_corpsRedEnvelopeInfoList_sendName);

	// 红包内容
	String _corpsRedEnvelopeInfoList_content = readString();
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setContent (_corpsRedEnvelopeInfoList_content);

	// 红包类型,1-帮派红包
	int _corpsRedEnvelopeInfoList_redEnvelopeType = readInteger();
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setRedEnvelopeType (_corpsRedEnvelopeInfoList_redEnvelopeType);

	// 红包状态,0-不可领取,1-可领取
	int _corpsRedEnvelopeInfoList_redEnvelopeStatus = readInteger();
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setRedEnvelopeStatus (_corpsRedEnvelopeInfoList_redEnvelopeStatus);

	// 发送时间
	long _corpsRedEnvelopeInfoList_createTime = readLong();
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setCreateTime (_corpsRedEnvelopeInfoList_createTime);

	// 红包总金额
	int _corpsRedEnvelopeInfoList_bonusAmount = readInteger();
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setBonusAmount (_corpsRedEnvelopeInfoList_bonusAmount);

	// 剩余红包数量
	int _corpsRedEnvelopeInfoList_remainingNum = readInteger();
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setRemainingNum (_corpsRedEnvelopeInfoList_remainingNum);

	// 剩余红包金额
	int _corpsRedEnvelopeInfoList_remainingBonus = readInteger();
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setRemainingBonus (_corpsRedEnvelopeInfoList_remainingBonus);

	// 帮派抢到红包的玩家信息
	int corpsRedEnvelopeInfoList_openRedEnveloperInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.corps.OpenRedEnveloperInfo[] _corpsRedEnvelopeInfoList_openRedEnveloperInfoList = new com.imop.lj.common.model.corps.OpenRedEnveloperInfo[corpsRedEnvelopeInfoList_openRedEnveloperInfoListSize];
	int corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex = 0;
	for(corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex=0; corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex<corpsRedEnvelopeInfoList_openRedEnveloperInfoListSize; corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex++){
		_corpsRedEnvelopeInfoList_openRedEnveloperInfoList[corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex] = new com.imop.lj.common.model.corps.OpenRedEnveloperInfo();
	// 抢到红包玩家id
	long _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recId = readLong();
	//end
	_corpsRedEnvelopeInfoList_openRedEnveloperInfoList[corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex].setRecId (_corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recId);

	// 抢到红包玩家姓名
	String _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recName = readString();
	//end
	_corpsRedEnvelopeInfoList_openRedEnveloperInfoList[corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex].setRecName (_corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recName);

	// 抢到红包的时间
	long _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_openTime = readLong();
	//end
	_corpsRedEnvelopeInfoList_openRedEnveloperInfoList[corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex].setOpenTime (_corpsRedEnvelopeInfoList_openRedEnveloperInfoList_openTime);

	// 抢到的红包金额
	int _corpsRedEnvelopeInfoList_openRedEnveloperInfoList_gotBonus = readInteger();
	//end
	_corpsRedEnvelopeInfoList_openRedEnveloperInfoList[corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex].setGotBonus (_corpsRedEnvelopeInfoList_openRedEnveloperInfoList_gotBonus);
	}
	//end
	_corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].setOpenRedEnveloperInfoList (_corpsRedEnvelopeInfoList_openRedEnveloperInfoList);
	}
	//end



		this.corpsRedEnvelopeInfoList = _corpsRedEnvelopeInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 帮派发送红包的玩家信息
	writeShort(corpsRedEnvelopeInfoList.length);
	int corpsRedEnvelopeInfoListIndex = 0;
	int corpsRedEnvelopeInfoListSize = corpsRedEnvelopeInfoList.length;
	for(corpsRedEnvelopeInfoListIndex=0; corpsRedEnvelopeInfoListIndex<corpsRedEnvelopeInfoListSize; corpsRedEnvelopeInfoListIndex++){

	String corpsRedEnvelopeInfoList_uuid = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getUuid();

	// 要领取红包的uuid
	writeString(corpsRedEnvelopeInfoList_uuid);

	long corpsRedEnvelopeInfoList_corpsId = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getCorpsId();

	// 所属帮派Id
	writeLong(corpsRedEnvelopeInfoList_corpsId);

	long corpsRedEnvelopeInfoList_sendId = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getSendId();

	// 发红包玩家id
	writeLong(corpsRedEnvelopeInfoList_sendId);

	String corpsRedEnvelopeInfoList_sendName = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getSendName();

	// 发红包玩家名称
	writeString(corpsRedEnvelopeInfoList_sendName);

	String corpsRedEnvelopeInfoList_content = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getContent();

	// 红包内容
	writeString(corpsRedEnvelopeInfoList_content);

	int corpsRedEnvelopeInfoList_redEnvelopeType = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getRedEnvelopeType();

	// 红包类型,1-帮派红包
	writeInteger(corpsRedEnvelopeInfoList_redEnvelopeType);

	int corpsRedEnvelopeInfoList_redEnvelopeStatus = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getRedEnvelopeStatus();

	// 红包状态,0-不可领取,1-可领取
	writeInteger(corpsRedEnvelopeInfoList_redEnvelopeStatus);

	long corpsRedEnvelopeInfoList_createTime = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getCreateTime();

	// 发送时间
	writeLong(corpsRedEnvelopeInfoList_createTime);

	int corpsRedEnvelopeInfoList_bonusAmount = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getBonusAmount();

	// 红包总金额
	writeInteger(corpsRedEnvelopeInfoList_bonusAmount);

	int corpsRedEnvelopeInfoList_remainingNum = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getRemainingNum();

	// 剩余红包数量
	writeInteger(corpsRedEnvelopeInfoList_remainingNum);

	int corpsRedEnvelopeInfoList_remainingBonus = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getRemainingBonus();

	// 剩余红包金额
	writeInteger(corpsRedEnvelopeInfoList_remainingBonus);

	com.imop.lj.common.model.corps.OpenRedEnveloperInfo[] corpsRedEnvelopeInfoList_openRedEnveloperInfoList = corpsRedEnvelopeInfoList[corpsRedEnvelopeInfoListIndex].getOpenRedEnveloperInfoList();

	// 帮派抢到红包的玩家信息
	writeShort(corpsRedEnvelopeInfoList_openRedEnveloperInfoList.length);
	int corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex = 0;
	int corpsRedEnvelopeInfoList_openRedEnveloperInfoListSize = corpsRedEnvelopeInfoList_openRedEnveloperInfoList.length;
	for(corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex=0; corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex<corpsRedEnvelopeInfoList_openRedEnveloperInfoListSize; corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex++){

	long corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recId = corpsRedEnvelopeInfoList_openRedEnveloperInfoList[corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex].getRecId();

	// 抢到红包玩家id
	writeLong(corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recId);

	String corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recName = corpsRedEnvelopeInfoList_openRedEnveloperInfoList[corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex].getRecName();

	// 抢到红包玩家姓名
	writeString(corpsRedEnvelopeInfoList_openRedEnveloperInfoList_recName);

	long corpsRedEnvelopeInfoList_openRedEnveloperInfoList_openTime = corpsRedEnvelopeInfoList_openRedEnveloperInfoList[corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex].getOpenTime();

	// 抢到红包的时间
	writeLong(corpsRedEnvelopeInfoList_openRedEnveloperInfoList_openTime);

	int corpsRedEnvelopeInfoList_openRedEnveloperInfoList_gotBonus = corpsRedEnvelopeInfoList_openRedEnveloperInfoList[corpsRedEnvelopeInfoList_openRedEnveloperInfoListIndex].getGotBonus();

	// 抢到的红包金额
	writeInteger(corpsRedEnvelopeInfoList_openRedEnveloperInfoList_gotBonus);
	}
	//end
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OPEN_CORPS_RED_ENVELOPE_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_CORPS_RED_ENVELOPE_PANEL";
	}

	public com.imop.lj.common.model.corps.CorpsRedEnvelopeInfo[] getCorpsRedEnvelopeInfoList(){
		return corpsRedEnvelopeInfoList;
	}

	public void setCorpsRedEnvelopeInfoList(com.imop.lj.common.model.corps.CorpsRedEnvelopeInfo[] corpsRedEnvelopeInfoList){
		this.corpsRedEnvelopeInfoList = corpsRedEnvelopeInfoList;
	}	
}