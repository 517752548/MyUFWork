package com.imop.lj.gameserver.plotdungeon.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.plotdungeon.handler.PlotdungeonHandlerFactory;

/**
 * 领取每日剧情副本奖励
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGGetDailyPlotDungeonReward extends CGMessage{
	
	/** 剧情副本类型,0-简单,1-精英 */
	private int plotDungeonType;
	/** 剧情副本章数 */
	private int plotDungeonChapter;
	
	public CGGetDailyPlotDungeonReward (){
	}
	
	public CGGetDailyPlotDungeonReward (
			int plotDungeonType,
			int plotDungeonChapter ){
			this.plotDungeonType = plotDungeonType;
			this.plotDungeonChapter = plotDungeonChapter;
	}
	
	@Override
	protected boolean readImpl() {

	// 剧情副本类型,0-简单,1-精英
	int _plotDungeonType = readInteger();
	//end


	// 剧情副本章数
	int _plotDungeonChapter = readInteger();
	//end



			this.plotDungeonType = _plotDungeonType;
			this.plotDungeonChapter = _plotDungeonChapter;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 剧情副本类型,0-简单,1-精英
	writeInteger(plotDungeonType);


	// 剧情副本章数
	writeInteger(plotDungeonChapter);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_GET_DAILY_PLOT_DUNGEON_REWARD;
	}
	
	@Override
	public String getTypeName() {
		return "CG_GET_DAILY_PLOT_DUNGEON_REWARD";
	}

	public int getPlotDungeonType(){
		return plotDungeonType;
	}
		
	public void setPlotDungeonType(int plotDungeonType){
		this.plotDungeonType = plotDungeonType;
	}

	public int getPlotDungeonChapter(){
		return plotDungeonChapter;
	}
		
	public void setPlotDungeonChapter(int plotDungeonChapter){
		this.plotDungeonChapter = plotDungeonChapter;
	}


	@Override
	public void execute() {
		PlotdungeonHandlerFactory.getHandler().handleGetDailyPlotDungeonReward(this.getSession().getPlayer(), this);
	}
}