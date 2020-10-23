package com.imop.lj.gameserver.corps.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回帮派福利面板
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCOpenCorpsBenifitPanel extends GCMessage{
	
	/** 帮派福利信息 */
	private com.imop.lj.common.model.corps.CorpsBenifitInfo corpsBenifitInfo;

	public GCOpenCorpsBenifitPanel (){
	}
	
	public GCOpenCorpsBenifitPanel (
			com.imop.lj.common.model.corps.CorpsBenifitInfo corpsBenifitInfo ){
			this.corpsBenifitInfo = corpsBenifitInfo;
	}

	@Override
	protected boolean readImpl() {
	// 帮派福利信息
	com.imop.lj.common.model.corps.CorpsBenifitInfo _corpsBenifitInfo = new com.imop.lj.common.model.corps.CorpsBenifitInfo();

	// 帮派ID
	long _corpsBenifitInfo_corpsId = readLong();
	//end
	_corpsBenifitInfo.setCorpsId (_corpsBenifitInfo_corpsId);

	// 上周帮贡 
	int _corpsBenifitInfo_lastWeekContribution = readInteger();
	//end
	_corpsBenifitInfo.setLastWeekContribution (_corpsBenifitInfo_lastWeekContribution);

	// 是否可领取 ,1可以,0不可以
	int _corpsBenifitInfo_canReceive = readInteger();
	//end
	_corpsBenifitInfo.setCanReceive (_corpsBenifitInfo_canReceive);



		this.corpsBenifitInfo = _corpsBenifitInfo;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	long corpsBenifitInfo_corpsId = corpsBenifitInfo.getCorpsId ();

	// 帮派ID
	writeLong(corpsBenifitInfo_corpsId);

	int corpsBenifitInfo_lastWeekContribution = corpsBenifitInfo.getLastWeekContribution ();

	// 上周帮贡 
	writeInteger(corpsBenifitInfo_lastWeekContribution);

	int corpsBenifitInfo_canReceive = corpsBenifitInfo.getCanReceive ();

	// 是否可领取 ,1可以,0不可以
	writeInteger(corpsBenifitInfo_canReceive);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_OPEN_CORPS_BENIFIT_PANEL;
	}
	
	@Override
	public String getTypeName() {
		return "GC_OPEN_CORPS_BENIFIT_PANEL";
	}

	public com.imop.lj.common.model.corps.CorpsBenifitInfo getCorpsBenifitInfo(){
		return corpsBenifitInfo;
	}
		
	public void setCorpsBenifitInfo(com.imop.lj.common.model.corps.CorpsBenifitInfo corpsBenifitInfo){
		this.corpsBenifitInfo = corpsBenifitInfo;
	}
}