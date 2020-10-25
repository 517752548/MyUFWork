package com.imop.lj.gameserver.plotdungeon.msg;

import com.imop.lj.core.msg.MessageType;
import com.imop.lj.gameserver.common.msg.CGMessage;
import com.imop.lj.gameserver.plotdungeon.handler.PlotdungeonHandlerFactory;

/**
 * 请求挑战剧情副本
 * 
 * @author CodeGenerator, don't modify this file please.
 */
public class CGPlotDungeonStart extends CGMessage{
	
	/** 剧情副本类型,0-简单,1-精英 */
	private int plotDungeonType;
	/** 剧情副本进度 */
	private int plotDungeonLevel;
	
	public CGPlotDungeonStart (){
	}
	
	public CGPlotDungeonStart (
			int plotDungeonType,
			int plotDungeonLevel ){
			this.plotDungeonType = plotDungeonType;
			this.plotDungeonLevel = plotDungeonLevel;
	}
	
	@Override
	protected boolean readImpl() {

	// 剧情副本类型,0-简单,1-精英
	int _plotDungeonType = readInteger();
	//end


	// 剧情副本进度
	int _plotDungeonLevel = readInteger();
	//end



			this.plotDungeonType = _plotDungeonType;
			this.plotDungeonLevel = _plotDungeonLevel;
		return true;
	}
	
	@Override
	protected boolean writeImpl() {

	// 剧情副本类型,0-简单,1-精英
	writeInteger(plotDungeonType);


	// 剧情副本进度
	writeInteger(plotDungeonLevel);


		return true;
	}
	
	@Override
	public short getType() {
		return MessageType.CG_PLOT_DUNGEON_START;
	}
	
	@Override
	public String getTypeName() {
		return "CG_PLOT_DUNGEON_START";
	}

	public int getPlotDungeonType(){
		return plotDungeonType;
	}
		
	public void setPlotDungeonType(int plotDungeonType){
		this.plotDungeonType = plotDungeonType;
	}

	public int getPlotDungeonLevel(){
		return plotDungeonLevel;
	}
		
	public void setPlotDungeonLevel(int plotDungeonLevel){
		this.plotDungeonLevel = plotDungeonLevel;
	}


	@Override
	public void execute() {
		PlotdungeonHandlerFactory.getHandler().handlePlotDungeonStart(this.getSession().getPlayer(), this);
	}
}