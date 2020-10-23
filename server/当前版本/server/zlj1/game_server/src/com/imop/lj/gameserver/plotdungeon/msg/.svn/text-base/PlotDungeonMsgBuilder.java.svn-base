package com.imop.lj.gameserver.plotdungeon.msg;

import java.util.List;

import com.imop.lj.common.model.plotdungeon.PlotDungeonInfo;

public class PlotDungeonMsgBuilder {

	public static GCPlotDungeonInfo createGCPlotDungeonInfo(int plotDungeonChapter, int plotDungeonType, int curPlotDungeonLevel){
		GCPlotDungeonInfo msg = new GCPlotDungeonInfo();
		msg.setPlotDungeonChapter(plotDungeonChapter);
		msg.setPlotDungeonType(plotDungeonType);
		msg.setCurPlotDungeonLevel(curPlotDungeonLevel);
		return msg;
	}
	
	public static GCDailyPlotDungeonInfo createGCDailyPlotDungeonInfo(List<PlotDungeonInfo> lst){
		GCDailyPlotDungeonInfo msg = new GCDailyPlotDungeonInfo();
		msg.setPlotDungeonInfoList(lst.toArray(new PlotDungeonInfo[0]));
		return msg;
	}
}
