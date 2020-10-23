package com.imop.lj.gameserver.plotdungeon.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回当前剧情副本情况
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCPlotDungeonInfo extends GCMessage{
	
	/** 剧情副本可开启的章节数 */
	private int plotDungeonChapter;
	/** 剧情副本类型,0-简单,1-精英 */
	private int plotDungeonType;
	/** 当前挑战剧情副本进度 */
	private int curPlotDungeonLevel;

	public GCPlotDungeonInfo (){
	}
	
	public GCPlotDungeonInfo (
			int plotDungeonChapter,
			int plotDungeonType,
			int curPlotDungeonLevel ){
			this.plotDungeonChapter = plotDungeonChapter;
			this.plotDungeonType = plotDungeonType;
			this.curPlotDungeonLevel = curPlotDungeonLevel;
	}

	@Override
	protected boolean readImpl() {

	// 剧情副本可开启的章节数
	int _plotDungeonChapter = readInteger();
	//end


	// 剧情副本类型,0-简单,1-精英
	int _plotDungeonType = readInteger();
	//end


	// 当前挑战剧情副本进度
	int _curPlotDungeonLevel = readInteger();
	//end



		this.plotDungeonChapter = _plotDungeonChapter;
		this.plotDungeonType = _plotDungeonType;
		this.curPlotDungeonLevel = _curPlotDungeonLevel;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 剧情副本可开启的章节数
	writeInteger(plotDungeonChapter);


	// 剧情副本类型,0-简单,1-精英
	writeInteger(plotDungeonType);


	// 当前挑战剧情副本进度
	writeInteger(curPlotDungeonLevel);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_PLOT_DUNGEON_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_PLOT_DUNGEON_INFO";
	}

	public int getPlotDungeonChapter(){
		return plotDungeonChapter;
	}
		
	public void setPlotDungeonChapter(int plotDungeonChapter){
		this.plotDungeonChapter = plotDungeonChapter;
	}

	public int getPlotDungeonType(){
		return plotDungeonType;
	}
		
	public void setPlotDungeonType(int plotDungeonType){
		this.plotDungeonType = plotDungeonType;
	}

	public int getCurPlotDungeonLevel(){
		return curPlotDungeonLevel;
	}
		
	public void setCurPlotDungeonLevel(int curPlotDungeonLevel){
		this.curPlotDungeonLevel = curPlotDungeonLevel;
	}
}