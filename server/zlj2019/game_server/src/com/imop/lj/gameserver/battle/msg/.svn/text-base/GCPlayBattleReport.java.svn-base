package com.imop.lj.gameserver.battle.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 服务器下发战报
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPlayBattleReport extends GCMessage{
	
	/** 战报id，Long格式，包含日期信息 */
	private long id;
	/** 战报数据包 */
	private String reportPack;
	/** 是否可以立即结束 */
	private int canClose;
	/** 是否显示Url */
	private int hasUrl;
	/** 战报读取完毕以后，前端返回场景id */
	private int toBackType;
	/** 战斗附加json串，主要是奖励等信息 */
	private String additionPack;

	public GCPlayBattleReport (){
	}
	
	public GCPlayBattleReport (
			long id,
			String reportPack,
			int canClose,
			int hasUrl,
			int toBackType,
			String additionPack ){
			this.id = id;
			this.reportPack = reportPack;
			this.canClose = canClose;
			this.hasUrl = hasUrl;
			this.toBackType = toBackType;
			this.additionPack = additionPack;
	}

	@Override
	protected boolean readImpl() {

	// 战报id，Long格式，包含日期信息
	long _id = readLong();
	//end


	// 战报数据包
	String _reportPack = readString();
	//end


	// 是否可以立即结束
	int _canClose = readInteger();
	//end


	// 是否显示Url
	int _hasUrl = readInteger();
	//end


	// 战报读取完毕以后，前端返回场景id
	int _toBackType = readInteger();
	//end


	// 战斗附加json串，主要是奖励等信息
	String _additionPack = readString();
	//end



		this.id = _id;
		this.reportPack = _reportPack;
		this.canClose = _canClose;
		this.hasUrl = _hasUrl;
		this.toBackType = _toBackType;
		this.additionPack = _additionPack;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 战报id，Long格式，包含日期信息
	writeLong(id);


	// 战报数据包
	writeString(reportPack);


	// 是否可以立即结束
	writeInteger(canClose);


	// 是否显示Url
	writeInteger(hasUrl);


	// 战报读取完毕以后，前端返回场景id
	writeInteger(toBackType);


	// 战斗附加json串，主要是奖励等信息
	writeString(additionPack);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PLAY_BATTLE_REPORT;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PLAY_BATTLE_REPORT";
	}

	public long getId(){
		return id;
	}
		
	public void setId(long id){
		this.id = id;
	}

	public String getReportPack(){
		return reportPack;
	}
		
	public void setReportPack(String reportPack){
		this.reportPack = reportPack;
	}

	public int getCanClose(){
		return canClose;
	}
		
	public void setCanClose(int canClose){
		this.canClose = canClose;
	}

	public int getHasUrl(){
		return hasUrl;
	}
		
	public void setHasUrl(int hasUrl){
		this.hasUrl = hasUrl;
	}

	public int getToBackType(){
		return toBackType;
	}
		
	public void setToBackType(int toBackType){
		this.toBackType = toBackType;
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