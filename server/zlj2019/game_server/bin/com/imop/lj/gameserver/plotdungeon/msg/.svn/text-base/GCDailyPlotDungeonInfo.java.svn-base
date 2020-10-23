package com.imop.lj.gameserver.plotdungeon.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.GCMessage;
/**
 * 返回每日剧情副本奖励信息
 *
 * @author CodeGenerator, don't modify this file please.
 */
public class GCDailyPlotDungeonInfo extends GCMessage{
	
	/** 每日剧情副本奖励信息 */
	private com.imop.lj.common.model.plotdungeon.PlotDungeonInfo[] plotDungeonInfoList;

	public GCDailyPlotDungeonInfo (){
	}
	
	public GCDailyPlotDungeonInfo (
			com.imop.lj.common.model.plotdungeon.PlotDungeonInfo[] plotDungeonInfoList ){
			this.plotDungeonInfoList = plotDungeonInfoList;
	}

	@Override
	protected boolean readImpl() {

	// 每日剧情副本奖励信息
	int plotDungeonInfoListSize = readUnsignedShort();
	com.imop.lj.common.model.plotdungeon.PlotDungeonInfo[] _plotDungeonInfoList = new com.imop.lj.common.model.plotdungeon.PlotDungeonInfo[plotDungeonInfoListSize];
	int plotDungeonInfoListIndex = 0;
	for(plotDungeonInfoListIndex=0; plotDungeonInfoListIndex<plotDungeonInfoListSize; plotDungeonInfoListIndex++){
		_plotDungeonInfoList[plotDungeonInfoListIndex] = new com.imop.lj.common.model.plotdungeon.PlotDungeonInfo();
	// 剧情副本类型,0-简单,1-精英
	int _plotDungeonInfoList_plotDungeonType = readInteger();
	//end
	_plotDungeonInfoList[plotDungeonInfoListIndex].setPlotDungeonType (_plotDungeonInfoList_plotDungeonType);

	// 剧情副本章数
	int _plotDungeonInfoList_plotDungeonChapter = readInteger();
	//end
	_plotDungeonInfoList[plotDungeonInfoListIndex].setPlotDungeonChapter (_plotDungeonInfoList_plotDungeonChapter);

	// 剧情副本状态,0-不可领取,1-可领取但未领取,2-已领取
	int _plotDungeonInfoList_plotDungeonStatus = readInteger();
	//end
	_plotDungeonInfoList[plotDungeonInfoListIndex].setPlotDungeonStatus (_plotDungeonInfoList_plotDungeonStatus);
	}
	//end



		this.plotDungeonInfoList = _plotDungeonInfoList;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 每日剧情副本奖励信息
	writeShort(plotDungeonInfoList.length);
	int plotDungeonInfoListIndex = 0;
	int plotDungeonInfoListSize = plotDungeonInfoList.length;
	for(plotDungeonInfoListIndex=0; plotDungeonInfoListIndex<plotDungeonInfoListSize; plotDungeonInfoListIndex++){

	int plotDungeonInfoList_plotDungeonType = plotDungeonInfoList[plotDungeonInfoListIndex].getPlotDungeonType();

	// 剧情副本类型,0-简单,1-精英
	writeInteger(plotDungeonInfoList_plotDungeonType);

	int plotDungeonInfoList_plotDungeonChapter = plotDungeonInfoList[plotDungeonInfoListIndex].getPlotDungeonChapter();

	// 剧情副本章数
	writeInteger(plotDungeonInfoList_plotDungeonChapter);

	int plotDungeonInfoList_plotDungeonStatus = plotDungeonInfoList[plotDungeonInfoListIndex].getPlotDungeonStatus();

	// 剧情副本状态,0-不可领取,1-可领取但未领取,2-已领取
	writeInteger(plotDungeonInfoList_plotDungeonStatus);
	}
	//end


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.GC_DAILY_PLOT_DUNGEON_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "GC_DAILY_PLOT_DUNGEON_INFO";
	}

	public com.imop.lj.common.model.plotdungeon.PlotDungeonInfo[] getPlotDungeonInfoList(){
		return plotDungeonInfoList;
	}

	public void setPlotDungeonInfoList(com.imop.lj.common.model.plotdungeon.PlotDungeonInfo[] plotDungeonInfoList){
		this.plotDungeonInfoList = plotDungeonInfoList;
	}	
}