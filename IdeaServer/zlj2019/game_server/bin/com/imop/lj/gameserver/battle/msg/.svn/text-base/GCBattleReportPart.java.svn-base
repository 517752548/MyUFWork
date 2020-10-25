package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 战斗的战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCBattleReportPart extends GCMessage{
	
	/** 0战斗开始，1每轮战报 */
	private int playType;
	/** 战报数据包 */
	private String reportPack;
	/** 战斗附加json串，主要是奖励等信息 */
	private String additionPack;

	public GCBattleReportPart (){
	}
	
	public GCBattleReportPart (
			int playType,
			String reportPack,
			String additionPack ){
			this.playType = playType;
			this.reportPack = reportPack;
			this.additionPack = additionPack;
	}

	@Override
	protected boolean readImpl() {

	// 0战斗开始，1每轮战报
	int _playType = readInteger();
	//end


	// 战报数据包
	String _reportPack = readString();
	//end


	// 战斗附加json串，主要是奖励等信息
	String _additionPack = readString();
	//end



		this.playType = _playType;
		this.reportPack = _reportPack;
		this.additionPack = _additionPack;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 0战斗开始，1每轮战报
	writeInteger(playType);


	// 战报数据包
	writeString(reportPack);


	// 战斗附加json串，主要是奖励等信息
	writeString(additionPack);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_BATTLE_REPORT_PART;
	}
	
	@Override
	public String getTypeName() {
		return "GC_BATTLE_REPORT_PART";
	}

	public int getPlayType(){
		return playType;
	}
		
	public void setPlayType(int playType){
		this.playType = playType;
	}

	public String getReportPack(){
		return reportPack;
	}
		
	public void setReportPack(String reportPack){
		this.reportPack = reportPack;
	}

	public String getAdditionPack(){
		return additionPack;
	}
		
	public void setAdditionPack(String additionPack){
		this.additionPack = additionPack;
	}
	public boolean isCompress() {
		return true;
	}
}