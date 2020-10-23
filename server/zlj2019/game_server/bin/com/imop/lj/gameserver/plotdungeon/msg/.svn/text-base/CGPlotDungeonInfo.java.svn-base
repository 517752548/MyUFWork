package com.imop.lj.gameserver.plotdungeon.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.plotdungeon.handler.PlotdungeonHandlerFactory;

/**
 * 查看当前剧情副本情况
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlotDungeonInfo extends CGMessage{
	
	/** 剧情副本类型,0-简单,1-精英 */
	private int plotDungeonType;
	
	public CGPlotDungeonInfo (){
	}
	
	public CGPlotDungeonInfo (
			int plotDungeonType ){
			this.plotDungeonType = plotDungeonType;
	}
	
	@Override
	protected boolean readImpl() {

	// 剧情副本类型,0-简单,1-精英
	int _plotDungeonType = readInteger();
	//end



			this.plotDungeonType = _plotDungeonType;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 剧情副本类型,0-简单,1-精英
	writeInteger(plotDungeonType);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PLOT_DUNGEON_INFO;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PLOT_DUNGEON_INFO";
	}

	public int getPlotDungeonType(){
		return plotDungeonType;
	}
		
	public void setPlotDungeonType(int plotDungeonType){
		this.plotDungeonType = plotDungeonType;
	}


	@Override
	public void execute() {
		PlotdungeonHandlerFactory.getHandler().handlePlotDungeonInfo(this.getSession().getPlayer(), this);
	}
}